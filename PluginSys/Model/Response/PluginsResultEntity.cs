using System;
namespace PluginSys.Model
{
    /// <summary>
    /// Plugins:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PluginsResultEntity : PluginsEntity
    { 
        public string Creator { get; set; }
        public int CurrentUserID { get; set; }
        public string CurrentUser { get; set; }
        public string PluginID { get; set; }
        public string State { get; set; }
        /**/
    }
    public partial class PluginsResultEntity2 : PluginsEntity
    {
        public string UserName { get; set; }
        public string Flow{ get; set; }      
         public string State { get; set; }
         public string FlowRemark { get; set; }/*  */

    }
}

