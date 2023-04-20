using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace core_ztzbx.Server
{
    public class ServerMain : BaseScript
    {
        PlayerAuth auth = new PlayerAuth();
        PlayerActions playerAction = new PlayerActions();

        YamlConfig secretPlayer = new YamlConfig("Config.Yaml");

        public ServerMain()
        {
            Exports.Add("login", new Func<int, IEnumerable<string>, string>(Login));
            Exports.Add("register", new Func<int, IEnumerable<string>, string>(Register));
            Exports.Add("playerToken", new Func<int, string>(PlayerToken));
            Exports.Add("playerAdmin", new Func<string, bool>(PlayerAdmin));
            Exports.Add("getPlayersUsernames", new Func<IEnumerable<string>>(GetPlayersUsernames));
            EventHandlers["banPlayer"] += new Action<Player, string>(BanPlayer);
            EventHandlers["playerDropped"] += new Action<Player, string>(OnPlayerDropped);

        }

        private void BanPlayer([FromSource] Player player, string username)
        {
            if (auth.IsAdmin(PlayersMetadata.token[player]))
            {
                Player bannedPlayer = PlayersMetadata.playerUsername.FirstOrDefault(x => x.Value == username).Key;
                if (player != bannedPlayer)
                {
                    playerAction.BanPlayer(PlayersMetadata.token[bannedPlayer]);
                    DropPlayer(bannedPlayer.Handle, $"Admin <{PlayersMetadata.playerUsername[player]}> just banned you!");
                }
            }
        }

        private IEnumerable<string> GetPlayersUsernames()
        {

            List<string> usernames = new List<string>();

            foreach (Player user in PlayersMetadata.onlinePlayers)
            {
                usernames.Add(PlayersMetadata.playerUsername[user]);
            }

            IEnumerable<string> result = usernames;
            return result;
        }


        private void OnPlayerDropped([FromSource] Player player, string reason)
        {
            Debug.WriteLine($"Player {PlayersMetadata.playerUsername[player]} dropped (Reason: {reason}).");
            PlayersMetadata.onlinePlayers.Remove(player);
            PlayersMetadata.playerUsername.Remove(player);

        }

        public bool PlayerAdmin(string userToken)
        {
            return auth.IsAdmin(userToken);
        }

        public string PlayerToken(int source)
        {
            if (PlayersMetadata.token.ContainsKey(Players[source]))
            {
                return PlayersMetadata.token[Players[source]];
            }
            else
            {
                TriggerClientEvent(Players[source], "sendOnUserChat", $"You need to login.");
                return "";
            }
        }

        public string Login(int source, dynamic args)
        {

            if (args.Count == 2)
            {
                string username = args[0].ToString();
                string password = args[1].ToString();

                if (!auth.Login(username, password)) { return Exports["language"].user_wrong(); }

                if (auth.IsBanned(username)) { return Exports["language"].banned_message(); }

                if (PlayersMetadata.onlinePlayers.Contains(Players[source])) { return Exports["language"].already_logged(); }

                string userKey = UserTokenGenerator.Get();
                playerAction.UpdateToken(userKey, username);

                if (PlayersMetadata.token.ContainsKey(Players[source]))
                {
                    PlayersMetadata.token.Remove(Players[source]);
                    PlayersMetadata.token.Add(Players[source], userKey);
                }
                else
                {
                    PlayersMetadata.token.Add(Players[source], userKey);
                }

                TriggerClientEvent(Players[source], "changeToken", userKey);
                PlayersMetadata.playerUsername.Add(Players[source], username);
                PlayersMetadata.onlinePlayers.Add(Players[source]);
                return "OK";

            }
            else
            {
                return Exports["language"].user_parameters_login_error();
            }
        }


        public string Register(int source, dynamic args)
        {

            if (args.Count == 3)
            {
                string username = args[0].ToString();
                string password = args[1].ToString();
                string email = args[2].ToString();

                if (!EmailValidator.IsValidEmail(email)) { return Exports["language"].not_valid_email(); }
                if (username.Length > 20){ return Exports["language"].user_to_large(); }
                if (auth.UsernameExists(username)) { return Exports["language"].user_exists(); }
                if (auth.EmailExists(email)) { return Exports["language"].email_exists(); }
                if (password.Length < 5) { return Exports["language"].password_to_short(); }

                string encryptedpassword = StringCipher.Encrypt(password, secretPlayer.data.secret);

                string userKey = UserTokenGenerator.Get();
                auth.Register(userKey, username, encryptedpassword, "user", email);

                if (PlayersMetadata.token.ContainsKey(Players[source]))
                {
                    PlayersMetadata.token.Remove(Players[source]);
                    PlayersMetadata.token.Add(Players[source], userKey);
                }
                else
                {
                    PlayersMetadata.token.Add(Players[source], userKey);
                }

                PlayersMetadata.playerUsername.Add(Players[source], username);
                PlayersMetadata.onlinePlayers.Add(Players[source]);
                TriggerClientEvent(Players[source], "changeToken", userKey);
                return "OK";

            }
            else
            {
                return Exports["language"].user_parameters_register_error();
            }

        }

    }
}
