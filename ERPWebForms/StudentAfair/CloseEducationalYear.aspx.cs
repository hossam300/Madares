using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class CloseEducationalYear : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CloseEducationalYear, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
                Session["Table"] = null;
            FillGrid();

        }
        protected void Page_Init(object sender, EventArgs e)
        {

            //FillGrid();

        }

        private void FillGrid()
        {
            if (Request.QueryString["id"].ToString() != null)
            {
                System.Data.DataTable dt = new DataTable();
                string sql = "";
                if (Session["Table"] == null)
                {
                    ddlOldEdyYear.SelectedValue = Request.QueryString["id"].ToString();
                    sql = "select ID,Name as oldClass,'' as newClass from Std_Class where EdyID = " + Request.QueryString["id"].ToString();
                    dt = DataAccess.ExecuteSQLQuery(sql);
                    Session["Table"] = dt;
                }
                else
                    dt = Session["Table"] as DataTable;
                grid.DataSource = dt;
                grid.DataBind();

                sql = "select ID,Name as oldClass from Std_Class where EdyID = " + ddlOldEdyYear.SelectedValue.ToString();
                dt = DataAccess.ExecuteSQLQuery(sql);
                GridViewDataComboBoxColumn regioncolumn = (grid.Columns["oldClass"] as GridViewDataComboBoxColumn);
                regioncolumn.PropertiesComboBox.DataSource = dt;
                regioncolumn.PropertiesComboBox.ValueField = "ID";
                regioncolumn.PropertiesComboBox.TextField = "oldClass";
                regioncolumn.ReadOnly = true;

                FillNewClass();
                if (ddlOldEdyYear.SelectedValue != "")
                {
                    //get students in this year didn't pay the total money
                    DataTable notPaid = new EducationalYear().getStudentnotPaid(int.Parse(ddlOldEdyYear.SelectedValue.ToString()));
                    if (notPaid != null)
                    {
                        studentnotPaid.Visible = true;
                        studentnotPaid.DataSource = notPaid;
                        studentnotPaid.DataBind();
                    }
                    else
                        studentnotPaid.Visible = false;
                }
                else
                    studentnotPaid.Visible = false;

            }
        }

        private void FillNewClass()
        {
            string sql = "";
            DataTable dt;
            GridViewDataComboBoxColumn regioncolumn;
            if (ddlNewYear.SelectedValue != "")
            {
                sql = "select ID,Name as newClass from Std_Class where EdyID = " + ddlNewYear.SelectedValue.ToString();
                dt = DataAccess.ExecuteSQLQuery(sql);

                regioncolumn = (grid.Columns["NewClass"] as GridViewDataComboBoxColumn);
                regioncolumn.PropertiesComboBox.DataSource = dt;
                regioncolumn.PropertiesComboBox.ValueField = "ID";
                regioncolumn.PropertiesComboBox.TextField = "newClass";
            }
            else
            {
                sql = "select ID,Name as newClass from Std_Class ";
                dt = DataAccess.ExecuteSQLQuery(sql);
                regioncolumn = (grid.Columns["NewClass"] as GridViewDataComboBoxColumn);
                regioncolumn.PropertiesComboBox.DataSource = dt;
                regioncolumn.PropertiesComboBox.ValueField = "ID";
                regioncolumn.PropertiesComboBox.TextField = "newClass";
            }
        }
        protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillNewClass();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["Table"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                new StdClass().moveNextYear(int.Parse(dt.Rows[i]["ID"].ToString()), int.Parse(dt.Rows[i]["newClass"].ToString()));
            }
            Response.Redirect("~/StudentAfair/EducationYears.aspx");


        }
        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {

        }
        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = grid.DataSource as DataTable;
            /*if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                ProductPriceItems PPI = new ProductPriceItems();
                table = PPI.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                DataColumn colid = table.Columns[0];
                table.PrimaryKey = new DataColumn[] { colid };
            }
            else
            {
                table = GetTable();
            }*/
            DataColumn colid = table.Columns[0];
            table.PrimaryKey = new DataColumn[] { colid };
            DataRow found = table.Rows.Find(e.Keys[0]);
            found["newClass"] = e.NewValues["newClass"];
            /*found["Amount"] = e.NewValues["Amount"];
            found["Seq"] = e.NewValues["Seq"];
            found["GLAccountID"] = e.NewValues["GLAccountID"];
            */
            Session["Table"] = table;
            grid.DataSource = table;
            grid.DataBind();
            e.Cancel = true;
            grid.CancelEdit();

        }
        protected void grid_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            //FillGrid();
        }
    }
}