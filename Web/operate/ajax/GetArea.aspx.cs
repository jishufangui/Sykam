using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TBLL;
using TDAl;
using CommonLibrary;
namespace Web.operate.ajax
{
    public partial class GetArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pid = CommonLibrary.CommOperate.GetStrFromRequestQueryString("pid");
                StringBuilder sb = new StringBuilder();
                sb.Append("<option value='-1'>请选择...</option>");
                AddressBLL addbll = new AddressBLL();
                DataTable dt = addbll.GetAreaByCity(pid);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("<option value='" + dt.Rows[i]["code"].ToString() + "'>" + dt.Rows[i]["name"].ToString() + "</option>");
                    }
                }
                Response.Write(sb.ToString());
                Response.End();

            }
        }
    }
}
