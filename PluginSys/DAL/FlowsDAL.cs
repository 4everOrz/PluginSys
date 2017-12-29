using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PluginSys.DAL
{
	/// <summary>
	/// 数据访问类:Flows
	/// </summary>
	public partial class FlowsDAL
	{
		public FlowsDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "tbl_Flows"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			int result= DbHelperSQL.RunProcedure("tbl_Flows_Exists",parameters,out rowsAffected);
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
		public int Add(PluginSys.Model.FlowsEntity model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4),
					new SqlParameter("@Flow", SqlDbType.NVarChar,500),
					new SqlParameter("@FlowStep", SqlDbType.Int,4),
					new SqlParameter("@CurrentUserID", SqlDbType.Int,4),
					new SqlParameter("@PluginRemark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@CurrentUserCount", SqlDbType.Int,4)                  };
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.Flow;
			parameters[2].Value = model.FlowStep;
			parameters[3].Value = model.CurrentUserID;
			parameters[4].Value = model.FlowRemark;
			parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CurrentUserCount; 
			DbHelperSQL.RunProcedure("tbl_Flows_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(PluginSys.Model.FlowsEntity model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4),
					new SqlParameter("@Flow", SqlDbType.NVarChar,500),
					new SqlParameter("@FlowStep", SqlDbType.Int,4),
					new SqlParameter("@CurrentUserID", SqlDbType.Int,4),
					new SqlParameter("@PluginRemark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@CurrentUserCount", SqlDbType.Int,4)  };
			parameters[0].Value = model.F_ID;
			parameters[1].Value = model.Flow;
			parameters[2].Value = model.FlowStep;
			parameters[3].Value = model.CurrentUserID;
            parameters[4].Value = model.FlowRemark;
			parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CurrentUserCount; 
			DbHelperSQL.RunProcedure("tbl_Flows_Update",parameters,out rowsAffected);
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
/// 更新草稿状态
/// </summary>
/// <param name="model"></param>
/// <returns></returns>
        public bool Update(int F_ID,string State)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4),
                    new SqlParameter("@State",SqlDbType.NVarChar,50)
					  };
            parameters[0].Value =F_ID;
            parameters[1].Value = State;
            DbHelperSQL.RunProcedure("tbl_Flows_StateUpdate", parameters, out rowsAffected);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int F_ID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			DbHelperSQL.RunProcedure("tbl_Flows_Delete",parameters,out rowsAffected);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string F_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbl_Flows ");
			strSql.Append(" where F_ID in ("+F_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
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
		public PluginSys.Model.FlowsEntity GetModel(int F_ID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			DataSet ds= DbHelperSQL.RunProcedure("tbl_Flows_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PluginSys.Model.FlowsEntity DataRowToModel(DataRow row)
		{
			PluginSys.Model.FlowsEntity model=new PluginSys.Model.FlowsEntity();
			if (row != null)
			{
				if(row["F_ID"]!=null && row["F_ID"].ToString()!="")
				{
					model.F_ID=int.Parse(row["F_ID"].ToString());
				}
				if(row["Flow"]!=null)
				{
					model.Flow=row["Flow"].ToString();
				}
				if(row["FlowStep"]!=null && row["FlowStep"].ToString()!="")
				{
					model.FlowStep=int.Parse(row["FlowStep"].ToString());
				}
				if(row["CurrentUserID"]!=null && row["CurrentUserID"].ToString()!="")
				{
					model.CurrentUserID=int.Parse(row["CurrentUserID"].ToString());
				}
				if(row["FlowRemark"]!=null)
				{
					model.FlowRemark=row["FlowRemark"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
                if (row["CurrentUserCount"] != null && row["CurrentUserCount"].ToString() != "")
                {
                    model.CurrentUserCount = int.Parse(row["CurrentUserCount"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = row["State"].ToString();
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
			strSql.Append("select F_ID,Flow,FlowStep,CurrentUserID,FlowRemark,CreateTime,CurrentUserCount ");
			strSql.Append(" FROM tbl_Flows ");
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
			strSql.Append(" F_ID,Flow,FlowStep,CurrentUserID,FlowRemark,CreateTime,CurrentUserCount ");
			strSql.Append(" FROM tbl_Flows ");
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
			strSql.Append("select count(1) FROM tbl_Flows ");
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.F_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tbl_Flows T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tbl_Flows";
			parameters[1].Value = "F_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
		#region  MethodEx
        /*************************************************************/
        public DataSet GetPluginModel(int CurrentUserID)
        {
              string Sql = "";
              int COUNT= GetList(CurrentUserID).Count;
              for (int a = 0; a < COUNT; a++)
              {
                  if (a == 0)
                  {
                      Sql += ("F_ID='" + GetList(CurrentUserID)[a]+"'");
                  }
                  else
                  {
                      Sql += ("or F_ID='" + GetList(CurrentUserID)[a]+"'");
                  }  
              }
              PluginsDAL Pdal = new PluginsDAL();
                return Pdal.GetList(Sql);        
        }
        public List<string> GetList(int CurrentUserID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@CurrentUserID", SqlDbType.Int,4)
			};
            parameters[0].Value = CurrentUserID;

  
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Flows_GetFID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<string > intlist = new List<string>();
                for (int a = 0; a < (ds.Tables[0].Rows.Count); a++)
                {
                    intlist.Add(ds.Tables[0].Rows[a][0].ToString());//获取当前用户名下的Fid
                }
               

                return intlist;
            }
            else
            {
                return null;
            }
        
        
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentUserID"></param>
        /// <returns></returns>
        public DataSet GetListP(int UserID,int F_ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@CurrentUserID", SqlDbType.Int,4),
                    new SqlParameter("@F_ID",SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;
            parameters[1].Value =F_ID;
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Flows_GetPlugin", parameters, "ds");
            return ds;
          
        }
  
        public bool UpdateFlow(int F_ID, int FlowStep, int CurrentUserID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4),
                    new SqlParameter("@FlowStep",SqlDbType.Int,4),
                      new SqlParameter("@CurrentUserID",SqlDbType.Int,4)
			};
            parameters[0].Value = F_ID;
            parameters[1].Value = FlowStep;
            parameters[2].Value = CurrentUserID;
          
            int ds = DbHelperSQL.RunProcedure("tbl_Flows_UpdateStep", parameters, out rowsAffected);
            if (ds != 0)
            { return true; }
            else
            { return false; }         
        }
        public bool UpdateState(int F_ID,string State)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4),
                    new SqlParameter("@State",SqlDbType.NVarChar,50)
			};
            parameters[0].Value = F_ID;
            parameters[1].Value =State;
         
        
             DbHelperSQL.RunProcedure("tbl_Flows_UpdateResult", parameters, out rowsAffected);
             if (rowsAffected != 0)
            { return true; }
            else
            { return false; }            
        }
        public PluginSys.Model.FlowsEntity GetModel_byEventID(int EventID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@EventID", SqlDbType.Int,4)
			};
            parameters[0].Value = EventID;
           
         
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Flows_GetModel_byEventID", parameters, "ds");
            return DataRowToModel(ds.Tables[0].Rows[0]);
        }
        public PluginSys.Model.FlowsEntity GetModel(string MID,string AppVer)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.NVarChar,10),
                    new SqlParameter("@AppVer", SqlDbType.Int,4)
			};
            parameters[0].Value = MID;
            parameters[1].Value = AppVer;
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Flows_GetModel_byMIDAppVer", parameters, "ds");
            return DataRowToModel(ds.Tables[0].Rows[0]);
        }
/**********************************************************************************/
		#endregion  MethodEx
	}
}

