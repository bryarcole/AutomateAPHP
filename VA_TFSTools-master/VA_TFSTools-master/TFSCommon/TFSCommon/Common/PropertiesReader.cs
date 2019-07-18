using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TFSCommon.Common
{
    public class PropertiesReader
    {
        private Dictionary<string, string> list;
        private string filename;

        public PropertiesReader(string file)
        {
            reload(file);
        }

        public string get(string field, string defValue)
        {
            return (get(field) == null) ? (defValue) : (get(field));
        }
        public string get(string field)
        {
            return (list.ContainsKey(field)) ? (list[field]) : (null);
        }

        public void set(string field, Object value)
        {
            if (!list.ContainsKey(field))
                list.Add(field, value.ToString());
            else
                list[field] = value.ToString();
        }

        public void Save()
        {
            Save(this.filename);
        }

        public void Save(string filename)
        {
            this.filename = filename;

            if (!System.IO.File.Exists(filename))
                System.IO.File.Create(filename);

            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);

            foreach (string prop in list.Keys.ToArray())
                if (!string.IsNullOrWhiteSpace(list[prop]))
                    file.WriteLine(prop + "=" + list[prop]);

            file.Close();
        }

        public void reload()
        {
            reload(this.filename);
        }

        public void reload(string filename)
        {
            string path = Directory.GetCurrentDirectory();
            this.filename = path + "\\" + filename;
            list = new Dictionary<string, string>();

            if (File.Exists(filename))
            {
                //Console.WriteLine("Test");
                loadFromFile(filename);
            }
            else
                File.Create(filename);
        }

        private void loadFromFile(string file)
        {
            //Console.WriteLine("Reading from file");
            //Console.WriteLine(this.filename);
            var lines = File.ReadAllLines(this.filename);
            //Console.WriteLine(lines);

            foreach (string line in lines)
            {
                //Console.WriteLine(line);

                if ((!string.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(";")) &&
                    (!line.StartsWith("#")) &&
                    (!line.StartsWith("'")) &&
                    (line.Contains('=')))
                {
                    int index = line.IndexOf('=');
                    //Console.WriteLine(index);
                    string key = line.Substring(0, index).Trim();
                    string value = line.Substring(index + 1).Trim();

                    if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                        (value.StartsWith("'") && value.EndsWith("'")))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    try
                    {
                        //Console.WriteLine(key + value);
                        list.Add(key, value);
                    }
                    catch { }
                }
            }
        }
    }
}

