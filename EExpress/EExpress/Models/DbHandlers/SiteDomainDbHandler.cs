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

    }
}