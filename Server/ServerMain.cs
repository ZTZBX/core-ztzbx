using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace core_ztzbx.Server
{
    public class ServerMain : BaseScript
    {
        PlayerAuth auth = new PlayerAuth();

        public ServerMain(){}

        [Command("login")]
        public void LoginTest(string args)
        {
            if (auth.login("pepe", "12345")){Debug.WriteLine("Todo OKK");}
            else {Debug.WriteLine("No Todo OKKKK");}
            
        }
    }
}