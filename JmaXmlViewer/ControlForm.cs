using Ichihai1415.GeoJSON;
using JmaXmlViewer.Utilities;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Xml.Serialization;
using static JmaXmlViewer.DataProcess.Processes;
using static JmaXmlViewer.Utilities.Converters;
using static JmaXmlViewer.Utilities.DataClass;
using static JmaXmlViewer.Utilities.Draw;
using static JmaXmlViewer.Utilities.Enums;
using static JmaXmlViewer.Utilities.Functions;
using static JmaXmlViewer.Utilities.XmlClass;

namespace JmaXmlViewer
{
    public partial class ControlForm : Form
    {
        public static readonly string VERSION = Assembly.GetExecutingAssembly().GetName().Version!.ToString();

        internal static readonly HttpClient client = new();

        internal static FeedIndex feedIndex = new();

        internal static bool isInitial = true;

        internal static string dataUrl_map = "";

        internal static readonly string[] MAP_DATA_FILES = ["AreaForecast", "AreaForecastEEW", "AreaForecastLocalE", "AreaForecastLocalEEW", "AreaForecastLocalM_1saibun",
            "AreaForecastLocalM_matome", "AreaForecastLocalM_prefecture", "AreaInformationCity_landslide", "AreaInformationCity_quake", "AreaInformationCity_risk",
            "AreaInformationCity_river", "AreaInformationCity_volcano", "AreaInformationCity_weather", "AreaInformationPrefectureEarthquake", "AreaMarineAJ", "AreaTsunami"];


        internal static Dictionary<MapType, GeoJSONScheme.GeoJSON_JMA_Map?> mapJsons = [];
        internal static Dictionary<MapType, string> mapDataFilenames = [];

        internal static Config config = new();

        public ControlForm()
        {
            ConWrite(string.Empty, false);//defaultColorの設定
            ExeLog("[ControlForm_Load] フォーム初期化開始", ConsoleColor.Green);
            InitializeComponent();
        }

