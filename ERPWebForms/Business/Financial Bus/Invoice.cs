using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Invoice
/// </summary>
public class Invoice:baseObject 
{
    decimal _amount;
    int _invoiceGLAcct;

    public int InvoiceGLAcct
    {
        get { return _invoiceGLAcct; }
        set { _invoiceGLAcct = value; }
    }
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    int _customerID;

    public int CustomerID
    {
        get { return _customerID; }
        set { _customerID = value; }
    }
    int _productID;

    public int ProductID
    {
        get { return _productID; }
        set { _productID = value; }
    }
    string _invoiceNumber;
    public string InvoiceNumber
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
    public DateTime InvoiceDate { get; set; }
    DataTable _invoiceJournalEntry;


    public DataTable InvoiceJournalEntry
    {
        get { return _invoiceJournalEntry; }
        set { _invoiceJournalEntry = value; }
    }
    
    public Invoice()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from Fin_Invoice where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
           
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            decimal.TryParse(dt.Rows[0]["Amount"].ToString(), out _amount);
            int.TryParse(dt.Rows[0]["CustomerID"].ToString(), out _customerID);
            int.TryParse(dt.Rows[0]["ProductID"].ToString(), out _productID);
            _description = dt.Rows[0]["Description"].ToString();
            _invoiceNumber = dt.Rows[0]["InvoiceNumber"].ToString();
            DateTime _date;
            DateTime.TryParse(dt.Rows[0]["InvoiceDate"].ToString(), out _date);
            InvoiceDate = _date;
            sql = "select * from Fin_InvoiceJournalEntry where InvoiceID = " + id.ToString();
            _invoiceJournalEntry = DataAccess.ExecuteSQLQuery(sql);
            return 1;
        }
        return 0;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "SELECT sum(Fin_InvoiceJournalEntry.Balance) as Balance ,Fin_Invoice.ID, Fin_Invoice.InvoiceDate,Fin_Customer.Name AS CustomerName, Fin_Product.Name AS ProductName, Fin_Invoice.Amount, Fin_Invoice.Description, Fin_Invoice.InvoiceNumber FROM Fin_Invoice INNER JOIN Fin_Customer ON Fin_Invoice.CustomerID = Fin_Customer.ID INNER JOIN Fin_Product ON Fin_Invoice.ProductID = Fin_Product.ID Inner join Fin_InvoiceJournalEntry on Fin_InvoiceJournalEntry.InvoiceID =Fin_Invoice.ID group by  Fin_Invoice.ID, Fin_Customer.Name , Fin_Product.Name , Fin_Invoice.Amount, Fin_Invoice.Description, Fin_Invoice.InvoiceNumber,Fin_Invoice.InvoiceDate";

        return DataAccess.ExecuteSQLQuery(sql);
    }
    public void reverse(int invoiceID)
    {
        get(invoiceID);
        //SqlParameter[] param = new SqlParameter[9];
        //param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        //param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        //param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        //param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        //param[4] = DataAccess.AddParamter("@Amount", _amount, SqlDbType.Int, 50);
        //param[5] = DataAccess.AddParamter("@CustomerID", _customerID, SqlDbType.Int, 50);
        //param[6] = DataAccess.AddParamter("@ProductID", _productID, SqlDbType.Int, 50);
        //param[7] = DataAccess.AddParamter("@InvoiceNumber", _invoiceNumber, SqlDbType.Int, 50);
        //param[8] = DataAccess.AddParamter("@InvoiceGLAcct", _invoiceGLAcct, SqlDbType.Int, 50);
        //string sql = "insert into Fin_Invoice(CreationDate,LastModifiedDate,OperatorID,Amount,CustomerID,Description,ProductID,InvoiceNumber,InvoiceGLAcct,reverseed) values (@Creationdate,@LastModifiedDate,@OperatorID,@Amount,@CustomerID,@Description,@ProductID,@InvoiceNumber,@InvoiceGLAcct,0)";
        //DataAccess.ExecuteSQLNonQuery(sql, param);
        ////get last id
        //sql = "select max(id)as lastID from Fin_Invoice";
        //DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        JournalEntry je = new JournalEntry();
        je.Description = "Journal entry for invoice# " + _invoiceNumber.ToString();
        je.Amount = _amount;
        je.addJERow(_invoiceGLAcct, _amount, 0, "invoice# " + _invoiceNumber.ToString(), _invoiceGLAcct < 0 ? 0 :1);
       
            _id = invoiceID;
            SqlParameter[] param2 = new SqlParameter[8];
            if (_invoiceJournalEntry != null && _invoiceJournalEntry.Rows != null && _invoiceJournalEntry.Rows.Count > 0)
            {
                for (int i = 0; i < _invoiceJournalEntry.Rows.Count; i++)
                {
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@GLAccountID", _invoiceJournalEntry.Rows[i]["GLAccountID"], SqlDbType.Int, 50);
                    param2[4] = DataAccess.AddParamter("@InvoiceID", _id, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@TotalAmount",Convert.ToDecimal(_invoiceJournalEntry.Rows[i]["TotalAmount"])*-1, SqlDbType.Decimal, 50);

                    param2[6] = DataAccess.AddParamter("@Balance",Convert.ToDecimal( _invoiceJournalEntry.Rows[i]["Balance"])*-1, SqlDbType.Decimal, 50);
                    param2[7] = DataAccess.AddParamter("@ProductItemID", _invoiceJournalEntry.Rows[i]["ProductItemID"], SqlDbType.Int, 50);
                    string sql = "insert into Fin_InvoiceJournalEntry(CreationDate,LastModifiedDate,OperatorID,GLAccountID,TotalAmount,InvoiceID,Balance,ProductItemID) values(@CreationDate,@LastModifiedDate,@OperatorID,@GLAccountID,@TotalAmount,@InvoiceID,@Balance,@ProductItemID)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                    //update the accounts balance 
                    //create the journal entry for the invoice
                    if (_invoiceJournalEntry.Rows[i]["PaidAmount"].ToString() != string.Empty && Convert.ToDecimal(_invoiceJournalEntry.Rows[i]["PaidAmount"].ToString()) > 0)
                    {
                        je.addJERow(Convert.ToInt32(_invoiceJournalEntry.Rows[i]["GLAccountID"].ToString()), 0,Convert.ToDecimal(_invoiceJournalEntry.Rows[i]["PaidAmount"].ToString()), "Invoice# " + _invoiceNumber.ToString(), Convert.ToInt32(_invoiceJournalEntry.Rows[i]["GLAccountID"].ToString()) < 0 ? 0 : 1);
                    }
                    sql = "Update Fin_Invoice set reverseed=1 Where ID=" + invoiceID.ToString();
                    DataAccess.ExecuteSQLNonQuery(sql);
                }
                je.save();
              
            }

            new Customer().updateCustomerItemBalance(_customerID, _productID, _amount*-1);
            
       



    }
    public override int save()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Amount", _amount, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@CustomerID", _customerID, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@ProductID", _productID, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@InvoiceNumber", _invoiceNumber, SqlDbType.NVarChar, 50);
        param[8] = DataAccess.AddParamter("@InvoiceGLAcct", _invoiceGLAcct, SqlDbType.Int, 50);
        param[9] = DataAccess.AddParamter("@InvoiceDate", InvoiceDate, SqlDbType.Date, 50);
        string sql = "insert into Fin_Invoice(CreationDate,LastModifiedDate,OperatorID,Amount,CustomerID,Description,ProductID,InvoiceNumber,InvoiceGLAcct,reverseed,InvoiceDate) values (@Creationdate,@LastModifiedDate,@OperatorID,@Amount,@CustomerID,@Description,@ProductID,@InvoiceNumber,@InvoiceGLAcct,0,@InvoiceDate)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Fin_Invoice";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        JournalEntry je = new JournalEntry();
        Customer c = new Customer();
        c.get(_customerID);
        je.Description = "Journal entry for invoice# " + _invoiceNumber.ToString() + " " + c.Name;
        je.Amount = _amount;
        je.addJERow(_invoiceGLAcct, 0, _amount, "invoice# " + _invoiceNumber.ToString(),_invoiceGLAcct<0?1:0);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["lastID"] != DBNull.Value)
                _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            else
                _id = 1;
            SqlParameter[] param2 = new SqlParameter[8];
            if (_invoiceJournalEntry != null && _invoiceJournalEntry.Rows != null && _invoiceJournalEntry.Rows.Count > 0)
            {
                for (int i = 0; i < _invoiceJournalEntry.Rows.Count; i++)
                {
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", InvoiceDate, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate",InvoiceDate, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@GLAccountID", _invoiceJournalEntry.Rows[i]["GLAccountID"], SqlDbType.Int, 50);
                    param2[4] = DataAccess.AddParamter("@InvoiceID", _id, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@TotalAmount", _invoiceJournalEntry.Rows[i]["TotalAmount"], SqlDbType.Decimal, 50);
                    
                    param2[6] = DataAccess.AddParamter("@Balance", _invoiceJournalEntry.Rows[i]["Balance"], SqlDbType.Decimal, 50);
                    param2[7] = DataAccess.AddParamter("@ProductItemID", _invoiceJournalEntry.Rows[i]["ProductItemID"], SqlDbType.Int, 50);
                    sql = "insert into Fin_InvoiceJournalEntry(CreationDate,LastModifiedDate,OperatorID,GLAccountID,TotalAmount,InvoiceID,Balance,ProductItemID) values(@CreationDate,@LastModifiedDate,@OperatorID,@GLAccountID,@TotalAmount,@InvoiceID,@Balance,@ProductItemID)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                    //update the accounts balance 
                    //create the journal entry for the invoice
                    if (_invoiceJournalEntry.Rows[i]["PaidAmount"].ToString() != string.Empty && Convert.ToDecimal(_invoiceJournalEntry.Rows[i]["PaidAmount"].ToString()) > 0)
                    {
                        je.addJERow(Convert.ToInt32(_invoiceJournalEntry.Rows[i]["GLAccountID"].ToString()), Convert.ToDecimal(_invoiceJournalEntry.Rows[i]["PaidAmount"].ToString()), 0, "Invoice# " + _invoiceNumber.ToString(), Convert.ToInt32(_invoiceJournalEntry.Rows[i]["GLAccountID"].ToString())<0?1:0);
                    }
                }
                je.save(InvoiceDate);
            }

            new Customer().updateCustomerItemBalance(_customerID, _productID, _amount);
            return _id;
        }
        return 0;
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
    public DataTable getProductItem(int CustID, int ProdID, Decimal Amount)
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
        sql = "select Max(ID)as lastInvoiceID from Fin_Invoice where CustomerID = " + CustID.ToString() + " and ProductID = " + ProdID.ToString();
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
        else //if no old invoice
        {

        }
        //merge the product item with invoices items
        DataRow dr;
        DataRow balanceDr;
        DataRow[] drs;
        decimal balance = -1;
        
            for (int i = 0; i < productItemsDT.Rows.Count; i++)
            {
                dr = FinalDT.NewRow();
                dr["GLAccountID"] = productItemsDT.Rows[i]["GLAccountID"];
                dr["TotalAmount"] = balance = decimal.Parse(productItemsDT.Rows[i]["Amount"].ToString());
                dr["Description"] = productItemsDT.Rows[i]["Description"];
                if (InvoiceItemsDT != null)
                {
                    drs = InvoiceItemsDT.Select("ProductItemID = " + productItemsDT.Rows[i]["ID"].ToString());
                    if (drs != null && drs.Length > 0)
                    {
                        balanceDr = drs[0];

                        decimal.TryParse(balanceDr["Balance"].ToString(), out balance);
                    }
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
    }

    public bool checkNoDuplicated(string txtInvoiceNo)
    {
        string sql = "select * from Fin_Invoice where InvoiceNumber = " + txtInvoiceNo;
        DataTable dt= DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            return true;
        else
            return false;
    }
}