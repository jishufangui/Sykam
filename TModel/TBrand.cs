using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TModel
{
    public  class TBrand
    {   
        /// <summary>
        /// 品牌ID
        /// </summary>
        public int BrandID
        { 
            get;
            set;
        }

        /// <summary>
        ///品牌名称
        /// </summary>
        public string BrandName
        {
            get;
            set;
        }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecom
        {
            get;
            set;
        }

        /// <summary>
        /// 品牌内容
        /// </summary>
        public string BrandMemo
        {
            get;
            set;
        }

        /// <summary>
        /// 品牌缩略图，可作为 logo
        /// </summary>
        public string BrandPic
        {
            get;
            set;
        }

        /// <summary>
        /// 品牌模板
        /// </summary>
        public string BrandTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// 是否生成html
        /// </summary>
        public bool IsHtml
        {
            get;
            set;
        }
         
        /// <summary>
        /// 生成的静态路径
        /// </summary>
        public string BrandHtmlPath
        {
            get;
            set;
        }

        /// <summary>
        /// 是否远程存图
        /// </summary>
        public bool IsRemote
        {
            get;
            set;
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime BrandAddtime
        {
            set;
            get;
        }

        /// <summary>
        /// 添加人
        /// </summary>
        public int BrandAdder
        {
            get;
            set;
        }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortID
        {
            get;
            set;
        }
    }
}
