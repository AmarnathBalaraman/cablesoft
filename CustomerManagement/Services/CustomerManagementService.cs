using CustomerManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerManagement.Services
{
    public class CustomerManagementService
    {
        //Db Connection string
        DBConnection conn;

        //Db Connection string
        string DBCon = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
        DBConnection DBconn = new DBConnection();

        SystemTools _SystemTools = new SystemTools();

        public CustomerManagementService()
        {
            conn = new DBConnection();
        }

        public int CreateUser(AddCustomerModel entity, string sUserId)
        {

            SqlParameter[] _SqlParameter = new SqlParameter[13];

            _SqlParameter[0] = new SqlParameter("@CustName", SqlDbType.VarChar);
            _SqlParameter[0].Value = Convert.ToString(entity.CustomerName);

            _SqlParameter[1] = new SqlParameter("@CustAddress", SqlDbType.VarChar);
            _SqlParameter[1].Value = Convert.ToString(entity.CustomerAddress);

            _SqlParameter[2] = new SqlParameter("@CustStreet", SqlDbType.VarChar);
            _SqlParameter[2].Value = Convert.ToString(entity.CustomerStreet);

            _SqlParameter[3] = new SqlParameter("@CustPincode", SqlDbType.VarChar);
            _SqlParameter[3].Value = Convert.ToString(entity.CustomerPincode);

            _SqlParameter[4] = new SqlParameter("@CustCity", SqlDbType.VarChar);
            _SqlParameter[4].Value = Convert.ToString(entity.CustomerCity);

            _SqlParameter[5] = new SqlParameter("@CustState", SqlDbType.VarChar);
            _SqlParameter[5].Value = Convert.ToString(entity.CustomerState);

            _SqlParameter[6] = new SqlParameter("@CustCountry", SqlDbType.VarChar);
            _SqlParameter[6].Value = Convert.ToString(entity.CustomerCountry);

            _SqlParameter[7] = new SqlParameter("@CustEmail", SqlDbType.VarChar);
            _SqlParameter[7].Value = Convert.ToString(entity.CustomerEmailId);

            _SqlParameter[8] = new SqlParameter("@CustMobileNo", SqlDbType.VarChar);
            _SqlParameter[8].Value = Convert.ToString(entity.CustomerMobileNo);

            _SqlParameter[9] = new SqlParameter("@CustUserId", SqlDbType.VarChar);
            _SqlParameter[9].Value = Convert.ToString(sUserId);

            _SqlParameter[10] = new SqlParameter("@CustBoxId", SqlDbType.VarChar);
            _SqlParameter[10].Value = Convert.ToInt32(entity.CustomerBoxType);

            _SqlParameter[11] = new SqlParameter("@CustBoxSerailNo", SqlDbType.VarChar);
            _SqlParameter[11].Value = Convert.ToString(entity.CustomerBoxSerialNo);

            _SqlParameter[12] = new SqlParameter("@CustPackId", SqlDbType.VarChar);
            _SqlParameter[12].Value = Convert.ToString(entity.CustomerPackageId);

     
            DataTable ds = conn.executeSelectQueryWithSPNew("NSP_AddCustomer", _SqlParameter);

            if (ds != null && ds.Rows[0][0].ToString() == "Y")
            {
                return 1;
            }
            return 0;

        }

        public DataTable CustomerList(String OperatorId)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];

            _SqlParameter[0] = new SqlParameter("@OperatorId", SqlDbType.VarChar);
            _SqlParameter[0].Value = Convert.ToString(OperatorId);
            DataTable ds = conn.executeSelectQueryWithSPNew("GetCustomerByOperatorId", _SqlParameter);

            return ds;
        }

        public int DeactivateActivateUser(CustomerListModel entity)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            _SqlParameter[0] = new SqlParameter("@UserID", SqlDbType.VarChar);
            _SqlParameter[0].Value = Convert.ToString(entity.CustomerId);

            _SqlParameter[1] = new SqlParameter("@Operation", SqlDbType.VarChar);
            _SqlParameter[1].Value = Convert.ToString(entity.Operation);

            DataTable ds = conn.executeSelectQueryWithSPNew("DeactivateActivateCustomer", _SqlParameter);

            if (ds != null && ds.Rows[0][0].ToString() == "Y")
            {
                return 1;
            }
            return 0;
        }//..DeactivateActivateUser

        public DataTable ViewCustomerDetailsList()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[0];
            DataTable ds = conn.executeSelectQueryWithSPNew("GetEditCustomer", _SqlParameter);

            return ds;
        }

        public DataTable UpdateCustomer(string sUsedID, EditCustomerModel entity)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[15];

            _SqlParameter[0] = new SqlParameter("@CustId", SqlDbType.VarChar);
            _SqlParameter[0].Value = Convert.ToString(entity.CustomerId);
            _SqlParameter[1] = new SqlParameter("@CustName", SqlDbType.VarChar);
            _SqlParameter[1].Value = Convert.ToString(entity.CustomerName);
            _SqlParameter[2] = new SqlParameter("@CustAddress", SqlDbType.VarChar);
            _SqlParameter[2].Value = Convert.ToString(entity.CustomerAddress);
            _SqlParameter[3] = new SqlParameter("@CustStreet", SqlDbType.VarChar);
            _SqlParameter[3].Value = Convert.ToString(entity.CustomerStreet);
            _SqlParameter[4] = new SqlParameter("@CustPincode", SqlDbType.Int);
            _SqlParameter[4].Value = Convert.ToString(entity.CustomerPincode);
            _SqlParameter[5] = new SqlParameter("@CustCity", SqlDbType.VarChar);
            _SqlParameter[5].Value = Convert.ToString(entity.CustomerCity);
            _SqlParameter[6] = new SqlParameter("@CustState", SqlDbType.VarChar);
            _SqlParameter[6].Value = Convert.ToString(entity.CustomerState);
            _SqlParameter[7] = new SqlParameter("@CustCountry", SqlDbType.VarChar);
            _SqlParameter[7].Value = Convert.ToString(entity.CustomerCountry);
            _SqlParameter[8] = new SqlParameter("@CustEmail", SqlDbType.VarChar);
            _SqlParameter[8].Value = Convert.ToString(entity.CustomerEmailId);
            _SqlParameter[9] = new SqlParameter("@CustMobileNo", SqlDbType.VarChar);
            _SqlParameter[9].Value = Convert.ToString(entity.CustomerMobileNo);
            _SqlParameter[10] = new SqlParameter("@CustUserId", SqlDbType.VarChar);
            _SqlParameter[10].Value = Convert.ToString(entity.CustomerId);
            _SqlParameter[11] = new SqlParameter("@UserId", SqlDbType.VarChar);
            _SqlParameter[11].Value = Convert.ToString(sUsedID);
            _SqlParameter[12] = new SqlParameter("@CustBoxId", SqlDbType.VarChar);
            _SqlParameter[12].Value = Convert.ToString(entity.CustomerBoxType);
            _SqlParameter[13] = new SqlParameter("@CustBoxSerailNo", SqlDbType.VarChar);
            _SqlParameter[13].Value = Convert.ToString(entity.CustomerBoxSerialNo);
            _SqlParameter[14] = new SqlParameter("@CustPackId", SqlDbType.VarChar);
            _SqlParameter[14].Value = Convert.ToString(entity.CustomerPackageId);

            DataTable ds = conn.executeSelectQueryWithSPNew("NSP_UpdateCustomer", _SqlParameter);
            return ds;
        }//..End UpdateCustomer

        public DataTable ActiveCustomerList()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[0];

            DataTable ds = conn.executeSelectQueryWithSPNew("GetActiveCustomer", _SqlParameter);
            return ds;
        }//..End ActiveCustomerList

        public int RemoveCustomer(CustomerListModel model)
        {
            using (SqlConnection conn = new SqlConnection(DBCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("RemoveCustomer", conn);//call Stored Procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustID", model.CustomerId);
                int rs = cmd.ExecuteNonQuery();

                return rs;

            }
        }

    }
}