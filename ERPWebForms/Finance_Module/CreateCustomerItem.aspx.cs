using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ERPWebForms.Finance_Module
{
    public partial class CreateCustomerItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            new Customer().addCustomerItem(Convert.ToInt32(ddlProduct.Value.ToString()), Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(ddlCustomer.Value.ToString()));
            HtmlForm form = Page.FindControl("form1") as HtmlForm;
            if (form != null)
            {
                form.Controls.Clear();
                WebControl textControl = CreateCentredText();
                textControl.ForeColor = Color.FromArgb(0, 51, 51);
                if (textControl != null)
                    form.Controls.Add(textControl);

            }


        }
        protected virtual WebControl CreateCentredText()
        {
            Table table = new Table();
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            table.Rows.Add(row);
            row.Cells.Add(cell);
            ASPxLabel lblSuccess = new ASPxLabel();
            lblSuccess.ID = "lblSuccess";

            lblSuccess.Text = "Record Saved Successfuly .";
            cell.Controls.Add(lblSuccess);

            cell.Controls.Add(new LiteralControl("&nbsp;"));
            cell.Controls.Add(new LiteralControl("<br/>"));
            ASPxButton buttonSendNewMsg = new ASPxButton();
            buttonSendNewMsg.ID = "ButtonSendNewMsg";
            buttonSendNewMsg.RenderMode = ButtonRenderMode.Link;
            buttonSendNewMsg.Text = "New Customer Item";

            cell.Controls.Add(buttonSendNewMsg);

            table.Height = Unit.Percentage(100);
            table.Width = Unit.Percentage(100);
            table.BorderWidth = Unit.Pixel(0);

            cell.VerticalAlign = VerticalAlign.Middle;
            cell.HorizontalAlign = HorizontalAlign.Center;

            return table;
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedIndex != 0)
            {
                DataTable dt = new Invoice().getProductItem(int.Parse(ddlCustomer.Value.ToString()), int.Parse(ddlProduct.Value.ToString()), 0);
                // grid.DataSource = dt;
                //grid.DataBind();
                txtPrice.Text = dt.Compute("Sum(TotalAmount)", "").ToString();
                //txtPrice.Text = dt.Compute("Sum(Balance)", "").ToString();
            }
        }
    }
}