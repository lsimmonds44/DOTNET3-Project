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
    public class PlantAccessor
    {
        public static List<Plant> RetrieveFullPlantList(bool active)
        {
            var plants = new List<Plant>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_all_plants";
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

                        plants.Add(new Plant()
                        {
                            PlantID = reader.GetInt32(0),
                            CommonName = reader.GetString(1),
                            ScientificName = reader.GetString(2),
                            Care = reader.GetString(3),
                            GrowingZone = reader.GetString(4),
                            SoilType = reader.GetString(5),
                            //Image = reader["image"] as byte[] 
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
            return plants;
        }

        public static Plant RetrievePlant(int plantID)
        {
            var plant = new Plant();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_plant_by_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PlantID", plantID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                   
                        plant = new Plant()
                        {
                            PlantID = reader.GetInt32(0),
                            CommonName = reader.GetString(1),
                            ScientificName = reader.GetString(2),
                            Care = reader.GetString(3),
                            GrowingZone = reader.GetString(4),
                            SoilType = reader.GetString(5),

                        };
                    
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

            return plant;

        }

        public static List<Plant> RetrievePlantsByZoneSoil(string soilTypeId, string growingZoneId)
        {
            var plants = new List<Plant>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_plants";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SoilTypeID", SqlDbType.VarChar);
            cmd.Parameters["@SoilTypeID"].Value = soilTypeId;
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

                        plants.Add(new Plant()
                        {
                            PlantID = reader.GetInt32(0),
                            CommonName = reader.GetString(1),
                            ScientificName = reader.GetString(2),
                            GrowingZone = reader.GetString(3),
                            SoilType = reader.GetString(4)
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
            return plants;
        }

        public static int InsertPlant(Plant plant)
        {
            int rows = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_insert_plant";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CommonName", plant.CommonName);
            cmd.Parameters.AddWithValue("@ScientificName", plant.ScientificName);
            cmd.Parameters.AddWithValue("@SoilTypeID", plant.SoilType);
            cmd.Parameters.AddWithValue("@GrowingZoneID", plant.GrowingZone);
            cmd.Parameters.AddWithValue("@Care", plant.Care);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        public static int UpdatePlant(Plant oldPlant, Plant newPlant)
        {
            int rows = 0;

            var conn = DBConnection.GetDBConnection();
            
            var cmdText = @"sp_update_plant";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PlantID", oldPlant.PlantID);

            cmd.Parameters.AddWithValue("@OldCommonName", oldPlant.CommonName);
            cmd.Parameters.AddWithValue("@OldScientificName", oldPlant.ScientificName);
            cmd.Parameters.AddWithValue("@OldCare", oldPlant.Care);
            cmd.Parameters.AddWithValue("@NewCommonName", newPlant.CommonName);
            cmd.Parameters.AddWithValue("@NewScientificName", newPlant.ScientificName);
            cmd.Parameters.AddWithValue("@NewCare", newPlant.Care);


            var cmdText2 = @"sp_update_soil_type";
            
            var cmd2 = new SqlCommand(cmdText2, conn);
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Parameters.AddWithValue("@PlantID", oldPlant.PlantID);

            cmd2.Parameters.AddWithValue("@OldSoilTypeID", oldPlant.SoilType);
            cmd2.Parameters.AddWithValue("@NewSoilTypeID", newPlant.SoilType);


            var cmdText3 = @"sp_update_growing_zone";

            var cmd3 = new SqlCommand(cmdText3, conn);
            cmd3.CommandType = CommandType.StoredProcedure;

            cmd3.Parameters.AddWithValue("@PlantID", oldPlant.PlantID);

            cmd3.Parameters.AddWithValue("@OldGrowingZoneID", oldPlant.GrowingZone);
            cmd3.Parameters.AddWithValue("@NewGrowingZoneID", newPlant.GrowingZone);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                rows = cmd2.ExecuteNonQuery();
                rows = cmd3.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        public static int DeletePlant(int PlantID)
        {
            int rows = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_delete_plant";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PlantID", PlantID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
    }
}
