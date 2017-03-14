using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{
    public class MyEncryption
    {
        public static string CreateMD5(string EncryStr, int Length)
        {
            try
            {
                if(Length==16)
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(EncryStr,"MD5").ToLower().Substring(8,16);
                }
                else if(Length ==32)
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(EncryStr,"MD5").ToLower();
                }
                else
                {
                    return "请选择生成16位或32位MD5";
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
