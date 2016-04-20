using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamSharp.steamStore.models;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var steamSharp = new SteamSharp.SteamSharp();
            var db = new Database.Database();
            string[] ids = { "255710", "245470"};
            List<SteamStoreGame> games = steamSharp.GameListByIds(ids);
            foreach (var game in games)
            {
                var spydata = steamSharp.GameSteamSpyDataById(game.data.steam_appid.ToString());
                db.Dbtest(game, spydata);
            }

            Console.ReadKey();
        }
    }
}
