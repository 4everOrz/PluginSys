using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PluginSys.Model;
using PluginSys.Model.Response;
namespace PluginSys.BLL
{
    /// <summary>
    /// Flows
    /// </summary>
    public partial class FlowsBLL : BaseBLL
    {
        private readonly PluginSys.DAL.FlowsDAL dal = new PluginSys.DAL.FlowsDAL();
        public FlowsBLL()
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
        public bool Exists(int F_ID)
        {
            return dal.Exists(F_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /*public int  Add(string flow,string remark)
        {
            FlowsEntity model= GetFlow(flow,remark);
            return dal.Add(model);
        }*/

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PluginSys.Model.FlowsEntity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新插件草稿状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(int FID, string State)
        {
            BaseResponseEntity<string> entity = new BaseResponseEntity<string>();
            if (dal.Update(FID, State))
            {
                entity.resCode = 1;
                entity.resMsg = "success";

            }
            else
            {
                entity.resCode = 0;
                entity.resMsg = "failed";
            }
            return JsonHelper.SerializeObject(entity);
        }



        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int F_ID)
        {

            return dal.Delete(F_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string F_IDlist)
        {
            return dal.DeleteList(F_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PluginSys.Model.FlowsEntity GetModel(int F_ID)
        {

            return dal.GetModel(F_ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PluginSys.Model.FlowsEntity GetModel(string MID, string AppVer)
        {
            return dal.GetModel(MID, AppVer);

        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public PluginSys.Model.FlowsEntity GetModelByCache(int F_ID)
        {

            string CacheKey = "FlowsModel-" + F_ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(F_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (PluginSys.Model.FlowsEntity)objModel;
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
        public List<PluginSys.Model.FlowsEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PluginSys.Model.FlowsEntity> DataTableToList(DataTable dt)
        {
            List<PluginSys.Model.FlowsEntity> modelList = new List<PluginSys.Model.FlowsEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PluginSys.Model.FlowsEntity model;
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        /************************************************************************/
        /// <summary>
        /// 获取当前用户名下待审批插件信息
        /// </summary>
        /// <param name="CurrentUserID"></param>
        /// <returns></returns>
        public string GetPluginModel(int CurrentUserID)
        {
            DataSet ds = dal.GetPluginModel(CurrentUserID);
            List<PluginsEntity> list = base.PutAllVal<PluginsEntity>(ds);
            BaseResponseEntity<List<PluginsEntity>> entity = new BaseResponseEntity<List<PluginsEntity>>();
            entity.resCode = 1;
            entity.resMsg = "success";
            entity.resData = list;

            return JsonHelper.SerializeObject(entity);
        }


        /// <summary>
        /// 获取当前用户名下待处理插件
        /// </summary>
        /// <param name="CurrentUserID"></param>
        /// <returns></returns>
        public string GetList(int UserID, int F_ID,out int listCount)
        {
            DataSet ds = dal.GetListP(UserID, F_ID);
            List<PluginsResultEntity2> list = base.PutAllVal<PluginsResultEntity2>(ds);
            BaseResponseEntity<List<PluginsResultEntity2>> entity = new BaseResponseEntity<List<PluginsResultEntity2>>();
            listCount = list.Count;
            entity.totalCount = list.Count;
            entity.resCode = 1;         
            entity.resData = list;
   
            return JsonHelper.SerializeObject(entity);
        }
        /// <summary>
        /// 更新审批表信息
        /// </summary>
        /// <param name="FID"></param>
        /// <param name="FlowStep"></param>
        /// <param name="CurrentUserID"></param>
        /// <returns></returns>
        public string UpdateFlow(int FID, int FlowStep, int CurrentUserID)
        {
            BaseResponseEntity<string> entity = new BaseResponseEntity<string>();

            if (dal.UpdateFlow(FID, FlowStep, CurrentUserID))
            {
                entity.resCode = 1;
                entity.resMsg = "Success";
                return JsonHelper.SerializeObject(entity);
            }
            else
            {
                entity.resCode = 0;
                entity.resMsg = "Failed";
                return JsonHelper.SerializeObject(entity);
            }

        }

        /// <summary>
        /// 更新插件审批状态：待完成？失败？成功？
        /// </summary>
        /// <param name="FID"></param>
        /// <returns></returns>
        public string UpdateState(int FID, string State)
        {
            BaseResponseEntity<string> entity = new BaseResponseEntity<string>();

            if (dal.UpdateState(FID, State))
            {
                entity.resCode = 1;
                entity.resMsg = "Operate successed";
                return JsonHelper.SerializeObject(entity);
            }
            else
            {
                entity.resCode = 0;
                entity.resMsg = "UpdateResultFailed";
                return JsonHelper.SerializeObject(entity);
            }


        }

        public PluginSys.Model.FlowsEntity GetModel_byEventID(int EventID)
        {
            return dal.GetModel_byEventID(EventID);

        }
        /*******************************************/
        /*********************************************************************************/
        #endregion  ExtensionMethod
    }
}

