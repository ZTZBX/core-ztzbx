using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// fivem imports
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;


namespace core_ztzbx.Client
{
    internal class ChatMessage : BaseScript
    {

        private string server_name;

        public ChatMessage() {
            EventHandlers["sendOnUserChat"] += new Action<string>(send);
            Exports.Add("sendOnUserChat", new Action<string>(send));
        }

        private void onClientResourceStart(string resourceName){ if (GetCurrentResourceName() != resourceName) return;}

        public void send(string message)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 31, 30, 30 },
                args = new[] { $"{message}" }
            });
        }

        
    }
}