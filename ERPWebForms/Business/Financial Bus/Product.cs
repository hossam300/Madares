using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product : baseObject
{
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    decimal _cost;

    public decimal Cost
    {
        get { return _cost; }
        set { _cost = value; }
    }
    decimal _price;

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }
    int _typeID;

    public int TypeID
    {
        get { return _typeID; }
        set { _typeID = value; }
    }
    DataTable _productPriceItems;
    public DataTable ProductPriceItems
    {
        get { return _productPriceItems; }
        set { _productPriceItems = value; }
    }
    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public override int get(int id)
    {
        string sql = "select * from Fin_Product where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _name = dt.Rows[0]["Name"].ToString();
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            decimal.TryParse(dt.Rows[0]["Cost"].ToString(), out _cost);
            decimal.TryParse(dt.Rows[0]["Price"].ToString(), out _price);
            int.TryParse(dt.Rows[0]["TypeID"].ToString(), out _typeID);
            sql = "select * from Fin_ProductPriceItems where ProductID = " + id.ToString();
            _productPriceItems = DataAccess.ExecuteSQLQuery(sql);
            return 1;
        }
        return 0;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from Fin_Product";

        return DataAccess.ExecuteSQLQuery(sql);
    }

    public DataTable getProductCustomers(int id)
    {
        string sql = "select * from Fin_CustomerItems inner join Fin_Customer on Fin_CustomerItems.CustomerID = Fin_Customer.ID  where ProductID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@Cost", _cost, SqlDbType.Decimal, 50);
        param[5] = DataAccess.AddParamter("@Price", _price, SqlDbType.Decimal, 50);
        param[6] = DataAccess.AddParamter("@TypeID", _typeID, SqlDbType.Decimal, 50);

        string sql = "insert into Fin_Product(CreationDate,LastModifiedDate,OperatorID,Name,Cost,Price,TypeID) values (@Creationdate,@LastModifiedDate,@OperatorID,@Name,@Cost,@Price,@TypeID)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Fin_Product";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            SqlParameter[] param2 = new SqlParameter[8];
            if (_productPriceItems != null && _productPriceItems.Rows != null && _productPriceItems.Rows.Count > 0)
            {
                for (int i = 0; i < _productPriceItems.Rows.Count; i++)
                {
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@GLAccountID", _productPriceItems.Rows[i]["GLAccountID"], SqlDbType.Int, 50);
                    param2[4] = DataAccess.AddParamter("@ProductID", _id, SqlDbType.Int, 50);
                    param2[5] = DataAccess.AddParamter("@Amount", _productPriceItems.Rows[i]["Amount"], SqlDbType.Decimal, 50);
                    param2[6] = DataAccess.AddParamter("@Seq", _productPriceItems.Rows[i]["Seq"], SqlDbType.Int, 50);
                    param2[7] = DataAccess.AddParamter("@Description", _productPriceItems.Rows[i]["Description"], SqlDbType.NVarChar, 500);

                    sql = "insert into Fin_ProductPriceItems (CreationDate,LastModifiedDate,OperatorID,GLAccountID,Description,ProductID,Amount,Seq) values(@CreationDate,@LastModifiedDate,@OperatorID,@GLAccountID,@Description,@ProductID,@Amount,@Seq)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                }
            }
            return _id;
        }
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[1] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        //DataAccess.AddParamter("@Creationdate", _creationDate, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@Cost", _cost, SqlDbType.Decimal, 50);
        param[5] = DataAccess.AddParamter("@Price", _price, SqlDbType.Decimal, 50);
        param[6] = DataAccess.AddParamter("@TypeID", _typeID, SqlDbType.Decimal, 50);

        string sql = "Update Fin_Product set LastModifiedDate = @LastModifiedDate,OperatorID =@OperatorID ,Name =@Name,Cost =@Cost,Price = @Price,TypeID=@TypeID where ID =@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        //delete the product price items and insert them again
        sql = "delete from Fin_ProductPriceItems where ProductID = @ID";
        param = new SqlParameter[1];
        param[0] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        DataAccess.ExecuteSQLNonQuery(sql, param);
        SqlParameter[] param2 = new SqlParameter[8];
        if (_productPriceItems != null && _productPriceItems.Rows != null && _productPriceItems.Rows.Count > 0)
        {
            for (int i = 0; i < _productPriceItems.Rows.Count; i++)
            {
                param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                param2[3] = DataAccess.AddParamter("@GLAccountID", _productPriceItems.Rows[i]["GLAccountID"], SqlDbType.Int, 50);
                param2[4] = DataAccess.AddParamter("@ProductID", _id, SqlDbType.Int, 50);
                param2[5] = DataAccess.AddParamter("@Amount", _productPriceItems.Rows[i]["Amount"], SqlDbType.Decimal, 50);
                param2[6] = DataAccess.AddParamter("@Seq", _productPriceItems.Rows[i]["Seq"], SqlDbType.Int, 50);
                param2[7] = DataAccess.AddParamter("@Description", _productPriceItems.Rows[i]["Description"], SqlDbType.NVarChar, 500);

                sql = "insert into Fin_ProductPriceItems (CreationDate,LastModifiedDate,OperatorID,GLAccountID,Description,ProductID,Amount,Seq) values(@CreationDate,@LastModifiedDate,@OperatorID,@GLAccountID,@Description,@ProductID,@Amount,@Seq)";
                DataAccess.ExecuteSQLNonQuery(sql, param2);
            }
        }

        return _id;
    }
}