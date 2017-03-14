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
    public partial class Shop_List : System.Web.UI.Page
    {
        protected static TBLL.ShopBLL shopbll = new ShopBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pg_Init();
            }

        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int Infoid;
            Int32.TryParse(GridView1.DataKeys[e.RowIndex].Value.ToString(), out Infoid);
            DeleteShop(Infoid);
            Pg_Init();
        }
        #region 删除商家
        protected void DeleteShop(int ShopID)
        {

            TShop shop = shopbll.GetShop(ShopID);
            if (shop.ShopPic.Trim()!="")
            {
                CommonLibrary.CommOperate.DeleteFile(Server.MapPath(shop.ShopPic));
            }
            ImageOperate.DeleteMemoImage(shop.ShopMemo);
            shopbll.DeleteShop(ShopID);

        }

        #endregion


        #region 批量排序

        protected void UpdateSortID(int id, int sortid)
        {
            ShopBLL spdll = new ShopBLL();
            TShop tshop = spdll.GetShop(id);
            tshop.SortID = sortid;
            spdll.UpdateShop(tshop, id);
        }
        #endregion
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
               DataRowView drow = e.Row.DataItem as DataRowView;
               if (drow != null)
               {

                   HiddenField hRecom = (HiddenField)e.Row.Cells[2].FindControl("H_Recom");
                   if (hRecom.Value.Trim().ToLower() == "true")
                   {
                       Literal L_recom = (Literal)e.Row.Cells[2].FindControl("L_Recom");
                       L_recom.Text = "&nbsp;&nbsp;<span style='color:red;font-weight:bold;'>推荐商户</span>";
                   }
                   AddressBLL adbl=new AddressBLL();
                   StringBuilder sbaddress = new StringBuilder();
                   HiddenField hProvince = (HiddenField)e.Row.Cells[3].FindControl("H_Province");
                   if (hProvince.Value.Trim() != "")
                   {
                       sbaddress.Append("<a  href='?provinceid="+hProvince.Value+"'>"+adbl.GetProvinceByCode(hProvince.Value).name+"</a>");
                   }
                   HiddenField hCity = (HiddenField)e.Row.Cells[3].FindControl("H_City");
                   if (hCity.Value.Trim() != "")
                   {
                       sbaddress.Append("　<a href='?cityid=" + hCity.Value + "'>"+adbl.GetCityByCode(hCity.Value).name+"</a>");
                   }
                   HiddenField hArea = (HiddenField)e.Row.Cells[3].FindControl("H_area");
                   if (hArea.Value.Trim() != "")
                   {
                       sbaddress.Append("　<a href='?areaid=" + hArea.Value + "'>" + adbl.GetAreaByCode(hArea.Value).name + "</a>");
                   }
                   Literal L_address = (Literal)e.Row.Cells[3].FindControl("L_address");
                   L_address.Text = sbaddress.ToString();
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
                    int.TryParse(this.GridView1.DataKeys[row.RowIndex].Values["ShopID"].ToString(), out id);

                    TextBox TxtSort = (TextBox)row.FindControl("TxtSort");
                    Int32.TryParse(TxtSort.Text, out sortid);

                    UpdateSortID(id, sortid);
                }

            }

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

            if (CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword") != null && CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword") != "")
            {
                fieldName.Add("keyword");
                fieldValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword"));
                selName.Add("[and]ShopTitle");
                selValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("keyword"));
            }
            if (CommonLibrary.CommOperate.GetStrFromRequestQueryString("provinceid") != null && CommonLibrary.CommOperate.GetStrFromRequestQueryString("provinceid") != "")
            {
                fieldName.Add("provinceid");
                fieldValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("provinceid"));
                selName.Add("[and]ShopProvince");
                selValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("provinceid"));
            }
            if (CommonLibrary.CommOperate.GetStrFromRequestQueryString("cityid") != null && CommonLibrary.CommOperate.GetStrFromRequestQueryString("cityid") != "")
            {
                fieldName.Add("cityid");
                fieldValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("cityid"));
                selName.Add("[and]ShopCity");
                selValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("cityid"));
            }
            if (CommonLibrary.CommOperate.GetStrFromRequestQueryString("areaid") != null && CommonLibrary.CommOperate.GetStrFromRequestQueryString("areaid") != "")
            {
                fieldName.Add("areaid");
                fieldValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("areaid"));
                selName.Add("[and]ShopArea");
                selValue.Add(CommonLibrary.CommOperate.GetStrFromRequestQueryString("areaid"));
            }

            int currentPage, pageSize, pageCount = 1, recordCount = 0;
            pageSize = 15;
            recordCount = shopbll.GetShopCounts(selName, selValue);
            currentPage = tool.PageAndCount.GetCurrent(recordCount, pageSize);
            int startId = tool.PageAndCount.StartID(currentPage, pageSize);
            int endId = tool.PageAndCount.EndID(currentPage, pageSize);
            GridView1.DataSource = shopbll.GetNodeByCondition(selName, selValue, "  SortID asc,ShopID desc", startId, endId);
            GridView1.DataKeyNames = new String[] { "ShopID" };
            GridView1.DataBind();

            PagerClass.PageSet ps = new PagerClass.PageSet(currentPage, recordCount, pageSize, fieldName, fieldValue);
            L_page.Text = ps.GeneratePagers();
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
                Response.Redirect("Shop_List.aspx?keyword=" + KeyWord);
            }
        }
    }
}
