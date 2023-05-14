using Microsoft.AspNetCore.Components;
using POC_SpotifyIntegration.Services;
using POC_SpotifyIntegrationShared;

namespace POC_SpotifyIntegration.Pages
{
    public partial class PlaylistDetails
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public Token Token { get; set; }
        [Inject]
        public ISpotifyDataService SpotifyDataService { get; set; }
        [Inject]
        public ITokenDataService TokenDataService { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        public Playlist Playlist { get; set; }
        public Tracks PlaylistTracks { get; set; }
        public int Offset { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetTokenAsync();
            Offset = 0;

            if (Id != null)
            {
                Playlist = await SpotifyDataService.GetPlaylist(Id, Token.Access_Token);

                if (Playlist == null)
                {
                    await GetTokenAsync();
                    Playlist = await SpotifyDataService.GetPlaylist(Id, Token.Access_Token);
                }
            }

            if (Playlist != null)
            {
                PlaylistTracks = Playlist.Tracks;
            }

        }

        async Task GetTokenAsync()
        {
            Token = await TokenDataService.GetAccessToken(Configuration["ClientId"], Configuration["ClientSecret"]);
        }

        async Task PreviousTracks()
        {
            if (Offset != 0)
            {
                Offset = Offset - 100;

                PlaylistTracks = await SpotifyDataService.Get100TracksInPlaylist(Id, Offset, Token.Access_Token);

                if (Playlist == null)
                {
                    await GetTokenAsync();
                    PlaylistTracks = await SpotifyDataService.Get100TracksInPlaylist(Id, Offset, Token.Access_Token);
                }
            }

        }
        async Task NextTracks()
        {
            if(PlaylistTracks.Total > 100 && PlaylistTracks.Items.Count() == 100)
            {
                Offset = Offset + 100;

                PlaylistTracks = await SpotifyDataService.Get100TracksInPlaylist(Id, Offset, Token.Access_Token);

                if (Playlist == null)
                {
                    await GetTokenAsync();
                    PlaylistTracks = await SpotifyDataService.Get100TracksInPlaylist(Id, Offset, Token.Access_Token);
                }

            }
        }
    }
}
