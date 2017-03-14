using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// .Net通用分页类
/// </summary>
namespace PagerClass
{
    public partial class CommonPage
    {
        #region 初始构造

        //PageStore()
        //{

        //}

        #endregion

        #region 字段
        /**//// <summary>
        /// 每页记录数
        /// </summary>
        private int _PageSize = 20;
        /**//// <summary>
        /// 需要获取第几页的数据,从 1 开始
        /// </summary>
        private int _PageIndex = 1;
        /**//// <summary>
        /// 总页数
        /// </summary>
        private int _PageCounts = 0;
        /**//// <summary>
        /// 总记录数
        /// </summary>
        private int _Counts = 0;
        /**//// <summary>
        /// 首页 显示样式
        /// </summary>
        private string _FirstStr = "";
        /**//// <summary>
        /// 上一页 显示样式
        /// </summary>
        private string _PrevStr = "";
        /**//// <summary>
        /// 下一页 显示样式
        /// </summary>
        private string _NextStr = "";
        /**//// <summary>
        /// 尾页 显示样式
        /// </summary>
        private string _LastStr = "";
        /**//// <summary>
        /// 跳转 的url链接
        /// </summary>
        private string _TurnUrlStr = "";
        /**//// <summary>
        /// 跳转的url链接的参数前面不要加问号和与号
        /// </summary>
        private string _Options = "";
        private string strCountww = "";  //共N条信息
        private string strPageww = "";    //第N页/共N页    
        private string strTurnww;  //跳转控件
        #endregion

        #region 属性

        /**//// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }
        
        /**//// <summary>
        /// 需要获取第几页的数据,从 1 开始
        /// </summary>
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        /**//// <summary>
        /// 总页数
        /// </summary>
        public int PageCounts
        {
            get { return _PageCounts; }
        }

        /**//// <summary>
        /// 总记录数
        /// </summary>
        public int Counts
        {
            get { return _Counts; }
            set { _Counts = value; }
        }
        
        /**//// <summary>
        /// 首页 显示样式
        /// </summary>
        public string FirstStr
        {
            get { return _FirstStr; }
            set { _FirstStr = value; }
        }
        
        /**//// <summary>
        /// 上一页 显示样式
        /// </summary>
        public string PrevStr
        {
            get { return _PrevStr; }
            set { _PrevStr = value; }
        }
        
        /**//// <summary>
        /// 下一页 显示样式
        /// </summary>
        public string NextStr
        {
            get { return _NextStr; }
            set { _NextStr = value; }
        }
        
        /**//// <summary>
        /// 尾页 显示样式
        /// </summary>
        public string LastStr
        {
            get { return _LastStr; }
            set { _LastStr = value; }
        }
        
        /**//// <summary>
        /// 跳转 的url链接
        /// </summary>
        public string TurnUrlStr
        {
            get { return _TurnUrlStr; }
            set { _TurnUrlStr = value; }
        }

        /**//// <summary>
        /// 跳转的url链接的参数前面不要加问号和与号
        /// </summary>
        public string Options
        {
            get { return _Options; }
            set { _Options = value; }
        }

        #endregion

