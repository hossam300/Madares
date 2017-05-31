using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ERPWebForms.HR
{
    public partial class CreatesheetStyle : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("ItemName", typeof(String));
                DataColumn Amountid = table.Columns.Add("ItemOrder", typeof(Int32));

                table.PrimaryKey = new DataColumn[] { colid };
                colid.ReadOnly = true;


                Session["Table"] = table;
            }
            return table;
        }
        public Int32 GetLastKey()
        {
            DataTable table = GetTable();

            Int32 max = 0;
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["ID"]) > max)
                    max = Convert.ToInt32(row["ID"]);
            }
            return max;
        }
        protected void Page_Init(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                Session["Table"] = null;
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    ExcelSheets excelSheets = new ExcelSheets();
                    DataTable dt = excelSheets.getSheetItemsByID(Convert.ToInt32(Request.QueryString["id"].ToString()));

                    grid.DataSource = dt;
                    grid.KeyFieldName = "ID";
                    grid.DataBind();
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                    DataColumn colid = dt.Columns["ID"];
                    dt.PrimaryKey = new DataColumn[] { colid };
                    colid.ReadOnly = true;


                    Session["Table"] = dt;
                }
                else
                {
                    grid.DataSource = GetTable();
                    grid.KeyFieldName = "ID";
                    grid.DataBind();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreatesheetStyle, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    ExcelSheets excelSheets = new ExcelSheets();
                    excelSheets.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    txtName.Text = excelSheets.SheetStyleName;

                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ExcelSheets excelSheets = new ExcelSheets();
            excelSheets.SheetStyleName = txtName.Text;
            excelSheets.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            excelSheets.OperatorID = 1;
            excelSheets.SheetItems = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            excelSheets.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = excelSheets.update();
            Session["Table"] = null;
            if (id > 0)
            {
                Response.Redirect("~/HR/ExcelSheetStyle.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreatesheetStyle.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ExcelSheets excelSheets = new ExcelSheets();
            excelSheets.SheetStyleName = txtName.Text;

            excelSheets.OperatorID = 1;
            excelSheets.SheetItems = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            excelSheets.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = excelSheets.save();
            Session["Table"] = null;
            if (id > 0)
            {
                Response.Redirect("~/HR/ExcelSheetStyle.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreatesheetStyle.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/ExcelSheetStyle.aspx");
        }
        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            DataTable table = new DataTable();
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                EmpTS emp = new EmpTS();


                table = emp.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                DataColumn colid = table.Columns[0];
                table.PrimaryKey = new DataColumn[] { colid };
            }
            else
            {
                table = GetTable();
            }

            DataRow found = table.Rows.Find(e.Keys[0]);
            table.Rows.Remove(found);

            Session["Table"] = table;
            grid.DataSource = table;
            grid.DataBind();
            e.Cancel = true;
        }
        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                EmpTS emp = new EmpTS();


                table = emp.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                DataColumn colid = table.Columns[0];
                table.PrimaryKey = new DataColumn[] { colid };
            }
            else
            {
                table = GetTable();
            }
            DataRow found = table.Rows.Find(e.Keys[0]);
            found["ItemName"] = e.NewValues["ItemName"];
            found["ItemOrder"] = e.NewValues["ItemOrder"];



            Session["Table"] = table;
            grid.DataSource = table;
            grid.DataBind();
            e.Cancel = true;
            grid.CancelEdit();
        }
        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();

            table = GetTable();

            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["ItemName"], e.NewValues["ItemOrder"] });
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
            Session["Table"] = table;

            e.Cancel = true;
            grid.DataSource = table;
            grid.DataBind();
            grid.CancelEdit();
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ID"] = GetLastKey() + 1;
        }
    }
}