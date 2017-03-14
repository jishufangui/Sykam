﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;

namespace CommonLibrary
{
    /// <summary>
    /// Summary description for MessageObject
    /// </summary>
    /// <summary>
    ///
    /// </summary>
    public class MessageObject
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        public static void Write(string str)
        {
            System.Web.HttpContext.Current.Response.Write(str);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="MyPage"></param>
        /// <param name="strCode"></param>
        public static void ShowJS(System.Web.UI.Page MyPage, string strCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append(strCode.Trim());
            sb.Append("</script>");
            MyPage.Response.Write(sb.ToString());
        }
        /// <summary>
        ///
        /// </summary>
        public static void Location()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append("window.location.href=window.location.href;");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        public static void Show(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append("alert(\"" + str.Trim() + "\"); \n");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        public static void ShowClose(string str)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script language=\"javascript\">\n");
            sb.Append("alert(\"" + str.Trim() + "\"); \n");
            sb.Append("window.close();\n");
            sb.Append("</script>\n");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        public static void ShowLocation(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append("alert(\"" + str.Trim() + "\"); \n");
            sb.Append("window.location.href=window.location.href;\n");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public static void ShowRedirect(string str, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append("alert(\"" + str.Trim() + "\"); \n");
            sb.Append("window.location.href=\"" + url.Trim() + "\";\n");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        public static void ShowPre(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append("alert(\"" + str.Trim() + "\"); \n");
            sb.Append("var p=document.referrer; \n");
            sb.Append("window.location.href=p;\n");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="url"></param>
        public static void RedirectPage(string url)
        {
            string path = "http://" + System.Web.HttpContext.Current.Request.Url.Host + url;
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append(string.Format("window.location.href='{0}';", @path));
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }
    }
}
