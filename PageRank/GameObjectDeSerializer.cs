using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PageRank
{
    class GameObjectDeserializer
    {
        public EssentialGameData DeserializeGame(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(EssentialGameData));
            EssentialGameData game = serializer.Deserialize(stream) as EssentialGameData;
            return game;
        }
    }
}
