using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PluginSys.DAL
{
    /// <summary>
    /// 数据访问类:Departments
    /// </summary>
    public partial class DepartmentsDAL
    {
        public DepartmentsDAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("DepartmentID", "tbl_Departments");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DepartmentID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4)
			};
            parameters[0].Value = DepartmentID;

            int result = DbHelperSQL.RunProcedure("tbl_Departments_Exists", parameters, out rowsAffected);
            if (result == 1)
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
        public int Add(PluginSys.Model.DepartmentsEntity model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,50),
					new SqlParameter("@DepartLevel", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.DepartmentName;
            parameters[2].Value = model.DepartLevel;
            parameters[3].Value = model.ParentID;
            parameters[4].Value = model.CreateTime;

            DbHelperSQL.RunProcedure("tbl_Departments_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(PluginSys.Model.DepartmentsEntity model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,50),
					new SqlParameter("@DepartLevel", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.DepartmentID;
            parameters[1].Value = model.DepartmentName;
            parameters[2].Value = model.DepartLevel;
            parameters[3].Value = model.ParentID;
            parameters[4].Value = model.CreateTime;

            DbHelperSQL.RunProcedure("tbl_Departments_Update", parameters, out rowsAffected);
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
        public bool Delete(int DepartmentID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4)
			};
            parameters[0].Value = DepartmentID;

            DbHelperSQL.RunProcedure("tbl_Departments_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string DepartmentIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_Departments ");
            strSql.Append(" where DepartmentID in (" + DepartmentIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public PluginSys.Model.DepartmentsEntity GetModel(int DepartmentID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4)
			};
            parameters[0].Value = DepartmentID;

            PluginSys.Model.DepartmentsEntity model = new PluginSys.Model.DepartmentsEntity();
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Departments_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
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
        public PluginSys.Model.DepartmentsEntity DataRowToModel(DataRow row)
        {
            PluginSys.Model.DepartmentsEntity model = new PluginSys.Model.DepartmentsEntity();
            if (row != null)
            {
                if (row["DepartmentID"] != null && row["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
                if (row["DepartmentName"] != null)
                {
                    model.DepartmentName = row["DepartmentName"].ToString();
                }
                if (row["DepartLevel"] != null && row["DepartLevel"].ToString() != "")
                {
                    model.DepartLevel = int.Parse(row["DepartLevel"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select DepartmentID,DepartmentName,DepartLevel,ParentID,CreateTime ");
            strSql.Append("select DepartmentID,DepartmentName");
            strSql.Append(" FROM tbl_Departments ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" DepartmentID,DepartmentName,DepartLevel,ParentID,CreateTime ");
            strSql.Append(" FROM tbl_Departments ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tbl_Departments ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.DepartmentID desc");
            }
            strSql.Append(")AS Row, T.*  from tbl_Departments T ");
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
            parameters[0].Value = "tbl_Departments";
            parameters[1].Value = "DepartmentID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

