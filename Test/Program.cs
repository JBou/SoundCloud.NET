using System;
using System.Collections.Generic;
using System.Linq;
using SoundCloud.NET;

namespace Test
{
    class Program
    {
        //Enter app credentials from here http://soundcloud.com/you/apps
        private const string ClientId = "client id";
        private const string ClientSecret = "client secret";
        //enter username and password a soundcloud user, e.g. your own credentials
        private const string Username = "username";
        private const string Password = "password";

        static void Main(string[] args)
        {

            //fill credentials
            SoundCloudCredentials credentials = new SoundCloudCredentials(ClientId, ClientSecret, Username, Password);
            //create client
            SoundCloudClient client = new SoundCloudClient(credentials);
            //login to soundcloud
            SoundCloudAccessToken token = client.Authenticate();
            
            //fetch some data
            if (client.IsAuthenticated)
            {
                //Fetch current user info
                var mySelf = User.Me();

                PartitionList<Track> likes = mySelf.GetFavorites();
                PartitionList<Playlist> playlists = mySelf.GetPlaylists();

                foreach (Track track in likes.Collection)
                {
                    Console.WriteLine(track.Title);
                }
                while (likes.GetNextPartition())
                {
                    foreach (Track track in likes.Collection)
                    {
                            Console.WriteLine(track.Title);
                    }
                }

            }
            //wait for user input
            Console.ReadLine();
        }
    }
}
