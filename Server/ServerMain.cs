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
            Exports.Add("login", new Func<int, IEnumerable<string>, string>(Login));
            Exports.Add("register", new Func<int, IEnumerable<string>, string>(Register));
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

        public string Login(int source, dynamic args)
        {
            if (!PlayersMetadata.token.ContainsKey(source))
            {
                if (args.Count == 2)
                {
                    string username = args[0].ToString();
                    string password = args[1].ToString();

                    if (!auth.Login(username, password)) { return Exports["lenguaje"].user_wrong(); }

                    string userKey = UserTokenGenerator.Get();
                    player.UpdateToken(userKey, username);
                    PlayersMetadata.token.Add(source, userKey);
                    TriggerClientEvent(Players[source], "changeToken", userKey);
                    return "OK";

                }
                else
                {
                    return Exports["lenguaje"].user_parameters_login_error();
                }
            }
            else
            {
                return Exports["lenguaje"].already_logged();
            }
        }

        public string Register(int source, dynamic args)
        {
            if (!PlayersMetadata.token.ContainsKey(source))
            {
                if (args.Count == 3)
                {
                    string username = args[0].ToString();
                    string password = args[1].ToString();
                    string email = args[2].ToString();

                    if (!EmailValidator.IsValidEmail(email)) { return Exports["lenguaje"].not_valid_email(); }
                    if (auth.UsernameExists(username)) { return Exports["lenguaje"].user_exists(); }
                    if (auth.EmailExists(email)) { return Exports["lenguaje"].email_exists(); }
                    if (password.Length < 5) { return Exports["lenguaje"].password_to_short(); }
                    
                    string userKey = UserTokenGenerator.Get();
                    auth.Register(userKey, username, password, "user", email);
                    PlayersMetadata.token.Add(source, userKey);
                    TriggerClientEvent(Players[source], "changeToken", userKey);
                    return "OK";

                }
                else
                {
                    return Exports["lenguaje"].user_parameters_register_error();
                }

            }
            else
            {
                return Exports["lenguaje"].already_logged_registered();
            }
        }


        [Command("login")]
        public void LoginCommand(int source, List<object> args, string raw)
        {
            string loginMeta = Login(source, args);

            if ("OK" == loginMeta)
            {
                TriggerClientEvent(Players[source], "sendOnUserChat", $"Welcome to <Server_name> {Players[source].Name}");
            }
            else
            {
                TriggerClientEvent(Players[source], "sendOnUserChat", loginMeta);
            }
        }


        [Command("register")]
        public void RegisterCommand(int source, List<object> args, string raw)
        {

            string RegisterMeta = Register(source, args);

            if ("OK" == RegisterMeta)
            {
                TriggerClientEvent(Players[source], "sendOnUserChat", $"Welcome to <Server_name> {Players[source].Name}");
            }
            else
            {
                TriggerClientEvent(Players[source], "sendOnUserChat", RegisterMeta);
            }

        }
    }
}