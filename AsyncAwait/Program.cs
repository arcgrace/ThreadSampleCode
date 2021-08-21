using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipAddress = Dns.GetHostEntry("webcode.me").AddressList[0];

            ConnectAndSend10K(ipAddress, 80);
        }
        private static async Task ConnectAndSend(IPAddress address, int port, int x)
        {
            var tcpClinet = new TcpClient();
            try
            {
                //異步發起連接,不佔用當前線程
                await tcpClinet.ConnectAsync(address, port);
                //連接成功後會從這裡繼續開始執行
                //失敗時會拋出異常並在以下的catch塊中捕捉

                //異步發送數據,不佔用當前線程
                var bytes = BitConverter.GetBytes(x);
                var stream = tcpClinet.GetStream();
                await stream.WriteAsync(bytes, 0, bytes.Length);
                //發送數據成功後會從這裡繼續開始執行
                //失敗時會拋出異常並在以下的catch塊中捕捉
                Console.WriteLine("connect and send {0} success", x);
            }
            catch(SocketException)
            {
                Console.WriteLine("Connect and send {0} failed ", x);
            }
            catch(OperationCanceledException)
            {
                //支持中斷異步操作需要傳遞CancellationToken
                //這個例子為了簡單沒有支持中斷,所以這裡的處理不會執行
                Console.WriteLine("connect and send {0} canceled", x);
            }
            finally
            {
                tcpClinet.Close();
            }
        }

        private static void ConnectAndSend10K(IPAddress address, int port)
        {
            var tasks = new Task[10];
            for (var x = 0; x < tasks.Length; x++)
            {
                //ConnectAndSend 自身也是一個異步操作
                tasks[x] = ConnectAndSend(address, port, x);
            }
            //同步等待數組中的所有異步操作完畢
            //當前線程會進入等待狀態
            Task.WaitAll(tasks);
        }
    }
}
