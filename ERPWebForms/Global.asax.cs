using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace ERPWebForms
{
   
    public class Global : HttpApplication
    {
        public enum formSecurity
        {

            AddBank = 1,
            AddBranch = 2,
            AddCustomer = 3,
            AddInvoice = 4,
            AddJournalEntry = 5,
            AddProduct = 6,
            AddSupplier = 7,
            AddSupplierInvoice = 8,
            AllGLAccounts = 9,
            AllTransactions = 10,
            Banks = 11,
            Branches = 12,
            CloseFinancialYear = 13,
            CreateCustomerItem = 14,
            CreateFinancialYear = 15,
            CreateNewGLAccount = 16,
            Customers = 17,
            FinancialYears = 18,
            GLAccounts = 19,
            Invoices = 20,
            JournalEntries = 21,
            Products = 22,
            SupplierInvoices = 23,
            Suppliers = 24,
            ViewBank = 25,
            ViewBranch = 26,
            ViewCustomer = 27,
            ViewFinancialYear = 28,
            ViewGLAccount = 29,
            ViewInvoice = 30,
            ViewJournalEntry = 31,
            ViewProduct = 32,
            ViewSupplier = 33,
            ViewSupplierInvoice = 34,
            AddHoliday = 35,
            AddLeave = 36,
            AddLeaveType = 37,
            Bonus = 38,
            CreateBonus = 39,
            CreateDeduction = 40,
            CreateEmployee = 41,
            CreateJobCategory = 42,
            CreateJobtitle = 43,
            CreateKPI = 44,
            CreatePayGrade = 45,
            CreateReview = 46,
            CreatesheetStyle = 47,
            CreateTimeSheet = 48,
            CreateWorkShifts = 49,
            Deductions = 50,
            Employees = 51,
            EmployeeTS = 52,
            ExcelSheetStyle = 53,
            Holidays = 54,
            Import = 55,
            JobCategory = 56,
            JobTitles = 57,
            KPI = 58,
            Leaves = 59,
            LeaveTypes = 60,
            PayGrade = 61,
            Reviews = 62,
            Sallary = 63,
            SetUp = 64,
            ViewBonus = 65,
            ViewDeduction = 66,
            ViewEmployee = 67,
            ViewHoliday = 68,
            ViewJobCategory = 69,
            ViewJobtitle = 70,
            ViewKPI = 71,
            ViewLeave = 72,
            ViewLeaveType = 73,
            ViewPayGrade = 74,
            ViewReview = 75,
            ViewsheetStyle = 76,
            ViewTimeSheet = 77,
            ViewWorkShift = 78,
            WorkingDays = 79,
            WorkShifts = 80,
            Absent = 81,
            AddAbsent = 82,
            AddClass = 83,
            AddCourse = 84,
            AddDocuments = 85,
            AddExam = 86,
            AddExamDegree = 87,
            AddParent = 88,
            AddStudent = 89,
            AddTeacher = 90,
            AddYear = 91,
            Classes = 92,
            ClassSchedule = 93,
            CloseEducationalYear = 94,
            Courses = 95,
            Documents = 96,
            EducationYears = 97,
            Exams = 98,
            Parents = 99,
            Students = 100,
            Teachers = 101,
            ViewClass = 102,
            ViewCourse = 103,
            ViewDocuments = 104,
            ViewExam = 105,
            ViewParent = 106,
            ViewStudent = 107,
            ViewTeacher = 108,
            ViewYear = 109,
            AddRole=110,
            AddUser=111,
            Roles=112,
            Users=113


                    }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}