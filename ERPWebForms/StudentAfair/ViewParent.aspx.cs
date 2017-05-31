//using ERPWebForms.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class ViewParent : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewParent, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            if (Request.QueryString["id"].ToString() != null)
            {
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    Parent p = new Parent();
                    p.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    txtParentName.Text = p.Name;
                    txtjob.Text = p.Job;
                    txtPhone.Text = p.Phone;
                    txtAddress.Text = p.Address;
                    txtEmail.Text = p.Email;

                    btnEdit.Visible = true;

                }
                else
                {

                    btnEdit.Visible = false;
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/StudentAfair/AddParent.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Parents.aspx");
        }

        protected void ASPxGridView2_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnview")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/StudentAfair/ViewStudent.aspx?id=" + id);
            }
        }
    }
}