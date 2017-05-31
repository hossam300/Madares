using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using DevExpress.XtraGrid.Views.Base;
using DevExpress.Web;
using System.Data;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using System.Resources;

namespace ERPWebForms.HR
{
    public partial class Sallary : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.Sallary , Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            //HashSet<string> addedColumns = new HashSet<string>{{ "ID", "EmpName", "EmpCode", "totalPenalty", "VacationsWithDeduction", "totalLiability", "FinalSalary", "Paid" };
            ResourceManager rm;
            if (Session["lang"] == "ar-EG")
            {
                rm = new ResourceManager("Sallary.ar-EG", System.Reflection.Assembly.GetExecutingAssembly());
            }
            else
            {
                rm = new ResourceManager("Sallary", System.Reflection.Assembly.GetExecutingAssembly());
            }
            if (!IsPostBack)
            {
                PayGrades pg = new PayGrades();
                pg.getSallaryItems();
                DataTable dt = pg.PayGradesSallaryItems;
                GridViewDataColumn ThisBool = new GridViewDataColumn();
                //ThisBool = (GridViewColumn)ASPxGridView1.Columns[0];
                //ASPxGridView1.Columns.Clear();
                //ASPxGridView1.Columns.Add(ThisBool);
                DataRow dr = dt.NewRow();
                dr["Name"] = "EmpID";
                dt.Rows.InsertAt(dr, 0);
                dr = dt.NewRow();
                dr["Name"] = "EmpName";
                dt.Rows.InsertAt(dr, 1);
                dr = dt.NewRow();
                dr["Name"] = "EmpCode";
                dt.Rows.InsertAt(dr, 2);
                dr = dt.NewRow();
                dr["Name"] = "totalPenalty";
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                dr = dt.NewRow();
                dr["Name"] = "VacationsWithDeduction";
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                dr = dt.NewRow();
                dr["Name"] = "totalLiability";
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                dr = dt.NewRow();
                dr["Name"] = "FinalSalary";
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                dr = dt.NewRow();
                dr["Name"] = "Paid";
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                /*dr["Name"] = "EmpID"; 
                dt.Rows.InsertAt(dr, 0);
                dr = dt.NewRow();
                dr["Name"] = GetLocalResourceObject("EmpName").ToString(); 
                dt.Rows.InsertAt(dr, 1);
                dr = dt.NewRow();
                dr["Name"] = GetLocalResourceObject("EmpCode").ToString();
                dt.Rows.InsertAt(dr, 2);
                dr = dt.NewRow();
                dr["Name"] = GetLocalResourceObject("totalPenalty").ToString(); 
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                dr = dt.NewRow();
                dr["Name"] = GetLocalResourceObject("VacationsWithDeduction").ToString(); 
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                dr = dt.NewRow();
                dr["Name"] = GetLocalResourceObject("totalLiability").ToString(); 
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                dr = dt.NewRow();
                dr["Name"] = GetLocalResourceObject("FinalSalary").ToString(); 
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                dr = dt.NewRow();
                dr["Name"] = GetLocalResourceObject("Paid").ToString(); 
                dt.Rows.InsertAt(dr, dt.Rows.Count);*/
                /* dt.Rows.InsertAt(dr, 1);
                 dt.Columns.Add("EmpID");
                 dt.Columns.Add("EmpName");
                 dt.Columns.Add("EmpCode");
                 dt.Columns.Add("totalDeserved");
                 dt.Columns.Add("totalLiability");
                 dt.Columns.Add("FinalSalary");
                 dt.Columns.Add("Paid");*/
                int added = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Name"] != "Paid")
                    {
                        if (dt.Rows[i]["Nature"].ToString() == "2" && added == 0)
                        {
                            ThisBool = new GridViewDataColumn();
                            ThisBool.Caption = GetLocalResourceObject("Rewards").ToString();
                            ThisBool.FieldName = "Rewards";
                            ThisBool.Visible = true;
                            ASPxGridView1.Columns.Add(ThisBool);

                            ThisBool = new GridViewDataColumn();
                            ThisBool.Caption = GetLocalResourceObject("totalDeserved").ToString();
                            ThisBool.FieldName = "totalDeserved";
                            ThisBool.Visible = true;
                            ASPxGridView1.Columns.Add(ThisBool);
                            added = 1;
                        }
                        ThisBool = new GridViewDataColumn();
                        if (GetLocalResourceObject(dt.Rows[i]["Name"].ToString()) != null)
                        {
                            ThisBool.Caption = GetLocalResourceObject(dt.Rows[i]["Name"].ToString()).ToString();
                        }
                        else
                            ThisBool.Caption = dt.Rows[i]["Name"].ToString();
                        ThisBool.FieldName = dt.Rows[i]["Name"].ToString();
                        if (dt.Rows[i]["Name"].ToString() == "EmpID")
                            ThisBool.Visible = false;
                        else
                            ThisBool.Visible = true;
                        ASPxGridView1.Columns.Add(ThisBool);
                    }
                    else
                    {
                        GridViewDataCheckColumn ThisBool2 = new GridViewDataCheckColumn();
                        ThisBool2.Caption = GetLocalResourceObject("Paid").ToString();
                        ThisBool2.FieldName = "Paid";
                        ThisBool2.Visible = true;
                        ASPxGridView1.Columns.Add(ThisBool2);
                    }

                }
            }
            else
            {
                if (ddlMonth.SelectedValue != "" && ddlYear.SelectedValue != "")
                {
                    FillGrid();

                    DataTable dt = (DataTable)Session["table"];
                    ASPxGridView1.DataSource = dt;
                    // ThisBool.FieldName = "Discontinued";
                    ASPxGridView1.DataBind();
                }
            }
            AddSubmitEvent();
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("HRUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = ASPxButton1.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = ASPxButton2.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }
        private void FillGrid()
        {
            DataTable dt = new Employee().getSalary(int.Parse(ddlMonth.SelectedValue.ToString()), int.Parse(ddlYear.SelectedValue.ToString()));
            //add the column to the grid

            //ASPxGridView1.AutoGenerateColumns = true;
            /* GridViewDataColumn ThisBool = new GridViewDataColumn();
             ThisBool = (GridViewColumn) ASPxGridView1.Columns[0];
             ASPxGridView1.Columns.Clear();
             ASPxGridView1.Columns.Add(ThisBool);
             for (int i = 0; i < dt.Columns.Count; i++)
             {
                 if (dt.Columns[i].ColumnName != "Paid")
                 {
                     ThisBool = new GridViewDataColumn();
                     ThisBool.Caption = dt.Columns[i].ColumnName;
                     ThisBool.FieldName = dt.Columns[i].ColumnName;
                     ThisBool.Visible = true;
                     ASPxGridView1.Columns.Add(ThisBool);
                 }
                 else
                 {
                     GridViewDataCheckColumn ThisBool2 = new GridViewDataCheckColumn();
                     ThisBool2.Caption = "تم الصرف";
                     ThisBool2.FieldName = "Paid";
                     ThisBool2.Visible = true;
                     ASPxGridView1.Columns.Add(ThisBool2);
                 }

             }*/

            ASPxGridView1.KeyFieldName = "EmpID";
            ASPxGridView1.DataSource = dt;
            // ThisBool.FieldName = "Discontinued";
            ASPxGridView1.DataBind();
            Session["table"] = dt;
            AddSubmitEvent();
            //prepare the data table
            //bind the grid
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnPay")
            {


                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                FillGrid();
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                DataTable dt = ASPxGridView1.DataSource as DataTable;
                int id = Convert.ToInt32(dr["EmpID"].ToString());
                dr["Paid"] = Convert.ToBoolean(true);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    new Employee().saveSallary(Convert.ToInt32(ddlMonth.SelectedValue.ToString()), Convert.ToInt32(ddlYear.SelectedValue.ToString()), 0, dt.Rows[i]);
                }
                Session["table"] = dt;
                /* dt.Rows.RemoveAt(Gid);
                 dt.Rows.InsertAt(dr,Gid);*/
                //ASPxGridView1.DataSource = dt;
                ASPxGridView1.DataBind();

                //Response.Redirect("~/HR/ViewEmployee.aspx?id=" + id);

            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ASPxGridView1.DataSource;
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    new Employee().saveSallary(Convert.ToInt32(ddlMonth.SelectedValue.ToString()), Convert.ToInt32(ddlYear.SelectedValue.ToString()), 0, dt.Rows[i]);
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlYear.SelectedValue != "" && ddlMonth.SelectedValue != "")
            {
                FillGrid();
                /*DataTable dt = new Employee().getSalary();
                ASPxGridView1.DataSource = dt;
                Session["table"] = dt;
                ASPxGridView1.DataBind();*/
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