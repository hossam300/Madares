using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class ViewWorkShift : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewWorkShift, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                string sql;
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        WorkShift workShift = new WorkShift();
                        workShift.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtShiftName.Text = workShift.ShiftName;
                        ddlFrom.Text = workShift.From;
                        ddlTo.Text = workShift.To;
                        txtDuration.Text = workShift.Duration;

                        for (int i = 0; i < workShift.Emps.Count; i++)
                        {
                            sql = "Select * From HR_Employees where EmpID=" + workShift.Emps[i].ToString();
                            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                            ListItem b = new ListItem();
                            b.Value = workShift.Emps[i].ToString();

                            b.Text = dt.Rows[0]["EmpName"].ToString();

                            box2View.Items.Add(b);

                        }




                        btnEdit.Visible = true;
                    }
                    else
                    {

                        btnEdit.Visible = false;
                    }
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/HR/CreateWorkShifts.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/WorkShifts.aspx");
        }
    }
}