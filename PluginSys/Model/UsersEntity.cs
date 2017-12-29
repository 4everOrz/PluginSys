using System;
using PluginSys.Model.Response;
namespace PluginSys.Model
{
	/// <summary>
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UsersEntity
	{
		public UsersEntity()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _password;
		private string _mail;
		private string _accesstoken;
		private bool _sex;
		private string _telphone;
		private int? _departmentid;
		private int? _roleid;
		private string _remark;
		private DateTime _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mail
		{
			set{ _mail=value;}
			get{return _mail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccessToken
		{
			set{ _accesstoken=value;}
			get{return _accesstoken;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telphone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
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
		#endregion Model

	}
}

