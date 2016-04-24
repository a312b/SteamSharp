using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.lib;
using Database.lib.converter.models;
using SteamSharp.steamSpy.models;
using SteamSharp.steamStore.models;

namespace Database
{
    public class Database
    {
        private MongoDb Mongo { get; }

        public Database()
        {
            Mongo = new MongoDb("mongodb://localhost:27017", "test", "Games");
        }
        public void InsertGame(SteamStoreGame game, SteamSpyData data)
        {
            Mongo.DbInsertGame(game, data);
        }

        public List<Game> FindAllGames()
        {
            return Mongo.DbFindGames();
        }
    }
}
