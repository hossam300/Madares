using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.HR
{
    public partial class CreateJobtitle : BasePage
    {
        int a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.CreateJobtitle, Request.Cookies["user"]["Permission"].ToString()))
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
                        Jobtitle jobtitle = new Jobtitle();
                        jobtitle.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtJobTitle.Text = jobtitle.JobTitle;
                        txtJobDescription.Text = jobtitle.JobDescription;
                        txtNote.Text = jobtitle.Note;
                        btnSave.Visible = false;
                        btnEdit.Visible = true;
                        a = Convert.ToInt32(Request.QueryString["id"].ToString());
                    }
                    else
                    {
                        btnSave.Visible = true;
                        btnEdit.Visible = false;
                    }
                }
            }
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("HRUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnCancel.UniqueID;
            updatePanel.Triggers.Add(trigger);
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string fileLocation = "";
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                fileLocation = Server.MapPath("~/HR/Uplaods/" + fileName);
                FileUpload1.SaveAs(fileLocation);
            }
            Jobtitle jobtitle = new Jobtitle();
            jobtitle.JobTitle = txtJobTitle.Text;
            jobtitle.ID = a;
            jobtitle.JobSpecification = fileLocation;
            jobtitle.JobDescription = txtJobDescription.Text;
            jobtitle.Note = txtNote.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            jobtitle.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = jobtitle.update();
            if (id > 0)
            {
                Response.Redirect("~/HR/JobTitles.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateJobtitle.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string fileLocation = "";
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                fileLocation = Server.MapPath("~/HR/Uplaods/" + fileName);
                FileUpload1.SaveAs(fileLocation);

            }
            Jobtitle jobtitle = new Jobtitle();
            jobtitle.JobTitle = txtJobTitle.Text;
            jobtitle.JobSpecification = fileLocation;
            jobtitle.JobDescription = txtJobDescription.Text;
            jobtitle.Note = txtNote.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            jobtitle.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = jobtitle.save();
            if (id > 0)
            {
                Response.Redirect("~/HR/JobTitles.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/HR/CreateJobtitle.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HR/JobTitles.aspx");
        }
        protected void FileUpload1_Load(object sender, EventArgs e)
        {

        }
        protected void FileUpload1_PreRender(object sender, EventArgs e)
        {

        }
    }
}