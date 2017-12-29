using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PluginSys.Model;
using PluginSys.BLL;
using Maticsoft.Common;
using PluginSys.Model.Response;
using Maticsoft.Common.DEncrypt;

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
            string result = "";
            try
            {
                if (Constant.Login == functype)//用户登录
                {
                    #region method
                    UsersBLL userBLL = new UsersBLL();
                    result = userBLL.Login(context.Request["Account"], context.Request["Password"]);
                    #endregion method
                }
                else if (Constant.GetPluginList == functype)//获取插件信息
                {
                    #region method
                    string AccessToken = context.Request["AccessToken"];
                    int UserID = int.Parse(context.Request["UserID"]);
                    string pageSize = context.Request["pageSize"];
                    string startIndex = context.Request["startIndex"];
                    string Key = context.Request["Key"];
                    PluginsBLL bll = new PluginsBLL();
                    if (bll.VaildToken(UserID, AccessToken))
                    {
                        switch (Key)
                        {
                            case "0"://获取已上传服务器插件
                                result = bll.GetListByPage(context.Request["MID"], context.Request["AppVer"], pageSize, startIndex, "Passed");
                                break;
                            case "1"://获取待审批插件
                                result = bll.GetListByPage(context.Request["MID"], context.Request["AppVer"], pageSize, startIndex, "Approving");
                                break;
                            case "2"://查看用户名下草稿
                                result = bll.GetDraft(UserID);
                                break;
                            default:
                                result = JsonHelper.SerializeObject("Error:Not the correct number of operations");
                                break;
                        }
                    }
                    else
                    {
                        result = JsonHelper.SerializeObject("Error:User verification failed");
                    }
                    #endregion method
                }
                else if (Constant.SearchEvent == functype)//查看待办记录
                {
                    #region method
                    string AccessToken = context.Request["AccessToken"];
                    int UserID = int.Parse(context.Request["UserID"]);
                    EventsBLL bll = new EventsBLL();
                    if (bll.VaildToken(UserID, AccessToken))
                    {
                        result = bll.GetList(UserID);
                    }
                    else
                    {
                        result = JsonHelper.SerializeObject("Error:User verification failed");
                    }
                    #endregion method
                }
                else if (Constant.OperateDraft == functype)//编辑插件  
                {
                    #region method
                    string AccessToken = context.Request["AccessToken"];
                    int UserID = int.Parse(context.Request["UserID"]);
                    string Key = context.Request["Key"];
                    string MID = context.Request["MID"];
                    int AppVer = int.Parse(context.Request["AppVer"]);
                    string PluginVer = context.Request["PluginVer"];
                    string PluginRemark = context.Request["PluginRemark"];
                    string Flow = context.Request["Flow"];
                    string FlowRemark = context.Request["FlowRemark"];
                    HttpPostedFile file = context.Request.Files[0];
                    PluginsBLL pbll = new PluginsBLL();
                    FlowsBLL fbll = new FlowsBLL();
                    EventsBLL ebll = new EventsBLL();
                    if (pbll.VaildToken(UserID, AccessToken))
                    {
                        switch (Key)
                        {
                            case "0"://新建  
                                if (pbll.Exists(MID, AppVer)) //插件信息是否已存在
                                {
                                    result = pbll.Update(UserID, MID, AppVer, PluginVer, PluginRemark, file.ContentLength, file, Flow, FlowRemark, "Draft");//更新
                                }
                                else
                                {
                                    result = pbll.Add(UserID, MID, AppVer, PluginVer, PluginRemark, file.ContentLength, file, Flow, FlowRemark, "Draft");//新增
                                }
                                break;
                            case "1"://提交审批 
                                result = pbll.Add(UserID, MID, AppVer, PluginVer, PluginRemark, file.ContentLength, file, Flow, FlowRemark, "Approving");
                                ebll.Add(fbll.GetModel(MID, AppVer.ToString()).F_ID, "有待审批插件");
                                break;
                            default:
                                result = JsonHelper.SerializeObject("Error:Not the correct number of operations");
                                break;
                        }
                    }
                    else
                    {
                        result = JsonHelper.SerializeObject("Error:User verification failed");
                    }
                    #endregion method
                }
                else if (Constant.DeleteDraft == functype)//删除草稿
                {
                    #region method
                    string AccessToken = context.Request["AccessToken"];
                    int UserID = int.Parse(context.Request["UserID"]);
                    PluginsBLL pbll = new PluginsBLL();
                    if (pbll.VaildToken(UserID, AccessToken))
                    {
                        int F_ID = int.Parse(context.Request["F_ID"]);
                        result = pbll.Delete(F_ID);
                    }
                    else
                    {
                        result = JsonHelper.SerializeObject("Error:User verification failed");
                    }
                    #endregion method
                }
                else if (Constant.GetPlugin == functype)//获取插件详情
                {
                    #region method
                    string AccessToken = context.Request["AccessToken"];
                    int UserID = int.Parse(context.Request["UserID"]);
                    int F_ID = int.Parse(context.Request["F_ID"]);
                    int listCount;
                    FlowsBLL fbll = new FlowsBLL();
                    ApproveHistoryBLL abll = new ApproveHistoryBLL();
                    if (fbll.VaildToken(UserID, AccessToken))
                    {
                        string Json1 = fbll.GetList(UserID, F_ID, out listCount);
                        string Json2 = abll.GetModel(F_ID);
                        if (listCount != 0)//有数据时
                        {
                            result = ExchangeType.FixJson1(Json1, Json2);
                        }
                        else //无数据时
                        {
                            result = ExchangeType.FixJson2(Json1, Json2);
                        }                      
                    }
                    else
                    {
                        result = JsonHelper.SerializeObject("Error:User verification failed");
                    }
                    #endregion method
                }
                else if (Constant.Approve == functype)//审批   
                {
                    #region method
                    FlowsBLL bll = new FlowsBLL();
                    EventsBLL ebll = new EventsBLL();
                    ApproveHistoryBLL abll = new ApproveHistoryBLL();
                    PluginsBLL pbll = new PluginsBLL();
                    string Opinion = context.Request["Opinion"];
                    int F_ID = int.Parse(context.Request["F_ID"]);
                    string AccessToken = context.Request["AccessToken"];
                    int UserID = int.Parse(context.Request["UserID"]);
                    string ApproveRemark = context.Request["ApproveRemark"];
                    if (bll.VaildToken(UserID, AccessToken))
                    {
                        FlowsEntity model = bll.GetModel(F_ID);
                        if (model.State == "Approving")
                        {
                            if (UserID == model.CurrentUserID)
                            {
                                PluginsEntity pentity = pbll.GetModel(F_ID);
                                if (Opinion == "true")
                                {
                                    if (model.FlowStep == model.CurrentUserCount)
                                    {
                                        ebll.Update(F_ID, pentity.CreatorID, "有插件审批通过");//添加待办通知
                                        result = bll.UpdateState(F_ID, "Passed");//更新审批状态
                                        //pbll.SendToSever(pentity.MID,pentity.PluginVer,pentity.AppVer,pentity.Url); ////上传服务器
                                    }
                                    else
                                    {
                                        string[] arry = model.Flow.Split('^');
                                        int NextUser = int.Parse(arry[model.FlowStep]);
                                        ebll.Update(F_ID, NextUser, "有待审批插件");
                                        result = bll.UpdateFlow(F_ID, model.FlowStep + 1, NextUser);
                                    }
                                }
                                else
                                {
                                    ebll.Update(F_ID, pentity.CreatorID, "有插件审批失败");
                                    result = bll.UpdateState(F_ID, "Failed");//更新审批状态
                                }
                                abll.ADD(UserID, F_ID, Opinion, ApproveRemark);//审批记录表添入数据
                            }
                            else
                            {
                                result = JsonHelper.SerializeObject("Error:User identity error");//此用户无权处理当前插件
                            }
                        }
                        else
                        {
                            result = JsonHelper.SerializeObject("Error:Approval has been completed");//审批已经结束
                        }
                    }
                    else
                    {
                        result = JsonHelper.SerializeObject("Error:User verification error");//用户身份校验不通过
                    }
                    #endregion method
                }
                else if (Constant.OutputDepartment == functype)//输出部门信息
                {
                    #region method
                    DepartmentsBLL bll = new DepartmentsBLL();
                    result = bll.OutputDepartment().ToString();
                    #endregion method
                }
                else if (Constant.Regist == functype)//用户注册
                {
                    #region method
                    BaseBLL basebll = new BaseBLL();
                    UsersEntity uentity = new UsersEntity();
                    UsersBLL bll = new UsersBLL();
                    uentity.UserName = context.Request["UserName"];
                    uentity.Password = DESEncrypt.Encrypt(context.Request["Password"]);
                    uentity.Mail = context.Request["Mail"];
                    uentity.Sex = ExchangeType.Tobool(context.Request["Sex"]);
                    uentity.Telphone = context.Request["Telphone"];
                    uentity.AccessToken = basebll.CreateToken();
                    uentity.DepartmentID = ExchangeType.Toint(context.Request["DepartmentID"]);
                    uentity.RoleID = ExchangeType.Toint(context.Request["RoleID"]);
                    uentity.CreateTime = System.DateTime.Now;
                    result = bll.Regist(uentity).ToString();
                    #endregion method
                }
                else if (Constant.SearchUsers == functype)//查询所有用户
                {
                    #region method
                    string AccessToken = context.Request["AccessToken"];
                    int UserID = int.Parse(context.Request["UserID"]);
                    UsersBLL bll = new UsersBLL();
                    if (bll.VaildToken(UserID, AccessToken))
                    {
                        result = bll.GetUsers();
                    }
                    else
                    {
                        result = JsonHelper.SerializeObject("Error:User verification error");
                    }
                    #endregion method
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