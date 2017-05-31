using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductPriceItems
/// </summary>
public class ProductPriceItems:baseObject
{
    int _gLAccountID;

    public int GLAccountID
    {
        get { return _gLAccountID; }
        set { _gLAccountID = value; }
    }
    int _productID;

    public int ProductID
    {
        get { return _productID; }
        set { _productID = value; }
    }
    decimal _amount;

    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    int _seq;

    public int Seq
    {
        get { return _seq; }
        set { _seq = value; }
    }
    string _description;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

	public ProductPriceItems()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        return 0;
    }
    public  DataTable getByProductID(int ProductID)
    {
        string sql = "select ID,Description,Amount,Seq,GLAccountID from Fin_ProductPriceItems where ProductID = " + ProductID.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        
        return dt;
    }

    public override System.Data.DataTable getList()
    {
        throw new NotImplementedException();
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