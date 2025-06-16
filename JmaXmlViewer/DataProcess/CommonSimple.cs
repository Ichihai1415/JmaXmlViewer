using static JmaXmlViewer.Utilities.ExternalConnects;
using static JmaXmlViewer.Utilities.XmlClass_XSD;

namespace JmaXmlViewer.DataProcess
{
    internal partial class Processes
    {
        /// <summary>
        /// HeadLine、CommentのみのシンプルなXMLを処理します。すべてのものが扱えます。
        /// </summary>
        /// <param name="xml"></param>
        public static void CommonSimple(C_Report xml)
        {
            var title = xml.Control?.Title;
            var updated = xml.Control?.DateTime;
            var status = xml.Control?.Status;
            var title2 = xml.Head?.Title;
            var reportDt = xml.Head?.ReportDateTime;
            var targetDt = xml.Head?.TargetDateTime;
            var eventId = xml.Head?.EventID;
            var infoType = xml.Head?.InfoType;
            var serial = xml.Head?.Serial;
            var headLine = xml.Head?.Headline?.Text;
            var comment = "";
            foreach (var item in xml.Body?.Comment?.Text ?? [])
                comment += item.Value;

            //Console.WriteLine(title + " " + title2);
            Console.WriteLine(title + "、" + title2 + "。" + headLine + comment);
            BouyomiChan(title + "、" + title2 + "。" + headLine + comment);

        }
    }
}
