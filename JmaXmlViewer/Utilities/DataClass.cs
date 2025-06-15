namespace JmaXmlViewer.Utilities
{
    internal class DataClass
    {
        /// <summary>
        /// Feed更新確認用
        /// </summary>
        public class FeedIndex
        {
            /// <summary>
            /// コードごとのエントリ(コード, ファイル名)（定時）
            /// </summary>
            public Dictionary<string, List<string>> CodeEntries_Regular { get; set; } = [];

            /// <summary>
            /// コードごとのエントリ(コード, ファイル名)（随時）
            /// </summary>
            public Dictionary<string, List<string>> CodeEntries_Extra { get; set; } = [];

            /// <summary>
            /// コードごとのエントリ(コード, ファイル名)（地震火山）
            /// </summary>
            public Dictionary<string, List<string>> CodeEntries_Eqvol { get; set; } = [];

            /// <summary>
            /// コードごとのエントリ(コード, ファイル名)（その他）
            /// </summary>
            public Dictionary<string, List<string>> CodeEntries_Other { get; set; } = [];

        }
    }
}
