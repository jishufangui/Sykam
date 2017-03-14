using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using System.Data.Common;
using DataHelper;
using CommonLibrary;
using TModel;
namespace TDAl.sqlserver
{
    public class UserMemberOperate : IUserMemberOperate
    {
        private static string _connection = string.Empty;
        DataHelper.DbHelper dh;

        public UserMemberOperate()
        {
            _connection = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();
            dh = new SqlHelper(_connection);
        }

        /// <summary>
        /// 获取指定ID成员
        /// </summary>
        /// <param name="id"></param>
        public TUserMember GetUserMember(string id)
        {
           TUserMember userMember = new TUserMember();
          
            return userMember;
        }
  

     }
}
