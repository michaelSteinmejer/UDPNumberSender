using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPNumberSender
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a UdpClient for reading incoming data.
            UdpClient udpClient = new UdpClient("192.168.24.192",7011);

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            IPAddress ip = IPAddress.Parse("192.168.24.192");
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 7011);

            try
            {
                // Blocks until a message is received on this socket from a remote host (a client).
                Console.WriteLine("Server is blocked");
                while (true)
                {
                    

                    Random rnd = new Random();
                    int number = rnd.Next(1, 10);                
                    //Console.WriteLine("Received from: " + clientName.ToString() + " " + text.ToString());

                    
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("sensor" + number);

                    udpClient.Send(sendBytes, sendBytes.Length);

                    Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
