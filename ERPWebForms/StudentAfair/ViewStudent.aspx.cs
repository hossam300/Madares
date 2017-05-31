using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
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
    public partial class ViewStudent : BasePage
    {
       
        public Int32 GetLastKey()
        {
          
            Int32 max = 0;
            string sql = "select max(id)as lastID from Std_FollowUp";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            max = int.Parse(dt.Rows[0]["lastID"].ToString());
            return max;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewStudent, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Student student = new Student();
                        student.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        lblStudentID.Text = student.ID.ToString();
                        Parent parent = new Parent();
                        lblStudentName.Text = student.Name;
                        parent.get(student.ParentID);
                        lblParentName.Text = parent.Name;
                        lblParentJob.Text = parent.Job;
                        lblBirthDate.Text = student.BirthDate.ToShortDateString();
                        DateTime ioct = new DateTime(DateTime.Now.Year, 10, 1);
                        lbl1oct.Text = (((ioct - student.BirthDate)).TotalDays / 365).ToString();
                        ddlType.Text = student.Type.ToString();
                        lblAddress.Text = student.Address.ToString();
                        lblPhone.Text = student.Phone;
                        StdClass sclass = new StdClass();
                        sclass.get(student.StudClass);
                        lblClass.Text = sclass.Name;
                        lblGender.Text = student.Gender;
                        lblReligion.Text = student.Religion;
                        if (student.LearningDisabilities == 1)
                        {
                            cbtxtDisabilities.Checked = true;
                        }
                        else
                            cbtxtDisabilities.Checked = false;
                        txtDisabilities.Text = student.Note;
                        if (student.Father != 0)
                        {
                            
                            parent.get(student.Father);
                            lblFather.Text = parent.Name;
                            txtfjob.Text = parent.Job;
                            txtfPhone.Text = parent.Phone;
                            txtfAddress.Text = parent.Address;
                        }
                        if (student.Mother != 0)
                        {

                            parent.get(student.Mother);
                            ddlMpther.Text = parent.Name;
                            txtmJob.Text = parent.Job;
                            txtmphone.Text = parent.Phone;
                            txtmAddress.Text = parent.Address;
                        }

                        btnEdit.Visible = true;
                        DataTable dt = new DataTable();//Exams
                        ASPxGridView3.DataSource = dt;
                        ASPxGridView3.DataBind();
                        StdClass c = new StdClass();
                        c.get(student.StudClass);
                        DataTable dt2 = new EducationalYear().GetCourses(c.EdID);//Courses
                        coursesGrid.DataSource = dt2;
                        coursesGrid.DataBind();
                        DataTable dt3 = new Student().getAbsent(int.Parse(lblStudentID.Text));//Absents
                        absentGrid.DataSource = dt3;
                        absentGrid.DataBind();
                    }
                    else
                    {

                        btnEdit.Visible = false;
                    }
                  
                }
                AddSubmitEvent();
            }
            AddSubmitEvent();

        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("SFUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = ASPxButton1.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = ASPxButton2.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/StudentAfair/AddStudent.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Students.aspx");

        }

        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ID"] = GetLastKey() + 1;
        }
        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();


            string sql = "Update  Std_FollowUp Set Description='"+e.NewValues["Description"] +"',TeacherID="+e.NewValues["TeacherID"]+",CourseID="+ e.NewValues["CourseID"]+",StudentID="+ Request.QueryString["id"].ToString()+" Where ID="+e.Keys[0];
            DataAccess.ExecuteSQLNonQuery(sql);
            e.Cancel = true;

            grid.CancelEdit();
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();

            
            string sql = "Insert Into Std_FollowUp(Description,TeacherID,CourseID,StudentID) Values(N'" + e.NewValues["Description"] + "'," + e.NewValues["TeacherID"] + "," + e.NewValues["CourseID"] + "," + Request.QueryString["id"].ToString() + ")";
            DataAccess.ExecuteSQLNonQuery(sql);
            e.Cancel = true;
           
            grid.CancelEdit();
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/StudentAfair/ViewFollowup.aspx?id=" + id);
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteRtfToResponse();
        }
    }
}