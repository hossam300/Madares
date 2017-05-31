//using ERPWebForms.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class AddDocuments : BasePage
    {
        string downloadUrl = "";
        int a;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddDocuments, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
            }
            btnSave.PostBackUrl = Request.Url.AbsoluteUri;
            btnEdit.PostBackUrl = Request.Url.AbsoluteUri;
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }

                if (Request.QueryString["id"].ToString() != null)
                {
                    if (Request.QueryString["CourseID"] != null)
                    {
                        ddlCourses.SelectedValue = Request.QueryString["CourseID"].ToString();
                    }
                    if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                    {
                        Document doc = new Document();
                        doc.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtName.Text = doc.Name;
                        FileUpload1.ResolveUrl(doc.URL);
                        ddlCourses.SelectedValue = doc.CourseID.ToString();
                        ddlClasses.SelectedValue = doc.ClassID.ToString();
                        btnSave.Visible = false;
                        btnEdit.Visible = true;
                        linkButton1.Visible = true;
                        downloadUrl = doc.URL;
                        a = Convert.ToInt32(Request.QueryString["id"].ToString());
                    }
                    else
                    {
                        linkButton1.Visible = false;
                        btnSave.Visible = true;
                        btnEdit.Visible = false;
                    }
                }
            }
        }

        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("SFUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnCancel.UniqueID;
            updatePanel.Triggers.Add(trigger);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string fileLocation = "";
            if (FileUpload1.HasFile)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                fileLocation = Server.MapPath("~/StudentAfair/Documents/" + fileName);
                FileUpload1.SaveAs(fileLocation);
            }
            Document doc = new Document();
            doc.Name = txtName.Text;
            doc.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            doc.URL = fileLocation;
            doc.CourseID = Convert.ToInt32(ddlCourses.SelectedValue.ToString());
            doc.ClassID = Convert.ToInt32(ddlClasses.SelectedValue.ToString());
            HttpCookie myCookie = Request.Cookies["user"];
            doc.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = doc.update();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Document.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddDocument.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            string fileLocation = "";
            if (FileUpload1.HasFile)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                fileLocation = Server.MapPath("~/StudentAfair/Documents/" + fileName);
                FileUpload1.SaveAs(fileLocation);

            }
            Document doc = new Document();
            doc.Name = txtName.Text;
            HttpCookie myCookie = Request.Cookies["user"];
            doc.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            doc.URL = fileLocation;
            doc.CourseID = Convert.ToInt32(ddlCourses.SelectedValue.ToString());
            doc.ClassID = Convert.ToInt32(ddlClasses.SelectedValue.ToString());
            int id = doc.save();
            if (id > 0)
            {
                Response.Redirect("~/StudentAfair/Document.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddDocument.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Document.aspx");
        }
        protected void FileUpload1_Load(object sender, EventArgs e)
        {

        }
        protected void FileUpload1_PreRender(object sender, EventArgs e)
        {

        }
        protected void linkButton1_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            doc.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
            string filename = doc.URL;
            if (filename != "")
            {
                string path = filename;
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    //Response.WriteFile("~/StudentAfair/Documents/"+file.Name);
                    //Response.Redirect("~/StudentAfair/Documents/" + file.Name);
                    string URL = "StudentAfair/Documents/" + file.Name;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('../" + URL + "','_blank')", true);
                    //Response.End();
                }
                else
                {
                    Response.Write("This file does not exist.");
                }
            }
            //  Response.Redirect(Server.MapPath(downloadUrl));
        }
    }
}