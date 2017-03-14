using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
namespace TModel.json
{
    [DataContract]
    public class J_brand
    {
        [DataMember]     
        public string  BrandID
        {
            set;
            get;
        }
       
        [DataMember] 
        public string BrandName
        {
            set;
            get;
        }
    }
}
