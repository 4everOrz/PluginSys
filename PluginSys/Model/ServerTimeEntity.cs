using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginSys.Model
{
    /// <summary>
    /// 服务器时间实体
    /// </summary>
    public class ServerTimeEntity : ServerBaseEntity
    {
        public string time { get; set; }
        public string localtime { get; set; }
        public string offset { get; set; }
        public string timezone { get; set; }
    }
}
