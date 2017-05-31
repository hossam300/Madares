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
    public partial class AddCustomer : BasePage
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
                        InvCustomer customer = new ClsCustomer().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtName.Text = customer.Name;
                        txtmail.Text = customer.Email;
                        txtPhone.Text = customer.Phone;
                        txtRemarks.Text = customer.Remarks;
                        txtAddress.Text = customer.Address;
                        ddlType.SelectedValue = customer.Type.ToString();
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
            InvCustomer customer = new InvCustomer();
            customer.Name = txtName.Text;
            customer.Email = txtmail.Text;
            customer.Phone = txtPhone.Text;
            customer.Remarks = txtRemarks.Text;
            customer.Address = txtAddress.Text;
            customer.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            customer.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsCustomer().update(Convert.ToInt32(Request.QueryString["id"].ToString()), customer);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/Customers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddCustomer.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InvCustomer customer = new InvCustomer();
            customer.Name = txtName.Text;
            customer.Email = txtmail.Text;
            customer.Phone = txtPhone.Text;
            customer.Remarks = txtRemarks.Text;
            customer.Address = txtAddress.Text;
            customer.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            customer.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new ClsCustomer().insert(customer);
            if (res > 0)
            {
                Response.Redirect("~/Inventory/Customers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddCustomer.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/Customers.aspx");
        }
    }
}