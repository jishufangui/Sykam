using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TModel
{
    public class TCity
    {
        #region 变量
        int _ID;
        string _code;
        string _name;
        string _provinceId;
        #endregion

        #region 属性
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        public string code
        {
            set {   _code=value; }
            get { return _code; }
        }
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public string provinceId
        {
            set { _provinceId = value; }
            get { return _provinceId; }
        }
        #endregion
    }
}
