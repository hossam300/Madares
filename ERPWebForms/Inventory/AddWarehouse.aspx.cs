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
    public partial class AddWarehouse : BasePage
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
                        Warehouse warehouse = new clsWarehouse().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtName.Text = warehouse.Name;
                        ddlStoreKeeper.SelectedValue = warehouse.StoreKeeper.ToString();
                        txtWarehouseAddress.Text = warehouse.Address;
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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            warehouse.Name = txtName.Text;
            warehouse.Address = txtWarehouseAddress.Text;
            warehouse.StoreKeeper =Convert.ToInt32(ddlStoreKeeper.SelectedValue.ToString());
            warehouse.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            warehouse.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            clsWarehouse clsWarehouse = new Business.Inventory.Controllers.clsWarehouse();
            int id = clsWarehouse.update(Convert.ToInt32(Request.QueryString["id"].ToString()), warehouse);
            if (id > 0)
            {
                Response.Redirect("~/Inventory/Warehouses.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddWarehouse.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Warehouse warehouse = new Warehouse();
           // warehouse.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            warehouse.Name = txtName.Text;
            warehouse.Address = txtWarehouseAddress.Text;
            warehouse.StoreKeeper = Convert.ToInt32(ddlStoreKeeper.SelectedValue.ToString());
            warehouse.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            warehouse.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            clsWarehouse clsWarehouse = new Business.Inventory.Controllers.clsWarehouse();
            int id = clsWarehouse.insert( warehouse);
            if (id > 0)
            {
                Response.Redirect("~/Inventory/Warehouses.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddWarehouse.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/Warehouses.aspx");
        }
    }
}