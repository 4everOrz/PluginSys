using System;
namespace PluginSys.Model
{
	/// <summary>
	/// Departments:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DepartmentsEntity
	{
		public DepartmentsEntity()
		{}
		#region Model
		private int _departmentid;
		private string _departmentname;
		private int? _departlevel;
		private int? _parentid;
		private DateTime? _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DepartLevel
		{
			set{ _departlevel=value;}
			get{return _departlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

