using System;
using Database.lib.converter.models;
using MongoDB.Bson;
using MongoDB.Driver;
using SteamSharp.steamSpy.models;
using SteamSharp.steamStore.models;

namespace Database.lib
{
    public class MongoDb
    {

        public async void DbInsertGame(SteamStoreGame storeGame, SteamSpyData steamSpy)
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<Game>("Games");
            var document = new Game
            {
                Title = storeGame.data.name,
                Developer = storeGame.data.developers,
                Publisher = storeGame.data.publishers,
                SteamAppId = storeGame.data.steam_appid,
                Released = storeGame.data.release_date.coming_soon,
                //This date varries alot. If the game hasn't been released it will default to the 1st of the month defined by steam.
                ReleaseDate = DateTime.Parse(storeGame.data.release_date.date),
                AveragePlayTime = steamSpy.average_forever,
                AveragePlayTime2Weeks = steamSpy.average_2weeks,
                //The price from store is in cents so we convert to EUR here.
                Price = storeGame.data.price_overview.initial / 100.00,
                AgeRating = storeGame.data.required_age,
                CoverImage = new Uri(storeGame.data.header_image),
                StoreLink = new Uri("http://store.steampowered.com/app/" + storeGame.data.steam_appid),
                Genres = storeGame.data.genres,
                Categories = storeGame.data.categories,
                Tags = storeGame.data.tags,
                OwnerCount = steamSpy.owners,
                Windows = storeGame.data.platforms.windows,
                Linux = storeGame.data.platforms.linux,
                Mac = storeGame.data.platforms.mac

            };

            await collection.InsertOneAsync(document);

        }

        public async void DbFindGames()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");

            var collection = database.GetCollection<BsonDocument>("Games");
            var filter = new BsonDocument();
            var count = 0;
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        // process document
                        Console.Write(document.AsBsonDocument);
                        count++;
                    }
                }
            }
            Console.Write(count);
        }
    }
}
