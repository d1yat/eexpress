using EExpress.Enums;
using EExpress.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EExpress.Models.DbHandlers
{
    public class BankDbHandler
    {
        public List<Bank> GetBank()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_bank))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_bank");

                    List<Bank> listBank = new List<Bank>();
                    foreach (DataRow dr in ds.Tables["m_bank"].Rows)
                    {
                        listBank.Add(new Bank()
                        {
                            kdbank = dr["kdbank"] as string,
                            nmbank = dr["nmbank"] as string,
                            alamat = dr["alamat"] as string,
                            statusx = dr["statusx"] as string,
                            norek = dr["norek"] as string
                        });
                    }

                    return listBank;
                }
            }

        }

        public Bank GetBankById(string kdbank)
        {
            string sqlCommand = "SELECT TOP 1 * FROM m_bank WHERE kdbank = @kdbank";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@kdbank", SqlDbType.VarChar, 50).Value = kdbank;
                cmd.CommandType = CommandType.Text;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_val");

                    Bank bank = new Bank();
                    foreach (DataRow dr in ds.Tables["m_val"].Rows)
                    {
                        bank.kdbank = dr["kdbank"] as string;
                        bank.nmbank = dr["nmbank"] as string;
                        bank.alamat= dr["alamat"] as string;
                        bank.statusx = dr["statusx"] as string;
                        bank.norek = dr["norek"] as string;
                    }

                    return bank;
                }
            }

        }

        public int AddEditBank(Bank bank)
        {
            string sqlCommand = "spAddEditBank";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@kdbank", bank.kdbank);
            parameters.Add("@nmbank", bank.nmbank);
            parameters.Add("@alamat", bank.alamat);
            parameters.Add("@statusx", bank.statusx);
            parameters.Add("@norek", bank.norek);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

    }
}