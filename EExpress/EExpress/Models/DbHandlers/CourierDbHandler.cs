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
    public class CourierDbHandler
    {
        public List<Courier> GetCourier()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_kurir))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_kurir");

                    List<Courier> listCourier = new List<Courier>();
                    foreach (DataRow dr in ds.Tables["m_kurir"].Rows)
                    {
                        listCourier.Add(new Courier()
                        {
                            kode = dr["kode"] as string,
                            nm = dr["nm"] as string,
                            statusx = char.Parse(dr["statusx"].ToString().Trim()),
                            tlp = dr["tlp"] as string,
                            jns_kendaraan = dr["jns_kendaraan"] as string
                        });
                    }

                    return listCourier;
                }
            }

        }

        public Courier GetCourierById(string id)
        {
            string sqlCommand = "SELECT TOP 1 * FROM m_kurir WHERE kode = @kode";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@kode", SqlDbType.VarChar, 10).Value = id;
                cmd.CommandType = CommandType.Text;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_kurir");

                    Courier courier = new Courier();
                    foreach (DataRow dr in ds.Tables["m_kurir"].Rows)
                    {
                        courier.kode = dr["kode"] as string;
                        courier.nm = dr["nm"] as string;
                        courier.statusx = char.Parse(dr["statusx"].ToString().Trim());
                        courier.tlp = dr["tlp"] as string;
                        courier.jns_kendaraan = dr["jns_kendaraan"] as string;
                    }

                    return courier;
                }
            }

        }

        public int AddEditCourier(Courier courier)
        {
            string sqlCommand = "spAddEditCourier";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@kode", courier.kode);
            parameters.Add("@nm", courier.nm);
            parameters.Add("@statusx", courier.statusx);
            parameters.Add("@tlp", courier.tlp);
            parameters.Add("@jns_kendaraan", courier.jns_kendaraan);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

    }
}