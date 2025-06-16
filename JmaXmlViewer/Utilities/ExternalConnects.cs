using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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
                return;
                ExeLog("[BouyomiChan] 棒読みちゃん処理開始");
                byte[] message = Encoding.UTF8.GetBytes(text);
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
                ExeLog(ex.ToString());
            }
        }
    }
}
