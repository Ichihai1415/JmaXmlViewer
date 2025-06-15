using System.Xml.Serialization;

namespace JmaXmlViewer.Utilities
{
    /// <summary>
    /// XML格納クラス
    /// </summary>
    public class XmlClass
    {
        /// <summary>
        /// 気象庁XML Atomフィードのクラス
        /// </summary>
        /// <remarks>クラスはC_、属性はA_</remarks>
        [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
        public class C_Feed
        {
            /// <summary>
            /// Feedのタイトル
            /// </summary>
            /// <remarks>例: 高頻度（定時）</remarks>
            [XmlElement(ElementName = "title", Namespace = "http://www.w3.org/2005/Atom")]
            public string Title { get; set; } = "";

            /// <summary>
            /// Feedのサブタイトル
            /// </summary>
            /// <remarks>固定: JMAXML publishing feed</remarks>
            [XmlElement(ElementName = "subtitle", Namespace = "http://www.w3.org/2005/Atom")]
            public string Subtitle { get; set; } = "";

            /// <summary>
            /// Feedの更新日時
            /// </summary>
            /// <remarks>例: 2025-06-15T19:08:23+09:00</remarks>
            [XmlElement(ElementName = "updated", Namespace = "http://www.w3.org/2005/Atom")]
            public DateTime Updated { get; set; }

            /// <summary>
            /// FeedのID(URL)
            /// </summary>
            /// <remarks>例: https://www.data.jma.go.jp/developer/xml/feed/regular.xml#short_1749982103</remarks>
            [XmlElement(ElementName = "id", Namespace = "http://www.w3.org/2005/Atom")]
            public string Id { get; set; } = "";

            /// <summary>
            /// Feedのリンクの配列
            /// </summary>
            [XmlElement(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
            public C_Link_Feed[] Link { get; set; } = [];

            /// <summary>
            /// Feedの規約
            /// </summary>
            [XmlElement(ElementName = "rights", Namespace = "http://www.w3.org/2005/Atom")]
            public C_Rights Rights { get; set; } = new();

            /// <summary>
            /// Feedのエントリの配列
            /// </summary>
            [XmlElement(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
            public C_Entry[] Entry { get; set; } = [];

            /// <summary>
            /// Feedの名前空間
            /// </summary>
            /// <remarks>固定: http://www.w3.org/2005/Atom</remarks>
            [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
            public string A_Xmlns { get; set; } = "";

            /// <summary>
            /// Feedの言語
            /// </summary>
            /// <remarks>固定: ja</remarks>
            [XmlAttribute(AttributeName = "lang", Namespace = "")]
            public string A_Lang { get; set; } = "";

            /// <summary>
            /// Feedのリンク
            /// </summary>
            [XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
            public class C_Link_Feed
            {
                /// <summary>
                /// Feedのリンクの関係
                /// </summary>
                /// <remarks>例: related</remarks>
                [XmlAttribute(AttributeName = "rel", Namespace = "")]
                public string A_Rel { get; set; } = "";

                /// <summary>
                /// FeedのURL
                /// </summary>
                /// <remarks>例: https://www.jma.go.jp/</remarks>
                [XmlAttribute(AttributeName = "href", Namespace = "")]
                public string A_Href { get; set; } = "";
            }

            /// <summary>
            /// Feedの規約
            /// </summary>
            [XmlRoot(ElementName = "rights", Namespace = "http://www.w3.org/2005/Atom")]
            public class C_Rights
            {
                /// <summary>
                /// 規約のテキストのタイプ
                /// </summary>
                /// <remarks>固定: html</remarks>
                [XmlAttribute(AttributeName = "type", Namespace = "")]
                public string A_Type { get; set; } = "";

                /// <summary>
                /// Feedの規約のテキスト
                /// </summary>
                /// <remarks>固定: <![CDATA[ <a href="https://www.jma.go.jp/jma/kishou/info/coment.html">利用規約</a>, <a href="https://www.jma.go.jp/jma/en/copyright.html">Terms of Use</a> ]]></remarks>
                [XmlText]
                public string Value { get; set; } = "";
            }

            /// <summary>
            /// エントリ
            /// </summary>
            [XmlRoot(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
            public class C_Entry
            {
                /// <summary>
                /// エントリのタイトル
                /// </summary>
                /// <remarks>例: 地方気象情報</remarks>
                [XmlElement(ElementName = "title", Namespace = "http://www.w3.org/2005/Atom")]
                public string Title { get; set; } = "";

                /// <summary>
                /// エントリのID(URL)
                /// </summary>
                /// <remarks>例: https://www.data.jma.go.jp/developer/xml/data/20250615060053_0_VPCJ50_230000.xml</remarks>
                [XmlElement(ElementName = "id", Namespace = "http://www.w3.org/2005/Atom")]
                public string Id { get; set; } = "";

                /// <summary>
                /// エントリの更新日時
                /// </summary>
                /// <remarks>例: 2025-06-15T06:00:53Z</remarks>
                [XmlElement(ElementName = "updated", Namespace = "http://www.w3.org/2005/Atom")]
                public DateTime Updated { get; set; }

                /// <summary>
                /// エントリの発表機関
                /// </summary>
                [XmlElement(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
                public C_Author Author { get; set; } = new();

                /// <summary>
                /// エントリのリンク
                /// </summary>
                [XmlElement(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
                public C_Link_Entry Link { get; set; } = new();

                /// <summary>
                /// エントリの内容
                /// </summary>
                [XmlElement(ElementName = "content", Namespace = "http://www.w3.org/2005/Atom")]
                public C_Content Content { get; set; } = new();

                /// <summary>
                /// エントリの発表機関
                /// </summary>
                [XmlRoot(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
                public class C_Author
                {
                    /// <summary>
                    /// エントリの発表機関名
                    /// </summary>
                    /// <remarks>例: 名古屋地方気象台</remarks>
                    [XmlElement(ElementName = "name", Namespace = "http://www.w3.org/2005/Atom")]
                    public string Name { get; set; } = "";
                }

                /// <summary>
                /// エントリのリンク
                /// </summary>
                [XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
                public class C_Link_Entry
                {
                    /// <summary>
                    /// エントリのリンクのタイプ
                    /// </summary>
                    /// <remarks>固定: application/xml</remarks>
                    [XmlAttribute(AttributeName = "type", Namespace = "")]
                    public string A_Type { get; set; } = "";

                    /// <summary>
                    /// エントリのURL
                    /// </summary>
                    /// <remarks>例: https://www.data.jma.go.jp/developer/xml/data/20250615060053_0_VPCJ50_230000.xml</remarks>
                    [XmlAttribute(AttributeName = "href", Namespace = "")]
                    public string A_Href { get; set; } = "";
                }

                /// <summary>
                /// エントリの内容
                /// </summary>
                [XmlRoot(ElementName = "content", Namespace = "http://www.w3.org/2005/Atom")]
                public class C_Content
                {
                    /// <summary>
                    /// エントリの内容の形式
                    /// </summary>
                    /// <remarks>固定: text</remarks>
                    [XmlAttribute(AttributeName = "type", Namespace = "")]
                    public string A_Type { get; set; } = "";

                    /// <summary>
                    /// エントリの内容のテキスト
                    /// </summary>
                    /// <remarks>例: 【高温に関する東海地方気象情報】東海地方では、６月１７日から１９日にかけて、最高気温が３５度以上となるところがあるでしょう。</remarks>
                    [XmlText]
                    public string Value { get; set; } = "";
                }
            }
        }

    }
}
