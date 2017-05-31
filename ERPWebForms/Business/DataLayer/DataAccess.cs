
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class DataAccess
    {

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString.ToString();
            }
        }
        public static string MySqlConnection { get 
        {
            return ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString.ToString();
        }
        }
        public static SqlParameter AddParamter(String ParameterName, object value, SqlDbType DbType, int size)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParameterName;
            param.Value = value.ToString();
            param.SqlDbType = DbType;
            param.Size = size;
            param.Direction = ParameterDirection.Input;
            return param;
        }
        public static DataTable ExecuteDTByProduct(string procedureName, SqlParameter[] Params)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = procedureName;
            cmd.Parameters.AddRange(Params);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            try
            {
                adapter.Fill(dTable);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
            return dTable;
        }

        public static int ExecuteSQLNonQuery(string SQL)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = SQL;
            
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            int res = 0;
            try
            {
                cmd.ExecuteNonQuery();
                res = 1;
            }
            catch (Exception ex)
            {
                res = 0;
            }
            finally
            {
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
            }
            return res;
        }

        public static int ExecuteMySQLNonQuery(string SQL)
        {
            
                //Connection string for Connector/ODBC 3.51
            //string host = "127.0.0.1"; // The IP address 127.0.0.1 is the same as "localhost" - it just means "this machine"
            //string database = "school";    // If this database doesn't already exist we'll create it
            //string user = "root";      // Default WampServer MySQL username
            //string password = "";          // Default WampServer MySQL password (no password!)
            // // Create a provider string from our details
            //string MyConString = "Data Source=" + host
            //            + ";Database=" + database
            //            + ";User ID=" + user
            string host = "188.121.44.193"; // The IP address 127.0.0.1 is the same as "localhost" - it just means "this machine"
            string database = "futureeg2016_horya";    // If this database doesn't already exist we'll create it
            string user = "futureeg2016";      // Default WampServer MySQL username
            string password = "Futureeg@2016";          // Default WampServer MySQL password (no password!)
            // Create a provider string from our details
            string MyConString = "Data Source=" + host
                        + ";Database=" + database
                        + ";User ID=" + user
                        + ";Password=" + password;
                //Connect to MySQL using Connector/ODBC
            MySqlConnection conn = conn = new MySqlConnection(MyConString);
                try
                {
                     conn.Open();
                }
                catch (Exception ex)
                {

                   // var e = ex.Message;
                }
         //       conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                //  cmd.CommandText = SQL;

                // cmd.CommandType = CommandType.Text;
              //   cmd.ExecuteNonQuery();
                //MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

                int res = 0;
                try
                {
                    cmd.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception ex)
                {
                    res = 0;
                }
            
            finally
            {
             //   adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
            }
                return res;
            
        }
        public static int ExecuteSQLNonQuery(string SQL , SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = SQL;
            cmd.Parameters.AddRange( param);

            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            int res = 0;
            try
            {
                cmd.ExecuteNonQuery();
                res = 1;
            }
            catch (Exception ex)
            {
                res = 0;
            }
            finally
            {
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
            }
            return res;
        }
        public static DataTable ExecuteSQLQuery(string SQL,SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = SQL;
            cmd.Parameters.AddRange(param);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            //int res = 0;
            try
            {
                adapter.Fill(dTable);
                //res = 1;
            }
            catch (Exception ex)
            {
                //  res = 0;
            }
            finally
            {
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
            }
            return dTable;
        }
        public static DataTable ExecuteSQLQuery(string SQL)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = SQL;

            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            //int res = 0;
            try
            {
                adapter.Fill(dTable);
                //res = 1;
            }
            catch (Exception ex)
            {
              //  res = 0;
            }
            finally
            {
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
            }
            return dTable;
        }
    }
