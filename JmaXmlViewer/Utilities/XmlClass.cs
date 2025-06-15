using System.Xml.Serialization;

namespace JmaXmlViewer.Utilities
{
    public class XmlClass
    {
        [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
        public class C_Feed
        {
            [XmlElement(ElementName = "title", Namespace = "http://www.w3.org/2005/Atom")]
            public string Title { get; set; } = "";

            [XmlElement(ElementName = "subtitle", Namespace = "http://www.w3.org/2005/Atom")]
            public string Subtitle { get; set; } = "";

            [XmlElement(ElementName = "updated", Namespace = "http://www.w3.org/2005/Atom")]
            public DateTime Updated { get; set; }

            [XmlElement(ElementName = "id", Namespace = "http://www.w3.org/2005/Atom")]
            public string Id { get; set; } = "";

            [XmlElement(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
            public C_Link_Feed[] Link { get; set; } = [];

            [XmlElement(ElementName = "rights", Namespace = "http://www.w3.org/2005/Atom")]
            public C_Rights Rights { get; set; } = new();

            [XmlElement(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
            public C_Entry[] Entry { get; set; } = [];

            [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
            public string Xmlns { get; set; } = "";

            [XmlAttribute(AttributeName = "lang", Namespace = "")]
            public string Lang { get; set; } = "";

            [XmlText]
            public string Text { get; set; } = "";

            [XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
            public class C_Link_Feed
            {
                [XmlAttribute(AttributeName = "rel", Namespace = "")]
                public string Rel { get; set; } = "";

                [XmlAttribute(AttributeName = "href", Namespace = "")]
                public string Href { get; set; } = "";
            }

            [XmlRoot(ElementName = "rights", Namespace = "http://www.w3.org/2005/Atom")]
            public class C_Rights
            {

                [XmlAttribute(AttributeName = "type", Namespace = "")]
                public string Type { get; set; } = "";

                [XmlText]
                public string Text { get; set; } = "";
            }


            [XmlRoot(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
            public class C_Entry
            {

                [XmlElement(ElementName = "title", Namespace = "http://www.w3.org/2005/Atom")]
                public string Title { get; set; } = "";

                [XmlElement(ElementName = "id", Namespace = "http://www.w3.org/2005/Atom")]
                public string Id { get; set; } = "";

                [XmlElement(ElementName = "updated", Namespace = "http://www.w3.org/2005/Atom")]
                public DateTime Updated { get; set; }

                [XmlElement(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
                public C_Author Author { get; set; } = new();

                [XmlElement(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
                public C_Link_Entry Link { get; set; } = new();

                [XmlElement(ElementName = "content", Namespace = "http://www.w3.org/2005/Atom")]
                public C_Content Content { get; set; } = new();


                [XmlRoot(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
                public class C_Author
                {

                    [XmlElement(ElementName = "name", Namespace = "http://www.w3.org/2005/Atom")]
                    public string Name { get; set; } = "";
                }



                [XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
                public class C_Link_Entry
                {
                    [XmlAttribute(AttributeName = "type", Namespace = "")]
                    public string Type { get; set; } = "";

                    [XmlAttribute(AttributeName = "href", Namespace = "")]
                    public string Href { get; set; } = "";
                }

                [XmlRoot(ElementName = "content", Namespace = "http://www.w3.org/2005/Atom")]
                public class C_Content
                {

                    [XmlAttribute(AttributeName = "type", Namespace = "")]
                    public string Type { get; set; } = "";

                    [XmlText]
                    public string Text { get; set; } = "";
                }
            }
        }


        [XmlRoot(ElementName = "Report", Namespace = "http://xml.kishou.go.jp/jmaxml1/")]
        public class C_Report_Common
        {

            [XmlElement(ElementName = "Control", Namespace = "http://xml.kishou.go.jp/jmaxml1/")]
            public C_Control Control { get; set; } = new();

            [XmlElement(ElementName = "Head", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
            public C_Head Head { get; set; } = new();

            [XmlElement(ElementName = "Body", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
            public C_Body Body { get; set; } = new();

            [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
            public string Xmlns { get; set; } = "";

            [XmlAttribute(AttributeName = "jmx", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Jmx { get; set; } = "";

            [XmlAttribute(AttributeName = "jmx_add", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string JmxAdd { get; set; } = "";

            //[XmlText]
            //public string Text { get; set; }

            [XmlRoot(ElementName = "Control", Namespace = "http://xml.kishou.go.jp/jmaxml1/")]
            public class C_Control
            {

                [XmlElement(ElementName = "Title", Namespace = "http://xml.kishou.go.jp/jmaxml1/")]
                public string Title { get; set; } = "";

                [XmlElement(ElementName = "DateTime", Namespace = "http://xml.kishou.go.jp/jmaxml1/")]
                public DateTime DateTime { get; set; }

                [XmlElement(ElementName = "Status", Namespace = "http://xml.kishou.go.jp/jmaxml1/")]
                public string Status { get; set; } = "";

                [XmlElement(ElementName = "EditorialOffice", Namespace = "http://xml.kishou.go.jp/jmaxml1/")]
                public string EditorialOffice { get; set; } = "";

                [XmlElement(ElementName = "PublishingOffice", Namespace = "http://xml.kishou.go.jp/jmaxml1/")]
                public string PublishingOffice { get; set; } = "";
            }

            [XmlRoot(ElementName = "Head", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
            public class C_Head
            {

                [XmlElement(ElementName = "Title", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public string Title { get; set; } = "";

                [XmlElement(ElementName = "ReportDateTime", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public DateTime ReportDateTime { get; set; }

                [XmlElement(ElementName = "TargetDateTime", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public DateTime TargetDateTime { get; set; }

                [XmlElement(ElementName = "EventID", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public string EventID { get; set; } = "";

                [XmlElement(ElementName = "InfoType", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public string InfoType { get; set; } = "";

                [XmlElement(ElementName = "Serial", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public string Serial { get; set; } = "";

                [XmlElement(ElementName = "InfoKind", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public string InfoKind { get; set; } = "";

                [XmlElement(ElementName = "InfoKindVersion", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public string InfoKindVersion { get; set; } = "";

                [XmlElement(ElementName = "Headline", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public C_Headline Headline { get; set; } = new();

                [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
                public string Xmlns { get; set; } = "";

                //[XmlText]
                //public string Text { get; set; }


                [XmlRoot(ElementName = "Headline", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                public class C_Headline
                {

                    [XmlElement(ElementName = "Text", Namespace = "http://xml.kishou.go.jp/jmaxml1/informationBasis1/")]
                    public string Text { get; set; } = "";
                }
            }

            [XmlRoot(ElementName = "Body", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
            [XmlType(TypeName = "CommonBody", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
            public　 class C_Body
            {

                [XmlElement(ElementName = "Notice", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                public object Notice { get; set; } = "";

                [XmlElement(ElementName = "Comment", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                public C_Comment Comment { get; set; } = new();

                [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
                public string Xmlns { get; set; } = "";

                //[XmlText]
                //public string Text { get; set; }

                [XmlRoot(ElementName = "Comment", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                public class C_Comment
                {

                    [XmlElement(ElementName = "Text", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                    public C_Text Text { get; set; } = new();

                    [XmlRoot(ElementName = "Text", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                    public class C_Text
                    {

                        [XmlAttribute(AttributeName = "type", Namespace = "")]
                        public string Type { get; set; } = "";

                        [XmlText]
                        public string Text { get; set; } = "";
                    }
                }
            }
        }


        [XmlRoot(ElementName = "Report", Namespace = "http://xml.kishou.go.jp/jmaxml1/")]
        public class C_Report_Meteorological 
        {

            [XmlElement(ElementName = "Body", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
            public C_Body Body { get; set; } = new();

            [XmlRoot(ElementName = "Body", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
            [XmlType(TypeName = "MeteorologicalBody", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
            public new class C_Body
            {
                [XmlElement(ElementName = "MeteorologicalInfos", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                public C_MeteorologicalInfos MeteorologicalInfos { get; set; } = new();

                [XmlElement(ElementName = "AdditionalInfo", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                public C_AdditionalInfo AdditionalInfo { get; set; } = new();

                [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
                public string Xmlns { get; set; } = "";


                [XmlRoot(ElementName = "MeteorologicalInfos", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                public class C_MeteorologicalInfos
                {
                    [XmlElement(ElementName = "MeteorologicalInfo", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                    public C_MeteorologicalInfo[] MeteorologicalInfo { get; set; } = [];

                    [XmlAttribute(AttributeName = "type", Namespace = "")]
                    public string Type { get; set; } = "";


                    [XmlRoot(ElementName = "MeteorologicalInfo", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                    public class C_MeteorologicalInfo
                    {
                        [XmlElement(ElementName = "DateTime", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                        public C_DateTime DateTime { get; set; } = new();

                        [XmlElement(ElementName = "Item", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                        public C_Item Item { get; set; } = new();

                        [XmlRoot(ElementName = "DateTime", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                        public class C_DateTime
                        {

                            [XmlAttribute(AttributeName = "significant", Namespace = "")]
                            public string Significant { get; set; } = "";

                            [XmlText]
                            public DateTime Value { get; set; }
                        }


                        [XmlRoot(ElementName = "Item", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                        public class C_Item
                        {
                            [XmlElement(ElementName = "Kind", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                            public C_Kind Kind { get; set; } = new();

                            [XmlElement(ElementName = "Station", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                            public C_Station Station { get; set; } = new();

                            [XmlRoot(ElementName = "Kind", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                            public class C_Kind
                            {
                                [XmlElement(ElementName = "Name", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                                public string Name { get; set; } = "";
                            }

                            [XmlRoot(ElementName = "Station", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                            public class C_Station
                            {
                                [XmlElement(ElementName = "Name", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                                public string Name { get; set; } = "";

                                [XmlElement(ElementName = "Code", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                                public C_Code Code { get; set; } = new();

                                [XmlElement(ElementName = "Location", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                                public string Location { get; set; } = "";

                                [XmlRoot(ElementName = "Code", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                                public class C_Code
                                {
                                    [XmlAttribute(AttributeName = "type", Namespace = "")]
                                    public string Type { get; set; } = "";

                                    [XmlText]
                                    public int Value { get; set; }
                                }
                            }
                        }



                    }
                }



                [XmlRoot(ElementName = "AdditionalInfo", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                public class C_AdditionalInfo
                {
                    [XmlElement(ElementName = "ObservationAddition", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                    public C_ObservationAddition ObservationAddition { get; set; } = new();

                    [XmlRoot(ElementName = "ObservationAddition", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                    public class C_ObservationAddition
                    {
                        [XmlElement(ElementName = "DeviationFromNormal", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                        public int DeviationFromNormal { get; set; }

                        [XmlElement(ElementName = "DeviationFromLastYear", Namespace = "http://xml.kishou.go.jp/jmaxml1/body/meteorology1/")]
                        public int DeviationFromLastYear { get; set; }
                    }
                }
            }

        }










    }
}
