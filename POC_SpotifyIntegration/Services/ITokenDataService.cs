using POC_SpotifyIntegrationShared;
using Refit;

namespace POC_SpotifyIntegration.Services
{
    public interface ITokenDataService
    {   
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        [Post("/api/token?grant_type=client_credentials")]
        Task<Token> GetAccessToken([AliasAs("client_id")] string clientid, [AliasAs("client_secret")] string clientsecret);

        [Headers("Content-Type: application/x-www-form-urlencoded")]
        [Post("/api/token?grant_type=authorization_code")]
        Task<Token> GetAccessTokenThroughCode([AliasAs("code")] string code, [AliasAs("redirect_uri")] string redirecturi, [AliasAs("client_id")] string clientid, [AliasAs("client_secret")] string clientsecret);
    }
}
