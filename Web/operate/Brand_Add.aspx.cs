using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TBLL;
using TDAl;
using TModel;
using Web.operate.tool;
namespace Web.operate
{
    public partial class Brand_Add : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (this.LoginUser != null)
                {
                    Tbx_Addtime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    Tbx_Adder.Text = LoginUser.Admin_RealName;
                    H_Adder.Value = LoginUser.Admin_ID.ToString();
                }
            }
        }

        #region 初始化变量
        private TBrand InitBrand()
        {
            string BrandName = tbx_title.Text;
            bool IsRecom = false;
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("Chk_tuijian"), out IsRecom);
            string BrandMemo = ContentHolder.Value;
            string BrandPic = string.Empty;
            BrandPic = CommonLibrary.CommOperate.GetStrFromRequestForm("CatePic");
            string BrandTemplate = Tbx_BrandTemplate.Text.Trim();
            bool IsHtml = false;
            string BrandHtmlPath = Tbx_htmlpath.Text;
            bool IsRemote = false;
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("Chk_Remote"), out IsRemote);
            DateTime BrandAddtime;
            DateTime.TryParse(Tbx_Addtime.Text, out BrandAddtime);
            int BrandAdder = 0;
            Int32.TryParse(H_Adder.Value, out BrandAdder);
            int SortID = 0;
            Int32.TryParse(tbx_SortId.Text, out SortID);

            TBrand tbrand = new TBrand();
            tbrand.BrandName = BrandName;
            tbrand.IsRecom = IsRecom;
            if (IsRemote == true)
            {
                tbrand.BrandMemo = ImageOperate.GetRemoteImage(BrandMemo, "/uploadfile/remote/");
            }
            else
            {
                tbrand.BrandMemo = BrandMemo;
            }
            tbrand.BrandPic = BrandPic;
            tbrand.BrandTemplate = BrandTemplate;
            tbrand.IsHtml = IsHtml;
            tbrand.BrandHtmlPath = BrandHtmlPath;
            tbrand.IsRemote = IsRemote;
            tbrand.BrandAddtime = BrandAddtime;
            tbrand.BrandAdder = BrandAdder;
            tbrand.SortID = SortID;

            return tbrand;

        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            TBrand tbrand = InitBrand();
            BrandBLL brandbll = new BrandBLL();
            brandbll.AddBrand(tbrand);
            int lastid = brandbll.GetLastID();
            CommonLibrary.RunJs.PageReplace("Brand_UpdateManage.aspx?LastID=" + lastid);
        }
    }
}
