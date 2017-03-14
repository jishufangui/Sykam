using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CommonLibrary;
using TBLL;
using TDAl;
using TModel;
namespace Web.operate
{
    public partial class OperateIndex :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (this.LoginUser != null)
                {
                    int adminid = this.LoginUser.Admin_ID;
                    TBLL.AdminBLL adminbll = new TBLL.AdminBLL();
                    TModel.TAdmin tadmin = new TModel.TAdmin();
                    tadmin = adminbll.GetAdmin(adminid);

                    lit_Count.Text = tadmin.Admin_LogTimes.ToString();
                    lit_TrueName.Text = this.LoginUser.Admin_RealName;
                    lit_User.Text = LoginUser.Admin_UID;
                    lit_ClientIP.Text = SystemVariables.GetClientIP();
                    lit_ServerIP.Text = SystemVariables.GetServerIP();
                    lit_Directory.Text = Server.MapPath("/");
                    lit_ServerName.Text = SystemVariables.GetServerName();
                    lit_ServerOs.Text = SystemVariables.GetServerOs();
                    lit_ScriptEngin.Text = SystemVariables.GetSoftWare();
                    lit_CPU.Text = SystemVariables.GetNumberOfCPU();
                    lit_ClientOS.Text = SystemVariables.GetClientOS();
                    L_browser.Text = SystemVariables.GetClientBrowser();
                }
              
            }
        }
    }
}
