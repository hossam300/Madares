using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Holidays
/// </summary>
public class Holiday:baseObject
{
    string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    DateTime _date;
    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }
    int _repeats;
    public int Repeats 
    {
        get { return _repeats; }
        set { _repeats = value; }
    }
    string _type;
    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }
	public Holiday()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
       string sql = "select * from HR_Holidays where HolidayID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
           _name = dt.Rows[0]["HolidayName"].ToString();
            _id = id;
             DateTime.TryParse(dt.Rows[0]["Date"].ToString(), out  _date);
            int.TryParse(dt.Rows[0]["RepeatsAnnually"].ToString(), out _repeats);
           _type = dt.Rows[0]["Type"].ToString();
        }
        return id;
          
            
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from HR_Holidays";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@RepeatsAnnually", _repeats, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@Date", _date.ToShortDateString(), SqlDbType.Date, 50);
        param[6] = DataAccess.AddParamter("@Type", _type, SqlDbType.NVarChar, 500);


        string sql = "INSERT INTO [dbo].[HR_Holidays] ([HolidayName] ,[Date],[RepeatsAnnually],[Type],[CreationDate],[LastModifiedDate],[OperatorID]) values (@Name,@Date,@RepeatsAnnually,@Type,@Creationdate,@LastModifiedDate,@OperatorID)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(HolidayID) as lastID from HR_Holidays";
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
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@RepeatsAnnually", _repeats, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@Date", _date, SqlDbType.DateTime, 50);
        param[6] = DataAccess.AddParamter("@Type", _type, SqlDbType.NVarChar, 50);


        string sql = "UPDATE [HR_Holidays] SET [HolidayName] = @Name,[Date] = @Date ,[RepeatsAnnually] = @RepeatsAnnually ,[Type] = @Type ,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID  WHERE HolidayID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        return _id;
    }
}