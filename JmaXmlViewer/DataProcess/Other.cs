using System.Xml.Linq;
using static JmaXmlViewer.Utilities.ExternalConnects;
using static JmaXmlViewer.Utilities.Functions;
using static JmaXmlViewer.Utilities.XmlClass_XSD;

namespace JmaXmlViewer.DataProcess
{
    internal partial class Processes
    {
        public static void Process_VGSK50VGSK60_VGSK55(C_Report xml)
        {
            var title = xml.Control?.Title ?? ExeLog_ReturnObjNull("[Process_VGSK50VGSK60_VGSK55] title is null", ConsoleColor.Yellow);
            var updated = xml.Control?.DateTime;
            var updatedSt = updated?.ToString("HH:mm:ss");
            var status = xml.Control?.Status;
            var editor = xml.Control?.EditorialOffice;
            var publisher = xml.Control?.PublishingOffice;
            var title2 = xml.Head?.Title ?? ExeLog_ReturnObjNull("[Process_VGSK50VGSK60_VGSK55] title2 is null", ConsoleColor.Yellow);
            var reportDt = xml.Head?.ReportDateTime;
            var targetDt = xml.Head?.TargetDateTime;
            var eventId = xml.Head?.EventID;
            var infoType = xml.Head?.InfoType;

            var kindName = xml.Body_meteorology1.MeteorologicalInfos[0].MeteorologicalInfo[0].Item[0].Kind[0].Name;
            var stationName = xml.Body_meteorology1.MeteorologicalInfos[0].MeteorologicalInfo[0].Item[0].Station.Name;
            var stationLocation = xml.Body_meteorology1.MeteorologicalInfos[0].MeteorologicalInfo[0].Item[0].Station.Location;
            var stationStatus = xml.Body_meteorology1.MeteorologicalInfos[0].MeteorologicalInfo[0].Item[0].Station.Status.ToString();
            var addName = xml.Body_meteorology1.AdditionalInfo.ObservationAddition.Text ?? "";

            var devNormal = xml.Body_meteorology1.AdditionalInfo.ObservationAddition.DeviationFromNormal;
            var devLastYear = xml.Body_meteorology1.AdditionalInfo.ObservationAddition.DeviationFromLastYear;

            var dN = int.TryParse(devNormal, out var dnn) ? dnn > 0 ? "平年から" + dnn + "日遅い" : dnn == 0 ? "平年と同日" : dnn < 0 ? "平年から" + (-dnn) + "日遅い" : "" : "";
            var dL = int.TryParse(devLastYear, out var dln) ? dln > 0 ? "昨年から" + dln + "日遅い" : dln == 0 ? "昨年と同日" : dln < 0 ? "昨年から" + (-dln) + "日遅い" : "" : "";

            var text = title2 + " " + stationName + "発表 " + stationLocation + stationStatus + (addName == "" ? "" : ("（" + addName.Split('（')[0] + "）")) + "で" + kindName + "を観測。" + (dN == "" ? "" : dN + "。") + (dL == "" ? "" : dL + "。");
            ConWrite("[Process_VGSK50VGSK60_VGSK55] " + text);
            BouyomiChan(text);
            Telop("1," + title + "," + updatedSt + "!SPACE" + text.Replace(" ", "!SPACE"));


            if (stationName == "金沢地方気象台")//自分用//todo:editer/publisher/stationは違うことあるか確認
            {
                XPost(title2 + " " + reportDt?.ToString("yyyy/MM/dd HH:mm") + " " + stationName + "\n" + stationLocation + stationStatus + (addName == "" ? "" : ("（" + addName.Split('（')[0] + "）")) + "で" + kindName + "を観測。\n" + (dN == "" ? "" : dN + "。") + (dL == "" ? "" : dL + "。"));
            }


        }
    }
}