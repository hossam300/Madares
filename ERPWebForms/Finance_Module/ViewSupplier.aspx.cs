using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class ViewSupplier : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewSupplier, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            if (Convert.ToInt32(Request.QueryString["SupplierID"].ToString()) > 0)
            {
                Supplier supplier = new Supplier();
                supplier.get(Convert.ToInt32(Request.QueryString["SupplierID"].ToString()));
                lblSupplierID.Text = supplier.ID.ToString();
                lblSupplierName.Text = supplier.Name.ToString();
                lblCreationDate.Text = supplier.CreationDate.ToShortDateString();
                lblLastModifiedDate.Text = supplier.LastModifiedDate.ToShortDateString();

                //DataTable dt = supplier.getCustomerItemList(Convert.ToInt32(Request.QueryString["CustomerID"].ToString()));
                //ASPxGridView1.DataSource = dt;
                //ASPxGridView1.DataBind();
            }
        }

    }
}