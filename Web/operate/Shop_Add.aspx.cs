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
    public partial class Shop_Add :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
              AddressBLL addbll = new AddressBLL();
              DataTable dt_province = addbll.GetAllProvince();
              StringBuilder sb = new StringBuilder();
              sb.Append("<option value=\"-1\">请选择...</option>");
              if (dt_province.Rows.Count > 0)
              {   for(int i=0;i<dt_province.Rows.Count;i++)
                  {
                      sb.Append("<option value='" + dt_province.Rows[i]["code"] + "'>" + dt_province.Rows[i]["name"] + "</option>");
                  }
              }
              L_province.Text = sb.ToString();
              Tbx_Addtime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

              if (this.LoginUser != null)
              {
                  Tbx_Adder.Text = LoginUser.Admin_RealName;
                  H_Adder.Value = LoginUser.Admin_ID.ToString() ;
              }
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 变量

            string ShopTitle = tbx_title.Text.Trim();
            string ShopETitle =Tbx_Identifier.Text.Trim();
            string ShopPic = CommonLibrary.CommOperate.GetStrFromRequestForm("CatePic");
            string ShopMemo = ContentHolder.Value;
            string ShopProvince = CommonLibrary.CommOperate.GetStrFromRequestForm("Sel_Province");
            if (ShopProvince.Equals("-1"))
            {
                CommonLibrary.RunJs.AlertAndBack("请选择省");
            }
            string ShopCity = CommonLibrary.CommOperate.GetStrFromRequestForm("Sel_City");
            if (ShopCity.Equals("-1"))
            {
                CommonLibrary.RunJs.AlertAndBack("请选择市");
            }
            string ShopArea = CommonLibrary.CommOperate.GetStrFromRequestForm("Sel_Area");
            if (ShopArea.Equals("-1"))
            {
                CommonLibrary.RunJs.AlertAndBack("请选择区");
            }
            string ShopLongitude = tbx_ShopLongitude.Text.Trim();//经度
            string ShopLatitude =tbx_ShopLatitude.Text.Trim();//纬度
            string ShopRoute = tbx_ShopRoute.Text.Trim();//交通路线
            string ShopOpenTime = tbx_ShopOpenTime.Text.Trim();//开业时间
            string ShopTemplate = Tbx_ShopTemplate.Text.Trim();//商场模板
            DateTime ShopAddtime;
            DateTime.TryParse(Tbx_Addtime.Text.Trim(), out ShopAddtime);
            string ShopAdder = H_Adder.Value;
            int SortID = 0;
            Int32.TryParse(tbx_SortId.Text, out SortID);
            bool IsRecom = false;
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("Chk_tuijian"), out IsRecom);
            bool IsHtml = false;
            string HtmlPath = Tbx_htmlpath.Text.Trim();
            bool IsRemote = false;//是否远程，获取图片，默认为否
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("Chk_Remote"), out IsRemote);
            #endregion

            TShop ts = new TShop();
            ts.ShopTitle = ShopTitle;
            ts.ShopETitle = ShopETitle;
            ts.ShopPic = ShopPic;
           
            if (IsRemote == true)
            {
                ts.ShopMemo = ImageOperate.GetRemoteImage(ShopMemo,"/uploadfile/remote/");
            }
            else
            {
                ts.ShopMemo = ShopMemo;
            }
            ts.ShopProvince = ShopProvince;
            ts.ShopCity = ShopCity;
            ts.ShopArea = ShopArea;
            ts.ShopLongitude = ShopLongitude;
            ts.ShopLatitude = ShopLatitude;
            ts.ShopRoute = ShopRoute;
            ts.ShopOpenTime = ShopOpenTime;
            ts.ShopTemplate = ShopTemplate;
            ts.ShopAddtime = ShopAddtime;
            ts.ShopAdder = ShopAdder;
            ts.SortID = SortID;
            ts.IsRecom = IsRecom;
            ts.IsHtml = IsHtml;
            ts.HtmlPath = HtmlPath;
            ts.IsRemote = IsRemote;
            TBLL.ShopBLL shopbll = new ShopBLL();
            shopbll.AddShop(ts);
            int lastid = shopbll.GetLastShopID();
            CommonLibrary.RunJs.PageReplace("Shop_UpdateManage.aspx?LastID=" + lastid);
        }
    }
}
