using System;
using SteamSharpCore;

namespace LoadDatabse
{
    class Program
    {
        static void Main(string[] args)
        {
            Loader loadDB = new Loader();

            loadDB.LoadGamesIntoDatabase();
            

            //SteamSharp ssharp = new SteamSharp("DCBF7FBBE0781730FA846CEF21DBE6D5");
            //ssharp.GameById("430170");

            Console.WriteLine("Donas");
            Console.ReadKey();
        }
    }
}
