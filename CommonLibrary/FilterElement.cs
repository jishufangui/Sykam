using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace CommonLibrary
{
   public  class FilterElement
   {   

       /// <summary>
       /// 过滤字符串，找出所有的'img' 元素，写入arraylist，返回出来
       /// </summary>
       /// <param name="Memo"></param>
       /// <returns></returns>
       public static ArrayList FilterPic(string Memo)
       {
           ArrayList result=new ArrayList();

           Regex r = new Regex(@"<IMG[^>]+src=\s*(?:'(?<src>[^']+)'|""(?<src>[^""]+)""|(?<src>[^>\s]+))\s*[^>]*>", RegexOptions.IgnoreCase);
           MatchCollection mc = r.Matches(Memo);
           foreach (Match m in mc)
           {


               result.Add(m.Groups["src"].Value.ToLower());  
    
           }  
        return result;
         
       }

      


       public static ArrayList FilterUrl(string Memo)
       {
           ArrayList result = new ArrayList();

           Regex r = new Regex(@"<a.*?href=[""'](?<url>.*?)[""'].*?>(?<name>.*?)</a>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
           MatchCollection mc = r.Matches(Memo);
           foreach (Match m in mc)
           {

               if (m.Groups["url"].Value.Trim() != "")
               {
                   result.Add(m.Groups["url"].Value.ToLower());

               }
           }  
           return result;
       }

       public static string DeleteImgfromString(string Memo)
       {
           Regex r = new Regex(@"<IMG[^>]+src=\s*(?:'(?<src>[^']+)'|""(?<src>[^""]+)""|(?<src>[^>\s]+))\s*[^>]*>", RegexOptions.IgnoreCase);
           Memo = r.Replace(Memo, ""); 
 
           return Memo;
       }

      
   }
}
