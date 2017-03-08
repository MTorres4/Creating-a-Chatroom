using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;



namespace Chatroom
{
    class Server : IUser
    {
        public Queue<string> messages = new Queue<string>();
        public TcpClient client;
        public string serverIP;
        ILoggable log;
        //client.username = client.username;
        //client.username = username;
        //private Dictionary<client.username, client.username> users = new Dictionary <client.username, client.username>();
        public Server(ILoggable log)
        {
            this.log = log;
        }

        public void AcceptClient()
        {
            // Retrieve the Name of HOST
            string hostName = Dns.GetHostName();

            // Get the IP
            serverIP = Dns.GetHostEntry(hostName).AddressList[1].ToString();

            

            //accepts data from client
            
            
        }

        public TcpClient ListenForClient()
        {
            //Listens for client to connect
            //  IPAddress ipAddress = IPAddress.Parse(serverIP);
            while (true)
            {
                TcpListener listen = new TcpListener(IPAddress.Any, 2007);
                Console.WriteLine("[Listening...]");
                listen.Start();
                client = listen.AcceptTcpClient();
                Console.WriteLine("[Client connected]");
                
            }
            
        }
        public void clientbob(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int data = stream.Read(buffer, 0, client.ReceiveBufferSize);
            string ch = Encoding.Unicode.GetString(buffer, 0, data);
            Console.WriteLine($" Message Received: {ch}");
            client.Close();
            Console.ReadKey();
        }
        public void JoinChatroom()
        {
            //users.Add(user);
        }

        public void JustJoined()
        {
            NotifyUsers();
        }

        public void NotifyUsers()
        {
            //foreach(KeyValuePair<client.username> Kvp in users)
            {
                //user.Notify(user);
                //may not need above
                //CWL($"{user.Username} has joined the chatroom"); Need method to send for display
            }
        }

        public void WriteToLog(string receivedMessage)
        {
            log.WriteTo(receivedMessage);
        }

        public void AddToQueue(string receivedMessage)
        {
            messages.Enqueue(receivedMessage);
        }

        public void DisplayMessage()
        {
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
