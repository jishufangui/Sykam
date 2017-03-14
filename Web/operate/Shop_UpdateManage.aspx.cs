using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.operate
{
    public partial class Shop_UpdateManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string infoid = CommonLibrary.CommOperate.GetStrFromRequestQueryString("lastid");
                string pid = CommonLibrary.CommOperate.GetStrFromRequestQueryString("pid");
                L_info.Text = "<a href=\"Shop_Mod.aspx?id=" + infoid + "\">继续修改</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"Shop_Add.aspx\">继续添加</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"Shop_List.aspx\">返回上级</a>";
            }
        }
    }
}
