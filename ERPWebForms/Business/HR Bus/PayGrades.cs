using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PayGrade
/// </summary>
public class PayGrades:baseObject
{
    string _payGrade;
    private int _depitGL;

    public int DepitGL
    {
        get { return _depitGL; }
        set { _depitGL = value; }
    }

    private int _creditGL;

    public int CreditGL
    {
        get { return _creditGL; }
        set { _creditGL = value; }
    }
    
    public string PayGrade
    {
        get { return _payGrade; }
        set { _payGrade = value; }
    }
     DataTable _payGradesSallary;
     public DataTable PayGradesSallary
     {
         get { return _payGradesSallary; }
         set { _payGradesSallary = value; }
     }
     DataTable _payGradesSallaryItems;

     public DataTable PayGradesSallaryItems
     {
         get { return _payGradesSallaryItems; }
         set { _payGradesSallaryItems = value; }
     }
	public PayGrades()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_PayGrades where PayGradeID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;

            _payGrade = dt.Rows[0]["PayGrade"].ToString();
            sql = "select [payGradesSallaryID] ,[Name],[Value],[Percentage],[Nature],[type],[source] from HR_payGradesSallary where PayGradeID = " + id.ToString();
            _payGradesSallary = DataAccess.ExecuteSQLQuery(sql);
            return 1;
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from HR_PayGrades ";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@PayGrade", _payGrade, SqlDbType.NVarChar, 500);

        string sql = "INSERT INTO [HR_PayGrades] ([PayGrade] ,[CreationDate],[LastModifiedDate],[OperatorID]) values (@PayGrade,@Creationdate,@LastModifiedDate,@OperatorID)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(PayGradeID)as lastID from HR_PayGrades";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            SqlParameter[] param2 = new SqlParameter[10];
            if (_payGradesSallary != null && _payGradesSallary.Rows != null && _payGradesSallary.Rows.Count > 0)
            {
                for (int i = 0; i < _payGradesSallary.Rows.Count; i++)
                {
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@Name", _payGradesSallary.Rows[i]["Name"], SqlDbType.NVarChar, 500);
                    param2[4] = DataAccess.AddParamter("@PayGradeID", _id, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@Value", _payGradesSallary.Rows[i]["Value"], SqlDbType.NVarChar, 500);
                    param2[6] = DataAccess.AddParamter("@Percentage", _payGradesSallary.Rows[i]["Percentage"], SqlDbType.Int, 50);
                    param2[7] = DataAccess.AddParamter("@Nature", _payGradesSallary.Rows[i]["Nature"], SqlDbType.Int, 50);
                    param2[8] = DataAccess.AddParamter("@type", _payGradesSallary.Rows[i]["type"], SqlDbType.Int, 50);
                    param2[9] = DataAccess.AddParamter("@source", _payGradesSallary.Rows[i]["source"], SqlDbType.Int, 50);

                    sql = "insert into HR_payGradesSallary (CreationDate,LastModifiedDate,OperatorID,Name,Value,PayGradeID,Percentage,Nature,type,source) values(@CreationDate,@LastModifiedDate,@OperatorID,@Name,@Value,@PayGradeID,@Percentage,@Nature,@type,@source)";
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
        param[3] = DataAccess.AddParamter("@PayGrade", _payGrade, SqlDbType.NVarChar, 500);

        string sql = "UPDATE [HR_PayGrades] SET [PayGrade] = @PayGrade,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID  WHERE PayGradeID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        sql = "delete from HR_payGradesSallary where PayGradeID = @ID";
        param = new SqlParameter[1];
        param[0] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        DataAccess.ExecuteSQLNonQuery(sql, param);
        SqlParameter[] param2 = new SqlParameter[10];
        if (_payGradesSallary != null && _payGradesSallary.Rows != null && _payGradesSallary.Rows.Count > 0)
        {
            for (int i = 0; i < _payGradesSallary.Rows.Count; i++)
            {
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@Name", _payGradesSallary.Rows[i]["Name"], SqlDbType.NVarChar, 500);
                    param2[4] = DataAccess.AddParamter("@PayGradeID", _id, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@Value", _payGradesSallary.Rows[i]["Value"], SqlDbType.NVarChar, 500);
                    param2[6] = DataAccess.AddParamter("@Percentage", _payGradesSallary.Rows[i]["Percentage"], SqlDbType.Int, 50);
                    param2[7] = DataAccess.AddParamter("@Nature", _payGradesSallary.Rows[i]["Nature"], SqlDbType.Int, 50);
                    param2[8] = DataAccess.AddParamter("@type", _payGradesSallary.Rows[i]["type"], SqlDbType.Int, 50);
                    param2[9] = DataAccess.AddParamter("@source", _payGradesSallary.Rows[i]["source"], SqlDbType.Int, 50);
                    sql = "insert into HR_payGradesSallary (CreationDate,LastModifiedDate,OperatorID,Name,Value,PayGradeID,Percentage,Nature,type,source) values(@CreationDate,@LastModifiedDate,@OperatorID,@Name,@Value,@PayGradeID,@Percentage,@Nature,@type,@source)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
            }
        }

        return _id;
    }


    public DataTable getByProductID(int PayGradeID)
    {
        string sql = "select [payGradesSallaryID] ,[Name],[Value],[Percentage],[Nature],[type],[source] from HR_payGradesSallary where PayGradeID = " + PayGradeID.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);

        return dt;
    }

    public int saveSallaryItems()
    {
        string sql = "";
        if (_payGradesSallaryItems != null && _payGradesSallaryItems.Rows != null && _payGradesSallaryItems.Rows.Count > 0)
        {
            for (int i = 0; i < _payGradesSallaryItems.Rows.Count; i++)
            {
                sql = "select * from HR_SallarySheetItems where SallarySheetItemID=" + _payGradesSallaryItems.Rows[i];
                DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                if(dt!= null && dt.Rows != null && dt.Rows.Count>1)
                {
                    //update
                    sql = "update HR_SallarySheetItems set Name ='N"+_payGradesSallaryItems.Rows[i]["Name"].ToString()+"' ,Nature="+_payGradesSallaryItems.Rows[i]["Nature"].ToString()+",Type="+_payGradesSallaryItems.Rows[i]["Type"].ToString()+",[Order]="+_payGradesSallaryItems.Rows[i]["Order"].ToString()+" where SallarySheetItemID=" + _payGradesSallaryItems.Rows[i]["SallarySheetItemID"].ToString();
                    DataAccess.ExecuteSQLNonQuery(sql);
                }
                else
                {
                    //insert
                    
                    sql = "insert into HR_SallarySheetItems (CreationDate,LastModifiedDate,OperatorID,Name,Nature,Type,[order]) values ('" + DateTime.Now.ToShortDateString()+"','"+DateTime.Now.ToShortDateString()+"',"+_operatorID.ToString()+",N'"+ _payGradesSallaryItems.Rows[i]["Name"].ToString() + "'," + _payGradesSallaryItems.Rows[i]["Nature"].ToString() + "," + _payGradesSallaryItems.Rows[i]["Type"].ToString() + "," + _payGradesSallaryItems.Rows[i]["Order"].ToString() + ")";
                    DataAccess.ExecuteSQLNonQuery(sql);
                }
            }
        }
        sql = "delete from HR_SallaryGLAcct";
        DataAccess.ExecuteSQLNonQuery(sql);

        sql = "insert into HR_SallaryGLAcct(SallaryDPGLID,SallaryCRGLID) values("+_depitGL.ToString()+","+_creditGL.ToString()+")";
        DataAccess.ExecuteSQLNonQuery(sql);
        return 0;
    }

    public void getSallaryItems()
    {
        string sql = "select * from HR_SallarySheetItems";
        PayGradesSallaryItems = DataAccess.ExecuteSQLQuery(sql);
        sql = "select * from HR_SallaryGLAcct";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if(dt != null && dt.Rows != null && dt.Rows.Count>0)
        {
            _creditGL = int.Parse(dt.Rows[0]["SallaryCRGLID"].ToString());
            _depitGL = int.Parse(dt.Rows[0]["SallaryDPGLID"].ToString());

        }
    }

    public DataTable getSallaryItem(int id)
    {
        string sql = "select * from HR_SallarySheetItems where SallarySheetItemID = " + id.ToString();
        return DataAccess.ExecuteSQLQuery(sql);
    }
}