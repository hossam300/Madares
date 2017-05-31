﻿using DevExpress.Export;
using DevExpress.XtraPrinting;
using ERPWebForms.Business.Inventory.Controllers;
using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Inventory
{
    public partial class ProductCategories : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //else
            //{
            //    if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.Banks, Request.Cookies["user"]["Permission"].ToString()))
            //        Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            //}
          //  gbind();
            AddSubmitEvent();
          if (!IsPostBack)
          {
              if (Request.QueryString["alert"] == "success")
              {
                  Response.Write("<script>alert('تم الحفظ بنجاح.');</script>");
              }
             // gbind();
          }
        }
    
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("InvUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnExportExcel.UniqueID;
            UpdatePanelControlTrigger trigger2 = new PostBackTrigger();
            trigger2.ControlID = btnExportWord.UniqueID;
            updatePanel.Triggers.Add(trigger);
            updatePanel.Triggers.Add(trigger2);

        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnView")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["ID"].ToString());
                Response.Redirect("~/Inventory/ViewProductCategory.aspx?id=" + id);
            }
            if (e.ButtonID=="btnActive")
            {
                 int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["ID"].ToString());
                new clsProductCategory().Active(id);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            Response.Redirect("~/Inventory/AddProductCategory.aspx?id=" + id);
        }

        protected void btnProductCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/AddProductCategory.aspx?id=0");
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }

        protected void btnExportWord_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteRtfToResponse();
        }
    }
}