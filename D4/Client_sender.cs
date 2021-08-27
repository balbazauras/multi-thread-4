﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace D4
{
    class Client_sender
    {
        private string fileName;
        public Client_sender(string fileName)
        {
            this.fileName = Path.ChangeExtension(fileName, ".txt");
        }
        public void Send()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1001);
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
