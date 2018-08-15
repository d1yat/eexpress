using EExpress.Enums;
using EExpress.Helpers;
using EExpress.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EExpress.Models.DbHandlers
{
    public class ProductDbHandler
    {
        public List<Product> GetProducts()
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
                            statusx = dr["statusx"] as string,
                            id = Guid.Parse(dr["id"].ToString())
                        });
                    }

                    return listProduct;
                }
            }

        }

        public Product GetProductById(Guid id)
        {
            string sqlCommand = "spGetById";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 50).Value =  Table.m_product;
                cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier, 16).Value =  id;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_product");

                    Product product = new Product();
                    foreach (DataRow dr in ds.Tables["m_product"].Rows)
                    {
                        product.kode = dr["kode"] as string;
                        product.nm = dr["nm"] as string;
                        product.statusx = dr["statusx"] as string;
                        product.id = Guid.Parse(dr["id"].ToString());
                    }

                    return product;
                }
            }

        }

        public int AddEditProduct(Product product)
        {
            string sqlCommand = "spAddEditProduct";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@kode", product.kode);
            parameters.Add("@nm", product.nm);
            parameters.Add("@statusx", product.statusx);
            parameters.Add("@id", product.id);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

    }
}