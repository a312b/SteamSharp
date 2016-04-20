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
    class TempGameGetter
    {
        private GameObjectSerializer serializer;
        private List<SteamStoreGame> _gameList = new List<SteamStoreGame>();
        public static int index = 0;
        private int[] PrimaryTags = new int[30];

        public TempGameGetter(int numberOfGames)
        {
            StreamReader reader = new StreamReader("appIDFileCSV.csv");
            string[] ListOfIDs = reader.ReadLine().Split(',').Take(numberOfGames).ToArray();
            for (int i = 0; i < ListOfIDs.Length; i++)
            {
                ListOfIDs[i] = ListOfIDs[i].Trim();
            }
            reader.Close();

            GenerateGameList(ListOfIDs);
            //GenerateGameList(new [] { "434000" });
        }

        private void GenerateGameList(string[] ListOfIDs)
        {
            var erroridsTxt = @"C:\Test\Errors\" + "errorIDs.txt";
            StreamWriter writer = new StreamWriter(erroridsTxt);

            var steamSharp = new SteamSharp.SteamSharp();

            foreach (string ID in ListOfIDs)
            {
                try
                {
                    _gameList.AddRange(steamSharp.GameListByIds(new[] {ID}));
                }
                catch (ArgumentNullException)
                {
                    writer.WriteLine("Error processing ID : " + ID);
                }
                catch (NullReferenceException)
                {
                    writer.WriteLine("Error processing ID : " + ID);
                }
            }
            writer.Close();
            serializer = new GameObjectSerializer(_gameList);
            serializer.Start();
        }
    }
}
