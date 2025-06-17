using static JmaXmlViewer.Utilities.ExternalConnects;
using static JmaXmlViewer.Utilities.Functions;
using static JmaXmlViewer.Utilities.XmlClass_XSD;

namespace JmaXmlViewer.DataProcess
{
    internal partial class Processes
    {
        /// <summary>
        /// HeadLine、CommentのみのシンプルなXMLを処理します。すべてのものが扱えます。
        /// </summary>
        /// <param name="xml"></param>
        public static void Process_CommonSimple(C_Report xml)
        {
            var title = xml.Control?.Title ?? ExeLog_ReturnObjNull("[Process_CommonSimple] title is null", ConsoleColor.Yellow);
            var updated = xml.Control?.DateTime;
            var updatedSt = updated?.ToString("HH:mm:ss");
            var status = xml.Control?.Status;
            var title2 = xml.Head?.Title ?? ExeLog_ReturnObjNull("[Process_CommonSimple] title2 is null", ConsoleColor.Yellow);
            var reportDt = xml.Head?.ReportDateTime;
            var targetDt = xml.Head?.TargetDateTime;
            var eventId = xml.Head?.EventID;
            var infoType = xml.Head?.InfoType;
            var serial = xml.Head?.Serial;
            var headLine = xml.Head?.Headline?.Text ?? ExeLog_ReturnObjNull("[Process_CommonSimple] headLine is null", ConsoleColor.DarkYellow);
            var comment = "";
            foreach (var item in xml.Body?.Comment?.Text ?? [])
                comment += item.Value;
            if (string.IsNullOrEmpty(comment))
                ExeLog("[Process_CommonSimple] comment is null", ConsoleColor.DarkYellow);

            //Console.WriteLine(title + " " + title2);
            ConWrite("[Process_CommonSimple] " + title + " " + title2 + "  " + headLine + comment);
            BouyomiChan(title + "、" + title2 + "。" + headLine + comment);
            Telop("1," + title + "," + updatedSt + "!SPACE" + title2 + "!SPACE" + headLine + "!SPACE" + comment);
        }
    }
}
