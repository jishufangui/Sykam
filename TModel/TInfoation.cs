using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TModel
{
    public class TInfoation
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
        /// 信息类型  1衣，2食，3住，4行
        /// </summary>
        public int InfoType
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



    }
}
