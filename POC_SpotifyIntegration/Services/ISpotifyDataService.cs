using POC_SpotifyIntegrationShared;
using Refit;

namespace POC_SpotifyIntegration.Services
{
    public interface ISpotifyDataService
    {
        [Get("/v1/users/{**userid}/playlists")]
        Task<PlaylistPage> GetUsersPlaylists(string userid, [Authorize("Bearer")] string token);
        [Get("/v1/users/{**userid}/playlists?offset={offset}&limit=20")]
        Task<PlaylistPage> Get20Playlists(string userid, int offset, [Authorize("Bearer")] string token);

        [Get("/v1/playlists/{**playlistid}")]
        Task<Playlist> GetPlaylist(string playlistid, [Authorize("Bearer")] string token);

        [Get("/v1/playlists/{playlistid}/tracks?offset={offset}&limit=100")]
        Task<Tracks> Get100TracksInPlaylist(string playlistid, int offset, [Authorize("Bearer")] string token);

        [Get("/v1/tracks/{**trackid}")]
        Task<Track> GetTrack(string trackid, [Authorize("Bearer")] string token);


        [Get("/v1/me/playlists")]
        Task<PlaylistPage> GetCurrentUsersPlaylists([Authorize("Bearer")] string token);
    }
}
