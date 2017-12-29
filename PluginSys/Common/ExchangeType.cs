using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    public class ExchangeType
    {

        public static bool Tobool(string num1)
        {
            if (num1 == "0")
            {
                bool num2 = false;
                return num2;
            }
            else
            {
                bool num2 = true;
                return num2;
            }

        }
        public static int Toint(string str)
        {
            int st = int.Parse(str);
            return st;
        }
        /// <summary>
        ///自定义拼合两段JSON序列化后的字符串（拼合截取字符串的方式),难看且暴力
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string FixJson1(string  str1,string str2)
        {
            string str3 = (str1.Replace("[", "").Replace("]", "").Replace("}", "") + ",") + (str2.Remove(0, 1) + "}");

            return str3;

        }
        public static string FixJson2(string str1, string str2)
        { 
        string str3 = (str1.Replace("[", "").Replace("]", "").Replace("}", ""))+str2+"}";
        return str3;
        
        }
    }
}
