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
using System.Text;
using System.Xml;
using CommonLibrary;
using TBLL;
using TModel;
namespace Web.operate
{
    public partial class OperateLeft : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoginUser"] != null)
                {
                    TAdmin LoginUser = Session["LoginUser"] as TAdmin;
                    AdminBLL adminbll = new AdminBLL();
                    menubar.InnerHtml = adminbll.GetLeftMenu(LoginUser.Admin_Flag);
                }
              
            }
        }
    }
}
