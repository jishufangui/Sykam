using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Reflection;
using DataHelper;
namespace TDAl
{
   public class DatabaseProvider
   {
       #region 变量
       private  string path = string.Empty;
       #endregion
      
       
       public DatabaseProvider()
       {
           path = ConfigurationSettings.AppSettings["DbType"].ToString().ToLower();//获取类路径
       }
       
     
       //通过配置获取dal
       public  INodeOperate GetNodeOperate()
       {
           string className = "TDAl."+path + ".NodeOperate";


           return (INodeOperate)Assembly.Load("TDAl").CreateInstance(className);
       
       }

       public IAddressOperate GetAddressOperate()
       {
           string className = "TDAl." + path + ".AddressOperate";
           return (IAddressOperate)Assembly.Load("TDAl").CreateInstance(className);
       }

       public IShopOperate GetShopOperate()
       {
           string className = "TDAl." + path + ".ShopOperate";
           return (IShopOperate)Assembly.Load("TDAl").CreateInstance(className);
       }

       public IInfoOperate GetInfoOperate()
       {
           string className = "TDAl." + path + ".InfoOperate";
           return (IInfoOperate)Assembly.Load("TDAl").CreateInstance(className);
       }

   
       public IAdminOperate GetAdminOperate()
       {
           string className = "TDAl." + path + ".AdminOperate";
           return (IAdminOperate)Assembly.Load("TDAl").CreateInstance(className);
       }

       public IBrandOperate GetBrandOperate()
       {
           string className = "TDAl." + path + ".BrandOperate";
           return (IBrandOperate)Assembly.Load("TDAl").CreateInstance(className);
       }
   }
}
