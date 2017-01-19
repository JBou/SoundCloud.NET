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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SoundCloud.NET
{
    public class Playlist : SoundCloudClient
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        private string _CreationDate;
        /// <summary>
        /// Gets or sets the comment's creation date.
        /// </summary>
        public DateTime CreationDate { get { return (DateTime.Parse(_CreationDate)); } set { _CreationDate = value.ToString(CultureInfo.InvariantCulture); } }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        public string Sharing { get; set; }

        [JsonProperty(PropertyName = "tag_list")]
        public string TagsList { get; set; }

        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "streamable")]
        public bool? Streamable { get; set; }

        [JsonProperty(PropertyName = "downloadable")]
        public bool? Downloadable { get; set; }

        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "release")]
        public string Release { get; set; }

        [JsonProperty(PropertyName = "purchase_url")]
        public string PurchaseUrl { get; set; }

        [JsonProperty(PropertyName = "label_id")]
        public int? LabelId { get; set; }

        [JsonProperty(PropertyName = "label_name")]
        public string LabelName { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "playlist_type")]
        public string PlaylistType { get; set; }

        [JsonProperty(PropertyName = "ean")]
        public string Ean { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "release_year")]
        public int? ReleaseYear { get; set; }

        [JsonProperty(PropertyName = "release_month")]
        public int? ReleaseMonth { get; set; }

        [JsonProperty(PropertyName = "release_day")]
        public int? ReleaseDay { get; set; }

        public DateTime RealeaseDate
        {
            get
            {
                if (ReleaseDay != null && ReleaseMonth != null && ReleaseYear != null)
                    return new DateTime((int)ReleaseYear, (int)ReleaseMonth, (int)ReleaseDay);

                return DateTime.MinValue;
            }
        }

        [JsonProperty(PropertyName = "license")]
        public string License { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        [JsonProperty(PropertyName = "tracks")]
        public List<Track> Tracks { get; set; }

        #endregion Public

        #region Shared Methods

        /// <summary>
        /// Returns a collection of playlists.
        /// </summary>
        public static List<Playlist> GetAllPlaylists()
        {
            return SoundCloudApi.ApiAction<List<Playlist>>(ApiCommand.Playlists);
        }

        /// <summary>
        /// Returns a playlist by playlist id.
        /// </summary>
        /// 
        /// <param name="id">Playlist id.</param>
        public static Playlist GetPlaylist(int id)
        {
            return SoundCloudApi.ApiAction<Playlist>(ApiCommand.Playlist, id);
        }

        #endregion Shared Methods
    }
}