using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using POC_SpotifyIntegration;
using POC_SpotifyIntegration.Services;
using POC_SpotifyIntegrationShared;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

System.Diagnostics.Debug.WriteLine("#ffeswfesjifuhesg");

builder.Services.AddSingleton<Token>();
builder.Services.AddRefitClient<ISpotifyDataService>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.spotify.com"));
builder.Services.AddRefitClient<ITokenDataService>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://accounts.spotify.com"));

await builder.Build().RunAsync();
