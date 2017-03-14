using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.Common;
using TBLL;
using TDAl;
using TModel;
using Web.operate.tool;
namespace Web.operate
{
    public partial class Brand_Mod : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                int Brandid = 0;
                Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out Brandid);
                TBrand tbrand = new TBrand();
                BrandBLL brandbll = new BrandBLL();
                
                tbrand = brandbll.GetBrandByID(Brandid);
                tbx_title.Text = tbrand.BrandName;
                ContentHolder.Value = tbrand.BrandMemo;
                #region 图片列表
                L_selpic.Text = ImageOperate.GetImageSelect(tbrand.BrandMemo, tbrand.BrandPic);
                #endregion
                Tbx_BrandTemplate.Text = tbrand.BrandTemplate;
                if (tbrand.IsRemote == true)
                {
                    L_isRemote.Text = "<input type=\"checkbox\" id=\"Chk_Remote\" name=\"Chk_Remote\" value=\"true\" Checked=Checked />";
                }
                else
                {
                    L_isRemote.Text = "<input type=\"checkbox\" id=\"Chk_Remote\" name=\"Chk_Remote\" value=\"true\" />";
                }

                if (tbrand.IsRecom == true)
                {
                    L_IsRecoom.Text = "<input type=\"checkbox\" id=\"Chk_tuijian\" name=\"Chk_tuijian\"  Checked=Checked  value=\"true\" />";
                }
                else
                {
                    L_IsRecoom.Text = "<input type=\"checkbox\" id=\"Chk_tuijian\" name=\"Chk_tuijian\"    value=\"true\" />";
                }

                Tbx_Addtime.Text = tbrand.BrandAddtime.ToString("yyyy-MM-dd hh:mm:ss");
                Tbx_Adder.Text = LoginUser.Admin_RealName;
                H_Adder.Value = LoginUser.Admin_ID.ToString();
                tbx_SortId.Text = tbrand.SortID.ToString() ;
                Tbx_htmlpath.Text = tbrand.BrandHtmlPath;
            }
        }


        #region 初始化变量
        private TBrand InitBrand()
        {
            int Brandid = 0;
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out Brandid);
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
            tbrand.BrandID = Brandid;
            return tbrand;

        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            TBrand tbrand = InitBrand();
            BrandBLL brandbll = new BrandBLL();
            brandbll.UpdateBrand(tbrand, tbrand.BrandID);
            CommonLibrary.RunJs.PageReplace("Brand_UpdateManage.aspx?LastID=" + tbrand.BrandID);
        }
    }
}
