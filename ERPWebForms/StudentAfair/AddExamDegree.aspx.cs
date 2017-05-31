using DevExpress.Utils;
using DevExpress.Web;
//using ERPWebForms.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ERPWebForms.StudentAfair
{
    public partial class AddExamDegree : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["TableDegree"] as DataTable;
            if (table == null || table.Rows == null)
            {
                table = new DataTable();
                if (ddlEmaxName.SelectedValue != null && ddlEmaxName.SelectedIndex > 0)
                {


                    //sc.get(int.Parse(ddlClasses.SelectedValue.ToString()));
                    DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                    DataColumn Days = table.Columns.Add("StudentName", typeof(String));
                    fillGridCol(table);

                    /*DataColumn Lecture1 = table.Columns.Add("Lecture1", typeof(String));
                    DataColumn Lecture2 = table.Columns.Add("Lecture2", typeof(String));
                    DataColumn Lecture3 = table.Columns.Add("Lecture3", typeof(String));
                    DataColumn Lecture4 = table.Columns.Add("Lecture4", typeof(String));
                    DataColumn Lecture5 = table.Columns.Add("Lecture5", typeof(String));
                    DataColumn Lecture6 = table.Columns.Add("Lecture6", typeof(String));
                    DataColumn Lecture7 = table.Columns.Add("Lecture7", typeof(String));
                   */
                    table.PrimaryKey = new DataColumn[] { colid };
                    colid.ReadOnly = true;
                   // DataRow dr;
                    // Create a resource manager to retrieve resources.
                    ResourceManager rm;
                    if (Session["lang"] == "ar-EG")
                    {
                        rm = new ResourceManager("ClassSchedule.ar-EG", System.Reflection.Assembly.GetExecutingAssembly());
                    }
                    else
                    {
                        rm = new ResourceManager("ClassSchedule", System.Reflection.Assembly.GetExecutingAssembly());
                    }


                    // Retrieve the value of the string resource named "welcome".
                    // The resource manager will retrieve the value of the  
                    // localized resource using the caller's current culture setting.
                    //String str = rm.GetString("welcome");
                    /*for (int i = 1; i < 8; i++)
                    {
                        dr = table.NewRow();
                        dr["ID"] = i;
                        // ClassSchedule.re
                        dr["Day"] = GetLocalResourceObject("Day" + i.ToString());
                        table.Rows.Add(dr);
                    }*/

                    /*table.Rows.Add(new Object[] { 1, "Saturday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 2, "Sunday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 3, "Monday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 4, "Tuesday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 5, "Wednesday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 6, "Thursday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 7, "Friday", "", "", "", "", "", "", "" });
               */

                    Session["TableDegree"] = table;
                    // grid.DataSource = table;
                    // grid.DataBind();
                }
            }
            return table;
        }

        private void fillGridCol(DataTable table)
        {
            table.Rows.Clear();
            //get exam courses
            Exam ex = new Exam();
            ex.get(int.Parse(ddlEmaxName.SelectedValue.ToString()));
            //add the courses as columns
            object x;
            //DataTable table = new DataTable();
            GridViewDataTextColumn ThisBool = new GridViewDataTextColumn();
            DataTable dt = new Course().getList();
            for (int i = 0; i < ex.Courses.Rows.Count; i++)
            {

                x = grid.Columns[ex.Courses.Rows[i]["Name"].ToString()];
                if (x == null)
                {
                    table.Columns.Add(ex.Courses.Rows[i]["Name"].ToString(), typeof(decimal));
                    ThisBool = new GridViewDataTextColumn();
                    ThisBool.Caption = ex.Courses.Rows[i]["Name"].ToString();
                    ThisBool.FieldName = ex.Courses.Rows[i]["Name"].ToString();
                    ThisBool.Name = ex.Courses.Rows[i]["Name"].ToString();
                    ThisBool.VisibleIndex = i + 3;
                    /* ThisBool.PropertiesComboBox.DataSource = dt;
                     ThisBool.PropertiesComboBox.TextField = "Name";
                     ThisBool.PropertiesComboBox.ValueField = "ID";*/
                    ThisBool.Visible = true;
                    grid.Columns.Add(ThisBool);
                }
            }
            //add the total col
            x = grid.Columns["Total"];
            if (x == null)
            {
                table.Columns.Add("Total", typeof(Decimal));
                table.Columns.Add("ExamCourseID", typeof(Decimal));
                ThisBool = new GridViewDataTextColumn();
                ThisBool.Caption = "Total";
                ThisBool.FieldName = "Total";
                ThisBool.Name = "Total";
                ThisBool.ReadOnly = true;
                ThisBool.VisibleIndex = grid.Columns.Count - 1;
                grid.Columns.Add(ThisBool);
            }
            /*DataTable dtStd = ex.getExamStudents(ex.ID);
            DataRow dr = table.NewRow();
            for (int i = 0; i < dtStd.Rows.Count; i++)
            {
                dr = table.NewRow();
                dr["ID"] = dtStd.Rows[i]["ID"].ToString();
                dr["StudentName"] = dtStd.Rows[i]["Name"].ToString();
                for (int j = 0; j < ex.Courses.Rows.Count; j++)
                {
                    dr[ex.Courses.Rows[j]["Name"].ToString()] = 0;
                }
                table.Rows.Add(dr);
            }*/
            DataTable dtExamDegree;
            if (ddlClassName.SelectedIndex == -1)
                dtExamDegree = ex.getExamDegree(ex.ID);
            else
                dtExamDegree = ex.getExamDegree(ex.ID, int.Parse(ddlClassName.SelectedValue.ToString()));
            DataRow dr = table.NewRow();
            int stdID = 0;
            decimal total = 0, currDegree = 0;
            for (int i = 0; i < dtExamDegree.Rows.Count; i++)
            {
                currDegree = 0;
                if (stdID != int.Parse(dtExamDegree.Rows[i]["StdID"].ToString()))
                {

                    if (stdID != 0)
                    {
                        dr["Total"] = total;
                        table.Rows.Add(dr);
                    }
                    dr = table.NewRow();
                    dr["ID"] = dtExamDegree.Rows[i]["StdID"].ToString();
                    dr["ExamCourseID"] = dtExamDegree.Rows[i]["ExamCourseID"].ToString();
                    dr["StudentName"] = dtExamDegree.Rows[i]["StdName"].ToString();
                    total = 0;
                    stdID = int.Parse(dtExamDegree.Rows[i]["StdID"].ToString());
                }
                decimal.TryParse(dtExamDegree.Rows[i]["Degree"].ToString(), out currDegree);
                if (dtExamDegree.Rows[i]["Degree"].ToString() != "")
                {

                    total += currDegree;
                }
                dr[dtExamDegree.Rows[i]["courseName"].ToString()] = currDegree;
            }
            if (dr != null && stdID != 0)
            {
                dr["Total"] = total;
                table.Rows.Add(dr);
            }
            /*dr["ID"] = 1;
            dr["StudentName"] = "Habiba";
            for (int i = 0; i < ex.Courses.Rows.Count; i++)
            {
                dr[ex.Courses.Rows[i]["Name"].ToString()] = 100;
            }*/

            grid.DataSource = table;
            grid.DataBind();
            //get exam students

            /*int noOfLec = new StdClass().getNoOfLec(int.Parse(ddlEmaxName.SelectedValue.ToString()));
            DataTable dt = new StdClass().GetCourses(int.Parse(ddlEmaxName.SelectedValue.ToString()));
            DataTable table = new DataTable();
            if (grid.Columns.Count != noOfLec)
            {
                GridViewDataComboBoxColumn x;
                GridViewDataComboBoxColumn ThisBool = new GridViewDataComboBoxColumn();
                for (int i = 1; i <= noOfLec; i++)
                {
                    table.Columns.Add("Lecture" + i.ToString(), typeof(String));
                    x = grid.Columns["Lecture" + i.ToString()] as GridViewDataComboBoxColumn;
                    if (x == null)
                    {
                        ThisBool = new GridViewDataComboBoxColumn();
                        ThisBool.Caption = "Lecture" + i.ToString();
                        ThisBool.FieldName = "Lecture" + i.ToString();
                        ThisBool.Name = "Lecture" + i.ToString();
                        ThisBool.VisibleIndex = i + 3;
                        ThisBool.PropertiesComboBox.DataSource = dt;
                        ThisBool.PropertiesComboBox.TextField = "Name";
                        ThisBool.PropertiesComboBox.ValueField = "ID";
                        ThisBool.Visible = true;
                        grid.Columns.Add(ThisBool);
                    }
                }
            }*/
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

                Session["TableDegree"] = null;
                DataTable dt = DataAccess.ExecuteSQLQuery("SELECT [ID], [Name] FROM [Std_Exam]");

                ddlEmaxName.DataSource = dt;
                ddlEmaxName.DataTextField = "Name";
                ddlEmaxName.DataValueField = "ID";
                ddlEmaxName.DataBind();
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {

                        ddlEmaxName.SelectedValue = Request.QueryString["id"].ToString();
                    }
                }
            }
            //if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            //{
            //    ProductPriceItems PPI = new ProductPriceItems();
            //    DataTable dt = PPI.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
            //    grid.DataSource = dt;
            //    grid.KeyFieldName = "ID";
            //    grid.DataBind();
            //    btnEdit.Visible = true;
            //    btnSave.Visible = false;
            //    DataColumn colid = dt.Columns["ID"];
            //    dt.PrimaryKey = new DataColumn[] { colid };
            //    colid.ReadOnly = true;


            //    Session["Table"] = dt;
            //}
            //else
            //{
            grid.DataSource = GetTable();
            grid.KeyFieldName = "ID";
            grid.DataBind();


        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddExamDegree, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
            }
        }
        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();

            table = GetTable();

            DataRow found = table.Rows.Find(e.Keys[0]);
            //found["Day"] = e.NewValues["Day"];
            decimal tot = 0;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (!table.Columns[i].ReadOnly && e.NewValues[table.Columns[i].ToString()] != null)
                {
                    found[table.Columns[i].ToString()] = e.NewValues[table.Columns[i].ToString()];
                    if (table.Columns[i].ToString() != "ID" && table.Columns[i].ToString() != "StudentName" && table.Columns[i].ToString() != "Total" && table.Columns[i].ToString() != "ExamCourseID")
                    {
                        tot += decimal.Parse(e.NewValues[table.Columns[i].ToString()].ToString());
                    }
                }

            }
            found["Total"] = tot.ToString();
            /*  found["Lecture1"] = e.NewValues["Lecture1"];
              found["Lecture2"] = e.NewValues["Lecture2"];
              found["Lecture3"] = e.NewValues["Lecture3"];
              found["Lecture4"] = e.NewValues["Lecture4"];
              found["Lecture5"] = e.NewValues["Lecture5"];
              found["Lecture6"] = e.NewValues["Lecture6"];
              found["Lecture7"] = e.NewValues["Lecture7"];
              found["Lecture8"] = e.NewValues["Lecture8"];
              found["Lecture9"] = e.NewValues["Lecture9"];
              found["Lecture10"] = e.NewValues["Lecture10"];
              */

            Session["TableDegree"] = table;
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

            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["Day"], e.NewValues["Lecture1"], e.NewValues["Lecture2"], e.NewValues["Lecture3"], e.NewValues["Lecture4"], e.NewValues["Lecture5"], e.NewValues["Lecture6"], e.NewValues["Lecture7"] });
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
            Session["TableDegree"] = table;

            e.Cancel = true;
            grid.DataSource = table;
            grid.DataBind();
            grid.CancelEdit();
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ID"] = GetLastKey() + 1;

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            Exam ex = new Exam();

            int id = ex.saveExamDegree(Session["TableDegree"] as DataTable, int.Parse(ddlEmaxName.SelectedValue.ToString()), int.Parse(ddlClassName.SelectedValue.ToString()));
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Exams.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddExam.aspx?id=0&&alret=notpass");
            }
        }

        protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            StdClass st = new StdClass();
            int classID = Convert.ToInt32(ddlEmaxName.SelectedValue.ToString());
            //st.getSchdulebyclass(classID);
            int colNo = grid.Columns.Count - 1;
            List<GridViewColumn> cols = new List<GridViewColumn>();
            foreach (GridViewColumn col in grid.Columns)
            {
                if (col.Name == "StudentName" || col.Name == "ID" || col.Name == "#" || col.Name == "Edit")
                {
                    cols.Add(col);
                }
            }
            grid.Columns.Clear();
            for (int i = 0; i < cols.Count; i++)
            {
                grid.Columns.Add(cols[i]);
            }
            //grid.Columns = cols;

            Session["TableDegree"] = null;
            DataTable dt = new DataTable();
            DataColumn colid = dt.Columns.Add("ID", typeof(Int32));
            DataColumn Days = dt.Columns.Add("StudentName", typeof(String));

            fillGridCol(dt);
            /*
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
            
                //   grid.DataSource = dt;
                // grid.DataBind();
                fillGridCol(dt);
            }
            else
            {
                Session["Table"] = null;
                dt = GetTable();

            }*/
            grid.DataSource = dt;
            grid.DataBind();
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
            dt.Columns["ID"].ReadOnly = true;
            Session["TableDegree"] = dt;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Exams.aspx");
        }

     

        protected void grid_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (ddlClassName.SelectedIndex == 0)
            {
                e.Visible = false;
            }
            else
            {
                e.Visible =true;
            }
        }
    }
}