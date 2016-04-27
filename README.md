# SteamSharp
A C# library for the steam apis. 
SteamSharp consists of 3 parts:
1. SteamSharp, which handles all the data collection from Steam and SteamSpy.
2. DatabaseCore, which is responsible for all operations made to the Mongodb.
3. LoadDatabase, which is the code that loads a new database with all games from steam.
Note: The LoadDatabase is a console application and not i library. It is set as the startup project in the Visual Studio Solution. 
But the LoadDatabase/Program.cs file is left empty.
## Set up
To use the the library, you need to add a refrence in your project.
In your own project add a refrence to the SteamSharp.dll for SteamSharp found at /SteamSharp/bin/Debug
1. Create an instance of the SteamSharp class
```cs
var steamSharp = new SteamSharp(STEAM_API_KEY);
```
## Models
The models for the return objects can be found in the models folder for each of the apis.
The model from the database looks like this
```cs
public class Game
    {
        public ObjectId _id { get; set; }
        //The main class. Contains all the information about a Steam game. Data is pulled from Steam Store, Steamspy and Steam Store Api.
        //The data is stored in JSON like format in the database. A game can be retrieved by its AppId from the database.
        //Note: All games have 2 id's. One is the Steam App Id, the other is the Id givin by the Database. Use the Steam App Id in most cases.
        public string Title { get; set; }
        public List<string> Developer { get;  set; }

        //Note: The developer and publisher can be the same. Ex: Valve
        public List<string> Publisher { get;  set; }

        //Note these Id's have varying length.
        public int SteamAppId { get;  set; }
        
        public string Description { get; set; }

        public bool Released { get; set; }
        public string ReleaseDate { get;  set; }
        public int AveragePlayTime { get;  set; }
        public int AveragePlayTime2Weeks { get;  set; }

        //Need user rating (is it int or string?)
        //The Steam store has is_free = true if game is free. This is translated to Price = 0.
        //Steam Store Api provides the price as an Int like 999 which translates to 9.99. Convetions is handled on insert.
        //Price does not include discounts as of now!
        public double Price { get;  set; }
        public int AgeRating { get;  set; }
        public Uri CoverImage { get;  set; }
        public Uri StoreLink { get;  set; }

        //Genre is not the same as Catagory. Genre contains "Action". Catagory contains "Multiplayer"
        public List<SteamStoreGame.Genre> Genres { get;  set; }
        public List<SteamStoreGame.Category> Categories { get;  set; }

        public List<SteamStoreGame.Tag> Tags { get; set; }

        public int OwnerCount { get;  set; }
        public bool Windows { get; set; }
        public bool Mac { get; set; }
        public bool Linux { get; set; }

    }
```

The Steam Game model can be found at lib/steamStore/models. 

# Database library
This solution contains a library for working with a [MongoDB](https://www.mongodb.org/) database. 
## Set up
To use the database library, simply add the refrence for the Database.dll found at /Database/bin/Debug
1. Install [MongoDB](https://www.mongodb.org/downloads#production) for your platform.
2. A setup guide for Windows can be found [here](https://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/).
3. To use the library and the database provided, specify the path to the folder containing the data.
Assuming your dir is at C:\Source\
```
C:\mongodb\bin\mongod.exe --dbpath C:\Source\SteamSharp\Database\data
```
You can check if the database is working by running mongo.exe. Mongo is found in the installation folder together with mongod.exe
```
//Run these in mongo.exe
use SteamSharp
//This returns the games count the the collection Games
db.Games.count()
```
##Usage
To find games from the database, you must specify a filter. This requires you to use the MongoDB.Driver which is a NuGet package.
```cs
//Add a filter
//This filter finds games where the SteamAppid is equal to the id provided by the user.
var filter = Builders<Game>.Filter.Eq("SteamAppId", providedId);
//Then run the database function using the filter
Dictionary<int, Game> gamesList = FindGameByFilter(string[] steamAppIds, filter);

//Some general methods have been made for simple tasks like the one above.
//This returns a dictionary of the games with the matching ids.
Dictionary<int, Game> gamesList = FindGameById(string[] steamAppIds);
```

