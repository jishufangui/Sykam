using System;
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
    public partial class InfoCate_Mod : BasePage
    {
        private int InfoID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {  
           
            if (!IsPostBack)
            {
                Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out InfoID);
                TNode tnode = new TNode();
                NodeBLL nodebll = new NodeBLL();
                tnode= nodebll.GetNode(InfoID);

                #region  初始化页面
                tbx_SortId.Text = tnode.SortID.ToString();//排序号
                tbx_title.Text = tnode.NodeName;//节点名
                Tbx_Identifier.Text = tnode.NodeIdentifier;//英文标示符
                int pid = tnode.ParentID;//父类ID
                ContentHolder.Value = tnode.NodeMemo;//内容
                Tbx_ListTemplate.Text = tnode.NodeTemplate;//节点模板；
                Tbx_DetailTemplate.Text = tnode.DetailTemplate;//详情页模板
                Tbx_htmlpath.Text = tnode.HtmlPath;//生成HTML目录
                #region  是否推荐
                if (tnode.IsRecom == true)
                {
                    L_IsRecoom.Text = "<input type=\"checkbox\" id=\"Chk_tuijian\" name=\"Chk_tuijian\"  Checked=Checked  value=\"true\" />";
                }
                else
                {
                    L_IsRecoom.Text = "<input type=\"checkbox\" id=\"Chk_tuijian\" name=\"Chk_tuijian\"    value=\"true\" />";

                }
                #endregion

                #region 是否获取远程图片
                if (tnode.IsRemote == true)
                {
                    L_isRemote.Text = "<input type=\"checkbox\" id=\"Chk_Remote\" name=\"Chk_Remote\" value=\"true\" Checked=Checked />";
                }
                else
                {
                    L_isRemote.Text = "<input type=\"checkbox\" id=\"Chk_Remote\" name=\"Chk_Remote\" value=\"true\" />";
                }
                #endregion

                #region 类别树
                DataTable dt = nodebll.GetAllNode();
                    L_CateTree.Text = "<select  id='sel' name='sel'><option value='0'>顶级类别</option>";
                    if (dt.Rows.Count > 0)
                    {
                        L_CateTree.Text += tool.NodeTree.GetNodeTree(dt, 0, 0,pid);
                    }
                    L_CateTree.Text += "</Select>";
                    #endregion

                L_selpic.Text = ImageOperate.GetImageSelect(tnode.NodeMemo, tnode.NodePic);


                Tbx_Descriotion.Text = tnode.Meta_Description;
                Tbx_Keyword.Text = tnode.Meta_KeyWords;
                Tbx_Addtime.Text = tnode.AddTime.ToString("yyyy-MM-dd hh:mm:ss");
                Tbx_Adder.Text = this.LoginUser.Admin_RealName;
                H_Adder.Value = LoginUser.Admin_ID.ToString();
                #endregion

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 变量
            int NodeId = 0;
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("id"), out NodeId);
            string NodeName = string.Empty;//节点名称
            NodeName = tbx_title.Text.Trim();
            string NodeIdentifier = string.Empty;//标示符
            NodeIdentifier = Tbx_Identifier.Text.Trim();
            string ParentStr = string.Empty;
            int ParentID = 0;//父类ID
            string NodePath = string.Empty;//节点路径

            #region 获取父类ID
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("sel"), out ParentID);
            #endregion

            string NodeMemo = string.Empty;//节点介绍
            NodeMemo = ContentHolder.Value;

            string NodePic = string.Empty;
            NodePic = CommonLibrary.CommOperate.GetStrFromRequestForm("CatePic");

            int sortid = 0;//排序号
            Int32.TryParse(tbx_SortId.Text, out sortid);

            bool IsRecom = false;//是否推荐
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("Chk_tuijian"), out IsRecom);

            bool IsHtml = false;//是否生成静态

            string HtmlPath = string.Empty;//生成html的路径
            HtmlPath = Tbx_htmlpath.Text;

            string NodeTemplate = string.Empty;//节点模板名称
            NodeTemplate = Tbx_ListTemplate.Text.Trim();

            string Meta_Description = string.Empty;//节点meta_description
            Meta_Description = Tbx_Descriotion.Text.Trim();

            string Meta_KeyWords = string.Empty;//节点meta_keyword
            Meta_KeyWords = Tbx_Keyword.Text.Trim();

            bool IsRemote = false;//是否远程，获取图片，默认为否
            bool.TryParse(CommonLibrary.CommOperate.GetStrFromRequestForm("Chk_Remote"), out IsRemote);


            DateTime Addtime;//添加时间
            Addtime = Convert.ToDateTime(Tbx_Addtime.Text.Trim());
            string DetailTemplate = string.Empty;//详情页模板
            DetailTemplate = Tbx_DetailTemplate.Text.Trim();
            string Adder = H_Adder.Value;
            #endregion

            TNode tnode = new TNode();
            tnode.NodeName = NodeName;
            tnode.NodeIdentifier = NodeIdentifier;
            tnode.ParentID = ParentID;
            tnode.NodePath = NodePath;
            if (IsRemote == true)
            {
                tnode.NodeMemo = ImageOperate.GetRemoteImage(NodeMemo, "/uploadfile/remote/");
            }
            else
            {
                tnode.NodeMemo = NodeMemo;
            }
            tnode.NodePic = NodePic;
            tnode.SortID = sortid;
            tnode.IsRecom = IsRecom;
            tnode.IsHtml = IsHtml;
            tnode.HtmlPath = HtmlPath;
            tnode.NodeTemplate = NodeTemplate;
            tnode.DetailTemplate = DetailTemplate;
            tnode.Meta_Description = Meta_Description;
            tnode.Meta_KeyWords = Meta_KeyWords;
            tnode.IsRemote = IsRemote;
            tnode.AddTime = Addtime;
            tnode.DetailTemplate = DetailTemplate;
            tnode.Adder = Adder;

            TBLL.NodeBLL NodeOperate = new NodeBLL();
            NodeOperate.UpdateNode(NodeId, tnode);
            CommonLibrary.RunJs.PageReplace("InfoCate_UpdateManage.aspx?LastID=" + NodeId+ "&pid=" + ParentID);
        }
    }
}
