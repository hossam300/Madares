using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class ViewJournalEntry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewJournalEntry, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["ID"].ToString()) > 0)
            {
                JournalEntry je = new JournalEntry();
                je.get(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                lblDescription.Text = je.Description.ToString();
                lblJournalEntryID.Text = je.ID.ToString();
                lblAmount.Text = je.Amount.ToString();
                lblCreationDate.Text = je.CreationDate.ToString();
                lblLastModifiedDate.Text = je.LastModifiedDate.ToString();
                grid.DataSource = je.JournalEntryRows;
                grid.DataBind();
            }

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddJournalEntry.aspx?id=" + Request.QueryString["ID"].ToString());
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("JournalEntries.aspx");
        }

    }
}