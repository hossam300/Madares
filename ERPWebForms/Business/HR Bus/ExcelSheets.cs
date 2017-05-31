using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExcelSheets
/// </summary>
public class ExcelSheets:baseObject
{
    string _sheetStyleName;
    public string SheetStyleName 
    {
        get { return _sheetStyleName; }
        set { _sheetStyleName = value; }
    }
    DataTable _sheetItems;
    public DataTable SheetItems 
    {
        get { return _sheetItems; }
        set { _sheetItems = value; }
    }
	public ExcelSheets()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_ExcelSheetStyle where SheetStyleID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _sheetStyleName = dt.Rows[0]["SheetStyleName"].ToString();
          
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;

            sql = "select * from HR_SheetItems where SheetStyleID = " + id.ToString();
            _sheetItems = DataAccess.ExecuteSQLQuery(sql);
            return 1;
        }
        return 0;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from HR_ExcelSheetStyle";

        return DataAccess.ExecuteSQLQuery(sql);
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@SheetStyleName", _sheetStyleName, SqlDbType.NVarChar, 200);



        string sql = "insert into HR_ExcelSheetStyle(CreationDate,LastModifiedDate,OperatorID,SheetStyleName) values (@Creationdate,@LastModifiedDate,@OperatorID,@SheetStyleName)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(SheetStyleID)as lastID from HR_ExcelSheetStyle";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            SqlParameter[] param2 = new SqlParameter[6];
            if (_sheetItems != null && _sheetItems.Rows != null && _sheetItems.Rows.Count > 0)
            {
                for (int i = 0; i < _sheetItems.Rows.Count; i++)
                {
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@ItemName", _sheetItems.Rows[i]["ItemName"], SqlDbType.NVarChar, 500);
                    param2[4] = DataAccess.AddParamter("@SheetStyleID", _id, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@ItemOrder", _sheetItems.Rows[i]["ItemOrder"], SqlDbType.NVarChar, 500);

                    sql = "insert into HR_SheetItems (CreationDate,LastModifiedDate,OperatorID,ItemName,SheetStyleID,ItemOrder) values(@CreationDate,@LastModifiedDate,@OperatorID,@ItemName,@SheetStyleID,@ItemOrder)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                }
            }
            return _id;
        }
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@SheetStyleName", _sheetStyleName, SqlDbType.NVarChar, 200);
        string sql = "Upadate HR_ExcelSheetStyle(LastModifiedDate = @LastModifiedDate,OperatorID =@OperatorID ,SheetStyleName =@SheetStyleName where SheetStyleID =@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        //delete the product price items and insert them again
        sql = "delete from HR_SheetItems where SheetStyleID = @ID";
        param = new SqlParameter[1];
        param[0] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        DataAccess.ExecuteSQLNonQuery(sql, param);
        
        SqlParameter[] param2 = new SqlParameter[6];
        if (_sheetItems != null && _sheetItems.Rows != null && _sheetItems.Rows.Count > 0)
        {
            for (int i = 0; i < _sheetItems.Rows.Count; i++)
            {
                param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                param2[3] = DataAccess.AddParamter("@ItemName", _sheetItems.Rows[i]["ItemName"], SqlDbType.NVarChar, 500);
                param2[4] = DataAccess.AddParamter("@SheetStyleID", _id, SqlDbType.Int, 50);
                param2[5] = DataAccess.AddParamter("@ItemOrder", _sheetItems.Rows[i]["ItemOrder"], SqlDbType.NVarChar, 500);

                sql = "insert into HR_SheetItems (CreationDate,LastModifiedDate,OperatorID,ItemName,TimeSheetID,ItemOrder) values(@CreationDate,@LastModifiedDate,@OperatorID,@ItemName,@TimeSheetID,@ItemOrder)";
                DataAccess.ExecuteSQLNonQuery(sql, param2);
            }
        }

        return _id;
    }
    public DataTable getSheetItemsByID(int TimeSheetID)
    {
        string sql = "select * from HR_SheetItems where SheetStyleID = " + TimeSheetID.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);

        return dt;
    }
}