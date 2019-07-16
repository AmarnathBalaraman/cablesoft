using CustomerManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerManagement.Services
{
    public class HomeService
    {
        //Db Connection string
        string DBCon = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
        SystemTools _SystemTools = new SystemTools();

        public DashboardModels DashboardStats(String OperatorId)
        {
            DashboardModels _DashboardModels = new DashboardModels();

            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DashboardStats", conn);//call Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OperatorId",OperatorId);
                SqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    _DashboardModels.UsersList = reader["UsersList"].ToString();
                    _DashboardModels.ActiveUsers = reader["ActiveUsers"].ToString();
                    _DashboardModels.InActiveUsers = reader["InActiveUsers"].ToString();
                    _DashboardModels.ArchivedUsers = reader["ArchivedUsers"].ToString();
                }

                return _DashboardModels;

            }
        }

    }
}