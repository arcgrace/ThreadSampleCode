using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace APM
{
    class Program
    {
        static void Main(string[] args)
        {

            IPAddress ipAddress = Dns.GetHostEntry("webcode.me").AddressList[0];
            ConnectAndSend10K(ipAddress, 80);
        }
        private static void ConnectAndSend(IPAddress address, int port, int x , CountdownEvent count)
        {
            var tcpClient = new TcpClient();

            //異步發起連接
            tcpClient.BeginConnect(address, port, ar =>
              {
                //連接成功或失敗時調用此callback
                try
                  {
                      tcpClient.EndConnect(ar);
                      Console.WriteLine("connect {0} success", x);
                  }
                  catch (SocketException)
                  {
                    //連接失敗時關閉連結
                    Console.WriteLine("connect and send {0} failed", x);
                      tcpClient.Close();

                    //通知事件對象
                    count.Signal();
                      return;
                  }

                //異步發送數據
                var bytes = BitConverter.GetBytes(x);
                  var stream = tcpClient.GetStream();
                  stream.BeginWrite(bytes, 0, bytes.Length, ar1 =>
                     {
                       //發送成功或失敗時調用此callback
                       try
                         {
                             stream.EndWrite(ar1);
                             Console.WriteLine("connect and send {0} success", x);
                         }
                         catch (SocketException)
                         {
                             Console.WriteLine("connect and send {0} failed", x);
                         }
                         finally
                         {
                           //關閉連接
                           tcpClient.Close();

                           //通知事件對象
                           count.Signal();
                         }
                     }, null);
              }, null);
        }

        private static void ConnectAndSend10K(IPAddress address,int port)
        {
            //創建一個等通知10000次的事件對象
            var n = 100;
            var count = new CountdownEvent(n);
            //創建10000個連接與發送數據
            for(var x= 0; x< n; x++)
            {
                ConnectAndSend(address, port, x, count);
            }
            //等待所有連接成功結束或出錯返回
            count.Wait();
        }
    }
}
