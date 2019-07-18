using System.IO;

namespace TFSCommon.Common
{
    public static class DirectoryTools
    {
        public static void createDirectory(string directory)
        {
            if (!Directory.Exists(@directory))
            {
                Directory.CreateDirectory(@directory);
            }
        }

        public static string CreateValidFolderString(string directory)
        {
            string res = directory;
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                res = res.Replace(c, '_');
            }
            return res;
        }
    }
}
