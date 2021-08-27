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
            for(int i=1;i<int.Parse(numberOfReceivers.Text);i++)
            {
               
                Receiver receiver = new Receiver();
                Thread th = new Thread(o => 
                { 
                    receiver.Start(1000 + i);
                   
                });   
            }
           
           
        }
    }
}
