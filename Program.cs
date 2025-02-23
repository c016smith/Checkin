using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Checkin;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMsalAuthentication(options =>
{
    var authentication = options.ProviderOptions.Authentication;
    builder.Configuration.Bind("AzureAd", authentication);
    
    options.ProviderOptions.DefaultAccessTokenScopes = 
        builder.Configuration.GetSection("MicrosoftGraph:Scopes")
            .Get<string[]>() ?? new[] { "User.Read.All", "User.ReadBasic.All" };
});

await builder.Build().RunAsync();
