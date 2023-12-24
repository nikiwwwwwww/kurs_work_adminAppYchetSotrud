using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp_YchetSotrudnikov
{
    public class SaveRole
    {

        //    public static List<string> DataList = new List<string>();


        public string Role { get; set; }

        public SaveRole(string role)
        {
            Role = role;
        }

        public string GetRole()
        {
            return this.Role;
        }

        public void SetRole(string role)
        {
            this.Role = role;
        }
    }
}
