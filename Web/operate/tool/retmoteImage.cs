using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
namespace Web.operate.tool
{
    public class retmoteImage
    {

        public static string  GetImage(string Memo,string Path)
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
    }
}
