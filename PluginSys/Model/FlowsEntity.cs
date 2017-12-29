using System;
namespace PluginSys.Model
{
	/// <summary>
	/// Flows:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FlowsEntity
	{
		public FlowsEntity()
		{}
		#region Model
		private int _f_id;
		private string _flow;
		private int _flowstep;
		private int _currentuserid;
		private string _remark;
		private DateTime _createtime;
        private int _currentusercount;
        private string _result;
		/// <summary>
		/// 
		/// </summary>
		public int F_ID
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Flow
		{
			set{ _flow=value;}
			get{return _flow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FlowStep
		{
			set{ _flowstep=value;}
			get{return _flowstep;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CurrentUserID
		{
			set{ _currentuserid=value;}
			get{return _currentuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FlowRemark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
        public int CurrentUserCount
        {
            set { _currentusercount = value;}
            get { return _currentusercount;}

        }
        public string State
        {
            set { _result = value; }
            get { return _result; }
        }
		#endregion Model

	}
}

