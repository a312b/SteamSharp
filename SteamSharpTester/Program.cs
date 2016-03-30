using System;
using SteamSharp;

namespace SteamSharpTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //xpath = //*[@id="game_highlights"]/div[1]/div/div[4]/div/div[2]

            /*
            https://docs.mongodb.org/getting-started/csharp/query/
            http://store.steampowered.com/app/245470/
            http://www.c-sharpcorner.com/UploadFile/9b86d4/getting-started-with-html-agility-pack/
            */
           
            var SharpTest = new Tests("ENTER API KEY");

            Console.ReadKey();

        }
    }
}
