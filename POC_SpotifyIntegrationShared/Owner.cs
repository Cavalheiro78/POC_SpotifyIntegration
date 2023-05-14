using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_SpotifyIntegrationShared
{
    public class Owner
    {
        public string Display_Name { get; set; }
        public ExternalUrl External_Urls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
