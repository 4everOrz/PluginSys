using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PluginSys.DAL
{
    /// <summary>
    /// 数据访问类:Config
    /// </summary>
    public partial class ConfigDAL
    {
        public ConfigDAL()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Cfg_Key)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@Cfg_Key", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Cfg_Key;

            int result = DbHelperSQL.RunProcedure("tbl_Config_Exists", parameters, out rowsAffected);
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
        public bool Add(PluginSys.Model.ConfigEntity model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@Cfg_Key", SqlDbType.NVarChar,50),
					new SqlParameter("@Cfg_Val", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.Cfg_Key;
            parameters[1].Value = model.Cfg_Val;

            DbHelperSQL.RunProcedure("tbl_Config_ADD", parameters, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(PluginSys.Model.ConfigEntity model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@Cfg_Key", SqlDbType.NVarChar,50),
					new SqlParameter("@Cfg_Val", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.Cfg_Key;
            parameters[1].Value = model.Cfg_Val;

            DbHelperSQL.RunProcedure("tbl_Config_Update", parameters, out rowsAffected);
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
        public bool Delete(string Cfg_Key)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@Cfg_Key", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Cfg_Key;

            DbHelperSQL.RunProcedure("tbl_Config_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string Cfg_Keylist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_Config ");
            strSql.Append(" where Cfg_Key in (" + Cfg_Keylist + ")  ");
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
        public PluginSys.Model.ConfigEntity GetModel(string Cfg_Key)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Cfg_Key", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Cfg_Key;

            PluginSys.Model.ConfigEntity model = new PluginSys.Model.ConfigEntity();
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Config_GetModel", parameters, "ds");
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
        public PluginSys.Model.ConfigEntity DataRowToModel(DataRow row)
        {
            PluginSys.Model.ConfigEntity model = new PluginSys.Model.ConfigEntity();
            if (row != null)
            {
                if (row["Cfg_Key"] != null)
                {
                    model.Cfg_Key = row["Cfg_Key"].ToString();
                }
                if (row["Cfg_Val"] != null)
                {
                    model.Cfg_Val = row["Cfg_Val"].ToString();
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
            strSql.Append("select Cfg_Key,Cfg_Val ");
            strSql.Append(" FROM tbl_Config ");
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
            strSql.Append(" Cfg_Key,Cfg_Val ");
            strSql.Append(" FROM tbl_Config ");
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
            strSql.Append("select count(1) FROM tbl_Config ");
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
                strSql.Append("order by T.Cfg_Key desc");
            }
            strSql.Append(")AS Row, T.*  from tbl_Config T ");
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
            parameters[0].Value = "tbl_Config";
            parameters[1].Value = "Cfg_Key";
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

