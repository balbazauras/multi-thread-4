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
    class Server_receiver
    {
        private static TcpListener listener = null;
        private string downloadsFolder = @"C:\Users\Whis\Desktop\Atsiskaitymas\result_server\";
        public static string Message = "Stopped";

        public void Start()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, 1001);
                listener.Start();
                MessageBox.Show("Started");
                while (true)
                {
                    using (var client = listener.AcceptTcpClient())
                    using (var stream = client.GetStream())
                    {
                        byte[] fileNameLengthBytes = new byte[4];
                        stream.Read(fileNameLengthBytes, 0, 4);
                        int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes, 0);
                        byte[] fileNameBytes = new byte[fileNameLength];
                        stream.Read(fileNameBytes, 0, fileNameLength);
                        string fileName = Encoding.ASCII.GetString(fileNameBytes, 0, fileNameLength);

                        string file = $"{downloadsFolder}{fileName}";
                        using (var output = File.Create(file))
                        {
                            MessageBox.Show("Saving file...");
                            var buffer = new byte[1024];
                            int bytesRead;
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                // progresui ideali vieta
                                output.Write(buffer, 0, bytesRead);
                            }
                        }
                        MessageBox.Show("Saving file complete");
                    }
                }
            }
            catch (Exception exc)
            {
                Message = exc.Message;
            }

        }
    }
}

