using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Web.operate.tool
{   
    /// <summary>
    /// 网站一般操作类
    /// </summary>
    public class WebOperate
    {    
        /// <summary>
        /// 检查用户是否登陆，如果没登陆，跳转到登陆页
        /// </summary>
        //public static void CheckOperateLogin()
        //{
        //    if (null == System.Web.HttpContext.Current.Session["admin"] || System.Web.HttpContext.Current.Session["admin"].ToString().Equals(String.Empty) || System.Web.HttpContext.Current.Session["admin"].ToString().Equals("") || null == System.Web.HttpContext.Current.Session["username"] || System.Web.HttpContext.Current.Session["username"].ToString().Equals(String.Empty) || System.Web.HttpContext.Current.Session["username"].ToString().Equals("") || System.Web.HttpContext.Current.Session["adminid"] == null || System.Web.HttpContext.Current.Session["adminid"].ToString().Equals(String.Empty) || System.Web.HttpContext.Current.Session["adminid"].ToString().Equals(""))
        //    {
        //        System.Web.HttpContext.Current.Response.Write("<script>alert('您没有登录或长时间没有操作');window.top.location.replace('/operate/Login.aspx');</script>");
        //        System.Web.HttpContext.Current.Response.End();
        //    }
        //}


        //#region  测试时候模拟登陆
        ///// <summary>
        ///// 测试时模拟管理员登陆
        ///// </summary>
        //public static void TestLogin()
        //{  
        //     System.Web.HttpContext.Current.Session["adminid"] = 1;
        //     System.Web.HttpContext.Current.Session["admin"] = "admin";
        //     System.Web.HttpContext.Current.Session["username"] ="管理员";
        //}
        //#endregion

    }
}
