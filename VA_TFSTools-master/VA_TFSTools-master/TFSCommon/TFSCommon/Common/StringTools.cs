using System;
using System.Text;

namespace TFSCommon.Common
{
    public static class StringTools
    {
        private static readonly char[] NewLineChars = Environment.NewLine.ToCharArray();

        public static string FixFileString(string fileLocation)
        {
            return fileLocation.Replace(@"\", @"\\");
        }

        public static string TrimEndNewLine(string value)
        {

            return value.TrimEnd(NewLineChars);
        }

        public static string addExtension(string filePath, string fileType)
        {
            return filePath + "." + fileType;
        }

        public static string StringToCSVCell(string str)
        {
            bool mustQuote = (str.Contains(",") || str.Contains("\"") || str.Contains("\r") || str.Contains("\n"));
            if (mustQuote)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\"");
                foreach (char nextChar in str)
                {
                    sb.Append(nextChar);
                    if (nextChar == '"')
                        sb.Append("\"");
                }
                sb.Append("\"");
                return sb.ToString();
            }

            return str;
        }
    }
}
