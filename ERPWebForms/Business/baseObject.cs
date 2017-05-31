using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for baseObject
/// </summary>
public abstract class baseObject
{
    protected int _id;
    protected int _operatorID;
    protected DateTime _creationDate;
    protected DateTime _lastModifiedDate;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public int OperatorID
    {
        get { return _operatorID; }
        set { _operatorID = value; }
    }

    public DateTime CreationDate
    {
        get { return _creationDate; }
        set { _creationDate = value; }
    }

    public DateTime LastModifiedDate
    {
        get { return _lastModifiedDate; }
        set { _lastModifiedDate = value; }
    }

    public abstract int get(int id);
    
    public abstract DataTable getList();
    

    public abstract int save();
   
    public abstract int update();
    

	public baseObject()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}