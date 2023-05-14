using Microsoft.AspNetCore.Components;
using POC_SpotifyIntegration.Services;
using POC_SpotifyIntegrationShared;
using System;

namespace POC_SpotifyIntegration.Pages
{
    public partial class ClientAuthorization
    {
        [Inject]
        public NavigationManager Nav { get; set; }
        [Inject]
        public ISpotifyDataService SpotifyDataService { get; set; }
        [Inject]
        public ITokenDataService TokenDataService { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public Token Token { get; set; }
        public PlaylistPage PlaylistPage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            
        }

        public void requestAuth()
        {
            var url = "https://accounts.spotify.com/authorize?client_id=d79fc7cf634c4533a8d7a648e8212cda&response_type=code&redirect_uri=" + Nav.Uri
            + "&scope=playlist-read-private playlist-read-collaborative";

            Nav.NavigateTo(url);
        }


        async Task GetToken()
        {
            var code = Nav.Uri.Substring(Nav.Uri.LastIndexOf('=') + 1);
            Token = await TokenDataService.GetAccessTokenThroughCode(code, Nav.Uri.Substring(0, Nav.Uri.IndexOf("?", StringComparison.Ordinal)), Configuration["ClientId"], Configuration["ClientSecret"]);
            GetPlaylistAsync();
        }

        private async Task GetPlaylistAsync()
        {
            if(Token.Access_Token != null)
                PlaylistPage = await SpotifyDataService.GetCurrentUsersPlaylists(Token.Access_Token);
        }
    }
}
