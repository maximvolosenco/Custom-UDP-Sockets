using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDP.Server.Properties;

namespace UDP.Server
{
    public class UDPManager
    {
        public void Start()
        {
            
            UdpClient listener = new UdpClient(Config.Port);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, Config.Port);

            //try
            //{
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    Console.WriteLine($"Received broadcast from :");
                    Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                }
            //}
            //catch (SocketException e)
            //{
            //    Console.WriteLine(e);
            //}
            //finally
            //{
            //    listener.Close();
            //}
        }
    }
}
