using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmpTS
/// </summary>
public class EmpTS:baseObject
{
	public EmpTS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        throw new NotImplementedException();
    }
    public DataTable getByProductID(int TimeSheetID)
    {
        string sql = "select * from HR_EmpTimeSheet where TimeSheetID = " + TimeSheetID.ToString();
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