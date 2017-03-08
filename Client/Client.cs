using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Chatroom
{
    class Client
    {
        public string myIP;
        public Client()
        {

        }

        public void GetIpAddress()
        {
            // Retrive the Name of HOST
            string hostName = Dns.GetHostName();
            // Get the IP
            myIP = Dns.GetHostEntry(hostName).AddressList[1].ToString();
        }
        public void ConnectToServer()
        {
            //establishes connection with server
            TcpClient client = new TcpClient(myIP, 5600);
            Console.WriteLine("[Try to connect to server...]");
            //sends data to server
            NetworkStream n = client.GetStream();
            Console.WriteLine("[Connect]");
            string ch = Console.ReadLine();
            byte[] message = Encoding.Unicode.GetBytes(ch);
            n.Write(message, 0, message.Length);
            Console.WriteLine("--------------------sent---------------");
            client.Close();
            Console.ReadKey();
        }
    }
}
