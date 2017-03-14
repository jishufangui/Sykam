using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
namespace Web.operate.tool
{
    public class ImageOperate
    {

        #region  从内容中提取图片，并将图片保存在指定路径下
        /// <summary>
        /// 从内容中提取图片，并将图片保存在指定路径下
        /// </summary>
        /// <param name="Memo"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string  GetRemoteImage(string Memo,string Path)
        {

            Regex re = new Regex(@"src\s*=\s*(?:([""'])(?<src>[^""']+)\1|(?<src>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection mc = re.Matches(Memo.Trim());
            foreach (Match c in mc)
            {
                string url = c.Groups["src"].Value;
                string filepath = url;
                if (url.Substring(0, 7).ToLower() == "http://")
                {
                    string FileType = "." + url.Substring(url.LastIndexOf(".") + 1);
                    string WebPath = Path + CommonLibrary.CommOperate.GetFolder();
                    string path = HttpContext.Current.Server.MapPath(WebPath);
                    
                    System.IO.Directory.CreateDirectory(path);//建立目录，如果有，则写入目录
                    
                    string FileName = System.Guid.NewGuid().ToString() + FileType;//生成的文件名
                    
                    path = path + FileName;//物理路径
                    try
                    {
                        WebClient myWebClient = new WebClient();
                        myWebClient.DownloadFile(url, path);//下载到本地
                        Memo = Memo.Replace(url, WebPath + FileName);//替换成本地路径
                    }
                    catch
                    {
                        return Memo;
                    }
                } 
            }

            return Memo;
        }

        #endregion

        #region   将内容图片和另外上传的图片合并为一个select 控件
        /// <summary>
        /// 将内容图片和另外上传的图片合并为一个select 控件
        /// </summary>
        /// <param name="Memo">内容</param>
        /// <param name="Pic">额外上传的图片</param>
        /// <returns></returns>
        public static string GetImageSelect(string Memo,string Pic)
        {  

            StringBuilder sb = new StringBuilder();
            sb.Append("<select id=\"CatePic\" name=\"CatePic\"><option value=\"\">无封面图片...</option>");
            Regex re = new Regex(@"src\s*=\s*(?:([""'])(?<src>[^""']+)\1|(?<src>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection mc = re.Matches(Memo.Trim());
            if (mc.Count != 0)
            {
                foreach (Match c in mc)
                {
                    string url = c.Groups["src"].Value;
                    if (url.ToLower().Equals(Pic))
                    {
                        continue;
                    }
                    else
                    {
                        sb.Append("<option value='" + url + "'>" + url + "</option>");
                    }

                }
            }
            if (Pic != "")
            {
                sb.Append("<option value='" + Pic + "' selected='selected'>" + Pic + "</option>");
            }

            sb.Append("</select>");
         
            return sb.ToString();
        }

        #endregion

        #region  删除内容图片
        /// <summary>
        /// 删除编辑器保存的图片
        /// </summary>
        /// <param name="Memo">编辑器的内容</param>
        public static void  DeleteMemoImage(string Memo)
        {
            Regex re = new Regex(@"src\s*=\s*(?:([""'])(?<src>[^""']+)\1|(?<src>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection mc = re.Matches(Memo.Trim());
            foreach (Match c in mc)
            {
                string url = c.Groups["src"].Value.Trim();
                string filepath = url;
                string suburl = url.Substring(0, 11);
                if (url.Substring(0, 11).ToLower() == "/uploadfile")
                {
                    CommonLibrary.CommOperate.DeleteFile(System.Web.HttpContext.Current.Server.MapPath( url));
                     
                }

            }
        }

        #endregion
    }
}
