using DevExpress.Export;
using DevExpress.Web.ASPxTreeList;
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
    public partial class AllGLAccounts : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AllGLAccounts, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                ASPxTreeList1.DataBind();
                TreeListNode firstUnread = ASPxTreeList1.FindNodeByFieldValue("IsNew", true);
                //  firstUnread.Focus();
                ASPxTreeList1.ExpandToLevel(2);

            }
            GLAccount gl = new GLAccount();
            DataTable dt = gl.getList();
            ASPxTreeList1.DataSource = dt;
            ASPxTreeList1.DataBind();
            AddSubmitEvent();
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "success")
                {
                    Response.Write("<script>alert('تم الحفظ بنجاح.');</script>");
                }
            }
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("AccountingUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnExportToXlsx.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = btnExportToRtf.UniqueID;

            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);
        }

        protected void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            PrepareExporter();
            treeListExporter.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void btnExportToRtf_Click(object sender, EventArgs e)
        {
            PrepareExporter();
            treeListExporter.WriteRtfToResponse();
        }
        void PrepareExporter()
        {
            treeListExporter.Settings.AutoWidth = true;
            treeListExporter.Settings.ExpandAllNodes = true;
        }




        protected void treeList_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            TreeListNode node = ASPxTreeList1.FindNodeByKeyValue(key);
            e.Result = GetEntryText(node);
        }
        protected string GetEntryText(TreeListNode node)
        {
            if (node != null)
            {
                string text = node["Text"].ToString();
                return text.Trim().Replace("\r\n", "<br />");
            }
            return string.Empty;
        }
        protected void treeList_HtmlDataCellPrepared(object sender, TreeListHtmlDataCellEventArgs e)
        {
            if (Object.Equals(e.GetValue("IsNew"), true))
                e.Cell.Font.Bold = true;
        }
        protected void ASPxTreeList1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}