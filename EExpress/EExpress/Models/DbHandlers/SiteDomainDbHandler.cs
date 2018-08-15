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
    public class SiteDomainDbHandler
    {
        public List<Origin> GetOrigin()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_origin))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_origin");

                    List<Origin> listOrigin = new List<Origin>();
                    foreach (DataRow dr in ds.Tables["m_origin"].Rows)
                    {
                        listOrigin.Add(new Origin()
                        {
                            kdkota = dr["kdkota"] as string,
                            nm = dr["nm"] as string,
                            statusx = dr["statusx"] as string,
                            kdorg = dr["kdorg"] as string
                        });
                    }

                    return listOrigin;
                }
            }

        }

        public Origin GetOriginBySiteName(string siteName)
        {
            string sqlCommand = "SELECT TOP 1 * FROM m_origin WHERE nm = @SiteName";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@SiteName", SqlDbType.VarChar, 100).Value = siteName;
                cmd.CommandType = CommandType.Text;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_origin");

                    Origin origin = new Origin();
                    foreach (DataRow dr in ds.Tables["m_origin"].Rows)
                    {
                        origin.kdkota = dr["kdkota"].ToString();
                        origin.nm = dr["nm"] as string;
                        origin.statusx = (dr["statusx"] as string).Trim();
                        origin.kdorg = (dr["kdorg"] as string).Trim();
                    }

                    return origin;
                }
            }

        }

        public List<SiteDomain> GetSiteDomain()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_domain))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_domain");

                    List<SiteDomain> listSiteDomain = new List<SiteDomain>();
                    foreach (DataRow dr in ds.Tables["m_domain"].Rows)
                    {
                        listSiteDomain.Add(new SiteDomain()
                        {
                            my_domain = dr["my_domain"] as string,
                            nmd = dr["nmd"] as string
                        });
                    }

                    return listSiteDomain;
                }
            }

        }

        public Pager GetCustomers(int pageIndex, int pageSize)
        {
            Pager listCustomer = new Pager();

            using (SqlCommand cmd = General.GetCommand("spGetWithPaging"))
            {
                cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 50).Value = Table.m_customer;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 11).Value = pageIndex;
                cmd.Parameters.Add("@OrderBy", SqlDbType.VarChar, 11).Value = "nm";

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    List<Customer> customers = new List<Customer>();

                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        customers.Add(new Customer()
                        {
                            id = Guid.Parse(dr["id"].ToString()),
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

                    dr.NextResult();

                    while (dr.Read())
                        listCustomer.TotalCount = Convert.ToInt32(dr["TotalCount"].ToString());

                    listCustomer.IndexViewModel = customers.Cast<object>().ToList();

                    //return listCustomer;
                }
            }

            return listCustomer;
        }

        public SiteDomain GetSiteDomainById(string kdkota)
        {
            string sqlCommand = "SELECT TOP 1 * FROM m_origin WHERE kdkota = @kdkota";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@kdkota", SqlDbType.VarChar, 10).Value = kdkota;
                cmd.CommandType = CommandType.Text;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_origin");

                    SiteDomain siteDomain = new SiteDomain();
                    foreach (DataRow dr in ds.Tables["m_origin"].Rows)
                    {
                        siteDomain.my_domain = dr["kdkota"].ToString();
                        siteDomain.nmd = dr["nm"] as string;
                        siteDomain.nmpjbt = (dr["statusx"] as string).Trim();
                        siteDomain.nmsignpjk= (dr["kdorg"] as string).Trim();
                    }

                    return siteDomain;
                }
            }

        }

        public int AddEditSiteDomain(SiteDomain siteDomain)
        {
            string sqlCommand = "spAddEditSiteDomain";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@my_domain", siteDomain.my_domain);
            parameters.Add("@nmd", siteDomain.nmd);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

        public int Edit(Customer customer)
        {
            string sqlCommand = "spAddEditCustomer";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", customer.id);
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
            parameters.Add("@id", customer.id);
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

        public TermInvoice GetTermInvoice(Guid id)
        {
            string sqlCommand = "spGetTermInvoice";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier, 16).Value = id;
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_term");

                    TermInvoice termInvoice = new TermInvoice();
                    foreach (DataRow dr in ds.Tables["m_term"].Rows)
                    {
                        termInvoice.cust_id = Guid.Parse(dr["id"].ToString());
                        termInvoice.nm = dr["nm"] as string;
                        termInvoice.termx = dr["termx"] as string;
                        termInvoice.descx = dr["descx"] as string;
                    }

                    return termInvoice;
                }
            }
        }

        public int AddEditTermInvoice(TermInvoice termInvoice)
        {
            string sqlCommand = "spAddEditTermInvoice";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cust_id", termInvoice.cust_id);
            parameters.Add("@nm", termInvoice.nm);
            parameters.Add("@termx", termInvoice.termx);
            parameters.Add("@descx", termInvoice.descx);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

        public List<Divisi> GetDivisi(Guid customerId)
        {
            string sqlCommand = "spGetDivisi";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@CustomerId", SqlDbType.UniqueIdentifier, 16).Value = customerId;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_div");

                    List<Divisi> listDivisi = new List<Divisi>();
                    foreach (DataRow dr in ds.Tables["m_div"].Rows)
                    {
                        listDivisi.Add(new Divisi()
                        {
                            id = !string.IsNullOrEmpty(dr["id"].ToString()) ? (Guid?)Guid.Parse(dr["id"].ToString()) : null,
                            cust_id = Guid.Parse(dr["cust_id"].ToString()),
                            nm = dr["nm"].ToString(),
                            alm1 = dr["alm1"].ToString(),
                            alm2 = dr["alm2"].ToString(),
                            tlp = dr["tlp"].ToString(),
                            ct_person = dr["ct_person"].ToString(),
                            statusx = dr["statusx"].ToString(),
                            ctk_hrg = dr["ctk_hrg"].ToString(),
                            npwp = dr["npwp"].ToString(),
                            k_payment = dr["k_payment"].ToString(),
                            countx = !string.IsNullOrEmpty(dr["countx"].ToString()) ? (int?)int.Parse(dr["countx"].ToString()) : null,
                            user_entry = dr["user_entry"].ToString()
                        });
                    }

                    return listDivisi;
                }
            }
        }

        public Divisi GetDivisiById(Guid id)
        {
            string sqlCommand = "spGetById";

            using (SqlCommand cmd = General.GetCommand(sqlCommand))
            {
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 50).Value = Table.m_div;
                cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier, 16).Value = id;

                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_div");

                    Divisi divisi = new Divisi();
                    foreach (DataRow dr in ds.Tables["m_div"].Rows)
                    {
                        divisi.id = !string.IsNullOrEmpty(dr["id"].ToString()) ? (Guid?)Guid.Parse(dr["id"].ToString()) : null;
                        divisi.cust_id = Guid.Parse(dr["cust_id"].ToString());
                        divisi.nm = dr["nm"].ToString();
                        divisi.alm1 = dr["alm1"].ToString();
                        divisi.alm2 = dr["alm2"].ToString();
                        divisi.tlp = dr["tlp"].ToString();
                        divisi.ct_person = dr["ct_person"].ToString();
                        divisi.statusx = dr["statusx"].ToString();
                        divisi.ctk_hrg = dr["ctk_hrg"].ToString();
                        divisi.npwp = dr["npwp"].ToString();
                        divisi.k_payment = dr["k_payment"].ToString();
                        divisi.countx = !string.IsNullOrEmpty(dr["countx"].ToString()) ? (int?)int.Parse(dr["countx"].ToString()) : null;
                        divisi.user_entry = dr["user_entry"].ToString();
                    }

                    return divisi;
                }
            }
        }

        public int AddEditDivisi(Divisi divisi)
        {
            string sqlCommand = "spAddEditDivisi";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", divisi.id);
            parameters.Add("@nm", divisi.nm);
            parameters.Add("@alm1", divisi.alm1);
            parameters.Add("@alm2", divisi.alm2);
            parameters.Add("@tlp", divisi.tlp);
            parameters.Add("@ct_person", divisi.ct_person);
            parameters.Add("@statusx", divisi.statusx);
            parameters.Add("@ctk_hrg", divisi.ctk_hrg);
            parameters.Add("@npwp", divisi.npwp);
            parameters.Add("@k_payment", divisi.k_payment);
            parameters.Add("@countx", divisi.countx);
            parameters.Add("@user_entry", divisi.user_entry);
            parameters.Add("@cust_id", divisi.cust_id);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }
    }
}