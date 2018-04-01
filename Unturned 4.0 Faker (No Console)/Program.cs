using System;
using System.Runtime.InteropServices;

namespace testing
{
    class Program
    {
        public const string DLL = "discord-rpc.dll";

        static void Main(string[] args)
        {
            EventHandlers handlers = new EventHandlers();
            RichPresence presence = new RichPresence();

            Initialize("430037918317281280", ref handlers, true, null);

            presence.state = "Pineridge";
            presence.details = "In Game";
            presence.largeImageKey = "unturned";

            UpdatePresence(ref presence);

            Console.ReadLine();
        }

        public struct EventHandlers { }

        [Serializable]
        public struct RichPresence
        {
            public string state; /* max 128 bytes */
            public string details; /* max 128 bytes */
            public long startTimestamp;
            public long endTimestamp;
            public string largeImageKey; /* max 32 bytes */
            public string largeImageText; /* max 128 bytes */
            public string smallImageKey; /* max 32 bytes */
            public string smallImageText; /* max 128 bytes */
            public string partyId; /* max 128 bytes */
            public int partySize;
            public int partyMax;
            public string matchSecret; /* max 128 bytes */
            public string joinSecret; /* max 128 bytes */
            public string spectateSecret; /* max 128 bytes */
            public bool instance;
        }

        [DllImport(DLL, EntryPoint = "Discord_Initialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Initialize(string applicationId, ref EventHandlers handlers, bool autoRegister, string optionalSteamId);

        [DllImport(DLL, EntryPoint = "Discord_UpdatePresence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdatePresence(ref RichPresence presence);
    }
}
