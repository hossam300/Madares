//using ERPWebForms.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class AddCourse : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddCourse , Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                getEdy();
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Course cr = new Course();
                        cr.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtCourseName.Text = cr.Name;
                        txtDescription.Text = cr.Description;
                        txtMin.Text = cr.Min.ToString();
                        txtMax.Text = cr.Max.ToString();
                        DataTable dtEdy = cr.Edy;
                         DataTable dtTeachers = cr.Teachers;
                       //s  Fill the Checkboxlists by dtEdy
                        ListItem li;
                        for (int i = 0; i < dtEdy.Rows.Count; i++)
                        {

                            li = cblKg.Items.FindByValue(dtEdy.Rows[i]["ID"].ToString());
                                    if (li != null)
                                        li.Selected = true;


                                    li = cblPri.Items.FindByValue(dtEdy.Rows[i]["ID"].ToString());
                                    if (li != null)
                                        li.Selected = true;


                                    li = cblPre.Items.FindByValue(dtEdy.Rows[i]["ID"].ToString());
                                    if (li != null)
                                        li.Selected = true;

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
        private void getEdy()
        {
            //get the courses for this educational year
            string sql = "SELECT [ID], [YearName] as Name FROM [Std_EducationalYear] where Rank = 1";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            cblKg.DataSource = dt;
            cblKg.DataTextField = "Name";
            cblKg.DataValueField = "ID";
            cblKg.DataBind();
            //get the classes for this educational year
            sql = "SELECT [ID], [YearName] as Name FROM [Std_EducationalYear] where Rank = 2";
            dt = DataAccess.ExecuteSQLQuery(sql);
            cblPri.DataSource = dt;
            cblPri.DataTextField = "Name";
            cblPri.DataValueField = "ID";
            cblPri.DataBind();
            sql = "SELECT [ID], [YearName] as Name FROM [Std_EducationalYear] where Rank = 3";
            dt = DataAccess.ExecuteSQLQuery(sql);
            cblPre.DataSource = dt;
            cblPre.DataTextField = "Name";
            cblPre.DataValueField = "ID";
            cblPre.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Course cr = new Course();
            cr.Name = txtCourseName.Text;
            cr.Description = txtCourseName.Text;
            int cmin = 0;
            int cmax = 0;
            int.TryParse(txtMax.Text, out cmax);
            int.TryParse(txtMin.Text, out cmin);
            cr.Min = cmin;
            cr.Max = cmax;
            HttpCookie myCookie = Request.Cookies["user"];
            cr.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            DataTable edyDT = new DataTable();
            edyDT.Columns.Add("EdyID");
            DataRow dr;
            //add KG years
            for (int i = 0; i < cblKg.Items.Count; i++)
            {
                if (cblKg.Items[i].Selected)
                {
                    dr = edyDT.NewRow();
                    dr["EdyID"] = cblKg.Items[i].Value.ToString();
                    edyDT.Rows.Add(dr);
                }

            }
            //add priem years
            for (int i = 0; i < cblPri.Items.Count; i++)
            {
                if (cblPri.Items[i].Selected)
                {
                    dr = edyDT.NewRow();
                    dr["EdyID"] = cblPri.Items[i].Value.ToString();
                    edyDT.Rows.Add(dr);
                }

            }
            //add prep years
            for (int i = 0; i < cblPre.Items.Count; i++)
            {
                if (cblPre.Items[i].Selected)
                {
                    dr = edyDT.NewRow();
                    dr["EdyID"] = cblPre.Items[i].Value.ToString();
                    edyDT.Rows.Add(dr);
                }

            }
            cr.Edy = edyDT;
            int id = cr.save();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Courses.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddCourse.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Courses.aspx");
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Course cr = new Course();
            cr.Name = txtCourseName.Text;
            cr.Description = txtCourseName.Text;
            cr.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            HttpCookie myCookie = Request.Cookies["user"];
            cr.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int cmin = 0;
            int cmax = 0;
            int.TryParse(txtMax.Text, out cmax);
            int.TryParse(txtMin.Text, out cmin);
            cr.Min = cmin;
            cr.Max = cmax;
            DataTable edyDT = new DataTable();
            edyDT.Columns.Add("EdyID");
            DataRow dr;
            //add KG years
            for (int i = 0; i < cblKg.Items.Count; i++)
            {
                if (cblKg.Items[i].Selected)
                {
                    dr = edyDT.NewRow();
                    dr["EdyID"] = cblKg.Items[i].Value.ToString();
                    edyDT.Rows.Add(dr);
                }

            }
            //add priem years
            for (int i = 0; i < cblPri.Items.Count; i++)
            {
                if (cblPri.Items[i].Selected)
                {
                    dr = edyDT.NewRow();
                    dr["EdyID"] = cblPri.Items[i].Value.ToString();
                    edyDT.Rows.Add(dr);
                }

            }
            //add prep years
            for (int i = 0; i < cblPre.Items.Count; i++)
            {
                if (cblPre.Items[i].Selected)
                {
                    dr = edyDT.NewRow();
                    dr["EdyID"] = cblPre.Items[i].Value.ToString();
                    edyDT.Rows.Add(dr);
                }

            }
            cr.Edy = edyDT;
            int id = cr.update();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Courses.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddCourse.aspx?id=0&&alret=notpass");
            }


        }
    }
}