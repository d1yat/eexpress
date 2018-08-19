using EExpress.Enums;
using EExpress.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EExpress.Services
{
    public static class Entity 
    {
        public static List<City> GetCities()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_city))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_city");

                    List<City> listCity = new List<City>();
                    foreach (DataRow dr in ds.Tables["m_city"].Rows)
                    {
                        listCity.Add(new City()
                        {
                            original = dr["original"] as string,
                            group_area = dr["group_area"] as string,
                            kdkota = dr["kdkota"] as string,
                            kd_pengiriman = dr["kd_pengiriman"] as string,
                            nm = dr["nm"] as string,
                            alk_manifest = dr["alk_manifest"] as string,
                            statusx = (dr["statusx"] as string).Trim(),
                            keyidx = dr["keyidx"] as string,
                            ambilreport = dr["ambilreport"] as string
                        });
                    }

                    return listCity;
                }
            }

        }
        public static List<ShipmentType> GetShipmentType()
        {
            string sqlCommand = "spGetWithSortAsc";
            string orderBy = "id";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_item_kiriman, orderBy))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_item_kiriman");

                    List<ShipmentType> listShipmentType = new List<ShipmentType>();
                    foreach (DataRow dr in ds.Tables["m_item_kiriman"].Rows)
                    {
                        listShipmentType.Add(new ShipmentType()
                        {
                            kode = dr["kode"] as string,
                            nm = dr["nm"] as string,
                            statusx = (dr["statusx"] as string).Trim(),
                            id = dr["id"] as string
                        });
                    }

                    return listShipmentType;
                }
            }

        }
        public static List<Product> GetProduct()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_product))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_product");

                    List<Product> listProduct = new List<Product>();
                    foreach (DataRow dr in ds.Tables["m_product"].Rows)
                    {
                        listProduct.Add(new Product()
                        {
                            kode = dr["kode"] as string,
                            nm = dr["nm"] as string,
                            statusx = (dr["statusx"] as string).Trim(),
                            id = Guid.Parse(dr["id"].ToString() )
                        });
                    }

                    return listProduct;
                }
            }

        }
    }
}