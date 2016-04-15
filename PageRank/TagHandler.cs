using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PageRank
{
    class TagHandler
    {
        public List<int> ListOfGameIDs; 
        public TagHandler(int numberOfGames)
        {
            StreamReader reader = new StreamReader("appIDFileCSV.csv");
            string[] ListOfIDs = reader.ReadLine().Split(',').Take(numberOfGames).ToArray();
            ListOfGameIDs = new List<int>(ListOfIDs.Select(int.Parse).ToList());
            reader.Close();
        }
    }
}
