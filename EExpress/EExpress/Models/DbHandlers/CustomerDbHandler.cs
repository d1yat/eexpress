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
    public class CustomerDbHandler
    {
        public List<Customer> GetCustomers()
        {
            using (SqlCommand cmd = General.GetCommand("spGetCustomers", Table.m_customer))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_customer");

                    List<Customer> listCustomer = new List<Customer>();
                    foreach (DataRow dr in ds.Tables["m_customer"].Rows)
                    {
                        listCustomer.Add(new Customer()
                        {
                            custno = Guid.Parse(dr["custno"].ToString()),
                            nm = dr["nm"] as string,
                            alm1 = dr["alm1"] as string,
                            alm2 = dr["alm2"] as string,
                            alm3 = dr["alm3"] as string,
                            tlp = dr["tlp"] as string,
                            ct_person = dr["ct_person"] as string,
                            statusx = dr["statusx"] as string,
                            ctk_hrg = dr["ctk_hrg"] as string,
                            npwp = dr["npwp"] as string,
                            k_payment = dr["k_payment"] as string,
                            hrgkhs = char.Parse((dr["hrgkhs"] as string).Trim()),
                            cetak_penerima = char.Parse((dr["cetak_penerima"] as string).Trim()),
                            user_entry = dr["user_entry"] as string,
                            hrgspecial = dr["hrgspecial"] as string,
                        });
                    }

                    return listCustomer;
                }
            }

        }

        public Customer GetCustomerById(string id)
        {
            using (SqlCommand cmd = General.GetCommand("spGetCustomerById"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_customer");

                    Customer customer = new Customer();
                    foreach (DataRow dr in ds.Tables["m_customer"].Rows)
                    {
                        customer.custno = Guid.Parse(dr["custno"].ToString());
                        customer.nm = dr["nm"] as string;
                        customer.alm1 = dr["alm1"] as string;
                        customer.alm2 = dr["alm2"] as string;
                        customer.alm3 = dr["alm3"] as string;
                        customer.tlp = dr["tlp"] as string;
                        customer.ct_person = dr["ct_person"] as string;
                        customer.statusx = dr["statusx"] as string;
                        customer.ctk_hrg = dr["ctk_hrg"] as string;
                        customer.npwp = dr["npwp"] as string;
                        customer.k_payment= dr["k_payment"] as string;
                        customer.hrgkhs = char.Parse((dr["hrgkhs"] as string).Trim());
                        customer.cetak_penerima= char.Parse((dr["cetak_penerima"] as string).Trim());
                        customer.user_entry = dr["user_entry"] as string;
                        customer.hrgspecial= dr["hrgspecial"] as string;
                    }

                    return customer;
                }
            }

        }

        public int Edit(Customer customer)
        {
            string sqlCommand = "spAddEditCustomer";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@custno", customer.custno);
            parameters.Add("@nm", customer.nm);
            parameters.Add("@alm1", customer.alm1);
            parameters.Add("@alm2", customer.alm2);
            parameters.Add("@alm3", customer.alm3);
            parameters.Add("@tlp", customer.tlp);
            parameters.Add("@ct_person", customer.ct_person ?? "1234");
            parameters.Add("@statusx", customer.statusx);
            parameters.Add("@ctk_hrg", customer.ctk_hrg);
            parameters.Add("@npwp", customer.npwp);
            parameters.Add("@k_payment", customer.k_payment);
            parameters.Add("@hrgkhs", customer.hrgkhs);
            parameters.Add("@cetak_penerima", customer.cetak_penerima);
            parameters.Add("@user_entry", customer.user_entry);
            parameters.Add("@hrgspecial", customer.hrgspecial);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

        public int Add(Customer customer)
        {
            string sqlCommand = "spAddEditCustomer";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@custno", Guid.NewGuid());
            parameters.Add("@nm", customer.nm);
            parameters.Add("@alm1", customer.alm1);
            parameters.Add("@alm2", customer.alm2);
            parameters.Add("@alm3", customer.alm3);
            parameters.Add("@tlp", customer.tlp);
            parameters.Add("@ct_person", customer.ct_person);
            parameters.Add("@statusx", customer.statusx);
            parameters.Add("@ctk_hrg", customer.ctk_hrg);
            parameters.Add("@npwp", customer.npwp);
            parameters.Add("@k_payment", customer.k_payment);
            parameters.Add("@hrgkhs", customer.hrgkhs);
            parameters.Add("@cetak_penerima", customer.cetak_penerima);
            parameters.Add("@user_entry", customer.user_entry);
            parameters.Add("@hrgspecial", customer.hrgspecial);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }
    }
}