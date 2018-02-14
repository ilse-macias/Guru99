using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99
{
    public class Utils
    {
        string path = @"C:\workspace\Guru99\Logs\log.txt";
        
        public Utils()
        {
  
        }

        //public void Main()
        //{

        //    // This text is always added, making the file longer over time if it's not deleted.
        //    using (StreamWriter write = File.AppendText(path))
        //    {
        //        Mobile mobile = new Mobile();
        //        Log("The test has passed.", write);
        //       // Log("Test2", write);
        //    }

        //    //Call the method DupLog to read.
        //    using (StreamReader read = File.OpenText(path))
        //    {
        //        DumpLog(read);
        //    }
        //}

        public void Log(string logMessage, TextWriter write)
        {
            write.WriteLine("Log Entry: ");
            write.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            write.WriteLine("{0} Message:", logMessage);
            write.WriteLine("-------------------------------");
        }

        //Open the file to read from.
        public void DumpLog(StreamReader read)
        {
            string line;
            while ((line = read.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        // This text is always added, making the file longer over time if it's not deleted.
        public void LogMsg(string msg)
        {
            using (StreamWriter write = File.AppendText(path))
            {
                Log(msg, write);
            }
        }
    }
}
