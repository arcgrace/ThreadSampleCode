using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
namespace SocketDemo
{
    /// <summary>
    /// CommunicationBase給客戶端和主機端共用，可傳送接收訊息
    /// </summary>
    public class CommunicationBase
    {
        /// <summary>
        /// 傳送訊息
        /// </summary>
        /// <param name="msg">要傳送的訊息</param>
        /// <param name="tmpTcpClient">TcpClient</param>
        public void SendMsg(string msg,TcpClient tmpTcpClient)
        {
            NetworkStream ns = tmpTcpClient.GetStream();
            if (ns.CanWrite)
            {
                byte[] msgByte = Encoding.Default.GetBytes(msg);
                ns.Write(msgByte, 0, msgByte.Length);
            }
        }
        /// <summary>
        /// 接收訊息
        /// </summary>
        /// <param name="tmpTcpClient">TcpClient</param>
        /// <returns>接收到的訊息</returns>
        public string ReceiveMsg(TcpClient tmpTcpClient)
        {
            string receiveMsg = string.Empty;
            byte[] receiveBytes = new byte[tmpTcpClient.ReceiveBufferSize];
            int numberOfBytesRead = 0;
            NetworkStream ns = tmpTcpClient.GetStream();

            if (ns.CanRead)
            {
                do
                {
                    numberOfBytesRead = ns.Read(receiveBytes, 0, tmpTcpClient.ReceiveBufferSize);

                    receiveMsg = Encoding.Default.GetString(receiveBytes, 0, numberOfBytesRead);
                }
                while (ns.DataAvailable);
            }

            return receiveMsg;
        }
    }
}

//這邊有幾個要注意的重點：

//不管傳送或接收都需要用 NetworkStream ns = tmpTcpClient.GetStream() 的方法來驅動
//訊息需先轉成byte[]陣列才可傳送 - Encoding.Default.GetBytes()
//傳送 - ns.Write();
//相對地收到訊息時需先從byte[] 陣列轉回一般字串 - Encoding.Default.GetString()
//接收 - ns.Read()
