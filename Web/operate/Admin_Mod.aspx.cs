using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Text;
using TBLL;
using TDAl;
using TModel;
namespace Web.operate
{
    public partial class Admin_Mod : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int adminid = 0;
                Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out adminid);
                AdminBLL adminbll = new AdminBLL();
                TAdmin admin = adminbll.GetAdmin(adminid);
                tbx_uid.Text = admin.Admin_UID;
                tbx_SortId.Text = admin.SortID.ToString();
                tbx_nickname.Text = admin.Admin_RealName;
                Tbx_Addtime.Text = admin.Admin_RegTime.ToString("yyyy-MM-dd hh:mm:ss");
                Tbx_logtimes.Text = admin.Admin_LogTimes.ToString();
                tbx_SortId.Text = admin.SortID.ToString();
                bool adminstat = admin.Admin_Stat;

                if (adminstat.ToString().ToLower() == "true")
                {
                    L_stat.Text = "<select id=\"sel_stat\" name=\"sel_stat\"><option value=\"true\" selected='selected' >未锁定</option><option value=\"false\">已锁定</option></select>";
                }
                else
                {
                    L_stat.Text = "<select id=\"sel_stat\" name=\"sel_stat\"><option value=\"true\">未锁定</option><option value=\"false\" selected='selected'>已锁定</option></select>";
                }

            }
        }

        protected TAdmin InitAdmin()
        {
            #region 变量
            int Admin_ID = 0;
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out Admin_ID);
             
            string Admin_UID = tbx_uid.Text.Trim();
            bool Admin_Stat = true;
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("sel_stat"), out Admin_Stat);
            string Admin_RealName = tbx_nickname.Text.Trim();
            DateTime Admin_RegTime;
            DateTime.TryParse(Tbx_Addtime.Text, out Admin_RegTime);
            int Admin_LogTimes = 0;
            Int32.TryParse(Tbx_logtimes.Text, out Admin_LogTimes);
            int SortID = 0;
            Int32.TryParse(tbx_SortId.Text, out SortID);

            TAdmin tadmin = new TAdmin();
            tadmin.Admin_UID = Admin_UID;
            tadmin.Admin_Stat = Admin_Stat;
            tadmin.Admin_RealName = Admin_RealName;
            tadmin.Admin_RegTime = Admin_RegTime;
            tadmin.Admin_LogTimes = Admin_LogTimes;
            tadmin.SortID = SortID;
            tadmin.Admin_ID = Admin_ID;
            tadmin.ModifyBy = LoginUser.Admin_ID;
            tadmin.ModifyTime = DateTime.Now;
            return tadmin;
           

            #endregion
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            TAdmin tadmin = InitAdmin();
            AdminBLL adminbll = new AdminBLL();
            adminbll.UpdateAdmin(tadmin, tadmin.Admin_ID);
            int lastid = tadmin.Admin_ID;
            CommonLibrary.RunJs.PageReplace("Admin_UpdateManage.aspx?LastID=" + lastid);
        }
    }
}
