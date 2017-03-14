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
    public partial class Brand_List : BasePage
    {
        protected static TBLL.BrandBLL brandbll = new BrandBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pg_Init();
            }
        }



        #region 页面初始化
        protected void Pg_Init()
        {
            ArrayList fieldName = new ArrayList();
            ArrayList fieldValue = new ArrayList();

            ArrayList selName = new ArrayList();
            ArrayList selValue = new ArrayList();
            string param = string.Empty;

            if (CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword") != null && CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword") != "")
            {
                fieldName.Add("keyword");
                fieldValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword"));
                selName.Add("[and]BrandName");
                selValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword"));
            }
          
            int currentPage, pageSize, pageCount = 1, recordCount = 0;
            pageSize = 15;
            recordCount = brandbll.GetBrandNum(fieldName, fieldValue);
            currentPage = tool.PageAndCount.GetCurrent(recordCount, pageSize);
            int startId = tool.PageAndCount.StartID(currentPage, pageSize);
            int endId = tool.PageAndCount.EndID(currentPage, pageSize);
            GridView1.DataSource = brandbll.GetBrand(selName, selValue, "  SortID asc,BrandID desc", startId, endId);
            GridView1.DataKeyNames = new String[] { "BrandID" };
            GridView1.DataBind();

            PagerClass.PageSet ps = new PagerClass.PageSet(currentPage, recordCount, pageSize, fieldName, fieldValue);
            L_page.Text = ps.GeneratePagers();
        }
        #endregion


        #region 删除品牌
        protected void DeleteBrand(int BrandID)
        {
            TBrand brand = brandbll.GetBrandByID(BrandID);
            if(brand.BrandPic.Trim()!="")
            {
                CommonLibrary.CommOperate.DeleteFile(Server.MapPath(brand.BrandPic.Trim()));
            }
            ImageOperate.DeleteMemoImage(brand.BrandPic.Trim());
            brandbll.DeleteBrand(BrandID);
        }

        #endregion


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int Infoid;
            Int32.TryParse(GridView1.DataKeys[e.RowIndex].Value.ToString(), out Infoid);
            DeleteBrand(Infoid);
            Pg_Init();
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
                    int.TryParse(this.GridView1.DataKeys[row.RowIndex].Values["BrandID"].ToString(), out id);

                    TextBox TxtSort = (TextBox)row.FindControl("TxtSort");
                    Int32.TryParse(TxtSort.Text, out sortid);

                    UpdateSortID(id, sortid);
                }

            }

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
                    L_recom.Text = "&nbsp;&nbsp;<span style='color:red;font-weight:bold;'>推荐品牌</span>";
                }

           
            }
        }


        #region 批量排序

        protected void UpdateSortID(int id, int sortid)
        {   
 
            TBrand tbrand = brandbll.GetBrandByID(id);
            tbrand.SortID = sortid;
            brandbll.UpdateBrand(tbrand, id);
        }
        #endregion

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
                Response.Redirect("Brand_List.aspx?keyword=" + KeyWord);
            }
        }
    }
}
