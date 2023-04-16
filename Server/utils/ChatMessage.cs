using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace core_ztzbx.Server
{
    public class  ChatMessage: BaseScript
    {
        public ChatMessage()
        {
            Exports.Add("sendOnUserChat", new Action<int, string>(SendOnUserChat));
        }
        public void SendOnUserChat(int source, string message)
        {
             TriggerClientEvent(Players[source], message);
        }

    }
}