using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TBLL;
using TDAl;
using TModel;
namespace Web.operate
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] is object)
            {
                TAdmin Loguser = Session["LoginUser"] as TAdmin;
                if (Loguser != null)
                {
                    L_changepwd.Text = "<a href=\"Admin_Password_Mod.aspx?id=" + Loguser.Admin_ID + "\" target=\"frmright\">ÐÞ¸ÄµÇÂ½ÃÜÂë</a>";
                }
            }
        }
    }
}
