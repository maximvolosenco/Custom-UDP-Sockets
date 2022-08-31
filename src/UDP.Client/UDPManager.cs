using System.Net;
using System.Text;
using System.Net.Sockets;
using UDP.Client.Properties;

namespace UDP.Client
{
    public class UDPManager
    {
        UdpClient _udp;
        IPEndPoint _ipEndpoint;
        IPAddress _ipAdress;
        public UDPManager()
        {
            _udp = new UdpClient();
            _udp.Client.Bind(new IPEndPoint(IPAddress.Any, Config.ClientPort));
            _ipAdress = IPAddress.Parse(Config.IPAdress);
            _ipEndpoint = new IPEndPoint(_ipAdress, Config.ClientPort);
        }
        
        public void Start()
        {

            Console.WriteLine("Enter message: ");
            string? message = Console.ReadLine();
            while (message != string.Empty)
            {
                SendMessage(message);

                ReceiveMessage();
                message = Console.ReadLine();
            }
            Console.ReadLine();
        }

        private void SendMessage(string? message)
        {
            byte[] bufferToSend = Encoding.ASCII.GetBytes(message);

            _udp.Send(bufferToSend, bufferToSend.Length, Config.IPAdress, Config.ServerPort);
        }

        private void ReceiveMessage()
        {
            byte[] bytes = _udp.Receive(ref _ipEndpoint);

            string messageFromServer = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            Console.WriteLine(messageFromServer);
        }
    }
   
}
