using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace core_ztzbx.Server
{
    public class CheckUser : BaseScript
    {
        public CheckUser(){}
        public bool CheckCredentials(string username, string password)
        {
          dynamic result = Exports["fivem-mysql"].raw($"SELECT * FROM players where username='{username}' and password='{password}'");  

          if (result.Length > 0){return true;}
          return false;
        }
    }
}