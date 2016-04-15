using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamSharp.steamStore.models;
using System.IO;
using System.Xml.Serialization;

namespace PageRank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EssentialGameData> gameList = new List<EssentialGameData>();
            //SteamSharp.SteamSharp steamSharp = new SteamSharp.SteamSharp();
            //TagHandler tagHandler = new TagHandler(1);
            DirectoryInfo dir = new DirectoryInfo(@"C:\Test");
            foreach (FileInfo file in dir.GetFiles())
            {
                gameList.Add(DeserializeObjects(file.FullName));
            }
            foreach (var gameData in gameList)
            {
                Console.WriteLine(gameData.Name);
                Console.WriteLine(gameData.GameID);
            }


            Console.ReadKey();
        }

        public static EssentialGameData DeserializeObjects(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open)) //double check that...
            {
                XmlSerializer _xSer = new XmlSerializer(typeof(EssentialGameData));

                var myObject = _xSer.Deserialize(fs);
                return myObject as EssentialGameData;
            }
        }
    }
}
