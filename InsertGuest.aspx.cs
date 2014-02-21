using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InsertGuest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBservices dbs = new DBservices();
        if (Request.QueryString == null)
        {
            Response.End();
            return;
        }
        NameValueCollection requestQuery = Request.QueryString;

        try
        {
            string name = requestQuery["name"];
            string amount = requestQuery["amount"];
            //string comment = requestQuery["comment"];
            dbs.FinishShopping(name,amount,"NULL");

        }

        catch (Exception ex)
        {
           // Logger.writeToLog(LoggerLevel.ERROR, "page :ActivityShow.aspx.cs, the exeption message is : " + ex.Message);

        }



        Response.End();

    }


}