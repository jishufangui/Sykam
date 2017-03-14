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
namespace Web.operate
{
    public partial class Admin_List :BasePage
    {
        protected static TBLL.AdminBLL adminbll = new AdminBLL();
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
            ArrayList selName = new ArrayList();
            ArrayList selValue = new ArrayList();

            int currentPage, pageSize, pageCount = 1, recordCount = 0;
            pageSize = 15;
            recordCount = adminbll.GetAdminNum(null, null);
            currentPage = tool.PageAndCount.GetCurrent(recordCount, pageSize);
            int startId = tool.PageAndCount.StartID(currentPage, pageSize);
            int endId = tool.PageAndCount.EndID(currentPage, pageSize);
            GridView1.DataSource = adminbll.GetAdminByCondition(null, null, startId, endId);
            GridView1.DataKeyNames = new String[] { "Admin_ID" };
            GridView1.DataBind();

            PagerClass.PageSet ps = new PagerClass.PageSet(currentPage, recordCount, pageSize, selName,selValue);
            L_page.Text = ps.GeneratePagers();
        }
        #endregion

        #region 删除用户
        protected void DeleteAdmin(int AminID,int userid)
        {

            adminbll.DeleteAdmin(AminID,userid);
        }

        #endregion

        #region 批量排序

        protected void UpdateSortID(int id, int sortid)
        {
            TAdmin tadmin = adminbll.GetAdmin(id);
            tadmin.SortID = sortid;
            adminbll.UpdateAdmin(tadmin, id);
        }
        #endregion

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int Infoid;
            Int32.TryParse(GridView1.DataKeys[e.RowIndex].Value.ToString(), out Infoid);
            DeleteAdmin(Infoid,LoginUser.Admin_ID);
            Pg_Init();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drow = e.Row.DataItem as DataRowView;
            if (drow != null)
            {
                HiddenField hstat = (HiddenField)e.Row.Cells[3].FindControl("H_stat");
                Literal lstat = (Literal)e.Row.Cells[3].FindControl("L_stat");
                if (hstat.Value.ToLower().Trim().Equals("true"))
                {
                    lstat.Text = "<span style='color:green;font-weight:bolder;'>未锁定</span>";
                }
                else
                {
                    lstat.Text = "<span style='color:red;font-weight:bolder;'>已锁定</span>";
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
                    int.TryParse(this.GridView1.DataKeys[row.RowIndex].Values["Admin_ID"].ToString(), out id);

                    TextBox TxtSort = (TextBox)row.FindControl("TxtSort");
                    Int32.TryParse(TxtSort.Text, out sortid);

                    UpdateSortID(id, sortid);
                }

            }

            Pg_Init();
        }


        #region 锁定或解锁
        protected void LockOrUnLock(bool stat, int id)
        {
            TAdmin tadmin = adminbll.GetAdmin(id);
            tadmin.Admin_Stat = stat;
            adminbll.UpdateAdmin(tadmin, id);
        }
        #endregion
        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                CheckBox CheckRow = (CheckBox)row.FindControl("CheckBox1");
                if (CheckRow.Checked)
                {
                    int sortid;
                    int id = 0;
                    int.TryParse(this.GridView1.DataKeys[row.RowIndex].Values["Admin_ID"].ToString(), out id);

                    TextBox TxtSort = (TextBox)row.FindControl("TxtSort");
                    Int32.TryParse(TxtSort.Text, out sortid);

                    LockOrUnLock(false, id);
                }

            }

            Pg_Init();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                CheckBox CheckRow = (CheckBox)row.FindControl("CheckBox1");
                if (CheckRow.Checked)
                {
                    int sortid;
                    int id = 0;
                    int.TryParse(this.GridView1.DataKeys[row.RowIndex].Values["Admin_ID"].ToString(), out id);

                    TextBox TxtSort = (TextBox)row.FindControl("TxtSort");
                    Int32.TryParse(TxtSort.Text, out sortid);

                    LockOrUnLock(true, id);
                }

            }

            Pg_Init();
        }
    }
}
