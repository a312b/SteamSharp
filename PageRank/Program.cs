using System;
using System.CodeDom.Compiler;
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
            //446750 corrupts

            //TagHandler tagHandler = new TagHandler(10);

            //SteamSharp.SteamSharp steamSharp = new SteamSharp.SteamSharp();

            StreamReader reader;
            List<EssentialGameData> gameList = new List<EssentialGameData>();
            DirectoryInfo dir = new DirectoryInfo(@"C:\Test");
            foreach (FileInfo file in dir.GetFiles())
            {
                reader = new StreamReader(file.FullName);
                int i = reader.ReadToEnd().Count(ch => ch == ';');
                Console.WriteLine($"{file.Name} contains {i} semicolons");
                Console.ReadKey();
                //gameList.Add(DeserializeObjects(file.FullName));
                //Console.WriteLine(file.FullName + @" added to list");
            }
            

            Console.ReadKey();
        }

        public static EssentialGameData DeserializeObjects(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open)) //double check that...
            {
                XmlSerializer _xSer = new XmlSerializer(typeof(EssentialGameData));
                var myObject = _xSer.Deserialize(fs);
                return myObject == null ? new EssentialGameData() : myObject as EssentialGameData;
            }
        }
    }
}
