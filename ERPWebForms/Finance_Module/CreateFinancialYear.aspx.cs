using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class CreateFinancialYear : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateFinancialYear, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
              if (!IsPostBack)
        {
            if (Request.QueryString["alert"] == "notpass")
            {
                Response.Write("<script>alert('لم يتم الحفظ');</script>");
            }
            if (Request.QueryString != null && Request.QueryString.AllKeys.Contains("id"))
            {
                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        FinancialYear year = new FinancialYear();
                        year.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtYearName.Text = year.Name;
                        txtStartDate.Text = year.StartDate.ToShortDateString();
                        txtEndDate.Text = year.EndDate.ToShortDateString();
                        txtDesc.Text = year.Description;
                        //txtstartingBalance.Text = bank.InitialBalance.ToString();
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
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FinancialYear f = new FinancialYear();
        f.Name = txtYearName.Text;
        f.Description = txtDesc.Text;
        DateTime d;
        DateTime.TryParse(txtStartDate.Text, out d);
        f.StartDate = d;

        DateTime.TryParse(txtEndDate.Text, out d);
        f.EndDate = d;
      int id=  f.save();
      if (id > 0)
      {
          Response.Redirect("~/Finance_Module/FinancialYears.aspx?alert=success");
      }
      else
      {
          Response.Redirect("~/Finance_Module/CreateFinancialYear.aspx?id=0&&alret=notpass");
      }
       
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        FinancialYear f = new FinancialYear();
        f.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
        f.Name = txtYearName.Text;
        f.Description = txtDesc.Text;
        DateTime d;
        DateTime.TryParse(txtStartDate.Text, out d);
        f.StartDate = d;

        DateTime.TryParse(txtEndDate.Text, out d);
        f.EndDate = d;
      int id=  f.update();
      if (id > 0)
      {
          Response.Redirect("~/Finance_Module/FinancialYears.aspx?alert=success");
      }
      else
      {
          Response.Redirect("~/Finance_Module/CreateFinancialYear.aspx?id=0&&alret=notpass");
      }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Finance_Module/FinancialYears.aspx");
    }
}
}