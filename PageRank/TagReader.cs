using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace PageRank
{
    class TagReader
    {
        private List<List<string>> TagMatrix = new List<List<string>>();
        Dictionary<string, int> TagEnumerator = new Dictionary<string, int>();
        private List<string> AppID = new List<string>(); 
        private StreamReader reader;

        public TagReader(string path)
        {
            reader = new StreamReader(path);
        }

        public Tuple<List<string>, List<List<int>>> GenerateTagMatrix()
        {
            List<List<int>> TagNumberMatrix = new List<List<int>>();
            
            foreach (List<string> list in TagMatrix)
            {
                TagNumberMatrix.Add(GetTagVector(list));
            }
            return new Tuple<List<string>, List<List<int>>>(AppID, TagNumberMatrix);

        }

        private List<int> GetTagVector(List<string> list)
        {
            int[] vector = new int[TagEnumerator.Count];

            foreach (var pair in TagEnumerator)
            {
                if (list.Contains(pair.Key))
                    vector[pair.Value] = 1;
            }
            return vector.ToList();

        }

        public void Start()
        {
            while (!reader.EndOfStream)
            {
                string[] lineSegments = reader.ReadLine().Split(':');
                string ID = lineSegments[0];
                List<string> tags = lineSegments[1].Split(',').ToList();
                TagMatrix.Add(tags);
                AppID.Add(ID);
            }
            reader.Close();
            GenerateTagEnumerator();

        }
        private void GenerateTagEnumerator()
        {
            int tagNumber = 0;
            foreach (List<string> list in TagMatrix)
            {
                foreach (string tag in list)
                {
                    if (TagEnumerator.ContainsKey(tag)) continue;
                    if (!string.IsNullOrWhiteSpace(tag))
                        TagEnumerator.Add(tag, tagNumber++);
                }
            }

        }
    }
}
