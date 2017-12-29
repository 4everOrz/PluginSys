using System;
namespace PluginSys.Model
{
	/// <summary>
	/// PluginsHistory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PluginsHistoryEntity
	{
		public PluginsHistoryEntity()
		{}
		#region Model
		private int _pligunid;
		private int _appver;
		private string _mid;
		private string _pluginver;
		private int _filesize;
		private string _remark;
		private DateTime _createtime;
		private int _f_id;
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
		public string Remark
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
		/// <summary>
		/// 
		/// </summary>
		public int F_ID
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		#endregion Model
        public int CreatorID { get; set; }
	}
}

