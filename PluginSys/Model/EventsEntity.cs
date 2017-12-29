using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginSys.Model
{
 public  partial class EventsEntity
    {	public EventsEntity()
		{}
		#region Model
		private int _eventid;
		private int _userid;
		private string _username;
		private string _eventremark;
		private DateTime _createtime;
      
		/// <summary>
		/// 
		/// </summary>
		public int EventID
		{
            set { _eventid = value; }
            get { return _eventid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
            set { _userid = value; }
            get { return _userid; }
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
		public string EventRemark
		{
			set{ _eventremark=value;}
			get{return _eventremark;}
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
