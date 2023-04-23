using System;
using EvolveDb;
using EvolveDb.Dialect;
using MySql.Data.MySqlClient;

namespace BetServices.Integration.Test.Seeders
{
    public class MySqlSeeder
    {
        public static MySqlConnection Connection = new MySqlConnection(Environment
            .GetEnvironmentVariable("DB_CONNECTION"));

        public static void SeedContext()
        {
            Connection.Open();
            try
            {
                var evolve = new Evolve(Connection, msg => Console.WriteLine(msg), DBMS.MySQL)
                {
                    Locations = new[] {"Migrations"},
                    IsEraseDisabled = false
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Database migration failed {ex}");
                throw;
            }
        }

        public static void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}