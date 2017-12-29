using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Security.Principal;
using System.Windows.Forms;


namespace Maticsoft.Common
{
    /// <summary>        
    /// Description: Abstract class to implementation common operation.
    /// </summary>
    internal class AbstractLog : ILog
    {
        public virtual void WriteEntry(string message, LogLevels logLevel)
        {
        }

        public virtual void WriteEntry(string message, Exception ex, LogLevels logLevel)
        {
        }

        protected virtual string GetCustomErrStr(Exception e)
        {
            StringBuilder rtnSB = new StringBuilder();

            rtnSB.AppendLine("***Error Message***");
            rtnSB.AppendLine(e.Message);

            StackTrace st = new StackTrace(e, true);
            rtnSB.AppendLine("***Stack Frame***");
            Exception InnEx;

            foreach (StackFrame sf in st.GetFrames())   //Modify By XianJun
            {
                if (sf.GetFileLineNumber().ToString() == "0")
                {
                    rtnSB.AppendFormat("Filename : {0},  Method Name : {1}", "System API", sf.GetMethod().Name);
                }
                else
                {
                    rtnSB.AppendFormat("Filename : {0}, Line Number : {1}, Method Name : {2}", sf.GetFileName(), sf.GetFileLineNumber().ToString(), sf.GetMethod().Name);
                }
                rtnSB.AppendLine();
            }
            rtnSB.AppendLine("***Inner Exception Message***");
            InnEx = e.InnerException;
            while (InnEx != null)
            {
                rtnSB.AppendFormat("MESSAGE: {0}, SOURCE: {1}", InnEx.Message, InnEx.Source);
                rtnSB.AppendLine();
                InnEx = InnEx.InnerException;
            }
            rtnSB.AppendLine("***Custom Data***");


            IEnumerator CustList = e.Data.Keys.GetEnumerator(); //Getting the Enumerator

            CustList.Reset();

            while (CustList.MoveNext())
            {
                rtnSB.AppendFormat("Key : {0}, Value : {1}", CustList.Current.ToString(), e.Data[CustList.Current.ToString()]);
                rtnSB.AppendLine();
            }

            return rtnSB.ToString();
        }

        protected virtual string GetAppInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ProductName : {0}", Application.ProductName);
            sb.AppendLine();
            sb.AppendFormat("ProductVersion : {0}", Application.ProductVersion);
            sb.AppendLine();
            sb.AppendFormat("ExecutablePath : {0}", Application.ExecutablePath);
            sb.AppendLine();
            sb.AppendFormat("OS Version : {0}", Environment.OSVersion);
            sb.AppendLine();
            sb.AppendFormat(".NET Runtime Version : {0}", Environment.Version.ToString());
            sb.AppendLine();
            sb.AppendFormat("Windows Logon User ID : {0}", WindowsIdentity.GetCurrent().Name);
            sb.AppendLine();
            sb.AppendFormat("Current Thread User ID : {0}", System.Windows.Forms.SystemInformation.UserName);
            sb.AppendLine();
            sb.AppendFormat("ComputerName : {0}", System.Windows.Forms.SystemInformation.ComputerName);
            sb.AppendLine();
            sb.AppendFormat("CurrentCulture : {0}", Application.CurrentCulture.ToString());
            sb.AppendLine();
            sb.AppendFormat("CurrentInputLanguage : {0}", Application.CurrentInputLanguage.Culture.ToString());
            sb.AppendLine();
            sb.AppendFormat("Network available : {0}", System.Windows.Forms.SystemInformation.Network);
            sb.AppendLine();
            return sb.ToString();

        }
    }
}
