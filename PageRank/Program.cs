using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamSharp.steamStore.models;
using System.IO;

namespace PageRank
{
    class Program
    {
        static void Main(string[] args)
        {
            TagHandler tagHandler = new TagHandler(200);

            Console.ReadKey();
        }
    }
}
