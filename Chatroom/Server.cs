using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;



namespace Chatroom
{
    class Server
    {
        public string serverIP;
        public Server()
        {

        }

        public void AcceptClient()
        {
            // Retrive the Name of HOST
            string hostName = Dns.GetHostName();

            // Get the IP
            serverIP = Dns.GetHostEntry(hostName).AddressList[1].ToString();

            //Listens for client to connect
            IPAddress ipAddress = IPAddress.Parse(serverIP);
            TcpListener listen = new TcpListener(ipAddress, 5600);
            Console.WriteLine("[Listenning...]");
            listen.Start();
            TcpClient client = listen.AcceptTcpClient();
            Console.WriteLine("[Client connected]");

            //accepts data from client
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int data = stream.Read(buffer, 0, client.ReceiveBufferSize);
            string ch = Encoding.Unicode.GetString(buffer, 0, data);
            Console.WriteLine("Message Received:" + ch);
            client.Close();
            Console.ReadKey();
        }
    }
}
