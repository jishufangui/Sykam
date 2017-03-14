using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TBLL;
using TDAl;
using TModel;
namespace Web.operate
{
    public class BasePage:System.Web.UI.Page
    {

        public TAdmin LoginUser
        {
            get
            {
                if (Session["LoginUser"] != null && Session["UserAllowPage"]!=null)
                {
                    return (TAdmin)Session["LoginUser"];
                }
                else
                {
                    return null;
                }
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.LoginUser == null)
            {
                this.RedirectToLogin();
            }
            else
            {
                //判断是否有权限
                List<string> PageList = (List<String>)Session["UserAllowPage"];
                
                if (!PageList.Contains(CurrentPageName()))
                {
                    CommonLibrary.RunJs.AlertAndBack("您没有权限访问该页面!");
                }
            }
        }

        public string CurrentPageName()
        {
          
                string currentFilePath = HttpContext.Current.Request.FilePath;
           
                return currentFilePath.Replace("/operate/", "").Trim();
           
        }




        protected virtual void RedirectToLogin()
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('您没有登录或长时间没有操作');window.top.location.replace('/operate/Login.aspx');</script>");
            System.Web.HttpContext.Current.Response.End();
        }
    }
}
