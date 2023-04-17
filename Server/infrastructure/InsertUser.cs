using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;

namespace core_ztzbx.Server
{
    public class InsertUser : BaseScript
    {
        public InsertUser() { }
        public void New(string token, string username, string password, string group, string email)
        {
            List<List<string>> rows_to_add = new List<List<string>> { };
            List<string> new_line_1 = new List<string> { $"'{token}'", $"'{username}'", $"'{password}'",  $"'{group}'",  $"'{email}'"};
            rows_to_add.Add(new_line_1);
            Exports["fivem-mysql"].insert("players", new List<string> { "`token`", "`username`", "`password`", "`group`", "`email`" }, rows_to_add);
        }
    }
}