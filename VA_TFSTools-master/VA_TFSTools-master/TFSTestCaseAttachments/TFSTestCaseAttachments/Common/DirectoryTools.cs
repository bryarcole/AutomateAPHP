using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSTestCaseAttachments.Common
{
    class DirectoryTools
    {
        public void createDirectory(string directory)
        {
            if (!Directory.Exists(@directory))
            {
                Console.WriteLine("Creating Directory");
                Console.WriteLine(directory);
                Directory.CreateDirectory(@directory);
            }
        }
    }
}
