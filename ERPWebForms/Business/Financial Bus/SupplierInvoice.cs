using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Invoice
/// </summary>
public class SupplierInvoice:baseObject 
{
    public struct product
    {
        public int ID;
        public string Name;
        public decimal itemPrice;
        public int prodID;
        public int acctID;
        public int noItems;
        public int acctType;
        public decimal totalPrice;
    }
    decimal _totalAmount;
    int _invoiceGLAcct;

    public int InvoiceGLAcct
    {
        get { return _invoiceGLAcct; }
        set { _invoiceGLAcct = value; }
    }
    int _invoiceLiabGLAcct;
    public int InvoiceLiabGLAcct
    {
        get { return _invoiceLiabGLAcct; }
        set { _invoiceLiabGLAcct = value; }
    }
    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
    }
    decimal _paidAmount;
    public decimal PaidAmount
    {
        get { return _paidAmount; }
        set { _paidAmount = value; }
    }

    public decimal RemainingAmount
    {
        get { return _totalAmount - _paidAmount; }
    }
    int _supplierID;

    public int SupplierID
    {
        get { return _supplierID; }
        set { _supplierID = value; }
    }
    ArrayList _products;

    public ArrayList Products
    {
        get { return _products; }
        set { _products = value; }
    }
    int _invoiceNumber;
    public int InvoiceNumber
    {
        get { return _invoiceNumber; }
        set { _invoiceNumber = value; }
    }
    string _description;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
   
    public SupplierInvoice()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from Fin_SupplierInvoice where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
           
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            int.TryParse(dt.Rows[0]["CashGLAcct"].ToString(), out _invoiceGLAcct);
            int.TryParse(dt.Rows[0]["LiabilityGLAcct"].ToString(), out _invoiceLiabGLAcct);
            _id = id;
            decimal.TryParse(dt.Rows[0]["TotalAmount"].ToString(), out _totalAmount);
            decimal.TryParse(dt.Rows[0]["PaidAmount"].ToString(), out _paidAmount);
            int.TryParse(dt.Rows[0]["SupplierID"].ToString(), out _supplierID);
            _description = dt.Rows[0]["Description"].ToString();
            int.TryParse(dt.Rows[0]["InvoiceNumber"].ToString(), out _invoiceNumber);
            sql = "select * from SupplierInvoiceItems where SuppInvID = " + id.ToString();
            DataTable dtProd = DataAccess.ExecuteSQLQuery(sql);
            if (dtProd != null && dtProd.Rows != null && dtProd.Rows.Count > 0)
            {
                product p;
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    p = new product();
                    int.TryParse(dtProd.Rows[i]["ID"].ToString(),out p.ID);
                    decimal.TryParse(dtProd.Rows[i]["ItemPrice"].ToString(), out p.itemPrice);
                    decimal.TryParse(dtProd.Rows[i]["TotalPrice"].ToString(), out p.totalPrice);
                    int.TryParse(dtProd.Rows[i]["NoItems"].ToString(), out p.noItems);
                    int.TryParse(dtProd.Rows[i]["AcctNo"].ToString(), out p.acctID);
                    int.TryParse(dtProd.Rows[i]["AcctType"].ToString(), out p.acctType);
                    int.TryParse(dtProd.Rows[i]["ProductID"].ToString(), out p.prodID);
                    //int.TryParse(dtProd.Rows[i]["SuppInvID"].ToString(), out p.SuppInvID);
                    _products.Add(p);
                }
            }
            return id;
        }
        return 0;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select Fin_SupplierInvoice.*,Fin_Supplier.Name AS SupplierName from Fin_SupplierInvoice inner join Fin_Supplier on Fin_Supplier.ID = Fin_SupplierInvoice.SupplierID";

        return DataAccess.ExecuteSQLQuery(sql);
    }
    public void addProduct(string Name, decimal itemPrice, int acctID, int noItems, int acctType, decimal totalPrice,int prodID)
    {
        product p = new product();
        p.acctID = acctID;
        p.acctType = acctType;
        p.Name = Name;
        p.itemPrice = itemPrice;
        p.noItems = noItems;
        p.totalPrice = totalPrice;
        p.prodID = prodID;
        if (_products == null)
            _products = new ArrayList();
        _products.Add(p);
    }
    public override int save()
    {
        SqlParameter[] param = new SqlParameter[11];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Amount", _totalAmount, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@SupplierID", _supplierID, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@PaidAmount", _paidAmount, SqlDbType.Decimal, 50);
        param[7] = DataAccess.AddParamter("@InvoiceNumber", _invoiceNumber, SqlDbType.Int, 50);
        param[8] = DataAccess.AddParamter("@CashGLAcct", _invoiceGLAcct, SqlDbType.Int, 50);
        param[9] = DataAccess.AddParamter("@LiabilityGLAcct", _invoiceLiabGLAcct, SqlDbType.Int, 50);
        param[10] = DataAccess.AddParamter("@RemainingAmount", _totalAmount - _paidAmount, SqlDbType.Decimal, 50);
        string sql = "insert into Fin_SupplierInvoice( CreationDate,LastModifiedDate,OperatorID,TotalAmount,PaidAmount,SupplierID,Description,InvoiceNumber,CashGLAcct,LiabilityGLAcct,RemainingAmount) values (@Creationdate,@LastModifiedDate,@OperatorID,@Amount,@PaidAmount,@SupplierID,@Description,@InvoiceNumber,@CashGLAcct,@LiabilityGLAcct,@RemainingAmount)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Fin_SupplierInvoice";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        JournalEntry je = new JournalEntry();
        je.Description = "Journal entry for supplier invoice# " + _invoiceNumber.ToString();
        je.Amount = _totalAmount;
        je.addJERow(_invoiceGLAcct, _paidAmount, 0, "supplier invoice# " + _invoiceNumber.ToString(),_invoiceGLAcct<0?1:0);
        je.addJERow(_invoiceLiabGLAcct, RemainingAmount, 0, "supplier invoice# " + _invoiceNumber.ToString(),_invoiceGLAcct<0?1:0);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            //save products and add the credit leg for the journal entry
            if (_products.Count > 0)
            {
                SqlParameter[] param_prod = new SqlParameter[9];
                for (int i = 0; i < _products.Count; i++)
                {

                    product pro = (product)_products[i];
                    param_prod[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param_prod[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param_prod[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);

                    param_prod[3] = DataAccess.AddParamter("@Price", pro.itemPrice, SqlDbType.Decimal, 50);
                    param_prod[4] = DataAccess.AddParamter("@noItems", pro.noItems, SqlDbType.Int, 50);
                    param_prod[5] = DataAccess.AddParamter("@totalPrice", pro.totalPrice, SqlDbType.Decimal, 50);
                    param_prod[6] = DataAccess.AddParamter("@acctNo", pro.acctID, SqlDbType.Int, 50);
                    param_prod[7] = DataAccess.AddParamter("@SuppInvID", _id, SqlDbType.Int, 50);
                    param_prod[8] = DataAccess.AddParamter("@ProdID",pro.prodID, SqlDbType.Int, 50);
                    sql = "insert into Fin_SupplierInvoiceItems(CreationDate,LastModifiedDate,OperatorID,ItemPrice,NoItems,TotalPrice,AcctNo,SuppInvID,ProductID) values(@Creationdate,@LastModifiedDate,@OperatorID,@Price,@noItems,@totalPrice,@acctNo,@SuppInvID,@ProdID)";
                    DataAccess.ExecuteSQLNonQuery(sql, param_prod);
                    je.addJERow(pro.acctID, 0, pro.totalPrice, "supplier invoice# " + _invoiceNumber,pro.acctID<0?1:0);
                }
            
            
                
            }
            je.save();

            return _id;
        }
        return 0;
    }
    public DataTable getInvItems(int InvID)
    {
        string sql = "select * from Fin_SupplierInvoiceItems  where SuppInvID = " + InvID.ToString();
        return DataAccess.ExecuteSQLQuery(sql);
    }
    public override int update()
    {
        /*
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Amount", _amount, SqlDbType.Decimal, 50);
        param[5] = DataAccess.AddParamter("@CustomerID", _customerID, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@ProductID", _productID, SqlDbType.Int, 50);

        string sql = "update Fin_Invoice set LastModifiedDate = @LastModifiedDate,OperatorID = @OperatorID,Amount = @Amount,CustomerID = @CustomerID,Description = @Description,ProductID = @ProductID where ID = @ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Fin_Invoice";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            SqlParameter[] param2 = new SqlParameter[9];
            if (_invoiceJournalEntry != null && _invoiceJournalEntry.Rows != null && _invoiceJournalEntry.Rows.Count > 0)
            {
                for (int i = 0; i < _invoiceJournalEntry.Rows.Count; i++)
                {
                    param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param[3] = DataAccess.AddParamter("@GLAccountID", _invoiceJournalEntry.Rows[i]["GLAccountID"], SqlDbType.Int, 50);
                    param[4] = DataAccess.AddParamter("@InvoiceID", _id, SqlDbType.Int, 50);
                    param[5] = DataAccess.AddParamter("@TotalAmount", _invoiceJournalEntry.Rows[i]["TotalAmount"], SqlDbType.Decimal, 50);
                    param[6] = DataAccess.AddParamter("@Balance", _invoiceJournalEntry.Rows[i]["Balance"], SqlDbType.Decimal, 50);

                    sql = "insert into Fin_InvoiceJournalEntry(CreationDate,LastModifiedDate,OperatorID,GLAccountID,TotalAmount,InvoiceID,Balance) values(@CreationDate,@LastModifiedDate,@OperatorID,@GLAccountID,@TotalAmount,@InvoiceID,@Balance)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                }
            }
            return _id;
        }*/
        return 0;
    }
   /* public DataTable getProductItem(int SupID, int ProdID, Decimal Amount)
    {
        string sql;
        DataTable productItemsDT,InvoiceItemsDT = null,FinalDT;
        int lastInvoiceID =0 ;
        FinalDT = new DataTable();
        //FinalDT.Columns.Add("ID");
        FinalDT.Columns.Add("GLAccountID");
        FinalDT.Columns.Add("TotalAmount",typeof(Decimal));
        FinalDT.Columns.Add("Description");
        FinalDT.Columns.Add("ProductItemID");
        FinalDT.Columns.Add("PaidAmount",typeof(Decimal));
        FinalDT.Columns.Add("Balance", typeof(Decimal));
        //get the product items
        sql = "select * from Fin_ProductPriceItems where ProductID = " + ProdID.ToString() + " Order by Seq";
        productItemsDT = DataAccess.ExecuteSQLQuery(sql);
        //get the last invoices items
        sql = "select Max(ID)as lastInvoiceID from Fin_SupplierInvoice where SupplierID = " + SupID.ToString() + " and ProductID = " + ProdID.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0 && dt.Rows[0]["lastInvoiceID"] !=DBNull.Value)
        {
            lastInvoiceID = int.Parse(dt.Rows[0]["lastInvoiceID"].ToString()); 
        }
        if (lastInvoiceID != 0) // if there is old invoices
        {
            sql = "select * from Fin_InvoiceJournalEntry where InvoiceID = " + lastInvoiceID.ToString();
            InvoiceItemsDT = DataAccess.ExecuteSQLQuery(sql);
        }
        else //in no old invoice
        {

        }
        //merge the product item with invoices items
        DataRow dr;
        DataRow balanceDr;
        decimal balance = -1;
        
            for (int i = 0; i < productItemsDT.Rows.Count; i++)
            {
                dr = FinalDT.NewRow();
                dr["GLAccountID"] = productItemsDT.Rows[i]["GLAccountID"];
                dr["TotalAmount"] = balance = decimal.Parse(productItemsDT.Rows[i]["Amount"].ToString());
                dr["Description"] = productItemsDT.Rows[i]["Description"];
                if (InvoiceItemsDT != null)
                {
                    balanceDr = InvoiceItemsDT.Select("ProductItemID = " + productItemsDT.Rows[i]["ID"].ToString())[0];

                    decimal.TryParse(balanceDr["Balance"].ToString(), out balance);
                }
                if(balance != -1)
                    dr["Balance"] = balance ;
                dr["ProductItemID"] = productItemsDT.Rows[i]["ID"];
                FinalDT.Rows.Add(dr);
            }
        

        //distribute the amount to the data table
        if (FinalDT != null && FinalDT.Rows != null && FinalDT.Rows.Count > 0)
        {
            decimal tempAmount = Amount;
            for (int i = 0; i < FinalDT.Rows.Count; i++)
            {
                if(tempAmount > decimal.Parse( FinalDT.Rows[i]["Balance"].ToString()))
                {
                    tempAmount -= decimal.Parse( FinalDT.Rows[i]["Balance"].ToString());
                    FinalDT.Rows[i]["PaidAmount"] = FinalDT.Rows[i]["Balance"];
                    FinalDT.Rows[i]["Balance"] = 0;
                    
                }
                else if(tempAmount <= decimal.Parse( FinalDT.Rows[i]["Balance"].ToString()))
                {
                    FinalDT.Rows[i]["PaidAmount"] = tempAmount;
                    FinalDT.Rows[i]["Balance"] = decimal.Parse(FinalDT.Rows[i]["Balance"].ToString()) - tempAmount;
                  
                    tempAmount = 0;
                    break;
                }
            }
        }
        return FinalDT;
    }*/
}