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
namespace D4
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            Thread th1 = new Thread(o =>
            {
                Client_receiver receiver = new Client_receiver();
                receiver.Start();
                Tesseract tesseract = new Tesseract();
                tesseract.ReadData(FileInfo.filePath);
            });
            th1.Start();  
        }
    }
}
