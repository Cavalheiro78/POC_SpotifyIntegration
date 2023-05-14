using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_SpotifyIntegrationShared
{
    public class Playlist
    {
        public bool Collaborative { get; set; }
        public string Description { get; set; }
        public ExternalUrl External_Urls { get; set; }
        public Followers Followers { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public string Primary_Color { get; set; }
        public bool Public { get; set; }
        public string Snapshot_Id { get; set; }
        public Tracks Tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class Tracks 
    {
        public string Href { get; set; }
        public List<PlaylistTrack> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public string Previous { get; set; }
        public int Total { get; set; }
    }

    public class PlaylistTrack
    {
        public string Added_At { get; set; }
        public AddedBy Added_By { get; set; }
        public bool Is_Local { get; set; }
        public string Primary_Color { get; set; }
        public Track Track { get; set; }
        public VideoThumbnail Video_Thumbnail { get; set; }
    }

    public class AddedBy
    {
        public ExternalUrl External_Urls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class VideoThumbnail
    {
        public string Url { get; set; }
    }

    public class Followers
    {
        public string Href { get; set; }
        public int Total { get; set; }
    }
}
