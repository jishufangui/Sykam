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
    public partial class Info_List : BasePage
    {
        protected static TBLL.InfoBLL infobll = new InfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pg_Init();
                
            }
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
                    L_recom.Text = "<span style='color:red;'>[荐]</span>";
                }

                HiddenField hInfoType = (HiddenField)e.Row.Cells[2].FindControl("H_InfoType");
                if (hInfoType.Value.Trim().ToLower() == "1")
                {
                    Literal L_InfoType = (Literal)e.Row.Cells[2].FindControl("L_InfoType");
                    L_InfoType.Text = "<span style='color:blue;'>[新闻]</span>";
                }
                else if (hInfoType.Value.Trim().ToLower() == "2")
                {
                    Literal L_InfoType = (Literal)e.Row.Cells[2].FindControl("L_InfoType");
                    L_InfoType.Text = "<span style='color:blue;'>[产品]</span>";
                }

                #region 注释掉
                HiddenField hnode = (HiddenField)e.Row.Cells[3].FindControl("H_Node");
                int nodeid = 0;
                if (hnode.Value.Trim() != "")
                {
                    Int32.TryParse(hnode.Value, out nodeid);
                }

                NodeBLL nodebll = new NodeBLL();
                string nodename=nodebll.GetNode(nodeid).NodeName;
                if (nodename.Trim() == "")
                {
                    nodename = "暂无栏目";
                }
                

                Literal Lnode = (Literal)e.Row.Cells[3].FindControl("L_Node");
                Lnode.Text = "<a href='?cid="+nodeid.ToString()+"'>"+nodename+"</a>";

                HiddenField hcheck = (HiddenField)e.Row.Cells[6].FindControl("H_Check");
                string checkstat = string.Empty;
                if (hcheck.Value.ToLower() == "true")
                {
                    checkstat = "<span style='color:green;font-weight:bolder;'>已审核</span>";
                }
                else
                {
                    checkstat = "<span style='color:red;font-weight:bolder;'>未审核</span>";
                }
                Literal lcheck = (Literal)e.Row.Cells[6].FindControl("L_check");
                lcheck.Text = checkstat;

                //AddressBLL adbl = new AddressBLL();
                //StringBuilder sbaddress = new StringBuilder();
                //HiddenField hProvince = (HiddenField)e.Row.Cells[3].FindControl("H_Province");
                //if (hProvince.Value.Trim() != "")
                //{
                //    sbaddress.Append("<a  href='?provinceid=" + hProvince.Value + "'>" + adbl.GetProvinceByCode(hProvince.Value).name + "</a>");
                //}
                //HiddenField hCity = (HiddenField)e.Row.Cells[3].FindControl("H_City");
                //if (hCity.Value.Trim() != "")
                //{
                //    sbaddress.Append("　<a href='?cityid=" + hCity.Value + "'>" + adbl.GetCityByCode(hCity.Value).name + "</a>");
                //}
                //HiddenField hArea = (HiddenField)e.Row.Cells[3].FindControl("H_area");
                //if (hArea.Value.Trim() != "")
                //{
                //    sbaddress.Append("　<a href='?areaid=" + hArea.Value + "'>" + adbl.GetAreaByCode(hArea.Value).name + "</a>");
                //}
                //Literal L_address = (Literal)e.Row.Cells[3].FindControl("L_address");
                //L_address.Text = sbaddress.ToString();

                #endregion


            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int Infoid;
            Int32.TryParse(GridView1.DataKeys[e.RowIndex].Value.ToString(), out Infoid);
            DeleteInfo(Infoid);
            Pg_Init();
        }


        #region 页面初始化
        protected void Pg_Init()
        {
            ArrayList fieldName = new ArrayList();
            ArrayList fieldValue = new ArrayList();

            ArrayList selName = new ArrayList();
            ArrayList selValue = new ArrayList();
            string param = string.Empty;

            int cid = 0;
            Int32.TryParse(CommonLibrary.CommOperate.GetStrFromRequestQueryString("cid"), out cid);

            if (CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword") != null && CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword") != "")
            {
                fieldName.Add("keyword");
                fieldValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword"));
                selName.Add("[and]InfoTitle");
                selValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword"));
            }

            if (cid != 0)
            {
                fieldName.Add("cid");
                fieldValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("cid"));

                selName.Add("[and]InfoType");
                selValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("cid"));
            }

  
           

            int currentPage, pageSize, pageCount = 1, recordCount = 0;
            pageSize = 15;
            recordCount = infobll.GetInfoCountsByNode(cid, selName, selValue, 1);
            currentPage = tool.PageAndCount.GetCurrent(recordCount, pageSize);
            int startId = tool.PageAndCount.StartID(currentPage, pageSize);
            int endId = tool.PageAndCount.EndID(currentPage, pageSize);
            GridView1.DataSource = infobll.GetInfoByNode(cid, selName,selValue, 1, startId, endId);
            GridView1.DataKeyNames = new String[] { "InfoID" };
            GridView1.DataBind();

            PagerClass.PageSet ps = new PagerClass.PageSet(currentPage, recordCount, pageSize, fieldName, fieldValue);
            L_page.Text = ps.GeneratePagers();

            #region 类别树
            TNode tnode = new TNode();
            NodeBLL nodebll = new NodeBLL();
            DataTable dt = nodebll.GetAllNode();
            L_CateTree.Text = "<select  id='sel' name='sel'>";
            if (dt.Rows.Count > 0)
            {
                L_CateTree.Text += tool.NodeTree.GetNodeTree(dt, 0, 0);
            }
            L_CateTree.Text += "</Select>";

            #endregion
        }
        #endregion

        #region  删除信息
        protected void DeleteInfo(int id)
        {
            TInformation tinfo = infobll.GetInfo(id);

            #region  逻辑删除  注释掉删除物理图片
            if (tinfo.InfoPic.Trim() != "")
            {
                if (tinfo.InfoPic.Trim().Substring(0, 4) != "http")
                {
                    CommonLibrary.CommOperate.DeleteFile(Server.MapPath(tinfo.InfoPic));
                }
            }
            ImageOperate.DeleteMemoImage(tinfo.InfoMemo);

            #endregion
            infobll.DeleteInfo(id, LoginUser.Admin_ID);
 
        }

        #endregion

        #region 批量排序

        protected void UpdateSortID(int id, int sortid)
        {


            TInformation tinfo = infobll.GetInfo(id);
            tinfo.SortID = sortid;
            infobll.UpdateInfo(tinfo,id);
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                CheckBox CheckRow = (CheckBox)row.FindControl("CheckBox1");
                if (CheckRow.Checked)
                {
                    int sortid;
                    int id = 0;
                    int.TryParse(this.GridView1.DataKeys[row.RowIndex].Values["InfoID"].ToString(), out id);

                    TextBox TxtSort = (TextBox)row.FindControl("TxtSort");
                    Int32.TryParse(TxtSort.Text, out sortid);

                    UpdateSortID(id, sortid);
                }

            }

            Pg_Init();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                CheckBox CheckRow = (CheckBox)row.FindControl("CheckBox1");
                if (CheckRow.Checked)
                {
                    int sortid;
                    int id = 0;
                    int.TryParse(this.GridView1.DataKeys[row.RowIndex].Values["InfoID"].ToString(), out id);

                    TextBox TxtSort = (TextBox)row.FindControl("TxtSort");
                    Int32.TryParse(TxtSort.Text, out sortid);

                    DeleteInfo(id);
                }

            }

            Pg_Init();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string KeyWord = string.Empty;
            if (Tbx_keyword.Text == "")
            {
                CommonLibrary.RunJs.AlertAndBack("请输入要搜索的关键词");
            }
            else
            {
                KeyWord = Tbx_keyword.Text;
                Response.Redirect("Info_List.aspx?keyword="+KeyWord);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string cid = CommonLibrary.CommOperate.GetStrFromRequestForm("sel");
            CommonLibrary.RunJs.PageReplace("Info_List.aspx?cid="+cid);

        }
    }
}
