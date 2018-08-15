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
    public class PODStatusDbHandler
    {
        public List<PODStatus> GetPODStatus()
        {
            string sqlCommand = "spGet";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_pod))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_pod");

                    List<PODStatus> listPodStatus = new List<PODStatus>();
                    foreach (DataRow dr in ds.Tables["m_pod"].Rows)
                    {
                        listPodStatus.Add(new PODStatus()
                        {
                            kode = int.Parse(dr["kode"].ToString()),
                            nm = dr["nm"] as string,
                            statusx = (dr["statusx"] as string).Trim(),
                            kode_relasi = (dr["kode_relasi"] as string).Trim(),
                            id = Guid.Parse(dr["id"].ToString())
                        });
                    }

                    return listPodStatus;
                }
            }

        }

        public PODStatus GetPODStatusById(Guid id)
        {
            string sqlCommand = "spGetById";

            using (SqlCommand cmd = General.GetCommand(sqlCommand, Table.m_pod, id))
            {
                using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sdAdapter.Fill(ds, "m_pod");

                    PODStatus podStatus = new PODStatus();
                    foreach (DataRow dr in ds.Tables["m_pod"].Rows)
                    {
                        podStatus.kode = int.Parse(dr["kode"].ToString());
                        podStatus.nm = dr["nm"] as string;
                        podStatus.statusx = (dr["statusx"] as string).Trim();
                        podStatus.kode_relasi = (dr["kode_relasi"] as string).Trim();
                        podStatus.id = Guid.Parse(dr["id"].ToString());
                    }

                    return podStatus;
                }
            }

        }

        public int AddEditPODStatus(PODStatus podStatus)
        {
            string sqlCommand = "spAddEditPODStatus";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@nm", podStatus.nm);
            parameters.Add("@statusx", podStatus.statusx);
            parameters.Add("@kode_relasi", podStatus.kode_relasi);
            parameters.Add("@id", podStatus.id);

            using (SqlCommand cmd = General.GetCommand(sqlCommand, parameters))
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                return cmd.ExecuteNonQuery();
            }
        }

    }
}