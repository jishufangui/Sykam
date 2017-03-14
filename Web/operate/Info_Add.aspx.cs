using System;
using System.Data;
using System.Text;
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
    public partial class Info_Add : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                #region 类别树
                TNode tnode = new TNode();
                NodeBLL nodebll = new NodeBLL();
                DataTable dt = nodebll.GetAllNode();
                L_CateTree.Text = "<select  id='sel' name='sel'><option value='-1'>请选择类别...</option>";
                if (dt.Rows.Count > 0)
                {
                    L_CateTree.Text += tool.NodeTree.GetNodeTree(dt, 0, 0);
                }
                L_CateTree.Text += "</Select>";

                #endregion

                Tbx_Addtime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                Tbx_Adder.Text = this.LoginUser.Admin_RealName;
                H_Adder.Value = LoginUser.Admin_ID.ToString();

                InfoBLL infobll = new InfoBLL();
                tbx_SortId.Text = infobll.GetInfoCountsByNode(0, null, null, 1).ToString();
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
            string InfoTitle = string.Empty;//信息标题
            InfoTitle = tbx_title.Text.Trim();
            string InfoSubMemo = string.Empty;//内容简介
            InfoSubMemo = Tbx_SubMemo.Text.Trim();
            string InfoMemo = string.Empty;//信息内容
            InfoMemo = ContentHolder.Value;
            string InfoPic = string.Empty;//信息封面图片
            InfoPic= CommonLibrary.CommOperate.GetStrFromRequestForm("CatePic");
            int InfoType = 0;//信息类型（1衣2食3住4行）
            //Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("h_brandid"), out InfoType);
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("sel_SelInfoType"), out InfoType);

            int BrandID = 0;//品牌ID
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("h_brandid"),out BrandID);

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
            InfoAdder = H_Adder.Value.Trim() ;
           
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
            tinfo.ShopID = ShopID;
            tinfo.BrandID = BrandID;
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
            tinfo.InfoTag=InfoTag;
            #endregion
            return tinfo;
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            TInformation tinfo = InitInfo(false);
            
            InfoBLL infobll = new InfoBLL();
            infobll.AddInfo(tinfo);
            int lastid = infobll.GetLastID();
            CommonLibrary.RunJs.PageReplace("Info_UpdateManage.aspx?LastID=" + lastid + "&cid="+tinfo.InfoCateID);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TInformation tinfo = InitInfo(true);

            InfoBLL infobll = new InfoBLL();
            infobll.AddInfo(tinfo);
            int lastid = infobll.GetLastID();
            CommonLibrary.RunJs.PageReplace("Info_UpdateManage.aspx?LastID=" + lastid + "&cid=" +tinfo.InfoCateID);
        }
    }
}
