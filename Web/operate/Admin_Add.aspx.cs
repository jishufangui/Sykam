using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using TBLL;
using TDAl;
using TModel;
namespace Web.operate
{
    public partial class Admin_Add : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Tbx_Addtime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            }
        }


        protected TAdmin InitAdmin()
        {
            #region 变量
            int Admin_ID = 0;
            string Admin_UID = tbx_uid.Text.Trim();
            string Admin_PWD1 = Tbx_password1.Text.Trim();
            string Admin_PWD2=Tbx_password2.Text.Trim();

            bool Admin_Stat = true;
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("sel_stat"), out Admin_Stat);
            string Admin_RealName = tbx_nickname.Text.Trim();
            DateTime Admin_RegTime;
            DateTime.TryParse(Tbx_Addtime.Text, out Admin_RegTime);
            int Admin_LogTimes = 0;
            Int32.TryParse(Tbx_logtimes.Text, out Admin_LogTimes);
            string Admin_Flag = string.Empty;
            int SortID = 0;
            Int32.TryParse(tbx_SortId.Text, out SortID);
            if (Admin_PWD1 != Admin_PWD2)
            {
                CommonLibrary.RunJs.AlertAndBack("两次输入密码不一致");
                return default(TAdmin);
            }
            else
            {
                TAdmin tadmin = new TAdmin();
                tadmin.Admin_UID = Admin_UID;
                tadmin.Admin_PWD = CommonLibrary.MyEncryption.CreateMD5(Admin_PWD2,32);
                tadmin.Admin_Stat = Admin_Stat;
                tadmin.Admin_RealName = Admin_RealName;
                tadmin.Admin_RegTime = Admin_RegTime;
                tadmin.Admin_LogTimes = Admin_LogTimes;
                tadmin.Admin_Flag = Admin_Flag;
                tadmin.SortID = SortID;

                return tadmin;
            }

            #endregion
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TAdmin tadmin = InitAdmin();
            AdminBLL adminbll = new AdminBLL();
            adminbll.AddAdmin(tadmin);
            int lastid = adminbll.GetLastID();
            CommonLibrary.RunJs.PageReplace("Admin_UpdateManage.aspx?LastID=" + lastid );
        }


    }
}
