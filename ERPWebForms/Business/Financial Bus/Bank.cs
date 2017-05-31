using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Bank
/// </summary>
public class Bank:baseObject
{
    string _bankName;

    public string BankName
    {
        get { return _bankName; }
        set { _bankName = value; }
    }
    string _description;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    string _accountName;

    public string AccountName
    {
        get { return _accountName; }
        set { _accountName = value; }
    }

    string _accountNumber;

    public string AccountNumber
    {
        get { return _accountNumber; }
        set { _accountNumber = value; }
    }
    decimal _initialBalance;

    public decimal InitialBalance
    {
        get { return _initialBalance; }
        set { _initialBalance = value; }
    }
    decimal _currentBalance;

    public decimal CurrentBalance
    {
        get { return _currentBalance; }
        set { _currentBalance = value; }
    }
    DateTime _acctStartDate;

    public DateTime AcctStartDate
    {
        get { return _acctStartDate; }
        set { _acctStartDate = value; }
    }

	public Bank()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from Fin_Bank where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            _bankName = dt.Rows[0]["BankName"].ToString();
            _description = dt.Rows[0]["Description"].ToString();
            _accountNumber = dt.Rows[0]["AccountNumber"].ToString();
            DateTime.TryParse(dt.Rows[0]["acctCreationDate"].ToString(),out  _acctStartDate);
            Decimal.TryParse(dt.Rows[0]["startingBalance"].ToString(),out _initialBalance);
            Decimal.TryParse(dt.Rows[0]["CurrentBalance"].ToString(), out _currentBalance);
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from Fin_Bank ";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@BankName", _bankName, SqlDbType.NVarChar,   250);
        param[5] = DataAccess.AddParamter("@CurrentBalance", _currentBalance, SqlDbType.Decimal, 50);
        param[6] = DataAccess.AddParamter("@AccountNumber", _accountNumber, SqlDbType.NVarChar, 250);
        param[7] = DataAccess.AddParamter("@acctCreationDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[8] = DataAccess.AddParamter("@startingBalance", _initialBalance, SqlDbType.Decimal, 50);

        string sql = "insert into Fin_Bank(CreationDate,LastModifiedDate,OperatorID,BankName,Description,CurrentBalance,AccountNumber,acctCreationDate,startingBalance) values (@CreationDate,@LastModifiedDate,@OperatorID,@BankName,@Description,@CurrentBalance,@AccountNumber,@acctCreationDate,@startingBalance)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id

        sql = "select max(id)as lastID from Fin_Bank";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());

            return _id;
        }
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@BankName", _bankName, SqlDbType.NVarChar, 250);
        param[5] = DataAccess.AddParamter("@CurrentBalance", _currentBalance, SqlDbType.Decimal, 50);
        param[6] = DataAccess.AddParamter("@AccountNumber", _accountNumber, SqlDbType.NVarChar, 150);
       // param[7] = DataAccess.AddParamter("@acctCreationDate", _acctStartDate, SqlDbType.DateTime, 50);
        param[7] = DataAccess.AddParamter("@startingBalance", _initialBalance, SqlDbType.Decimal, 50);

        string sql = "update Fin_Bank set LastModifiedDate =@LastModifiedDate ,OperatorID = @OperatorID ,BankName =@BankName ,Description = @Description,CurrentBalance = @CurrentBalance,AccountNumber = @AccountNumber,startingBalance =@startingBalance  where ID = @ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        
            return _id;
        
    }

    internal void decreaseAcctBalanc(decimal dpAmt, int acctID)
    {
        string sql = "update Fin_Bank set CurrentBalance = CurrentBalance - " + dpAmt.ToString() + " where ID = " + (acctID*-1).ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
    }

    internal void increaseAcctBalanc(decimal crAmt, int acctID)
    {
        string sql = "update Fin_Bank set CurrentBalance = CurrentBalance + " + crAmt.ToString() + " where ID = " + (acctID*-1).ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
    }
}