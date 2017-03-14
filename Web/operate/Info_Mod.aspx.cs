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
    public partial class Info_Mod : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                int infoid = 0;
                Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out infoid);
                TInformation tinfo = new TInformation();
                InfoBLL infobll = new InfoBLL();
                AdminBLL adinbll = new AdminBLL();
                tinfo = infobll.GetInfo(infoid);

                tbx_title.Text = tinfo.InfoTitle;
                Tbx_SubMemo.Text = tinfo.InfoSubMemo;
                ContentHolder.Value = tinfo.InfoMemo;
                #region 图片列表
                L_selpic.Text = ImageOperate.GetImageSelect(tinfo.InfoMemo, tinfo.InfoPic);
                #endregion

                #region  信息类型
                if (tinfo.InfoType == 1)
                {
                    L_selinfotype.Text = "<select id='sel_SelInfoType' name='sel_SelInfoType' > <option value=\"1\" selected=selected> 新闻 </option> <option value=\"2\"> 产品 </option></select>";
                 
                
                }
                else if(tinfo.InfoType==2)
                {
                    L_selinfotype.Text = "<select id='sel_SelInfoType' name='sel_SelInfoType' > <option value=\"1\" > 新闻 </option> <option value=\"2\" selected=selected> 产品</option></select>";
                    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "InitInfoType", "$('.dazhe').hide();", true);
                    L_js.Text = @"<script type='text/javascript'>
                                 $(document).ready( function()
                                  {  $('.dazhe').hide();}
                                 );
                         </script>";
                }
                 

                #endregion

                #region  商家id
                int shopid = tinfo.ShopID;
                L_shopid.Text = "<input type=\"hidden\" id=\"h_shopid\" name=\"h_shopid\"  value=\""+shopid+"\"/>";
                if (shopid == -1)
                {
                    tbx_ShopID.Text = "暂无商家";
                }
                else
                {
                    ShopBLL shopbll = new ShopBLL();
                    tbx_ShopID.Text = shopbll.GetShop(shopid).ShopTitle;
                }
                #endregion


                #region 品牌信息
                int brandid = tinfo.BrandID;
                L_brandid.Text = "<input type=\"hidden\" id=\"h_brandid\" name=\"h_brandid\"  value=\""+brandid+"\"/>";
                if (brandid == -1)
                {
                    tbx_brand.Text = "暂无品牌信息";
                }
                else
                {
                    BrandBLL brandbll = new BrandBLL();
                    tbx_brand.Text = brandbll.GetBrandByID(brandid).BrandName;
                }
                #endregion

                tbx_SortId.Text = tinfo.SortID.ToString();
                tbx_Etitle.Text = tinfo.InfoETitle;
                Tbx_modifier.Text= this.LoginUser.Admin_RealName;
                H_Modifier.Value= LoginUser.Admin_ID.ToString();

                Tbx_modifytime.Text = tinfo.ModifyTime.ToString("yyyy-MM-dd hh:mm:ss");
                //Tbx_Adder.Text = this.LoginUser.Admin_RealName;
                //H_Adder.Value = LoginUser.Admin_ID.ToString();
                int Adder = 0;
                Int32.TryParse(tinfo.InfoAdder, out Adder);
                Tbx_Adder.Text = adinbll.GetAdmin(Adder).Admin_RealName;
                H_Adder.Value = Adder.ToString();
                Tbx_BeginTime.Text = tinfo.InfoStartTime;
                Tbx_EndTime.Text = tinfo.InfoEndTime;
                Tbx_from.Text = tinfo.InfoFrom;
                Tbx_Addtime.Text = tinfo.InfoAddTime.ToString("yyyy-MM-dd hh:mm:ss");
                Tbx_clicknum.Text = tinfo.InfoClicks.ToString();

                if (tinfo.IsRecom == true)
                {
                    L_IsRecoom.Text = "<input type=\"checkbox\" id=\"Chk_tuijian\" name=\"Chk_tuijian\"  Checked=Checked  value=\"true\" />";
                }
                else
                {
                    L_IsRecoom.Text = "<input type=\"checkbox\" id=\"Chk_tuijian\" name=\"Chk_tuijian\"    value=\"true\" />";
                }
                if (tinfo.IsRemote == true)
                {
                    L_isRemote.Text = "<input type=\"checkbox\" id=\"Chk_Remote\" name=\"Chk_Remote\" value=\"true\" Checked=Checked />";
                }
                else
                {
                    L_isRemote.Text = "<input type=\"checkbox\" id=\"Chk_Remote\" name=\"Chk_Remote\" value=\"true\" />";
                }

                Tbx_tag.Text = tinfo.InfoTag;

                NodeBLL nodebll = new NodeBLL();
                DataTable dt = nodebll.GetAllNode();
                L_CateTree.Text = "<select  id='sel' name='sel'><option value='-1'>请选择类别...</option>";
                if (dt.Rows.Count > 0)
                {
                    L_CateTree.Text += tool.NodeTree.GetNodeTree(dt, 0, 0,tinfo.InfoCateID);
                }
                L_CateTree.Text += "</Select>";

            
                

            }
        }


        #region 初始化变量
        /// <summary>
        /// 初始化变量
        /// </summary>
        /// <param name="ischeck">是否初始化</param>
        /// <returns></returns>
        private TInformation InitInfo(bool ischeck)
        {
            #region  变量
            int infoid = 0;
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out infoid);
            string InfoTitle = string.Empty;//信息标题
            InfoTitle = tbx_title.Text.Trim();
            string InfoSubMemo = string.Empty;//内容简介
            InfoSubMemo = Tbx_SubMemo.Text.Trim();
            string InfoMemo = string.Empty;//信息内容
            InfoMemo = ContentHolder.Value;
            string InfoPic = string.Empty;//信息封面图片
            InfoPic = CommonLibrary.CommOperate.GetStrFromRequestForm("CatePic");
            int InfoType = 0;//信息类型（1衣2食3住4行）
            //Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("h_brandid"), out InfoType);
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("sel_SelInfoType"), out InfoType);

            int BrandID = 0;//品牌ID
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("h_brandid"), out BrandID);
            int ShopID = 0;//商家ID
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("h_shopid"), out ShopID);
            string InfoStartTime = string.Empty;//活动开始时间
            InfoStartTime = Tbx_BeginTime.Text.Trim();
            string InfoEndTime = string.Empty;//活动截止时间
            InfoEndTime = Tbx_EndTime.Text.Trim();
            string InfoFrom = string.Empty;//信息来源
            InfoFrom = Tbx_from.Text.Trim();
            DateTime InfoAddTime;
            DateTime.TryParse(Tbx_Addtime.Text, out InfoAddTime);
            string InfoAdder = string.Empty;//添加人
            InfoAdder = H_Adder.Value.Trim();
            int InfoClicks = 0;//点击数
            Int32.TryParse(Tbx_clicknum.Text, out InfoClicks);
            bool IsRecom = false;//是否推荐 默认为否
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("Chk_tuijian"), out IsRecom);
            int SortID = 0;//排序号
            Int32.TryParse(tbx_SortId.Text, out SortID);
            bool IsHtml = false;//是否生成html
            string HtmlPath = string.Empty;//生成html路径
            bool IsRemote = false;//是否远程存图
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("Chk_Remote"), out IsRemote);

            bool IsCheck = ischeck;//是否通过验证
            int InfoCateID = 0;//信息类别ID
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("sel"), out InfoCateID);
            if (InfoCateID == -1)
            {
                CommonLibrary.RunJs.AlertAndBack("请选择类别");
            }
            string InfoETitle = string.Empty;//英文标题
            InfoETitle = tbx_Etitle.Text.Trim();

            string InfoTag = Tbx_tag.Text.Trim();
            #endregion

            TInformation tinfo = new TInformation();
            #region 初始化变量
            tinfo.InfoID = infoid;
            tinfo.InfoTitle = InfoTitle;
            tinfo.InfoSubMemo = InfoSubMemo;
            if (IsRemote == true)
            {
                tinfo.InfoMemo = ImageOperate.GetRemoteImage(InfoMemo, "/uploadfile/remote/");
            }
            else
            {
                tinfo.InfoMemo = InfoMemo;
            }
            tinfo.InfoPic = InfoPic;
            tinfo.InfoType = InfoType;
            tinfo.BrandID = BrandID;
            tinfo.ShopID = ShopID;
            tinfo.InfoStartTime = InfoStartTime;
            tinfo.InfoEndTime = InfoEndTime;
            tinfo.InfoFrom = InfoFrom;
            tinfo.InfoAddTime = InfoAddTime;
            tinfo.InfoAdder = InfoAdder;
            tinfo.InfoClicks = InfoClicks;
            tinfo.IsRecom = IsRecom;
            tinfo.SortID = SortID;
            tinfo.IsHtml = IsHtml;
            tinfo.HtmlPath = HtmlPath;
            tinfo.IsRemote = IsRemote;
            tinfo.IsCheck = IsCheck;
            tinfo.InfoCateID = InfoCateID;
            tinfo.InfoETitle = InfoETitle;
            tinfo.InfoTag = InfoTag;
            tinfo.ModifyBy = LoginUser.Admin_ID;
            tinfo.ModifyTime = DateTime.Now;
            #endregion
            return tinfo;
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {

            TInformation tinfo = InitInfo(false);
            tinfo.ModifyBy = this.LoginUser.Admin_ID;
            tinfo.ModifyTime = DateTime.Now;
            InfoBLL infobll = new InfoBLL();
 
            int lastid = infobll.UpdateInfo(tinfo, tinfo.InfoID);
            CommonLibrary.RunJs.PageReplace("Info_UpdateManage.aspx?LastID=" + tinfo.InfoID + "&cid=" + tinfo.InfoCateID);

           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            TInformation tinfo = InitInfo(true);
            InfoBLL infobll = new InfoBLL();
            int lastid = infobll.UpdateInfo(tinfo, tinfo.InfoID);
            CommonLibrary.RunJs.PageReplace("Info_UpdateManage.aspx?LastID=" + tinfo.InfoID + "&cid=" + tinfo.InfoCateID);

        }
    }
}
