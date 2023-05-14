namespace POC_SpotifyIntegrationShared
{
    public class SimplifiedPlaylist
    {
        public string Id { get; set; }
        public bool Collaborative { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ExternalUrl External_Urls { get; set; }
        public string Href { get; set; }
        public List<Image> Images { get; set; }
        public Owner Owner { get; set; }
        public string Primary_Color { get; set; }
        public bool Public { get; set; }
        public string Snapshot_Id { get; set; }
        public SimplifiedPlaylistTracks Tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class SimplifiedPlaylistTracks
    {
        public string Href { get; set; }
        public int Total { get; set; }
    }
}