using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UntitledSandbox_Server
{
    public static class FileManager
    {
        public static string path = Directory.GetCurrentDirectory() + "/data/";
        public static string config = path + "config.txt";
        public static string banlist = path + "banlist.txt";

        public static void FixFolder()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static string ReadConfig(int index)
        {
            FixFolder();
            if (!File.Exists(config)) File.Create(config);
            string content = File.ReadAllText(config);
            string[] data = content.Split(',');
            if (data.Length <= index) return "Unknown";
            return data[index];
        }

        public static void WriteConfig(int index, string data)
        {
            FixFolder();
            string path = config;
            if (!File.Exists(path)) File.Create(path);
            string content = File.ReadAllText(path);
            string[] contents = content.Split(',');
            if (contents.Length <= index) return;
            contents[index] = data;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < contents.Length; i++)
            {
                if (i == contents.Length - 1) builder.Append(contents[i]);
                else builder.Append(contents[i] + ",");
            };
            File.WriteAllText(path, builder.ToString());
        }

        public static List<string> ReadBanlist()
        {
            FixFolder();
            if (!File.Exists(banlist)) File.Create(banlist);
            string content = File.ReadAllText(banlist);
            string[] data = content.Split(',');
            return data.ToList();
        }

        public static void AppendBanlist(string name)
        {
            FixFolder();
            string newPath = banlist;
            if (!File.Exists(path)) File.Create(newPath);
            File.AppendAllText(path, "," + name);
        }

        public static void Defaults()
        {
            FixFolder();
            string newPath = config;
            File.WriteAllText(newPath, "true,true,true,false");
        }
    }
}