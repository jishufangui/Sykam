using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TBLL;
using TDAl;
using TModel;
namespace Web.operate
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string UserName = userName.Text.Trim();
            string PassWord = CommonLibrary.MyEncryption.CreateMD5(passWord.Text.Trim(), 32);
            string VeryCode = validCode.Text;


            AdminBLL adminbll = new AdminBLL();
            int userid = adminbll.CheckUserNameAndPassWord(UserName, PassWord);
            if (userid == 0)
            {
                CommonLibrary.RunJs.AlertAndBack("用户名或密码错误");
            }
            else
            {
                TAdmin tadmin = adminbll.GetAdmin(userid);
                Session["LoginUser"] = tadmin;
                Session["UserAllowPage"] = adminbll.GetUserAllowPage(tadmin.Admin_Flag);
                tadmin.Admin_LogTimes = tadmin.Admin_LogTimes + 1;
                
                adminbll.UpdateAdmin(tadmin, userid);
                CommonLibrary.RunJs.PageReplace("Default.aspx");
            }
        }
    }
}
