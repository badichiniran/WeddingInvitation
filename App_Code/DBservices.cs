using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBservices
/// </summary>
public class DBservices
{
        public SqlDataAdapter da;
        public DataTable dt;
        public string connectionString;
        public DBservices()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        }

        public SqlConnection connect()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                //Logger.writeToLog(LoggerLevel.ERROR, "page :DBServicesAPP.cs, function: connect(), exeption message: " + ex.Message);
                throw;
            }
        }

        public void disconnect(SqlConnection con)
        {
            if (con != null)
            {
                try
                {
                    con.Close();
                }
                catch (Exception ex)
                {
                   // Logger.writeToLog(LoggerLevel.ERROR, "page :DBServicesAPP.cs, function: disconnect(), exeption message: " + ex.Message);
                    throw;
                }
            }
        }

        public void FinishShopping(string name, string amount, string comment)
        {
            string InsertGuestQuery = "INSERT INTO [GuestList] ([Name],[Amount],[Comment]) VALUES ('" + name + "','" + amount + "','" + comment + "')";
            SqlConnection con;
            try
            {
                con = connect();
                da = new SqlDataAdapter(InsertGuestQuery, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            disconnect(con);
        }

}