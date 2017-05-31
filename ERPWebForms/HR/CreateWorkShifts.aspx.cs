using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class CreateWorkShifts : BasePage
    {
        ArrayList ar1 = new ArrayList();
        ArrayList ar2 = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateWorkShifts, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                string sql;
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        WorkShift workShift = new WorkShift();
                        workShift.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtShiftName.Text = workShift.ShiftName;
                        ddlFrom.SelectedValue = workShift.From;
                        ddlTo.SelectedValue = workShift.To;
                        // txtDuration.Text = workShift.Duration;
                        sql = "Select * From HR_Employees ";
                        DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            ListItem c = new ListItem();
                            c.Value = dt2.Rows[i]["EmpID"].ToString();

                            c.Text = dt2.Rows[i]["EmpName"].ToString();
                            box1View.Items.Add(c);
                        }
                        for (int i = 0; i < workShift.Emps.Count; i++)
                        {
                            sql = "Select * From HR_Employees where EmpID=" + workShift.Emps[i].ToString();
                            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                            ListItem b = new ListItem();
                            b.Value = workShift.Emps[i].ToString();

                            b.Text = dt.Rows[0]["EmpName"].ToString();

                            box2View.Items.Add(b);

                        }
                        for (int i = 0; i < box2View.Items.Count; i++)
                        {
                            box1View.Items.Remove(box2View.Items[i]);
                        }


                        btnSave.Visible = false;
                        btnEdit.Visible = true;
                    }
                    else
                    {
                        sql = "Select * From HR_Employees ";
                        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ListItem c = new ListItem();
                            c.Value = dt.Rows[i]["EmpID"].ToString();

                            c.Text = dt.Rows[i]["EmpName"].ToString();
                            box1View.Items.Add(c);
                        }

                        btnSave.Visible = true;
                        btnEdit.Visible = false;
                    }
                }
            }
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("HRUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnCancel.UniqueID;
            updatePanel.Triggers.Add(trigger);
        }
        protected void btnAddAll_Click(object sender, EventArgs e)
        {
            while (box1View.Items.Count != 0)
            {
                for (int i = 0; i < box1View.Items.Count; i++)
                {
                    box2View.Items.Add(box1View.Items[i]);
                    box1View.Items.Remove(box1View.Items[i]);
                }
            }
            lbmsg.Text = "All data added to listbox2";
            lbmsg.ForeColor = System.Drawing.Color.ForestGreen;
        }
        protected void btnAllSelected_Click(object sender, EventArgs e)
        {

            if (box1View.SelectedIndex >= 0)
            {
                for (int i = 0; i < box1View.Items.Count; i++)
                {
                    if (box1View.Items[i].Selected)
                    {
                        if (!ar1.Contains(box1View.Items[i]))
                        {
                            ar1.Add(box1View.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ar1.Count; i++)
                {
                    if (!box2View.Items.Contains(((ListItem)ar1[i])))
                    {
                        box2View.Items.Add(((ListItem)ar1[i]));
                    }
                    box1View.Items.Remove(((ListItem)ar1[i]));
                }
                box2View.SelectedIndex = -1;
            }
            else
            {
                lbmsg.Text = "Please select atleast one listitem";
                lbmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (box2View.SelectedIndex >= 0)
            {
                for (int i = 0; i < box2View.Items.Count; i++)
                {
                    if (box2View.Items[i].Selected)
                    {
                        if (!ar2.Contains(box2View.Items[i]))
                        {
                            ar2.Add(box2View.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ar2.Count; i++)
                {
                    if (!box1View.Items.Contains(((ListItem)ar2[i])))
                    {
                        box1View.Items.Add(((ListItem)ar2[i]));
                    }
                    box2View.Items.Remove(((ListItem)ar2[i]));
                }
                box1View.SelectedIndex = -1;
            }
            else
            {
                lbmsg.Text = "Data removed from listbox";
                lbmsg.ForeColor = System.Drawing.Color.ForestGreen;
            }



        }
        protected void btnRemoveAll_Click(object sender, EventArgs e)
        {
            while (box2View.Items.Count != 0)
            {
                for (int i = 0; i < box2View.Items.Count; i++)
                {
                    box1View.Items.Add(box2View.Items[i]);
                    box2View.Items.Remove(box2View.Items[i]);
                }
            }
            lbmsg.Text = "All data removed and moved to listbox1";
            lbmsg.ForeColor = System.Drawing.Color.ForestGreen;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

            WorkShift workShift = new WorkShift();
            workShift.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            workShift.ShiftName = txtShiftName.Text;
            workShift.From = ddlFrom.SelectedValue.ToString();
            workShift.To = ddlTo.SelectedValue.ToString();
            HttpCookie myCookie = Request.Cookies["user"];
            workShift.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            string[] from = ddlFrom.SelectedValue.ToString().Split(':', '\t');
            string[] to = ddlTo.SelectedValue.ToString().ToString().Split(':', '\t');


            string diffhoure = (Convert.ToInt32(to[0]) - Convert.ToInt32(from[0])).ToString();
            string diffminute = (Convert.ToInt32(to[1]) - Convert.ToInt32(from[1])).ToString();
            workShift.Duration = diffhoure + ":" + diffminute;
            for (int i = 0; i < box2View.Items.Count; i++)
            {
                workShift.Emps[i] = Convert.ToInt32(box2View.Items[i].Value.ToString());
            }
            int id = workShift.update();
            if (id > 0)
            {
                Response.Redirect("~/HR/WorkShifts.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateWorkShifts.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            WorkShift workShift = new WorkShift();
            workShift.ShiftName = txtShiftName.Text;
            workShift.From = ddlFrom.SelectedValue.ToString();
            workShift.To = ddlTo.SelectedValue.ToString();
            HttpCookie myCookie = Request.Cookies["user"];
            workShift.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            string[] from = ddlFrom.SelectedValue.ToString().Split(':', '\t');
            string[] to = ddlTo.SelectedValue.ToString().ToString().Split(':', '\t');


            string diffhoure = (Convert.ToInt32(to[0]) - Convert.ToInt32(from[0])).ToString();
            string diffminute = (Convert.ToInt32(to[1]) - Convert.ToInt32(from[1])).ToString();
            workShift.Duration = diffhoure + ":" + diffminute;
            ArrayList arr = new ArrayList();
            for (int i = 0; i < box2View.Items.Count; i++)
            {
                arr.Add(box2View.Items[i].Value.ToString());

            }
            workShift.Emps = arr;
            int id = workShift.save();
            if (id > 0)
            {
                Response.Redirect("~/HR/WorkShifts.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateWorkShifts.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/WorkShifts.aspx");
        }
    }
}