using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleServer
{
    /// <summary>
    /// Server class
    /// </summary>
    public class Server
    {
        /// <summary>
        /// 等待客戶端連線
        /// </summary>
        public void ListenToConnection()
        {
            //取得本機名稱
            string hostName = Dns.GetHostName();
            Console.WriteLine("本機名稱= " + hostName);

            //取得本機IP
            IPAddress[] ipa = Dns.GetHostAddresses(hostName);
            Console.WriteLine("本機IP= " + ipa[0].ToString());

            //建立本機端的IPEndPoint物件
            IPEndPoint ipe = new IPEndPoint(ipa[0], 1234);

            //建立TcpListener物件
            TcpListener tcpListener = new TcpListener(ipe);

            //開始監聽port
            tcpListener.Start();
            Console.WriteLine("等待客戶端連線中...\n");

            TcpClient tmpTcpClient;
            int numberOfClients = 0;
            while (true)
            {
                try
                {
                    //建立與客戶端的連線
                    tmpTcpClient = tcpListener.AcceptTcpClient();

                    if (tmpTcpClient.Connected)
                    {
                        Console.WriteLine("連線成功!");
                        HandleClient handleClient = new HandleClient(tmpTcpClient);
                        Thread myThread = new Thread(new ThreadStart(handleClient.Communicate));
                        numberOfClients += 1;
                        myThread.IsBackground = true;
                        myThread.Start();
                        myThread.Name = tmpTcpClient.Client.RemoteEndPoint.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
            }//end while
        }//end ListenToConnect()
    }//end class

}//end namespace

//建立IPEndPoint端點需要IPAddress跟Port
//TcpListener是主機專用 - 專門用來聽port是否有從客戶端來的連線request
//在while裡有使用到thread，因為我們假設主機host起來之後可能會有一個以上的client連線進來, thread的使用方式可以參考msdn