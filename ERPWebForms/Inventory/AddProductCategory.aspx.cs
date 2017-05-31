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
    public partial class AddProductCategory : BasePage
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
                        ProductCategory productCategory = new clsProductCategory().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtProductCategory.Text = productCategory.Name;
                        txtCategoryDescription.Text = productCategory.Description;
                      
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
            ProductCategory productCategory = new ProductCategory();
            productCategory.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            productCategory.Name = txtProductCategory.Text;
            productCategory.Description = txtCategoryDescription.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            productCategory.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            clsProductCategory clsProductCategory = new Business.Inventory.Controllers.clsProductCategory();
            int id = clsProductCategory.update(Convert.ToInt32(Request.QueryString["id"].ToString()), productCategory);
            if (id > 0)
            {
                Response.Redirect("~/Inventory/ProductCategories.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddProductCategory.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            productCategory.Name = txtProductCategory.Text;
            productCategory.Description = txtCategoryDescription.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            productCategory.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            clsProductCategory clsProductCategory = new Business.Inventory.Controllers.clsProductCategory();
            int id = clsProductCategory.insert(productCategory);
            if (id > 0)
            {
                Response.Redirect("~/Inventory/ProductCategories.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Inventory/AddProductCategory.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory/ProductCategories.aspx");
        }
    }
}