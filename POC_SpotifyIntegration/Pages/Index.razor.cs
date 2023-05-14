using Microsoft.AspNetCore.Components;
using POC_SpotifyIntegration.Services;
using POC_SpotifyIntegrationShared;

namespace POC_SpotifyIntegration.Pages
{
    public partial class Index
    {
        [Inject]
        public Token Token { get; set; }
        [Inject]
        public ISpotifyDataService SpotifyDataService { get; set; }
        [Inject]
        public ITokenDataService TokenDataService { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }
        public PlaylistPage PlaylistPage { get; set; }
        public string UserId { get; set; }
        public int Offset { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Offset = 0;
        }

        async Task GetPlaylists()
        {
            await GetTokenAsync();
            if (Token.Access_Token == null)
                await GetTokenAsync();

            PlaylistPage = await SpotifyDataService.GetUsersPlaylists(UserId, Token.Access_Token);

            if (PlaylistPage == null)
            {
                await GetTokenAsync();
                PlaylistPage = await SpotifyDataService.GetUsersPlaylists(UserId, Token.Access_Token);
            }
        }
        
        async Task GetTokenAsync()
        {
            Token = await TokenDataService.GetAccessToken(Configuration["ClientId"], Configuration["ClientSecret"]);
        }

        async Task PreviousPlaylists()
        {
            if (Offset != 0)
            {
                Offset = Offset - 20;

                PlaylistPage = await SpotifyDataService.GetUsersPlaylists(UserId, Token.Access_Token);

                if (PlaylistPage == null)
                {
                    await GetTokenAsync();
                    PlaylistPage = await SpotifyDataService.GetUsersPlaylists(UserId, Token.Access_Token);
                }
            }

        }
        async Task NextPlaylists()
        {
            if (PlaylistPage.Total > 20 && PlaylistPage.Items.Count() == 20)
            {
                Offset = Offset + 20;

                PlaylistPage = await SpotifyDataService.Get20Playlists(UserId, Offset, Token.Access_Token);

                if (PlaylistPage == null)
                {
                    await GetTokenAsync();
                    PlaylistPage = await SpotifyDataService.Get20Playlists(UserId, Offset, Token.Access_Token);
                }

            }
        }
    }
}
