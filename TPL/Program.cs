using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipAddress = Dns.GetHostEntry("webcode.me").AddressList[0];
    
            ConnectAndSend10K(ipAddress, 80);
        }
        private static Task ConnectAndSend(IPAddress address, int port, int x)
        {
            var tcpClient = new TcpClient();

            //異步發起連接
            Task task = tcpClient.ConnectAsync(address, port);

            //異步發送數據
            Task task1 = task.ContinueWith(t =>
            {
                //發生錯誤時傳遞給下一個callback function
                if (t.IsFaulted)
                {
                    ExceptionDispatchInfo.Capture(t.Exception).Throw();
                }
                Console.WriteLine("發送數據x:" + x + " task1 current runnung processor id = " + Thread.GetCurrentProcessorId());
           
                //返回一個新的Task, 外部需要使用Unwrap方法
                //把Task <Task> 合併為Task
                var bytes = BitConverter.GetBytes(x);
                var stream = tcpClient.GetStream();
                return stream.WriteAsync(bytes, 0, bytes.Length);
            }).Unwrap();

            //處理最終結果
            Task task2 = task1.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Console.WriteLine("connect and send {0} failed", x);
                }
                else if (t.IsCanceled)
                {
                    //支持中斷異步操作需要傳遞CancellationToken
                    //這個例子為了簡單沒有支持中斷，所以這裡的處理不會執行
                    Console.WriteLine("connet and send {0} cancelled", x);
                }
                else
                {
                    Console.WriteLine("結果處理x:"+x+ " task2 current runnung processor id = " + Thread.GetCurrentProcessorId());
                   
                    Console.WriteLine("connect and send {0} success", x);
                }
                tcpClient.Close();
            });
            return task2;
        }

        private static void ConnectAndSend10K(IPAddress address,int port)
        {
            var tasks = new Task[10];
            for(var x= 0;x<tasks.Length; x++)
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
