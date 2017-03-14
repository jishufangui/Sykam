using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;
namespace CommonLibrary
{
    public class CommOperate
    {

        /// <summary>
        /// 静态函数， 检查传入的id值是否合法
        /// </summary>
        /// <param name="id">传入的ID</param>
        public static bool CheckID(string id)
        {
            if (id == null || id.Equals("") || id.Equals("0") || id.Equals(string.Empty))
            {
                return false;
            }
            else
            {
                try
                {
                    int i = Convert.ToInt32(id);
                    return true;
                }
                catch
                {

                    return false;
                }
            }
        }

        /// <summary>
        /// 删除指定位置的文件
        /// </summary>
        /// <param name="path">文件的物理路径</param>
        /// <returns>真 删除成功，假 删除失败</returns>
        public static bool DeleteFile(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 判断制定路径的文件是否存在
        /// </summary>
        /// <param name="path">文件的物理路径</param>
        /// <returns>返回真、假</returns>
        public static bool IsFileExists(string path)
        {
            if (System.IO.File.Exists(path))
                return true;
            else
                return false;
        }



        /// <summary>
        /// 直接获得Get方法提交的值
        /// </summary>
        /// <param name="param">提交的参数</param>
        /// <returns>获得提交的值</returns>
        public static string GetStrFromRequestQueryString(string param)
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.QueryString[param] is object)
                    return System.Web.HttpContext.Current.Request.QueryString[param];
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 直接获得Post方法提交的值
        /// </summary>
        /// <param name="param">控件的ID</param>
        /// <returns>获得控件的值</returns>
        public static string GetStrFromRequestForm(string cID)
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Form[cID] is object)
                    return System.Web.HttpContext.Current.Request.Form[cID];
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// 静态函数，去除指定字符串中的html代码
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>去除html后的字符串</returns>
        public static string RemoveHtml(string str)
        {
            try
            {
                string reStr = null;
                string pattern = @"<(.|\n)*?>";
                reStr = System.Text.RegularExpressions.Regex.Replace(str, pattern, string.Empty).Trim().Replace("&nbsp;", string.Empty).Replace("\r","").Replace("\n","").Replace("\t","").Replace(" ","");
                return reStr;
            }
            catch
            {
                return "";
            }

        }


        /// <summary>
        /// 截取指定长度的字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">截取的长度</param>
        /// <returns></returns>
        public static string GetStrAsLen(string str, int len)
        {
            string result;

            if (str == "" || str.Equals(string.Empty))
            {
                result = str;
            }
            else
            {
                if (str.Length > len)
                    result = str.Substring(0, len) + "...";
                else
                    result = str;
            }

            return result;
        }



        /// <summary>
        /// 截取指定长度的字符串无省略号!
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">截取的长度</param>
        /// <returns></returns>
        public static string CutStrAsLen(string str, int len)
        {
            string result;

            if (str == "" || str.Equals(string.Empty))
            {
                result = str;
            }
            else
            {
                if (str.Length > len)
                    result = str.Substring(0, len);
                else
                    result = str;
            }

            return result;
        }



