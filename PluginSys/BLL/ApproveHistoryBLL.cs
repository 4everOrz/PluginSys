using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PluginSys.Model;
using PluginSys.Model.Response;
using System.Web;
using System.IO;
using System.Text;
namespace PluginSys.BLL
{
  public partial  class ApproveHistoryBLL:BaseBLL
    {
       private readonly PluginSys.DAL.ApproveHistoryDAL dal = new PluginSys.DAL.ApproveHistoryDAL();
      public ApproveHistoryBLL()
      { }
        #region method
      
      public bool ADD(int UserID,int F_ID,string Opinion,string ApproveRemark)
      {
          PluginSys.Model.ApproveHistoryEntity model = new ApproveHistoryEntity();
          model.UserID = UserID;
          model.F_ID = F_ID;
          model.Opinion = Opinion;
          model.ApproveRemark = ApproveRemark;        
          BaseResponseEntity<string> entity=new BaseResponseEntity<string>();
          if (dal.Add(model) != 0)
          {
              return true;
          }
          else 
          { 
              return false;
          }
          
      }
      public string GetModel(int F_ID)
      {   
          DataSet ds= dal.GetModel(F_ID) ;        
          List<ApproveHistoryEntity> list = base.PutAllVal<ApproveHistoryEntity>(ds);
          ApproveResponseEntity<List<ApproveHistoryEntity>> entity = new ApproveResponseEntity<List<ApproveHistoryEntity>>();
          if (list.Count != 0)
          {             
              entity.ApproveList = list;
          }
          else
          {             
              entity.ApproveList = null;
          }
          return JsonHelper.SerializeObject(entity);
      }

        #endregion method
    }
}
