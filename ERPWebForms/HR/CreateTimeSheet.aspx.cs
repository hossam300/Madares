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
    public partial class CreateTimeSheet : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("EmpTimeSheetID", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("EmpID", typeof(Int32));
                DataColumn Amountid = table.Columns.Add("Date", typeof(String));
                DataColumn Seqid = table.Columns.Add("AttendTime", typeof(String));
                DataColumn Nameid = table.Columns.Add("LeaveTime", typeof(String));
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
                if (Convert.ToInt32(row["EmpTimeSheetID"]) > max)
                    max = Convert.ToInt32(row["EmpTimeSheetID"]);
            }
            return max;
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Session["Table1"] != null)
                {
                    Session["Table"] = Session["Table1"];
                    grid.DataSource = GetTable();
                    grid.KeyFieldName = "EmpTimeSheetID";
                    grid.DataBind();
                }
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                Session["Table1"] = null;
                Session["Table"] = null;
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    EmpTS emp = new EmpTS();
                    DataTable dt = emp.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));

                    grid.DataSource = dt;
                    grid.KeyFieldName = "EmpTimeSheetID";
                    grid.DataBind();
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                    DataColumn colid = dt.Columns["EmpTimeSheetID"];
                    dt.PrimaryKey = new DataColumn[] { colid };
                    colid.ReadOnly = true;


                    Session["Table"] = dt;
                }
                else
                {
                    grid.DataSource = GetTable();
                    grid.KeyFieldName = "EmpTimeSheetID";
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
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateTimeSheet, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    TimeSheet ts = new TimeSheet();
                    ts.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    ddlMonth.SelectedValue = ts.Month;
                    ddlYear.SelectedValue = ts.Year;


                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/EmployeeTS.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TimeSheet ts = new TimeSheet();
            ts.Month = ddlMonth.SelectedValue.ToString();
            ts.Year = ddlYear.SelectedValue.ToString();
            ts.OperatorID = 1;
            ts.TimeSheets = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            ts.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = ts.save();
            Session["Table"] = null;
            if (id > 0)
            {
                Response.Redirect("~/HR/EmployeeTS.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateTimeSheet.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            TimeSheet ts = new TimeSheet();
            ts.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            ts.OperatorID = 1;
            ts.Month = ddlMonth.SelectedValue.ToString();
            ts.Year = ddlYear.SelectedValue.ToString();
            ts.TimeSheets = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            ts.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = ts.update();
            Session["Table"] = null;
            if (id > 0)
            {
                Response.Redirect("~/HR/EmployeeTS.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateTimeSheet.aspx?id=0&&alret=notpass");
            }

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
            found["EmpID"] = e.NewValues["EmpID"];
            found["Date"] = e.NewValues["Date"];

            found["AttendTime"] = e.NewValues["AttendTime"];
            found["LeaveTime"] = e.NewValues["LeaveTime"];

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

            table.Rows.Add(new Object[] { e.NewValues["EmpTimeSheetID"], e.NewValues["EmpID"], e.NewValues["Date"], e.NewValues["AttendTime"], e.NewValues["LeaveTime"] });
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
            Session["Table"] = table;

            e.Cancel = true;
            grid.DataSource = table;
            grid.DataBind();
            grid.CancelEdit();
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["EmpTimeSheetID"] = GetLastKey() + 1;
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            MyIframe.Visible = true;
            btnLoad.Visible = true;
        }
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            MyIframe.Visible = false;
            btnLoad.Visible = false;

        }
    }
}