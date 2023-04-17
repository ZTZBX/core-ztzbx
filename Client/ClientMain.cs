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
            EventHandlers["getToken"] += new Func<string>(GetToken);

            // Exports
            Exports.Add("playerToken", new Func<string>(GetToken));

            FreezeEntityPosition(PlayerPedId(), true);
        }

        private string GetToken() {return Player.playerToken;}

        private void ChangeToken(string token) 
        {
            Player.playerToken = token;
            FreezeEntityPosition(PlayerPedId(), false);
        }
    }
}