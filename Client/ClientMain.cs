using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace core_ztzbx.Client
{
    public class ClientMain : BaseScript
    {
        ChatMessage chatmes = new ChatMessage();

        public ClientMain()
        {
            EventHandlers["changeToken"] += new Action<string>(ChangeToken);
            EventHandlers["changeUsername"] += new Action<string>(changeUsername);


            // Exports
            Exports.Add("playerToken", new Func<string>(GetToken));
            Exports.Add("playerUsername", new Func<string>(GetUsername));
            Exports.Add("banPlayer", new Action<string>(BanPlayer));

            FreezeEntityPosition(PlayerPedId(), true);
        }

        private void BanPlayer(string username)
        {
            TriggerServerEvent("banPlayer", username);
        }
        private string GetToken() { return Player.playerToken; }
        private string GetUsername() { return Player.username; }
        private void changeUsername(string username)
        {
            Player.username = username;
        }
        private void ChangeToken(string token)
        {
            Player.playerToken = token;
            FreezeEntityPosition(PlayerPedId(), false);
        }
    }
}