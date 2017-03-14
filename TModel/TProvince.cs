using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TModel
{
    public  class TProvince
    {
        #region 变量
        private int _ID = 0;//省ID
        private string _code = string.Empty;//省的编号
        private string _name = string.Empty;//省的名称
        #endregion

        #region 属性
        public int ID
        {
            set {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }

        public string code
        {
            set
            {
                _code = value;
            }
            get
            {
                return _code;
            }
        }

        public string name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }

        #endregion
    }
}
