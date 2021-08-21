using System;
using System.Threading;
using System.Collections.Generic;

namespace createManagedThreadAndWaitToReturn
{
    internal static class Program
    {
      private static void ThreadProc()
       {
            //線程中的處理
            for(var x= 0; x <20; x++)
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
            for (var x = 0; x < 5; x++)
            {
                //創建線程對象
                var thread = new Thread(ThreadProc);
                //開始線程
                thread.Start();
            }
            foreach (var thread in threads)
            {
                //在這裡寫這個無效 
                Console.WriteLine("hello!");
                //等待線程結束
                thread.Join();
            }
        }
    }
}
