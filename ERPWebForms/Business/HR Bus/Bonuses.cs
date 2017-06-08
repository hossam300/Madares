using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Bonus
/// </summary>
public class Bonuses : baseObject
{
    int _empID;
    public int EmpID 
    {
        get { return _empID; }
        set { _empID = value; }
    }
    int _type;
    public int Type
    {
        get { return _type; }
        set { _type = value; }
    }
    decimal _value;
    public decimal Value
    {
        get { return _value; }
        set { _value = value; }
    }
    int _nature;
    public int Nature
    {
        get { return _nature; }
        set { _nature = value; }
    }
    int _month;
    public int Month
    {
        get { return _month; }
        set { _month = value; }
    }
    int _year;
    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }
    int _manger;
    public int Manger
    {
        get { return _manger; }
        set { _manger = value; }
    }
    int _precentageFrom;
    public int PrecentageFrom
    {
        get { return _precentageFrom; }
        set { _precentageFrom = value; }
    }
	public Bonuses()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "SELECT * FROM HR_Bonces where BonceID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            int.TryParse(dt.Rows[0]["EmpID"].ToString(), out _empID);
            int.TryParse(dt.Rows[0]["Type"].ToString(), out _type);
            int.TryParse(dt.Rows[0]["Month"].ToString(), out _month);
            int.TryParse(dt.Rows[0]["Year"].ToString(), out _year);
            int.TryParse(dt.Rows[0]["Manger"].ToString(), out _year);
            int.TryParse(dt.Rows[0]["PrecentageFrom"].ToString(), out _year);
            decimal.TryParse(dt.Rows[0]["Value"].ToString(), out _value);
         
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        //Nature=1 it's a bonus Nature=0 it's Deduction 
        string sql = "SELECT * FROM HR_Bonces  Where Nature =1";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }
    public System.Data.DataTable getListDeduction()
    {
        //Nature=1 it's a bonus Nature=0 it's Deduction 
        string sql = "SELECT * FROM HR_Bonces  Where Nature =0";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }
    public override int save()
    {
        SqlParameter[] param = new SqlParameter[11];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@EmpID", _empID, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@Value", _value, SqlDbType.Decimal, 50);
        param[5] = DataAccess.AddParamter("@Type", _type, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Nature", _nature, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@Month", _month, SqlDbType.Int, 50);
        param[8] = DataAccess.AddParamter("@Year", _year, SqlDbType.Int, 50);
        param[9] = DataAccess.AddParamter("@Manger", _year, SqlDbType.Int, 50);
        param[10] = DataAccess.AddParamter("@PrecentageFrom", _year, SqlDbType.Int, 50);
        string sql = "INSERT INTO [dbo].[HR_Bonces] ([EmpID] ,[Value],[Type],[Nature],[CreationDate],[LastModifiedDate],[OperatorID],[Month],[Year],[Manger],[PrecentageFrom]) values (@EmpID,@Value,@Type,@Nature,@Creationdate,@LastModifiedDate,@OperatorID,@Month,@Year,@Manger,@PrecentageFrom)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(BonceID)as lastID from HR_Bonces";
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
        SqlParameter[] param = new SqlParameter[11];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@EmpID", _empID, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@Value", _value, SqlDbType.Decimal, 50);
        param[5] = DataAccess.AddParamter("@Type", _type, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Nature", _nature, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@Month", _month, SqlDbType.Int, 50);
        param[8] = DataAccess.AddParamter("@Year", _year, SqlDbType.Int, 50);
        param[9] = DataAccess.AddParamter("@Manger", _year, SqlDbType.Int, 50);
        param[10] = DataAccess.AddParamter("@PrecentageFrom", _year, SqlDbType.Int, 50);
        string sql = "UPDATE [dbo].[HR_Bonces] SET [EmpID] = @EmpID,[Value] = @Value ,[Type] = @Type ,[Nature] = @Nature ,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID,[Month]=@Month,[Year]=@Year,[Manger]=@Manger,[PrecentageFrom]=@PrecentageFrom WHERE BonceID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        return _id;
    }
}