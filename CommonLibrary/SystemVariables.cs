using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{   
    ///获取系统相关信息 
    public static class  SystemVariables
    {
        /// <summary>
        /// 获得上页地址
        /// </summary>
        /// <param name="defaultUrl">默认地址</param>
        /// <returns></returns>
        public static string GetReferUrl(String defaultUrl)
        {
            string result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
            if (result.Trim().Length == 0)
                result = defaultUrl;
            return result;
        }

        /// <summary>
        /// 获得客户端IP
        /// </summary>
        /// <returns>IP值</returns>
        public static string GetClientIP()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == ip || ip == string.Empty)
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            }
            if (null == ip || ip == string.Empty)
            {
                ip = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return ip;
        }

        /// <summary>
        /// 获得服务器IP
        /// </summary>
        /// <returns></returns>
        public static string GetServerIP()
        {
            return System.Web.HttpContext.Current.Request.ServerVariables.Get("Local_Addr");
        }

        /// <summary>
        /// 客户端操作系统
        /// </summary>
        /// <returns></returns>
        public static String GetClientOS()
        {
            string Agent = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            return SwitchOs(Agent);

        }

        /// <summary>
        /// 判断操作系统
        /// </summary>
        /// <param name="Agent"></param>
        /// <returns></returns>
        private static String SwitchOs(String Agent)
        {
            if (Agent.IndexOf("NT 4.0") > 0)
            {
                return "Windows NT ";
            }
            else if (Agent.IndexOf("NT 5.0") > 0)
            {
                return "Windows 2000";
            }
            else if (Agent.IndexOf("NT 5.1") > 0)
            {
                return "Windows XP";
            }
            else if (Agent.IndexOf("NT 5.2") > 0)
            {
                return "Windows 2003";
            }
            else if (Agent.IndexOf("NT 6.0") > 0)
            {
                return "Windows Vista";
            }
            else if (Agent.IndexOf("WindowsCE") > 0)
            {
                return "Windows CE";
            }
            else if (Agent.IndexOf("NT") > 0)
            {
                return "Windows NT ";
            }
            else if (Agent.IndexOf("9x") > 0)
            {
                return "Windows ME";
            }
            else if (Agent.IndexOf("98") > 0)
            {
                return "Windows 98";
            }
            else if (Agent.IndexOf("95") > 0)
            {
                return "Windows 95";
            }
            else if (Agent.IndexOf("Win32") > 0)
            {
                return "Win32";
            }
            else if (Agent.IndexOf("Linux") > 0)
            {
                return "Linux";
            }
            else if (Agent.IndexOf("SunOS") > 0)
            {
                return "SunOS";
            }
            else if (Agent.IndexOf("Mac") > 0)
            {
                return "Mac";
            }
            else if (Agent.IndexOf("Linux") > 0)
            {
                return "Linux";
            }
            else if (Agent.IndexOf("Windows") > 0)
            {
                return "Windows";
            }
            return "unknow";
        }

        /// <summary>
        /// 服务器名
        /// </summary>
        /// <returns></returns>
        public static String GetServerName()
        {
            return System.Web.HttpContext.Current.Request.ServerVariables.Get("Server_Name");
        }

        /// <summary>
        /// 脚本解释引擎
        /// </summary>
        /// <returns></returns>
        public static String GetSoftWare()
        {
            return System.Web.HttpContext.Current.Request.ServerVariables.Get("SERVER_SOFTWARE");
        }

        /// <summary>
        /// 获得服务器操作系统
        /// </summary>
        /// <returns></returns>
        public static String GetServerOs()
        {
            String str = System.Environment.OSVersion.VersionString;
            return SwitchOs(str);
        }

        /// <summary>
        /// 获得服务器cpu数量
        /// </summary>
        /// <returns></returns>
        public static String GetNumberOfCPU()
        {
            return System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
        }

        /// <summary>
        /// 客户端浏览器
        /// </summary>
        /// <returns></returns>
        public static String GetClientBrowser()
        {
            System.Web.HttpBrowserCapabilities HBC = System.Web.HttpContext.Current.Request.Browser;

            return HBC.Browser + " v." + HBC.Version + " " + HBC.Platform;
        }
    }
}
