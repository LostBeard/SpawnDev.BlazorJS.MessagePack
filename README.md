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

// Load the MessagePack Javascript library at startup (optional)
// Could also be done in component or a service as needed.
await MessagePack.Init();

// Run app using BlazorJSRunAsync
await builder.Build().BlazorJSRunAsync();
```


Example Home.razor  
```cs
@page "/"
@using SpawnDev.BlazorJS.JSObjects

<PageTitle>SpawnDev.BlazorJS.MessagePack</PageTitle>

<h1>SpawnDev.BlazorJS.MessagePack</h1>

<p>
    This demo converts text to binary using MessagePack Javascript library and SpawnDev.BlazorJS.MessagePack
</p>

<div>
    <textarea style="width: 600px; word-wrap: break-word; white-space: normal;" @bind=@incoming></textarea>
    <button @onclick=@Submit>Pack</button>
</div>
<div>
    <pre style="width: 600px; word-wrap: break-word; white-space: normal;">@((MarkupString)outgoing)</pre>
</div>
<div>
    <pre style="width: 600px; word-wrap: break-word; white-space: normal;">@((MarkupString)readback)</pre>
</div>

@code {
    string outgoing = "";
    string incoming = "";
    string readback = "";

    void Submit()
    {
        // encode using MessagePack to a Uint8Array
        using Uint8Array uint8Array = MessagePack.Encode(incoming);
        // the Uint8Array could now be sent over WebRTC, saved to file, etc.
        // for this demo we are converting to hex and displaying it
        var bytes = uint8Array.ReadBytes();
        outgoing = Convert.ToHexString(bytes);
        // demo decode
        readback = MessagePack.Decode<string>(uint8Array);
    }
}
```
