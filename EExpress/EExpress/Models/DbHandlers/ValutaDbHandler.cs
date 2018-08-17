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
    public class ValutaDbHandler
    {
        public List<Valuta> GetValuta()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_val))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_val");

                    List<Valuta> listValuta = new List<Valuta>();
                    foreach (DataRow dr in ds.Tables["m_val"].Rows)
                    {
                        listValuta.Add(new Valuta()
                        {
                            kode = dr["kode"] as string,
                            nm = dr["nm"] as string,
                            statusx = dr["statusx"] as string
                        });
                    }

                    return listValuta;
                }
            }

        }

        public Valuta GetValutaById(string kode)
        {
            string sqlCommand = "SELECT TOP 1 * FROM m_val WHERE kode = @kode";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@kode", SqlDbType.VarChar, 10).Value = kode;
                cmd.CommandType = CommandType.Text;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_val");

                    Valuta valuta = new Valuta();
                    foreach (DataRow dr in ds.Tables["m_val"].Rows)
                    {
                        valuta.kode = dr["kode"] as string;
                        valuta.nm = dr["nm"] as string;
                        valuta.statusx = dr["statusx"] as string;
                    }

                    return valuta;
                }
            }

        }

        public int AddEditValuta(Valuta valuta)
        {
            string sqlCommand = "spAddEditValuta";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@kode", valuta.kode);
            parameters.Add("@nm", valuta.nm);
            parameters.Add("@statusx", valuta.statusx);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

    }
}