using ERPWebForms.Business.Inventory.Controllers;
using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Inventory
{
    public partial class AddNewItemToStock : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Security 
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //else
            //{
            //    if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddBank, Request.Cookies["user"]["Permission"].ToString()))
            //        Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            //}

            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Restock restock = new ClsRestock().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlProduct.SelectedValue = restock.ProductID.ToString();
                        ddlSupplier.SelectedValue = restock.SupplierID.ToString();
                        ddlWarehouse.SelectedValue = restock.WarehouseID.ToString();
                        txtRemarks.Text = restock.Remarks;
                        txtQuantity.Text = restock.Quantity.ToString();
                        txtTotalCost.Text = restock.TotalCost.ToString();
                        txtUnitCost.Text = restock.UnitCost.ToString();

                        if (restock.InvoiceImage != null)
                        {
                            hrefURL.Visible = true;
                            hrefURL.HRef = restock.InvoiceImage.ToString();
                            hrefURL.InnerText = "Download";
                        }

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
            UpdatePanel updatePanel = Page.Master.FindControl("InvUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnCancel.UniqueID;
            updatePanel.Triggers.Add(trigger);
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string fileLocation = "";
            if (FileUpload1.HasFile)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                fileLocation = Server.MapPath("~/Inventory/Uplaods/" + fileName);
                FileUpload1.SaveAs(fileLocation);
            }
            Restock restock = new Restock();
            restock.ProductID = Convert.ToInt32(ddlProduct.SelectedValue.ToString());
            restock.SupplierID = Convert.ToInt32(ddlSupplier.SelectedValue.ToString());
            restock.WarehouseID = Convert.ToInt32(ddlWarehouse.SelectedValue.ToString());
            restock.Quantity = Convert.ToInt32(txtQuantity.Text);
            restock.TotalCost = Convert.ToDouble(txtTotalCost.Text);
            restock.UnitCost = Convert.ToDouble(txtUnitCost.Text);
            restock.Remarks = txtRemarks.Text;
            restock.InvoiceImage = fileLocation;
            restock.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            restock.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsRestock().update(Convert.ToInt32(Request.QueryString["id"].ToString()), restock);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/RestockedItems.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddNewItemToStock.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string fileLocation = "";
            if (FileUpload1.HasFile)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                fileLocation = Server.MapPath("~/Inventory/Uplaods/" + fileName);
                FileUpload1.SaveAs(fileLocation);
            }
            Restock restock = new Restock();
            restock.ProductID = Convert.ToInt32(ddlProduct.SelectedValue.ToString());
            restock.SupplierID = Convert.ToInt32(ddlSupplier.SelectedValue.ToString());
            restock.WarehouseID = Convert.ToInt32(ddlWarehouse.SelectedValue.ToString());
            restock.Quantity = Convert.ToInt32(txtQuantity.Text);
            restock.TotalCost = Convert.ToDouble(txtTotalCost.Text);
            restock.UnitCost = Convert.ToDouble(txtUnitCost.Text);
            restock.Remarks = txtRemarks.Text;
            restock.InvoiceImage = fileLocation;
            restock.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            restock.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsRestock().insert(restock);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/RestockedItems.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddNewItemToStock.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/RestockedItems.aspx");
        }
    }
}