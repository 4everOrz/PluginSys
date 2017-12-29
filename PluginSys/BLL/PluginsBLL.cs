using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PluginSys.Model;
using PluginSys.Model.Response;
using System.Web;
using System.IO;
using System.Text;
namespace PluginSys.BLL
{
    /// <summary>
    /// Plugins
    /// </summary>
    public partial class PluginsBLL : BaseBLL
    {
        private readonly PluginSys.DAL.PluginsDAL dal = new PluginSys.DAL.PluginsDAL();
        public PluginsBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string MID, int AppVer)
        {
            return dal.Exists(MID, AppVer);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PluginSys.Model.PluginsEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PluginSys.Model.PluginsEntity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int F_ID)
        {
            BaseResponseEntity<object> result = new BaseResponseEntity<object>();
            if (dal.Delete(F_ID))
            {
                result.resMsg = "success";
                result.resCode = 1;          
            }
            else
            {
                result.resCode = 0;
                result.resMsg = "plugin delete error";                
            }  
            return JsonHelper.SerializeObject(result);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PluginSys.Model.PluginsEntity GetModel(string MID, int AppVer)
        {

            return dal.GetModel(MID, AppVer);
        }


        public PluginSys.Model.PluginsEntity GetModel(int F_ID)
        {

            return dal.GetModel(F_ID);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public PluginSys.Model.PluginsEntity GetModelByCache(string MID, int AppVer)
        {

            string CacheKey = "PluginsModel-" + MID + AppVer;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(MID, AppVer);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (PluginSys.Model.PluginsEntity)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PluginSys.Model.PluginsEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PluginSys.Model.PluginsEntity> DataTableToList(DataTable dt)
        {
            List<PluginSys.Model.PluginsEntity> modelList = new List<PluginSys.Model.PluginsEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PluginSys.Model.PluginsEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public string GetListByPage(string MID, string AppVer, string pageSize, string currentIndex, string State)
        {
            int count = 0;
            DataSet ds = dal.GetListByPage(MID, AppVer, int.Parse(pageSize), int.Parse(currentIndex), State, out count);
            List<PluginsResultEntity> list = base.PutAllVal<PluginsResultEntity>(ds);
            BaseResponseEntity<List<PluginsResultEntity>> entity = new BaseResponseEntity<List<PluginsResultEntity>>();
            entity.totalCount = count;
            entity.resCode = 1;
            entity.resData = list;
            return JsonHelper.SerializeObject(entity);
        }


        /// <summary>
        /// 获取当前用户名下草稿
        /// </summary>
        /// <param name="CreatorID"></param>
        /// <returns></returns>
        public string GetDraft(int CreatorID)
        {

            DataSet ds = dal.GetDraft(CreatorID);
            List<PluginsResultEntity2> list = base.PutAllVal<PluginsResultEntity2>(ds);
            BaseResponseEntity<List<PluginsResultEntity2>> entity = new BaseResponseEntity<List<PluginsResultEntity2>>();
            entity.totalCount = list.Count;
            entity.resCode = 1;
            entity.resMsg = "success";
            entity.resData = list;
            
            return JsonHelper.SerializeObject(entity);

        }
        /// <summary>
        /// 添加插件信息，向插件表和审批表存入数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="MID"></param>
        /// <param name="AppVer"></param>
        /// <param name="PluginVer"></param>
        /// <param name="PluginRemark"></param>
        /// <param name="FileSize"></param>
        /// <param name="file"></param>
        /// <param name="Flow"></param>
        /// <param name="FlowRemark"></param>
        /// <returns></returns>
        public string Add(int UserID, string MID, int AppVer, string PluginVer, string PluginRemark, int FileSize, HttpPostedFile file, string Flow, string FlowRemark, string State)
        {
            if (FileSize < 2048000)
            {
                bool ret = false;
                PluginsEntity entity = new PluginsEntity();
                FlowsEntity entityx = new FlowsEntity();
                string[] arry = Flow.Split('^');
                int count = arry.Length;

                entity.AppVer = AppVer;
                entity.CreatorID = UserID;
                entity.FileSize = FileSize;
                entity.MID = MID;
                entity.PluginVer = PluginVer;
                entity.PluginRemark = PluginRemark;
                entity.Url = TransferToServer(file, MID, PluginVer, AppVer);
                entity.CreateTime = DateTime.Now;

                entityx.Flow = Flow;
                entityx.FlowRemark = FlowRemark;
                entityx.CurrentUserID = int.Parse(arry[0]);//第一审批人id
                entityx.FlowStep = 1;
                entityx.CurrentUserCount = count;

                entityx.State = State;


                ret = dal.Add(entity, entityx);



                BaseResponseEntity<object> result = new BaseResponseEntity<object>();
                if (ret)
                {
                    result.resMsg = "success";
                    result.resCode = 1;

                    return JsonHelper.SerializeObject(result);
                }
                else
                {

                    result.resCode = 1;
                    result.resMsg = "Plugin add error";
                    return JsonHelper.SerializeObject(result);
                }
            }
            else
            {
                throw new Exception("The FileSize error");
            }

            //TODO  存插件上传历史记录
        }
        /// <summary>
        /// 更新插件
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="MID"></param>
        /// <param name="AppVer"></param>
        /// <param name="PluginVer"></param>
        /// <param name="PluginRemark"></param>
        /// <param name="FileSize"></param>
        /// <param name="file"></param>
        /// <param name="Flow"></param>
        /// <param name="FlowRemark"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public string Update(int UserID, string MID, int AppVer, string PluginVer, string PluginRemark, int FileSize, HttpPostedFile file, string Flow, string FlowRemark, string State)
        {
            if (FileSize < 2048000)
            {
                bool ret = false;
                PluginsEntity entity = new PluginsEntity();


                FlowsEntity entityx = new FlowsEntity();
                string[] arry = Flow.Split('^');
                int count = arry.Length;

                entity.AppVer = AppVer;
                entity.CreatorID = UserID;
                entity.FileSize = FileSize;
                entity.MID = MID;
                entity.PluginVer = PluginVer;
                entity.PluginRemark = PluginRemark;
                entity.Url = TransferToServer(file, MID, PluginVer, AppVer);
                entity.CreateTime = DateTime.Now;


                entityx.Flow = Flow;
                entityx.FlowRemark = FlowRemark;
                entityx.CurrentUserID = int.Parse(arry[0]);//第一审批人id
                entityx.FlowStep = 1;
                entityx.CurrentUserCount = count;//审批级数
                entityx.State = State;

                ret = dal.Update(entity, entityx);


                BaseResponseEntity<object> result = new BaseResponseEntity<object>();
                if (ret)
                {
                    result.resMsg = "success";
                    result.resCode = 1;
                    return JsonHelper.SerializeObject(result);
                }
                else
                {
                    result.resCode = 0;
                    result.resMsg = "plugin update error";
                    return JsonHelper.SerializeObject(result);
                }
            }
            else
            {
                throw new Exception("The FileSize error");
            }

            //TODO  存插件上传历史记录
        }

        /// <summary>
        ///  存插件获取Url
        /// </summary>
        /// <returns></returns>
        public string TransferToServer(HttpPostedFile file, string mid, string ver, int appVer)
        {
            string[] arr = file.FileName.Split('.');
            if ((arr[arr.Length - 1] == "zip") || (arr[arr.Length - 1] == "7z"))
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("/plugins/" + mid + "/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (arr.Length != 0)
                {
                    string filename = path + mid + "_" + DateTime.Now.Ticks + "." + arr[arr.Length - 1];
                    file.SaveAs(filename);
                    return filename;
                }
                else
                {
                    throw new Exception("Extension name error");
                }
            }
            else
            {
                throw new Exception("The FileType error");
            }
        }
        /// <summary>
        /// 上传插件到服务器
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="ver"></param>
        /// <param name="appVer"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool SendToSever(string mid, string ver, int appVer, string filename)
        {   /*
             * appId 服务器端提供
             * appt [当前UTC时间]
             * appr 整数随机数
             * apivc=md5(appid_appkey_appt_appr) [api校验码]
             * mid
             * ver
             * appVer
             * descriptionCN
             * descriptionEN
             * file
             */
            string appt = GetServerTime();
            int appr = new Random().Next(99999);
            string vc = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Constant.Appid + "_" + Constant.Appkey + "_" + appt + "_" + appr, "MD5");

            MultipartForm http = new MultipartForm();
            http.AddString("appId", Constant.Appid);
            http.AddString("appt", appt);
            http.AddString("appr", appr.ToString());
            http.AddString("apivc", vc);
            http.AddString("mid", mid);
            http.AddString("ver", ver);
            http.AddString("appVer", appVer.ToString());
            http.AddString("descriptionCN", "无");
            http.AddString("descriptionEN", "none"); 
            http.AddFlie("File", filename);
            WebClient client = new WebClient();
            string result = client.Post(Constant.GetURL_AddPlugin(), http);
            ServerBaseEntity baseEntity = JsonHelper.DeserializeJsonToObject<ServerBaseEntity>(result);
            if (baseEntity.r == 200)
            {
                return true;
            }
            else
            {
                ServerErrorEntity entity = JsonHelper.DeserializeJsonToObject<ServerErrorEntity>(result);
                throw new Exception("addPlugin error-code:" + entity.r + "-msg:" + entity.msg);
            }
        }
        //获取服务器UTC
        public string GetServerTime()
        {
            /*{"r":200,"time":"2017-10-24 08:06:19","localtime":"2017-10-24 16:06:19","offset":8,"timezone":"涓浗鏍囧噯鏃堕棿"}*/
            WebClient client = new WebClient();
            string result = client.GetHtml(Constant.GetURL_Time());
            ServerBaseEntity baseEntity = JsonHelper.DeserializeJsonToObject<ServerBaseEntity>(result);
            if (baseEntity.r == 200)
            {
                ServerTimeEntity entity = JsonHelper.DeserializeJsonToObject<ServerTimeEntity>(result);
                return entity.time;
            }
            else
            {
                throw new Exception("GetServerTime error");
            }
        }
        #endregion  ExtensionMethod
    }

}

