using System;
using System.Configuration;
using System.Reflection;
namespace DataHelper
{
    public class DataFactory
    {
        /// <summary>
        /// 获取数据类型1为sqlserver,2为access
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        
       

        public static DbHelper GetHelper()
        {
            string ConnStr = ConfigurationSettings.AppSettings["ConnStr"].ToString();
            
            string  datatype = string.Empty;
            datatype = ConfigurationSettings.AppSettings["DbType"].ToString().ToLower();
 
            switch (datatype)
            {
                case "sqlserver":
                    return new SqlHelper(ConnStr);
                    break;
                case "oledb":
                    return new OledbHelper(ConnStr);
                default:
                    return new SqlHelper(ConnStr);
                    break;
            }
        }


    }
}
