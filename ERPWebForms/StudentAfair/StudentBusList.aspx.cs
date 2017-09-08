using DevExpress.Web;
using ERPWebForms.Business.Bus.Controllers;
using ERPWebForms.Business.Bus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class StudentBusList : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["TableStudentBus"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn StudentId = table.Columns.Add("StudentId", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("StationID", typeof(Int32));
                DataColumn Amountid = table.Columns.Add("Amount", typeof(Int32));
                DataColumn Seqid = table.Columns.Add("PaymentType", typeof(String));
                table.PrimaryKey = new DataColumn[] { colid };
                colid.ReadOnly = true;


                Session["TableStudentBus"] = table;
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
                Session["TableStudentBus"] = null;
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {

                    // List<StationLine>  stations= new List<StationLine>();
                    // stations = busLine.StationsLines;
                    DataTable dt = new ClsStudentLine().GetStudentLines(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    grid.DataSource = dt;
                    grid.KeyFieldName = "ID";
                    grid.DataBind();
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                    DataColumn colid = dt.Columns["ID"];
                    dt.PrimaryKey = new DataColumn[] { colid };
                    colid.ReadOnly = true;
                    Session["TableStudentBus"] = dt;
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                }
                else
                {
                    grid.DataSource = GetTable();
                    grid.KeyFieldName = "ID";
                    grid.DataBind();
                    btnEdit.Visible = false;
                    btnSave.Visible = true;
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
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddClass, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    StudentLine studentLine = new ClsStudentLine().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    ddlBusLine.SelectedValue = studentLine.LineId.ToString();
                }
            }
        }
        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            DataTable table = new DataTable();
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                //ProductPriceItems PPI = new ProductPriceItems();
                table = new ClsBusLine().GetBusLineStation(Convert.ToInt32(Request.QueryString["id"].ToString())); ;
                if (table.Rows.Count > 0)
                {
                    if (Session["TableStudentBus"] == null)
                    {
                        DataColumn colid = table.Columns[0];
                        table.PrimaryKey = new DataColumn[] { colid };
                    }
                    else
                        table = GetTable();
                }
                else
                    table = GetTable();
            }
            else
            {
                table = GetTable();
            }

            DataRow found = table.Rows.Find(e.Keys[0]);
            table.Rows.Remove(found);

            Session["TableStudentBus"] = table;
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
                //  ProductPriceItems PPI = new ProductPriceItems();
                table = new ClsBusLine().GetBusLineStation(Convert.ToInt32(Request.QueryString["id"].ToString())); ;
                if (table.Rows.Count > 0)
                {
                    if (Session["TableStudentBus"] == null)
                    {
                        DataColumn colid = table.Columns[0];
                        table.PrimaryKey = new DataColumn[] { colid };
                    }
                    else
                        table = GetTable();
                }
                else
                    table = GetTable();
            }
            else
            {
                table = GetTable();
            }
            DataRow found = table.Rows.Find(e.Keys[0]);
            found["StudentId"] = e.NewValues["StudentId"];
            found["StationID"] = e.NewValues["StationID"];
            found["Amount"] = e.NewValues["Amount"];
            found["PaymentType"] = e.NewValues["PaymentType"];

            Session["TableStudentBus"] = table;
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

            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["StudentId"], e.NewValues["StationID"], e.NewValues["Amount"], e.NewValues["PaymentType"] });
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
            Session["TableStudentBus"] = table;

            e.Cancel = true;
            grid.DataSource = table;
            grid.DataBind();
            grid.CancelEdit();
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ID"] = GetLastKey() + 1;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {


            HttpCookie myCookie = Request.Cookies["user"];
            DataTable dt = Session["TableStudentBus"] as DataTable;
            int res = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentLine studentLine = new StudentLine();
                studentLine.LineId = Convert.ToInt32(ddlBusLine.SelectedValue.ToString());
                studentLine.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"].ToString());
                studentLine.StationId = Convert.ToInt32(dt.Rows[i]["StationId"].ToString());
                studentLine.Amount = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString());
                studentLine.PaymentType = dt.Rows[i]["PaymentType"].ToString();
                studentLine.Active = 1;
                studentLine.OperatorID=Convert.ToInt32(myCookie.Values["userid"].ToString());
                res = new ClsStudentLine().update(Convert.ToInt32(Request.QueryString["id"].ToString()), studentLine);
            }
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/StudentBusList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/StudentBusList.aspx?alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["user"];
            DataTable dt = Session["TableStudentBus"] as DataTable;
            int res = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentLine studentLine = new StudentLine();
                studentLine.LineId = Convert.ToInt32(ddlBusLine.SelectedValue.ToString());
                studentLine.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"].ToString());
                studentLine.StationId = Convert.ToInt32(dt.Rows[i]["StationId"].ToString());
                studentLine.Amount = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString());
                studentLine.PaymentType = dt.Rows[i]["PaymentType"].ToString();
                studentLine.Active = 1;
                studentLine.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
                res = new ClsStudentLine().insert(studentLine);
            }
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/StudentBusList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/StudentBusList.aspx?alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/BusLineList.aspx");
        }

    }
}