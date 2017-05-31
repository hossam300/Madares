using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EducationalYear
/// </summary>
public class EducationalYear:baseObject
{
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    int _rank;

    public int Rank
    {
        get { return _rank; }
        set { _rank = value; }
    }

    int _noOfLec;

    public int NoOfLec
    {
        get { return _noOfLec; }
        set { _noOfLec = value; }
    }

    int _lecTimeMin;

    public int LecTimeMin
    {
        get { return _lecTimeMin; }
        set { _lecTimeMin = value; }
    }

    DataTable _breaks;

    public DataTable Breaks
    {
        get { return _breaks; }
        set { _breaks = value; }
    }

	public EducationalYear()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "Select * From Std_EducationalYear Where ID="+id;
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            _name = dt.Rows[0]["YearName"].ToString();

            int.TryParse(dt.Rows[0]["Rank"].ToString(), out _rank);
            int.TryParse(dt.Rows[0]["NoOfLec"].ToString(), out _noOfLec);
            int.TryParse(dt.Rows[0]["LecPeriodMin"].ToString(), out _lecTimeMin);
            sql = "SELECT   * From Std_EdYearBreaks Where YearID="+id;
            _breaks = DataAccess.ExecuteSQLQuery(sql);
           
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        string sql = "SELECT Std_EducationalYear.ID,Std_EducationalYear.CreationDate,Std_EducationalYear.LastModifiedDate,Std_EducationalYear.OperatorID,YearName      ,Rank,COUNT(std_class.ID) as NoClasses FROM Std_EducationalYear left outer join Std_Class on Std_Class.EdyID = Std_EducationalYear.ID  group by Std_EducationalYear.ID,Std_EducationalYear.CreationDate,Std_EducationalYear.LastModifiedDate,Std_EducationalYear.OperatorID,YearName ,Rank";
        //DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        /*sql = "SELECT Std_EducationalYear.ID,Std_EducationalYear.CreationDate,Std_EducationalYear.LastModifiedDate,Std_EducationalYear.OperatorID,YearName      ,Rank,COUNT(std_class.ID) as NoClasses,COUNT(std_student.ID) as NoStudents  FROM Std_EducationalYear left outer join Std_Class on Std_Class.EdyID = Std_EducationalYear.ID  left outer join std_student on std_class.ID = std_student.studClassID  group by Std_EducationalYear.ID,Std_EducationalYear.CreationDate,Std_EducationalYear.LastModifiedDate,Std_EducationalYear.OperatorID,YearName      ,Rank";*/
        return DataAccess.ExecuteSQLQuery(sql);
    }

    public override int save()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@Rank", _rank, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@NoLec", _noOfLec, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@LecTime", _lecTimeMin, SqlDbType.Int, 50);



        string sql = "insert into Std_EducationalYear(CreationDate,LastModifiedDate,OperatorID,YearName,Rank,NoOfLec,LecPeriodMin) values (@CreationDate,@LastModifiedDate,@OperatorID,@Name,@Rank,@NoLec,@LecTime)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Std_EducationalYear";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            //save the breaks
            if (_breaks != null && _breaks.Rows != null && _breaks.Rows.Count > 0)
            {
                for (int i = 0; i < _breaks.Rows.Count; i++)
                {
                    sql = "insert into Std_EdYearBreaks(YearID,BreakFrom,BreakTo) values (" + _id.ToString() + ",'" + _breaks.Rows[i]["BreakFrom"].ToString() + "','" + _breaks.Rows[i]["BreakTo"].ToString() + "')";
                    DataAccess.ExecuteSQLNonQuery(sql);
                }

            }
            //save the product for this educational year
            Product product = new Product();
            product.Name = _name;
            product.OperatorID = 1;
            product.Price = 0;
            product.Cost = 0;
            product.TypeID = 3;
            product.ProductPriceItems = new DataTable();
            int prodID = product.save();
            //save the relation in the integration table
            sql = "insert into Int_EdyProduct(EdyID,ProductID) values("+_id.ToString()+","+prodID.ToString()+")";
            DataAccess.ExecuteSQLNonQuery(sql);
            return _id;
        }
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 250);
        param[4] = DataAccess.AddParamter("@Rank", _rank, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@NoLec", _noOfLec, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@LecTime", _lecTimeMin, SqlDbType.Int, 50);



        string sql = "UPDATE [Std_EducationalYear]  SET [LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID,[YearName] =@Name,[Rank] = @Rank,[NoOfLec] = @NoLec,[LecPeriodMin] = @LecTime where ID =@ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "delete from Std_EdYearBreaks where YearID = "+ _id.ToString() ;
        DataAccess.ExecuteSQLNonQuery(sql);
        if(_breaks != null && _breaks.Rows != null && _breaks.Rows.Count>0)
        {
            for (int i = 0; i < _breaks.Rows.Count; i++)
            {
                sql = "insert into Std_EdYearBreaks(YearID,BreakFrom,BreakTo) values (" + _id.ToString() + ",'" + _breaks.Rows[i]["BreakFrom"].ToString() + "','" + _breaks.Rows[i]["BreakTo"].ToString() + "')";
                DataAccess.ExecuteSQLNonQuery(sql);
            }
        }
        return _id;
        
    }

    public DataTable GetClasses(int edID)
    {
        string sql = "SELECT     dbo.Std_Class.ID, dbo.Std_Class.Name, dbo.Std_Teacher.Name AS Supervisor From dbo.Std_Class INNER JOIN dbo.Std_Teacher ON dbo.Std_Class.SupID = dbo.Std_Teacher.ID WHERE  (dbo.Std_Class.EdyID = " + edID + ")";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public DataTable GetCourses(int edID)
    {
        string sql = "SELECT dbo.Std_Course.ID, dbo.Std_Course.Name, dbo.Std_Course.Description, dbo.Std_Course.min, dbo.Std_Course.max FROM  dbo.Std_CourseEdy INNER JOIN  dbo.Std_Course ON dbo.Std_CourseEdy.CourseID = dbo.Std_Course.ID WHERE     (dbo.Std_CourseEdy.EdyID =" + edID + ")";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public DataTable getStudentnotPaid(int edyID)
    {
        string sql = "select Std_Student.ID as StudentID,Std_Student.Name as StudentName,Std_Student.Phone as Phone,Std_Parent.Name as ParentName, Fin_CustomerItems.Balance as RemainingAmount " +
                     " from dbo.Int_StdCustomer "+
                     "inner join Std_Student on Int_StdCustomer.StdID = Std_Student.ID " +
                     "inner join Fin_CustomerItems on Fin_CustomerItems.ID = Int_StdCustomer.CustItemID " +
                     "inner join Std_Parent on Std_Parent.ID = Std_Student.ParentID " +
                     "inner join Std_Class on Std_Class.ID = Std_Student.StudClassID " +
                     "inner join Std_EducationalYear on Std_Class.EdyID= Std_EducationalYear.ID " +
                     "where Fin_CustomerItems.Balance>0 and Std_EducationalYear.ID = " + edyID.ToString();
        return DataAccess.ExecuteSQLQuery(sql);
    }
}