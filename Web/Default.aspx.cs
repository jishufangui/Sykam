using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TBLL;
using TDAl;
using TModel;
namespace Web
{
    public partial class _Default : BaseWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TBLL.ShopBLL sbll = new TBLL.ShopBLL();
            Title = "首页-" + GetTitle();
        }

        #region  ------私有方法------


        private string LastNews()
        {
            string NewsList = string.Empty;
            return NewsList;
        }

        #endregion
    }
}
