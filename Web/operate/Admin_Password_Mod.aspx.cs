using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
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
    public partial class Admin_Password_Mod : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int AdminID = 0;
                Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out AdminID);
                AdminBLL adminbll = new AdminBLL();
                TAdmin tadmin = adminbll.GetAdmin(AdminID);
                L_admin_uid.Text = tadmin.Admin_UID;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int AdminID = 0;
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out AdminID);
            AdminBLL adminbll = new AdminBLL();
            TAdmin tadmin = adminbll.GetAdmin(AdminID);
            string Oldpwd = tadmin.Admin_PWD;
            string Oldpwd2 = CommonLibrary.MyEncryption.CreateMD5(Tbx_oldpassword.Text.Trim(), 32);
            if (Oldpwd != Oldpwd2)
            {
                CommonLibrary.RunJs.AlertAndBack("原始密码输入错误");
            }
            else
            {
                string Newpwd = CommonLibrary.MyEncryption.CreateMD5(Tbx_password2.Text.Trim(), 32);
                adminbll.ChangePwd(Newpwd, AdminID);
                CommonLibrary.RunJs.PageReplace("Admin_UpdateManage.aspx?LastID=" + AdminID);
            }
           

        }
    }
}
