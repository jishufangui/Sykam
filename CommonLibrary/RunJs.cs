using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{
    public class RunJs
    {
        /// <summary>
        /// 停止页面执行并弹出错误对话框，确定后返回
        /// </summary>
        /// <param name="str">错误信息</param>
        public static void AlertAndBack(string str)
        {
            System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert('" + str + "');history.back();</script>");
            System.Web.HttpContext.Current.Response.End();

        }

        /// <summary>
        /// 停止页面执行并弹出错误对话框，确定后返回
        /// </summary>
        /// <param name="str">错误信息</param>
        public static void AlertAndClose(string str)
        {
            System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert('" + str + "');window.close();</script>");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 弹出信息并且页面重定向
        /// </summary>
        /// <param name="str">弹出的信息</param>
        /// <param name="url">重定向的地址</param>
        public static void AlertAndRedirect(String str, String url)
        {
            System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert('" + str + "');location.replace('" + url + "');</script>");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 页面重定向
        /// </summary>
        /// <param name="url"></param>
        public static void PageReplace(String url)
        {
            System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">location.replace('" + url + "');</script>");
            System.Web.HttpContext.Current.Response.End();
        }
    }
}
