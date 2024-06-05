using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.MessagePack
{
    /// <summary>
    /// MessagePack.Decoder
    /// </summary>
    public class Decoder : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Decoder(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance of MessagePack.Decoder
        /// </summary>
        public Decoder() : base(JS.New("MessagePack.Decoder")) { }
        /// <summary>
        /// It decodes buffer that includes a MessagePack-encoded object, and returns the decoded object typed unknown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Decode<T>(Uint8Array data) => JS.Call<T>("MessagePack.decode", data);
        /// <summary>
        /// It decodes buffer that includes a MessagePack-encoded object, and returns the decoded object typed unknown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Decode<T>(byte[] data) => JS.Call<T>("MessagePack.decode", data);
    }
}
