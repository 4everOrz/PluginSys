using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PluginSys.Model;
using PluginSys.Model.Response;
namespace PluginSys.BLL
{
    	public partial class EventsBLL:BaseBLL
        {
            private readonly PluginSys.DAL.EventsDAL dal = new PluginSys.DAL.EventsDAL();
            public EventsBLL()
            { }
		#region  BasicMethod

		
		/// <summary>
		/// 向待办表内增加一条数据
		/// </summary>
		public string  Add(int F_ID,string EventRemark)
		{
            BaseResponseEntity<string > entity = new BaseResponseEntity<string>();
            entity.resCode = 1;
            entity.resMsg = "Insert Event success";
            entity.resData = "EventID="+dal.Add(F_ID,EventRemark);
            return JsonHelper.SerializeObject(entity);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(int f_ID,int UserID, string EventRemark)
		{
			return dal.Update( f_ID, UserID,EventRemark);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int EventID)
		{

            return dal.Delete(EventID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public PluginSys.Model.EventsEntity GetModel(int EventID)
		{

            return dal.GetModel(EventID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
    

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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<PluginSys.Model.EventsEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<PluginSys.Model.EventsEntity> DataTableToList(DataTable dt)
		{
            List<PluginSys.Model.EventsEntity> modelList = new List<PluginSys.Model.EventsEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                PluginSys.Model.EventsEntity model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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
        public string GetList(int UserID)
        {         
            DataSet ds = dal.GetList("UserID=" + UserID+" AND EventState='ing'");
            List<EventsResultEntity> list = base.PutAllVal<EventsResultEntity>(ds);
            BaseResponseEntity<List<EventsResultEntity>> entity = new BaseResponseEntity<List<EventsResultEntity>>();

            if (list.Count != 0)
            {
                entity.totalCount = list.Count;
                entity.resCode = 1;
                entity.resData = list;  
            }
            else
            {
                entity.resCode = 1;
                entity.resMsg = "no data";
                entity.resData =null;                
            }
        
          return JsonHelper.SerializeObject(entity);
        
        }
		#endregion  ExtensionMethod
	}
}

