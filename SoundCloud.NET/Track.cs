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
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SoundCloud.NET
{
    /// <summary>
    ///   SoundCloud track.
    /// </summary>
    public class Track
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        private string _CreationDate;

        public DateTime CreationDate
        {
            get { return (DateTime.Parse(_CreationDate)); }
            set { _CreationDate = value.ToString(CultureInfo.InvariantCulture); }
        }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "commentable")]
        public bool Commentable { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        public string Sharing { get; set; }

        [JsonProperty(PropertyName = "tag_list")]
        public string TagList { get; set; }

        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "streamable")]
        public bool Streamable { get; set; }

        [JsonProperty(PropertyName = "downloadable")]
        public bool Downloadable { get; set; }

        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "release")]
        public string Release { get; set; }

        [JsonProperty(PropertyName = "purchase_url")]
        public string PurchaseUrl { get; set; }

        [JsonProperty(PropertyName = "label_id")]
        public string LabelId { get; set; }

        [JsonProperty(PropertyName = "label_name")]
        public string LabelName { get; set; }

        [JsonProperty(PropertyName = "isrc")]
        public string Isrc { get; set; }

        [JsonProperty(PropertyName = "video_url")]
        public string VideoUrl { get; set; }

        [JsonProperty(PropertyName = "track_type")]
        public string TrackType { get; set; }

        [JsonProperty(PropertyName = "key_signature")]
        public string KeySignature { get; set; }

        [JsonProperty(PropertyName = "bpm")]
        public string Bpm { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "release_year")]
        public string ReleaseYear { get; set; }

        [JsonProperty(PropertyName = "release_month")]
        public string ReleaseMonth { get; set; }

        [JsonProperty(PropertyName = "release_day")]
        public string ReleaseDay { get; set; }

        [JsonProperty(PropertyName = "original_format")]
        public string OriginalFormat { get; set; }

        [JsonProperty(PropertyName = "license")]
        public string License { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "artwork_url")]
        public string Artwork { get; set; }

        [JsonProperty(PropertyName = "waveform_url")]
        public string WaveForm { get; set; }

        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        [JsonProperty(PropertyName = "stream_url")]
        public string StreamUrl { get; set; }

        [JsonProperty(PropertyName = "download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty(PropertyName = "downloads_remaining")]
        public int DownloadsRemaining { get; set; }

        [JsonProperty(PropertyName = "secret_token")]
        public string SecretToken { get; set; }

        [JsonProperty(PropertyName = "secret_uri")]
        public string SecretUri { get; set; }

        [JsonProperty(PropertyName = "user_playback_count")]
        public int UserPlaybackCount { get; set; }

        [JsonProperty(PropertyName = "user_favorite")]
        public bool UserFavorite { get; set; }

        [JsonProperty(PropertyName = "playback_count")]
        public int PlaybackCount { get; set; }

        [JsonProperty(PropertyName = "download_count")]
        public int DownloadCount { get; set; }

        [JsonProperty(PropertyName = "favoritings_count")]
        public int FavoritingsCount { get; set; }

        [JsonProperty(PropertyName = "comment_count")]
        public int CommentsCount { get; set; }

        [JsonProperty(PropertyName = "attachments_uri")]
        public string AttachmentUri { get; set; }

        #endregion Properties

        #region Shared Methods

        /// <summary>
        ///   Returns a collection of tracks uploaded by logged-in user.
        /// </summary>
        public static List<Track> MyTacks()
        {
            return SoundCloudApi.ApiAction<List<Track>>(ApiCommand.MeTracks);
        }

        /// <summary>
        ///   Returns a collection of tracks.
        /// </summary>
        public static List<Track> GetTracks()
        {
            return SoundCloudApi.ApiAction<List<Track>>(ApiCommand.Tracks);
        }

        /// <summary>
        ///   Returns a track by track id.
        /// </summary>
        /// <param name="id"> Track id. </param>
        public static Track GetTrack(int id)
        {
            return SoundCloudApi.ApiAction<Track>(ApiCommand.Track, id);
        }

        /// <summary>
        ///   Returns a collection of tracks after filtering.
        /// </summary>
        /// <param name="term"> </param>
        /// <param name="tags"> </param>
        /// <param name="filter"> </param>
        /// <param name="license"> </param>
        /// <param name="order"> </param>
        /// <param name="bpmFrom"> </param>
        /// <param name="bpmTo"> </param>
        /// <param name="durationFrom"> </param>
        /// <param name="durationTo"> </param>
        /// <param name="from"> </param>
        /// <param name="to"> </param>
        /// <param name="ids"> </param>
        /// <param name="genres"> </param>
        /// <param name="types"> </param>
        public static List<Track> Search(string term, string[] tags, Filter filter, string license, string order,
                                         int? bpmFrom, int? bpmTo, int? durationFrom, int? durationTo, DateTime from,
                                         DateTime to, int[] ids, string[] genres, string[] types, int offset = 0, int limit = 100)
        {
            var filters = new Dictionary<string, object>();

            if (term != null)
            {
                filters.Add("q", term);
            }
            if (tags != null && tags.Length > 0)
            {
                filters.Add("tags", String.Join(",", tags));
            }

            filters.Add("filter", filter.ToString().ToLower());

            if (license != null)
            {
                filters.Add("license", license);
            }
            if (order != null)
            {
                filters.Add("order", order);
            }
            if (bpmFrom != null && bpmTo != null)
            {
                filters.Add("bpm[from]", bpmFrom);
                filters.Add("bpm[to]", bpmTo);
            }
            if (durationFrom != null && durationTo != null)
            {
                filters.Add("duration[from]", durationFrom);
                filters.Add("duration[to]", durationTo);
            }
            if (from != null && to != null)
            {
                filters.Add("created_at[from]", from.ToString("yyyy/MM/dd hh:mm:ss"));
                filters.Add("created_at[to]", to.ToString("yyyy/MM/dd hh:mm:ss"));
            }
            if (ids != null && ids.Length > 0)
            {
                filters.Add("ids", String.Join(",", ids));

            }
            if (genres != null && genres.Length > 0)
            {
                filters.Add("genres", String.Join(",", genres));
            }
            if (types != null && types.Length > 0)
            {
                filters.Add("types", String.Join(",", types));
            }
            if (offset > 0)
            {
                filters.Add("offset", offset > 8000 ? 8000 : offset);
            }
            if (limit > 0)
            {
                filters.Add("limit", limit > 200 ? 200 : limit);
            }
            return SoundCloudApi.ApiAction<List<Track>>(ApiCommand.Tracks, filters);
        }

        #endregion

        /// <summary>
        ///   Upload a track to sound cloud.
        /// </summary>
        /// <remarks>
        ///   To upload a track, you have to specify the following properties :
        ///   * Uri : the path of the file on your computer.
        ///   * Title : title of the track.
        ///   * Description : a brief description of the track.
        ///   * Sharing : public or private.
        /// </remarks>
        public void Add()
        {
            if (Uri != null && Title != null && Description != null && Sharing != null)
            {
                if (File.Exists(Path.GetFullPath(Uri)))
                {
                    var parameters = new Dictionary<string, object>
                                         {
                                             {"track[asset_data]", Path.GetFullPath(Uri)},
                                             {"track[title]", Title},
                                             {"track[description]", Description},
                                             {"track[sharing]", Sharing}
                                         };

                    SoundCloudApi.ApiAction<Track>(ApiCommand.Tracks, HttpMethod.Post, parameters);
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        ///   Deletes a given track.
        /// </summary>
        /// <remarks>
        ///   To delete a track, you have to be the owner or you have permission to delete it.
        /// </remarks>
        public void Delete()
        {
            SoundCloudApi.ApiAction<Track>(ApiCommand.Track, HttpMethod.Delete, Id);
        }

        /// <summary>
        /// Returns comments of a track by track id.
        /// </summary>
        /// <returns></returns>
        public List<Comment> GetComments()
        {
            return SoundCloudApi.ApiAction<List<Comment>>(ApiCommand.TrackComments, Id);
        }

        /// <summary>
        /// Returns all users with permission for a track by track id.
        /// </summary>
        /// <returns></returns>
        public List<User> GetPermissions()
        {
            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.TrackPermissions, Id);
        }

        /// <summary>
        /// Adds the given track to the logged-in user's list of favorites.
        /// </summary>
        public void AddToFavorites()
        {
            SoundCloudApi.ApiAction<Track>(ApiCommand.MeFavoritesTrack, HttpMethod.Put, Id);
        }

        /// <summary>
        ///   Deletes the given track from the logged-in user's list of favorites.
        /// </summary>
        public void RemoveFromFavorites()
        {
            SoundCloudApi.ApiAction<Track>(ApiCommand.MeFavoritesTrack, HttpMethod.Delete, Id);
        }

        /// <summary>
        ///   Share a track to a social network.
        /// </summary>
        /// <param name="connection"> Registered social profile on sound cloud. </param>
        public void Share(Connection connection)
        {
            Share(connection, null);
        }

        /// <summary>
        ///   Share a track to a social network.
        /// </summary>
        /// <param name="connection"> Registered social profile on sound cloud. </param>
        /// <param name="sharingNote"> String that will be used as status message. This string might be truncated by SoundCloud. </param>
        public void Share(Connection connection, string sharingNote)
        {
            var parameters = new Dictionary<string, object> { { "connections[][id]", connection.Id } };

            if (sharingNote != null) parameters.Add("sharing_note", sharingNote);

            SoundCloudApi.ApiAction<Track>(ApiCommand.TrackShare, HttpMethod.Post, parameters, Id);
        }
    }
}