        private async void ControlForm_Load(object sender, EventArgs e)
        {
#if !DEBUG
            //todo: ばーじょんちぇっく

#endif
            //追加処理あれば第二引数にTask
            CheckDirectory("Resources");
            CheckDirectory("Resources\\MapData");

            try
            {
                dataUrl_map = File.Exists("Config\\url_map.txt") ? File.ReadAllText("Config\\url_map.txt") : "https://raw.githubusercontent.com/Ichihai1415/JMA-GIS-GeoJSON/refs/heads/release/";
                ExeLog("[ControlForm_Load] マップデータバージョン取得中...", ConsoleColor.Green);
                var mapVersion = await client.GetStringAsync(dataUrl_map + "_update_date.txt");
                var mapVersion_file = File.Exists("Resources\\MapData\\_update_date.txt") ? File.ReadAllText("Resources\\MapData\\_update_date.txt") : "";
                if (mapVersion != mapVersion_file)
                {
                    ExeLog("[ControlForm_Load] マップデータの更新があります。パラメータ取得中...", ConsoleColor.Green);

                    var newMapDataParamSt = await client.GetStringAsync(dataUrl_map + "_url.json")!;
                    var newMapDataParam = JsonNode.Parse(newMapDataParamSt)!;

                    var existFiles = Directory.GetFiles("Resources\\MapData", "*.geojson", SearchOption.TopDirectoryOnly)
                        .Select(f => Path.GetFileName(f).Replace("AreaForecastLocalM_", "AreaForecastLocalM-").Replace("AreaInformationCity_", "AreaInformationCity-").Split('_')).ToArray();
                    //_が余計にあるものを一時置換
                    // ex. AreaForecastEEW_GIS_20190125_01.geojson -> [0]AreaForecastEEW [1]GIS [2]20190125 [3]01.geojson
                    foreach (var file in MAP_DATA_FILES)
                        foreach (var simpleRateExtension in new string[] { "01.geojson", "1.geojson" })
                        {
                            var newVersion = newMapDataParam["updateTime"]![file]!.ToString();
                            var isExist = false;
                            foreach (var existFile in existFiles)
                            {
                                if (existFile.Length != 4) throw new Exception("マップデータのファイル名が不正です。");
                                if (existFile[0].Replace("-", "_") == file && existFile[3] == simpleRateExtension)
                                {
                                    var existVersion = existFile[2];
                                    if (existVersion != newVersion)
                                    {
                                        ExeLog("[ControlForm_Load] 削除: " + file + "_GIS_" + existVersion + "_" + simpleRateExtension, ConsoleColor.Green);
                                        File.Delete("Resources\\MapData\\" + file + "_GIS_" + existVersion + "_" + simpleRateExtension);
                                        ExeLog("[ControlForm_Load] ダウンロード(更新): " + file + "_GIS_" + newVersion + "_" + simpleRateExtension, ConsoleColor.Green);
                                        var newData = await client.GetStringAsync(dataUrl_map + file + "_GIS_" + newVersion + "_" + simpleRateExtension);
                                        File.WriteAllText("Resources\\MapData\\" + file + "_GIS_" + newVersion + "_" + simpleRateExtension, newData);
                                    }
                                    isExist = true;
                                    break;
                                }
                            }
                            if (!isExist)
                            {
                                ExeLog("[ControlForm_Load] ダウンロード(新規): " + file + "_GIS_" + newVersion + "_" + simpleRateExtension, ConsoleColor.Green);
                                var newData = await client.GetStringAsync(dataUrl_map + file + "_GIS_" + newVersion + "_" + simpleRateExtension);
                                File.WriteAllText("Resources\\MapData\\" + file + "_GIS_" + newVersion + "_" + simpleRateExtension, newData);
                            }
                        }
                    File.WriteAllText("Resources\\MapData\\_update_date.txt", mapVersion);
                    ExeLog("[ControlForm_Load] マップデータ更新終了", ConsoleColor.Green);
                }
                else
                    ExeLog("[ControlForm_Load] マップデータは最新です。", ConsoleColor.Green);
                ExeLog("[ControlForm_Load] なお、変換は手動のため気象庁Webページの更新より遅れます。更新がある場合開発者に連絡してください。", ConsoleColor.Green);

                ExeLog("[ControlForm_Load] マップデータ読み込み中...", ConsoleColor.Green);
                var mapDataFiles = Directory.GetFiles("Resources\\MapData", "*.geojson", SearchOption.TopDirectoryOnly)
                       .Select(f => Path.GetFileName(f).Replace("AreaForecastLocalM_", "AreaForecastLocalM-").Replace("AreaInformationCity_", "AreaInformationCity-").Split('_')).ToArray();
                foreach (var file in mapDataFiles)
                {
                    if (file.Length != 4) throw new Exception("マップデータのファイル名が不正です。");
                    var filename = string.Join("_", file).Replace("-", "_");
                    GeoJSONScheme.GeoJSON_JMA_Map? mapJson = null;
                    if (!config.MapLoadEachTime)
                        mapJson = GetMapData(filename);

                    var mapType = (file[0] + file[3]) switch
                    {
                        "AreaForecast01.geojson" => MapType.AreaForecast_01,
                        "AreaForecast1.geojson" => MapType.AreaForecast_1,
                        "AreaForecastEEW01.geojson" => MapType.AreaForecastEEW_01,
                        "AreaForecastEEW1.geojson" => MapType.AreaForecastEEW_1,
                        "AreaForecastLocalE01.geojson" => MapType.AreaForecastLocalE_01,
                        "AreaForecastLocalE1.geojson" => MapType.AreaForecastLocalE_1,
                        "AreaForecastLocalEEW01.geojson" => MapType.AreaForecastLocalEEW_01,
                        "AreaForecastLocalEEW1.geojson" => MapType.AreaForecastLocalEEW_1,
                        "AreaForecastLocalM-1saibun01.geojson" => MapType.AreaForecastLocalM_1saibun_01,
                        "AreaForecastLocalM-1saibun1.geojson" => MapType.AreaForecastLocalM_1saibun_1,
                        "AreaForecastLocalM-matome01.geojson" => MapType.AreaForecastLocalM_matome_01,
                        "AreaForecastLocalM-matome1.geojson" => MapType.AreaForecastLocalM_matome_1,
                        "AreaForecastLocalM-prefecture01.geojson" => MapType.AreaForecastLocalM_prefecture_01,
                        "AreaForecastLocalM-prefecture1.geojson" => MapType.AreaForecastLocalM_prefecture_1,
                        "AreaInformationCity-landslide01.geojson" => MapType.AreaInformationCity_landslide_01,
                        "AreaInformationCity-landslide1.geojson" => MapType.AreaInformationCity_landslide_1,
                        "AreaInformationCity-quake01.geojson" => MapType.AreaInformationCity_quake_01,
                        "AreaInformationCity-quake1.geojson" => MapType.AreaInformationCity_quake_1,
                        "AreaInformationCity-risk01.geojson" => MapType.AreaInformationCity_risk_01,
                        "AreaInformationCity-risk1.geojson" => MapType.AreaInformationCity_risk_1,
                        "AreaInformationCity-river01.geojson" => MapType.AreaInformationCity_river_01,
                        "AreaInformationCity-river1.geojson" => MapType.AreaInformationCity_river_1,
                        "AreaInformationCity-volcano01.geojson" => MapType.AreaInformationCity_volcano_01,
                        "AreaInformationCity-volcano1.geojson" => MapType.AreaInformationCity_volcano_1,
                        "AreaInformationCity-weather01.geojson" => MapType.AreaInformationCity_weather_01,
                        "AreaInformationCity-weather1.geojson" => MapType.AreaInformationCity_weather_1,
                        "AreaInformationPrefectureEarthquake01.geojson" => MapType.AreaInformationPrefectureEarthquake_01,
                        "AreaInformationPrefectureEarthquake1.geojson" => MapType.AreaInformationPrefectureEarthquake_1,
                        "AreaMarineAJ01.geojson" => MapType.AreaMarineAJ_01,
                        "AreaMarineAJ1.geojson" => MapType.AreaMarineAJ_1,
                        "AreaTsunami01.geojson" => MapType.AreaTsunami_01,
                        "AreaTsunami1.geojson" => MapType.AreaTsunami_1,
                        _ => throw new Exception("マップデータ名が不明です。")
                    };

                    mapJsons[mapType] = mapJson;
                    mapDataFilenames[mapType] = filename;
                }
                ExeLog("[ControlForm_Load] マップデータ読み込み完了", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                ExeLog("[ControlForm_Load] マップデータの取得、読み込み中にエラーが発生しました。開発者に連絡してください。", ConsoleColor.Red);
                ErrorLog("[ControlForm_Load]", ex);
                return;
            }


            BackgroundImage = DrawData(new FeedIndex());

            return;//テスト用

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
            ProcessPerSec.Enabled = true;
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
        internal static string[] ignoreCodes = [ "VPWW53", "VXSE51", "VXSE52", "VXSE53", "VPCU51", "VPCY51", "VPZU52","VFVO60","VPTW60",
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
            {
                ErrorLog("[GetFeed]", ex);
            }
            finally
            {
                GC.Collect();
            }
        }

        /*
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
        }*/
    }
}
