using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Data;
using System.Data.Common;
using CommonLibrary;
using TDAl;
using TModel;
namespace TBLL
{
    public class AdminBLL
    {
        IAdminOperate AdminOperate = null;
        public AdminBLL()
        {
            TDAl.DatabaseProvider DataProvider = null;
            DataProvider = new DatabaseProvider();
            AdminOperate = DataProvider.GetAdminOperate();
        }

        #region 通过 id获取管理员
        /// <summary>
        /// 通过ID获取管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TAdmin GetAdmin(int id)
        {
            return AdminOperate.GetAdmin(id);
        }
        #endregion

        #region  添加管理员
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="tadmin"></param>
        /// <returns></returns>
        public int AddAdmin(TAdmin tadmin)
        {
            return AdminOperate.AddAdmin(tadmin);
        }
        #endregion

        #region  修改管理员
        public int UpdateAdmin(TAdmin tadmin, int id)
        {
            return AdminOperate.UpdateAdmin(tadmin, id);
        }
        #endregion

        #region 删除管理员
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteAdmin(int id,int userid)
        {
            return AdminOperate.LoginDeletAdmin(id, userid);
        }
        #endregion

        #region 获取最新插入信息ID
        public int GetLastID()
        {
            return AdminOperate.GetLastAdminID();
        }
        #endregion

        #region  获取指定条件下管理员数量
        public int GetAdminNum(ArrayList FiledName, ArrayList FiledValu)
        {
            int counts = 0;
            counts = AdminOperate.GetAdminNumByCondition(FiledName, FiledValu);
            return counts;
        }
        #endregion


        #region 获取指定条件下的管理员
        public DataTable GetAdminByCondition(ArrayList FiledName, ArrayList FiledValue, int startid, int endid)
        {
            return AdminOperate.GetAdminByCondition(FiledName, FiledValue, startid, endid);
        }
        #endregion

        #region 修改密码
        public int ChangePwd(string password, int id)
        {
            return AdminOperate.ChangePWd(password, id);
        }
        #endregion


        #region  修改权限
        public int UpdateCompetence(string Flag, int id)
        {
            return AdminOperate.UpdateCompetence(Flag, id);
        }
        #endregion

        #region 获取权限
        public string GetCompetence(int id)
        {
            return AdminOperate.GetCompetence(id);
        }
        #endregion


        #region  检测用户名和密码是否匹配
        /// <summary>
        /// 检测用户名和密码是否匹配，如果匹配，返回用户ID，不匹配则返回 0
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public int CheckUserNameAndPassWord(string Uid, string Pwd)
        {
            return AdminOperate.CheckUserNameAndPassWord(Uid, Pwd);
        }
        #endregion

        #region 获取xml中的菜单列表
        public List<TMenu> GetMenuListByXml()
        {
            OperateXml_old op = new OperateXml_old();
            List<TMenu> MenuList = new List<TMenu>();


            XmlNodeList nodes = op.SelectNodes("SetUp.xml", "root");
            if (nodes.Count > 0)
            {
                foreach (XmlNode rootNode in nodes)
                {
                    XmlElement xe = (XmlElement)rootNode;
                    TMenu MenuItem = new TMenu();
                    int _MenuID = 0;
                    Int32.TryParse(xe.GetAttribute("id"), out _MenuID);
                    MenuItem.MenuID = _MenuID;
                    MenuItem.Link = xe.GetAttribute("link");
                    MenuItem.MenuTitle = xe.GetAttribute("title");
                    MenuItem.ParentId = 0;//根节点
                    MenuItem.Link = xe.GetAttribute("link");
                    MenuItem.Style = xe.GetAttribute("linkStyle");
                    MenuList.Add(MenuItem);
                    foreach (XmlNode _Childnode in rootNode)
                    {
                        XmlElement _Childxe = (XmlElement)_Childnode;
                        TMenu ChildMenuItem = new TMenu();
                        int _ChildMenuID = 0;
                        Int32.TryParse(_Childxe.GetAttribute("id"), out _ChildMenuID);
                        ChildMenuItem.Link = _Childxe.GetAttribute("link");
                        ChildMenuItem.MenuTitle = _Childxe.GetAttribute("title");

                        int _ParentID = 0;
                        Int32.TryParse(_Childxe.GetAttribute("parentId"), out _ParentID);
                        ChildMenuItem.ParentId = _ParentID;

                        ChildMenuItem.Link = _Childxe.GetAttribute("link");
                        ChildMenuItem.Style = _Childxe.GetAttribute("linkStyle");
                        MenuList.Add(ChildMenuItem);
                    }
                }
            }

            return MenuList;
        }
        #endregion