        #region 返回分页后的页码显示
        /**//// <summary>
        /// 返回分页后的页码显示
        /// </summary>
        /// <param name="bolCount">是否显示 共N条信息</param>
        /// <param name="bolPage">是否显示 第N页/共N页</param>
        /// <param name="bolFirst">是否显示 首页</param>
        /// <param name="bolLast">是否显示 尾页</param>
        /// <param name="bolTurn">是否显示 跳转控件</param>
        /// <param name="IsChinese">是否 用中文显示</param>
        /// <param name="intStyle">样式选择</param>
        /// <param name="intShowNum">每页显示多少个数字</param>
        /// <returns>返回分页后的页码显示</returns>
        public string GetShowPageStr(bool bolCount, bool bolPage, bool bolFirst, bool bolLast, bool bolTurn, bool IsChinese, int intStyle, int intShowNum)
        {
            string strPageShowww = "";
            string _FirstStr2 = "";
            string _PrevStr2 = "";
            string _NextStr2 = "";
            string _LastStr2 = "";

            #region 公共处理

            //总页数
            _PageCounts = (_Counts + _PageSize - 1) / _PageSize;

            //超出最小页码
            if (_PageIndex < 1)
            {
                _PageIndex = 1;
            }
            
            //超出最大页码
            if (_PageIndex > _PageCounts)
            {
                _PageIndex = _PageCounts;
            }

            if (IsChinese)//中文分页
            {
                //跳转
                strTurnww = "<input value='" + _PageIndex.ToString() + "' id='txtPageGo' name='txtPageGo' type='text' style='width:35px;'><input name='btnGo' type='button' id='btnGo' value='跳转' onclick=\"javascript:window.location.href='" + _TurnUrlStr + "?Page=' + document.getElementById('txtPageGo').value + '" + "&" + Options + "'\">";
                //共N条信息
                strCountww = "共 " + _Counts.ToString() + " 条信息";
                //第N页/共N页
                strPageww = "第" + _PageIndex.ToString() + "页/共" + _PageCounts.ToString() + "页";
                //处理页码显示样式
                if (intStyle == 1)
                {
                    if (_FirstStr == "")
                    {
                        _FirstStr = "首页";
                    }
                    if (_PrevStr == "")
                    {
                        _PrevStr = "上一页";
                    }
                    if (_NextStr == "")
                    {
                        _NextStr = "下一页";
                    }
                    if (_LastStr == "")
                    {
                        _LastStr = "尾页";
                    }
                }
                else if(intStyle == 2)
                {
                    if (_FirstStr == "")
                    {
                        _FirstStr = " << ";
                    }
                    if (_PrevStr == "")
                    {
                        _PrevStr = " < ";
                    }
                    if (_NextStr == "")
                    {
                        _NextStr = " > ";
                    }
                    if (_LastStr == "")
                    {
                        _LastStr = " >> ";
                    }
                }
                else
                {
                    if (_FirstStr == "")
                    {
                        _FirstStr = " << ";
                    }
                    if (_PrevStr == "")
                    {
                        _PrevStr = " 上一页 ";
                    }
                    if (_NextStr == "")
                    {
                        _NextStr = " 下一页 ";
                    }
                    if (_LastStr == "")
                    {
                        _LastStr = " >> ";
                    }
                }
            }
            else//英文文分页
            {
                //跳转
                strTurnww = "<input value='" + _PageIndex.ToString() + "' id='txtPageGo' name='txtPageGo' type='text' style='width:35px;'><input name='btnGo' type='button' id='btnGo' value='Goto' onclick=\"javascript:window.location.href='" + _TurnUrlStr + "?Page=' + document.getElementById('txtPageGo').value + '" + "&" + Options + "'\">";
                //共N条信息
                strCountww = "Total " + _Counts.ToString() + " Infos";
                //第N页/共N页
                strPageww = " " + _PageIndex.ToString() + "/" + _PageCounts.ToString() + " ";
                //处理页码显示样式
                if (intStyle == 1)
                {
                    if (_FirstStr == "")
                    {
                        _FirstStr = " First ";
                    }
                    if (_PrevStr == "")
                    {
                        _PrevStr = " Previous ";
                    }
                    if (_NextStr == "")
                    {
                        _NextStr = " Next ";
                    }
                    if (_LastStr == "")
                    {
                        _LastStr = " Last ";
                    }
                }
                else if(intStyle == 2)
                {
                    if (_FirstStr == "")
                    {
                        _FirstStr = " << ";
                    }
                    if (_PrevStr == "")
                    {
                        _PrevStr = " < ";
                    }
                    if (_NextStr == "")
                    {
                        _NextStr = " > ";
                    }
                    if (_LastStr == "")
                    {
                        _LastStr = " >> ";
                    }
                }
                else
                {
                    if (_FirstStr == "")
                    {
                        _FirstStr = " First ";
                    }
                    if (_PrevStr == "")
                    {
                        _PrevStr = " Previous ";
                    }
                    if (_NextStr == "")
                    {
                        _NextStr = " Next ";
                    }
                    if (_LastStr == "")
                    {
                        _LastStr = " Last ";
                    }
                }
            }
            #endregion            

            //没有记录
            if (_Counts <= 0)
            {
                strPageShowww = strCountww;
            }
            //有记录
            else
            {
                //只有一页
                if (_PageCounts <= 1)
                {
                    strPageShowww = strCountww + "  " + strPageww;
                }
                //不止一页
                else
                {

                    #region 页码链接处理
                    //第一页
                    if (_PageIndex == 1)
                    {
                        _FirstStr2 = "<a href=\"#\" class=\"page_\">" + _FirstStr + "</a>";
                        _PrevStr2 = "<a href=\"#\" class=\"page_\">" + _PrevStr + "</a>";
                    }
                    else
                    {
                        _FirstStr2 = "<a href=\"" + _TurnUrlStr + "?Page=1" + "&" + _Options + "\" class=\"page_\">" + _FirstStr + "</a>";
                        _PrevStr2 = "<a href=\"" + _TurnUrlStr + "?Page=" + Convert.ToString(_PageIndex - 1) + "&" + _Options + "\" class=\"page_\">" + _PrevStr + "</a>";
                    }

                    //最后一页
                    if (_PageIndex == _PageCounts)
                    {
                        _NextStr2 = "<a href=\"#\" class=\"page_\">" + _NextStr + "</a>";
                        _LastStr2 = "<a href=\"#\" class=\"page_\">" + _LastStr + "</a>";
                    }
                    else
                    {
                        _NextStr2 = "<a href=\"" + _TurnUrlStr + "?Page=" + Convert.ToString(_PageIndex + 1) + "&" + _Options + "\" class=\"page_\">" + _NextStr + "</a>";
                        _LastStr2 = "<a href=\"" + _TurnUrlStr + "?Page=" + _PageCounts + "&" + _Options + "\" class=\"page_\">" + _LastStr + "</a>";
                    }

                    //----处理显示页码-----------

                    if (bolCount == true)//共N条信息
                    {
                        strPageShowww = strPageShowww + "  " + strCountww;
                    }
                    if (bolPage == true)//第N页/共N页
                    {
                        strPageShowww = strPageShowww + "  " + strPageww;
                    }
                    if (bolFirst == true) //首页
                    {
                        strPageShowww = strPageShowww + "  " + _FirstStr2;
                    }
                    strPageShowww = strPageShowww + "{0}";//上一页
                    strPageShowww = strPageShowww + "{1}{2}";//下一页                    
                    if (bolLast == true)//尾页
                    {
                        strPageShowww = strPageShowww + "  " + _LastStr2;
                    }
                    if (bolTurn == true)//跳转控件
                    {
                        strPageShowww = strPageShowww + "  " + strTurnww;
                    }

                    #endregion

                    #region 样式一: 共X条信息 第N页/共M页 首页 上一页 下一页 尾页  跳转
                    if (intStyle == 1)
                    {
                        strPageShowww = strPageShowww.Replace("{0}", "  " + _PrevStr2);//上一页
                        strPageShowww = strPageShowww.Replace("{1}", "  " + _NextStr2);//下一页
                        strPageShowww = strPageShowww.Replace("{2}", "");//
                    }
                    #endregion

                    #region 样式二: 共X条信息 第N页/共M页 首页 1 2 3 尾页 跳转
                    if (intStyle == 2)
                    {
                        int PageTemp = 0;
                        string strPageNum = "";
                        string strTempNow = "";
                        
                        //当页码超过最后一批该显示
                        if (_PageIndex > _PageCounts - intShowNum + 1)
                        {
                            PageTemp = _PageCounts < intShowNum ? 0 : _PageCounts - intShowNum;
                            for (int i = 1; i <= intShowNum; i++)
                            {
                                if (i > _PageCounts) break;                                
                                strTempNow = Convert.ToString(PageTemp + i);

                                //当前页不显示超链接
                                if( PageIndex == PageTemp + i)
                                {
                                    strPageNum = strPageNum + "<a href=\"#\" class=\"current\">" + strTempNow + "</a> ";
                                }
                                else
                                {
                                    strPageNum = strPageNum + "<a href=\"" + _TurnUrlStr + "?Page=" + strTempNow + "&" + _Options + "\">" + strTempNow + "</a> "; 
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < intShowNum; i++)
                            {
                                strTempNow = Convert.ToString(PageIndex + i);
                                //当前页不显示超链接
                                if (i == 0)
                                {
                                    strPageNum = strPageNum + "<a href=\"#\" class=\"current\">" + strTempNow + "</a> ";
                                }
                                else
                                {
                                    strPageNum = strPageNum + "<a href=\"" + _TurnUrlStr + "?Page=" + strTempNow + "&" + _Options + "\">" + strTempNow + "</a> ";
                                }
                            }
                        }
                        //
                        strPageShowww = strPageShowww.Replace("{0}", "  " + _PrevStr2);//上一页
                        strPageShowww = strPageShowww.Replace("{1}", "  " + strPageNum);//显示数字
                        strPageShowww = strPageShowww.Replace("{2}", "  " + _NextStr2);//下一页
                    }

                    #endregion

                    #region 样式三: 首页 1 2 3 尾页
                    if (intStyle == 3)
                    {
                        int PageTemp = 0;
                        string strPageNum = "";
                        string strTempNow = "";

                        //当页码超过最后一批该显示
                        if (_PageIndex > _PageCounts - intShowNum + 1)
                        {
                            PageTemp = _PageCounts < intShowNum ? 0 : _PageCounts - intShowNum;
                            for (int i = 1; i <= intShowNum; i++)
                            {
                                if (i > _PageCounts) break;
                                strTempNow = Convert.ToString(PageTemp + i);

                                //当前页不显示超链接
                                if (PageIndex == PageTemp + i)
                                {
                                    strPageNum = strPageNum + "<a href=\"#\" class=\"current\">" + strTempNow + "</a> ";
                                }
                                else
                                {
                                    strPageNum = strPageNum + "<a href=\"" + _TurnUrlStr + "?Page=" + strTempNow + "&" + _Options + "\">" + strTempNow + "</a> ";
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < intShowNum; i++)
                            {
                                strTempNow = Convert.ToString(PageIndex + i);
                                //当前页不显示超链接
                                if (i == 0)
                                {
                                    strPageNum = strPageNum + "<a href=\"#\" class=\"current\">" + strTempNow + "</a> ";
                                }
                                else
                                {
                                    strPageNum = strPageNum + "<a href=\"" + _TurnUrlStr + "?Page=" + strTempNow + "&" + _Options + "\">" + strTempNow + "</a> ";
                                }
                            }
                        }
                        //
                        strPageShowww = strPageShowww.Replace("{0}", "  " + _PrevStr2);//上一页
                        strPageShowww = strPageShowww.Replace("{1}", "  " + strPageNum);//显示数字
                        strPageShowww = strPageShowww.Replace("{2}", "  " + _NextStr2);//下一页
                    }

                    #endregion
                }
            }
            return strPageShowww;
        }
        #endregion
    }
}