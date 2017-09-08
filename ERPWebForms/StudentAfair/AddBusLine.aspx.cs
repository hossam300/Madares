using DevExpress.Web;
using ERPWebForms.Business.Bus.Controllers;
using ERPWebForms.Business.Bus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class AddBusLine : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["TableBusLine"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("StationID", typeof(Int32));
                DataColumn Amountid = table.Columns.Add("Time", typeof(String));
                DataColumn Seqid = table.Columns.Add("OrderOnLine", typeof(Int32));
                table.PrimaryKey = new DataColumn[] { colid };
                colid.ReadOnly = true;


                Session["TableBusLine"] = table;
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
                Session["TableBusLine"] = null;
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {

                    // List<StationLine>  stations= new List<StationLine>();
                    // stations = busLine.StationsLines;
                    DataTable dt = new ClsBusLine().GetBusLineStation(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    grid.DataSource = dt;
                    grid.KeyFieldName = "ID";
                    grid.DataBind();
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                    DataColumn colid = dt.Columns["ID"];
                    dt.PrimaryKey = new DataColumn[] { colid };
                    colid.ReadOnly = true;
                    Session["TableBusLine"] = dt;
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
                    BusLine busLine = new ClsBusLine().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    txtName.Text = busLine.Name;
                    ddlStartStation.SelectedValue = busLine.StartStationId.ToString();
                    ddlSupervisorId.SelectedValue = busLine.SupervisorId.ToString();
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
                    if (Session["TableBusLine"] == null)
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

            Session["TableBusLine"] = table;
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
                    if (Session["TableBusLine"] == null)
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
            found["StationID"] = e.NewValues["StationID"];
            found["Time"] = e.NewValues["Time"];
            found["OrderOnLine"] = e.NewValues["OrderOnLine"];

            Session["TableBusLine"] = table;
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

            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["StationID"], e.NewValues["Time"], e.NewValues["OrderOnLine"] });
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
            Session["TableBusLine"] = table;

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
            BusLine busLine = new BusLine();
            busLine.Name = txtName.Text;
            busLine.StartStationId = Convert.ToInt32(ddlStartStation.SelectedValue.ToString());
            busLine.SupervisorId = Convert.ToInt32(ddlSupervisorId.SelectedValue.ToString());
            List<StationLine> stationLines = new List<StationLine>();
            DataTable dt = Session["TableBusLine"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StationLine stationLine = new StationLine();
                stationLine.StationId = Convert.ToInt32(dt.Rows[i]["StationId"].ToString());
                stationLine.Time = dt.Rows[i]["Time"].ToString();
                stationLine.OrderOnLine = Convert.ToInt32(dt.Rows[i]["OrderOnLine"].ToString());
                stationLine.Active = 1;
                stationLines.Add(stationLine);
            }
            busLine.StationsLines = stationLines;
            busLine.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            busLine.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsBusLine().update(Convert.ToInt32(Request.QueryString["id"].ToString()), busLine);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/BusLineList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddBusLine.aspx?id=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BusLine busLine = new BusLine();
            busLine.Name = txtName.Text;
            busLine.StartStationId = Convert.ToInt32(ddlStartStation.SelectedValue.ToString());
            busLine.SupervisorId = Convert.ToInt32(ddlSupervisorId.SelectedValue.ToString());
            List<StationLine> stationLines = new List<StationLine>();
            DataTable dt = Session["TableBusLine"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StationLine stationLine = new StationLine();
                stationLine.StationId = Convert.ToInt32(dt.Rows[i]["StationId"].ToString());
                stationLine.Time = dt.Rows[i]["Time"].ToString();
                stationLine.OrderOnLine = Convert.ToInt32(dt.Rows[i]["OrderOnLine"].ToString());
                stationLine.Active = 1;
                stationLines.Add(stationLine);
            }
            busLine.StationsLines = stationLines;
            busLine.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            busLine.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsBusLine().insert(busLine);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/BusLineList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddBusLine.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/BusLineList.aspx");
        }

    }
}