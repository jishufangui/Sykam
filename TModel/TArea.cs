using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TModel
{
    public  class TArea
    {
        #region 变量
           int  _ID;
           string _code;
           string _name;
           string _cityId;
        #endregion
       
        #region 属性
           public int id
           {
               set { _ID = value; }
               get { return _ID; }
           }

           public string code
           {
               set { _code = value; }
               get { return _code; }
           }
           public string name
           {
               set { _name = value; }
               get { return _name; }
           }
           public string cityId
           {
               set { _cityId = value; }
               get { return _cityId; }
           }

           #endregion
    }
}
