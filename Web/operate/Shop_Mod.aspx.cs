using System;
using System.Text;
using System.Data;
using System.Collections;
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
    public partial class Shop_Mod : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                int shopid = 0;
                Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out shopid);
                TShop tshop = new TShop();
               
                ShopBLL spbll = new ShopBLL();
                tshop = spbll.GetShop(shopid);
                tbx_title.Text = tshop.ShopTitle;
                Tbx_Identifier.Text=tshop.ShopETitle;
                ContentHolder.Value = tshop.ShopMemo;
                tbx_ShopLongitude.Text = tshop.ShopLongitude;
                tbx_ShopLatitude.Text = tshop.ShopLatitude;
                tbx_ShopRoute.Text = tshop.ShopRoute;
                tbx_ShopOpenTime.Text = tshop.ShopOpenTime;
                Tbx_ShopTemplate.Text = tshop.ShopTemplate;
                Tbx_Addtime.Text = tshop.ShopAddtime.ToString("yyyy-MM-dd hh:mm:ss");
                Tbx_Adder.Text = this.LoginUser.Admin_RealName;
                H_Adder.Value = LoginUser.Admin_ID.ToString();
                tbx_SortId.Text = tshop.SortID.ToString();
                if (tshop.IsRecom == true)
                {
                    L_IsRecoom.Text = "<input type=\"checkbox\" id=\"Chk_tuijian\" name=\"Chk_tuijian\"  Checked=Checked  value=\"true\" />";
                }
                else
                {
                    L_IsRecoom.Text = "<input type=\"checkbox\" id=\"Chk_tuijian\" name=\"Chk_tuijian\"    value=\"true\" />";

                }

             

                Tbx_htmlpath.Text = tshop.HtmlPath;

                #region  省 市 地区
                string ShopProvince = string.Empty;
                ShopProvince = tshop.ShopProvince;
                string ShopCity = string.Empty;
                ShopCity = tshop.ShopCity;
                string ShopArea = string.Empty;
                ShopArea = tshop.ShopArea;

                AddressBLL addbll=new AddressBLL();
                StringBuilder sb = new StringBuilder();
                    #region 省
                    using (DataTable dtprovince = addbll.GetAllProvince())
                    {
                        sb.Append("<option value=\"-1\">请选择...</option");
                        if (dtprovince.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtprovince.Rows.Count; i++)
                            {
                                if (dtprovince.Rows[i]["code"].ToString().Equals(ShopProvince))
                                {
                                    sb.Append("<option value='" + dtprovince.Rows[i]["code"] + "' selected=selected>" + dtprovince.Rows[i]["name"] + "</option>");
                                }
                                else
                                {
                                    sb.Append("<option value='" + dtprovince.Rows[i]["code"] + "'>" + dtprovince.Rows[i]["name"] + "</option>");
                                }
                            }
                        }
                    }
                    L_province.Text = sb.ToString();
                    sb.Length = 0;
                    #endregion
                    #region 市
                    using (DataTable dtcity = addbll.GetCityByProvince(ShopProvince))
                    {
                        sb.Append("<option value='-1'>市</option>");
                        if (dtcity.Rows.Count > 0)
                        {   
                            for (int i = 0; i < dtcity.Rows.Count; i++)
                            {   
                                if (dtcity.Rows[i]["code"].ToString().Equals(ShopCity))
                                {
                                    sb.Append("<option value='" + dtcity.Rows[i]["code"].ToString() + "' selected=selected>" + dtcity.Rows[i]["name"].ToString() + "</option>");
                                }
                                else
                                {
                                    sb.Append("<option value='" + dtcity.Rows[i]["code"].ToString() + "'>" + dtcity.Rows[i]["name"].ToString() + "</option>");
                                }
                            }
                        }
                    }
                    L_City.Text = sb.ToString();
                    #endregion
                    sb.Length = 0;
                    #region 地区
                    using (DataTable dtarea = addbll.GetAreaByCity(ShopCity))
                    {
                        sb.Append("<option value='-1'>地区</option>");
                        for (int i = 0; i < dtarea.Rows.Count; i++)
                        {
                            if (dtarea.Rows[i]["code"].ToString().Equals(ShopArea))
                            {
                                sb.Append("<option value='" + dtarea.Rows[i]["code"].ToString() + "' selected=selected>" + dtarea.Rows[i]["name"].ToString() + "</option>");
                            }
                            else
                            {
                                sb.Append("<option value='" + dtarea.Rows[i]["code"].ToString() + "'  >" + dtarea.Rows[i]["name"].ToString() + "</option>");
                            }
                        }

                    }
                    L_Area.Text = sb.ToString();
                    #endregion

                #endregion


                #region 是否获取远程图片
                 if (tshop.IsRemote == true)
                {
                    L_isRemote.Text = "<input type=\"checkbox\" id=\"Chk_Remote\" name=\"Chk_Remote\" value=\"true\" Checked=Checked />";
                }
                else
                {
                    L_isRemote.Text = "<input type=\"checkbox\" id=\"Chk_Remote\" name=\"Chk_Remote\" value=\"true\" />";
                }
                #endregion

                #region 图片列表
                L_selpic.Text = ImageOperate.GetImageSelect(tshop.ShopMemo, tshop.ShopPic);
                #endregion


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 变量
            string ShopTitle = tbx_title.Text.Trim();
            string ShopETitle = Tbx_Identifier.Text.Trim();
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
            string ShopLatitude = tbx_ShopLatitude.Text.Trim();//纬度
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

            int shopid = 0;
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out shopid);
           
            bool IsRemote = false;//是否远程，获取图片，默认为否
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("Chk_Remote"), out IsRemote);
            #endregion

            TShop ts = new TShop();
            ts.ShopTitle = ShopTitle;
            ts.ShopETitle = ShopETitle;
            ts.ShopPic = ShopPic;
            if (IsRemote == true)
            {
                ts.ShopMemo = ImageOperate.GetRemoteImage(ShopMemo, "/uploadfile/remote/");
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

            ShopBLL spbll = new ShopBLL();
            spbll.UpdateShop(ts, shopid);
            CommonLibrary.RunJs.PageReplace("Shop_UpdateManage.aspx?LastID=" + shopid);
        }
    }
}
