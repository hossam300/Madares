using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Branch
/// </summary>
public class Branch:baseObject
{
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    string _phone;

    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
    string _description;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
	public Branch()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from Fin_Branches where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            _name = dt.Rows[0]["BranchName"].ToString();
            _description = dt.Rows[0]["Description"].ToString();
            _phone = dt.Rows[0]["Phone"].ToString();
           
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from Fin_Branches ";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@BranchName", _name, SqlDbType.NVarChar, 200);
        param[5] = DataAccess.AddParamter("@Phone", _phone, SqlDbType.NVarChar, 50);


        string sql = "insert into Fin_Branches(CreationDate,LastModifiedDate,OperatorID,BranchName,Description,Phone) values (@CreationDate,@LastModifiedDate,@OperatorID,@BranchName,@Description,@Phone)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Fin_Branches";
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
        SqlParameter[] param = new SqlParameter[6];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Description", _description, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@BranchName", _name, SqlDbType.NVarChar, 200);
        param[5] = DataAccess.AddParamter("@Phone", _phone, SqlDbType.NVarChar, 50);


        string sql = "Update Fin_Branches set LastModifiedDate = @LastModifiedDate,OperatorID = @OperatorID,BranchName =@BranchName ,Description = @Description,Phone = @Phone where ID =@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
            return _id;
        
    }
}