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
    public partial class AddSupplier : BasePage
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
                        InvSupplier supplier = new ClsSupplier().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtName.Text = supplier.Name;
                        txtmail.Text = supplier.Email;
                        txtPhone.Text = supplier.Phone;
                        txtRemarks.Text = supplier.Remarks;
                        txtAddress.Text = supplier.Address;
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
            InvSupplier supplier = new InvSupplier();
            supplier.Name = txtName.Text;
            supplier.Email = txtmail.Text;
            supplier.Phone = txtPhone.Text;
            supplier.Remarks = txtRemarks.Text;
            supplier.Address = txtAddress.Text;
            supplier.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            supplier.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsSupplier().update(Convert.ToInt32(Request.QueryString["id"].ToString()), supplier);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/Suppliers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddSupplier.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InvSupplier supplier = new InvSupplier();
            supplier.Name = txtName.Text;
            supplier.Email = txtmail.Text;
            supplier.Phone = txtPhone.Text;
            supplier.Remarks = txtRemarks.Text;
            supplier.Address = txtAddress.Text;
            supplier.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            supplier.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsSupplier().insert(supplier);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/Suppliers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddSupplier.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/Suppliers.aspx");
        }
    }
}