using System;
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
    public partial class InfoCate_Add : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          
            if (!IsPostBack)
            {
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
            string NodeName = string.Empty;//节点名称
            NodeName = tbx_title.Text.Trim();
            string NodeIdentifier = string.Empty;//标示符
            NodeIdentifier = Tbx_Identifier.Text.Trim();
            string ParentStr = string.Empty;
            int ParentID = 0;//父类ID
            string NodePath = string.Empty;//节点路径

            #region 获取父类ID和路径
            //如果是顶级分类
            if (cbx_IsTop.Checked == true)
            {
                ParentStr = "0";
                NodePath = "0,";


            }
            else
            {
                ParentStr = CommonLibrary.CommOperate.GetStrFromRequestForm("topSelc");
                string[] ParentArry = ParentStr.Split(',');


                if (ParentArry[ParentArry.Length - 1] == "-1")
                {

                    if (ParentArry.Length == 1)
                    {
                        CommonLibrary.RunJs.AlertAndBack("请选择父类别");
                    }
                    else
                    {
                        ParentStr = ParentArry[ParentArry.Length - 2].ToString();
                        for (int i = 0; i < ParentArry.Length - 1; i++)
                        {
                            NodePath = NodePath + ParentArry[i].ToString() + ",";
                        }
                    }
                }
                else
                {
                    ParentStr = ParentArry[ParentArry.Length - 1].ToString();
                    for (int i = 0; i < ParentArry.Length; i++)
                    {
                        NodePath = NodePath + ParentArry[i].ToString() + ",";
                    }
                }

            }

            Int32.TryParse(ParentStr, out ParentID);
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
         

            DateTime Addtime ;//添加时间
            Addtime= Convert.ToDateTime(Tbx_Addtime.Text.Trim());
            string DetailTemplate = string.Empty;//详情页模板
            DetailTemplate = Tbx_DetailTemplate.Text.Trim();
            string Adder = H_Adder.Value.Trim();
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
            NodeOperate.AddNode(tnode);
            int lastid=NodeOperate.GetLastNodeID();
            CommonLibrary.RunJs.PageReplace("InfoCate_UpdateManage.aspx?LastID="+lastid+"&pid="+ParentID);
        }
    }
}
