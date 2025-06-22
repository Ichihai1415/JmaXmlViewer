using Ichihai1415.GeoJSON;
using System.Text.Json;
using static JmaXmlViewer.Utilities.Enums;
using static JmaXmlViewer.Utilities.Functions;
using static JmaXmlViewer.ControlForm;

namespace JmaXmlViewer.Utilities
{
    internal class Draw
    {
        internal static Bitmap DrawData<T>(T data)
        {
            ExeLog("[DrawData<" + nameof(T) + ">] 描画を開始します", ConsoleColor.Green);
            var bitmap = new Bitmap(1920, 1080);
            using var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(30, 30, 60));






            return bitmap;
        }


        internal static void DrawMap<T>(T data, Graphics g, Config_Draw_Internal config)
        {
            var mapJson = mapJsons[config.MapType];
            if (mapJson == null)
            {
                ExeLog("[DrawMap<" + nameof(T) + ">] マップデータ読み込み中...", ConsoleColor.Green);
                var mapJsonSt = File.ReadAllText("Resources\\MapData\\" + mapDataFilenames[config.MapType]);
                mapJson = GeoJSONHelper.Deserialize<GeoJSONScheme.GeoJSON_JMA_Map>(mapJsonSt);

            }


            if ()

        }
    }
}
