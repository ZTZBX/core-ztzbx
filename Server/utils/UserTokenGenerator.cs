using System;
using System.Linq;

using System.Threading.Tasks;
using CitizenFX.Core;

namespace core_ztzbx.Server
{
    static public class UserTokenGenerator
    {
        static public string Get() {

            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return token;
        }
    }
}