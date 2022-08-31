using System.Net;
using System.Text;
using System.Net.Sockets;
using UDP.Client.Properties;

namespace UDP.Client
{
    public class UDPManager
    {
        //UdpClient _udp;
        //IPEndPoint _ipEndpoint;
        //Socket _socket;
        //IPAddress _broadcast;

        UdpClient _udp;
        public UDPManager()
        {
            //_udp = new UdpClient(Config.ClientPort);
            //_ipEndpoint = new IPEndPoint(IPAddress.Any, Config.ClientPort);
            //_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //_broadcast = IPAddress.Parse(Config.IPAdress);
            _udp = new UdpClient();
            //_udp.Client.Bind(new IPEndPoint(IPAddress.Any, Config.ServerPort));
        }
        
        public void Start()
        {

            Console.WriteLine("Enter message: ");
            string? message = Console.ReadLine();
            while (message != string.Empty)
            {
                SendMessage(message);

                //ReceiveMessage();
                message = Console.ReadLine();
            }
            Console.ReadLine();
        }

        private void SendMessage(string? message)
        {
            byte[] bufferToSend = Encoding.ASCII.GetBytes(message);

            _udp.Send(bufferToSend, bufferToSend.Length, Config.IPAdress, Config.ServerPort);
            //IPEndPoint ipEndpoint = new IPEndPoint(_broadcast, Config.ServerPort);

            //_socket.SendTo(bufferToSend, ipEndpoint);
        }

        //private void ReceiveMessage()
        //{
        //    //byte[] bytes = _udp.Receive(ref _ipEndpoint);

        //    string messageFromServer = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
        //    Console.WriteLine(messageFromServer);
        //}
    }
   
}
