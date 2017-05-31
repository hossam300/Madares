using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccount
/// </summary>
public class GLAccount : baseObject
{

    string _name;
    string _description;
    int _acctType;

    public int AcctType
    {
        get { return _acctType; }
        set { _acctType = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    decimal _balance;

    public decimal Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }
    int _parentAcctID;

    public int ParentAcctID
    {
        get { return _parentAcctID; }
        set { _parentAcctID = value; }
    }
    int _status;

    public int Status
    {
        get { return _status; }
        set { _status = value; }
    }
    int _acctCode;

    public int AcctCode
    {
        get { return _acctCode; }
        set { _acctCode = value; }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public GLAccount()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public override int get(int id)
    {
        string sql = "select * from Fin_GLAccount where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _name = dt.Rows[0]["Name"].ToString();
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            decimal.TryParse(dt.Rows[0]["Balance"].ToString(), out _balance);
            _balance = getAcctBalance(id);
            _description = dt.Rows[0]["Description"].ToString();
            _name = dt.Rows[0]["Name"].ToString();
            int.TryParse(dt.Rows[0]["ParentAcctID"].ToString(), out _parentAcctID);
            int.TryParse(dt.Rows[0]["Status"].ToString(), out _status);
            int.TryParse(dt.Rows[0]["AcctCode"].ToString(), out _acctCode);
            int.TryParse(dt.Rows[0]["AcctType"].ToString(), out _acctType);
            return 1;
        }
        return 0;
    }
    public bool AccountCodeExist(int AccountCode) {
        string sql = "select * from Fin_GLAccount where AcctCode = " + AccountCode.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt.Rows.Count>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override System.Data.DataTable getList()
    {
        string sql = "SELECT  ID, Name, Description, Balance, AcctType, Status, AcctCode, ParentAcctID FROM   dbo.Fin_GLAccount";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Balance"] = getAcctBalance(Convert.ToInt32(dt.Rows[i]["ID"].ToString()));
        }
        return dt;

    }
    public System.Data.DataTable getList(int parentAcctID)
    {
        string sql = "select * from Fin_GLAccount where ParentAcctID = " + parentAcctID.ToString() + " order by id";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Balance"] = getAcctBalance(Convert.ToInt32(dt.Rows[i]["ID"].ToString()));
        }
        return dt;
    }
    public DataTable getAcctTransactions(int id)
    {
        string sql = "select * from Fin_JournalEntryRows where GLAccountID =" + id.ToString();
        return DataAccess.ExecuteSQLQuery(sql);
    }

    /* public override System.Data.DataTable getAccountsList()
     {
         string sql = "Select Fin_GLAccount.ID,Fin_GLAccount.Name,'gl' as [type] from Fin_GLAccount union select Fin_Bank.ID,Fin_Bank.BankName,'dp' as [type]  from Fin_Bank";
         DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        /* for (int i = 0; i < dt.Rows.Count; i++)
         {
             dt.Rows[i]["Balance"] = getAcctBalance(Convert.ToInt32(dt.Rows[i]["ID"].ToString()));
         }
         return dt;

     }*/

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[5] = DataAccess.AddParamter("@Balance", _balance, SqlDbType.Decimal, 50);
        param[6] = DataAccess.AddParamter("@ParentAcctID", _parentAcctID, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@AcctType", _acctType, SqlDbType.Int, 50);
        param[8] = DataAccess.AddParamter("@Status", _status, SqlDbType.Int, 50);
        param[9] = DataAccess.AddParamter("@AcctCode", _acctCode, SqlDbType.Int, 50);
        string sql = "insert into Fin_GLAccount(CreationDate,LastModifiedDate,OperatorID,Name,Description,Balance,ParentAcctID,AcctType,Status,AcctCode) values (@Creationdate,@LastModifiedDate,@OperatorID,@Name,@Description,@Balance,@ParentAcctID,@AcctType,@Status,@AcctCode)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Fin_GLAccount";
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
        SqlParameter[] param = new SqlParameter[9];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        //param[5] = DataAccess.AddParamter("@Balance", _balance, SqlDbType.Decimal, 50);
        param[5] = DataAccess.AddParamter("@ParentAcctID", _parentAcctID, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@Status", _status, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@AcctCode", _acctCode, SqlDbType.Int, 50);
        param[8] = DataAccess.AddParamter("@AcctType", _acctType, SqlDbType.Int, 50);
        string sql = "Update Fin_GLAccount set LastModifiedDate = @LastModifiedDate,OperatorID = @OperatorID,Name =@Name ,Description =@Description ,ParentAcctID = @ParentAcctID,Status =@Status ,AcctCode = @AcctCode,AcctType = @AcctType Where ID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id

        return _id;

    }
    public void increaseAcctBalanc(decimal amt, int glAcctID)
    {
        string sql = " update Fin_GLAccount set Balance = Balance + " + amt.ToString() + " where ID = " + glAcctID.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
    }

    public void decreaseAcctBalanc(decimal amt, int glAcctID)
    {
        string sql = " update Fin_GLAccount set Balance = Balance - " + amt.ToString() + " where ID = " + glAcctID.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
    }
    public decimal getAcctBalance(int glAcctID)
    {
        decimal acctBalance = 0;
        string sql = " select * from Fin_GLAccount where ParentAcctID = " + glAcctID.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);

        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                acctBalance += getAcctBalance(Convert.ToInt32(dt.Rows[i]["ID"].ToString()));
            }
        }
        else
        {
            sql = "select Balance from Fin_GLAccount where ID=" + glAcctID.ToString();
            dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["Balance"].ToString());
            }
        }
        return acctBalance;
    }
}