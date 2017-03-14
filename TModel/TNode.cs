using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TModel
{
    public class TNode
    {


        #region 字段
        private int _NodeID = 0;//节点ID
        private string _NodeName = string.Empty;//节点名称
        private string _NodeIdentifier = string.Empty;//节点标示
        private int _ParentID = 0;//父节点ID
        private string _NodePath = string.Empty;//节点路径
        private string _NodeMemo = string.Empty;//节点描述
        private string _NodePic = string.Empty; //节点图片
        private int _SortID = 0;//排序号
        private bool _IsRecom = false;//是否推荐
        private bool _IsHtml = false;//是否生成html
        private string _HtmlPath = string.Empty;//生成的HTML路径
        private string _NodeTemplate = string.Empty;//该节点模板
        private string _Meta_Description = string.Empty;//节点描述
        private string _Meta_keyword = string.Empty;//节点关键字
        private bool _IsRemote = false;//是否远程获取图片
        private DateTime _Addtime;
        private string _DetailTemplate = string.Empty;//详情页模板
        private string _Adder = string.Empty;//添加人
        #endregion



        #region 属性
        /// <summary>
        /// 节点ID
        /// </summary>
        public int NodeID
        {
             set { _NodeID = value; }
            get { return _NodeID; }
        }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeName
        {
            set { _NodeName = value; }
            get { return _NodeName; }
        }
        /// <summary>
        /// 节点标示
        /// </summary>
        public string NodeIdentifier
        {
            set { _NodeIdentifier = value; }
            get { return _NodeIdentifier; }
        }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public int ParentID
        {
            set { _ParentID = value; }
            get { return _ParentID; }
        }
        /// <summary>
        ///节点路径
        /// </summary>
        public string NodePath
        {
            set { _NodePath = value; }
            get { return _NodePath; }
        }
        /// <summary>
        /// 节点描述
        /// </summary>
        public string NodeMemo
        {
            set { _NodeMemo = value; }
            get { return _NodeMemo; }
        }
        /// <summary>
        /// 节点图片
        /// </summary>
        public string NodePic
        {
            set { _NodePic = value; }
            get { return _NodePic; }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        public int SortID
        {
            set { _SortID = value; }
            get { return _SortID; }
        }
        /// <summary>
        /// 是否推荐节点
        /// </summary>
        public bool IsRecom
        {
            set { _IsRecom = value; }
            get { return _IsRecom; }
        }
        /// <summary>
        /// 是否生成HTML
        /// </summary>
        public bool IsHtml
        {
            set { _IsHtml = value; }
            get { return _IsHtml; }
        }
        /// <summary>
        /// 生成的html路径
        /// </summary>
        public string HtmlPath
        {
            set { _HtmlPath = value; }
            get { return _HtmlPath; }
        }
        /// <summary>
        /// 节点模板
        /// </summary>
        public string NodeTemplate
        {
            set { _NodeTemplate = value; }
            get { return _NodeTemplate; }
        }
        /// <summary>
        /// 详情页模板
        /// </summary>
        public string DetailTemplate
        {
            set { _DetailTemplate = value; }
            get { return _DetailTemplate; }
        }
        /// <summary>
        ///  meta描述
        /// </summary>
        public string Meta_Description
        {
            set { _Meta_Description = value; }
            get { return _Meta_Description; }
        }
        /// <summary>
        /// meta关键字
        /// </summary>
        public string Meta_KeyWords
        {
            set { _Meta_keyword = value; }
            get { return _Meta_keyword; }
        }

        /// <summary>
        /// 是否远程获取图片，默认为否
        /// </summary>
        public bool IsRemote
        {
            set { _IsRemote = value; }
            get { return _IsRemote; }
        }

        /// <summary>
        /// 添加时间Addtime
        /// </summary>
        public DateTime AddTime
        {
            set { _Addtime = value; }
            get { return _Addtime; }
        }

        /// <summary>
        /// 添加人
        /// </summary>
        public string Adder
        {
            set { _Adder = value; }
            get { return _Adder; }
        }
        #endregion
    }
}
