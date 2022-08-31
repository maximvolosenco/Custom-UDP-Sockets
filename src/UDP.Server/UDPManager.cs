using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDP.Server.Properties;

namespace UDP.Server
{
    public class UDPManager
    {
        UdpClient _udp;
        IPEndPoint _ipEndpoint;
        Socket _socket;
        IPAddress _broadcast;
        public UDPManager()
        {
            _udp = new UdpClient(Config.ServerPort);
            _ipEndpoint = new IPEndPoint(IPAddress.Any, Config.ServerPort);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _broadcast = IPAddress.Parse(Config.IPAdress);
        }
        public void Start()
        {
            Console.WriteLine("Waiting for broadcast");
            while (true)
            {
                string message = ReceiveMessage();
                SendMessage(message);
            }

        }
        private string ReceiveMessage()
        {
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
                IPEndPoint ipEndpoint = new IPEndPoint(_broadcast, Config.ClientPort);

                _socket.SendTo(bufferToSend, ipEndpoint);
            }
        }
    }
}
