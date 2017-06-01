using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class InsectAccessor
    {
        public static List<Insect> RetrieveInsectsByZone(string growingZoneId)
        {
            var insects = new List<Insect>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_insects";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@GrowingZoneID", SqlDbType.VarChar);
            cmd.Parameters["@GrowingZoneID"].Value = growingZoneId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        insects.Add(new Insect()
                        {
                            InsectID = reader.GetInt32(0),
                            CommonName = reader.GetString(1),
                            ScientificName = reader.GetString(2),
                            InsectType = reader.GetString(3),
                            GrowingZone = reader.GetString(4)
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return insects;
        }

        public static List<Insect> RetrieveFullInsectList(bool active)
        {
            var insects = new List<Insect>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_all_insects";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        insects.Add(new Insect()
                        {
                            InsectID = reader.GetInt32(0),
                            CommonName = reader.GetString(1),
                            ScientificName = reader.GetString(2),
                            InsectType = reader.GetString(3),
                            GrowingZone = reader.GetString(4),          
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return insects;
        }
    }
}
