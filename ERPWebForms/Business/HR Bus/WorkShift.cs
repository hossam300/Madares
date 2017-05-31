using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WorkShift
/// </summary>
public class WorkShift:baseObject
{
    struct Emp
    {
        public int ID;
      
       
    }
    string _shiftName;

    public string ShiftName
    {
        get { return _shiftName; }
        set { _shiftName = value; }

    }
    string _from;

    public string From
    {
        get { return _from; }
        set { _from = value; }

    }
    string _to;

    public string To
    {
        get { return _to; }
        set { _to = value; }

    }
    string _duration;

    public string Duration
    {
        get { return _duration; }
        set { _duration = value; }

    }
    ArrayList _emps;

    public ArrayList Emps
    {
        get { return _emps; }
        set { _emps = value; }
    }
	public WorkShift()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from HR_WorkShift where WorkShiftID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;

            _shiftName = dt.Rows[0]["ShiftName"].ToString();
            _from = dt.Rows[0]["From"].ToString();
            _to = dt.Rows[0]["To"].ToString();
            _duration = dt.Rows[0]["Duration"].ToString();
            sql = "select * from HR_Emp_Shift where ShiftID =" + id.ToString();
            DataTable dtemps = DataAccess.ExecuteSQLQuery(sql);
            if (dtemps != null && dtemps.Rows != null && dtemps.Rows.Count > 0)

            {
                Emp em ;
               
                _emps = new ArrayList(dtemps.Rows.Count);
                for (int i = 0; i < dtemps.Rows.Count; i++)
                {
                    em = new Emp();
                    int.TryParse(dtemps.Rows[i]["EmpID"].ToString(), out em.ID);
                   
                    _emps.Add(em.ID);
                }
               
            }
        
        return id;
          }
        return 0;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "select * from HR_WorkShift ";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@ShiftName", _shiftName, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@From", _from, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@To", _to, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Duration", _duration, SqlDbType.NVarChar, 500);

        string sql = "insert into HR_WorkShift( [CreationDate],[LastModifiedDate],[OperatorID],[ShiftName],[From],[To],[Duration]) values (@Creationdate,@LastModifiedDate,@OperatorID,@ShiftName,@From,@To,@Duration)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        sql = "select max(WorkShiftID) as lastID from HR_WorkShift";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            SqlParameter[] param2 = new SqlParameter[5];
            if (_emps != null  && _emps.Count > 0)
            {
                for (int i = 0; i < _emps.Count; i++)
                {
                   
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@EmpID",_emps[i] , SqlDbType.Int, 50);
                    param2[4] = DataAccess.AddParamter("@ShiftID", _id, SqlDbType.Int, 50);

                    sql = "insert into HR_Emp_Shift (CreationDate,LastModifiedDate,OperatorID,EmpID,ShiftID) values(@CreationDate,@LastModifiedDate,@OperatorID,@EmpID,@ShiftID)";
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
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID",_id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@ShiftName", _shiftName, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@From", _from, SqlDbType.NVarChar, 500);
        param[5] = DataAccess.AddParamter("@To", _to, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Duration", _duration, SqlDbType.NVarChar, 500);

        string sql = "Update  HR_WorkShift Set [LastModifiedDate]=@LastModifiedDate,[OperatorID]=@OperatorID,[ShiftName]=@ShiftName,[From]=@From,[To]=@To,[Duration]=@Duration Where [WorkShiftID]=@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
       
            
            SqlParameter[] param2 = new SqlParameter[5];
            if (_emps != null && _emps.Count > 0)
            {
                for (int i = 0; i < _emps.Count; i++)
                {
                    Emp em = (Emp)_emps[i];
                    param2[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
                    param2[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
                    param2[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@EmpID", em.ID, SqlDbType.Int, 50);
                    param2[4] = DataAccess.AddParamter("@ShiftID", _id, SqlDbType.Int, 50);

                    sql = "Update  HR_Emp_Shift Set LastModifiedDate=@LastModifiedDate,OperatorID=@OperatorID,EmpID=@EmpID where ShiftID=@ID";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                }
            }
            return _id;
       
    }
}