# SpawnDev.BlazorJS.MessagePack
MessagePack binary Javascript encoder and decoder.

[![NuGet version](https://badge.fury.io/nu/SpawnDev.BlazorJS.MessagePack.svg?label=SpawnDev.BlazorJS.MessagePack)](https://www.nuget.org/packages/SpawnDev.BlazorJS.MessagePack)

**SpawnDev.BlazorJS.MessagePack** brings the amazing [MessagePack](https://github.com/msgpack/msgpack-javascript) library to Blazor WebAssembly.

**SpawnDev.BlazorJS.MessagePack** uses [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS) for Javascript interop allowing strongly typed, full usage of the [MessagePack](https://github.com/msgpack/msgpack-javascript) Javascript library. Voice, video and data channels are all fully supported in Blazor WebAssembly. The **SpawnDev.BlazorJS.MessagePack** API is a strongly typed version of the API found at the [MessagePack](https://github.com/msgpack/msgpack-javascript) repo. 

### Demo
[Basic Demo](https://lostbeard.github.io/SpawnDev.BlazorJS.MessagePack/)

### Getting started

Add the Nuget package `SpawnDev.BlazorJS.MessagePack` to your project using your package manager of choice.  
```nuget
nuget install SpawnDev.BlazorJS.MessagePack
```

Modify the Blazor WASM `Program.cs` to initialize SpawnDev.BlazorJS for Javascript interop.  
Example Program.cs   
```cs
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

// Run app using BlazorJSRunAsync extension method
await builder.Build().BlazorJSRunAsync();
```
