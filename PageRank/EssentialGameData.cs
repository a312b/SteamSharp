using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SteamSharp.steamStore.models;

namespace PageRank
{
    [Serializable]
    public class EssentialGameData
    {
        
        public string Name { get;  set; }
        public int GameID { get;  set; }
        public List<string> Developers { get; set; }
        public SteamStoreGame.ReleaseDate ReleaseDate { get; set; }
        public List<SteamStoreGame.Genre> Genres { get;  set; }
        public List<SteamStoreGame.Tag> Tags  { get;  set; }
        public SteamStoreGame.PriceOverview Price { get;  set; }
        public string DetailedDescription { get;  set; }
        public SteamStoreGame.Platforms SuppoertedPlatforms { get;  set; }
        public List<SteamStoreGame.Category> Category { get;  set; }
        public SteamStoreGame.Metacritic MetaCritic { get;  set; }
        public SteamStoreGame.Recommendations Recommendations { get;  set; }
        public bool IsFree { get;  set; }
        public EssentialGameData()
        { }

        
        public EssentialGameData(SteamStoreGame game)
        {
            Name = game.data.name;
            GameID = game.data.steam_appid;
            Developers = game.data.developers;
            ReleaseDate = game.data.release_date;
            Genres = game.data.genres;
            Tags = game.data.tags;
            Price = game.data.price_overview;
            DetailedDescription = game.data.detailed_description;
            SuppoertedPlatforms = game.data.platforms;
            Category = game.data.categories;
            MetaCritic = game.data.metacritic;
            Recommendations = game.data.recommendations;
            IsFree = game.data.is_free;

            RemoveHTML();
        }

        private void RemoveHTML()
        {
            string newName = "";
            string[] segments = DetailedDescription.Split('>');
            foreach (string segment in segments)
            {
                newName += segment.TakeWhile(ch => ch != '<')
                    .Aggregate("", (ch, current) => ch + current);
            }
            DetailedDescription = newName;
            //Regex.Replace(DetailedDescription, @"<[^>]*>", string.Empty).Trim('"');
        }
    }
}
