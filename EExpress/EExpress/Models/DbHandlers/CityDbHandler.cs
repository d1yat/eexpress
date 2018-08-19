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
    public class CityDbHandler
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

        public int AddEditCity(City city)
        {
            string sqlCommand = "spAddEditCity";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@original", city.original);
            parameters.Add("@group_area", city.group_area);
            parameters.Add("@kdkota", city.kdkota);
            parameters.Add("@kd_pengiriman", city.kd_pengiriman);
            parameters.Add("@nm", city.nm);
            parameters.Add("@alk_manifest", city.alk_manifest);
            parameters.Add("@statusx", city.statusx);
            parameters.Add("@keyidx", city.keyidx);
            parameters.Add("@ambilreport", city.ambilreport);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

    }
}