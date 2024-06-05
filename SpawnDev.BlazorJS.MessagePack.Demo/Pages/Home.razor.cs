using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.MessagePack.Demo.Pages
{
    public partial class Home
    {
        string outgoing = "";
        string incoming = "";
        string readback = "";

        void Submit()
        {
            // encode to a Uint8Array using MessagePack
            using Uint8Array uint8Array = MessagePack.Encode(incoming);
            // the Uint8Array could now be sent over WebRTC, saved to file, etc.
            // for this demo we are converting to hex and displaying it
            var bytes = uint8Array.ReadBytes();
            outgoing = Convert.ToHexString(bytes);
            // decode to a string using MessagePack
            readback = MessagePack.Decode<string>(uint8Array);
        }
    }
}
