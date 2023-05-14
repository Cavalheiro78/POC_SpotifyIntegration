using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_SpotifyIntegrationShared
{
    public class Track
    {
        public Album Album { get; set; }
        public List<Artist> Artists { get; set; }
        public List<string> Available_Markets { get; set; }
        public int Disc_Number { get; set; }
        public int Duration_Ms { get; set; }
        public bool Explicit { get; set; }
        public ExternalIds External_Ids { get; set; }
        public ExternalUrl External_Urls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public bool Is_Local { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Preview_Url { get; set; }
        public int Track_Number { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }

    }

    public class Album
    {
        public string Album_Group { get; set; }
        public string Album_Type { get; set; }
        public List<Artist> Artists { get;}
        public List<string> Available_Markets { get;}
        public ExternalUrl External_Urls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public string Release_Date { get; set; }
        public string Release_Date_Precision { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class Artist
    {
        public ExternalUrl External_Urls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