        /// <summary>
        /// 文件上传公共类
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="filePath">保存路径</param>
        /// <param name="enabledFileType">允许文件格式</param>
        /// <param name="maxSize">最大上传大小</param>
        /// <returns>文件名</returns>
        public String UploadFile(System.Web.UI.WebControls.FileUpload file, String filePath, String enabledFileType, Int32 maxSize)
        {
            if (null != file && file.PostedFile.ContentLength > 0)
            {
                String serverPath = System.Web.HttpContext.Current.Server.MapPath(filePath + "/" + DateTime.Now.ToString("yyyy-MM")) + "/";
                if (!System.IO.Directory.Exists(serverPath))
                    System.IO.Directory.CreateDirectory(serverPath);

                String fileExt = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1).ToLower();
                if (!enabledFileType.Contains(fileExt))
                {
                    return "ext_err";  //文件格式错误
                }

                if (maxSize > 0)       //maxSize=0时不限制大小
                {
                    if (file.PostedFile.ContentLength > 5242880)
                        return "size_err";   //文件大小错误
                }
                CommOperate cp = new CommOperate();

                String fileName = cp.FileNameMaker() + "." + fileExt;
                file.SaveAs(serverPath + fileName);
                return DateTime.Now.ToString("yyyy-MM") + "/" + fileName;

            }
            else
                return "";
        }


        /// <summary>
        /// 生成文件名字
        /// </summary>
        /// <returns>文件名</returns>
        public string FileNameMaker()
        {

            return "W_" + DateTime.Now.Ticks.ToString();
        }

        /// <summary>
        /// 获取完整的QueryString  字符串，貌似不支持urlrewrite
        /// </summary>
        /// <param name="QueryStringCollection">QueryString集合(NameValueCollection类型的)</param>
        /// <returns>完整的QueryString字符串</returns>
        public static string GetQueryStringParam(NameValueCollection QueryStringCollection)
        {
            string ParaString = string.Empty;
            if (QueryStringCollection != null && QueryStringCollection.Count > 0)
            {
                //ParaString = "?";
                string[] keys = QueryStringCollection.AllKeys;
                for (int i = 0; i < QueryStringCollection.Count; i++)
                {
                    ParaString = ParaString + keys[i].ToString() + "=" + QueryStringCollection[i].ToString() + "&";
                }
                ParaString = ParaString.Substring(0, ParaString.Length - 1);
            }
            return ParaString;
        }


        /// <summary>
        ///  获取完整的QueryString，并且去掉不想显示的QueryString 重构QueryString，貌似不支持urlrewrite
        /// </summary>
        /// <param name="QueryStringCollection">QueryString集合(NameValueCollection类型的)</param>
        /// <param name="NoDisplay">不想显示的QueryString选项</param>
        /// <returns>重构的QueryString</returns>
        public static string GetQueryStringParam(NameValueCollection QueryStringCollection, string NoDisplay)
        {
            string ParaString = string.Empty;
            if (QueryStringCollection != null && QueryStringCollection.Count > 0)
            {
                //ParaString = "?";
                string[] keys = QueryStringCollection.AllKeys;
                for (int i = 0; i < QueryStringCollection.Count; i++)
                {
                    if (!keys[i].Equals(NoDisplay))
                    {
                        ParaString = ParaString + keys[i].ToString() + "=" + QueryStringCollection[i].ToString() + "&";
                    }
                }
                if (ParaString.Length > 0)
                {
                    ParaString = ParaString.Substring(0, ParaString.Length - 1);
                }
            }
            return ParaString;
        }

        /// <summary>
        /// 获取指定字节长度的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetStrAsLenByByte(string str,int len)
        {
            byte[] bwrite = Encoding.GetEncoding("UTF-8").GetBytes(str.ToCharArray()); 
            
            if(bwrite.Length >=len) 
            return   Encoding.Default.GetString(   bwrite,0,len); 
            else  
            return Encoding.Default.GetString(bwrite); 

      
        }


        public static int GetBytefromStr(string str)
        {
            byte[] bwrite = Encoding.GetEncoding("UTF-8").GetBytes(str.ToCharArray());
            return bwrite.Length;
        }


        public static string GetFolder()
        {
            return DateTime.Now.ToString("yyyyMMdd") + "/";
        }


        /// <summary>
        /// 根据指定类型获取json字符串。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            Stream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);

            // 从头到尾将stream读取成一个字符串形式的数据，并且返回
            stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }




        #region 根据arraylist生成查询条件
        /// <summary>
        /// 根据arraylist生成查询条件
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="FiledValue"></param>
        /// <returns></returns>
        public static string SelectCondition(ArrayList FiledName, ArrayList FiledValue)
        {
            StringBuilder sbCondition = new StringBuilder();//查询条件
    
            if (FiledName != null && FiledValue != null)
            {
              
                for (int i = 0; i < FiledName.Count; i++)
                {
                    if (FiledValue[i].ToString().Trim() != "")
                    {
                        string type = FiledValue[i].GetType().ToString().ToLower();//参数的值类型
                        string param = string.Empty;// 匹配[]中的符号内容，转换为 sqlserver的条件符号

                        #region 匹配[]及里面的内容
                        string pattern = @"(?i)(?<=\[)(.*)(?=\])";
                        Regex rg = new Regex(pattern);
                        MatchCollection mc = rg.Matches(FiledName[i].ToString());

                        #endregion
                        if (mc.Count > 0)
                        {
                            param = mc[0].ToString();// 匹配[]中的符号内容，转换为 sqlserver的条件符号

                            if (param.ToLower().Trim().Equals("and"))//如果匹配内容为[and] 
                            {
                                param = "  and  ";
                            }
                            else if (param.ToLower().Trim().Equals("or"))//如果匹配内容为[or] 
                            {
                                param = "  or   ";
                            }
                            else
                            {
                                param = " and ";//如果都不是，则默认为[and]
                            }
                            FiledName[i] = FiledName[i].ToString().Trim().Replace("[" + mc[0].ToString() + "]", "");

                        }
                        else
                        {
                            param = " and ";//如果没有[]，则连接符为and 
                        }

                        if (FiledValue[i].GetType().ToString().ToLower().Equals("system.string"))
                        {
                            sbCondition.Append(param + FiledName[i].ToString() + "  like  '%" + FiledValue[i].ToString() + "%'");
                        }
                        else
                        {
                            sbCondition.Append(param + FiledName[i].ToString() + "  =  " + FiledValue[i].ToString());
                        }
                    }
                }
            }
            else
            {
                sbCondition.Length = 0;
            }


            return sbCondition.ToString();
        }
        #endregion

    }
}
