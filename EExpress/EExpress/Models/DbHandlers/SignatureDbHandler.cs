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
    public class SignatureDbHandler
    {
        public List<Signature> GetSignature()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_domain))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_domain");

                    List<Signature> listSignature = new List<Signature>();
                    foreach (DataRow dr in ds.Tables["m_domain"].Rows)
                    {
                        listSignature.Add(new Signature()
                        {
                            PaymentDescription = dr["paymentx"] as string,
                            BankAccDescription = dr["bnk"] as string,
                            Finance = dr["nmpjbt"] as string,
                            Tax = dr["nmsignpjk"] as string
                        });
                    }

                    return listSignature;
                }
            }

        }

        public Signature GetSignatureDetails()
        {
            string sqlCommand = "SELECT TOP 1 * FROM m_domain";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.CommandType = CommandType.Text;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_domain");

                    Signature signature = new Signature();
                    foreach (DataRow dr in ds.Tables["m_domain"].Rows)
                    {
                        signature.PaymentDescription = dr["paymentx"] as string;
                        signature.BankAccDescription = dr["bnk"] as string;
                        signature.Finance = dr["nmpjbt"] as string;
                        signature.Tax = dr["nmsignpjk"] as string;
                    }

                    return signature;
                }
            }

        }

        public int AddEditSignature(Signature signature)
        {
            string sqlCommand = "spAddEditSignature";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@nmsignpjk", signature.Tax);
            parameters.Add("@nmpjbt", signature.Finance);
            parameters.Add("@paymentx", signature.PaymentDescription);
            parameters.Add("@bnk", signature.BankAccDescription);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

    }
}