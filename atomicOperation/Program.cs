using System;
using System.Threading;

namespace atomicOperation
{
    class Program
    {
        public static int x = 0;
        public static void Main(string[] args)
        {
            
        }

        public static void increment()
        {
            int y = Interlocked.Increment(ref x);
            Console.WriteLine(y);
            Console.ReadKey();
        }
    }
}
