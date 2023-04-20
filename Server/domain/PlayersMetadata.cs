using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Collections.Generic;

namespace core_ztzbx.Server
{
    static public class PlayersMetadata 
    {
        // firts value is the id of the concret user and the last is the string
        public static Dictionary<Player, string> token = new Dictionary<Player, string>();
        
        public static List<Player> onlinePlayers = new List<Player>();

        // The key is the handle of the user and the value is the username
        public static Dictionary<Player, string>  playerUsername = new Dictionary<Player, string>();
    }
}