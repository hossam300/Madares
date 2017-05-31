using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class WorkingDays : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.WorkingDays , Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        WorkingDay workingDays = new WorkingDay();
                        workingDays.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddSaturday.SelectedValue = workingDays.Saturday.ToString();
                        ddlSunday.SelectedValue = workingDays.Sunday.ToString();
                        ddlMonday.SelectedValue = workingDays.Monday.ToString();
                        ddlThursday.SelectedValue = workingDays.Thursday.ToString();
                        ddlWednesday.SelectedValue = workingDays.Wednesday.ToString();
                        ddlTuesday.SelectedValue = workingDays.Tuesday.ToString();
                        ddlFriday.SelectedValue = workingDays.Friday.ToString();

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
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("HRUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnSave.UniqueID;


            updatePanel.Triggers.Add(trigger);


        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ddSaturday.Enabled = true;
            ddlSunday.Enabled = true;
            ddlMonday.Enabled = true;
            ddlThursday.Enabled = true;
            ddlWednesday.Enabled = true;
            ddlTuesday.Enabled = true;
            ddlFriday.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnEdit.Visible = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            WorkingDay workingDays = new WorkingDay();
            workingDays.Saturday = ddSaturday.SelectedValue;
            workingDays.Sunday = ddlSunday.SelectedValue;
            workingDays.Monday = ddlMonday.SelectedValue;
            workingDays.Thursday = ddlThursday.SelectedValue;
            workingDays.Wednesday = ddlWednesday.SelectedValue;
            workingDays.Tuesday = ddlTuesday.SelectedValue;
            workingDays.Friday = ddlFriday.SelectedValue;
            workingDays.update();
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ddSaturday.Enabled = false;
            ddlSunday.Enabled = false;
            ddlMonday.Enabled = false;
            ddlThursday.Enabled = false;
            ddlWednesday.Enabled = false;
            ddlTuesday.Enabled = false;
            ddlFriday.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = true;
        }
    }
}