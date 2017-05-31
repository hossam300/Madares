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
    public partial class CreateReview : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table101"] as DataTable;
            DataColumn colid = table.Columns[0];
            table.PrimaryKey = new DataColumn[] { colid };
            colid.ReadOnly = true;
            if (table == null)
            {
                table = new DataTable();

                colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("KPI", typeof(String));
                DataColumn Amountid = table.Columns.Add("Rate", typeof(String));

                table.PrimaryKey = new DataColumn[] { colid };
                colid.ReadOnly = true;


                Session["Table101"] = table;
            }
            return table;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateReview, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                Session["Table101"] = null;
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Review review = new Review();
                        review.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlEmp.SelectedValue = review.EmpID.ToString();
                        ddlSupervisor.Text = review.SupervisorID.ToString();
                        txtStartDate.Text = review.StartDate.ToShortDateString();
                        txtEndDate.Text = review.EndTime.ToShortDateString();
                        txtDueDate.Text = review.DueDate.ToShortDateString();
                        ASPxRatingControl1.Value = review.Reviews;
                        grid.DataSource = review.ReviewKPIS;
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
            Review review = new Review();
            review.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            review.EmpID = Convert.ToInt32(ddlEmp.SelectedValue.ToString());
            review.SupervisorID = Convert.ToInt32(ddlSupervisor.SelectedValue.ToString());
            review.StartDate = Convert.ToDateTime(txtStartDate.Text);
            review.EndTime = Convert.ToDateTime(txtEndDate.Text);
            review.DueDate = Convert.ToDateTime(txtDueDate.Text);
            review.Reviews = ASPxRatingControl1.Value;
            review.ReviewKPIS = Session["Table101"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            review.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = review.update();
            Session["Table101"] = null;
            if (id > 0)
            {
                Response.Redirect("~/HR/Reviews.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateReview.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Review review = new Review();
            review.EmpID = Convert.ToInt32(ddlEmp.SelectedValue.ToString());
            review.SupervisorID = Convert.ToInt32(ddlSupervisor.SelectedValue.ToString());
            review.StartDate = Convert.ToDateTime(txtStartDate.Text);
            review.EndTime = Convert.ToDateTime(txtEndDate.Text);
            review.DueDate = Convert.ToDateTime(txtDueDate.Text);
            review.Reviews = ASPxRatingControl1.Value;
            review.ReviewKPIS = Session["Table101"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            review.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = review.save();
            Session["Table101"] = null;
            if (id > 0)
            {
                Response.Redirect("~/HR/Reviews.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateReview.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["Table101"] = null;
            Response.Redirect("~/HR/Reviews.aspx");
        }
        protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select JobTitleID From HR_Employees Where EmpID=" + ddlEmp.SelectedValue.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            sql = "SELECT KpiID as ID, KeyPerformanceIndicator as KPI,0 as Rate FROM HR_Kpis WHERE (JobTitleID = " + dt.Rows[0]["JobTitleID"].ToString() + ")";
            DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
            grid.DataSource = dt2;

            grid.DataBind();
            Session["Table101"] = dt2;
        }
        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();

            table = GetTable();

            DataRow found = table.Rows.Find(e.Keys[0]);

            found["KPI"] = e.NewValues["KPI"];
            found["Rate"] = e.NewValues["Rate"];
            Session["Table101"] = table;
            grid.DataSource = table;
            grid.DataBind();
            e.Cancel = true;
            grid.CancelEdit();
        }
    }
}