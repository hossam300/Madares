using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
//using ERPWebForms.Business;

namespace ERPWebForms.StudentAfair
{
    public partial class AddAbsent : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddAbsent, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            //   ASPxGridView1.StartEdit(1);
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                FillGrid();
            }


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Absent.aspx?alert=success");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Absent.aspx");
        }
        protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            if (ddlClasses.SelectedIndex != -1 && txtDate.Text != "")
            {
                string sql = "select ID,Name,0 as first ,0 as second,0 as third,0 as fourth,0 as fifth from Std_Student where StudClassID = " + ddlClasses.SelectedValue.ToString();
                DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                DateTime d = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //DateTime date = new DateTime(2013, 1, 5);
                DateTime fdt = getFirstDayinWeek(d);
                DateTime edt = fdt.AddDays(5);
                //sql = "select StudentID,AbsentDate from Std_Absent where ClassID = " + ddlClasses.SelectedValue.ToString() + " and AbsentDate between '" + fdt.ToShortDateString() + "' and '" + edt.ToShortDateString() + "'";
                sql = "select StudentID,AbsentDate from Std_Absent where ClassID = " + ddlClasses.SelectedValue.ToString() + " and AbsentDate between convert(date,'" + fdt.ToShortDateString() + "',103) and convert(date,'" + edt.ToShortDateString() + "',103) ";
                DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
                DataRow[] drs;
                int dtCol;
                DateTime absentDate;
                if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        drs = dt.Select("ID = " + dt2.Rows[i]["StudentID"].ToString());
                        DateTime.TryParse(dt2.Rows[i]["AbsentDate"].ToString(), out absentDate);
                        dtCol = absentDate.Subtract(fdt).Days;
                        if (drs.Length > 0)
                            drs[0][dtCol + 2] = 1;
                    }
                }
                /*  DayOfWeek firstDay = DayOfWeek.Sunday;
                  CalendarWeekRule rule;
                  System.Globalization.Calendar cal = new GregorianCalendar();

                  rule = CalendarWeekRule.FirstFullWeek;
                  int wn = GetWeekNumberOfTheYear(d);
                  DateTime fdt = new DateTime(DateTime.Now.Year, 1, 1).AddDays(wn * 7);
                  DateTime edt = fdt.AddDays(7); */
                //cal.getf
              //  GridViewDataCheckColumn c;
                /* for (DateTime i = fdt; i < edt; i=i.AddDays(1))
                 {
                     dt.Columns.Add(i.ToShortDateString(),typeof(Boolean));	
                     c = new GridViewDataCheckColumn();
                     c.FieldName = i.ToShortDateString();
                     c.Caption = i.ToShortDateString();
                 }*/
                /* for (int i = 3; i < 8; i++)
                 {
                     ASPxGridView1.Columns[i].Caption = fdt.ToShortDateString();
                     fdt = fdt.AddDays(1);
                 }*/
                ASPxGridView1.Columns["first"].Caption = fdt.ToShortDateString();
                fdt = fdt.AddDays(1);
                ASPxGridView1.Columns["second"].Caption = fdt.ToShortDateString();
                fdt = fdt.AddDays(1);
                ASPxGridView1.Columns["third"].Caption = fdt.ToShortDateString();
                fdt = fdt.AddDays(1);
                ASPxGridView1.Columns["fourth"].Caption = fdt.ToShortDateString();
                fdt = fdt.AddDays(1);
                ASPxGridView1.Columns["fifth"].Caption = fdt.ToShortDateString();
                fdt = fdt.AddDays(1);
                ASPxGridView1.DataSource = dt;
                ASPxGridView1.DataBind();
                ASPxGridView1.StartEdit(1);
            }
        }

        private static DateTime getFirstDayinWeek(DateTime d)
        {
            DateTime fdt = d;
            switch (d.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    fdt = d;
                    break;
                case DayOfWeek.Monday:
                    fdt = d.AddDays(-1);
                    break;
                case DayOfWeek.Tuesday:
                    fdt = d.AddDays(-2);
                    break;
                case DayOfWeek.Wednesday:
                    fdt = d.AddDays(-3);
                    break;
                case DayOfWeek.Thursday:
                    fdt = d.AddDays(-4);
                    break;
                case DayOfWeek.Friday:
                    fdt = d.AddDays(-5);
                    break;
                case DayOfWeek.Saturday:
                    fdt = d.AddDays(-6);
                    break;
                default:
                    fdt = d;
                    break;
            }
            return fdt;
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("HRUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            //   trigger.ControlID = ASPxButton1.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            // trigger2.ControlID = ASPxButton2.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }


        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
            DataRow dr = ASPxGridView1.GetDataRow(Gid);
            int id = Convert.ToInt32(dr["EmpID"].ToString());
            if (e.ButtonID == "btnview")
            {
                Response.Redirect("~/HR/ViewEmployee.aspx?id=" + id);
            }
            else
                ASPxGridView1.SettingsEditing.Mode = (GridViewEditingMode)id;

        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            ASPxGridView1.StartEdit(id);
            //  ASPxGridView1.DataBind();
        }
        private int GetWeekNumberOfTheYear(DateTime dt)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            // option 1 
            /*   var weekNo = currentCulture.Calendar.GetWeekOfYear(DateTime.Now, currentCulture.DateTimeFormat.CalendarWeekRule, currentCulture.DateTimeFormat.FirstDayOfWeek);*/
            // option 2 
            var weekNo = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            return weekNo;
        }
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Saturday);
        }


        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
             HttpCookie myCookie = Request.Cookies["user"];
            int OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int ID = Convert.ToInt32(e.NewValues[0].ToString());
            int classID = Convert.ToInt32(ddlClasses.SelectedValue.ToString());
            string Name = e.NewValues[1].ToString();
            Student std = new Student();
            int date1Absent = Convert.ToInt32(e.NewValues[2].ToString());
            DateTime d = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime date = new DateTime(2013, 1, 5);
            DateTime date1 = getFirstDayinWeek(d);
            std.addAbsent(ID, classID, date1, date1Absent, OperatorID);
            int date2Absent = Convert.ToInt32(e.NewValues[3].ToString());
            DateTime date2 = date1.AddDays(1);
            std.addAbsent(ID, classID, date2, date2Absent, OperatorID);
            int date3Absent = Convert.ToInt32(e.NewValues[4].ToString());
            DateTime date3 = date1.AddDays(2);
            std.addAbsent(ID, classID, date3, date3Absent, OperatorID);
            int date4Absent = Convert.ToInt32(e.NewValues[5].ToString());
            DateTime date4 = date1.AddDays(3);
            std.addAbsent(ID, classID, date4, date4Absent, OperatorID);
            int date5Absent = Convert.ToInt32(e.NewValues[6].ToString());
            DateTime date5 = date1.AddDays(4);
            std.addAbsent(ID, classID, date5, date5Absent, OperatorID);
            FillGrid();
            e.Cancel = true;
        }
    }
}