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
            // encode using MessagePack to a Uint8Array
            using Uint8Array uint8Array = MessagePack.Encode(incoming);
            // the Uint8Array could now be sent over WebRTC, saved to file, etc.
            // for this demo we are converting to hex and displaying it
            var bytes = uint8Array.ReadBytes();
            outgoing = Convert.ToHexString(bytes);
            // decode using MessagePack to a string
            readback = MessagePack.Decode<string>(uint8Array);
        }
    }
}
