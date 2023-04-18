using System;
using System.Threading.Tasks;

namespace core_ztzbx.Server
{
    public class PlayerActions
    {
        public PlayerActions(){}

        UpdateUser upUser = new UpdateUser();
        public void UpdateToken(string token, string username)
        {
            upUser.Token(token, username);
        }
    }
}