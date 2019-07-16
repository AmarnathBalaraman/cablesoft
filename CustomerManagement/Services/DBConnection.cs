using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerManagement.Services
{
    public class DBConnection
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;

        public DBConnection()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
        }

        public SqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                return null;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return dataTable;
        }//..End of Execute

        public DataTable executeSelectQueryWithSPNew(String _storedprocedure, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.CommandTimeout = 0;
                myCommand.Connection = openConnection();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = _storedprocedure;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                //MessageBox.Show(e.Message, "Error Message - A179");
                return null;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return dataTable;
        }//..End executeSelectQueryWithSPNew

        public DataSet executeSelectQueryNew(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
            }
            catch (SqlException e)
            {
                //MessageBox.Show(e.Message, "Error Message - A179");
                return null;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return ds;
        }//..End executeSelectQueryNew

        public DataSet executeSelectQueryNewDs(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            try
            {
                myCommand.CommandTimeout = 0;
                myCommand.Connection = openConnection();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
            }
            catch (SqlException e)
            {
                //MessageBox.Show(e.Message, "Error Message - A179");
                return null;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return ds;
        }//..End executeSelectQueryNew
    }
}