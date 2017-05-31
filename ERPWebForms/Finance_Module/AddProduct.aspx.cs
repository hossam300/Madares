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
    public partial class AddProduct : BasePage
    {
        DataTable GetTable()
        {
            //You can store a DataTable in the session state
            DataTable table = Session["Table"] as DataTable;
            if (table == null)
            {
                table = new DataTable();

                DataColumn colid = table.Columns.Add("ID", typeof(Int32));
                DataColumn Descriptionid = table.Columns.Add("Description", typeof(String));
                DataColumn Amountid = table.Columns.Add("Amount", typeof(Decimal));
                DataColumn Seqid = table.Columns.Add("Seq", typeof(Int32));
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
                if (!new UserSecurity().CheckFormPermission((int)Global.formSecurity.AddProduct, Request.Cookies["user"]["Permission"].ToString()))
                    Response.Redirect("~/Finance_Module/UnAuthorized.aspx");
            }
            DataTable dt;
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
                {
                    Product product = new Product();
                    product.get(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    txtProductName.Text = product.Name;
                    txtCost.Text = product.Cost.ToString();
                    txtPrice.Text = product.Price.ToString();
                    ddlType.SelectedValue = product.TypeID.ToString();
                    dt = product.ProductPriceItems;
                    //grid.DataSource = dt;
                    //Session["Table"] = dt;
                    //grid.DataBind();

                }
            }
            //  dt = GetTable();
            // grid.DataSource = dt;
            // grid.DataBind();
        }
        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            DataTable table = new DataTable();
            if (Convert.ToInt32(Request.QueryString["id"].ToString()) > 0)
            {
                ProductPriceItems PPI = new ProductPriceItems();
                table = PPI.getByProductID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                if (table.Rows.Count > 0)
                {
                    if (Session["Table"]==null)
                    {
                        DataColumn colid = table.Columns[0];
                        table.PrimaryKey = new DataColumn[] { colid };    
                    }
                    else
                        table = GetTable();
                }
                else
                    table = GetTable();
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
                if (table.Rows.Count>0)
                {
                    if (Session["Table"] == null)
                    {
                        DataColumn colid = table.Columns[0];
                        table.PrimaryKey = new DataColumn[] { colid };
                    }
                    else
                        table = GetTable();
                }
              else
                    table = GetTable();
            }
            else
            {
                table = GetTable();
            }
            DataRow found = table.Rows.Find(e.Keys[0]);
            found["Description"] = e.NewValues["Description"];
            found["Amount"] = e.NewValues["Amount"];
            found["Seq"] = e.NewValues["Seq"];
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

            table.Rows.Add(new Object[] { e.NewValues["ID"], e.NewValues["Description"], e.NewValues["Amount"], e.NewValues["Seq"], e.NewValues["GLAccountID"] });
            // sumAmount +=Convert.ToDouble(e.NewValues["Amount"].ToString());
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
            if (!Page.IsValid) return;
            Product product = new Product();
            product.Name = txtProductName.Text;
            product.OperatorID = 1;
            product.Price = Convert.ToDecimal(txtPrice.Text);
            product.Cost = Convert.ToDecimal(txtCost.Text);
            product.TypeID = Convert.ToInt32(ddlType.SelectedValue);
            product.ProductPriceItems = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            product.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = product.save();

            Session["Table"] = null;
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/Products.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddProduct.aspx?id=0&&alret=notpass");
            }

        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            Product product = new Product();
            product.Name = txtProductName.Text;
            product.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            product.OperatorID = 1;
            product.Price = Convert.ToDecimal(txtPrice.Text);
            product.Cost = Convert.ToDecimal(txtCost.Text);
            product.TypeID = Convert.ToInt32(ddlType.SelectedValue);
            product.ProductPriceItems = Session["Table"] as DataTable;
            HttpCookie myCookie = Request.Cookies["user"];
            product.OperatorID = Convert.ToInt32(myCookie.Values["userid"].ToString());
            int id = product.update();
            Session["Table"] = null;
            if (id > 0)
            {
                Response.Redirect("~/Finance_Module/Products.aspx?alert=success");
            }
            else
            {
                Response.Redirect("~/Finance_Module/AddProduct.aspx?id=0&&alret=notpass");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["Table"] = null;
            Response.Redirect("~/Finance_Module/Products.aspx");

        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DataTable dt = Session["Table"] as DataTable;
            decimal price = decimal.Parse(dt.Compute("sum(Amount)", "").ToString());
            if (txtPrice.Text != null && txtPrice.Text != "")
            {
                if (decimal.Parse(txtPrice.Text) != price)
                    args.IsValid = false;
                else
                    args.IsValid = true;
            }

        }
    }
}