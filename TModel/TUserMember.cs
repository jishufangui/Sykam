using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TModel
{
    public class TUserMember
    {
        public string user_id
        {
            get;
            set;
        }

        public string user_name
        {
            get;
            set;
        }
        public string mobile_no
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public string qq
        {
            get;
            set;
        }

        public string wechart
        {
            get;
            set;
        }

        public string usertype
        {
            get;
            set;
        }


        public string password
        {
            get;
            set;
        }

        public int adder
        {
            get;
            set;
        }

        public DateTime addtime
        {
            get;
            set;
        }

        public int modifier
        {
            get;
            set;
        }

        public DateTime modifytime
        {
            get;
            set;
        }
        public int isDelete
        {
            set;
            get;
        }

    }
}
