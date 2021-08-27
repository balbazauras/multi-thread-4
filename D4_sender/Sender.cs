using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D4_sender
{
    class Sender
    {
        private string fileName;


        public Sender(string fileName)
        {
            this.fileName = fileName;

        }

        public void Send(int number)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1000+number);
                byte[] fileNameBytes = Encoding.ASCII.GetBytes(Path.GetFileName(fileName));
                byte[] fileNameLength = BitConverter.GetBytes(Path.GetFileName(fileName).Length);
                byte[] fullBuffer = new byte[4 + fileNameBytes.Length];

                fileNameLength.CopyTo(fullBuffer, 0);
                fileNameBytes.CopyTo(fullBuffer, 4);
                socket.Connect(endPoint);
                socket.SendFile(fileName, fullBuffer, null, TransmitFileOptions.UseDefaultWorkerThread);
                socket.Close();
            
           
            

      

            


        }
    }
}
