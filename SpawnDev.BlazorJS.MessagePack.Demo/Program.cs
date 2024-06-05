using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.MessagePack;
using SpawnDev.BlazorJS.MessagePack.Demo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add SpawnDev.BlazorJS interop
builder.Services.AddBlazorJSRuntime();

// Load the MessagePack Javascript library at startup (optional)
// Could also be done in component or a service as needed.
await MessagePack.Init();

// Run app using BlazorJSRunAsync
await builder.Build().BlazorJSRunAsync();
