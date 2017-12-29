using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.Common;
using PluginSys.Model;
using PluginSys.Model.Response;
namespace PluginSys.BLL
{
	/// <summary>
	/// Departments
	/// </summary>
	public partial class DepartmentsBLL:BaseBLL
	{
		private readonly PluginSys.DAL.DepartmentsDAL dal=new PluginSys.DAL.DepartmentsDAL();
		public DepartmentsBLL()
		{}
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
		public bool Exists(int DepartmentID)
		{
			return dal.Exists(DepartmentID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(PluginSys.Model.DepartmentsEntity model)
		{   
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PluginSys.Model.DepartmentsEntity model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DepartmentID)
		{
			
			return dal.Delete(DepartmentID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DepartmentIDlist )
		{
			return dal.DeleteList(DepartmentIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PluginSys.Model.DepartmentsEntity GetModel(int DepartmentID)
		{
			
			return dal.GetModel(DepartmentID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PluginSys.Model.DepartmentsEntity GetModelByCache(int DepartmentID)
		{
			
			string CacheKey = "DepartmentsModel-" + DepartmentID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DepartmentID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PluginSys.Model.DepartmentsEntity)objModel;
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
		public List<PluginSys.Model.DepartmentsEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PluginSys.Model.DepartmentsEntity> DataTableToList(DataTable dt)
		{
			List<PluginSys.Model.DepartmentsEntity> modelList = new List<PluginSys.Model.DepartmentsEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PluginSys.Model.DepartmentsEntity model;
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
        public string OutputDepartment()
        {                 
           DataSet coco=dal.GetList("");
           List<DepartmentsEntity> list = base.PutAllVal<DepartmentsEntity>(coco);
           BaseResponseEntity<List<DepartmentsEntity>> entity = new BaseResponseEntity<List<DepartmentsEntity>>();
           entity.resMsg = "success";
           entity.resCode = 1;
           entity.resData = list;         
           return JsonHelper.SerializeObject(entity);     
        }
   
		#endregion  ExtensionMethod
	}
}

