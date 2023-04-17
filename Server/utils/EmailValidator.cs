

using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace core_ztzbx.Server
{
    static public class EmailValidator
    {
        static public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

    }
}