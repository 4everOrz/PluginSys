using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace PluginSys.DAL
{
    public partial class EventsDAL
    {
        public EventsDAL()
        { }
        #region  Method


        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(int F_ID,string EventRemark)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@EventID", SqlDbType.Int,4),                   
					new SqlParameter("@F_ID", SqlDbType.Int,4),
					new SqlParameter("@EventRemark", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)
                                        };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = F_ID;
            parameters[2].Value = EventRemark;
            parameters[3].Value =DateTime.Now;

            DbHelperSQL.RunProcedure("tbl_Events_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }


        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(int F_ID, int UserID, string EventRemark)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                                            
                    new SqlParameter("@F_ID", SqlDbType.Int,4),  
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@EventRemark", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)
				          };
            parameters[0].Value =F_ID;
            parameters[1].Value = UserID;
            parameters[2].Value = EventRemark;
            parameters[3].Value = DateTime.Now;
            DbHelperSQL.RunProcedure("tbl_Events_Update", parameters, out rowsAffected);
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
        public bool Delete(int EventID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@EventID", SqlDbType.Int,4)
			};
            parameters[0].Value = EventID;

            DbHelperSQL.RunProcedure("tbl_Events_Delete", parameters, out rowsAffected);
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
        public PluginSys.Model.EventsEntity GetModel(int EventID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@EventID", SqlDbType.Int,4)
			};
            parameters[0].Value = EventID;

            PluginSys.Model.EventsEntity model = new PluginSys.Model.EventsEntity();
            DataSet ds = DbHelperSQL.RunProcedure("tbl_Events_GetModel", parameters, "ds");
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
        public PluginSys.Model.EventsEntity DataRowToModel(DataRow row)
        {
            PluginSys.Model.EventsEntity model = new PluginSys.Model.EventsEntity();
            if (row != null)
            {
                if (row["EventID"] != null && row["EventID"].ToString() != "")
                {
                    model.EventID = int.Parse(row["EventID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null && row["UserName"].ToString() != "")
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["EventRemark"] != null && row["EventRemark"].ToString() != "")
                {
                    model.EventRemark = row["EventRemark"].ToString();
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
            strSql.Append("select  E.EventID,E.UserName,E.UserID,E.EventRemark,E.CreateTime,F.F_ID,P.MID");
            strSql.Append(" FROM tbl_Events E INNER JOIN tbl_Flows F ON E.EventID=F.EventID INNER JOIN tbl_Plugins P ON F.F_ID=P.F_ID ");
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
            strSql.Append("  EventID,UserName,UserID,EventRemark,CreateTime");
            strSql.Append(" FROM tbl_Events ");
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
            strSql.Append("select count(1) FROM tbl_Events ");
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
    }
}
