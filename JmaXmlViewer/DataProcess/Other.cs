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


            if (stationName == "金沢地方気象台")//自分用//toido:editer/publisher/stationは違うことあるか確認
            {
                XPost("【" + title2 + "】" + reportDt?.ToString("yyyy/MM/dd HH:mm:ss") + "\n" + stationLocation + stationStatus + (addName == "" ? "" : ("（" + addName.Split('（')[0] + "）")) + "で" + kindName + "を観測。\n" + (dN == "" ? "" : dN + "。") + (dL == "" ? "" : dL + "。"));
            }


        }
    }
}
/*
<Report xmlns="http://xml.kishou.go.jp/jmaxml1/" xmlns:jmx="http://xml.kishou.go.jp/jmaxml1/">
<Control>
<Title>季節観測</Title>
<DateTime>2025-11-18T04:23:01Z</DateTime>
<Status>通常</Status>
<EditorialOffice>山形地方気象台</EditorialOffice>
<PublishingOffice>山形地方気象台</PublishingOffice>
</Control>
<Head xmlns="http://xml.kishou.go.jp/jmaxml1/informationBasis1/">
<Title>季節観測</Title>
<ReportDateTime>2025-11-18T13:23:00+09:00</ReportDateTime>
<TargetDateTime>2025-11-18T00:00:00+09:00</TargetDateTime>
<EventID>20251118132000_初雪</EventID>
<InfoType>発表</InfoType>
<Serial/>
<InfoKind>特殊気象報</InfoKind>
<InfoKindVersion>1.0_0</InfoKindVersion>
<Headline>
<Text/>
</Headline>
</Head>
<Body xmlns="http://xml.kishou.go.jp/jmaxml1/body/meteorology1/">
<MeteorologicalInfos type="季節観測">
<MeteorologicalInfo>
<DateTime significant="yyyy-mm-dd">2025-11-18T00:00:00+09:00</DateTime>
<Item>
<Kind>
<Name>初雪</Name>
</Kind>
<Station>
<Name>山形地方気象台</Name>
<Code type="国際地点番号">47588</Code>
<Location>山形市緑町</Location>
</Station>
</Item>
</MeteorologicalInfo>
</MeteorologicalInfos>
<AdditionalInfo>
<ObservationAddition>
<DeviationFromNormal>2</DeviationFromNormal>
<DeviationFromLastYear>0</DeviationFromLastYear>
</ObservationAddition>
</AdditionalInfo>
</Body>
</Report>


<Report xmlns="http://xml.kishou.go.jp/jmaxml1/" xmlns:jmx="http://xml.kishou.go.jp/jmaxml1/">
<Control>
<Title>生物季節観測</Title>
<DateTime>2025-11-18T06:44:46Z</DateTime>
<Status>通常</Status>
<EditorialOffice>奈良地方気象台</EditorialOffice>
<PublishingOffice>奈良地方気象台</PublishingOffice>
</Control>
<Head xmlns="http://xml.kishou.go.jp/jmaxml1/informationBasis1/">
<Title>生物季節観測</Title>
<ReportDateTime>2025-11-18T15:42:00+09:00</ReportDateTime>
<TargetDateTime>2025-11-18T00:00:00+09:00</TargetDateTime>
<EventID>20251118154200_13</EventID>
<InfoType>発表</InfoType>
<Serial/>
<InfoKind>生物季節観測報告気象報</InfoKind>
<InfoKindVersion>1.0_0</InfoKindVersion>
<Headline>
<Text/>
</Headline>
</Head>
<Body xmlns="http://xml.kishou.go.jp/jmaxml1/body/meteorology1/">
<MeteorologicalInfos type="生物季節観測">
<MeteorologicalInfo>
<DateTime significant="yyyy-mm-dd">2025-11-18T00:00:00+09:00</DateTime>
<Item>
<Kind>
<Name>いちょうの黄葉日</Name>
<Code>13</Code>
<ClassName>イチョウ</ClassName>
<Condition>通常</Condition>
</Kind>
<Station>
<Name>奈良地方気象台</Name>
<Code type="国際地点番号">47780</Code>
<Location>奈良市東紀寺町</Location>
<Status>付近</Status>
</Station>
</Item>
</MeteorologicalInfo>
</MeteorologicalInfos>
<AdditionalInfo>
<ObservationAddition>
<DeviationFromNormal>0</DeviationFromNormal>
<DeviationFromLastYear>10</DeviationFromLastYear>
<Text>奈良女子大学附属中等教育学校（ナラジョシダイガクフゾクチュウトウキョウイクガッコウ）</Text>
</ObservationAddition>
</AdditionalInfo>
</Body>
</Report> 
 */
