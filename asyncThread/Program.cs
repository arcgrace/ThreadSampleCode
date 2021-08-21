using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace asyncThread
{
    class Program
    {
        //不確定是因為port 還是socket的設定
        static void Main(string[] args)
        {


            IPAddress ipAddress = Dns.GetHostEntry("webcode.me").AddressList[0];           
            ConnectAndSend10K(ipAddress, 80);
        }
        private static  void ConnectAndSend(IPAddress address, int port, int x)
        {
            Console.WriteLine("this is round " + x);
            Console.WriteLine("current running processor " + Thread.GetCurrentProcessorId());

            
            using var client = new TcpClient();

            var hostname = "webcode.me";

            //連接是一個blocking operation(阻塞操作)，線程進入等待狀態，並在成功或失敗時恢復執行
            client.Connect(hostname, 80);

            using NetworkStream networkStream = client.GetStream();
            networkStream.ReadTimeout = 2000;

            using var writer = new StreamWriter(networkStream);

            var message = "HEAD / HTTP/1.1\r\nHost: webcode.me\r\nUser-Agent: C# program\r\n"
                + "Connection: close\r\nAccept: text/html\r\n\r\n";

            Console.WriteLine(message);
            Console.WriteLine("current running processor id= " + Thread.GetCurrentProcessorId());
            using var reader = new StreamReader(networkStream, Encoding.UTF8);

            byte[] bytes = Encoding.UTF8.GetBytes(message);
            //發送數據是一個阻塞操作，線程進入等待狀態，並在成功或失敗時恢復執行
            networkStream.Write(bytes, 0, bytes.Length);
            //讀取數據也是一個阻塞操作，線程進入等待狀態，並在成功或失敗時恢復執行
            Console.WriteLine(reader.ReadToEnd());
            Console.WriteLine("current running processor id= " + Thread.GetCurrentProcessorId());

            ////////////
            //TcpClient tcpClient = new TcpClient();
            //IPAddress ipAddress = Dns.GetHostEntry("webcode.me").AddressList[0];

            //tcpClient.Connect(ipAddress, port);
            //// Uses the GetStream public method to return the NetworkStream.
            //NetworkStream netStream = tcpClient.GetStream();

            //if (netStream.CanWrite)
            //{
            //    Byte[] sendBytes = Encoding.UTF8.GetBytes("Is anybody there?");
            //    netStream.Write(sendBytes, 0, sendBytes.Length);
            //}
            //else
            //{
            //    Console.WriteLine("You cannot write data to this stream.");
            //    tcpClient.Close();

            //    // Closing the tcpClient instance does not close the network stream.
            //    netStream.Close();
            //    return;
            //}

            //if (netStream.CanRead)
            //{
            //    // Reads NetworkStream into a byte buffer.
            //    byte[] bytes = new byte[tcpClient.ReceiveBufferSize];

            //    // Read can return anything from 0 to numBytesToRead.
            //    // This method blocks until at least one byte is read.
            //    netStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);

            //    // Returns the data received from the host to the console.
            //    string returndata = Encoding.UTF8.GetString(bytes);

            //    Console.WriteLine("This is what the host returned to you: " + returndata);
            //}
            //else
            //{
            //    Console.WriteLine("You cannot read data from this stream.");
            //    tcpClient.Close();

            //    // Closing the tcpClient instance does not close the network stream.
            //    netStream.Close();
            //    return;
            //}
            //netStream.Close();

            //////.net core p.216
            //var tcpClinet = new TcpClient();
            //try
            //{
            //    //連接是一個blocking operation(阻塞操作)，線程進入等待狀態，並在成功或失敗時恢復執行
            //    tcpClinet.Connect(address, port);

            //    var message = "HEAD / HTTP/1.1\r\nHost: webcode.me\r\nUser-Agent: C# program\r\n"
            //                   + "Connection: close\r\nAccept: text/html\r\n\r\n";
            //    byte[] bytes = Encoding.UTF8.GetBytes(message);
            //    //發送數據是一個阻塞操作，線程進入等待狀態，並在成功或失敗時恢復執行
            //    tcpClinet.GetStream().Write(bytes, 0, bytes.Length);
            //    Console.WriteLine("connet and send {0} success", x);
            //}
            //catch (SocketException)
            //{
            //    Console.WriteLine("connect and send {0} failed", x);
            //}
            //finally
            //{
            //    tcpClinet.Close();
            //}
        }

        private static void ConnectAndSend10K(IPAddress address,int port)
        {
            //創建10,000個連接需要創造10,000個線程
            var threads = new Thread[20];
            for(var x = 0; x < threads.Length; x++)
            {
                var thread = new Thread(() => ConnectAndSend(address, port, x));
                threads[x] = thread;
                thread.Start();
            }
            for(var x= 0; x < threads.Length; x++)
            {
                threads[x].Join();
            }
        }
    }
}
