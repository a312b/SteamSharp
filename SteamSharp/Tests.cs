using System;
using SteamSharp.steamUser;

namespace SteamSharp
{
    //Just here for basic testing of the library
    public class Tests
    {
        public string ApiKey { get; set; }

        readonly SteamSharp _steamSharpTest = new SteamSharp();

        public Tests(string Key)
        {
            ApiKey = Key;
        }
        //Functions for testing library 
        public void PrintGamesFromStoreTest()
        {
            string[] idArray = { "245470", "441920" };
            var gameArray = _steamSharpTest.GameListByIds(idArray);
            foreach (var steamStoreGame in gameArray)
            {
                Console.Write(steamStoreGame.data.name);
                Console.WriteLine("\r\n");
                Console.Write(steamStoreGame.data.steam_appid);

                foreach (var item in steamStoreGame.data.tags)
                {
                    Console.WriteLine("\r\n");
                    Console.Write(item.description);
                }
            }
        }
        public void PrintPlayerTest()
        {
            var steamUser = new SteamApi(ApiKey);
            string[] idArray = { "76561197960435530", "76561198022252871" };
            var steamUserList = steamUser.GetSteamUserData(idArray).players;
            foreach (var steamPlayer in steamUserList)
            {
                Console.Write(steamPlayer.personaname);
                Console.WriteLine("\r\n");
            }

        }

        public void PrintPlayerGameTimeListTest()
        {
            var gameTimeList = _steamSharpTest.SteamUserGameTimeListById(ApiKey, "76561197960434622");
            foreach (var game in gameTimeList)
            {
                Console.Write($"Game id: {game.appid} - Time played: {game.playtime_forever}");
                Console.WriteLine("\r\n");
            }
        }

        public void PrintSteamSpyDataTest()
        {
            var spydata = _steamSharpTest.GameSteamSpyDataById("730");
            Console.Write($"Game: {spydata.name} and owners: {spydata.owners}");
        }


        //Old db test
        /*
        public void dbTester()
        {
            mongodb mongo = new mongodb();
            mongo.Dbtest();
            mongo.DbGetData();
           
        }
        */
    }

}
