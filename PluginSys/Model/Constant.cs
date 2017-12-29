using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginSys.Model
{
    public class Constant
    {
        #region 功能

        public const string Login = "Login";//登录
        public const string Regist = "Regist";//注册
        public const string GetPluginList = "GetPluginList";//获取已上传插件列表    
        public const string OutputDepartment = "OutputDepartment";//获取所有部门信息
        
        public const string Approve = "Approve";//审批
        public const string GetPlugin = "GetPlugin";//查看插件
        public const string OperateDraft = "OperateDraft";//对草稿执行操作
        public const string DeleteDraft = "DeleteDraft";//删除草稿
        public const string GetPluginAll = "GetPluginAll";
        public const string SearchEvent = "SearchEvent";//查看待办
        public const string SearchUsers = "SearchUsers";//查询用户
        public const string ManageDepartment = "ManageDepartment";//部门管理
        #endregion


        public const string Appid = "5185135031351000951";
        public const string Appkey = "067b90d133f1312476f2599c77260fd7";
        private const string _url = "http://test.grih.gree.com";
        private const string _addAppPlugin = "/InternalAPI/AddAppPlugin";
        private const string _getUTCTime = "/App/Time";


        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public static string GetURL_Time()
        {
            return _url + _getUTCTime;
        }

        /// <summary>
        /// 获取上传插件服务器地址
        /// </summary>
        /// <returns></returns>
        public static string GetURL_AddPlugin()
        {
            return _url + _addAppPlugin;
        }
    }
}
