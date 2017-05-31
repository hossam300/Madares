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
    public partial class SetUp : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("SallarySheetItemID", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("Name", typeof(String));

                DataColumn Nature = table.Columns.Add("Nature", typeof(int));
                DataColumn Type = table.Columns.Add("Type", typeof(int));
                DataColumn Order = table.Columns.Add("Order", typeof(int));



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
                if (Convert.ToInt32(row["SallarySheetItemID"]) > max)
                    max = Convert.ToInt32(row["SallarySheetItemID"]);
            }
            return max;
        }
        protected void Page_Init(object sender, EventArgs e)
        {


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.SetUp, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            /*if (!IsPostBack)
            {*/
            btnSave.Visible = true;
            DataTable table = GetTable();
            PayGrades pg = new PayGrades();
            pg.getSallaryItems();
            table = pg.PayGradesSallaryItems;
            if (!IsPostBack)
            {
                ddlDepitAcct.SelectedValue = pg.DepitGL.ToString();
                ddlCreditAcct.SelectedValue = pg.CreditGL.ToString();
                Session["Table"] = null;
                Session["Table"] = table;
            }
            grid.DataSource = table;
            grid.DataBind();
            //}
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            PayGrades payGrade = new PayGrades();

            payGrade.PayGradesSallaryItems = Session["Table"] as DataTable;
            if (ddlCreditAcct.SelectedIndex != -1)
            {
                payGrade.CreditGL = int.Parse(ddlCreditAcct.SelectedValue.ToString());
            }
            if (ddlDepitAcct.SelectedIndex != -1)
            {
                payGrade.DepitGL = int.Parse(ddlDepitAcct.SelectedValue.ToString());
            }
            int id = payGrade.saveSallaryItems();
            Response.Redirect("~/HR/Setup.aspx?id= 0 ");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/Setup.aspx?id= 0 ");
        }
        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            DataTable table = new DataTable();
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                PayGrades payGrade = new PayGrades();

                table = payGrade.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
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
            /*if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                PayGrade payGrade = new PayGrade();


            
                DataColumn colid = table.Columns[0];
                table.PrimaryKey = new DataColumn[] { colid };
            }
            else
            {*/
            table = GetTable();
            //}
            /*table = new PayGrade().getSallaryItems();
            DataColumn colid = table.Columns["SallarySheetItemID"];
            table.PrimaryKey = new DataColumn[] { colid };*/
            DataRow found = table.Rows.Find(e.Keys[0]);
            found["Name"] = e.NewValues["Name"];

            found["Nature"] = e.NewValues["Nature"];
            found["Type"] = e.NewValues["Type"];
            found["Order"] = e.NewValues["Order"];


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
            /*  if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
              {
                  table = new PayGrade().getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                  DataColumn colid = table.Columns[0];
                  table.PrimaryKey = new DataColumn[] { colid };
              }
              else
              {*/
            table = GetTable();
            // }
            DataRow dr = table.NewRow();
            //if (e.NewValues["SallarySheetItemID"] != null)
            dr["SallarySheetItemID"] = e.NewValues["SallarySheetItemID"];
            /*else
                dr["SallarySheetItemID"] = "0";
        */
            dr["Name"] = e.NewValues["Name"];

            dr["Nature"] = e.NewValues["Nature"];
            dr["Type"] = e.NewValues["Type"];

            dr["Order"] = e.NewValues["Order"];

            table.Rows.Add(dr);
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
            Session["Table"] = table;

            e.Cancel = true;
            grid.DataSource = table;
            grid.DataBind();
            grid.CancelEdit();
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["SallarySheetItemID"] = GetLastKey() + 1;
        }
    }

}