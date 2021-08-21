using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SocketDemo;
namespace ConsoleServer
{
   public class HandleClient
    {
        /// <summary>
        /// private attribute of HandleClient class
        /// </summary>
        private TcpClient mTcpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_tmpTcpClient">傳入TcpClient參數</param>
        public HandleClient(TcpClient _tmpTcpClient)
        {
            this.mTcpClient = _tmpTcpClient;
        }

        public void Communicate()
        {
            try
            {
                CommunicationBase cb = new CommunicationBase();
                string msg = cb.ReceiveMsg(this.mTcpClient);
                Console.WriteLine(msg + "\n");
                cb.SendMsg("主機回傳測試", this.mTcpClient);
            }
            catch
            {
                Console.WriteLine("客戶端強制關閉連線!");
                this.mTcpClient.Close();
                Console.Read();
            }
        }//end HandleClient()
    }//end Class
}//end namespace

//HandleClient裡面只有一個Communicate()的方法，是用來傳送及接收訊息，
//而在稍早提到因為傳送及接收的功能主機及客戶端都會使用到，
//所以在這裡需先new一個CommunicationBase的物件再使用其傳送及接收的方法：

//cb.ReceiveMsg()
//cb.SendMsg()
