using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.MessagePack
{
    /// <summary>
    /// Wraps MessagePack Javascript library<br/>
    /// https://github.com/msgpack/msgpack-javascript
    /// </summary>
    public static class MessagePack
    {
        static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        static Task? _Init = null;
        /// <summary>
        /// Load the SimplePeer Javascript library
        /// </summary>
        /// <returns>Returns when the library has been loaded</returns>
        public static Task Init(string? libPath = null)
        {
            _Init ??= JS.LoadScript(libPath ?? "_content/SpawnDev.BlazorJS.MessagePack/msgpack.min.js", nameof(MessagePack));
            return _Init;
        }
        /// <summary>
        /// It encodes data into a single MessagePack-encoded object, and returns a byte array as Uint8Array. It throws errors if data is, or includes, a non-serializable object such as a function or a symbol.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Uint8Array Encode(object data) => JS.Call<Uint8Array>("MessagePack.encode", data);
        /// <summary>
        /// It encodes data into a single MessagePack-encoded object, and returns a byte array as Uint8Array. It throws errors if data is, or includes, a non-serializable object such as a function or a symbol.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] EncodeToBytes(object data) => JS.Call<Uint8Array>("MessagePack.encode", data).Using(o => o.ReadBytes());
        /// <summary>
        /// It decodes buffer that includes a MessagePack-encoded object, and returns the decoded object typed T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Decode<T>(Uint8Array data) => JS.Call<T>("MessagePack.decode", data);
        /// <summary>
        /// It decodes buffer that includes a MessagePack-encoded object, and returns the decoded object typed unknown.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static JSObject Decode(Uint8Array data) => Decode<JSObject>(data);
        /// <summary>
        /// It decodes buffer that includes a MessagePack-encoded object, and returns the decoded object typed T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Decode<T>(byte[] data) => JS.Call<T>("MessagePack.decode", data);
        /// <summary>
        /// It decodes buffer that includes a MessagePack-encoded object, and returns the decoded object typed unknown.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static JSObject Decode(byte[] data) => Decode<JSObject>(data);
    }
}
