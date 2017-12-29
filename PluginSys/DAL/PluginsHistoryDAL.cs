using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PluginSys.DAL
{
    /// <summary>
    /// 数据访问类:PluginsHistory
    /// </summary>
    public partial class PluginsHistoryDAL
    {
        public PluginsHistoryDAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("PligunID", "tbl_PluginsHistory");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PligunID, int AppVer)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@PligunID", SqlDbType.Int,4),
					new SqlParameter("@AppVer", SqlDbType.Int,4)			};
            parameters[0].Value = PligunID;
            parameters[1].Value = AppVer;

            int result = DbHelperSQL.RunProcedure("tbl_PluginsHistory_Exists", parameters, out rowsAffected);
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
        public bool Add(PluginSys.Model.PluginsHistoryEntity model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AppVer", SqlDbType.Int,4),
					new SqlParameter("@MID", SqlDbType.NVarChar,10),
					new SqlParameter("@PluginVer", SqlDbType.NVarChar,5),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@F_ID", SqlDbType.Int,4),
                    new SqlParameter("@CreatorID", SqlDbType.Int,4)};
            parameters[0].Value = model.AppVer;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.PluginVer;
            parameters[3].Value = model.FileSize;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.F_ID;
            parameters[7].Value = model.CreatorID;
            DbHelperSQL.RunProcedure("tbl_PluginsHistory_ADD", parameters, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(PluginSys.Model.PluginsHistoryEntity model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@AppVer", SqlDbType.Int,4),
					new SqlParameter("@MID", SqlDbType.NVarChar,10),
					new SqlParameter("@PluginVer", SqlDbType.NVarChar,5),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.AppVer;
            parameters[1].Value = model.MID;
            parameters[3].Value = model.PluginVer;
            parameters[4].Value = model.FileSize;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.F_ID;

            DbHelperSQL.RunProcedure("tbl_PluginsHistory_Update", parameters, out rowsAffected);
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
        public bool Delete(int PligunID, int AppVer)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@PligunID", SqlDbType.Int,4),
					new SqlParameter("@AppVer", SqlDbType.Int,4)			};
            parameters[0].Value = PligunID;
            parameters[1].Value = AppVer;

            DbHelperSQL.RunProcedure("tbl_PluginsHistory_Delete", parameters, out rowsAffected);
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
        public PluginSys.Model.PluginsHistoryEntity GetModel(int PligunID, int AppVer)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PligunID", SqlDbType.Int,4),
					new SqlParameter("@AppVer", SqlDbType.Int,4)			};
            parameters[0].Value = PligunID;
            parameters[1].Value = AppVer;

            PluginSys.Model.PluginsHistoryEntity model = new PluginSys.Model.PluginsHistoryEntity();
            DataSet ds = DbHelperSQL.RunProcedure("tbl_PluginsHistory_GetModel", parameters, "ds");
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
        public PluginSys.Model.PluginsHistoryEntity DataRowToModel(DataRow row)
        {
            PluginSys.Model.PluginsHistoryEntity model = new PluginSys.Model.PluginsHistoryEntity();
            if (row != null)
            {
                if (row["PligunID"] != null && row["PligunID"].ToString() != "")
                {
                    model.PligunID = int.Parse(row["PligunID"].ToString());
                }
                if (row["AppVer"] != null && row["AppVer"].ToString() != "")
                {
                    model.AppVer = int.Parse(row["AppVer"].ToString());
                }
                if (row["MID"] != null)
                {
                    model.MID = row["MID"].ToString();
                }
           
                if (row["PluginVer"] != null)
                {
                    model.PluginVer = row["PluginVer"].ToString();
                }
                if (row["FileSize"] != null && row["FileSize"].ToString() != "")
                {
                    model.FileSize = int.Parse(row["FileSize"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["F_ID"] != null && row["F_ID"].ToString() != "")
                {
                    model.F_ID = int.Parse(row["F_ID"].ToString());
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
            strSql.Append("select PligunID,AppVer,MID,PluginName,PluginVer,FileSize,Remark,CreateTime,F_ID ");
            strSql.Append(" FROM tbl_PluginsHistory ");
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
            strSql.Append(" PligunID,AppVer,MID,PluginName,PluginVer,FileSize,Remark,CreateTime,F_ID ");
            strSql.Append(" FROM tbl_PluginsHistory ");
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
            strSql.Append("select count(1) FROM tbl_PluginsHistory ");
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
                strSql.Append("order by T.AppVer desc");
            }
            strSql.Append(")AS Row, T.*  from tbl_PluginsHistory T ");
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
            parameters[0].Value = "tbl_PluginsHistory";
            parameters[1].Value = "AppVer";
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

