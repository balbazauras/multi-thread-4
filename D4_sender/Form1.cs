using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D4_sender
{
    public partial class Form1 : Form
    {
        private string fileName;
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Thread th1 = new Thread (o => 
            { Server_sender send = new Server_sender(fileName);
              send.Send();
            });
            Thread th2 = new Thread(o =>
            {
                Server_receiver server_Receiver = new Server_receiver();
                server_Receiver.Start();
            });
            th1.Start();
            th2.Start();
        }
    }
}