        #region 根据权限字符传生成后台导航栏
        /// <summary>
        /// 根据权限字符传生成后台顶部导航栏
        /// </summary>
        /// <param name="RoleString"></param>
        /// <returns></returns>
        public string GetTopMenu(string RoleString)
        {
            List<TMenu> TopMenuList = new List<TMenu>();
            TopMenuList = GetMenuListByXml().Where(t => t.ParentId == 0).ToList();
            StringBuilder MenuString = new StringBuilder();
            if (TopMenuList.Count() > 0)
            {

                foreach (var item in TopMenuList)
                {
                    if (RoleString.ToLower().Contains(item.MenuID.ToString().ToLower()))
                    {
                        MenuString.Append("<li><a href=\"" + item.Link + "\" onclick=\"parent.frmleft.disp(" + item.MenuID + ");\"   style='"+item.Style+"' target=\"frmright\"><span>" + item.MenuTitle + "</span></a></li>");
                    }
                }
            }
            return MenuString.ToString();
        }

        /// <summary>
        /// 根据权限字符传生成后台左侧导航
        /// </summary>
        /// <param name="RoleString"></param>
        /// <returns></returns>
        public string GetLeftMenu(string RoleString)
        {
            List<TMenu> TopMenuList = new List<TMenu>();
            TopMenuList = GetMenuListByXml().Where(t => t.ParentId == 0).ToList();
            StringBuilder MenuString = new StringBuilder();

            if (TopMenuList.Count() > 0)
            {
                int i = 0;
                foreach (var topitem in TopMenuList)
                {
                    MenuString.Append("<div id=\"left_" + topitem.MenuID + "\" ");
                    if (i == 0)
                    {
                        MenuString.Append("style=\"display:block;\">");
                    }
                    else
                    {
                        MenuString.Append("style=\"display:none;\">");
                    }

                    List<TMenu> LeftMenuList = new List<TMenu>();
                    LeftMenuList = GetMenuListByXml().Where(t => t.ParentId == topitem.MenuID).ToList();
                    if (LeftMenuList.Count() > 0)
                    {

                        foreach (var item in LeftMenuList)
                        {
                            if (RoleString.Contains(item.MenuID.ToString()))
                            {
                                if (item.Style.Contains("display: none;"))
                                {
                                }
                                else
                                {
                                    MenuString.Append("<a href=\"" + item.Link + "\" style=\"" + item.Style + "\" target=\"frmright\">" + item.MenuTitle + "</a>");
                                }
                            }
                        }
                    }

                    MenuString.Append("</div>");
                    i++;
                }
            }
            return MenuString.ToString();
        }

        #endregion

        #region 获取用户允许访问的页面
        /// <summary>
        /// 获取用户允许访问的页面
        /// </summary>
        /// <param name="RoleString"></param>
        /// <returns></returns>
        public List<string> GetUserAllowPage(string RoleString)
        {
            List<string> PageList = new List<string>();
            List<TMenu> menulist = GetMenuListByXml();
            if (menulist.Count() > 0)
            {
                foreach (var item in menulist)
                {
                    if (RoleString.Contains(item.MenuID.ToString()))
                    {
                        PageList.Add(item.Link);
                    }
                }
            }
            
            return PageList;
        }
        #endregion
    }
}
