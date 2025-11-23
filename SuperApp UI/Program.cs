using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using SuperApp_UI;
using SuperApp_UI.Services; // your custom service namespace
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl")
                 ?? "https://superapp-b9qu.onrender.com";   // ← CHANGE THIS TO YOUR REAL RENDER URL

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// ✅ Configure base API address
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("") });

// ✅ Add LocalStorage
builder.Services.AddBlazoredLocalStorage();

// ✅ Enable authorization support
builder.Services.AddAuthorizationCore();

// ✅ Register your custom authentication provider
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddSingleton<UserStateService>();

await builder.Build().RunAsync();
