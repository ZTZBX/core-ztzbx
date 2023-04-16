using System;
using System.Threading.Tasks;

namespace core_ztzbx.Server
{
    public class PlayerAuth
    {
        InsertUser insertUser = new InsertUser();
        CheckUser checkUser = new CheckUser();

        public PlayerAuth(){}
        public bool Login(string username, string password)
        {
            bool status = checkUser.CheckCredentials(username, password);
            return status;
        }

        public void Register(string token, string username, string password, string group)
        {
            insertUser.New(token, username, password, group);
        }

        public bool Exists(string username)
        {
            return checkUser.Exists(username);
        }
    }
}