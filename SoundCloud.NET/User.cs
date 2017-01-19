/*
    SoundCloud.NET Library For Sound Cloud Api Management.
    Copyright (C) 2011 Haythem Tlili

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SoundCloud.NET
{
    /// <summary>
    /// SoundCloud user.
    /// </summary>
    public class User : SoundCloudClient
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "avatar_url")]
        public string Avatar { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "discogs_name")]
        public string Discogs { get; set; }

        [JsonProperty(PropertyName = "myspace_name")]
        public string Myspace { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "website_title")]
        public string WebsiteTitle { get; set; }

        [JsonProperty(PropertyName = "online")]
        public bool? IsOnline { get; set; }

        [JsonProperty(PropertyName = "track_count")]
        public int Tracks { get; set; }

        [JsonProperty(PropertyName = "playlist_count")]
        public int Playlists { get; set; }

        [JsonProperty(PropertyName = "followers_count")]
        public int Followers { get; set; }

        [JsonProperty(PropertyName = "followings_count")]
        public int Followings { get; set; }

        [JsonProperty(PropertyName = "public_favorites_count")]
        public int Favorites { get; set; }

        [JsonProperty(PropertyName = "plan")]
        public string Plan { get; set; }

        [JsonProperty(PropertyName = "private_tracks_count")]
        public int PrivateTracks { get; set; }

        [JsonProperty(PropertyName = "private_playlists_count")]
        public int PrivatePlaylists { get; set; }

        [JsonProperty(PropertyName = "primary_email_confirmed")]
        public bool EmailConfirmed { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Returns a collection of users the user with user id is following.
        /// </summary>
        public List<User> GetFollowings()
        {
            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.UserFollowings, Id);
        }

        /// <summary>
        /// Adds the user with the id contact_id to the givens user's list of contacts.
        /// </summary>
        /// 
        /// <param name="user">User to follow.</param>
        public void AddFollowing(User user)
        {
            AddFollowing(user.Id);
        }

        /// <summary>
        /// Adds the user with the id contact_id to the givens user's list of contacts.
        /// </summary>
        /// 
        /// <param name="id">User id to follow.</param>
        public void AddFollowing(int id)
        {
            SoundCloudApi.ApiAction<User>(ApiCommand.UserFollowingsContact, HttpMethod.Put, Id, id);
        }

        /// <summary>
        /// Removes the user with the id contact_id from the givens user's list of contacts.
        /// </summary>
        /// 
        /// <param name="user">User to remove.</param>
        public void RemoveFollowing(User user)
        {
            RemoveFollowing(user.Id);
        }

        /// <summary>
        /// Removes the user with the id contact_id from the givens user's list of contacts.
        /// </summary>
        /// 
        /// <param name="id">User id to remove.</param>
        public void RemoveFollowing(int id)
        {
            SoundCloudApi.ApiAction<User>(ApiCommand.UserFollowingsContact, HttpMethod.Delete, Id, id);
        }

        /// <summary>
        /// Returns a collection of users who follow the user with user id
        /// </summary>
        public List<User> GetFollowers()
        {
            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.UserFollowers, Id);
        }

        /// <summary>
        /// Returns a collection of tracks uploaded by user id.
        /// </summary>
        public List<Track> GetTracks()
        {
            return SoundCloudApi.ApiAction<List<Track>>(ApiCommand.UserTracks, Id);
        }

        /// <summary>
        /// Returns a collection of tracks favorited by the user with user id.
        /// </summary>
        public PartitionList<Track> GetFavorites()
        {
           return SoundCloudApi.ApiAction<PartitionList<Track>>(ApiCommand.UserFavorites, Id);
        }

        /// <summary>
        /// Returns a collection of groups joined by user with user id.
        /// </summary>
        public List<Group> GetGroups()
        {
            return SoundCloudApi.ApiAction<List<Group>>(ApiCommand.UserGroups, Id);
        }

        /// <summary>
        /// Returns a collection of playlists created by user with user id
        /// </summary>
        public PartitionList<Playlist> GetPlaylists()
        {
            return SoundCloudApi.ApiAction<PartitionList<Playlist>>(ApiCommand.UserPlaylists, Id);
        }

        #endregion Public Methods

        #region Shared Methods

        /// <summary>
        /// Returns a collection of users.
        /// </summary>
        public static List<User> GetAllUsers()
        {
            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.Users);
        }

        /// <summary>
        /// Returns a limited collection of users.
        /// </summary>
        /// 
        /// <param name="count">Users count.</param>
        public static List<User> GetUsers(int count)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("limit", count);

            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.Users, parameters);
        }

        /// <summary>
        /// Returns a user by user id.
        /// </summary>
        /// 
        /// <param name="id">User id.</param>
        public static User GetUser(int id)
        {
            return SoundCloudApi.ApiAction<User>(ApiCommand.User, id);
        }

        /// <summary>
        /// Returns the logged-in user.
        /// </summary>
        public static User Me()
        {
            return SoundCloudApi.ApiAction<User>(ApiCommand.Me);
        }

        /// <summary>
        /// Returns a collection of users based on a pattern.
        /// </summary>
        /// 
        /// <param name="term">a term to search for.</param>
        public static List<User> Search(string term)
        {
            var parameters = new Dictionary<string, object> { { "q", term } };

            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.Users, parameters);
        }

        #endregion Shared Methods
    }
}