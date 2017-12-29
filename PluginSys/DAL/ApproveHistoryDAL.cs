using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace PluginSys.DAL
{
    public partial class ApproveHistoryDAL
    {
        public ApproveHistoryDAL()
        { }
        #region method

        public int Add(PluginSys.Model.ApproveHistoryEntity model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),                   
					new SqlParameter("@F_ID", SqlDbType.Int,4),
                    new SqlParameter("@Opinion", SqlDbType.NVarChar,10),               
					new SqlParameter("@ApproveRemark", SqlDbType.NVarChar,100),
					new SqlParameter("@ApproveTime", SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.F_ID;
            parameters[2].Value = model.Opinion;
            parameters[3].Value = model.ApproveRemark;
            parameters[4].Value = DateTime.Now;
            DbHelperSQL.RunProcedure("tbl_ApproveRemark_ADD", parameters, out rowsAffected);
            return rowsAffected;
        }
        public DataSet GetModel(int F_ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = F_ID;

            DataSet ds = DbHelperSQL.RunProcedure("tbl_ApproveHistory_GetModel", parameters, "ds");
           
                return ds;
           
        }
        #endregion method
    }
}

