using System.Xml.Serialization;
using static JmaXmlViewer.Utilities.XmlClass;

namespace JmaXmlViewer.DataProcess.Extra
{
    internal partial class Processes_Extra
    {
        public static void VPTI52(string xmlString)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(C_Report_Common));
                using var reader = new StringReader(xmlString);
                var test = (C_Report_Common?)serializer.Deserialize(reader);
                Console.WriteLine("[VPTI52] " + test?.Head.Headline.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[VPTI52] ERROR: " + ex.Message);
            }

        }


    }
}
