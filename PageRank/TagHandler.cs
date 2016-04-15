using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using SteamSharp.steamStore.models;

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

            GenerateGameList(IDStringList);
        }

        private void GenerateGameList(List<string> ListOfIDs)
        {
            
            var steamSharp = new SteamSharp.SteamSharp();

            foreach (string ID in ListOfIDs)
            {
                try
                { 
                    gameList.AddRange(steamSharp.GameListByIds(new [] {ID }));
                }
                catch (ArgumentNullException)
                {
                }
                catch (NullReferenceException)
                {
                }
            }
            foreach (var game in gameList)
            {
                EssentialGameData essentialGameData = new EssentialGameData();
                string gameFileName = game.data.name.Where(char.IsLetterOrDigit)
                    .Aggregate("", (current, ch) => current + ch);
                var path = @"C:\Test\" + gameFileName + ".xml";
                
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xSer = new XmlSerializer(typeof(EssentialGameData));

                    xSer.Serialize(fs, essentialGameData);
                }
            }
        }
    }
}
