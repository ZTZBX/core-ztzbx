using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;

namespace core_ztzbx.Server
{
    static public class PlayersMetadata 
    {
        // firts value is the id of the concret user and the last is the string
        public static Dictionary<int, string> token = new Dictionary<int, string>();

        // first value is the unique token and the last is a bool indicating if is admin
        public static Dictionary<string, bool> admin = new Dictionary<string, bool>();
        
        public static List<Player> onlinePlayers = new List<Player>();

        // The key is the handle of the user and the value is the username
        public static Dictionary<Player, string>  playerUsername = new Dictionary<Player, string>();
    }
}