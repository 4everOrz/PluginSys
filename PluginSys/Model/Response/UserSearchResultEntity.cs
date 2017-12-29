using System;


namespace PluginSys.Model.Response
{
    [Serializable]
   public partial class UserSearchResultEntity
    {
         public int UserID{ get; set; }      
         public string UserName { get; set; }
         public string DepartmentName { get; set; }
    }
    public partial class UserResultEntity
    {
        public int UserID{ get; set; }
        public string AccessToken { get; set; }
    }
}

