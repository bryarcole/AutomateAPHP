using System;
using System.IO;

namespace TFSCommon.Common
{
    public class Logger
    {
        private string _fileLocation;

        public Logger()
        {
            _fileLocation = "C:\\Users\\bryar.h.cole\\Desktop\\" + GenerateFileName();
        }

        public Logger(string fileLocation)
        {
            _fileLocation = fileLocation + "\\" + GenerateFileName();
        }

        public void Log(string logMessage)
        {
            using (StreamWriter w = File.AppendText(_fileLocation))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine("  :");
                w.WriteLine($"  :{logMessage}");
                w.WriteLine("-------------------------------");
            }
        }

        public void LogUriAndPackage(string uri, string logMessage)
        {
            using (StreamWriter w = File.AppendText(_fileLocation))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine("  :");
                w.WriteLine($"  :{uri}");
                w.WriteLine($"  :{logMessage}");
                w.WriteLine("-------------------------------");
            }
        }

        private string GenerateFileName()
        {
            string res = DateTime.Now.ToString("s").Replace(":", ".") + "_log.txt";
            return res;
        }
    }
}
