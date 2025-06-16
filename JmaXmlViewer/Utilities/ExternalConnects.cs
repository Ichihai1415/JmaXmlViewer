using System.Net.Sockets;
using System.Text;
using static JmaXmlViewer.Utilities.Functions;

namespace JmaXmlViewer.Utilities
{
    internal class ExternalConnects
    {

        /// <summary>
        /// 棒読みちゃんに読み上げ指令を送ります。
        /// </summary>
        /// <param name="text">読み上げさせる文</param>
        public static void BouyomiChan(string text)
        {
            try
            {
                if (!File.Exists("bouyomi"))//仮
                    return;
                ExeLog("[BouyomiChan] 棒読みちゃん処理開始", ConsoleColor.Green);
                byte[] message = Encoding.UTF8.GetBytes(text.Replace("\n", ""));
                using TcpClient tcpClient = new("127.0.0.1", 50001);
                using NetworkStream networkStream = tcpClient.GetStream();
                using BinaryWriter binaryWriter = new(networkStream);
                binaryWriter.Write((short)1);
                binaryWriter.Write((short)-1);
                binaryWriter.Write((short)-1);
                binaryWriter.Write((short)-1);
                binaryWriter.Write((short)0);
                binaryWriter.Write((byte)0);
                binaryWriter.Write(message.Length);
                binaryWriter.Write(message);
            }
            catch (Exception ex)
            {
                ExeLog("[BouyomiChan] エラー: " + ex, ConsoleColor.Red);
            }
            finally
            {
                ExeLog("[BouyomiChan] 棒読みちゃん処理終了", ConsoleColor.Green);
            }
        }


        /// <summary>
        /// TelopにSocket送信します
        /// </summary>
        /// <param name="text">Telopに送信するテキスト(Telop方式)</param>
        internal static void Telop(string text)
        {
            if (!File.Exists("telop"))
                return;
            ConWrite("[Telop]テロップ送信開始");
            ConWrite("[Telop]Text:" + text);
            try
            {
                byte[] message = new byte[4096];
                message = Encoding.UTF8.GetBytes(text);
                using TcpClient tcpClient = new("127.0.0.1", 31401);
                using NetworkStream networkStream = tcpClient.GetStream();
                networkStream.Write(message, 0, message.Length);
            }
            catch (Exception ex)
            {
                ConWrite("[Telop]", ex);
            }
            ConWrite("[Telop]テロップ送信終了");
        }
        /*
        /// <summary>
        /// XPosterV2Hostに送信します。
        /// </summary>
        /// <param name="text">ポストするテキスト</param>
        /// <param name="path">ポストする画像</param>
        internal static void XPost(string text, string path)
        {
            if (!CtrlForm.debug && !CtrlForm.readJSON)
                if (File.Exists("XPosterV2Host - Enable"))//念のため
                    try
                    {
                        ConWrite("[XPost]X送信開始");
                        var sendText = $"{{ \"text\" : \"{text.Replace("\n", "\\\\n")}\", \"images\" : \"{Path.GetFullPath(path).Replace("\\", "\\\\")}\" }}";
                        ConWrite("[XPost]Text:" + sendText);
                        var message = new byte[16 * 1024];
                        message = Encoding.UTF8.GetBytes(sendText);
                        using var tcpClient = new TcpClient("127.0.0.1", 31403);
                        using var networkStream = tcpClient.GetStream();
                        networkStream.Write(message, 0, message.Length);
                    }
                    catch (Exception ex)
                    {
                        ConWrite("[XPost]", ex);
                    }
                    finally
                    {
                        ConWrite("[XPost]X送信終了");
                    }
        }*/

    }
}
