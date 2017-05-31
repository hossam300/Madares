using ERPWebForms.Business.Inventory.Controllers;
using ERPWebForms.Business.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Inventory
{
    public partial class ViewDispatchItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
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
                        Dispatch dispatch = new ClsDispatch().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        ddlProduct.SelectedValue = dispatch.ProductID.ToString();
                        ddlStuff.SelectedValue = dispatch.StuffID.ToString();
                        ddlWarehouse.SelectedValue = dispatch.WarehouseID.ToString();
                        txtRemarks.Text = dispatch.Remarks;
                        txtQuantity.Text = dispatch.Amount.ToString();
                  
                        btnEdit.Visible = true;
                    }
                  
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/Inventory/DispatchItem.aspx?id=" + id);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/DispatchItems.aspx");
        }
    }
}