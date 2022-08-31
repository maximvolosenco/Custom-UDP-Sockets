using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDP.Server.Properties;

namespace UDP.Server
{
    public class UDPManager
    {
        //UdpClient _udp;
        //IPEndPoint _ipEndpoint;
        //Socket _socket;
        //IPAddress _broadcast;

        UdpClient _udp;
        IPEndPoint _ipEndpoint;
        IPAddress _ipAdress;
        public UDPManager()
        {
            //_udp = new UdpClient(Config.ServerPort);
            //_ipEndpoint = new IPEndPoint(IPAddress.Any, Config.ServerPort);
            //_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //_broadcast = IPAddress.Parse(Config.IPAdress);

            _udp = new UdpClient();
            _udp.Client.Bind(new IPEndPoint(IPAddress.Any, Config.ServerPort));
            _ipAdress = IPAddress.Parse(Config.IPAdress);
            _ipEndpoint = new IPEndPoint(_ipAdress, Config.ServerPort);
        }
        public void Start()
        {
            Console.WriteLine("Waiting for broadcast");
            while (true)
            {
                string message = ReceiveMessage();
                //SendMessage(message);
            }

        }
        private string ReceiveMessage()
        {
            //byte[] bytes = _udp.Receive(ref _ipEndpoint);
            byte[] bytes = _udp.Receive(ref _ipEndpoint);
            string messageFromClient = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            Console.WriteLine($" {messageFromClient}");

            return messageFromClient;
        }

        private void SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                string _messageToClient = "200 ok";
                byte[] bufferToSend = Encoding.ASCII.GetBytes(_messageToClient);

                _udp.Send(bufferToSend, bufferToSend.Length, Config.IPAdress, Config.ServerPort);
                //IPEndPoint ipEndpoint = new IPEndPoint(_broadcast, Config.ClientPort);

                //_socket.SendTo(bufferToSend, ipEndpoint);
            }
        }
    }
}
