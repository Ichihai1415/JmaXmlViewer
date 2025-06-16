using System.Media;

namespace JmaXmlViewer.Utilities
{
    internal class Functions
    {
        /// <summary>
        /// コンソールのデフォルトの色
        /// </summary>
        public static readonly ConsoleColor defaultColor = Console.ForegroundColor;

        /// <summary>
        /// コンソールにデフォルトの色で出力します。
        /// </summary>
        /// <param name="text">出力するテキスト</param>
        /// <param name="withLine">改行するか</param>
        public static void ConWrite(string text, bool withLine = true)
        {
            ConWrite(text, defaultColor, withLine);
        }

        /// <summary>
        /// 例外のテキストを赤色で出力します。
        /// </summary>
        /// <param name="loc">場所([ConWrite]など)</param>
        /// <param name="ex">出力する例外</param>
        public static void ConWrite(string loc, Exception ex)
        {
            ConWrite(loc + " " + ex.ToString(), ConsoleColor.Red);
        }

        /// <summary>
        /// コンソールに色付きで出力します。色は変わったままとなります。
        /// </summary>
        /// <param name="text">出力するテキスト</param>
        /// <param name="color">表示する色</param>
        /// <param name="withLine">改行するか</param>
        public static void ConWrite(string text, ConsoleColor color, bool withLine = true)
        {
            Console.ForegroundColor = color;
            //Console.Write(DateTime.Now.ToString("HH:mm:ss.ffff "));
            if (withLine)
                Console.WriteLine(text);
            else
                Console.Write(text);
        }

        public static void ExeLog(string text, bool conWrite = true)
        {
            ExeLog(text, defaultColor, conWrite);
        }

        public static void ExeLog(string text, ConsoleColor color, bool conWrite = true)
        {
            //...
            if (conWrite)
                ConWrite(DateTime.Now.ToString("HH:mm:ss.ffff ") + text, color);
        }

        public static void ErrorLog(string loc, Exception ex, bool conWrite = true)
        {
            if (conWrite)
                ConWrite(loc, ex);
            Directory.CreateDirectory("Log\\Error\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.Day);
            File.WriteAllText("Log\\Error\\" + DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.Day + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", ex.ToString());
        }

        public static object? ConWrite_ReturnObjNull(string text, bool withLine = true)
        {
            ConWrite(text, withLine);
            return null;
        }
        public static object? ConWrite_ReturnObjNull(string text, ConsoleColor color, bool withLine = true)
        {
            ConWrite(text, color, withLine);
            return null;
        }
        public static object? ExeLog_ReturnObjNull(string text, bool withLine = true)
        {
            ExeLog(text, withLine);
            return null;
        }
        public static object? ExeLog_ReturnObjNull(string text, ConsoleColor color, bool withLine = true)
        {
            ExeLog(text, color, withLine);
            return null;
        }

        /// <summary>
        /// 共通プレイヤー
        /// </summary>
        internal static SoundPlayer? player = null;

        /// <summary>
        /// 音声を再生します。
        /// </summary>
        /// <remarks>音声ファイルがなければ無効です。</remarks>
        /// <param name="fileName">再生するファイル名(sound\\)</param>
        internal static void PlaySound(string fileName)
        {
            if (!fileName.StartsWith("Sound\\"))
                fileName = "Sound\\" + fileName;
            if (!File.Exists(fileName))
            {
                ConWrite("[PlaySound]音声ファイルがないため再生しません。");
                return;
            }
            ConWrite($"[PlaySound]音声再生開始(\"{fileName}\")");
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
            player = new SoundPlayer(fileName);
            player.Play();
        }

    }
}
