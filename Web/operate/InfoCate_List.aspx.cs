using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;
using TBLL;
using TDAl;
using TModel;
using Web.operate.tool;
namespace Web.operate
{
    public partial class InfoCate_List : BasePage
    {

        protected static TBLL.NodeBLL nodebll = new TBLL.NodeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pg_Init();
            }
        }

        #region  页面初始化
        protected void Pg_Init()
        {   
            ArrayList fieldName=new ArrayList();
            ArrayList fieldValue= new ArrayList();

            ArrayList selName = new ArrayList();
            ArrayList selValue = new ArrayList();
            string param = string.Empty;
            int cid = 0;

            if (CommonLibrary.CommOperate.GetStrFromRequestQueryString("pid") != null && CommonLibrary.CommOperate.GetStrFromRequestQueryString("pid") != "")
            {
                fieldName.Add("pid");
                fieldValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("pid") );
                selName.Add("ParentID");
                cid = 0;
                Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("pid"), out cid);
              
                selValue.Add(cid);
             
            }
            else if (CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword") != null && CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword") != "")
            {
                fieldName.Add( "keyword" );
                fieldValue.Add( CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword") );
                selName.Add("NodeName");
                selValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword"));
                
            }
            else
            {
                fieldName = null;
                fieldValue = null;
                selName.Add("ParentID");
                selValue.Add(0);
            }

            int currentPage, pageSize, pageCount = 1, recordCount = 0;
           
            pageSize = 15;

            recordCount = nodebll.GetNodeCounts(selName, selValue);
 
            currentPage = tool.PageAndCount.GetCurrent(recordCount, pageSize);
            int startId = tool.PageAndCount.StartID(currentPage, pageSize);
            int endId = tool.PageAndCount.EndID(currentPage, pageSize);
            GridView1.DataSource = nodebll.GetNodeByCondition(selName, selValue, "  SortID asc,NodeId desc", startId, endId);
            GridView1.DataKeyNames = new String[] { "NodeId" };
            GridView1.DataBind();

            TBLL.NodeBLL NodeOperate = new NodeBLL();
            lbl_CurrentNode.Text= NodeTree.GetNodePath(NodeOperate.GetNode(cid).NodePath);
            PagerClass.PageSet ps = new PagerClass.PageSet(currentPage, recordCount, pageSize, fieldName, fieldValue);
            L_page.Text = ps.GeneratePagers();



        }

        #endregion

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Infoid;
            Int32.TryParse(GridView1.DataKeys[e.RowIndex].Value.ToString(), out Infoid);
            DeleteNode(Infoid);
            Pg_Init();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drow = e.Row.DataItem as DataRowView;
            if (drow != null)
            {

                HiddenField hRecom = (HiddenField)e.Row.Cells[2].FindControl("H_Recom");
                if (hRecom.Value.Trim().ToLower() == "true")
                {
                    Literal L_recom = (Literal)e.Row.Cells[2].FindControl("L_Recom");
                    L_recom.Text = "&nbsp;&nbsp;<span style='color:red;font-weight:bold;'>推荐信息</span>";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in this.GridView1.Rows)
            {
                CheckBox CheckRow = (CheckBox)row.FindControl("CheckBox1");
                if (CheckRow.Checked)
                {
                    int sortid;
                    int id = 0;
                    int.TryParse(this.GridView1.DataKeys[row.RowIndex].Values["NodeId"].ToString(), out id);

                    TextBox TxtSort = (TextBox)row.FindControl("TxtSort");
                    Int32.TryParse(TxtSort.Text, out sortid);

                    UpdateSortID(id, sortid);
                }

            }

            Pg_Init();
        }



        #region 批量排序

        protected void UpdateSortID(int id, int sortid)
        {
            TModel.TNode tnode = new TNode();
            TBLL.NodeBLL NodeOperate = new NodeBLL();
            tnode = NodeOperate.GetNode(id);
            tnode.SortID = sortid;
            NodeOperate.UpdateNode(id, tnode);

        }
        #endregion


        protected void DeleteNode(int InfoID)
        {
            TBLL.NodeBLL NodeOperate = new NodeBLL();
            TModel.TNode tnode = new TNode();
            tnode = NodeOperate.GetNode(InfoID);
            DataTable dt = NodeOperate.GetChildNode(InfoID);
            if (dt.Rows.Count > 0)
            {
                CommonLibrary.RunJs.AlertAndBack("请先删除该类别下的子类别再删除该类别");
            }
            else
            {
                if (tnode.NodePic.Trim() != "")
                {
                    CommonLibrary.CommOperate.DeleteFile(Server.MapPath(tnode.NodePic));
                }
                ImageOperate.DeleteMemoImage(tnode.NodeMemo);
                NodeOperate.DeleteNode(InfoID);
            }
           
        }
    }
}
