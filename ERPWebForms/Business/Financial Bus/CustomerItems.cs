using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerItems
/// </summary>
public class CustomerItems : baseObject
{
    int _customerID;

    public int CustomerID
    {
        get { return _customerID; }
        set { _customerID = value; }
    }
    int _productID;

    public int ProductID
    {
        get { return _productID; }
        set { _productID = value; }
    }
    decimal _price;

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }
    decimal _balance;

    public decimal Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }


    public CustomerItems()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public override int get(int id)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// to
    /// </summary>
    /// <param name="Cusomerid"></param>
    /// <param name="Productid"></param>
    /// <returns></returns>
    public System.Data.DataTable get(int Cusomerid, int Productid)
    {
        string sql = "select * from Fin_CustomerItems where CustomerID = " + Cusomerid.ToString() + " and ProductID = " + Productid.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);

        return dt;
    }

    public override System.Data.DataTable getList()
    {
        return new DataTable();
    }
    public System.Data.DataTable getList(int id, int IDtype)
    {
        string sql = "";
        if (IDtype == 1)//customerid
            sql = "select * from Fin_CustomerItems where CustomerID = " + id.ToString();
        else
            sql = "select * from Fin_CustomerItems where ProductID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        throw new NotImplementedException();
    }

    public override int update()
    {
        throw new NotImplementedException();
    }
}