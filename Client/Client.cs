using SocketDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace ConsoleClient
{
    /// <summary>
    /// Client class
    /// </summary>
    public class Client
    {
        /// <summary>
        /// 連線至主機
        /// </summary>
        public void ConnetToServer()
        {
            ////預設主機IP
            string hostIP = "58.115.16.31";

            ////先建立IPAddress物件,ip為欲連線主機之IP
            IPAddress ipa = IPAddress.Parse(hostIP);

            //IPAddress ipa = Dns.GetHostEntry("www.microsoft.com").AddressList[0];

            //建立IPEndPoint
            IPEndPoint ipe = new IPEndPoint(ipa, 8080);

            //先建立一個TcpClient;
            TcpClient tcpClient = new TcpClient();

            //開始連線
            try
            {
                Console.WriteLine("主機IP=" + ipa.ToString());
                Console.WriteLine("連線至主機中...\n");
                tcpClient.Connect(ipe);
                if (tcpClient.Connected)
                {
                    Console.WriteLine("連線成功!");
                    CommunicationBase cb = new CommunicationBase();
                    cb.SendMsg("這是客戶端傳給主機的訊息", tcpClient);
                    Console.WriteLine(cb.ReceiveMsg(tcpClient));
                }
                else
                {
                    Console.WriteLine("連線失敗!");
                }
                Console.Read();
            }
            catch (Exception ex)
            {
                tcpClient.Close();
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

    }
}
