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

        public void Register(string token, string username, string password, string group, string email)
        {
            insertUser.New(token, username, password, group, email);
        }

        public bool UsernameExists(string username)
        {
            return checkUser.UsernameExists(username);
        }

        public bool EmailExists(string email)
        {
            return checkUser.EmailExists(email);
        }

        public bool IsAdmin(string token)
        {
            return checkUser.IsAdmin(token);
        }
    }
}