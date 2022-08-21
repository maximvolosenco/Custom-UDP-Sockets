﻿using System.Net;
using System.Text;
using System.Net.Sockets;

namespace UDP.Client
{
    public class UDPSender
    {
        public void StartSender()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("192.168.100.38");

            Console.WriteLine("Enter message: ");
            string message = Console.ReadLine();
            while (message != string.Empty)
            {
                byte[] sendBuf = Encoding.ASCII.GetBytes(message);
                IPEndPoint ep = new IPEndPoint(broadcast, 11000);

                socket.SendTo(sendBuf, ep);

                Console.WriteLine("Message sent");

                message = Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
   
}