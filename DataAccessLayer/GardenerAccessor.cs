using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GardenerAccessor
    {
        public static List<Gardener> RetrieveUsers(bool active = true)
        {
            var gardeners = new List<Gardener>();
            var conn = DBConnection.GetDBConnection();
            var cmdText = @"SELECT UserID, FirstName, " +
                               @"LastName, PhoneNumber, " +
                               @"Email, UserName, Active " +
                          @"FROM Gardener " +
                          @"WHERE Active = @active ";

            var cmd = new SqlCommand(cmdText, conn);

            int activeBit = active ? 1 : 0;
            cmd.Parameters.Add("@active", SqlDbType.Bit);
            cmd.Parameters["@active"].Value = activeBit;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var gard = new Gardener()
                        {
                            UserID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                            Email = reader.GetString(4),
                            UserName = reader.GetString(5),
                            Active = reader.GetBoolean(6)
                        };

                        gardeners.Add(gard);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("There was a problem retrieving your data.", ex);
            }
            finally
            {
                conn.Close();
            }

            return gardeners;
        }
    }
}
