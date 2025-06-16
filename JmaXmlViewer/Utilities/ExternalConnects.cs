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
    }
}
