using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class AddHoliday : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddHoliday, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/HR/UnAuthorized.aspx");
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
                        Holiday holiday = new Holiday();
                        holiday.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtName.Text = holiday.Name;
                        txtDate.Text = holiday.Date.ToShortDateString();
                        if (holiday.Repeats == 0)
                        {
                            cbRepeats.Checked = false;
                        }
                        else
                        {
                            cbRepeats.Checked = true;
                        }
                        ddlType.SelectedValue = holiday.Type;

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
            Holiday holiday = new Holiday();
            holiday.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            holiday.Name = txtName.Text;
            holiday.Date = Convert.ToDateTime(txtDate.Text);
            holiday.Type = ddlType.SelectedValue.ToString();
            HttpCookie myCookie = Request.Cookies["user"];
            holiday.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            if (cbRepeats.Checked)
            {
                holiday.Repeats = 1;
            }
            else
            {
                holiday.Repeats = 0;
            }
            int id = holiday.update();
            if (id > 0)
            {
                Response.Redirect("~/HR/Holidays.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/AddHoliday.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Holiday holiday = new Holiday();
            holiday.Name = txtName.Text;
            holiday.Date = Convert.ToDateTime(txtDate.Text);
            holiday.Type = ddlType.SelectedValue.ToString();
            HttpCookie myCookie = Request.Cookies["user"];
            holiday.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            if (cbRepeats.Checked)
            {
                holiday.Repeats = 1;
            }
            else
            {
                holiday.Repeats = 0;
            }
            int id = holiday.save();
            if (id > 0)
            {
                Response.Redirect("~/HR/Holidays.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/AddHoliday.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/Holidays.aspx");
        }
    }
}