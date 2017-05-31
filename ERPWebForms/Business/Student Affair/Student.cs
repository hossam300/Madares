using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student:baseObject
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
    string _address;

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
    DateTime _birthDate;

    public DateTime BirthDate
    {
        get { return _birthDate; }
        set { _birthDate = value; }
    }
    int _parentID;

    public int ParentID
    {
        get { return _parentID; }
        set { _parentID = value; }
    }
    string _phone;
    
    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
    int _type;

    public int Type
    {
        get { return _type; }
        set { _type = value; }
    }
    int _class;

    public int StudClass
    {
        get { return _class; }
        set { _class = value; }
    }
    string _gender;
    public string Gender {
        get { return _gender; }
        set { _gender = value; }
    }
    string _religion;
    public string Religion
    {
        get { return _religion; }
        set { _religion = value; }
    }
    int _learningDisabilities;
    public int LearningDisabilities {
        get { return _learningDisabilities; }
        set { _learningDisabilities = value; }
    }
    string _note;
    public string Note {
        get { return _note; }
        set { _note = value; }
    }
    int _father;
    public int Father {
        get { return _father; }
        set { _father = value; }
    }
    int _mother;
    public int Mother
    {
        get { return _mother; }
        set { _mother = value; }
    }
	public Student()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public override int get(int id)
    {
        string sql = "select * from Std_Student where ID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            _name = dt.Rows[0]["Name"].ToString();
            _userName = dt.Rows[0]["UserName"].ToString();
            int.TryParse(dt.Rows[0]["ParentID"].ToString(),out _parentID);
            _address = dt.Rows[0]["Address"].ToString();
            _phone = dt.Rows[0]["Phone"].ToString();
            int.TryParse(dt.Rows[0]["Type"].ToString(), out _type);
            int.TryParse(dt.Rows[0]["StudClassID"].ToString(), out _class);
            DateTime d = DateTime.Now;
            DateTime.TryParse(dt.Rows[0]["BirthDate"].ToString(), out d);
            _birthDate = d;
            Phone = dt.Rows[0]["Phone"].ToString();
            _gender = dt.Rows[0]["Gender"].ToString();
            _religion = dt.Rows[0]["Religion"].ToString();
            int.TryParse(dt.Rows[0]["LearningDisabilities"].ToString(), out _learningDisabilities);
            _note = dt.Rows[0]["Note"].ToString();
            int.TryParse(dt.Rows[0]["Father"].ToString(), out _father);
            int.TryParse(dt.Rows[0]["Mother"].ToString(), out _mother);
        }
        return id;
    }

    public override System.Data.DataTable getList()
    {
        DateTime d = new DateTime(DateTime.Now.Year, 9, 30);
      //string sql = "SELECT     dbo.Std_Student.ID, dbo.Std_Student.Name as Name, dbo.Std_Student.BirthDate, dbo.Std_Parent.Name AS ParentName, dbo.Std_Student.Address as Address, dbo.Std_Student.Phone as Phone , dbo.Std_Class.Name AS ClassName,  dbo.Std_StudentType.Name AS StdType, dbo.Std_EducationalYear.YearName as EducationalYear FROM dbo.Std_Student INNER JOIN  dbo.Std_Parent ON dbo.Std_Student.ParentID = dbo.Std_Parent.ID INNER JOIN dbo.Std_Class ON dbo.Std_Student.StudClassID = dbo.Std_Class.ID INNER JOIN dbo.Std_StudentType ON dbo.Std_Student.Type = dbo.Std_StudentType.ID INNER JOIN dbo.Std_EducationalYear ON dbo.Std_Class.EdyID = dbo.Std_EducationalYear.ID";
        string sql = "SELECT     dbo.Std_Student.ID, dbo.Std_Student.Name as Name, convert(varchar(20),dbo.Std_Student.BirthDate,103) as BirthDate, dbo.Std_Parent.Name AS ParentName,dbo.Std_Student.Gender, dbo.Std_Student.Religion,dbo.Std_Student.Address as Address, dbo.Std_Student.Phone as Phone , dbo.Std_Class.Name AS ClassName,  dbo.Std_StudentType.Name AS StdType, dbo.Std_EducationalYear.YearName as EducationalYear, dbo.Age(  dbo.Std_Student.BirthDate,CONVERT(datetime, '" + d.ToString("yyyy-MM-dd") + "', 121 )) AS age110 FROM dbo.Std_Student INNER JOIN  dbo.Std_Parent ON dbo.Std_Student.ParentID = dbo.Std_Parent.ID INNER JOIN dbo.Std_Class ON dbo.Std_Student.StudClassID = dbo.Std_Class.ID INNER JOIN dbo.Std_StudentType ON dbo.Std_Student.Type = dbo.Std_StudentType.ID INNER JOIN dbo.Std_EducationalYear ON dbo.Std_Class.EdyID = dbo.Std_EducationalYear.ID Where Type <> 4";
        //string sql = "select *,CAST(DATEDIFF(DAY, BirthDate,'" + d.ToString("yyyy-MM-dd") + "') AS datetime) AS age110 ,Std_class.Name as ClassName, Std_EducationalYear.YearName as EducationalYear,Std_StudentType.Name as StdType,std_parent.Name as ParentName from Std_Student inner join Std_class on Std_Student.StudClassID = Std_class.ID inner join Std_EducationalYear on Std_class.EdyID = Std_EducationalYear.ID inner join Std_StudentType on Std_Student.type = Std_StudentType.ID inner join std_parent on std_parent.ID = Std_Student.ParentID";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }
    public  System.Data.DataTable getListNotExist()
    {
        DateTime d = new DateTime(DateTime.Now.Year, 9, 30);
        //string sql = "SELECT     dbo.Std_Student.ID, dbo.Std_Student.Name as Name, dbo.Std_Student.BirthDate, dbo.Std_Parent.Name AS ParentName, dbo.Std_Student.Address as Address, dbo.Std_Student.Phone as Phone , dbo.Std_Class.Name AS ClassName,  dbo.Std_StudentType.Name AS StdType, dbo.Std_EducationalYear.YearName as EducationalYear FROM dbo.Std_Student INNER JOIN  dbo.Std_Parent ON dbo.Std_Student.ParentID = dbo.Std_Parent.ID INNER JOIN dbo.Std_Class ON dbo.Std_Student.StudClassID = dbo.Std_Class.ID INNER JOIN dbo.Std_StudentType ON dbo.Std_Student.Type = dbo.Std_StudentType.ID INNER JOIN dbo.Std_EducationalYear ON dbo.Std_Class.EdyID = dbo.Std_EducationalYear.ID";
        string sql = "SELECT     dbo.Std_Student.ID, dbo.Std_Student.Name as Name, convert(varchar(20),dbo.Std_Student.BirthDate,103) as BirthDate, dbo.Std_Parent.Name AS ParentName,dbo.Std_Student.Gender, dbo.Std_Student.Religion,dbo.Std_Student.Address as Address, dbo.Std_Student.Phone as Phone , dbo.Std_Class.Name AS ClassName,  dbo.Std_StudentType.Name AS StdType, dbo.Std_EducationalYear.YearName as EducationalYear, dbo.Age(  dbo.Std_Student.BirthDate,CONVERT(datetime, '" + d.ToString("yyyy-MM-dd") + "', 121 )) AS age110 FROM dbo.Std_Student INNER JOIN  dbo.Std_Parent ON dbo.Std_Student.ParentID = dbo.Std_Parent.ID INNER JOIN dbo.Std_Class ON dbo.Std_Student.StudClassID = dbo.Std_Class.ID INNER JOIN dbo.Std_StudentType ON dbo.Std_Student.Type = dbo.Std_StudentType.ID INNER JOIN dbo.Std_EducationalYear ON dbo.Std_Class.EdyID = dbo.Std_EducationalYear.ID Where Type=4";
        //string sql = "select *,CAST(DATEDIFF(DAY, BirthDate,'" + d.ToString("yyyy-MM-dd") + "') AS datetime) AS age110 ,Std_class.Name as ClassName, Std_EducationalYear.YearName as EducationalYear,Std_StudentType.Name as StdType,std_parent.Name as ParentName from Std_Student inner join Std_class on Std_Student.StudClassID = Std_class.ID inner join Std_EducationalYear on Std_class.EdyID = Std_EducationalYear.ID inner join Std_StudentType on Std_Student.type = Std_StudentType.ID inner join std_parent on std_parent.ID = Std_Student.ParentID";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }
    public override int save()
    {
        SqlParameter[] param = new SqlParameter[17];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@ParentID", _parentID, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@Address", _address, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Phone", _phone, SqlDbType.NVarChar, 50);
        param[7] = DataAccess.AddParamter("@Type", _type, SqlDbType.Int, 50);
        param[8] = DataAccess.AddParamter("@StudClassID", _class, SqlDbType.Int, 50);
        param[9] = DataAccess.AddParamter("@BirthDate", _birthDate, SqlDbType.DateTime, 50);
        param[10] = DataAccess.AddParamter("@Gender", _gender, SqlDbType.NVarChar, 500);
        param[11] = DataAccess.AddParamter("@Religion", _religion, SqlDbType.NVarChar, 500);
        param[12] = DataAccess.AddParamter("@LearningDisabilities", _learningDisabilities, SqlDbType.Int, 50);
        param[13] = DataAccess.AddParamter("@Note", _note, SqlDbType.NVarChar, 500);
        param[14] = DataAccess.AddParamter("@Father", _father, SqlDbType.Int, 50);
        param[15] = DataAccess.AddParamter("@Mother", _mother, SqlDbType.Int, 50);
        param[16] = DataAccess.AddParamter("@UserName", _userName, SqlDbType.NVarChar, 500);
        string sql = "insert into Std_Student(CreationDate,LastModifiedDate,OperatorID,Name,ParentID,Address,Phone,Type,StudClassID,BirthDate,Gender,Religion,LearningDisabilities,Note,Father,Mother,UserName) " +
            "values (@CreationDate,@LastModifiedDate,@OperatorID,@Name,@ParentID,@Address,@Phone,@Type,@StudClassID,@BirthDate,@Gender,@Religion,@LearningDisabilities,@Note,@Father,@Mother,@UserName)";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(id)as lastID from Std_Student";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());
            //save the student as customer
            Customer cs = new Customer();
            cs.Name = _name;
            cs.OperatorID = _operatorID;
            int cusID = cs.save();
            //save the customer product table
            try
            {
                InsertToMySql(_id);
                InsertUserToMySql(_id, _userName, _userName, _phone);
                InsertCustomerItem(cusID, _class);
            }
            catch (Exception ex)
            {
               
            }
            
            return _id;
        }
        return 0;
    }
    public void InsertToMySql(int ID) {
    
   string sql = "INSERT INTO `scl_student_information` (`id`) Values(11"+ID+")";
   DataAccess.ExecuteMySQLNonQuery(sql);
    }
    public void InsertUserToMySql(int ID, string name, string username, string password) 
    {
        string sql = "INSERT INTO `scl_users` (`id`, `name`, `username`, `email`, `password`, `block`, `sendEmail`, `registerDate`, `lastvisitDate`, `activation`, `params`, `lastResetTime`, `resetCount`, `otpKey`, `otep`, `requireReset`) " +
"VALUES (11" + ID + ", '"+name+"', '"+username+"', ''," +
"'$2y$10$jWwB4H81Om7zRCHCh6jIHOqItNrBMYzSGZ3P7cKYoiB0yFGbiK.Rq','0', '0', '', '', '', '', '0000-00-00 00:00:00', '0', '', '', '0');";
        DataAccess.ExecuteMySQLNonQuery(sql);
        sql = "INSERT INTO `scl_user_usergroup_map`(`user_id`, `group_id`) VALUES (11"+ID+",11)";
        DataAccess.ExecuteMySQLNonQuery(sql);
    }
    public void InsertCustomerItem(int cusID,int classId)
    {
        Customer cs = new Customer();
        //get the product id by class ID
        string sql = "select Fin_Product.ID,Fin_Product.Price from Fin_Product Inner join Int_EdyProduct on Fin_Product.ID = Int_EdyProduct.ProductID Inner join Std_Class on Std_Class.EdyID = Int_EdyProduct.EdyID Where Std_Class.ID = " + classId.ToString();
        DataTable intDT = DataAccess.ExecuteSQLQuery(sql);
        int CIId = 0;
        if (intDT != null && intDT.Rows != null && intDT.Rows.Count > 0)
        {
            CustomerItems ci = new CustomerItems();
            ci.CustomerID = cusID;
            ci.ProductID = int.Parse(intDT.Rows[0]["ID"].ToString());
            ci.Price = Decimal.Parse(intDT.Rows[0]["Price"].ToString());
            CIId = cs.addCustomerItem(int.Parse(intDT.Rows[0]["ID"].ToString()), Decimal.Parse(intDT.Rows[0]["Price"].ToString()), cusID);
        }

        //save the relation table
        sql = "Insert into Int_StdCustomer(StdID,CusID,CustItemID) Values(" + _id.ToString() + "," + cusID.ToString() + "," + CIId.ToString() + ")";
        DataAccess.ExecuteSQLNonQuery(sql);
        //return sql;
    }
    public int addAbsent(int stdID, int classID, DateTime date, int isAbsent,int operatorID)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = DataAccess.AddParamter("@StudentID", stdID, SqlDbType.Int, 50);
        param[1] = DataAccess.AddParamter("@classID", classID, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@AbsentDate", date, SqlDbType.DateTime, 50);
        param[3] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[4] = DataAccess.AddParamter("@OperatorID", operatorID, SqlDbType.Int, 50);



        string sql = "delete from Std_Absent where StudentID=@StudentID  and ClassID = @ClassID and AbsentDate = @AbsentDate";
        DataAccess.ExecuteSQLNonQuery(sql, param);
        if (isAbsent == 1)
        {
            sql = "insert into Std_Absent(CreationDate,OperatorID,AbsentDate,ClassID,StudentID) values(@CreationDate,@OperatorID,@AbsentDate,@ClassID,@StudentID)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
        }
        return 0;
    }
    public override int update()
    {
        Student s = new Student();
        s.get(_id);
        
        SqlParameter[] param = new SqlParameter[16];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@Name", _name, SqlDbType.NVarChar, 200);
        param[4] = DataAccess.AddParamter("@ParentID", _parentID, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@Address", _address, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@Phone", _phone, SqlDbType.NVarChar, 50);
        param[7] = DataAccess.AddParamter("@Type", _type, SqlDbType.Int, 50);
        param[8] = DataAccess.AddParamter("@StudClassID", _class, SqlDbType.Int, 50);
        param[9] = DataAccess.AddParamter("@BirthDate", _birthDate, SqlDbType.DateTime, 50);
        param[10] = DataAccess.AddParamter("@Gender", _gender, SqlDbType.NVarChar, 500);
        param[11] = DataAccess.AddParamter("@Religion", _religion, SqlDbType.NVarChar, 500);
        param[12] = DataAccess.AddParamter("@LearningDisabilities", _learningDisabilities, SqlDbType.Int, 50);
        param[13] = DataAccess.AddParamter("@Note", _note, SqlDbType.NVarChar, 500);
        param[14] = DataAccess.AddParamter("@Father", _father, SqlDbType.Int, 50);
        param[15] = DataAccess.AddParamter("@Mother", _mother, SqlDbType.Int, 50);
        
        string sql = "update Std_Student set LastModifiedDate = @LastModifiedDate,OperatorID = @OperatorID,Name=@Name,ParentID=@ParentID,Address=@Address,Phone=@Phone,Type=@Type,StudClassID=@StudClassID,BirthDate=@BirthDate"+
            ",Gender=@Gender,Religion=@Religion,LearningDisabilities=@LearningDisabilities,Note=@Note,Father=@Father,Mother=@Mother where ID = @ID";
        DataAccess.ExecuteSQLNonQuery(sql, param);
    //get the customer id
        sql = " select ID,CusID,CustItemID from Int_StdCustomer where StdID = " + _id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            int cusID = int.Parse(dt.Rows[0]["CusID"].ToString());
            //save the customer product table
            Customer c = new Customer();
            c.get(cusID);
            c.Name = _name;
            c.OperatorID = _operatorID;
            c.update();
            if (s._class != _class)
            {
                UpdateCustomerItem(cusID, _class, int.Parse(dt.Rows[0]["CustItemID"].ToString()), int.Parse(dt.Rows[0]["ID"].ToString()));
            }
        }
        //InsertToMySql(_id);
        //InsertUserToMySql(_id, _userName, _userName, _phone);
            return _id;
    
    }

    private void UpdateCustomerItem(int cusID, int _class,int CustItemID,int IntID)
    {
        string sql = "delete from Fin_CustomerItems where ID = " + CustItemID.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);

        sql = "delete from Int_StdCustomer where ID = " + IntID.ToString();
        DataAccess.ExecuteSQLNonQuery(sql);

        InsertCustomerItem(cusID, _class);
    }

    public DataTable getAbsent()
    {
        string sql = "select Std_Absent.*,Std_Class.Name as ClassName, Std_Student.Name as StudentName from Std_Absent inner join Std_Student on Std_Student.ID = StudentID inner join Std_Class on Std_Class.ID = Std_Absent.ClassID";
        return DataAccess.ExecuteSQLQuery(sql);
    }

    public DataTable getAbsent(int p)
    {
        string sql = "select * from Std_Absent where StudentID = " + p.ToString();
        return DataAccess.ExecuteSQLQuery(sql);
    }
}