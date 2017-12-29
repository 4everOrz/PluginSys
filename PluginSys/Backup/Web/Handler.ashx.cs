using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PluginSys.Model;
using PluginSys.BLL;
using Maticsoft.Common;
using PluginSys.Model.Response;

namespace PluginSys.Web
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string functype = context.Request["Functype"];
            string AccessToken = context.Request["AccessToken"];
            string UserID = context.Request["UserID"];
            string result = "";
            try
            {
                if (Constant.Login == functype)//用户登录
                {
                    UsersBLL userBLL = new UsersBLL();
                    result = userBLL.Login(context.Request["Account"], context.Request["Password"]);
                }
                else if (Constant.GetPluginList == functype)//获取插件列表
                {
                    PluginsBLL bll = new PluginsBLL();
                    if (bll.VaildToken(int.Parse(UserID), AccessToken))
                    {
                        result = bll.GetListByPage(context.Request["MID"], context.Request["AppVer"], context.Request["pageSize"], context.Request["startIndex"]);
                    }
                }
                else if (Constant.AddPlugin == functype)//新增插件
                {
                    string MID = context.Request["MID"];
                    string AppVer = context.Request["AppVer"];
                    string PluginVer = context.Request["PluginVer"];
                    string Remark = context.Request["Remark"];
                    HttpPostedFile file = context.Request.Files[0];
                    PluginsBLL bll = new PluginsBLL();
                    if (bll.VaildToken(int.Parse(UserID), AccessToken))
                    {

                        bool ret = bll.TransferToServer(file, MID, PluginVer, AppVer);
                        if (ret)
                        {
                            result = bll.Add(UserID, MID, AppVer, PluginVer, Remark, file.ContentLength);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                BaseResponseEntity<object> entity = new BaseResponseEntity<object>();
                entity.resCode = 0;
                entity.resMsg = "service error pls check log：" + e.Message;
                result = JsonHelper.SerializeObject(entity);
                LogManager.Error(e.ToString());
            }
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}