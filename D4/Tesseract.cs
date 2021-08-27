using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using System.IO;

namespace D4
{
    class Tesseract
    {
        public void ReadData(string filePath)
        {
            try
            {
                MessageBox.Show("Reading started");
                string text = null;
                {
                    var engine = new TesseractEngine(@"./TesseractFiles", "eng", EngineMode.Default);
                    var img = Pix.LoadFromFile(filePath);
                    var page = engine.Process(img);
                    text = page.GetText();
                    using (StreamWriter outputFile = new StreamWriter(Path.ChangeExtension(filePath, ".txt")))
                    {
                        outputFile.Write(text);
                    }
                }
                MessageBox.Show("Reading done");
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                MessageBox.Show("Unexpected Error: " + e.Message);
                MessageBox.Show("Details: ");
                MessageBox.Show(e.ToString());
            }
        }
    }
}
