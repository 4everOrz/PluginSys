using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PluginSys.Model;
namespace PluginSys.BLL
{
	/// <summary>
	/// Config
	/// </summary>
	public partial class ConfigBLL
	{
		private readonly PluginSys.DAL.ConfigDAL dal=new PluginSys.DAL.ConfigDAL();
		public ConfigBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Cfg_Key)
		{
			return dal.Exists(Cfg_Key);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PluginSys.Model.ConfigEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PluginSys.Model.ConfigEntity model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Cfg_Key)
		{
			
			return dal.Delete(Cfg_Key);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Cfg_Keylist )
		{
			return dal.DeleteList(Cfg_Keylist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PluginSys.Model.ConfigEntity GetModel(string Cfg_Key)
		{
			
			return dal.GetModel(Cfg_Key);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PluginSys.Model.ConfigEntity GetModelByCache(string Cfg_Key)
		{
			
			string CacheKey = "ConfigModel-" + Cfg_Key;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Cfg_Key);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PluginSys.Model.ConfigEntity)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PluginSys.Model.ConfigEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PluginSys.Model.ConfigEntity> DataTableToList(DataTable dt)
		{
			List<PluginSys.Model.ConfigEntity> modelList = new List<PluginSys.Model.ConfigEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PluginSys.Model.ConfigEntity model;
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

		#endregion  ExtensionMethod
	}
}

