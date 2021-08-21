using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server sv = new Server();
            sv.ListenToConnection();
        }
    }
}

