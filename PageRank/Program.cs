using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamSharp.steamStore.models;
using System.IO;
using System.Linq.Expressions;
using System.Net.Configuration;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace PageRank
{
    class Program
    {
        static void Main(string[] args)
        {
            //GameObjectDeserializer deSerializer = new GameObjectDeserializer();
            //TempGameGetter getter = new TempGameGetter(10);

            TagReader tagReader = new TagReader(@"C:\Users\Alex\Desktop\TagsForAppID.txt");
            tagReader.Start();

            Tuple<List<string>, List<List<int>>> input = tagReader.GenerateTagMatrix();

            ArrayList arrList = new ArrayList();

            foreach (List<int> list in input.Item2)
            {
                arrList.Add(list);
            }

            CopyPasteRank cpRank = new CopyPasteRank(arrList);

            double[] result = cpRank.ComputePageRank();

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