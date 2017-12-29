using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;


namespace PluginSys.BLL
{
    public class BaseBLL
    {
        /// <summary>
        /// 校验token
        /// </summary>
        /// <returns></returns>
        public bool VaildToken(int UserID, string AccessToken)
        {
            // TODO 这里校验token身份，还可以计数IP请求次数 拒绝请求
          /*  UsersBLL bll = new UsersBLL();
            if (AccessToken== bll.GetModel(UserID).AccessToken)
            {
                return true;
            }  */
            if (true)
            {
                return true; 
            }
            else
            {
                throw new Exception("vaild faild");
            }
        }

        /// <summary>
        /// 生成token
        /// </summary>
        /// <returns></returns>
        public string CreateToken()
        {
            string token = Guid.NewGuid().ToString();
            token = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(token, "MD5");
            return token;
        }

        public List<T> PutAllVal<T>(DataSet ds) where T : new()
        {
            List<T> lists = new List<T>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lists.Add(PutVal<T>(row));
                }
            }
            return lists;
        }
        private T PutVal<T>(DataRow row) where T : new()
        {  
            //初始化 如果为null           
            T entity = new T();
            //得到类型
            Type type = typeof(T);
            //取得属性集合
            PropertyInfo[] pi = type.GetProperties();
            foreach (PropertyInfo item in pi)
            {
                if (row.Table.Columns.Contains(item.Name))
                {
                    //给属性赋值
                    if (row[item.Name] != null && row[item.Name] != DBNull.Value)
                    {
                       if (item.PropertyType == typeof(System.DateTime))
                        {                        
                            item.SetValue(entity, Convert.ToDateTime(row[item.Name].ToString()), null);
                        }
                        else
                        { 
                            if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                            {
                                item.SetValue(entity, Convert.ChangeType(row[item.Name], Nullable.GetUnderlyingType(item.PropertyType)), null);
                            }
                            else
                            {
                                item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                            }
                        }
                    }
                }
            }
            return entity;
        }

    }
}

