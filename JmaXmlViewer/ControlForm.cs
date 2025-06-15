using System.Xml.Serialization;
using static JmaXmlViewer.Utilities.Converters;
using static JmaXmlViewer.Utilities.DataClass;
using static JmaXmlViewer.Utilities.XmlClass;
using static JmaXmlViewer.Utilities.Functions;
using static JmaXmlViewer.Utilities.ExternalConnects;
using static JmaXmlViewer.DataProcess.Other.Processes_Other;
using static JmaXmlViewer.DataProcess.Extra.Processes_Extra;

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
            //VGSK50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\01_01_01_091210_VGSK50.xml"));
            //VGSK50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\01_01_02_091210_VGSK50.xml"));
            //VGSK50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\01_01_03_091210_VGSK50.xml"));



            //VPTI50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\06_01_01_100514_VPTI50.xml"));
            //VPTI50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\06_02_01_100514_VPTI50.xml"));
            //VPTI50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\06_03_01_200630_VPTI50.xml"));
            //VPTI50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\06_04_01_200826_VPTI50.xml"));
            //VPTI50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\06_04_02_200826_VPTI50.xml"));
            //VPTI50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\06_04_03_200826_VPTI50.xml"));
            //VPTI50(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\06_04_04_200826_VPTI50.xml"));

            //VPTI51(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\07_01_01_100514_VPTI51.xml"));
            //VPTI51(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\07_01_02_100514_VPTI51.xml"));
            //VPTI51(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\07_02_01_100806_VPTI51.xml"));
            //VPTI51(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\07_03_01_100514_VPTI51.xml"));
            //VPTI51(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\07_04_01_200826_VPTI51.xml"));
            //VPTI51(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\07_04_02_200826_VPTI51.xml"));
            //VPTI51(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\07_04_03_200826_VPTI51.xml"));
            //VPTI51(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\07_04_04_200826_VPTI51.xml"));

            //VPTI52(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\08_01_01_110126_VPTI52.xml"));
            //VPTI52(File.ReadAllText(@"D:\Ichihai1415\data\jma\xml\jmaxml_20250318_Samples\08_01_02_100806_VPTI52.xml"));










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
            //Console.WriteLine("[ProcessPerSec] " + now.ToString("HH:mm:ss.ffff"));
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
            var serializer = new XmlSerializer(typeof(C_Feed)) ?? throw new Exception("XmlSerializerの初期化に失敗しました。");
            var xmlSt = await client.GetStringAsync("https://www.data.jma.go.jp/developer/xml/feed/" + type + ".xml");
            using var reader = new StringReader(xmlSt);
            var feed = (C_Feed?)serializer.Deserialize(reader) ?? throw new Exception("Feedの取得に失敗しました。"); ;
            Console.WriteLine("[GetFeed] " + feed.Title + " " + feed.Updated);
            var processEntries = new List<C_Feed.C_Entry>();
            foreach (var entry in feed.Entry)
            {
                //Console.WriteLine($"Title: {entry.Title}, Updated: {entry.Updated}, ID: {entry.Id}");
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
                        Console.WriteLine("[GetFeed] 既存のため更新判定終了");
                        break;//新しい順前提
                    }
                    else
                    {
                        entries.Add(fileName);
                        processEntries.Add(entry);
                        Console.WriteLine("[GetFeed] 追加: " + type + " " + code + " " + fileName);
                    }
                }
                else
                {
                    codeEntries.Add(code, [fileName]);
                    processEntries.Add(entry);
                    Console.WriteLine("[GetFeed] 追加: " + type + " " + code + " " + fileName);
                }
            }
            if (isInitial || processEntries.Count == 0) return;
            processEntries.Reverse();
            foreach (var entry in processEntries)
            {
                var code = GetCode(entry.Id);


            }
            GC.Collect();
        }
    }
}
