using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;


namespace core_ztzbx.Server
{
    public class ServerMain : BaseScript
    {
        PlayerAuth auth = new PlayerAuth();
        Player player = new Player();

        public ServerMain()
        {
            Exports.Add("login", new Action<int, IEnumerable<string>>(Login));
            Exports.Add("register", new Action<int, IEnumerable<string>>(Login));
            Exports.Add("playerToken", new Func<int, string>(PlayerToken));
        }

        public string PlayerToken(int source)
        {
            if (PlayersMetadata.token.ContainsKey(source))
            {
                return PlayersMetadata.token[source];
            }
            else
            {
                TriggerClientEvent(Players[source], "sendOnUserChat", $"You need to login.");
                return "";
            }
        }

        public void Login(int source, dynamic args)
        {
            if (!PlayersMetadata.token.ContainsKey(source))
            {
                if (args.Count == 2)
                {
                    string username = args[0].ToString();
                    string password = args[1].ToString();

                    if (auth.Login(username, password))
                    {
                        string userKey = UserTokenGenerator.Get();
                        player.UpdateToken(userKey, username);
                        PlayersMetadata.token.Add(source, userKey);
                        TriggerClientEvent(Players[source], "changeToken", userKey);
                        TriggerClientEvent(Players[source], "sendOnUserChat", $"Welcome to <Server_name> {Players[source].Name}");
                    }
                    else
                    {
                        TriggerClientEvent(Players[source], "sendOnUserChat", "The username or password is wrong");
                    }
                }
                else
                {
                    TriggerClientEvent(Players[source], "sendOnUserChat", "/login <username> <password>");
                }
            }
            else
            {
                TriggerClientEvent(Players[source], "sendOnUserChat", "You cant login if you are already logged");
            }
        }

        public void Register(int source, dynamic args)
        {
            if (!PlayersMetadata.token.ContainsKey(source))
            {
                if (args.Count == 2)
                {
                    string username = args[0].ToString();
                    string password = args[1].ToString();

                    if (password.Length > 5)
                    {
                        if (!auth.Exists(username))
                        {
                            string userKey = UserTokenGenerator.Get();
                            auth.Register(userKey, username, password, "user");
                            PlayersMetadata.token.Add(source, userKey);
                            TriggerClientEvent(Players[source], "changeToken", userKey);
                        }
                        else
                        {
                            TriggerClientEvent(Players[source], "sendOnUserChat", "The username is already exists");
                        }
                    }
                    else
                    {
                        TriggerClientEvent(Players[source], "sendOnUserChat", "The password is to short");
                    }
                }
                else
                {
                    TriggerClientEvent(Players[source], "sendOnUserChat", "/login <username> <password>");
                }

            }
            else
            {
                TriggerClientEvent(Players[source], "sendOnUserChat", "You register cant if you are logged");
            }
        }


        [Command("login")]
        public void LoginCommand(int source, List<object> args, string raw) { Login(source, args); }


        [Command("register")]
        public void RegisterCommand(int source, List<object> args, string raw) { Register(source, args); }
    }
}