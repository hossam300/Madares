using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee : baseObject
{
    public enum SourceLUT
    {
        Basic = 1,
        Variable = 2,
        allawance = 3,
        BasicAndVariable = 4,
        total = 5
    }
    public enum MaritalStatusLUT
    {
        Single = 1,
        Married = 2,
        divorced = 3
    }

    public enum Qualifications
    {
        
    }

    enum Religons
    {
        Muslim = 1,
        Christian = 2
    }

    public enum NatureLUT
    {
        Deserved = 1,
        Liability = 2
    }

    public enum TypeLUT
    {
        Basic = 1,
        Variable = 2,
        allawance = 3,
        Liabilty = 4,
        others =5
    }

    string _empName;

    public string EmpName
    {
        get { return _empName; }
        set { _empName = value; }
    }
    decimal _sallary;

    public decimal Sallary
    {
        get { return _sallary; }
        set { _sallary = value; }
    }
    string _specialty;

    public string Specialty
    {
        get { return _specialty; }
        set { _specialty = value; }
    }

    int _reportTo;

    public int ReportTo
    {
        get { return _reportTo; }
        set { _reportTo = value; }
    }
    string _nationality;

    public string Nationality
    {
        get { return _nationality; }
        set { _nationality = value; }
    }
    DateTime _hiringDate;

    public DateTime HiringDate
    {
        get { return _hiringDate; }
        set { _hiringDate = value; }
    }
    string _empCode;
    public string EmpCode
    {
        get { return _empCode; }
        set { _empCode = value; }
    }
    int _jobtitleID;
    public int JobTitleID
    {
        get { return _jobtitleID; }
        set { _jobtitleID = value; }
    }
int _jobCategoryID;
    public int JobCategoryID
    {
        get { return _jobCategoryID; }
        set { _jobCategoryID = value; }
    }
int _payGradeID;
    public int PayGradeID
    {
        get { return _payGradeID; }
        set { _payGradeID = value; }
    }

    public string IDNumber { get; set; }

    public string Address { get; set; }
    public int TeleNumber { get; set; }
    public int MaritalStatus { get; set; }
    public string Experience { get; set; }
    public int Qualification { get; set; }
    public int GraduationYear { get; set; }
    public int Religion { get; set; }
    
    public DateTime ResignDate { get; set; }
	public Employee()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable getSalary(int month, int year)
    {
        DataTable res = new DataTable();
        string sql = "select * from HR_EmpSallary inner join HR_EmpSallaryItems on HR_EmpSallaryItems.EmpSallaryID = HR_EmpSallary.ID where Year = " + year.ToString() + " and Month = " + month.ToString();
        DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
        if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
        {
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (!res.Columns.Contains(dt2.Rows[i]["sallaryItem"].ToString()))
                {
                    res.Columns.Add(dt2.Rows[i]["sallaryItem"].ToString());
                }
            }
            int PEmpID = 0,EmpID =0 ;
            DataRow dr = res.NewRow();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (dt2.Rows[i]["sallaryItem"].ToString() == "EmpID")
                {
                    EmpID = Convert.ToInt32(dt2.Rows[i]["Value"].ToString());
                }
                if (EmpID != PEmpID)
                {
                    if (PEmpID != 0)
                    {
                        
                        res.Rows.Add(dr);
                       // payGradeID = int.Parse(dt.Rows[i]["PayGradeID"].ToString());
                    }
                    dr = res.NewRow();
                  /*  dr["EmpID"] = dt2.Rows[i]["EmpID"].ToString();
                    dr["EmpName"] = dt2.Rows[i]["EmpName"].ToString();
                    dr["EmpCode"] = dt2.Rows[i]["EmpCode"].ToString();
                    dr["Paid"] = Convert.ToBoolean(false);*/
                    PEmpID = EmpID;
                }

                dr[dt2.Rows[i]["sallaryItem"].ToString()] = dt2.Rows[i]["Value"].ToString();


            }
            if (EmpID != 0 && dr != null)
                res.Rows.Add(dr);
        }
        else
        {
            sql = "select EmpID, EmpName,EmpCode,HR_Employees.PayGradeID,Name as SalaryItemName,Value as SalaryItemValue from HR_Employees inner join HR_payGradesSallary on HR_Employees.PayGradeID = HR_payGradesSallary.PayGradeID order by EmpID";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);

            res.Columns.Add("EmpID");
            res.Columns.Add("EmpName");
            res.Columns.Add("EmpCode");
            sql = "select distinct HR_payGradesSallary.Name,HR_payGradesSallary.Nature,[Order] from HR_payGradesSallary inner join HR_SallarySheetItems on HR_SallarySheetItems.Name = HR_payGradesSallary.Name order by HR_payGradesSallary.Nature,[Order]";
            DataTable dtc = DataAccess.ExecuteSQLQuery(sql);
            
            for (int i = 0; i < dtc.Rows.Count; i++)
            {

                res.Columns.Add(dtc.Rows[i]["Name"].ToString());
            }
            res.Columns.Add("Rewards");
            res.Columns.Add("totalDeserved");
            res.Columns.Add("totalPenalty");
            res.Columns.Add("VacationsWithDeduction");
            res.Columns.Add("totalLiability");
            res.Columns.Add("FinalSalary");
            res.Columns.Add("Paid");
            DataRow dr = null;
            int PEmpID = 0;
            int payGradeID = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (payGradeID == 0)
                {
                    payGradeID = int.Parse(dt.Rows[i]["PayGradeID"].ToString());
                }
                if (Convert.ToInt32(dt.Rows[i]["EmpID"].ToString()) != PEmpID)
                {
                    if (PEmpID != 0)
                    {
                        
                        calcTotal(dr, payGradeID);
                        calcReward(dr, PEmpID, month, year);
                        res.Rows.Add(dr);
                        payGradeID = int.Parse(dt.Rows[i]["PayGradeID"].ToString());
                    }
                    dr = res.NewRow();
                    dr["EmpID"] = dt.Rows[i]["EmpID"].ToString();
                    dr["EmpName"] = dt.Rows[i]["EmpName"].ToString();
                    dr["EmpCode"] = dt.Rows[i]["EmpCode"].ToString();
                    dr["Paid"] = Convert.ToBoolean(false);
                    PEmpID = Convert.ToInt32(dt.Rows[i]["EmpID"].ToString());
                }

                dr[dt.Rows[i]["SalaryItemName"].ToString()] = dt.Rows[i]["SalaryItemValue"].ToString();

            }
            if (dr != null)
            {
                calcTotal(dr, payGradeID);
                res.Rows.Add(dr);
            }
        }
        return res;

    }

    private void calcReward(DataRow dr, int EmpID, int Month,int year)
    {
        decimal reward = 0, penility = 0,leavesDeduction = 0 ;

        decimal totalSalary = decimal.Parse(dr["FinalSalary"].ToString());
        decimal totalDeserved = decimal.Parse(dr["totalDeserved"].ToString());
        decimal totalLiability = decimal.Parse(dr["totalLiability"].ToString());
        string sql = "select * from HR_Bonces where Year =  " + year.ToString() + " and Month =" + Month.ToString() + " and EmpID = " + EmpID.ToString() + " and Nature = 1";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //calculate the reward
            if(int.Parse(dt.Rows[i]["Type"].ToString()) == 1)//percentage
            {
                reward += decimal.Parse(dt.Rows[i]["Value"].ToString()) * totalSalary/30;  
            }
            else if(int.Parse(dt.Rows[i]["Type"].ToString()) == 2)//Amount
            {
                reward += decimal.Parse(dt.Rows[i]["Value"].ToString());
                
            }
        }

        sql = "select * from HR_Bonces where Year =  " + year.ToString() + " and Month =" + Month.ToString() + " and EmpID = " + EmpID.ToString() + " and Nature = 2";
        dt = DataAccess.ExecuteSQLQuery(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //calculate the penility
            if(int.Parse(dt.Rows[i]["Type"].ToString()) == 1)//percentage
            {
                penility+= decimal.Parse(dt.Rows[i]["Value"].ToString()) * totalSalary/30;  
            }
            else if(int.Parse(dt.Rows[i]["Type"].ToString()) == 2)//Amount
            {
                penility += decimal.Parse(dt.Rows[i]["Value"].ToString());
                
            }
        }
        //vacations with deduction
        sql = "select * from HR_Leaves inner join HR_LeaveType on HR_Leaves.LeaveTypeID= HR_LeaveType.LeaveTypeID where HR_LeaveType.Deduction =1 and EmpID = " + EmpID.ToString();
        dt = DataAccess.ExecuteSQLQuery(sql);
        DateTime stDt, edDt,mSdt,mEDT;
        decimal NoOfDays = 0;
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            mSdt = new DateTime(year,Month,1);
            mEDT = new DateTime(year,Month,DateTime.DaysInMonth(year,Month));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime.TryParse(dt.Rows[i]["FromDate"].ToString(), out stDt);
                DateTime.TryParse(dt.Rows[i]["ToDate"].ToString(), out edDt);
                 //st dt < 1st day and ed < last day
                if (stDt < mSdt && edDt < mEDT && edDt > mSdt)
                    NoOfDays = (decimal)(edDt - mSdt).TotalDays;
                //st < 1st day and ed > last day
                else if (stDt < mSdt && edDt > mEDT)
                    NoOfDays = 30;
                else if (stDt < mSdt && edDt < mSdt)
                    NoOfDays = 0;
                //st > 1st day and ed < last day
                else if (stDt > mSdt && edDt < mEDT)
                    NoOfDays = (decimal)(edDt - stDt).TotalDays;
                //st > 1st day and ed > last day
                else if (stDt > mSdt && edDt > mEDT && stDt < mEDT)
                    NoOfDays = (decimal)(mEDT - stDt).TotalDays;
                else if (stDt < mEDT)
                    NoOfDays = 0;
                leavesDeduction += NoOfDays * decimal.Parse(dt.Rows[i]["DeductionValue"].ToString()) * totalSalary / 30;
            }
        }

        dr["totalPenalty"] = penility;
        dr["VacationsWithDeduction"] =Math.Round( leavesDeduction,2) ;
        dr["Rewards"] = reward;
        totalDeserved += reward;
        totalLiability += penility + Math.Round(leavesDeduction, 2);
        totalSalary = totalDeserved - totalLiability;
       
        dr["totalDeserved"] = totalDeserved;
        dr["totalLiability"] = totalLiability;
        dr["FinalSalary"] = totalSalary;

        /*sql = "select (select SUM(value) from HR_Bonces where Year = " + year.ToString() + " and Month =" + Month.ToString() + "   and EmpID = " + EmpID.ToString() + " and Nature = 1) as totalReword,(select SUM(value) from HR_Bonces where Year =  " + year.ToString() + " and Month =" + Month.ToString() + " and EmpID = " + EmpID.ToString() + " and Nature = 2) as totalPenlity ,empID from HR_Bonces group by EmpID  ";
        dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            if(dt.Rows[0]["totalPenlity"] != DBNull.Value)
                dr["totalPenalty"] = dt.Rows[0]["totalPenlity"].ToString();
            else
                dr["totalPenalty"] = 0;

            if (dt.Rows[0]["totalReword"] != DBNull.Value)
                dr["Rewards"] = dt.Rows[0]["totalReword"].ToString();
            else
                dr["Rewards"] = 0;
        }
        else
        {
            dr["totalPenalty"] = 0;
            dr["Rewards"] = 0;
        }*/
    }


    private void calcTotal(DataRow dr,int payGradID)
    {
        string sql = "select distinct HR_payGradesSallary.Name,Value,Percentage,HR_payGradesSallary.Nature,HR_payGradesSallary.type,source,[order] from HR_payGradesSallary inner join HR_SallarySheetItems on HR_SallarySheetItems.Name = HR_payGradesSallary.Name where PayGradeID= " + payGradID.ToString() + " order by Nature,[order]";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        decimal totalDeserved = 0, totalLiability = 0, totalSalary = 0;
        decimal value = 0, basic = 0,variable = 0, allowance =0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if(int.Parse(dt.Rows[i]["type"].ToString()) == (int)TypeLUT.Basic && dr[dt.Rows[i]["Name"].ToString()].ToString() != string.Empty)
                basic += decimal.Parse(dr[dt.Rows[i]["Name"].ToString()].ToString());
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dr[dt.Rows[i]["Name"].ToString()].ToString() != string.Empty)
            {
                if (int.Parse(dt.Rows[i]["Percentage"].ToString()) == 1) //percentage = true
                {
                    //calculate the value
                    switch (int.Parse(dt.Rows[i]["source"].ToString()))
                    {
                        case (int)SourceLUT.Basic:
                            {
                                value = decimal.Parse(dr[dt.Rows[i]["Name"].ToString()].ToString()) * basic / 100;
                                dr[dt.Rows[i]["Name"].ToString()] = value;
                                if (int.Parse(dt.Rows[i]["type"].ToString()) == (int)TypeLUT.Variable)
                                {
                                    variable += value;
                                }
                                break;
                            }
                        case (int)SourceLUT.Variable:
                            {
                                value = decimal.Parse(dr[dt.Rows[i]["Name"].ToString()].ToString()) * variable / 100;
                                dr[dt.Rows[i]["Name"].ToString()] = value;
                                if (int.Parse(dt.Rows[i]["type"].ToString()) == (int)TypeLUT.allawance)
                                {
                                    allowance += value;
                                }
                                break;
                            }
                        case (int)SourceLUT.allawance:
                            {
                                value = decimal.Parse(dr[dt.Rows[i]["Name"].ToString()].ToString()) * allowance / 100;
                                dr[dt.Rows[i]["Name"].ToString()] = value;
                                
                                break;
                            }
                        case (int)SourceLUT.BasicAndVariable:
                            {
                                value = decimal.Parse(dr[dt.Rows[i]["Name"].ToString()].ToString()) * (basic+variable)/ 100;
                                dr[dt.Rows[i]["Name"].ToString()] = value;
                                
                                break;
                            }
                        case (int)SourceLUT.total:
                            {
                                value = decimal.Parse(dr[dt.Rows[i]["Name"].ToString()].ToString()) * (basic+variable+allowance) / 100;
                                dr[dt.Rows[i]["Name"].ToString()] = value;
                                
                                break;
                            }
                    }


                }
             

                if (int.Parse(dt.Rows[i]["Nature"].ToString()) == (int)NatureLUT.Deserved)//deserved
                {
                    totalDeserved += decimal.Parse(dr[dt.Rows[i]["Name"].ToString()].ToString());

                }
                else if (int.Parse(dt.Rows[i]["Nature"].ToString()) == (int)NatureLUT.Liability)//liablilty
                {
                    if (dr[dt.Rows[i]["Name"].ToString()].ToString() != string.Empty)
                        totalLiability += decimal.Parse(dr[dt.Rows[i]["Name"].ToString()].ToString());
                }
            }
        }
        totalSalary = totalDeserved - totalLiability;
        dr["totalDeserved"] = totalDeserved;
        dr["totalLiability"] = totalLiability;
        dr["FinalSalary"] = totalSalary;
    }
    public override int get(int id)
    {
        string sql = "select * from HR_Employees where EmpID = " + id.ToString();
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            DateTime.TryParse(dt.Rows[0]["CreationDate"].ToString(), out _creationDate);
            DateTime.TryParse(dt.Rows[0]["LastModifiedDate"].ToString(), out _lastModifiedDate);
            int.TryParse(dt.Rows[0]["OperatorID"].ToString(), out _operatorID);
            _id = id;
            _empName = dt.Rows[0]["EmpName"].ToString();
            Decimal.TryParse(dt.Rows[0]["Sallary"].ToString(), out _sallary);
            _specialty = dt.Rows[0]["Specialty"].ToString();
            int.TryParse(dt.Rows[0]["ReportTo"].ToString(), out _reportTo);
            _nationality = dt.Rows[0]["Nationality"].ToString();
            DateTime.TryParse(dt.Rows[0]["HiringDate"].ToString(), out  _hiringDate);
            _empCode = dt.Rows[0]["EmpCode"].ToString();
            int.TryParse(dt.Rows[0]["JobTitleID"].ToString(), out _jobtitleID);
            int.TryParse(dt.Rows[0]["JobCategoryID"].ToString(), out _jobCategoryID);
            int.TryParse(dt.Rows[0]["PayGradeID"].ToString(), out _payGradeID);

            Religion = dt.Rows[0]["Religion"]==DBNull.Value?1: int.Parse(dt.Rows[0]["Religion"].ToString());
            Qualification = dt.Rows[0]["Qualification"] == DBNull.Value ? 1 : int.Parse(dt.Rows[0]["Qualification"].ToString());
            MaritalStatus = dt.Rows[0]["MartrialStatus"] == DBNull.Value ? 1 : int.Parse(dt.Rows[0]["MartrialStatus"].ToString());
            IDNumber = dt.Rows[0]["IDNumber"].ToString();
            Address = dt.Rows[0]["Address"].ToString();
            TeleNumber = dt.Rows[0]["TelephoneNo"] == DBNull.Value ? 0 : int.Parse(dt.Rows[0]["TelephoneNo"].ToString());
            GraduationYear = dt.Rows[0]["GraduationYear"] == DBNull.Value ? 0 : int.Parse(dt.Rows[0]["GraduationYear"].ToString());
            Experience = dt.Rows[0]["Experience"].ToString();
            ResignDate = dt.Rows[0]["ResignDate"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dt.Rows[0]["ResignDate"].ToString());
            /*
             *  ddlReligion.SelectedValue = emp.Religion.ToString() ;
                        ddlQualification.SelectedValue = emp.Qualification.ToString();
                        ddlMaritalStatus.SelectedValue = emp.MaritalStatus.ToString();
                        txtIDNumber.Text = emp.IDNumber;
                        txtAddress.Text = emp.Address;
                        txtTelephoneNo.Text = emp.TeleNumber.ToString();
                        txtGraduationYear.Text = emp.GraduationYear.ToString();
                        txtExperience.Text = emp.Experience;
                        if (emp.ResignDate != DateTime.MinValue)
                            txtResignDate.Text = emp.ResignDate.ToShortDateString();
             */

        }
        return id;
    }

    public override DataTable getList()
    {
        string sql = "select * from HR_Employees ";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        return dt;
    }

    public override int save()
    {
        SqlParameter[] param;
        if (ResignDate != DateTime.MinValue)
            param = new SqlParameter[22];
        else
            param = new SqlParameter[21];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@Creationdate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@EmpName", _empName, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Sallary", _sallary, SqlDbType.Decimal, 50);
        param[5] = DataAccess.AddParamter("@Specialty", _specialty, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@ReportTo", _reportTo, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@Nationality", _nationality, SqlDbType.NVarChar, 500);
        param[8] = DataAccess.AddParamter("@HiringDate", _hiringDate, SqlDbType.DateTime, 50);
        param[9] = DataAccess.AddParamter("@EmpCode", _empCode, SqlDbType.NVarChar, 500);
        param[10] = DataAccess.AddParamter("@JobTitleID", _jobtitleID, SqlDbType.Int, 50);
        param[11] = DataAccess.AddParamter("@JobCategoryID", _jobCategoryID, SqlDbType.Int, 50);
        param[12] = DataAccess.AddParamter("@PayGradeID", _payGradeID, SqlDbType.Int, 50);

        param[13] = DataAccess.AddParamter("@IDNumber", IDNumber, SqlDbType.Int, 50);
        param[14] = DataAccess.AddParamter("@TelephoneNo", TeleNumber, SqlDbType.Int, 50);
        param[15] = DataAccess.AddParamter("@MartrialStatus", MaritalStatus, SqlDbType.Int, 50);
        param[16] = DataAccess.AddParamter("@Qualification", Qualification, SqlDbType.Int, 50);
        param[17] = DataAccess.AddParamter("@Religion", Religion, SqlDbType.Int, 50);
        param[18] = DataAccess.AddParamter("@GraduationYear", GraduationYear, SqlDbType.Int, 50);
        param[19] = DataAccess.AddParamter("@Address", Address, SqlDbType.NVarChar, 250);
        param[20] = DataAccess.AddParamter("@Experience", Experience, SqlDbType.NVarChar, 250);
        if(ResignDate != DateTime.MinValue)
            param[21] = DataAccess.AddParamter("@ResignDate", ResignDate, SqlDbType.DateTime, 50);

        string sql = "";
        if (ResignDate != DateTime.MinValue)

        {
            sql = "INSERT INTO [dbo].[HR_Employees] ([EmpName] ,[Sallary],[Specialty],[ReportTo],[Nationality],[HiringDate],[CreationDate],[LastModifiedDate],[OperatorID]," +
            "[EmpCode],[JobTitleID],[JobCategoryID],[PayGradeID],IDNumber,TelephoneNo,MartrialStatus,Qualification,Religion,GraduationYear,Address,Experience,ResignDate) " +
            "values (@EmpName,@Sallary,@Specialty,@ReportTo,@Nationality,@HiringDate,@Creationdate,@LastModifiedDate,@OperatorID,@EmpCode,@JobTitleID,@JobCategoryID,@PayGradeID," +
            "@IDNumber,@TelephoneNo,@MartrialStatus,@Qualification,@Religion,@GraduationYear,@Address,@Experience,@ResignDate)";
        }
        else
        {
            sql = "INSERT INTO [dbo].[HR_Employees] ([EmpName] ,[Sallary],[Specialty],[ReportTo],[Nationality],[HiringDate],[CreationDate],[LastModifiedDate],[OperatorID]," +
            "[EmpCode],[JobTitleID],[JobCategoryID],[PayGradeID],IDNumber,TelephoneNo,MartrialStatus,Qualification,Religion,GraduationYear,Address,Experience) " +
            "values (@EmpName,@Sallary,@Specialty,@ReportTo,@Nationality,@HiringDate,@Creationdate,@LastModifiedDate,@OperatorID,@EmpCode,@JobTitleID,@JobCategoryID,@PayGradeID," +
            "@IDNumber,@TelephoneNo,@MartrialStatus,@Qualification,@Religion,@GraduationYear,@Address,@Experience)";
        }
        DataAccess.ExecuteSQLNonQuery(sql, param);
        //get last id
        sql = "select max(EmpID)as lastID from HR_Employees";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
        {
            _id = int.Parse(dt.Rows[0]["lastID"].ToString());

            return _id;
        }
        return 0;
    }

    public override int update()
    {
        SqlParameter[] param;
        if(ResignDate == DateTime.MinValue)
            param = new SqlParameter[21];
        else
            param = new SqlParameter[22];
        param[0] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@ID", _id, SqlDbType.Int, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", _operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@EmpName", _empName, SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Sallary", _sallary, SqlDbType.Decimal, 50);
        param[5] = DataAccess.AddParamter("@Specialty", _specialty, SqlDbType.NVarChar, 500);
        param[6] = DataAccess.AddParamter("@ReportTo", _reportTo, SqlDbType.Int, 50);
        param[7] = DataAccess.AddParamter("@Nationality", _nationality, SqlDbType.NVarChar, 500);
        param[8] = DataAccess.AddParamter("@HiringDate", _hiringDate, SqlDbType.DateTime, 50);
        param[9] = DataAccess.AddParamter("@EmpCode", _empCode, SqlDbType.NVarChar, 500);
        param[10] = DataAccess.AddParamter("@JobTitleID", _jobtitleID, SqlDbType.Int, 50);
        param[11] = DataAccess.AddParamter("@JobCategoryID", _jobCategoryID, SqlDbType.Int, 50);
        param[12] = DataAccess.AddParamter("@PayGradeID", _payGradeID, SqlDbType.Int, 50);

        param[13] = DataAccess.AddParamter("@IDNumber", IDNumber, SqlDbType.Int, 50);
        param[14] = DataAccess.AddParamter("@TelephoneNo", TeleNumber, SqlDbType.Int, 50);
        param[15] = DataAccess.AddParamter("@MartrialStatus", MaritalStatus, SqlDbType.Int, 50);
        param[16] = DataAccess.AddParamter("@Qualification", Qualification, SqlDbType.Int, 50);
        param[17] = DataAccess.AddParamter("@Religion", Religion, SqlDbType.Int, 50);
        param[18] = DataAccess.AddParamter("@GraduationYear", GraduationYear, SqlDbType.Int, 50);
        param[19] = DataAccess.AddParamter("@Address", Address, SqlDbType.NVarChar, 250);
        param[20] = DataAccess.AddParamter("@Experience", Experience, SqlDbType.NVarChar, 250);
        if (ResignDate != DateTime.MinValue)
            param[21] = DataAccess.AddParamter("@ResignDate", ResignDate, SqlDbType.DateTime, 50);
        string sql = "";
        if (ResignDate == DateTime.MinValue)
        {
            sql = "UPDATE [dbo].[HR_Employees] SET [EmpName] = @EmpName,[Sallary] = @Sallary ,[Specialty] = @Specialty ,[ReportTo] = @ReportTo ,[Nationality] = @Nationality," +
        "[HiringDate] = @HiringDate,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID,[EmpCode]=@EmpCode,[JobTitleID]=@JobTitleID,[JobCategoryID]=@JobCategoryID," +
        "[PayGradeID]=@PayGradeID, IDNumber = @IDNumber,TelephoneNo=@TelephoneNo,MartrialStatus=@MartrialStatus,Qualification=@Qualification,Religion=@Religion,GraduationYear=@GraduationYear," +
        "Address=@Address,Experience=@Experience " +
        "WHERE EmpID=@ID";
        }
        else
        {
            sql = "UPDATE [dbo].[HR_Employees] SET [EmpName] = @EmpName,[Sallary] = @Sallary ,[Specialty] = @Specialty ,[ReportTo] = @ReportTo ,[Nationality] = @Nationality," +
        "[HiringDate] = @HiringDate,[LastModifiedDate] = @LastModifiedDate,[OperatorID] = @OperatorID,[EmpCode]=@EmpCode,[JobTitleID]=@JobTitleID,[JobCategoryID]=@JobCategoryID," +
        "[PayGradeID]=@PayGradeID, IDNumber = @IDNumber,TelephoneNo=@TelephoneNo,MartrialStatus=@MartrialStatus,Qualification=@Qualification,Religion=@Religion,GraduationYear=@GraduationYear," +
        "Address=@Address,Experience=@Experience,ResignDate=@ResignDate " +
        "WHERE EmpID=@ID";
        }
        DataAccess.ExecuteSQLNonQuery(sql, param);
        return _id;
       
    }
    
    public void saveSallary(int Month, int Year,int operatorID, DataRow EmpData)
    {
        int isPaid = 0;
        
        string sql = "select ID,isPaid from HR_EmpSallary where Year = " + Year.ToString() + " and Month = " + Month.ToString() + " and EmpID = " + EmpData["EmpID"].ToString() ;
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        if(dt != null && dt.Rows != null && dt.Rows.Count>0)
        {
            int.TryParse(dt.Rows[0]["isPaid"].ToString(), out isPaid);
        }
        int paid = Convert.ToBoolean(EmpData["Paid"].ToString()) ? 1 : 0;
        SqlParameter[] param = new SqlParameter[7];
        param[0] = DataAccess.AddParamter("@CreationDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[1] = DataAccess.AddParamter("@LastModifiedDate", DateTime.Now, SqlDbType.DateTime, 50);
        param[2] = DataAccess.AddParamter("@OperatorID", operatorID, SqlDbType.Int, 50);
        param[3] = DataAccess.AddParamter("@EmpID", EmpData["EmpID"].ToString(), SqlDbType.NVarChar, 500);
        param[4] = DataAccess.AddParamter("@Year", Year, SqlDbType.Int, 50);
        param[5] = DataAccess.AddParamter("@Month", Month, SqlDbType.Int, 50);
        param[6] = DataAccess.AddParamter("@isPaid", paid, SqlDbType.Int, 50);
        
        sql = "delete from HR_EmpSallaryItems where EmpSallaryID in (select ID from HR_EmpSallary where Year = " + Year.ToString() + " and Month = " + Month.ToString() + " and EmpID = " + EmpData["EmpID"].ToString() + ")";
        DataAccess.ExecuteSQLNonQuery(sql);
        sql = " delete from HR_EmpSallary where Year = " + Year.ToString() + " and Month = " + Month.ToString() + " and EmpID = " + EmpData["EmpID"].ToString();
        DataAccess.ExecuteSQLNonQuery(sql);
        sql = "insert into HR_EmpSallary(CreationDate,LastModifiedDate,OperatorID,EmpID,Year,Month,isPaid) values(@CreationDate,@LastModifiedDate,@OperatorID,@EmpID,@Year,@Month,@isPaid)";
        DataAccess.ExecuteSQLNonQuery(sql,param);
        sql = "select Max(ID)as lastID from HR_EmpSallary";
        dt = DataAccess.ExecuteSQLQuery(sql);
        int id = 0;
        if(dt!=null && dt.Rows!= null && dt.Rows.Count>0)
        {
            int.TryParse(dt.Rows[0]["lastID"].ToString(),out id);
        }
        for (int i = 0; i < EmpData.Table.Columns.Count; i++)
        {
            sql = "insert into HR_EmpSallaryItems(EmpSallaryID,sallaryItem,Value) values("+id.ToString()+",N'"+EmpData.Table.Columns[i].ToString()+"',N'"+EmpData[EmpData.Table.Columns[i].ToString()].ToString()+"')";
            DataAccess.ExecuteSQLNonQuery(sql);
        }
        //make the financial account entries if the item was not paid and paid now
        if(isPaid ==0 && paid == 1)
        {
            sql = "select * from HR_SallaryGLAcct";
            DataTable set = DataAccess.ExecuteSQLQuery(sql);
            if (set != null && set.Rows != null && set.Rows.Count > 0)
            {
                JournalEntry je = new JournalEntry();
                je.Description = "Pay Sallary for Emp: " + EmpData["EmpName"].ToString() + " " + Month.ToString() + "/" + Year.ToString();
                je.Amount = decimal.Parse(EmpData["FinalSalary"].ToString());
                je.OperatorID = _operatorID;
                //depit from the cash account (asset account)
                je.addJERow(int.Parse(set.Rows[0]["SallaryDPGLID"].ToString()), 0, je.Amount, "Depit for Paying sallary for Emp: " + EmpData["EmpName"].ToString() + " " + Month.ToString() + "/" + Year.ToString(), int.Parse(set.Rows[0]["SallaryDPGLID"].ToString()) < 0 ? 1 : 0);
                //credit the sallary account (expense account)
                je.addJERow(int.Parse(set.Rows[0]["SallaryCRGLID"].ToString()), je.Amount, 0, "Credit for Paying sallary for Emp: " + EmpData["EmpName"].ToString()+ " " + Month.ToString() + "/" + Year.ToString(), int.Parse(set.Rows[0]["SallaryCRGLID"].ToString()) < 0 ? 1 : 0);
                je.save();
            }
        }
    }

    public void paySallary(int Empid, int Month, int Year)
    {
//        update
    }
}