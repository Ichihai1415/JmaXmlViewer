using System;
using System.Xml.Serialization;
using static JmaXmlViewer.Utilities.XmlClass;

namespace JmaXmlViewer.DataProcess.Other
{
    internal partial class Processes_Other
    {
        public static void VGSK50(string xmlString)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Utilities.XmlClass_XSD.typereport));
                using var reader = new StringReader(xmlString);
                var test = (Utilities.XmlClass_XSD.typereport?)serializer.Deserialize(reader);
                Console.WriteLine("[VGSK50] " + test?.Body.MeteorologicalInfos[0].MeteorologicalInfo[0].Item[0].Kind[0].Name);


                /*
                var serializer = new XmlSerializer(typeof(C_Report_Meteorological));
                using var reader = new StringReader(xmlString);
                var test = (C_Report_Meteorological?)serializer.Deserialize(reader);*/
                //Console.WriteLine("[VGSK50] " + test?.Head.Headline.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[VGSK50] ERROR: " + ex.Message);
            }

        }


    }
}
