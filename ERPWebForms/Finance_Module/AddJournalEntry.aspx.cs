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
    public partial class AddJournalEntry : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("GLAccountID", typeof(String));
                DataColumn Amountid = table.Columns.Add("Depit", typeof(String));
                DataColumn Seqid = table.Columns.Add("Credit", typeof(String));
                DataColumn Nameid = table.Columns.Add("Memo", typeof(String));
                DataColumn acctType = table.Columns.Add("acctType", typeof(String));
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
                //amountNotValid
                if (Request.QueryString["alert"] == "amountNotValid")
                {
                    Response.Write("<script>alert('مبلغ المدين لايساوى مبلغ الدائن');</script>");
                }
                if (Request.QueryString["alert"] == "notpass")
                {
                    Response.Write("<script>alert('لم يتم الحفظ');</script>");
                }
                Session["Table"] = null;
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    ProductPriceItems PPI = new ProductPriceItems();
                    DataTable dt = PPI.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
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
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddJournalEntry, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            txtTranDate.Text = DateTime.Now.ToShortDateString();
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["ID"].ToString()) > 0)
                {
                    JournalEntry je = new JournalEntry();
                    je.get(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                    txtDesc.Text = je.Description.ToString();

                    txtTranAmount.Text = je.Amount.ToString();
                    txtTranDate.Text = je.CreationDate.ToString();

                    grid.DataSource = je.JournalEntryRows;
                    grid.DataBind();
                }
            }

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
            ///Check the account balance
            GLAccount acc = new GLAccount();
            acc.get(int.Parse(e.NewValues["GLAccountID"].ToString()));
            if (acc.AcctType == 1 || acc.AcctType == 5)//depit acount (asset and expenses)
            {
                if (e.NewValues["Credit"] != null && e.NewValues["Credit"].ToString() != "")
                {
                    if (acc.Balance < decimal.Parse(e.NewValues["Credit"].ToString()))
                        throw new Exception("Account Balance(" + acc.Balance.ToString() + ") not enough");
                }
            }
            else
            {
                if (e.NewValues["Depit"] != null && e.NewValues["Depit"].ToString() != "")
                {
                    if (acc.Balance < decimal.Parse(e.NewValues["Depit"].ToString()))
                        throw new Exception("Account Balance(" + acc.Balance.ToString() + ") not enough");
                }
            }
            /////////////////////////////
            DataRow found = table.Rows.Find(e.Keys[0]);
            found["GLAccountID"] = e.NewValues["GLAccountID"];
            found["Depit"] = e.NewValues["Depit"];
            found["Credit"] = e.NewValues["Credit"];
            found["Memo"] = e.NewValues["Memo"];
            found["acctType"] = int.Parse(e.NewValues["GLAccountID"].ToString()) < 0 ? 1 : 0;
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


            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());

            ///Check the account balance
            GLAccount acc = new GLAccount();
            acc.get(int.Parse(e.NewValues["GLAccountID"].ToString()));
            if (acc.AcctType == 1 || acc.AcctType == 5)//depit acount (asset and expenses)
            {
                if (e.NewValues["Credit"] != null && e.NewValues["Credit"].ToString() != "")
                {
                    if (acc.Balance < decimal.Parse(e.NewValues["Credit"].ToString()))
                        throw new Exception("Account Balance(" + acc.Balance.ToString() + ") not enough");
                }
            }
            else
            {
                if (e.NewValues["Depit"] != null && e.NewValues["Depit"].ToString() != "")
                {
                    if (acc.Balance < decimal.Parse(e.NewValues["Depit"].ToString()))
                        throw new Exception("Account Balance(" + acc.Balance.ToString() + ") not enough");
                }
            }

            /////////////////////////////
            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["GLAccountID"], e.NewValues["Depit"], e.NewValues["Credit"], e.NewValues["Memo"], int.Parse(e.NewValues["GLAccountID"].ToString()) < 0 ? 1 : 0 });
            Session["Table"] = table;

            e.Cancel = true;
            grid.DataSource = table;
            grid.DataBind();
            grid.CancelEdit();
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ID"] = GetLastKey() + 1;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValid) return;
            JournalEntry je = new JournalEntry();
            je.Description = txtDesc.Text;
            je.Amount = Convert.ToDecimal(txtTranAmount.Text);
            je.JournalEntryRows = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            je.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = je.save();
            Session["Table"] = null;
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/JournalEntries.aspx?alert=success");
            }
            else
            {
                if (id == -1)
                {
                    Response.Redirect("~/Finance_Module/AddJournalEntry.aspx?id=0&&alret=amountNotValid");
                }
                else
                {
                    Response.Redirect("~/Finance_Module/AddJournalEntry.aspx?id=0&&alret=notpass");
                }
            }
            //to do when view page created
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            JournalEntry je = new JournalEntry();
            je.Description = txtDesc.Text;
            je.Amount = Convert.ToDecimal(txtTranAmount.Text);
            je.JournalEntryRows = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            je.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = je.update();
            Session["Table"] = null;
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/JournalEntries.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddJournalEntry.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Finance_Module/JournalEntries.aspx");
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Session["Table"] != null)
            {
                DataTable dt = Session["Table"] as DataTable;
                decimal crAmt = 0, dpAmt = 0;
                if (dt.Rows != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Credit"].ToString() != "" && dt.Rows[i]["Credit"] != null)
                        {

                            crAmt += decimal.Parse(dt.Rows[i]["Credit"].ToString());


                        }
                        if (dt.Rows[i]["Depit"].ToString() != "" && dt.Rows[i]["Depit"] != null)
                        {
                            dpAmt += decimal.Parse(dt.Rows[i]["Depit"].ToString());
                        }
                    }
                    if (dpAmt == crAmt && crAmt == decimal.Parse(txtTranAmount.Text))
                        args.IsValid = true;
                    else
                        args.IsValid = false;
                }
            }
        }
    }
}