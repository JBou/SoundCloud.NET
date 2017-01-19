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
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SoundCloud.NET
{
    /// <summary>
    /// Connections represent the external profiles (like twitter, tumblr or facebook profiles and pages) that are connected to a SoundCloud user. The connection ids can be used to share tracks and playlists to social network.
    /// </summary>
    public class Connection : SoundCloudClient
    {
        #region Properties

        /// <summary>
        /// Gets or sets the connection id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the connection.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        private string creationDate;
        /// <summary>
        /// Gets or sets the connection creation date.
        /// </summary>
        public DateTime CreationDate { get { return (DateTime.Parse(creationDate)); } set { creationDate = value.ToString(); } }

        /// <summary>
        /// Gets or sets the connection service.
        /// </summary>
        /// 
        /// <remarks>Service is one of the social networks supported by the sound cloud plateform.</remarks>
        [JsonProperty(PropertyName = "service")]
        public string Service { get; set; }
        
        /// <summary>
        /// Gets or sets the connection type. <seealso cref="ConnectionType"/>.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets whether a new favorite will be published to the connection or not.
        /// </summary>
        [JsonProperty(PropertyName = "post_favorite")]
        public bool PostFavorite { get; set; }

        /// <summary>
        /// Gets or sets whether a new post will be published to the connection or not.
        /// </summary>
        [JsonProperty(PropertyName = "post_publish")]
        public bool PostPublish { get; set; }

        /// <summary>
        /// Gets the connection uri.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public Uri Uri { get; set; }

        #endregion Properties

        #region Shared Methods

        /// <summary>
        /// Retrieves connections for the authenticated user.
        /// </summary>
        public static List<Connection> MyConnections()
        {
            return SoundCloudApi.ApiAction<List<Connection>>(ApiCommand.MeConnections);
        }

        #endregion Shared Methods
    }
}