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
    public class StreetService
    {
        //Db Connection string
        DBConnection conn;
        public StreetService()
        {
            conn = new DBConnection();
        }

        public int CreateStreet(StreetModel entity, string sUserId)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            _SqlParameter[0] = new SqlParameter("@StAreaCode", SqlDbType.VarChar);
            _SqlParameter[0].Value = Convert.ToString(entity.StreetAreaCode);

            _SqlParameter[1] = new SqlParameter("@StName", SqlDbType.VarChar);
            _SqlParameter[1].Value = Convert.ToString(entity.StreetName);

            _SqlParameter[2] = new SqlParameter("@StOperator", SqlDbType.VarChar);
            _SqlParameter[2].Value = Convert.ToString(sUserId);

            _SqlParameter[3] = new SqlParameter("@StCreatedBy", SqlDbType.VarChar);
            _SqlParameter[3].Value = Convert.ToString(sUserId);

            _SqlParameter[4] = new SqlParameter("@StModifiedBy", SqlDbType.VarChar);
            _SqlParameter[4].Value = Convert.ToString(sUserId);

            _SqlParameter[5] = new SqlParameter("@StIsActive", SqlDbType.VarChar);
            _SqlParameter[5].Value = Convert.ToInt32(1);

            _SqlParameter[6] = new SqlParameter("@StIsArchived", SqlDbType.VarChar);
            _SqlParameter[6].Value = Convert.ToInt32(0);


            DataTable ds = conn.executeSelectQueryWithSPNew("NSP_AddStreet", _SqlParameter);

            if (ds != null && ds.Rows[0][0].ToString() == "Y")
            {
                return 1;
            }
            return 0;

        }
        public DataTable StreetList(String OperatorId)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];

            _SqlParameter[0] = new SqlParameter("@OperatorId", SqlDbType.VarChar);
            _SqlParameter[0].Value = Convert.ToString(OperatorId);
            DataTable ds = conn.executeSelectQueryWithSPNew("GetStreetByOperatorId", _SqlParameter);

            return ds;
        }
        public DataTable ViewStreetList()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[0];
            DataTable ds = conn.executeSelectQueryWithSPNew("GetViewStreetList", _SqlParameter);

            return ds;
        }
        public DataTable UpdateStreet(EditStreetModel entity)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            _SqlParameter[0] = new SqlParameter("@StreetId", SqlDbType.VarChar);
            _SqlParameter[0].Value = Convert.ToString(entity.StreetId);
            _SqlParameter[1] = new SqlParameter("@StreetName", SqlDbType.VarChar);
            _SqlParameter[1].Value = Convert.ToString(entity.StreetName);
          
            DataTable ds = conn.executeSelectQueryWithSPNew("NSP_UpdateStreet", _SqlParameter);
            return ds;
        }//..End UpdateCustomer

        public DataTable ActiveCustomerList()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[0];

            DataTable ds = conn.executeSelectQueryWithSPNew("GetActiveCustomer", _SqlParameter);
            return ds;
        }//..End ActiveCustomerList


       
        public DataTable EditStreet()
        {
            throw new NotImplementedException();
        }
    }


}