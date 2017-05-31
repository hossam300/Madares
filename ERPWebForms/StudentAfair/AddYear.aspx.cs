using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class AddYear : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddYear, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        EducationalYear ed = new EducationalYear();
                        ed.get(Convert.ToInt32(Request.QueryString["id"].ToString()));

                        txtYearName.Text = ed.Name;
                        ddlRank.SelectedValue = ed.Rank.ToString();
                        txtNoOfLec.Text = ed.NoOfLec.ToString();
                        txtLecTime.Text = ed.LecTimeMin.ToString();
                        if (ed.Breaks != null && ed.Breaks.Rows != null && ed.Breaks.Rows.Count > 0)
                        {
                            txtBreakFrom.Text = ed.Breaks.Rows[0]["BreakFrom"].ToString();
                            txtBreakTo.Text = ed.Breaks.Rows[0]["BreakTo"].ToString();
                        }
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EducationalYear ed = new EducationalYear();
            ed.Name = txtYearName.Text;
            int Yrank = 0;
            int.TryParse(ddlRank.SelectedValue, out Yrank);
            ed.Rank = Yrank;

            int YNoLec = 0;
            int.TryParse(txtNoOfLec.Text, out YNoLec);
            ed.NoOfLec = YNoLec;

            int YLecPeriod = 0;
            int.TryParse(txtLecTime.Text, out YLecPeriod);
            ed.LecTimeMin = YLecPeriod;
            DataTable dt = new DataTable();
            dt.Columns.Add("BreakFrom");
            dt.Columns.Add("BreakTo");
            DataRow dr = dt.NewRow();
            dr["BreakFrom"] = txtBreakFrom.Text;
            dr["BreakTo"] = txtBreakTo.Text;
            dt.Rows.Add(dr);
            ed.Breaks = dt;
            HttpCookie myCookie = Request.Cookies["user"];
            ed.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = ed.save();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/EducationYears.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddYear.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/EducationYears.aspx");
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EducationalYear ed = new EducationalYear();
            ed.Name = txtYearName.Text;
            ed.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            int Yrank = 0;
            int.TryParse(ddlRank.SelectedValue, out Yrank);
            ed.Rank = Yrank;

            int YNoLec = 0;
            int.TryParse(txtNoOfLec.Text, out YNoLec);
            ed.NoOfLec = YNoLec;

            int YLecPeriod = 0;
            int.TryParse(txtLecTime.Text, out YLecPeriod);
            ed.LecTimeMin = YLecPeriod;
            DataTable dt = new DataTable();
            dt.Columns.Add("BreakFrom");
            dt.Columns.Add("BreakTo");
            DataRow dr = dt.NewRow();
            dr["BreakFrom"] = txtBreakFrom.Text;
            dr["BreakTo"] = txtBreakTo.Text;
            dt.Rows.Add(dr);
            ed.Breaks = dt;
            HttpCookie myCookie = Request.Cookies["user"];
            ed.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = ed.update();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/EducationYears.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddYear.aspx?id=0&&alret=notpass");
            }
        }
    }
}