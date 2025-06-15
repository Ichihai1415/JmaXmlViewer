namespace JmaXmlViewer.Utilities
{
    internal class Converters
    {

        public static string GetCode(string url)
        {
            //例: https://www.data.jma.go.jp/developer/xml/data/20250614195027_0_VPFG50_430000.xml
            var dirs = url.Split('/');
            if (dirs.Length == 7)
            {
                var fileParams = dirs[6].Split('_');
                if (fileParams.Length == 4)
                    return fileParams[2];
            }
            throw new Exception("コードの抽出に失敗しました。", new ArgumentException("URLの形式が正しくない可能性があります。", nameof(url)));
        }
    }
}
