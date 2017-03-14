using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TModel
{
    public class TInformation
    {   

        /// <summary>
        /// 信息ID
        /// </summary>
        public int InfoID
        {
            set;
            get;
        }

        /// <summary>
        ///  信息标题
        /// </summary>
        public string InfoTitle
        {
            set;
            get;
        }

        /// <summary>
        /// 信息内容简介
        /// </summary>
        public string InfoSubMemo
        {
            set;
            get;
        }

        /// <summary>
        /// 信息内容
        /// </summary>
        public string InfoMemo
        {
            set;
            get;
        }

        /// <summary>
        /// 信息图片
        /// </summary>
        public string InfoPic
        {
            set;
            get;
        }

        /// <summary>
        /// 信息类型  1服饰，2美食，3房产，4数码，5旅游，6汽车
        /// </summary>
        public int InfoType
        {
            set;
            get;
        }

        /// <summary>
        /// 信息类型 名称
        /// </summary>
        public string InfoTypeString
        {
            set;
            get;
        }


    

        /// <summary>
        /// 商城ID
        /// </summary>
        public int ShopID
        {
            set;
            get;
        }
        /// <summary>
        /// 商场名
        /// </summary>
        public string ShopName
        {
            set;
            get;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string InfoStartTime
        {
            set;
            get;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string InfoEndTime
        {
            set;
            get;
        }

        /// <summary>
        /// 来源
        /// </summary>
        public string InfoFrom
        {
            set;
            get;
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime InfoAddTime
        {
            set;
            get;
        }

        /// <summary>
        /// 添加人
        /// </summary>
        public string InfoAdder
        {
            set;
            get;
        }

        /// <summary>
        ///  点击数
        /// </summary>
        public int InfoClicks
        {
            set;
            get;
        }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecom
        {
            set;
            get;
        }
        

        /// <summary>
        /// 排序ID
        /// </summary>
        public int SortID
        {
            set;
            get;
        }

        /// <summary>
        /// 是否生成HTML
        /// </summary>
        public bool IsHtml
        {
            set;
            get;
        }

        /// <summary>
        /// 生成HTML路径
        /// </summary>
        public string HtmlPath
        {
            set;
            get;
        }

        /// <summary>
        /// 是否获取远程图片
        /// </summary>
        public bool IsRemote
        {
            set;
            get;
        }

        /// <summary>
        /// 是否审核过
        /// </summary>
        public bool IsCheck
        {
            set;
            get;
        }

        /// <summary>
        /// 信息类别号
        /// </summary>
        public int InfoCateID
        {
            set;
            get;
        }

        /// <summary>
        /// 信息英文标题
        /// </summary>
        public string InfoETitle
        {
            set;
            get;
        }

        /// <summary>
        /// tag标签
        /// </summary>
        public string InfoTag
        {
            set;
            get;
        }

        /// <summary>
        /// 品牌ID
        /// </summary>
        public int BrandID
        {
            set;
            get;
        }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName
        {
            set;
            get;
        }

        public int ModifyBy
        {
            get;
            set;
        }

        public DateTime ModifyTime
        {
            get;
            set;
        }
    }
}
