using Ichihai1415.GeoJSON;
using System.Drawing.Drawing2D;
using static Ichihai1415.GeoJSON.GeoJSONScheme.GeoJSON_JMA_Map;
using static JmaXmlViewer.ControlForm;
using static JmaXmlViewer.Utilities.Enums;
using static JmaXmlViewer.Utilities.Functions;

namespace JmaXmlViewer.Utilities
{
    internal class Draw
    {
        internal static Bitmap DrawData<T>(T data)
        {
            ExeLog("[DrawData<" + typeof(T).Name + ">] 描画を開始します。", ConsoleColor.Green);
            var bitmap = new Bitmap(1920, 1080);
            using var g = Graphics.FromImage(bitmap);
            g.Clear(Color.FromArgb(0, 0, 0));
            if (config.Enable_AntiAlias)
            {
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
            }

            DrawMap(g, new Config_Draw_Internal()
            {
                Width = bitmap.Width,
                Height = bitmap.Height,
                LatSta = 20,
                LatEnd = 50,
                LonSta = 120,
                LonEnd = 150,
                Zoom = 36,
                MapType = MapType.AreaForecastLocalM_prefecture_01,
                DrawCodeColor_Fill = new Dictionary<string, Color>() { { "1342100", Color.Purple },{ "130000",Color.Purple } },
                DefaultColor_Fill = Color.FromArgb(30, 60, 90),
                DrawCodeColor_Line = new Dictionary<string, Color>() { { "1342100", Color.Yellow } },
                DefaultColor_Line = Color.FromArgb(216, 255, 255, 255),
                LineWidth = 1.0f,
            });



            g.DrawString("地図データ: 気象庁", new Font("MS UI Gothic", 20), Brushes.White, 0, 0);
            return bitmap;
        }


        internal static void DrawMap(Graphics g, Config_Draw_Internal config)
        {
            var mapJson = mapJsons[config.MapType] ?? GetMapData(config.MapType);

            ExeLog("[DrawMap] マップデータ描画中...", ConsoleColor.Green);
            foreach (var feature in mapJson.Features)
            {
                if (feature.Geometry == null) continue;
                if (feature.Properties == null) continue;
                var code = feature.Properties.GetCode();
                if (code == null) continue;

                var containFill = config.DrawCodeColor_Fill.TryGetValue(code, out var color_fill);
                if(!containFill)
                    color_fill = config.DefaultColor_Fill;
                var containLine= config.DrawCodeColor_Line.TryGetValue(code, out var color_line);
                if (!containLine)
                    color_line = config.DefaultColor_Line;
                if (config.DefaultColor_Fill.A == 0 && !containFill &&
                    config.DefaultColor_Line.A == 0 && !containLine)
                    continue;



                switch (feature.Geometry.Type)
                {
                    case "Polygon":
                        var points = feature.Geometry.Coordinates.Objects[0].MainPoints.Select(coordinate => new PointF((coordinate.Lon - config.LonSta) * config.Zoom, (config.LatEnd - coordinate.Lat) * config.Zoom));
                        if (points.Count() > 2)
                        {
                            if (color_fill.A != 0)
                                g.FillPolygon(new SolidBrush(color_fill), points.ToArray());
                            if (color_line.A != 0)
                                g.DrawPolygon(new Pen(color_line, config.LineWidth), points.ToArray());
                        }
                        break;
                    case "MultiPolygon":
                        foreach (var singleObject in feature.Geometry.Coordinates.Objects)
                        {
                            var singlePoints = singleObject.MainPoints.Select(coordinate => new PointF((coordinate.Lon - config.LonSta) * config.Zoom, (config.LatEnd - coordinate.Lat) * config.Zoom));
                            if (singlePoints.Count() > 2)
                            {
                                if (color_fill.A != 0)
                                    g.FillPolygon(new SolidBrush(color_fill), singlePoints.ToArray());
                                if (color_line.A != 0)
                                    g.DrawPolygon(new Pen(color_line, config.LineWidth), singlePoints.ToArray());
                            }
                        }
                        break;
                    case "LineString":
                        var linePoints = feature.Geometry.Coordinates.Objects[0].MainPoints.Select(coordinate => new PointF((coordinate.Lon - config.LonSta) * config.Zoom, (config.LatEnd - coordinate.Lat) * config.Zoom));
                        if (linePoints.Count() > 1)
                        {
                            if (color_line.A != 0)
                                g.DrawLines(new Pen(color_line, config.LineWidth), linePoints.ToArray());
                        }
                        break;
                    case "MultiLineString":
                        foreach (var singleObject in feature.Geometry.Coordinates.Objects)
                        {
                            var singleLinePoints = singleObject.MainPoints.Select(coordinate => new PointF((coordinate.Lon - config.LonSta) * config.Zoom, (config.LatEnd - coordinate.Lat) * config.Zoom));
                            if (singleLinePoints.Count() > 1)
                            {
                                if (color_line.A != 0)
                                    g.DrawLines(new Pen(color_line, config.LineWidth), singleLinePoints.ToArray());
                            }
                        }
                        break;
                    default:
                        throw new Exception("未対応のGeometry.Typeです。");
                }

            }





            if (ControlForm.config.MapUnloadEachTime)
                mapJsons[config.MapType] = null;
            GC.Collect();
        }
    }
}
