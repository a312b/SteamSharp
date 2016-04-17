using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using SteamSharp.steamStore.models;
using System.Runtime.Serialization;

namespace PageRank
{
    class TagHandler
    {
        public static List<SteamStoreGame> gameList = new List<SteamStoreGame>();
        public static int index = 0;
        private int[] PrimaryTags = new int[30];

        public TagHandler(int numberOfGames)
        {
            StreamReader reader = new StreamReader("appIDFileCSV.csv");
            string[] ListOfIDs = reader.ReadLine().Split(',').Take(numberOfGames).ToArray();
            List<string> IDStringList = ListOfIDs.Select(ID => ID.Trim()).ToList();
            reader.Close();

            //GenerateGameList(IDStringList);
            GenerateGameList(new List<string>() { "434000" });
        }

        private void GenerateGameList(List<string> ListOfIDs)
        {
            var erroridsTxt = @"C:\Test\Errors" + "errorIDs.txt";
            StreamWriter writer = new StreamWriter(erroridsTxt);
            
            var steamSharp = new SteamSharp.SteamSharp();

            foreach (string ID in ListOfIDs)
            {
                try
                { 
                    gameList.AddRange(steamSharp.GameListByIds(new [] {ID }));
                }
                catch (ArgumentNullException)
                {
                    writer.Write("error processing ID : " + ID);
                }
                catch (NullReferenceException)
                {
                    writer.Write("error processing ID : " + ID);
                }
            }
            writer.Close();
            foreach (var game in gameList)
            {
                EssentialGameData essentialGameData = new EssentialGameData();
                string gameFileName = game.data.name.Where(char.IsLetterOrDigit)
                    .Aggregate("", (current, ch) => current + ch);
                var path = @"C:\Test\wut\" + gameFileName + ".xml";
                
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xSer = new XmlSerializer(typeof(EssentialGameData));

                    xSer.Serialize(fs, essentialGameData);
                }
                SerializeObject(essentialGameData);
            }
        }

        private void SerializeObject(EssentialGameData data)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(EssentialGameData));

        }
    }
}
