using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TBLL;
using TDAl;
using TModel;
using Web.operate.tool;
namespace Web.operate
{
    public partial class InfoCateTree : System.Web.UI.Page
    {
        protected static TBLL.NodeBLL nodebll = new TBLL.NodeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                TNode tnode = new TNode();
                NodeBLL nodebll = new NodeBLL();
                DataTable dt = nodebll.GetAllNode();
                L_CateTree.Text=NodeTree.GetJqueryNodeTree(dt,0);
            }
        }
    }
}
