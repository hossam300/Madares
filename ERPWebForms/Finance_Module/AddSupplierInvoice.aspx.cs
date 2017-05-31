using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebForms.Finance_Module
{
    public partial class AddSupplierInvoice : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("ProductID", typeof(String));
                DataColumn Amountid = table.Columns.Add("itemprice", typeof(String));
                DataColumn Seqid = table.Columns.Add("Quantity", typeof(String));
                DataColumn Nameid = table.Columns.Add("GLAccountID", typeof(Int32));
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
                if (Request.QueryString["alert"] == "noProducts")
                {
                    Response.Write("<script>alert('من فضلك ادخل منتج واحد على الاقل');</script>");
                }
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                Session["Table"] = null;
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    SupplierInvoice PPI = new SupplierInvoice();
                    DataTable dt = PPI.getInvItems(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    grid.DataSource = dt;
                    grid.KeyFieldName = "ID";
                    grid.DataBind();
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                    DataColumn colid = dt.Columns["ID"];
                    dt.PrimaryKey = new DataColumn[] { colid };
                    colid.ReadOnly = true;


                    Session["Table"] = dt;

                }
                else
                {
                    grid.DataSource = GetTable();
                    grid.KeyFieldName = "ID";
                    grid.DataBind();

                }
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
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddSupplierInvoice, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            DataTable dt;
            if (!IsPostBack)
            {

                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    SupplierInvoice s = new SupplierInvoice();
                    s.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    txtDescription.Text = s.Description;
                    txtInvoiceNumber.Text = s.InvoiceNumber.ToString();
                    txtPaidAmount.Text = s.PaidAmount.ToString();
                    txtRemaining.Text = s.RemainingAmount.ToString();
                    txtTotalAmount.Text = s.TotalAmount.ToString();
                    ddlCashGlAccount.Value = s.InvoiceGLAcct.ToString();
                    ddlliabilityGlAccount.Value = s.InvoiceLiabGLAcct.ToString();
                    ddlSupplier.Value = s.SupplierID.ToString();
                    dt = s.getInvItems(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    grid.DataSource = dt;
                    Session["Table"] = dt;
                    grid.DataBind();

                }
            }
            dt = GetTable();
            grid.DataSource = dt;
            grid.DataBind();
        }
        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            DataTable table = new DataTable();
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                ProductPriceItems PPI = new ProductPriceItems();
                table = PPI.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                DataColumn colid = table.Columns[0];
                table.PrimaryKey = new DataColumn[] { colid };
            }
            else
            {
                table = GetTable();
            }

            DataRow found = table.Rows.Find(e.Keys[0]);
            table.Rows.Remove(found);

            Session["Table"] = table;
            grid.DataSource = table;
            grid.DataBind();
            e.Cancel = true;
        }
        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                ProductPriceItems PPI = new ProductPriceItems();
                table = PPI.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                DataColumn colid = table.Columns[0];
                table.PrimaryKey = new DataColumn[] { colid };
            }
            else
            {
                table = GetTable();
            }
            DataRow found = table.Rows.Find(e.Keys[0]);
            found["ProductID"] = e.NewValues["ProductID"];
            found["itemprice"] = e.NewValues["itemprice"];
            found["ProductID"] = e.NewValues["ProductID"];
            found["Quantity"] = e.NewValues["Quantity"];
            found["GLAccountID"] = e.NewValues["GLAccountID"];

            Session["Table"] = table;
            grid.DataSource = table;
            grid.DataBind();
            e.Cancel = true;
            grid.CancelEdit();
        }
        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            DataTable table = new DataTable();

            table = GetTable();

            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["ProductID"], e.NewValues["itemprice"], e.NewValues["Quantity"], e.NewValues["GLAccountID"] });
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
            Session["Table"] = table;

            e.Cancel = true;
            Session["Table"] = table;
            grid.DataSource = table;
            grid.DataBind();
            grid.CancelEdit();
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ID"] = GetLastKey() + 1;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            SupplierInvoice supInv = new SupplierInvoice();
            supInv.SupplierID = int.Parse(ddlSupplier.Value.ToString());
            supInv.InvoiceNumber = int.Parse(txtInvoiceNumber.Text);
            supInv.InvoiceGLAcct = int.Parse(ddlCashGlAccount.Value.ToString());
            supInv.InvoiceLiabGLAcct = int.Parse(ddlliabilityGlAccount.Value.ToString());
            supInv.Description = txtDescription.Text;
            //decimal.TryParse(txtPaidAmount.Text, out supInv.PaidAmount);
            supInv.PaidAmount = decimal.Parse(txtPaidAmount.Text);
            //supInv.RemainingAmount = decimal.Parse(txtRemaining.Text);
            supInv.TotalAmount = decimal.Parse(txtTotalAmount.Text);
            HttpCookie myCookie = Request.Cookies["user"];
            supInv.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            DataTable table = (DataTable)Session["Table"];
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    supInv.addProduct("", decimal.Parse(table.Rows[i]["itemprice"].ToString()), int.Parse(table.Rows[i]["GLAccountID"].ToString()), int.Parse(table.Rows[i]["Quantity"].ToString()), int.Parse(table.Rows[i]["GLAccountID"].ToString()) < 0 ? 1 : 0, int.Parse(table.Rows[i]["Quantity"].ToString()) * decimal.Parse(table.Rows[i]["itemprice"].ToString()), int.Parse(table.Rows[i]["ProductID"].ToString()));
                }
                int id = supInv.save();
                if (id > 0)
                {
                    Response.Redirect("~/Finance_Module/SupplierInvoices.aspx?alert=success");
                }
                else
                {
                    Response.Redirect("~/Finance_Module/AddSupplierInvoice.aspx?id=0&&alret=notpass");
                }

            }
            else
            {
                Response.Redirect("~/Finance_Module/AddSupplierInvoice.aspx?alert=noProducts&&id=0");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/SupplierInvoices.aspx");
        }
        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalAmount.Text != "" && txtPaidAmount.Text != "")
            {
                txtRemaining.Text = Convert.ToString(decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtPaidAmount.Text)).ToString();
            }
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ResourceManager rm;
            if (Session["lang"] == "ar-EG")
            {
                rm = new ResourceManager("AddSupplierInvoice.ar-EG", System.Reflection.Assembly.GetExecutingAssembly());
            }
            else
            {
                rm = new ResourceManager("AddSupplierInvoice", System.Reflection.Assembly.GetExecutingAssembly());
            }
            GLAccount acc = new GLAccount();
            acc.get(int.Parse(ddlCashGlAccount.Value.ToString()));
            if (acc.AcctType == 1 || acc.AcctType == 5)//depit acount (asset and expenses)
            {
                if (txtPaidAmount.Text != null && txtPaidAmount.Text != "")
                {
                    if (acc.Balance < decimal.Parse(txtPaidAmount.Text))
                    {
                        CustomValidator1.ErrorMessage = string.Format(GetLocalResourceObject("BalanceNotEnough2").ToString(), acc.Balance);
                        args.IsValid = false;
                    }
                    else
                        args.IsValid = true;
                }
            }

        }
    }
}