using System;
using System.Threading.Tasks;

namespace core_ztzbx.Server
{
    public class PlayerAuth
    {
        public PlayerAuth(){}
        public bool login(string username, string password)
        {
            CheckUser checkUser = new CheckUser();
            bool status = checkUser.CheckCredentials(username, password);
            return status;
        }
    }
}