using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginSys.Model.Response
{
    public class LoginResultEntity : UsersEntity
    {
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
    }
}
