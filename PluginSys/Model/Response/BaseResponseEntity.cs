using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginSys.Model.Response
{
    /// <summary>
    /// 回应包基本字段
    /// </summary>
    public class BaseResponseEntity<T>
    {
        public int resCode { get; set; }
        public string resMsg { get; set; }
        public int totalCount { get; set; }
        public T resData{ get; set; }
    }
    public class ApproveResponseEntity<T>
    {  
        public T ApproveList { get; set; }    
 
    }
}
