using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PluginSys.Model;
using PluginSys.Model.Response;
using Maticsoft.Common.DEncrypt;
namespace PluginSys.BLL
{
    /// <summary>
    /// Users
    /// </summary>
    public partial class UsersBLL : BaseBLL
    {
        private readonly PluginSys.DAL.UsersDAL dal = new PluginSys.DAL.UsersDAL();
        public UsersBLL()
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
        public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /*  public int Add(PluginSys.Model.UsersEntity model)
          {
              return dal.Add(model);

          }*/
        public DataSet Add(PluginSys.Model.UsersEntity model)
        {
            return dal.Add(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PluginSys.Model.UsersEntity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {

            return dal.Delete(UserID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            return dal.DeleteList(UserIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PluginSys.Model.UsersEntity GetModel(int UserID)
        {

            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public PluginSys.Model.UsersEntity GetModelByCache(int UserID)
        {

            string CacheKey = "UsersModel-" + UserID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (PluginSys.Model.UsersEntity)objModel;
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
        public List<PluginSys.Model.UsersEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PluginSys.Model.UsersEntity> DataTableToList(DataTable dt)
        {
            List<PluginSys.Model.UsersEntity> modelList = new List<PluginSys.Model.UsersEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PluginSys.Model.UsersEntity model;
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
        public string Login(string account, string psw)
        {
            DataSet ds = dal.GetDSByLogin(account, DESEncrypt.Encrypt(psw), base.CreateToken());
            List<LoginResultEntity> list = base.PutAllVal<LoginResultEntity>(ds);
            BaseResponseEntity<LoginResultEntity> entity = new BaseResponseEntity<LoginResultEntity>();
            if (list.Count != 0)
            {
                entity.resCode = 1;
                entity.resData = list[0];
                return JsonHelper.SerializeObject(entity);
            }
            else
            {
                entity.resCode = 0;
                entity.resMsg = "ACCOUNTNOTEXIST";
                return JsonHelper.SerializeObject(entity);
            }
        }
        /// <summary>
        /// 检查当前注册用户是否已经存在，并对新用户进行注册
        /// </summary>
        public string Regist(PluginSys.Model.UsersEntity model)
        {
            BaseResponseEntity<string> entity = new BaseResponseEntity<string>();
            if (check(model.Mail, model.Telphone) != 0)
            {
                entity.resCode = 0;
                entity.resMsg = "The User Already Exists";
                return JsonHelper.SerializeObject(entity);
            }
            else
            {
                DataSet ds = dal.Add(model);
                List<UserResultEntity> list = base.PutAllVal<UserResultEntity>(ds);
                BaseResponseEntity<List<UserResultEntity>> entity1 = new BaseResponseEntity<List<UserResultEntity>>();
                if (list.Count != 0)
                {
                    entity1.totalCount = list.Count;
                    entity1.resCode = 1;
                    entity1.resMsg = "success";
                    entity1.resData = list;
                   
                }
                else
                {
                    entity1.resCode = 1;
                    entity1.resMsg = "failed";
                    entity1.resData = null;
                   
                }
              return JsonHelper.SerializeObject(entity1);
            }
        }
        public int check(string Mail, string Telphone)
        {
            int count = dal.Getcount(Mail, Telphone);
            return count;
        }
        public string GetUsers()//获取所有用户
        {
            DataSet ds = dal.GetUserNameList("");
            List<UserSearchResultEntity> list = base.PutAllVal<UserSearchResultEntity>(ds);
            BaseResponseEntity<List<UserSearchResultEntity>> entity = new BaseResponseEntity<List<UserSearchResultEntity>>();
            if (list.Count != 0)
            {
                entity.totalCount = list.Count;
                entity.resCode = 1;
                entity.resData = list;
                return JsonHelper.SerializeObject(entity);
              
            }
            else
            {
                entity.resCode = 0;
                entity.resMsg = "ACCOUNTNOTEXIST";
                return JsonHelper.SerializeObject(entity);
            }
        }
        #endregion  ExtensionMethod
    }
}

