using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;

namespace PluginSys.DAL
{
	/// <summary>
	/// 数据访问类:Users
	/// </summary>
	public partial class UsersDAL
	{
		public UsersDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UserID", "tbl_Users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

			int result= DbHelperSQL.RunProcedure("tbl_Users_Exists",parameters,out rowsAffected);
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
		public DataSet Add(PluginSys.Model.UsersEntity model)
		{
		 
			SqlParameter[] parameters = {
					
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,100),
					new SqlParameter("@Mail", SqlDbType.NVarChar,50),
					new SqlParameter("@AccessToken", SqlDbType.NVarChar,100),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Telphone", SqlDbType.NVarChar,20),
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.Mail;
			parameters[3].Value = model.AccessToken;
			parameters[4].Value = model.Sex;
			parameters[5].Value = model.Telphone;
			parameters[6].Value = model.DepartmentID;
			parameters[7].Value = model.RoleID;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.CreateTime;

            DataSet ds = DbHelperSQL.RunProcedure("tbl_Users_ADD", parameters, "ds");
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                 return ds;
            }
            else
            {
                return null;
            }
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(PluginSys.Model.UsersEntity model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,100),
					new SqlParameter("@Mail", SqlDbType.NVarChar,50),
					new SqlParameter("@AccessToken", SqlDbType.NVarChar,100),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Telphone", SqlDbType.NVarChar,20),
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.Mail;
			parameters[4].Value = model.AccessToken;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.Telphone;
			parameters[7].Value = model.DepartmentID;
			parameters[8].Value = model.RoleID;
			parameters[9].Value = model.Remark;
			parameters[10].Value = model.CreateTime;

			DbHelperSQL.RunProcedure("tbl_Users_Update",parameters,out rowsAffected);
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
		public bool Delete(int UserID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

			DbHelperSQL.RunProcedure("tbl_Users_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbl_Users ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
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
		public PluginSys.Model.UsersEntity GetModel(int UserID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

			PluginSys.Model.UsersEntity model=new PluginSys.Model.UsersEntity();
			DataSet ds= DbHelperSQL.RunProcedure("tbl_Users_GetModel",parameters,"ds");
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
		public PluginSys.Model.UsersEntity DataRowToModel(DataRow row)
		{
			PluginSys.Model.UsersEntity model=new PluginSys.Model.UsersEntity();
			if (row != null)
			{
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["Mail"]!=null)
				{
					model.Mail=row["Mail"].ToString();
				}
				if(row["AccessToken"]!=null)
				{
					model.AccessToken=row["AccessToken"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					if((row["Sex"].ToString()=="1")||(row["Sex"].ToString().ToLower()=="true"))
					{
						model.Sex=true;
					}
					else
					{
						model.Sex=false;
					}
				}
				if(row["Telphone"]!=null)
				{
					model.Telphone=row["Telphone"].ToString();
				}
				if(row["DepartmentID"]!=null && row["DepartmentID"].ToString()!="")
				{
					model.DepartmentID=int.Parse(row["DepartmentID"].ToString());
				}
				if(row["RoleID"]!=null && row["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(row["RoleID"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select UserID,UserName,Password,Mail,AccessToken,Sex,Telphone,DepartmentID,RoleID,Remark,CreateTime ");
			strSql.Append(" FROM tbl_Users ");
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
			strSql.Append(" UserID,UserName,Password,Mail,AccessToken,Sex,Telphone,DepartmentID,RoleID,Remark,CreateTime ");
			strSql.Append(" FROM tbl_Users ");
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
			strSql.Append("select count(1) FROM tbl_Users ");
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
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from tbl_Users T ");
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
			parameters[0].Value = "tbl_Users";
			parameters[1].Value = "UserID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
		#region  MethodEx
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataSet GetDSByLogin(string account,string psw,string token)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@account", SqlDbType.NVarChar,50),
                    new SqlParameter("@password", SqlDbType.NVarChar,100),
                    new SqlParameter("@token", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = account;
            parameters[1].Value = psw;
            parameters[2].Value = token;
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Users_GetModel_byLogin", parameters, "ds");
            return ds;
        }

        /// <summary>
        /// 得到记录的总数（存储过程）
        /// </summary>
       public int Getcount( string Mail, string Telphone)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Mail", SqlDbType.NVarChar,50),
                    new SqlParameter("@Telphone", SqlDbType.NVarChar,20),
			};
            parameters[0].Value =Mail;  
            parameters[1].Value = Telphone;
            int result = DbHelperSQL.RunProcedureC("tbl_Users_Getcount", parameters);
            return result;
        }
       public DataSet GetUserNameList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("SELECT UserID,UserName,DepartmentName");
           strSql.Append(" FROM tbl_Users U INNER JOIN tbl_Departments D ON U.DepartmentID=D.DepartmentID ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" WHERE " + strWhere);
           }
           return DbHelperSQL.Query(strSql.ToString());
       }

		#endregion  MethodEx
	}
}

