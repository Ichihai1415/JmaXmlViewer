using System.Xml.Serialization;
using static JmaXmlViewer.DataProcess.Processes;
using static JmaXmlViewer.Utilities.Converters;
using static JmaXmlViewer.Utilities.DataClass;
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
            ExeLog("[ControlForm_Load] フォーム初期化開始", ConsoleColor.Green);
            InitializeComponent();
        }

        private async void ControlForm_Load(object sender, EventArgs e)
        {
            //SampleTest(@"C:\Ichihai1415\data\jmaxml_20250318_Samples");
            //ProcessPerSec.Enabled = false;
            //return;

            ExeLog("[ControlForm_Load] 初期取得開始", ConsoleColor.Green);
            await GetFeed("regular");
            await GetFeed("extra");
            await GetFeed("eqvol");
            await GetFeed("other");
            isInitial = false;
            ExeLog("[ControlForm_Load] 初期取得終了", ConsoleColor.Green);
        }

        private async void ProcessPerSec_Tick(object sender, EventArgs e)
        {
            ProcessPerSec.Enabled = false;
            while (DateTime.Now.Millisecond > 800)
            {
                //ExeLog("[ProcessPerSec_Tick] タイマーイベントが呼び出されましたが、想定より早いです。時間調整します。", ConsoleColor.DarkGray);
                await Task.Delay(50);
            }
            var now = DateTime.Now;
            ProcessPerSec.Interval = 1000 - now.Millisecond;
            ProcessPerSec.Enabled = true;
            //ExeLog("[ProcessPerSec] " + now.ToString("HH:mm:ss.ffff"));
            switch (now.Second)
            {
                case 7:
                    await GetFeed("regular");
                    break;
                case 22:
                    await GetFeed("extra");
                    break;
                case 37:
                    await GetFeed("eqvol");
                    break;
                case 52:
                    await GetFeed("other");
                    break;
                default:
                    return;
            }
            ExeLog("[ProcessPerSec_Tick] フィード取得完了", ConsoleColor.Green);
        }

        //一時
        public static string[] ignoreCodes = [ "VPWW53", "VXSE51", "VXSE52", "VXSE53","VPCU51","VPCY51",
            //regular
            "VPFG50", "VPFD50", "VPFD51", "VPZW50", "VPCW50", "VPFW50", "VPZK50", "VPCK50", "VPFD60", "VPFW60", "VZSA50", "VZSF50", "VZSF51", "VZSA60", "VZSF60", "VZSF61", "VPZK70", "VPCK70", "VPRN50" ];//仮、設定でやる

        internal async Task GetFeed(string type)
        {
            try
            {
                var serializer_feed = new XmlSerializer(typeof(C_Feed)) ?? throw new Exception("XmlSerializerの初期化に失敗しました。");
                ExeLog("[GetFeed] 取得中: " + "https://www.data.jma.go.jp/developer/xml/feed/" + type + ".xml", ConsoleColor.Green);
                var xmlSt = await client.GetStringAsync("https://www.data.jma.go.jp/developer/xml/feed/" + type + ".xml");
                using var reader_feed = new StringReader(xmlSt);
                var feed = (C_Feed?)serializer_feed.Deserialize(reader_feed) ?? throw new Exception("Feedの取得に失敗しました。");
                ExeLog("[GetFeed] Name: " + feed.Title + ", Updated: " + feed.Updated, ConsoleColor.Cyan);
                var processEntries = new List<C_Feed.C_Entry>();
                foreach (var entry in feed.Entry)
                {
                    //ExeLog("[GetFeed] Title: " + entry.Title + ", Updated: " + entry.Updated + ", ID: " + entry.Id, ConsoleColor.Cyan);
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
                            ExeLog("[GetFeed] 既存のため更新判定終了", ConsoleColor.Green);
                            break;//新しい順前提
                        }
                        else
                        {
                            entries.Add(fileName);
                            processEntries.Add(entry);
                            ExeLog("[GetFeed] 追加(既存コード): " + type + " " + code + " " + entry.Title + " " + fileName, ConsoleColor.Blue);
                        }
                    }
                    else
                    {
                        codeEntries.Add(code, [fileName]);
                        processEntries.Add(entry);
                        ExeLog("[GetFeed] 追加(新規コード): " + type + " " + code + " " + entry.Title + " " + fileName, ConsoleColor.Blue);
                    }
                }

                if (isInitial || processEntries.Count == 0) return;
                processEntries.Reverse();
                foreach (var entry in processEntries)
                {
                    var code = GetCode(entry.Id);

                    if (ignoreCodes.Contains(code))
                    {
                        ExeLog("[GetFeed] 詳細取得対象外: " + code, ConsoleColor.DarkGray);
                        continue;
                    }

                    ExeLog("[GetFeed] 取得中: " + entry.Id, ConsoleColor.Green);
                    var entryXmlString = await client.GetStringAsync(entry.Id);
                    var serializer_entry = new XmlSerializer(typeof(Utilities.XmlClass_XSD.C_Report));
                    using var reader_entry = new StringReader(entryXmlString);
                    var xml = (Utilities.XmlClass_XSD.C_Report?)serializer_entry.Deserialize(reader_entry) ?? throw new Exception("XMLの読み込みに失敗しました。");

                    Process_CommonSimple(xml);

                }
            }
            catch (Exception ex)
            {//todo:errorlogに移行
                ExeLog("[GetFeed] エラー: " + ex, ConsoleColor.Red);
                Directory.CreateDirectory("Log\\Error\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.Day);
                File.WriteAllText("Log\\Error\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.Day + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public static void SampleTest(string rootPath)
        {
            if (Directory.Exists(rootPath))
            {
                string[] xmlFiles = Directory.GetFiles(rootPath, "*.xml");

                foreach (string file in xmlFiles)
                {
                    try
                    {
                        Console.WriteLine($"Processing: {file}");
                        var entryXmlString = File.ReadAllText(file);
                        var serializer_entry = new XmlSerializer(typeof(Utilities.XmlClass_XSD.C_Report));
                        using var reader_entry = new StringReader(entryXmlString);
                        var xml = (Utilities.XmlClass_XSD.C_Report?)serializer_entry.Deserialize(reader_entry) ?? throw new Exception("XMLの読み込みに失敗しました。");

                        Process_CommonSimple(xml);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing {file}: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("指定されたフォルダが見つかりません。");
            }
        }
    }
}
