using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class AddInvoice : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn Amountid = table.Columns.Add("TotalAmount", typeof(String));
                DataColumn Seqid = table.Columns.Add("Balance", typeof(String));
                DataColumn Nameid = table.Columns.Add("GLAccountID", typeof(String));
                table.PrimaryKey = new DataColumn[] { colid };
                colid.ReadOnly = true;


                Session["Table"] = table;
            }
            return table;
        }
        public Int32 GetLastKey()
        {
            DataTable table = GetTable();

            Int32 max = 0;
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["ID"]) > max)
                    max = Convert.ToInt32(row["ID"]);
            }
            return max;
        }
        protected void Page_Init(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }

                grid.DataSource = GetTable();
                grid.KeyFieldName = "ID";
                grid.DataBind();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddInvoice, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            } ddlCustomer.Style.Add("class", "chzn-select");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            Invoice inv = new Invoice();
            inv.Amount = decimal.Parse(txtAmount.Text);
            inv.Description = txtDescription.Text;
            inv.InvoiceNumber = txtinvoiceNum.Text;
            inv.CustomerID = int.Parse(ddlCustomer.Value.ToString());
            inv.ProductID = int.Parse(ddlProduct.Value.ToString());
            inv.InvoiceDate = DateTime.Parse(txtDate.Text);
            HttpCookie myCookie = Request.Cookies["user"];
            inv.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            //inv.OperatorID = 1;
            inv.InvoiceGLAcct = int.Parse(ddlGLAcct.Value.ToString());
            inv.InvoiceJournalEntry = new Invoice().getProductItem(int.Parse(ddlCustomer.Value.ToString()), int.Parse(ddlProduct.Value.ToString()), decimal.Parse(txtAmount.Text));
            int id = inv.save();
            Session["Table"] = null;
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/Invoices.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddInvoice.aspx?id=0&&alret=notpass");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["Table"] = null;
            Response.Redirect("~/Finance_Module/Invoices.aspx");
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ID"] = GetLastKey() + 1;
        }
        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            DataTable table = new DataTable();
            table = GetTable();
            DataRow found = table.Rows.Find(e.Keys[0]);
            table.Rows.Remove(found);

            Session["Table"] = table;
            grid.DataSource = table;
            grid.DataBind();
            e.Cancel = true;
        }
        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();

            table = GetTable();

            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["TotalAmount"], e.NewValues["Balance"], e.NewValues["GLAccountID"] });
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
            Session["Table"] = table;

            e.Cancel = true;
            grid.DataSource = table;
            grid.DataBind();
            grid.CancelEdit();

        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcRem();
            //get the products for this customer
            DataTable dt = new Customer().getCustomerItemList(int.Parse(ddlCustomer.Value.ToString()));
            if (dt.Rows.Count > 0)
            {
                ddlProduct.DataSource = dt;
                ddlProduct.ValueField = "ProductID";
                ddlProduct.TextField = "Name";
                ddlProduct.DataBind();
            }
            else
            {
                ddlProduct.SelectedIndex = -1;
                txtAmount.Text = "0";
                txtProductPrice.Text = "0";
                txtRemainingAmount.Text = "0";
            }
        }
        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcRem();
        }
        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
            CalcRem();
        }

        private void CalcRem()
        {
            if (txtAmount.Text != "")
            {
                if (txtRemainingAmount.Text != "")
                {
                    if (decimal.Parse(txtAmount.Text) > decimal.Parse(txtRemainingAmount.Text))
                    {

                        return;
                    }
                }
                if (ddlProduct.SelectedIndex != -1 && ddlCustomer.SelectedIndex != -1)
                {
                    DataTable dt = new Invoice().getProductItem(int.Parse(ddlCustomer.Value.ToString()), int.Parse(ddlProduct.Value.ToString()), decimal.Parse(txtAmount.Text));
                    grid.DataSource = dt;
                    grid.DataBind();
                    txtProductPrice.Text = dt.Compute("Sum(TotalAmount)", "").ToString();
                    txtRemainingAmount.Text = dt.Compute("Sum(Balance)", "").ToString();
                }
            }
        }
        protected void CompareValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DataTable dt = new Invoice().getProductItem(int.Parse(ddlCustomer.Value.ToString()), int.Parse(ddlProduct.Value.ToString()), 0);
            decimal rem = decimal.Parse(dt.Compute("Sum(Balance)", "").ToString());
            if (decimal.Parse(txtAmount.Text) > rem)
                args.IsValid = false;
            else
                args.IsValid = true;
        }
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !new Invoice().checkNoDuplicated(txtinvoiceNum.Text);
        }
    }
}