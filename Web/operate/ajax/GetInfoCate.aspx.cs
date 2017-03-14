using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
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
    public partial class GetInfoCate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            int pid = 0;
            string SelectVal = string.Empty;
            Int32.TryParse(CommOperate.GetStrFromRequestForm("uid"), out pid);
            SelectVal = CommOperate.GetStrFromRequestForm("sv");

            TBLL.NodeBLL nbl = new NodeBLL();
            DataTable childlist = nbl.GetChildNode(pid);
            if (childlist.Rows.Count> 0)
            {
                sb.Append("<option value='-1'>请选择...</option>");
                for (int i = 0; i < childlist.Rows.Count; i++)
                {

                    sb.Append("<option value='" + childlist.Rows[i]["NodeId"].ToString().Trim() + "'>" + childlist.Rows[i]["NodeName"].ToString().Trim() + "</opion>");
                }
            }
            else
            {
                sb.Append("0");
            }

            Response.Write(sb.ToString());
            Response.End();
           
        
        }
    }
}
