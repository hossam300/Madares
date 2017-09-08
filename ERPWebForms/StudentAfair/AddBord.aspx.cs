﻿using ERPWebForms.Business.control.Controllers;
using ERPWebForms.Business.control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.StudentAfair
{
    public partial class AddBord : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddParent, Request.Cookies["user"]["Permission"].ToString()))
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
                         board board = new Clsboard().get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                         txtName.Text = board.Name;
                         ddlClass.SelectedValue = board.ClassId.ToString();
                         txtNumberOfStudents.Text = board.StudentNum.ToString();
                         ddlFloor.SelectedValue = board.FloorId.ToString();
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
            board board = new board();
            board.Name = txtName.Text;
            board.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
            board.StudentNum = Convert.ToInt32(txtNumberOfStudents.Text);
            board.FloorId = Convert.ToInt32(ddlFloor.SelectedValue.ToString());
            board.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            board.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new Clsboard().update(Convert.ToInt32(Request.QueryString["id"].ToString()), board);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/BordList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddBord.aspx?id=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "&&alret=notpass");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            board board = new board();
            board.Name = txtName.Text;
            board.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
            board.StudentNum = Convert.ToInt32(txtNumberOfStudents.Text);
            board.FloorId = Convert.ToInt32(ddlFloor.SelectedValue.ToString());
            board.Active = 1;
            HttpCookie myCookie = Request.Cookies["user"];
            board.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int res = new Clsboard().insert( board);
            if (res > 0)
            {
                Response.Redirect("~/StudentAfair/BoardList.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/StudentAfair/AddBord.aspx?id=0&&alret=notpass");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentAfair/BoardList.aspx");
        }
    }
}