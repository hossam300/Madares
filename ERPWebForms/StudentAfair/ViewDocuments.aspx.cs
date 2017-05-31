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
    public partial class ViewDocuments : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.ViewDocuments, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/StudentAfair/UnAuthorized.aspx");
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
                        Document doc = new Document();
                        doc.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                        txtName.Text = doc.Name;
                        //FileUpload1.ResolveUrl(doc.URL);
                        Course course = new Course();
                        course.get(doc.CourseID);
                        ddlcourses.Text = course.Name;
                        StdClass stdclass= new StdClass();
                        stdclass.get(doc.ClassID);
                        ddlClasse.Text = stdclass.Name;
                        btnEdit.Visible = true;
                        linkButton1.Visible = true;
                        //   downloadUrl = doc.URL;

                    }
                    else
                    {
                        linkButton1.Visible = false;

                        btnEdit.Visible = false;
                    }
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/StudentAfair/AddDocuments.aspx?id=" + id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/Document.aspx");
        }
        protected void linkButton1_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            doc.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
            string filename = doc.URL;
            string[] tokens = filename.Split('\\');
            string i = tokens[9] + "\\" + tokens[10];
            if (filename != "")
            {
                //string path = filename;
                //System.IO.FileInfo file = new System.IO.FileInfo(path);
                //if (file.Exists)
                //{
                //    Response.Clear();
                //    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                //    Response.AddHeader("Content-Length", file.Length.ToString());
                //    Response.ContentType = "application/octet-stream";
                //    //Response.WriteFile("~/StudentAfair/Documents/"+file.Name);
                //    //Response.Redirect("~/StudentAfair/Documents/" + file.Name);
                //    string URL = "StudentAfair/Documents/" + file.Name;
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('../" + URL + "','_blank')", true);
                //    //Response.End();
                //}
                //else
                //{
                //    Response.Write("This file does not exist.");
                //}
                Response.Redirect("~/StudentAfair/" + i);
            }
        }
    }
}