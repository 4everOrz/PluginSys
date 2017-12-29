using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginSys.Model
{
    [Serializable]
  public  class ApproveHistoryEntity
    {
        #region Model
        private int _approveid;
        private int _fid;
        private int _userid;
        private string _username;
        private string _opinion;
        private string _approveremark;
        private DateTime _creatime;

        public int ApproveID
        {
            set { _approveid = value; }
            get { return _approveid; }
        }
        public int F_ID
        {
            set { _fid = value; }
            get { return _fid; }
        }
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        public string ApproveUserName
        {
            set { _username = value; }
            get { return _username; }
        }
        public string Opinion
        {
            set { _opinion = value; }
            get { return _opinion; }
        }
        public string ApproveRemark
        {
            set { _approveremark = value; }
            get { return _approveremark; }
        }
        public DateTime ApproveTime
        {
            set { _creatime = value; }
            get { return _creatime; }
        }
     #endregion model


    }
}
