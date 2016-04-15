using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SteamSharp.steamStore.models;

namespace PageRank
{
    class TagHandler
    {
        public List<int> ListOfGameIDs;
        public List<SteamStoreGame> gameList { get; private set; }

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
            int errorCount = 0;
            for (int index = 0; index < ListOfIDs.Count; index++)
            {
                try
                {
                    gameList.AddRange(steamSharp.GameListByIds(new[] {ListOfIDs[index]}));
                }
                catch (ArgumentNullException)
                {
                    errorCount++;
                }
                catch (NullReferenceException)
                {
                    errorCount++;
                }
            }
            
        }
    }
}
