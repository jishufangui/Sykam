using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace TModel
{
    public class TMenu
    {   
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuTitle
        {
            set;
            get;
        }

        /// <summary>
        /// 菜单链接
        /// </summary>
        public string Link
        {
            set;
            get;
        }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuID
        {
            set;
            get;
        }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        public int ParentId
        {
            set;
            get;
        }

        /// <summary>
        /// 菜单样式
        /// </summary>
        public string Style
        {
            set;
            get;
        }
    }
}
