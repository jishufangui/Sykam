using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TModel
{
    public class TAdmin
    {   

        /// <summary>
        /// ID
        /// </summary>
        public int Admin_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 管理员用户名
        /// </summary>
        public string Admin_UID
        {
            get;
            set;
        }

        /// <summary>
        /// 管理员密码
        /// </summary>
        public string Admin_PWD
        {
            get;
            set;
        }

        /// <summary>
        /// 是否锁定 true为能用。false为不能用
        /// </summary>
        public bool Admin_Stat
        {
            get;
            set;
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Admin_RealName
        {
            get;
            set;
        }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime Admin_RegTime
        {
            get;
            set;
        }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int Admin_LogTimes
        {
            get;
            set;
        }

        /// <summary>
        /// 权限字段
        /// </summary>
        public string Admin_Flag
        {
            set;
            get;
        }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortID
        {
            set;
            get;
        }


        public DateTime? ModifyTime
        {
            get;
            set;
        }

        public int? ModifyBy
        {
            get;
            set;
        }


    }
}
