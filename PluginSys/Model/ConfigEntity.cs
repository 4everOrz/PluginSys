using System;
namespace PluginSys.Model
{
	/// <summary>
	/// Config:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ConfigEntity
	{
		public ConfigEntity()
		{}
		#region Model
		private string _cfg_key;
		private string _cfg_val;
		/// <summary>
		/// 
		/// </summary>
		public string Cfg_Key
		{
			set{ _cfg_key=value;}
			get{return _cfg_key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Cfg_Val
		{
			set{ _cfg_val=value;}
			get{return _cfg_val;}
		}
		#endregion Model

	}
}

