using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D4_sender
{
    class ImageRepo
    {
        //@"C:\Users\Whis\Desktop\Atsiskaitymas\source\"
        public static string [][] Distribution(int numberOfReceivers)
        {
            int counter=0;
            string[] list= Directory.GetFiles(@"C:\Users\Whis\Desktop\Atsiskaitymas\source\");


               // people.Add(new Person { Name = "Person #" + (i + 1) });
            var receivers = new List<Info>();
            for (int i = 0; i < numberOfReceivers; i++)
            {
               foreach(string l  in list)
                {
                  

                }
            }


            return null;
        }
    }
    //+ list.Length % numberOfReceivers
}
