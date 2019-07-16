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
    public class SystemService
    {
        DBConnection conn;
private  string Session;

        public SystemService()
        {
            conn = new DBConnection();
        }

        public DataSet GetInitialDetails()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[0];
            DataSet ds = conn.executeSelectQueryNew("LoadCountryLabels", _SqlParameter);
            return ds;
        }

        public DataSet GetInitialDetails(string sUsedID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            _SqlParameter[0] = new SqlParameter("@OperatorId", SqlDbType.VarChar);
            _SqlParameter[0].Value = Convert.ToString(sUsedID);
            DataSet ds = conn.executeSelectQueryNewDs("LoadStreetByOperator", _SqlParameter);
            return ds;
        }

             //..End GetInitialDetails

        //public DataSet LoadDynamicMenu(string sUserId,string sRoleId)
        //{
        //    SqlParameter[] _SqlParameter = new SqlParameter[2];
        //    _SqlParameter[0] = new SqlParameter("@UserId1", SqlDbType.VarChar);
        //    _SqlParameter[0].Value = Convert.ToInt32(sUserId);
        //    _SqlParameter[1] = new SqlParameter("@RoleId", SqlDbType.VarChar);
        //    _SqlParameter[1].Value = Convert.ToInt32(sRoleId);
        //    DataSet ds = conn.executeSelectQueryNew("LoadDynamicMenu", _SqlParameter);
        //    return ds;
        //}//..End GetInitialDetails

        public DataSet LoadDynamicMenu(string sUsedID, string sRoleId)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            _SqlParameter[0] = new SqlParameter("@UserID", SqlDbType.VarChar);
            _SqlParameter[0].Value = Convert.ToString(sUsedID);
            _SqlParameter[1] = new SqlParameter("@RoleId", SqlDbType.VarChar);
            _SqlParameter[1].Value = Convert.ToString(sRoleId);

            return conn.executeSelectQueryNewDs("LoadDynamicMenu", _SqlParameter);

        }//..End LoadDetail

        
    }///End
}