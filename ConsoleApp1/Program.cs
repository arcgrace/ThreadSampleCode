using System;
using System.Threading;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        private static void ThreadProc()
        {
            //線程中的處理
            for (var x = 0; x < 20; x++)
            {
                Console.WriteLine(
                    "({0})thread {1} : {2}",
                    DateTime.Now,
                    Thread.CurrentThread.ManagedThreadId,
                    x);
                Thread.Sleep(1000);
            }
        }
        private static void Main()
        {
            var threads = new List<Thread>();
            for(var x= 0; x < 5; x++)
            {
                //創建線程對象
                var thread = new Thread(ThreadProc);
                //設置線程為後台線程
                thread.IsBackground = true;
                //開始線程
                thread.Start();
            }
            Thread.Sleep(5000);

            //在這裡 , 主線程不會等待後台線程結束
            //而是直接退出程序
        }
    }
}
