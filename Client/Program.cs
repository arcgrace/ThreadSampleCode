using SocketDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client ct = new Client();
            ct.ConnetToServer();
        }
    }
   
}
