using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class AddSupplier : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddSupplier, Request.Cookies["user"]["Permission"].ToString()))
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
                    Supplier supplier = new Supplier();
                    supplier.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    txtSupplierName.Text = supplier.Name;
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
            Supplier supplier = new Supplier();
            supplier.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            supplier.Name = txtSupplierName.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            supplier.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int SupplierID = supplier.update();

            if (SupplierID > 0)
            {
                Response.Redirect("~/Finance_Module/Suppliers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddSupplier.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.Name = txtSupplierName.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            supplier.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int SupplierID = supplier.save();
            if (SupplierID > 0)
            {
                Response.Redirect("~/Finance_Module/Suppliers.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddSupplier.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/Suppliers.aspx");
        }
    }
}