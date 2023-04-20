using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace core_ztzbx.Server
{
    public class UpdateUser : BaseScript
    {
        public UpdateUser(){}
        public void Token(string token, string username)
        {
          Exports["fivem-mysql"].raw($"UPDATE players SET token = '{token}' WHERE username='{username}'");
        }


        public void BanPlayer(string token)
        {
          Exports["fivem-mysql"].raw($"UPDATE players SET baned = {1} WHERE token='{token}'");
        }

    }
}