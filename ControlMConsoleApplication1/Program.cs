using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ControlMConsoleApplication1
{
   public class Program
    {
        public class Randy
        {
            public int RandID { get; set; }
            public int RandHash { get; set; }
        }
      public  static void Main(string[] args)
        {
            string dataDump = "";
            string filePath = @"\\CRASTCMBTHDEV01\tcmbatch\tcmapp\ERS\TTMDEV\TestControlM\";
            Random rnd = new Random(DateTime.Now.Millisecond);
            if (args!=null && args.Count()>0)
            {
                switch (args[0])
                {
                    case "create":
                        
                        
                        dataDump = Enumerable.Range(100, 10000).Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y);
                        File.WriteAllText(filePath+"xxxDataDumpxxx.txt", dataDump);
                        break;
                    case "transform":
                       
                        while (File.Exists(filePath + "xxxDataDumpxxx.txt") ==false)
                        {
                            Thread.Sleep(1000);
                        }
                        var data = File.ReadAllText(filePath + "xxxDataDumpxxx.txt");
                        var rands = data.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => new Randy { RandHash = x.GetHashCode(), RandID = int.Parse(x) }).ToList();
                        XmlSerializer serial = new XmlSerializer(typeof(Randy));
                        serial.Serialize(File.OpenWrite(filePath+"xxxDataDumpxxx.xml"), rands[rnd.Next(100, 10000)]);

                        break;
                    default:
                       
                        break;
                }
            }
            else
            {
                dataDump = Enumerable.Range(100, 10000).Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y);
                File.WriteAllText("xxxDataDumpxxx.txt", dataDump);

                var data2 = File.ReadAllText("xxxDataDumpxxx.txt");
                var rands2 = data2.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => new Randy { RandHash = x.GetHashCode(), RandID = int.Parse(x) }).ToList();
                XmlSerializer serial2 = new XmlSerializer(typeof(Randy));
                serial2.Serialize(File.OpenWrite("xxxDataDumpxxx.xml"), rands2[rnd.Next(100,10000)]);
                Console.WriteLine("Done");
            }
        }
    }
}
