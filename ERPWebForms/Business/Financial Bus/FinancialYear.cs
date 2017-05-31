using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FinancialYear
/// </summary>
public class FinancialYear:baseObject
{
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    DateTime _startDate;

    public DateTime StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }
    DateTime _endDate;

    public DateTime EndDate
    {
        get { return _endDate; }
        set { _endDate = value; }
    }
    string _description;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
	public FinancialYear()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from Fin_FinancialYear where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        _id = id;
        _name = dt.Rows[0]["Name"].ToString();
        DateTime.TryParse(dt.Rows[0]["StartDate"].ToString(), out _startDate);
        DateTime.TryParse(dt.Rows[0]["EndDate"].ToString(), out _endDate);
        _description = dt.Rows[0]["Description"].ToString();
        DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
        DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from Fin_FinancialYear";
        return DataAccess.ExecuteSQLQuery(sql);
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[5] = DataAccess.AddParamter("@StartDate", _startDate.ToShortDateString(), SqlDbType.Date, 50);
        param[6] = DataAccess.AddParamter("@EndDate", _endDate.ToShortDateString(), SqlDbType.Date, 50);



        string sql = "insert into Fin_FinancialYear(CreationDate,LastModifiedDate,OperatorID,Name,Description,StartDate,EndDate) values (@CreationDate,@LastModifiedDate,@OperatorID,@Name,@Description,@StartDate,@EndDate)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Fin_FinancialYear";
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
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[5] = DataAccess.AddParamter("@StartDate", _startDate.ToShortDateString(), SqlDbType.Date, 50);
        param[6] = DataAccess.AddParamter("@EndDate", _endDate, SqlDbType.Date, 50);

        string sql = "update Fin_FinancialYear set LastModifiedDate =@LastModifiedDate ,OperatorID = @OperatorID ,Name =@Name ,Description = @Description,StartDate = @StartDate,EndDate = @EndDate  where ID = @ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id

        return _id;
        
    }

    public DataTable getTrailBalance()
    {
        string sql = "select Fin_GLAccount.ID,Fin_GLAccount.Name,Fin_GLAccount.AcctCode,Fin_GLAccount.InitBalance, SUM(Fin_JournalEntryRows.CreditAmount)AS CreditBalance,SUM(Fin_JournalEntryRows.DepitAmount) as DepitBalance,Balance as CurrentBalance from Fin_GLAccount inner join Fin_JournalEntryRows on Fin_GLAccount.ID = Fin_JournalEntryRows.GLAccountID group by Fin_GLAccount.ID,Fin_GLAccount.Name,Fin_GLAccount.AcctCode,Fin_GLAccount.InitBalance,Balance        ";
        return DataAccess.ExecuteSQLQuery(sql);

    }

    public void CloseYear()
    {
        //copy journal entry table
        string sql = "insert into Fin_PreviousJournalEntry(ID,CreationDate,LastModifiedDate,OperatorID,Amount,Description,FinancialYearID) values select ID,CreationDate,LastModifiedDate,OperatorID,Amount,Description," + _id.ToString() + " from Fin_JournalEntry";
        DataAccess.ExecuteSQLNonQuery(sql);

        //copy journal entry rows table
        sql = "insert into Fin_PreviousJournalEntryRows(ID,CreationDate,LastModifiedDate,OperatorID,GLAccountID,CreditAmount,DepitAmount,JournalEntryID,Memo,AcctBalance,FinancialYearID) values select ID,CreationDate,LastModifiedDate,OperatorID,GLAccountID,CreditAmount,DepitAmount,JournalEntryID,Memo,AcctBalance," + _id.ToString() + " from Fin_JournalEntryRows";
        DataAccess.ExecuteSQLNonQuery(sql);

        //delete the journal entry table
        sql = "delete from Fin_JournalEntry";
        DataAccess.ExecuteSQLNonQuery(sql);

        //delete the journal entry row table
        sql = "delete from Fin_JournalEntryRows";
        DataAccess.ExecuteSQLNonQuery(sql);

        //copy the balance in the init balance for GL accounts and make balance equal 0
        sql = "update Fin_GLAccount set InitBalance = InitBalance + Balance";
        DataAccess.ExecuteSQLNonQuery(sql);
        sql = "update Fin_GLAccount set Balance = 0";
        DataAccess.ExecuteSQLNonQuery(sql);

        //set the isclosed = true for the year
        sql = "update Fin_FinancialYear set isClosed = 1 where ID = " +_id.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
    }
}