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
            string path = config;
            if (!File.Exists(path)) File.Create(path);
            string content = File.ReadAllText(path);
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
            content = "";
            for (int i = 0; i < contents.Length; i++)
            {
                if (i == contents.Length - 1) content += contents[i];
                else content += contents[i] + ",";
            };
            File.WriteAllText(path, content);
        }

        public static List<string> ReadBanlist()
        {
            FixFolder();
            string path = banlist;
            if (!File.Exists(path)) File.Create(path);
            string content = File.ReadAllText(path);
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