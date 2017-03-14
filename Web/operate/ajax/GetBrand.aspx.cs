using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TBLL;
using TDAl;
using CommonLibrary;
namespace Web.operate.ajax
{
    public partial class GetBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Keyword = Server.UrlDecode(CommonLibrary.CommOperate.GetStrFromRequestQueryString("q"));
                BrandBLL brandbll = new BrandBLL();
                Response.ContentType = "text/html";
                Response.Write(brandbll.GetBrandJson(Keyword));
                Response.End();

            }
        }
    }
}
