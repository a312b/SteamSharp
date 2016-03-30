using System;
using RestSharp;
using SteamSharp.restsharp;
using SteamSharp.steamUser.models;

namespace SteamSharp.steamUser
{
    internal class SteamApi : RestRequestBase
    {
        //Key used for most requests to the server
        //Generate/retrieve one here: http://steamcommunity.com/dev/apikey
        public string SteamDelveoperKey { private get; set; }

        public SteamApi(string key)
        {
            SteamDelveoperKey = key;
            BaseUrl = " http://api.steampowered.com/";
        }
        public SteamUser GetSteamUserData(string[] steamUserIds)
        {
            var idString = String.Join(",", steamUserIds); //Convert to a comma seperated string (This is the format required by the api)
            var request = new RestRequest {Resource = "ISteamUser/GetPlayerSummaries/v0002/" };
            request.AddParameter("key", SteamDelveoperKey, ParameterType.QueryString);
            request.AddParameter("steamids", idString, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json; //Set the format that we want the api to return. JSON is default for steam, but it never hurts
            request.RootElement = "response";

            return Execute<SteamUser>(request);

        }

        public UserGameTime GetGameTimeForUserById(string steamUserId)
        {
            var request = new RestRequest { Resource = "IPlayerService/GetOwnedGames/v0001/" };
            request.AddParameter("key", SteamDelveoperKey, ParameterType.QueryString);
            request.AddParameter("steamid", steamUserId, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json; //Set the format that we want the api to return. JSON is default for steam, but it never hurts
            request.RootElement = "response";

            return Execute<UserGameTime>(request);
        }
        
    }
}
