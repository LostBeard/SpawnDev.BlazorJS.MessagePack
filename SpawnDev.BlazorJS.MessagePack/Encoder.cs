using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.MessagePack
{
    /// <summary>
    /// MessagePack.Encoder
    /// </summary>
    public class Encoder : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Encoder(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance of MessagePack.Encoder
        /// </summary>
        public Encoder() : base(JS.New("MessagePack.Encoder")) { }
        /// <summary>
        /// It encodes data into a single MessagePack-encoded object, and returns a byte array as Uint8Array. It throws errors if data is, or includes, a non-serializable object such as a function or a symbol.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Uint8Array Encode(object data) => JS.Call<Uint8Array>("MessagePack.encode", data);
    }
}
