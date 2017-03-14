using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
namespace TModel.json
{
    [DataContract]
    public  class J_shop
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        [DataMember]
        public string  ShopID
        {
            set;
            get;
        }

        /// <summary>
        /// 商家名称
        /// </summary>
        [DataMember]
        public string ShopTitle
        {
            set;
            get;
        }
    }
}
