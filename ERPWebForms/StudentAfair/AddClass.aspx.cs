using DevExpress.Web;
//using ERPWebForms.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ERPWebForms.StudentAfair
{
    public partial class AddClass : BasePage
    {
        int count;
        DataTable dt2;
        DataTable dt3;


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

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        StdClass sttclass = new StdClass();
                        sttclass.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        //txtNoOfStudent.Text=sttclass.
                        txtClassName.Text = sttclass.Name;
                        ddlEdtYear.SelectedValue = sttclass.EdID.ToString();
                        if (sttclass.SupID != 0)
                        {
                            ddlSup.SelectedValue = sttclass.SupID.ToString();

                        }

                        ASPxGridView1.DataSource = sttclass.CoursesTeachers;
                        ASPxGridView1.DataBind();
                        string sql = "select ID as TeacherID,Name as TeacherName from Std_Teacher ";
                        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                        GridViewDataComboBoxColumn regioncolumn = (ASPxGridView1.Columns["clTeacher"] as GridViewDataComboBoxColumn);
                        regioncolumn.PropertiesComboBox.DataSource = dt;
                        regioncolumn.PropertiesComboBox.ValueField = "TeacherID";
                        regioncolumn.PropertiesComboBox.TextField = "TeacherName";
                        Session["table"] = sttclass.CoursesTeachers;
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
            if (IsPostBack)
            {
                ASPxGridView1.DataSource = Session["table"];
                ASPxGridView1.DataBind();
            }
           
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            StdClass sc = new StdClass();
            sc.Name = txtClassName.Text;
            int EdtYear = 0;
            int.TryParse(ddlEdtYear.SelectedValue.ToString(), out EdtYear);
            sc.EdID = EdtYear;
            int supID = 0;
            int.TryParse(ddlSup.SelectedValue.ToString(), out supID);
            sc.SupID = supID;
            HttpCookie myCookie = Request.Cookies["user"];
            sc.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            /*DataTable dtcourseteacher = new DataTable();
            dtcourseteacher.Columns.Add("Course");
            dtcourseteacher.Columns.Add("Teacher");
            for (int i = 0; i < count; i++)
              {
                  string opid1 = "lblCourse" + dt2.Rows[i]["Name"].ToString() ;
                     Label lblName = (Label)panel.FindControl(opid1);
                    string Attr;
                    Attr = "ddlTeacher" + dt3.Rows[i]["Name"].ToString();
                    DropDownList ddlTeacher = (DropDownList)panel.FindControl(Attr);
                    DataRow dr = dtcourseteacher.NewRow();
                    dr["Course"] = lblName.Text;
                    dr["Teacher"] = ddlTeacher.SelectedValue;
                    dtcourseteacher.Rows.Add(dr);
                   }*/
            sc.CoursesTeachers = Session["table"] as DataTable;

            int id = sc.save();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Classes.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddClass.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Classes.aspx");
        }
        protected void ddlEdtYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " SELECT Std_Course.ID,Std_Course.Name as CourseName , '' as TeacherName  FROM Std_CourseEdy inner join Std_Course on Std_Course.ID = CourseID where EdyID =" + ddlEdtYear.SelectedValue.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            ASPxGridView1.DataSource = dt;
            ASPxGridView1.DataBind();
            Session["table"] = dt;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    sql = " SELECT Name  FROM Std_Course where ID =" + dt.Rows[i]["CourseID"].ToString();
            //    dt2 = DataAccess.ExecuteSQLQuery(sql);
            //    Label lblCourse = new Label();
            //    lblCourse.ID = "lblCourse"+dt2.Rows[0]["Name"];
            //    lblCourse.Text = dt2.Rows[0]["Name"].ToString();


            //    sql = "SELECT dbo.Std_Teacher.ID, dbo.Std_Teacher.Name FROM dbo.Std_Teacher INNER JOIN  dbo.Std_TeacherCourses ON dbo.Std_Teacher.ID = dbo.Std_TeacherCourses.TeacherID Where dbo.Std_TeacherCourses.CourseID=" + dt.Rows[i]["CourseID"].ToString();
            //    dt3 = DataAccess.ExecuteSQLQuery(sql);
            //    DropDownList ddlTeacher = new DropDownList();
            //    ddlTeacher.ID = "ddlTeacher" +dt3.Rows[0]["Name"];
            //    ddlTeacher.Style.Add("class", "chzn-select");
            //    ddlTeacher.Style.Add("width", "80%");
            //    ddlTeacher.DataValueField = "ID";
            //    ddlTeacher.DataTextField = "Name";
            //    ddlTeacher.DataSource = dt3;
            //    ddlTeacher.DataBind();
            //    ddlTeacher.Items.Insert(0, new ListItem(String.Empty, "0"));
            //    Table tbl = new Table();
            //    TableRow row = new TableRow();

            //    TableCell cell1 = new TableCell();
            //    TableCell cell2 = new TableCell();
            //    Session["Course"] = dt2;
            //    Session["Course"] = dt2;
            //    cell1.HorizontalAlign = HorizontalAlign.Center;
            //    cell2.HorizontalAlign = HorizontalAlign.Center;

            //    cell2.Controls.Add(ddlTeacher);
            //    cell1.Controls.Add(lblCourse);
            //    row.Cells.Add(cell1);
            //    row.Cells.Add(cell2);


            //    tbl.Rows.Add(row);
            //    panel.Controls.Add(tbl);
            //}

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            StdClass sc = new StdClass();
            sc.Name = txtClassName.Text;
            sc.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            int EdtYear = 0;
            int.TryParse(ddlEdtYear.SelectedValue.ToString(), out EdtYear);
            sc.EdID = EdtYear;
            int supID = 0;

            int.TryParse(ddlSup.SelectedValue.ToString(), out supID);
            sc.SupID = supID;
            HttpCookie myCookie = Request.Cookies["user"];
            sc.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            sc.CoursesTeachers = Session["table"] as DataTable;
            int id = sc.update();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Classes.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddClass.aspx?id=0&&alret=notpass");
            }

        }
        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = grid.DataSource as DataTable;
            /*if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                ProductPriceItems PPI = new ProductPriceItems();
                table = PPI.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                DataColumn colid = table.Columns[0];
                table.PrimaryKey = new DataColumn[] { colid };
            }
            else
            {
                table = GetTable();
            }*/
            DataColumn colid = table.Columns[0];
            table.PrimaryKey = new DataColumn[] { colid };
            DataRow found = table.Rows.Find(e.Keys["ID"]);
            found["TeacherName"] = e.NewValues["TeacherName"];
            /*found["Amount"] = e.NewValues["Amount"];
            found["Seq"] = e.NewValues["Seq"];
            found["GLAccountID"] = e.NewValues["GLAccountID"];
            */
            Session["Table"] = table;
            grid.DataSource = table;
            grid.DataBind();
            string sql = "select ID as TeacherID,Name as TeacherName from Std_Teacher ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            GridViewDataComboBoxColumn regioncolumn = (ASPxGridView1.Columns["clTeacher"] as GridViewDataComboBoxColumn);
            regioncolumn.PropertiesComboBox.DataSource = dt;
            regioncolumn.PropertiesComboBox.ValueField = "TeacherID";
            regioncolumn.PropertiesComboBox.TextField = "TeacherName";
            e.Cancel = true;
            grid.CancelEdit();
        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            string sql = "select ID as TeacherID,Name as TeacherName from Std_Teacher inner join Std_TeacherCourses on TeacherID = ID where CourseID=" + e.EditingKeyValue.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            GridViewDataComboBoxColumn regioncolumn = (ASPxGridView1.Columns["clTeacher"] as GridViewDataComboBoxColumn);
            regioncolumn.PropertiesComboBox.DataSource = dt;
            regioncolumn.PropertiesComboBox.ValueField = "TeacherID";
            regioncolumn.PropertiesComboBox.TextField = "TeacherName";

        }
    }
}