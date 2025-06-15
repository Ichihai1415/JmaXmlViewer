using System.Data.SqlTypes;
using System.Xml.Serialization;
using static JmaXmlViewer.DataProcess.Processes;
using static JmaXmlViewer.Utilities.Converters;
using static JmaXmlViewer.Utilities.DataClass;
using static JmaXmlViewer.Utilities.ExternalConnects;
using static JmaXmlViewer.Utilities.Functions;
using static JmaXmlViewer.Utilities.XmlClass;

namespace JmaXmlViewer
{
    public partial class ControlForm : Form
    {
        internal static readonly HttpClient client = new();

        internal static FeedIndex feedIndex = new();

        internal static bool isInitial = true;

        public ControlForm()
        {
            InitializeComponent();
        }

        private async void ControlForm_Load(object sender, EventArgs e)
        {
            //ProcessPerSec.Enabled = false;
            //return;

            await GetFeed("regular");
            await GetFeed("extra");
            await GetFeed("eqvol");
            await GetFeed("other");
            isInitial = false;
        }

        private async void ProcessPerSec_Tick(object sender, EventArgs e)
        {
            ProcessPerSec.Enabled = false;
            while (DateTime.Now.Millisecond > 800)
                await Task.Delay(50);
            var now = DateTime.Now;
            ProcessPerSec.Interval = 1000 - now.Millisecond;
            ProcessPerSec.Enabled = true;
            //ExeLog("[ProcessPerSec] " + now.ToString("HH:mm:ss.ffff"));
            switch (now.Second)
            {
                case 0:
                    await GetFeed("regular");
                    break;
                case 15:
                    await GetFeed("extra");
                    break;
                case 30:
                    await GetFeed("eqvol");
                    break;
                case 45:
                    await GetFeed("other");
                    break;
            }

        }

        internal async Task GetFeed(string type)
        {
            var serializer_feed = new XmlSerializer(typeof(C_Feed)) ?? throw new Exception("XmlSerializerの初期化に失敗しました。");
            ExeLog("[GetFeed] 取得中: " + "https://www.data.jma.go.jp/developer/xml/feed/" + type + ".xml");
            var xmlSt = await client.GetStringAsync("https://www.data.jma.go.jp/developer/xml/feed/" + type + ".xml");
            using var reader_feed = new StringReader(xmlSt);
            var feed = (C_Feed?)serializer_feed.Deserialize(reader_feed) ?? throw new Exception("Feedの取得に失敗しました。"); ;
            ExeLog("[GetFeed] " + feed.Title + " " + feed.Updated);
            var processEntries = new List<C_Feed.C_Entry>();
            foreach (var entry in feed.Entry)
            {
                //ExeLog($"Title: {entry.Title}, Updated: {entry.Updated}, ID: {entry.Id}");
                var code = GetCode(entry.Id);
                var fileName = entry.Id.Split('/').Last() ?? throw new Exception("ファイル名の取得に失敗しました。");
                var codeEntries = type switch
                {
                    "regular" => feedIndex.CodeEntries_Regular,
                    "extra" => feedIndex.CodeEntries_Extra,
                    "eqvol" => feedIndex.CodeEntries_Eqvol,
                    "other" => feedIndex.CodeEntries_Other,
                    _ => throw new ArgumentException("type(" + type + ")が不明です。", nameof(type))
                };
                if (codeEntries.TryGetValue(code, out var entries))
                {
                    if (entries.Contains(fileName))
                    {
                        ExeLog("[GetFeed] 既存のため更新判定終了");
                        break;//新しい順前提
                    }
                    else
                    {
                        entries.Add(fileName);
                        processEntries.Add(entry);
                        ExeLog("[GetFeed] 追加: " + type + " " + code + " " + fileName);
                    }
                }
                else
                {
                    codeEntries.Add(code, [fileName]);
                    processEntries.Add(entry);
                    ExeLog("[GetFeed] 追加: " + type + " " + code + " " + fileName);
                }
            }
            if (isInitial || processEntries.Count == 0) return;
            processEntries.Reverse();
            foreach (var entry in processEntries)
            {
                var code = GetCode(entry.Id);

                ExeLog("[GetFeed] 取得中: " + entry.Id);
                var entryXmlString = await client.GetStringAsync(entry.Id);
                var serializer_entry = new XmlSerializer(typeof(Utilities.XmlClass_XSD.C_Report));
                using var reader_entry = new StringReader(entryXmlString);
                var xml = (Utilities.XmlClass_XSD.C_Report?)serializer_entry.Deserialize(reader_entry) ?? throw new Exception("XMLの読み込みに失敗しました。");

                CommonSimple(xml);

            }
            GC.Collect();
        }
    }
}
