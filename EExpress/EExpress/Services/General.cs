using EExpress.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EExpress.Services
{
    public static class General
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["EExpressConnection"].ConnectionString;

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static SqlCommand GetCommand(string sqlCommand)
        {
            return new SqlCommand(sqlCommand, GetConnection());
        }

        public static SqlCommand GetCommand(string sqlCommand, Table tableName)
        {
            SqlCommand cmd = new SqlCommand(sqlCommand, GetConnection());
            cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 50).Value = tableName;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public static SqlCommand GetCommand(string sqlCommand, Dictionary<string, object> parameters)
        {
            SqlCommand cmd = new SqlCommand(sqlCommand, GetConnection());
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
    }
}