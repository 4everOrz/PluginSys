using System;

namespace PluginSys.Model
{
	/// <summary>
	/// Plugins:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PluginsEntity
	{
		public PluginsEntity()
		{}
		#region Model
		private int _pligunid;
		private int _appver;
		private string _mid;
		private string _pluginver;
		private int _filesize;
		private string _pluginremark;
		private DateTime _createtime;
        private int _creatorid;

       private int _f_id;
        private string _url;
     /*    private int _currentusercount;
        private string _flowremark;
        private int _flowstep;
        private int _currentuserid;
        private string _flow;
        private string _result;*/
        /// <summary>
        /// 
        /// </summary>
        public int PligunID
		{
			set{ _pligunid=value;}
			get{return _pligunid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AppVer
		{
			set{ _appver=value;}
			get{return _appver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MID
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PluginVer
		{
			set{ _pluginver=value;}
			get{return _pluginver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FileSize
		{
			set{ _filesize=value;}
			get{return _filesize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PluginRemark
		{
			set{ _pluginremark=value;}
			get{return _pluginremark;}
		}
      
		/// <summary>
		/// 
		/// </summary> 
      
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_ID
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        public int CreatorID
        {
            set { _creatorid= value; }
            get { return _creatorid; }
        
        }
       
     /**************************************************
      * public int CurrentUserID
        {
            set { _currentuserid = value; }
            get { return _currentuserid; }
        } 
        public int FlowStep
        {
            set { _flowstep = value; }
            get { return _flowstep; }
        }
       public string FlowRemark
        {
            set { _flowremark = value; }
            get { return _flowremark; }
        }
        public int CurrentUserCount
        {
            set { _currentusercount = value; }
            get { return _currentusercount; }
        }
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        public string Flow
        {
            set { _flow = value; }
            get { return _flow; }
        }
        #endregion Model

        public int CreatorID { get; set; }*/

	}
}

#endregion