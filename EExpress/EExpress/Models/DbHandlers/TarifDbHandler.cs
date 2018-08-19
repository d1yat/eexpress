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
    public class TarifDbHandler
    {

        public List<City> GetCities()
        {
            List<City> listCity = Entity.GetCities();

            return listCity;
        }

        public City GetCityByCityCode(string cityCode)
        {
            string sqlCommand = "SELECT TOP 1 * FROM m_city WHERE kdkota = @CityCode";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@CityCode", SqlDbType.VarChar, 6).Value = cityCode;
                cmd.CommandType = CommandType.Text;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_city");

                    City city = new City();
                    foreach (DataRow dr in ds.Tables["m_city"].Rows)
                    {
                        city.original = dr["original"] as string;
                        city.group_area = dr["group_area"] as string;
                        city.kdkota = dr["kdkota"] as string;
                        city.kd_pengiriman = dr["kd_pengiriman"] as string;
                        city.nm = dr["nm"] as string;
                        city.alk_manifest = dr["alk_manifest"] as string;
                        city.statusx = (dr["statusx"] as string).Trim();
                        city.keyidx = dr["keyidx"] as string;
                        city.ambilreport = dr["ambilreport"] as string;
                    }

                    return city;
                }
            }

        }

        public List<Tarif> GetTarif()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_hrg))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_hrg");

                    List<Tarif> listTarif = new List<Tarif>();
                    foreach (DataRow dr in ds.Tables["m_hrg"].Rows)
                    {
                        listTarif.Add(new Tarif()
                        {
                            custno = dr["custno"] as string,
                            kdproduct = dr["kdproduct"] as string,
                            dst = dr["dst"] as string,
                            kdpengiriman = dr["kdpengiriman"] as string,
                            discnt = decimal.Parse(dr["discnt"].ToString()),
                            kilo1 = decimal.Parse(dr["kilo1"].ToString()),
                            kategory = dr["kategory"] as string,
                            jns_shipment = dr["jns_shipment"] as string,
                            prckilo1 = decimal.Parse(dr["prckilo1"].ToString()),
                            prckilo2 = decimal.Parse(dr["prckilo2"].ToString()),
                            valuta_kurs = dr["valuta_kurs"] as string,
                            ctk_hrg = dr["ctk_hrg"] as string,
                            kilo_min = decimal.Parse(dr["kilo_min"].ToString()),
                            xtake = dr["xtake"] as string,
                            xlangsam = dr["xlangsam"] as string,
                            xnoflat = dr["xnoflat"] as string,
                            id = Guid.Parse(dr["id"].ToString())
                        });
                    }

                    return listTarif;
                }
            }

        }

        public List<ShipmentType> GetShipmentType()
        {
            List<ShipmentType> listShipmentType = Entity.GetShipmentType();

            return listShipmentType;
        }

        public List<Product> GetProduct()
        {
            List<Product> listProduct = Entity.GetProduct();

            return listProduct;
        }

        public int AddEditTarif(Tarif tarif)
        {
            string sqlCommand = "spAddEditTarif";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@custno", tarif.custno);
            parameters.Add("@kdproduct", tarif.kdproduct);
            parameters.Add("@dst", tarif.dst);
            parameters.Add("@kdpengiriman", tarif.kdpengiriman);
            parameters.Add("@discnt", tarif.discnt);
            parameters.Add("@kilo1", tarif.kilo1);
            parameters.Add("@kategory", tarif.kategory);
            parameters.Add("@jns_shipment", tarif.jns_shipment);
            parameters.Add("@prckilo1", tarif.prckilo1);
            parameters.Add("@prckilo2", tarif.prckilo2);
            parameters.Add("@valuta_kurs", tarif.valuta_kurs);
            parameters.Add("@ctk_hrg", tarif.ctk_hrg);
            parameters.Add("@kilo_min", tarif.kilo_min);
            parameters.Add("@xtake", tarif.xtake);
            parameters.Add("@xlangsam", tarif.xlangsam);
            parameters.Add("@xnoflat", tarif.xnoflat);
            parameters.Add("@id", tarif.id);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

    }
}