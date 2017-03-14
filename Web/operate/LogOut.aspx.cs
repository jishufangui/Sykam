using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.operate
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            Session.Abandon();
            System.Web.HttpContext.Current.Response.Write("<script>alert('您没有登录或长时间没有操作');window.top.location.replace('Login.aspx');</script>");
            System.Web.HttpContext.Current.Response.End();
        }
    }
}
