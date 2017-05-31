using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class AddCustomer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddCustomer, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }


                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    Customer customer = new Customer();
                    customer.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    txtCustomerName.Text = customer.Name;
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                }
                else
                {
                    btnEdit.Visible = false;
                    btnSave.Visible = true;
                }
            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Customer customer2 = new Customer();
            customer2.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            customer2.Name = txtCustomerName.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            customer2.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int CustomerID = customer2.update();
            if (CustomerID > 0)
            {
                Response.Redirect("Customers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddCustomer.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Name = txtCustomerName.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            customer.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int CustomerID = customer.save();
            if (CustomerID > 0)
            {
                Response.Redirect("Customers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddCustomer.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customers.aspx");
        }
    }
}