using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CustomerManagement.Models;
using System.Data.SqlClient;

namespace CustomerManagement.Services
{
    public class AccountService
    {
        string DBconn = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
        SystemTools _SystemTools = new SystemTools();

        public LoginResultModel UserAuthenticate(LoginModel model)
        {
            LoginResultModel __LoginResultModel = new LoginResultModel();

            using (SqlConnection conn = new SqlConnection(DBconn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("NSP_LoginUser", conn);//call Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Password", _SystemTools.EncryptPass(model.Password));
                //int rs = cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    __LoginResultModel.UserID = int.Parse(reader["UserID"].ToString());
                    __LoginResultModel.Firstname = reader["Firstname"].ToString();
                    __LoginResultModel.Position = reader["Position"].ToString();
                    __LoginResultModel.Email = reader["Email"].ToString();
                    __LoginResultModel.RoleId = reader["RoleId"].ToString();
                }

                return __LoginResultModel;

            }


        }
    }
}