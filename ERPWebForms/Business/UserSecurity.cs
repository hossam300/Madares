using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserSecurity
/// </summary>
public class UserSecurity
{
    int _userID;
    public string userName { get; set; }
    public string password { get; set; }

    public int RoleID { get; set; }
    public string RoleName { get; set; }
    public string DefaultURL { get; set; }
    public string RolePermission { get; set; }
    public int UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }
    ArrayList _forms;

    public ArrayList Forms
    {
        get { return _forms; }
        set { _forms = value; }
    }
    public string UserPermission;
	public UserSecurity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool login(string userName,string pass,out DataTable res)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = DataAccess.AddParamter("@UserName", userName, SqlDbType.NVarChar, 500);
        param[1] = DataAccess.AddParamter("@Password", pass, SqlDbType.NVarChar, 500);
        string sql = "select * from Users inner join UserRoles on Users.RoleID = UserRoles.ID where userName=@UserName and Password=@Password";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql,param);
        res = dt;
        
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            //sql = "select * from UserRoles where RoleID = " + dt.Rows[0]["RoleID"].ToString();
            //permission = DataAccess.ExecuteSQLQuery(sql);
            return true;
        }
       // permission = null;.
        return false;
    }
    public int addUser(string userName,string pass, int userRole)
    {
        int id = 0;
        string sql = "insert into users(name,username,password,RoleID) values('" + userName + "','" + userName + "','" + pass + "'," + userRole.ToString() + ")";
        DataAccess.ExecuteSQLNonQuery(sql);
        sql = "select Max(ID) as MaxID from users";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if(dt != null && dt.Rows != null && dt.Rows.Count >0)
        {
            id = int.Parse(dt.Rows[0]["MaxID"].ToString());
        }
        return id;
    }
    public int EditUser(int userID, string pass, int userRole) {

        string sql = "update users set password='" + pass + "',RoleID=" + userRole.ToString() + " Where user_id=" + userID;
        DataAccess.ExecuteSQLNonQuery(sql);
        sql = "select Max(ID) as MaxID from users";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return userID;
    }
    public string getUserPermission(int userID)
    {
        string userPermission = "";
        string sql = "select * from FormsSecurity where UserID = " + userID.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            /*for (int i = 0; i < dt.Rows.Count; i++)
			{
                userPermission += dt.Rows[i]["FormID"].ToString() + ",";
			}*/
            userPermission = dt.Rows[0]["FormID"].ToString();
        }
        return userPermission;
    }
    public void saveUserPermission()
    {
        string sql = "";
        string forms = "";
        /*for (int i = 0; i < Forms.Count; i++)
        {
            forms += forms[i].ToString() + ",";
        }*/
       // forms = forms.Substring(0, forms.Length - 1);
        sql = "delete FormsSecurity where UserID = " + _userID.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
        sql = "insert into FormsSecurity(UserID,FormID) values ("+_userID.ToString()+",'"+UserPermission+"')";
        DataAccess.ExecuteSQLNonQuery(sql);
    }
    public bool CheckFormPermission(int formID, string userPermission)
    {
        string[] per = userPermission.Split(',');
        for (int i = 0; i < per.Length; i++)
        {
            if (per[i].ToString() != "")
            {
                if (int.Parse(per[i].ToString()) == formID)
                    return true;
            }
        }
        return false;
    }

    public int addRole(string roleName,string defaultURL, string permission)
    {
        int id = 0;
        string sql = "insert into UserRoles(Name,DefaultURL,permission) values('" + roleName + "','" + defaultURL + "','"+permission+"')";
        DataAccess.ExecuteSQLNonQuery(sql);
        sql = "select max(id)as lastID from UserRoles";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            id = int.Parse(dt.Rows[0]["lastID"].ToString());
            //save the permission
        
        }
        return id;
    }
    public DataTable getAllForms(int Module)
    {
        string sql = "select * from AppForms where Module = " + Module.ToString();
        return DataAccess.ExecuteSQLQuery(sql);
    }

    internal DataTable getUsersList()
    {
        string sql = "select users.user_id as ID,username,UserRoles.Name as Role from users inner join UserRoles on UserRoles.ID = Users.RoleID";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public void get(int id)
    {
        string sql = "select * from users where user_id = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if(dt != null && dt.Rows != null && dt.Rows.Count>0)
        {
            userName = dt.Rows[0]["username"].ToString();
            password = dt.Rows[0]["password"].ToString();
            RoleID = int.Parse(dt.Rows[0]["RoleID"].ToString());
        }

    }
    public bool UserNameExist(string UserName) {
        string sql = "select * from users where username ='" + UserName+"'";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            return true;
        else
        return false;
    }
    internal void updateUser(string userName, string pass, int userRole, int id)
    {
        
        string sql = "update users set username = '"+userName+"',password = '"+pass+"',RoleID ="+userRole.ToString()+" where user_id = "+id.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
        
        
    }

    internal DataTable getRolesList()
    {
        string sql = "select * from UserRoles";
        return DataAccess.ExecuteSQLQuery(sql);
    }

    internal void getRole(int p)
    {
        string sql = "select *  from UserRoles  where ID = " + p.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        RoleName = dt.Rows[0]["Name"].ToString();
        DefaultURL = dt.Rows[0]["DefaultURL"].ToString();
        sql = "select * from FormsSecurity where RoleID = "+ p.ToString();
        RolePermission = dt.Rows[0]["Permission"].ToString();
    }

    internal void updateRole(int ID, string RoleName, string DefaultURL, string permission)
    {
        //int id = 0;
        string sql = "update UserRoles Set Name='" + RoleName + "',DefaultURL='" + DefaultURL + "', Permission ='"+permission+"' where ID = " + ID.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
            //save the permission
        
    }

}