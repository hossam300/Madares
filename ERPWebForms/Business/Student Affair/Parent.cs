using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Parent
/// </summary>
public class Parent:baseObject
{
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    string _userName;

    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }
    string _phone;

    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
    string _email;

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    string _address;

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
    string _job;

    public string Job
    {
        get { return _job; }
        set { _job = value; }
    }

	public Parent()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id) 
    {
        string sql = "select * from std_parent Where ID="+id;
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;

            _name = dt.Rows[0]["Name"].ToString();
            _email = dt.Rows[0]["Email"].ToString();
            _phone = dt.Rows[0]["Phone"].ToString();
            _address = dt.Rows[0]["address"].ToString();
            _job = dt.Rows[0]["Job"].ToString();
            _userName = dt.Rows[0]["UserName"].ToString();

        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from std_parent";
        return DataAccess.ExecuteSQLQuery(sql);
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@job", _job, SqlDbType.NVarChar, 250);
        param[5] = DataAccess.AddParamter("@Address", _address, SqlDbType.NVarChar, 250);
        param[6] = DataAccess.AddParamter("@Phone", _phone, SqlDbType.NVarChar, 250);
        param[7] = DataAccess.AddParamter("@Email", _email, SqlDbType.NVarChar, 250);
        param[8] = DataAccess.AddParamter("@UserName", _userName, SqlDbType.NVarChar, 250);
       
       
       

        string sql = "insert into Std_Parent(CreationDate,LastModifiedDate,OperatorID,Name,Job,Address,Phone,email,UserName) values (@CreationDate,@LastModifiedDate,@OperatorID,@Name,@Job,@Address,@Phone,@Email,@UserName)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Std_Parent";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            InsertToMySql(_id);
            InsertUserToMySql(_id, _userName, _userName, _phone, _email);
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
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@job", _job, SqlDbType.NVarChar, 250);
        param[5] = DataAccess.AddParamter("@Address", _address, SqlDbType.NVarChar, 250);
        param[6] = DataAccess.AddParamter("@Phone", _phone, SqlDbType.NVarChar, 250);
        param[7] = DataAccess.AddParamter("@Email", _email, SqlDbType.NVarChar, 250);
        string sql = " Update Std_Parent Set LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,Name=@Name,Job=@Job,Address=@Address,Phone=@Phone,email=@email Where ID=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //InsertToMySql(_id);
        //InsertUserToMySql(_id, _userName, _userName, _phone, _email);
        return _id;
        
            
       
    }
    public void InsertToMySql(int ID)
    {

        string sql = "INSERT INTO `scl_parent_information` (`id`) Values(10" + ID + ")";
        DataAccess.ExecuteMySQLNonQuery(sql);
    }
    public void InsertUserToMySql(int ID, string name, string username, string password, string email)
    {
        string sql = "INSERT INTO `scl_users` (`id`, `name`, `username`, `email`, `password`, `block`, `sendEmail`, `registerDate`, `lastvisitDate`, `activation`, `params`, `lastResetTime`, `resetCount`, `otpKey`, `otep`, `requireReset`) " +
"VALUES (10" + ID + ", '" + name + "', '" + username + "', '" + email + "'," +
"'$2y$10$jWwB4H81Om7zRCHCh6jIHOqItNrBMYzSGZ3P7cKYoiB0yFGbiK.Rq','0', '0', '', '', '', '', '0000-00-00 00:00:00', '0', '', '', '0');";
        DataAccess.ExecuteMySQLNonQuery(sql);
        sql = "INSERT INTO `scl_user_usergroup_map`(`user_id`, `group_id`) VALUES (10" + ID + ",10)";
        DataAccess.ExecuteMySQLNonQuery(sql);
    }
  
}