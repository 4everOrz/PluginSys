using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PluginSys.DAL
{
	/// <summary>
	/// 数据访问类:Plugins
	/// </summary>
	public partial class PluginsDAL
	{
		public PluginsDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PligunID", "tbl_Plugins"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MID,int AppVer)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.NVarChar,10),
					new SqlParameter("@AppVer", SqlDbType.Int,4)			};
			parameters[0].Value = MID;
			parameters[1].Value = AppVer;

			int result= DbHelperSQL.RunProcedure("tbl_Plugins_Exists",parameters,out rowsAffected);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
        /// 
        public bool Add(PluginSys.Model.PluginsEntity model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@AppVer", SqlDbType.Int,4),
                    new SqlParameter("@MID", SqlDbType.NVarChar,10),
                    new SqlParameter("@PluginVer", SqlDbType.NVarChar,5),
                    new SqlParameter("@FileSize", SqlDbType.Int,4),
                    new SqlParameter("@PluginRemark", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),                    
                    new SqlParameter("@CreatorID", SqlDbType.Int,4),
                    new SqlParameter("@Url",SqlDbType.NVarChar,200),
              
};
            parameters[0].Value = model.AppVer;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.PluginVer;
            parameters[3].Value = model.FileSize;
            parameters[4].Value = model.PluginRemark;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CreatorID;
            parameters[7].Value = model.Url;

          

            DbHelperSQL.RunProcedure("tbl_Plugins_Add", parameters, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        /// <summary>
        /// 增加插件和审批表信息，存储过程
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelx"></param>
        /// <returns></returns>
		public bool Add(PluginSys.Model.PluginsEntity model,PluginSys.Model.FlowsEntity modelx )
		{
			int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@AppVer", SqlDbType.Int,4),
                    new SqlParameter("@MID", SqlDbType.NVarChar,10),
                    new SqlParameter("@PluginVer", SqlDbType.NVarChar,5),
                    new SqlParameter("@FileSize", SqlDbType.Int,4),
                    new SqlParameter("@PluginRemark", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),                    
                    new SqlParameter("@CreatorID", SqlDbType.Int,4),
                    new SqlParameter("@Url",SqlDbType.NVarChar,200),

                    new SqlParameter("@Flow",SqlDbType.NVarChar,200),
                    new SqlParameter("@FlowStep",SqlDbType.Int,4),
                    new SqlParameter("@CurrentUserID",SqlDbType.Int,20),
                    new SqlParameter("@FlowRemark",SqlDbType.NVarChar,200),
                    new SqlParameter("@CurrentUserCount",SqlDbType.Int,4),
                    new SqlParameter("@State",SqlDbType.NVarChar,50)

};
			parameters[0].Value = model.AppVer;
			parameters[1].Value = model.MID;
			parameters[2].Value = model.PluginVer;
			parameters[3].Value = model.FileSize;
			parameters[4].Value = model.PluginRemark;
			parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CreatorID;
            parameters[7].Value = model.Url;

            parameters[8].Value = modelx.Flow;
            parameters[9].Value = modelx.FlowStep;
            parameters[10].Value = modelx.CurrentUserID;
            parameters[11].Value = modelx.FlowRemark;
            parameters[12].Value = modelx.CurrentUserCount;
            parameters[13].Value = modelx.State;

            DbHelperSQL.RunProcedure("tbl_Plugins_Flows_Add", parameters, out rowsAffected);
            return rowsAffected > 0 ? true : false;
		}

		/// <summary>
		///  更新一条信息
		/// </summary>
        /// 
        public bool Update(PluginSys.Model.PluginsEntity model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@AppVer", SqlDbType.Int,4),
                    new SqlParameter("@MID", SqlDbType.NVarChar,10),
                    new SqlParameter("@PluginVer", SqlDbType.NVarChar,5),
                    new SqlParameter("@FileSize", SqlDbType.Int,4),
                    new SqlParameter("@PluginRemark", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),                    
                    new SqlParameter("@CreatorID", SqlDbType.Int,4),
                    new SqlParameter("@Url",SqlDbType.NVarChar,200),

                
};
            parameters[0].Value = model.AppVer;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.PluginVer;
            parameters[3].Value = model.FileSize;
            parameters[4].Value = model.PluginRemark;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CreatorID;
            parameters[7].Value = model.Url;

         
            DbHelperSQL.RunProcedure("tbl_Plugins_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
        /// <summary>
        ///  更新插件表和审批表信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelx"></param>
        /// <returns></returns>
        public bool Update(PluginSys.Model.PluginsEntity model, PluginSys.Model.FlowsEntity modelx)
		{
			int rowsAffected=0;
            SqlParameter[] parameters = {
                    new SqlParameter("@AppVer", SqlDbType.Int,4),
                    new SqlParameter("@MID", SqlDbType.NVarChar,10),
                    new SqlParameter("@PluginVer", SqlDbType.NVarChar,5),
                    new SqlParameter("@FileSize", SqlDbType.Int,4),
                    new SqlParameter("@PluginRemark", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),                    
                    new SqlParameter("@CreatorID", SqlDbType.Int,4),
                    new SqlParameter("@Url",SqlDbType.NVarChar,200),
                 


                    new SqlParameter("@Flow",SqlDbType.NVarChar,200),
                    new SqlParameter("@FlowStep",SqlDbType.Int,4),
                    new SqlParameter("@CurrentUserID",SqlDbType.Int,20),
                    new SqlParameter("@FlowRemark",SqlDbType.NVarChar,200),
                    new SqlParameter("@CurrentUserCount",SqlDbType.Int,4),
                    new SqlParameter("@State",SqlDbType.NVarChar,50)
};
            parameters[0].Value = model.AppVer;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.PluginVer;
            parameters[3].Value = model.FileSize;
            parameters[4].Value = model.PluginRemark;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CreatorID;
            parameters[7].Value = model.Url;
           

            parameters[8].Value = modelx.Flow;
            parameters[9].Value = modelx.FlowStep;
            parameters[10].Value = modelx.CurrentUserID;
            parameters[11].Value = modelx.FlowRemark;
            parameters[12].Value = modelx.CurrentUserCount;
            parameters[13].Value = modelx.State;
            DbHelperSQL.RunProcedure("tbl_Plugins_Flows_Update", parameters, out rowsAffected);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
/****************************************************************************/
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int F_ID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
								};
            parameters[0].Value = F_ID;
			DbHelperSQL.RunProcedure("tbl_Plugins_Delete",parameters,out rowsAffected);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PluginSys.Model.PluginsEntity GetModel(string MID,int AppVer)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.NVarChar,10),
					new SqlParameter("@AppVer", SqlDbType.Int,4)			};
            parameters[0].Value = MID;
			parameters[1].Value = AppVer;

			PluginSys.Model.PluginsEntity model=new PluginSys.Model.PluginsEntity();
			DataSet ds= DbHelperSQL.RunProcedure("tbl_Plugins_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
        public PluginSys.Model.PluginsEntity GetModel(int FID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@F_ID", SqlDbType.Int,10)
                               };
            parameters[0].Value = FID;
        

            PluginSys.Model.PluginsEntity model = new PluginSys.Model.PluginsEntity();
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Plugins_GetModel_byF_ID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public DataSet GetDraft(int CreatorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM tbl_Plugins inner join tbl_Flows on tbl_Plugins.F_ID=tbl_Flows.F_ID");
            strSql.Append(" where CreatorID="+CreatorID+"and State='Draft'");
            
            return DbHelperSQL.Query(strSql.ToString());
              }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PluginSys.Model.PluginsEntity DataRowToModel(DataRow row)
		{
			PluginSys.Model.PluginsEntity model=new PluginSys.Model.PluginsEntity();
			if (row != null)
			{
				if(row["PligunID"]!=null && row["PligunID"].ToString()!="")
				{
					model.PligunID=int.Parse(row["PligunID"].ToString());
				}
                if (row["CreatorID"] != null && row["CreatorID"].ToString() != "")
                {
                    model.CreatorID = int.Parse(row["CreatorID"].ToString());
                }
				if(row["AppVer"]!=null && row["AppVer"].ToString()!="")
				{
					model.AppVer=int.Parse(row["AppVer"].ToString());
				}
				if(row["MID"]!=null)
				{
					model.MID=row["MID"].ToString();
				}			
				if(row["PluginVer"]!=null)
				{
					model.PluginVer=row["PluginVer"].ToString();
				}
				if(row["FileSize"]!=null && row["FileSize"].ToString()!="")
				{
					model.FileSize=int.Parse(row["FileSize"].ToString());
				}
				if(row["PluginRemark"]!=null)
				{
					model.PluginRemark=row["PluginRemark"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["F_ID"]!=null && row["F_ID"].ToString()!="")
				{
					model.F_ID=int.Parse(row["F_ID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PligunID,AppVer,MID,PluginVer,FileSize,PluginRemark,CreateTime,F_ID,Url,CreatorID");
			strSql.Append(" FROM tbl_Plugins ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" PligunID,AppVer,MID,PluginName,PluginVer,FileSize,Remark,CreateTime,F_ID ");
			strSql.Append(" FROM tbl_Plugins ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tbl_Plugins ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby );
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.AppVer desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from tbl_Plugins T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(string MID,string appVer, int pageSize, int currentIndex, string State,out int Count)
		{  
            int AppVer;
            if (appVer == null)
            {
                AppVer = 0;
            }
            else
            {
                AppVer = int.Parse(appVer);
            }
            Count = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@Count", SqlDbType.Int,4),    
                    new SqlParameter("@pageSize", SqlDbType.Int,4),
                    new SqlParameter("@startIndex", SqlDbType.Int,4),
                    new SqlParameter("@MID",  SqlDbType.NVarChar,10),                    
					new SqlParameter("@AppVer",SqlDbType.Int,4) ,
                    new SqlParameter("@State",SqlDbType.NVarChar,10)
			};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = pageSize;
            parameters[2].Value = currentIndex;
            parameters[3].Value = MID;
            parameters[4].Value = AppVer;
            parameters[5].Value = State;
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Plugins_GetListByPage", parameters, "ds");
            Count = (int)parameters[0].Value;
            return ds;
		}
       
		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

