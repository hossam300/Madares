using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ImportExcel
/// </summary>
public class ImportExcel
{
     int _styleID;
     public int StyleID {
         get { return _styleID; }
         set { _styleID = value; }
     }
    DataTable _excelSheet;
    public DataTable ExcelSheet 
    {
        get { return _excelSheet; }
        set { _excelSheet = value; }
    } 
	public ImportExcel()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public  DataTable SetGrid(DataTable Sheet,int Style)
    {
        DataTable grid = new DataTable();
        string sql = "select ItemName,ItemOrder from HR_SheetItems where SheetStyleID = " + Style.ToString() + " Order by ItemOrder";
        DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        DataTable dtItems = new DataTable();
        dtItems.Columns.Add("EmpTimeSheetID");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dtItems.Columns.Add(dt.Rows[i]["ItemName"].ToString());
        }
        for (int K = 0; K < Sheet.Rows.Count; K++)
        {


            DataRow dr = dtItems.NewRow();
            dr["EmpTimeSheetID"] = (K+1).ToString();
        for (int j = 0; j < dt.Rows.Count; j++)
        {
           
            dr[dt.Rows[j]["ItemName"].ToString()] = Sheet.Rows[K][dt.Rows[j]["ItemName"].ToString()].ToString();
        }
        dtItems.Rows.Add(dr); 
        }

        return dtItems;
    }
}