using System;
using System.IO;
using static UntitledSandbox_Server.FileManager;

namespace UntitledSandbox_Server
{
    public static class Initializator
    {
        public const string version = "Beta 1.0";
        public const string product = "Untitled Sandbox Server";
        public static void Main()
        {
            Console.WriteLine("* Initializing...");
            Console.Title = product + " " + version;
            try 
            { 
                if (!File.Exists(config)) Defaults();
                if (!File.Exists(banlist)) File.Create(banlist);
                Menu.MenuMain();
            }
            catch (Exception e)
            {
                Console.WriteLine("* An exception occured while initializing. Press enter to exit.");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.Read();
                Environment.Exit(0);
            } 
        }
    }
}
