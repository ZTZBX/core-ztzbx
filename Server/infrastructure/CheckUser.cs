using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace core_ztzbx.Server
{
    public class CheckUser : BaseScript
    {
        public CheckUser() { }
        public bool CheckCredentials(string username, string password)
        {
            dynamic result = Exports["fivem-mysql"].raw($"SELECT username FROM players where username='{username}' and password='{password}'");

            if (result.Count > 0) { return true; }
            return false;
        }

        public bool UsernameExists(string username)
        {
            dynamic result = Exports["fivem-mysql"].raw($"SELECT username FROM players where username='{username}'");
            if (result.Count > 0) { return true; }
            return false;
        }

        public bool EmailExists(string email)
        {
            dynamic result = Exports["fivem-mysql"].raw($"SELECT username FROM players where email='{email}'");
            if (result.Count > 0) { return true; }
            return false;
        }

        public bool IsAdmin(string token)
        {
            dynamic result = Exports["fivem-mysql"].raw($"SELECT group FROM players where token='{token}'");
            if (result.Count <= 0) { return false; }
            if (result[0][0] == "admin") { return true; }
            return false;
        }


    }
}