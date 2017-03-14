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
using System.Xml;
using System.Text;
using System.IO;
using CommonLibrary;
using TBLL;
using TModel;
namespace Web.operate
{
    public partial class OperateTop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["LoginUser"] != null)
                {
                    TAdmin LoginUser = Session["LoginUser"]  as  TAdmin;
                    AdminBLL adminbll = new AdminBLL();
                    menu.InnerHtml = adminbll.GetTopMenu(LoginUser.Admin_Flag);
                }
               
              
            }
        }
    }
}
