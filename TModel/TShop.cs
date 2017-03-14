using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
namespace TModel
{
    [DataContract]
    public class TShop
    {
        #region 变量
        //int _ShopID = 0;//商家ID
        //string _ShopTitle = string.Empty;//商家名称
        //string _ShopETitle = string.Empty;//商家英文标示符
        //string _ShopPic = string.Empty;//商家图片
        //string _ShopMemo = string.Empty;//商家内容介绍
        //string _ShopProvince = string.Empty;//商家所在省份
        //string _ShopCity = string.Empty;//商家所在城市
        //string _ShopArea = string.Empty;//商家所在地区
        //string _ShopLongitude = string.Empty;//google地图经度
        //string _ShopLatitude = string.Empty;//google地图纬度
        //string _ShopRoute = string.Empty;//公交路线
        //string _ShopOpenTime = string.Empty;//营业时间
        //string _ShopTemplate = string.Empty;//模板
        //DateTime _ShopAddtime;//添加或修改时间
        //string _ShopAdder = string.Empty;//添加人
        //private int _SortID = 0;//排序号
        //private bool _IsRecom = false;//是否推荐
        //private bool _IsHtml = false;//是否生成html
        //private string _HtmlPath = string.Empty;//生成的HTML路径

        #endregion

        /// <summary>
        /// 商家ID
        /// </summary>
        [DataMember]
        public int ShopID
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
        /// <summary>
        /// 商家英文标识
        /// </summary>
        [DataMember]
        public string ShopETitle
        {
            set;
            get;
        }
        /// <summary>
        /// 商家图片
        /// </summary>
        [DataMember]
        public string ShopPic
        {
            set;
            get;
        }

        /// <summary>
        /// 商家介绍
        /// </summary>
        [DataMember]
        public string ShopMemo
        {
            set;
            get;
        }
        /// <summary>
        /// 所在省份
        /// </summary>
        [DataMember]
        public string ShopProvince
        {
            set;
            get;
        }
        /// <summary>
        /// 所在城市
        /// </summary>
        [DataMember]
        public string ShopCity
        {
            set;
            get;
        }
        /// <summary>
        /// 所在地区
        /// </summary>
        [DataMember]
        public string ShopArea
        {
            set;
            get;
        }
        /// <summary>
        /// google地图经度
        /// </summary>
        [DataMember]
        public string ShopLongitude
        {
            set;
            get;
        }
        /// <summary>
        /// google地图纬度
        /// </summary>
        [DataMember]
        public string ShopLatitude
        {
            set;
            get;
        }
        /// <summary>
        /// 公交路线
        /// </summary>
        [DataMember]
        public string ShopRoute
        {
            set;
            get;
        }
        /// <summary>
        /// 营业时间
        /// </summary>
        [DataMember]
        public string ShopOpenTime
        {
            set;
            get;
        }
        /// <summary>
        /// 模板页
        /// </summary>
        [DataMember]
        public string ShopTemplate
        {
            set;
            get;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        [DataMember]
        public DateTime ShopAddtime
        {
            set;
            get;
        }
        /// <summary>
        /// 添加人
        /// </summary>
        [DataMember]
        public string ShopAdder
        {
            set;
            get;
        }
        /// <summary>
        /// 排序号
        /// </summary>
        [DataMember]
        public int SortID
        {
            set;
            get;
        }
        /// <summary>
        /// 是否作为推荐
        /// </summary>
        [DataMember]
        public bool IsRecom
        {
            set;
            get;
        }
        /// <summary>
        /// 是否生成 html
        /// </summary>
        [DataMember]
        public bool IsHtml
        {
            set;
            get;
        }
        /// <summary>
        /// 生成html路径
        /// </summary>
        [DataMember]
        public string HtmlPath
        {
            set;
            get;
        }

        /// <summary>
        /// 是否远程存图
        /// </summary>
        [DataMember]
        public bool IsRemote
        {
            set;
            get;
        }

 
   }
}
