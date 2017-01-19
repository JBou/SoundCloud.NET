using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SoundCloud.NET
{

    public class PartitionList<T> : SoundCloudClient
    {
        [JsonProperty(PropertyName = "next_href")]
        public string NextHref { get; set; }

        [JsonProperty(PropertyName = "collection")]
        public List<T> Collection { get; set; }

        public Boolean GetNextPartition()
        {
            if (String.IsNullOrEmpty(NextHref))
            {
                NextHref = null;
                Collection = new List<T>();
                return false;
            }
            PartitionList<T> trackList = SoundCloudApi.ApiActionNextHref<PartitionList<T>>(NextHref);
            NextHref = trackList.NextHref;
            Collection = trackList.Collection;
            return true;
        }

    }
}