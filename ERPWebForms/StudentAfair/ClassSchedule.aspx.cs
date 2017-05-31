using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
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
    public partial class ClassSchedule : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table"] as DataTable;
            if (table == null || table.Rows == null)
            {
                table = new DataTable();
                if (ddlClasses.SelectedValue != null && ddlClasses.SelectedIndex > 0)
                {

                    table = fillGridCol();
                    //sc.get(int.Parse(ddlClasses.SelectedValue.ToString()));
                    DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                    DataColumn Days = table.Columns.Add("Day", typeof(String));


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
                    DataRow dr;
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
                    for (int i = 1; i < 8; i++)
                    {
                        dr = table.NewRow();
                        dr["ID"] = i;
                        // ClassSchedule.re
                        dr["Day"] = GetLocalResourceObject("Day" + i.ToString());
                        table.Rows.Add(dr);
                    }

                    /*table.Rows.Add(new Object[] { 1, "Saturday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 2, "Sunday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 3, "Monday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 4, "Tuesday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 5, "Wednesday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 6, "Thursday", "", "", "", "", "", "", "" });
                    table.Rows.Add(new Object[] { 7, "Friday", "", "", "", "", "", "", "" });
               */

                    Session["Table"] = table;
                }
            }
            return table;
        }

        private DataTable fillGridCol()
        {
            int noOfLec = new StdClass().getNoOfLec(int.Parse(ddlClasses.SelectedValue.ToString()));
            DataTable dt = new StdClass().GetCourses(int.Parse(ddlClasses.SelectedValue.ToString()));
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

                Session["Table"] = null;
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
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ClassSchedule, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            AddSubmitEvent();
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("SFUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnExportClassw.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = btnExportClassx.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }
        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();

            table = GetTable();

            DataRow found = table.Rows.Find(e.Keys[0]);
            found["Day"] = e.NewValues["Day"];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (!table.Columns[i].ReadOnly && e.NewValues[table.Columns[i].ToString()] != null)
                {
                    found[table.Columns[i].ToString()] = e.NewValues[table.Columns[i].ToString()];
                }

            }
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

            table = GetTable();

            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["Day"], e.NewValues["Lecture1"], e.NewValues["Lecture2"], e.NewValues["Lecture3"], e.NewValues["Lecture4"], e.NewValues["Lecture5"], e.NewValues["Lecture6"], e.NewValues["Lecture7"] });
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
            Session["Table"] = table;

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
            StdClass st = new StdClass();
            st.ClassSchedule = Session["Table"] as DataTable;
            st.ID = Convert.ToInt32(ddlClasses.SelectedValue.ToString());
            st.updateSchdulebyclass();
        }

        protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            StdClass st = new StdClass();
            int classID = Convert.ToInt32(ddlClasses.SelectedValue.ToString());
            st.getSchdulebyclass(classID);
            DataTable dt = st.ClassSchedule;
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                //   grid.DataSource = dt;
                // grid.DataBind();
                fillGridCol();
            }
            else
            {
                Session["Table"] = null;
                dt = GetTable();

            }
            grid.DataSource = dt;
            grid.DataBind();
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
            dt.Columns["ID"].ReadOnly = true;
            Session["Table"] = dt;
        }

        protected void btnExportClassx_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }

        protected void btnExportClassw_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteRtfToResponse();
        }
    }

}