using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for BasePage
/// </summary>

public class BasePage:Page
{
    protected override void InitializeCulture()
    {
        HttpCookie mylang = Request.Cookies["lang"];
      
        if (Request.Cookies["lang"]!= null)
            {
                string lang = Convert.ToString(mylang.Values["lang"].ToString());
            Culture = lang;
            UICulture = lang;
        }
        base.InitializeCulture();
    }
}
