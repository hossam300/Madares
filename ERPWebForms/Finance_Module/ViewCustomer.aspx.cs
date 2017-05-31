using DevExpress.Export;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class ViewCustomer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewCustomer, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["CustomerID"].ToString()) > 0)
            {
                Customer customer = new Customer();
                customer.get(Convert.ToInt32(Request.QueryString["CustomerID"].ToString()));
                lblCustomerID.Text = customer.ID.ToString();
                lblCustomerName.Text = customer.Name.ToString();
                lblCreationDate.Text = customer.CreationDate.ToShortDateString();
                lblLastModifiedDate.Text = customer.LastModifiedDate.ToShortDateString();
                lblTotalBalance.Text = customer.TotalBalance.ToString();
                lblTotalBuyedAmount.Text = customer.totalBuyedAmount.ToString();
                DataTable dt = customer.getCustomerItemList(Convert.ToInt32(Request.QueryString["CustomerID"].ToString()));
                ASPxGridView1.DataSource = dt;
                ASPxGridView1.DataBind();
                AddSubmitEvent();
            }
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("AccountingUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = ASPxButton1.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = ASPxButton2.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCustomer.aspx?id=" + Request.QueryString["CustomerID"].ToString());
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customers.aspx");
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {

        }
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }
        protected void ASPxButton3_Click(object sender, EventArgs e)
        {

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