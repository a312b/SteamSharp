using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.lib;
using SteamSharp.steamSpy.models;
using SteamSharp.steamStore.models;

namespace Database
{
    public class Database
    {
        public void InsertGame(SteamStoreGame game, SteamSpyData data)
        {
            var mongo = new MongoDb();
            mongo.DbInsertGame(game, data);
        }

        public void FindGames()
        {
            var mongo = new MongoDb();
            mongo.DbFindGames();
        }
    }
}
