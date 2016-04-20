using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamSharp.steamStore.models;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PageRank
{
    class Program
    {
        static void Main(string[] args)
        {
            GameObjectDeSerializer deSerializer = new GameObjectDeSerializer();
            TempGameGetter tagHandler = new TempGameGetter(10);
            //DirectoryInfo dir = new DirectoryInfo(@"C:\Test\");
            //List<EssentialGameData> gameList = new List<EssentialGameData>();

            //foreach (FileInfo file in dir.GetFiles())
            //{
            //    gameList.Add(deSerializer.DeserializeGame(file.FullName));
            //}
            //foreach (var essentialGameData in gameList)
            //{
            //    Console.WriteLine(essentialGameData.Name);
            //}

            Console.ReadKey();
        }

        
    }
}
