using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Supplier : baseObject
{
    string _name;
    decimal _totalBuyedAmount;
    decimal _totalBalance;
    public  string Name
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

    public override int get(int id)
    {
        string sql = "select * from Fin_Supplier where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _name = dt.Rows[0]["Name"].ToString();
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            //getTotalBuyedBalance();
            /*decimal.TryParse(dt.Rows[0]["TotalBalance"].ToString(), out _totalBalance);
            decimal.TryParse(dt.Rows[0]["TotalBuyedAmount"].ToString(), out _totalBuyedAmount);*/
            return 1;
        }
        return 0;
    }
    /*public int addCustomerItem(int productId, decimal price,int customerID)
    {
        SqlParameter[] param =new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@CustomerID", customerID, SqlDbType.Int, 50);
        param[4] = DataAccess.AddParamter("@ProductID", productId, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@Price", price, SqlDbType.Decimal, 50);
        param[6] = DataAccess.AddParamter("@Balance", price, SqlDbType.Decimal, 50);


        string sql = "insert into Fin_CustomerItems(CreationDate,LastModifiedDate,OperatorID,CustomerID,ProductID,Price,Balance) values(@CreationDate,@LastModifiedDate,@OperatorID,@CustomerID,@ProductID,@Price,@Balance)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Fin_CustomerItems";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            return int.Parse(dt.Rows[0]["lastID"].ToString());
        return 0;
    }*/
    /*public DataTable getCustomerItemList(int customerID)
    {
        string sql = "select * from Fin_CustomerItems where CustomerID = " + customerID.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }*/
    public override DataTable getList()
    {
        string sql = "select * from Fin_Supplier";


        return DataAccess.ExecuteSQLQuery(sql);
    }


    public override int save()
    {
        SqlParameter[] param =new SqlParameter[4];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);

        string sql = "insert into Fin_Supplier(CreationDate,LastModifiedDate,OperatorID,Name) values (@Creationdate,@LastModifiedDate,@OperatorID,@Name)";
        DataAccess.ExecuteSQLNonQuery(sql,param);
        //get last id
        sql = "select max(id)as lastID from Fin_Supplier";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            return int.Parse(dt.Rows[0]["lastID"].ToString());
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[1] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        //param[2] = DataAccess.AddParamter("@Creationdate", _creationDate, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);

        string sql = "update Fin_Supplier set LastModifiedDate = @LastModifiedDate,OperatorID = @OperatorID,Name = @Name where ID = @ID";
        return DataAccess.ExecuteSQLNonQuery(sql,param);
        
        
    }

    public  decimal totalBuyedAmount
    {
        get{return _totalBuyedAmount;}
        set { _totalBuyedAmount = value; }
    }

    public  decimal TotalBalance
    {
        get { return _totalBalance; }
        set { _totalBalance = value; }
    }

    /*public  void getTotalBuyedBalance()
    {
        string sql = "select sum(Price) as totalBuyedAmount,sum(Balance) as totalBalance from Fin_CustomerItems where CustomerID = " + _id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            decimal.TryParse(dt.Rows[0]["totalBuyedAmount"].ToString(), out _totalBuyedAmount);
            decimal.TryParse(dt.Rows[0]["totalBalance"].ToString(), out _totalBalance);
        }
    }*/


    public Supplier()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}