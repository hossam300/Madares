using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JournalEntry
/// </summary>
public class JournalEntry:baseObject
{
    
    string _description;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    DataTable _journalEntryRows;

    public DataTable JournalEntryRows
    {
        get { return _journalEntryRows; }
        set { _journalEntryRows = value; }
    }

    decimal _amount;

    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
	public JournalEntry()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from Fin_JournalEntry where ID ="+id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {

            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
    
            _description = dt.Rows[0]["Description"].ToString();
            _amount = Convert.ToDecimal( dt.Rows[0]["Amount"].ToString());
            sql = "SELECT TOP 1000 [ID] ,[CreationDate]  ,[LastModifiedDate]  ,[GLAccountID] as GLAccountID ,[CreditAmount] as Credit ,[DepitAmount] as Depit ,[JournalEntryID] ,[Memo] ,[AcctBalance] from Fin_JournalEntryRows where JournalEntryID = " + id.ToString();
            
            _journalEntryRows = DataAccess.ExecuteSQLQuery(sql); 
            return id;
        }
        return 0;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from Fin_JournalEntry";

        return DataAccess.ExecuteSQLQuery(sql);
    }

    public int postJournalEntry()
    {
        return 0;
    }
    public int addJERow(int glActID, decimal creditAmt, decimal depitAmt, string memo,int AcctType)
    {
        if (_journalEntryRows == null)
        {
            _journalEntryRows = new DataTable();
            _journalEntryRows.Columns.Add("GLAccountID");
            _journalEntryRows.Columns.Add("Depit");
            _journalEntryRows.Columns.Add("Credit");
            _journalEntryRows.Columns.Add("Memo");
            _journalEntryRows.Columns.Add("AcctType");
            
        }
        DataRow dr = _journalEntryRows.NewRow();
        dr["GLAccountID"] = glActID;
        dr["Depit"] = depitAmt;
        dr["Credit"] = creditAmt;
        dr["Memo"] = memo;
        dr["AcctType"] = AcctType.ToString();
        _journalEntryRows.Rows.Add(dr);
        return 0;
    }

    public override int save()
    {
        return save(DateTime.Now);
    }
    public int save(DateTime AEDate)
    {
        int res =validate(); 
        if (res ==0)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
            param[1] = DataAccess.AddParamter("@Creationdate", AEDate, SqlDbType.DateTime, 50);
            param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
            param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);

            param[4] = DataAccess.AddParamter("@Amount", _amount, SqlDbType.Decimal, 50);


            string sql = "insert into Fin_JournalEntry(CreationDate,LastModifiedDate,OperatorID,Amount,Description) values (@Creationdate,@LastModifiedDate,@OperatorID,@Amount,@Description)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            //get last id
            sql = "select max(id)as lastID from Fin_JournalEntry";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                _id = int.Parse(dt.Rows[0]["lastID"].ToString());
                SqlParameter[] param2 = new SqlParameter[9];
                decimal dpAmt, crAmt;
                dpAmt = 0;
                crAmt = 0;

                for (int i = 0; i < _journalEntryRows.Rows.Count; i++)
                {
                    decimal.TryParse(_journalEntryRows.Rows[i]["Depit"].ToString(), out dpAmt);
                    decimal.TryParse(_journalEntryRows.Rows[i]["Credit"].ToString(), out crAmt);
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@GLAccountID", _journalEntryRows.Rows[i]["GLAccountID"], SqlDbType.Int, 50);
                    //CreditAmount
                    param2[4] = DataAccess.AddParamter("@CreditAmount", crAmt, SqlDbType.Decimal, 50);
                    param2[5] = DataAccess.AddParamter("@DepitAmount", dpAmt, SqlDbType.Decimal, 50);

                    param2[6] = DataAccess.AddParamter("@JournalEntryID", _id, SqlDbType.Int, 50);
                    param2[7] = DataAccess.AddParamter("@Memo", _journalEntryRows.Rows[i]["Memo"], SqlDbType.NVarChar, 500);

                    param2[8] = DataAccess.AddParamter("@AcctBalance", new GLAccount().getAcctBalance(Convert.ToInt32(_journalEntryRows.Rows[i]["GLAccountID"].ToString())), SqlDbType.Decimal, 50);
                    sql = "insert into Fin_JournalEntryRows(CreationDate,LastModifiedDate,OperatorID,GLAccountID,CreditAmount,DepitAmount,JournalEntryID,Memo,AcctBalance) VALUES (@CreationDate,@LastModifiedDate,@OperatorID,@GLAccountID,@CreditAmount,@DepitAmount,@JournalEntryID,@Memo,@AcctBalance)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                    //post the JE to update the acount balance
                    int acctID = Convert.ToInt32(_journalEntryRows.Rows[i]["GLAccountID"].ToString());
                    if (int.Parse(_journalEntryRows.Rows[i]["AcctType"].ToString()) == 0) // GL Account
                    {
                        GLAccount gl = new GLAccount();
                        gl.get(acctID);

                        //1--> asset     --> depit
                        //2--> liability --> credit
                        //3--> equity    --> credit
                        //4--> income    --> credit
                        //5--> expense   --> depit


                        if (gl.AcctType == 1 || gl.AcctType == 5)//depit acount (asset and expenses)
                        {
                            if (dpAmt > 0)
                                gl.increaseAcctBalanc(dpAmt, gl.ID);
                            else if (crAmt > 0)
                                gl.decreaseAcctBalanc(crAmt, gl.ID);
                        }
                        else //credit acount (equity,liablity, income)
                        {
                            if (dpAmt > 0)
                                gl.decreaseAcctBalanc(dpAmt, gl.ID);
                            else if (crAmt > 0)
                                gl.increaseAcctBalanc(crAmt, gl.ID);
                        }
                    }
                    else
                    {
                        //bank account
                        if (dpAmt > 0)
                            new Bank().decreaseAcctBalanc(dpAmt, acctID);
                        else if (crAmt > 0)
                            new Bank().increaseAcctBalanc(crAmt, acctID);
                    }
                }
                return _id;
            }
        }
       
       return res;
    }

    private int validate()
    {
        decimal dpAmt = 0,crAmt = 0;
        for (int i = 0; i < _journalEntryRows.Rows.Count; i++)
        {
            if (_journalEntryRows.Rows[i]["Depit"].ToString()!="")
                dpAmt += Decimal.Parse(_journalEntryRows.Rows[i]["Depit"].ToString());
            if (_journalEntryRows.Rows[i]["Credit"].ToString() != "")
                crAmt += Decimal.Parse(_journalEntryRows.Rows[i]["Credit"].ToString());
        }
        if (dpAmt == crAmt && crAmt == _amount)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    public override int update()
    {
        throw new NotImplementedException();
    }
}