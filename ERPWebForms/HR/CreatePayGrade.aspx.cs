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
    public partial class CreatePayGrade : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("payGradesSallaryID", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("Name", typeof(String));
                DataColumn Amountid = table.Columns.Add("Value", typeof(String));
                DataColumn Nature = table.Columns.Add("Nature", typeof(int));
                DataColumn Type = table.Columns.Add("type", typeof(int));
                DataColumn Percentage = table.Columns.Add("Percentage", typeof(int));
                DataColumn Source = table.Columns.Add("source", typeof(int));


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
                if (Convert.ToInt32(row["payGradesSallaryID"]) > max)
                    max = Convert.ToInt32(row["payGradesSallaryID"]);
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
                    PayGrades payGrade = new PayGrades();
                    DataTable dt = payGrade.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));

                    grid.DataSource = dt;
                    grid.KeyFieldName = "payGradesSallaryID";
                    grid.DataBind();
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                    DataColumn colid = dt.Columns["payGradesSallaryID"];
                    dt.PrimaryKey = new DataColumn[] { colid };
                    colid.ReadOnly = true;


                    Session["Table"] = dt;
                }
                else
                {
                    grid.DataSource = GetTable();
                    grid.KeyFieldName = "payGradesSallaryID";
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
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreatePayGrade , Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        PayGrades payGrade = new PayGrades();
                        payGrade.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtPayGrade.Text = payGrade.PayGrade;
                        grid.DataSource = payGrade.PayGradesSallary;
                        grid.DataBind();
                        btnSave.Visible = false;
                        btnEdit.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = true;
                        btnEdit.Visible = false;
                    }
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            PayGrades payGrade = new PayGrades();
            payGrade.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            payGrade.PayGrade = txtPayGrade.Text;
            payGrade.PayGradesSallary = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            payGrade.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = payGrade.update();
            if (id > 0)
            {
                Response.Redirect("~/HR/PayGrade.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreatePayGrade.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            PayGrades payGrade = new PayGrades();
            payGrade.PayGrade = txtPayGrade.Text;
            payGrade.PayGradesSallary = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            payGrade.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = payGrade.save();
            if (id > 0)
            {
                Response.Redirect("~/HR/PayGrade.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreatePayGrade.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/PayGrade.aspx");
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
            found["Name"] = e.NewValues["Name"];
            found["Value"] = e.NewValues["Value"];
            found["Nature"] = e.NewValues["Nature"];
            found["Type"] = e.NewValues["Type"];
            found["Percentage"] = e.NewValues["Percentage"];
            found["Source"] = e.NewValues["Source"];


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
            dr["payGradesSallaryID"] = e.NewValues["payGradesSallaryID"];
            DataTable dt = new PayGrades().getSallaryItem(int.Parse(e.NewValues["Name"].ToString()));
            dr["Name"] = dt.Rows[0]["Name"].ToString();
            dr["Value"] = e.NewValues["Value"];
            dr["Nature"] = dt.Rows[0]["Nature"].ToString();
            dr["type"] = dt.Rows[0]["type"].ToString();
            if (e.NewValues["Percentage"] != null)
                dr["Percentage"] = e.NewValues["Percentage"];
            else
                dr["Percentage"] = 0;
            if (e.NewValues["source"] != null)
                dr["source"] = e.NewValues["source"];
            else
                dr["source"] = 0;

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
            e.NewValues["payGradesSallaryID"] = GetLastKey() + 1;
        }
    }
}