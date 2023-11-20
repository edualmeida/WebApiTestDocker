using Npgsql;

namespace WebApiTestDocker.Services
{
    public class Postgres
    {
        public string GetValue()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=pgsql-dev;User Id=postgres;Password=test1234;Database=postgres;");

            conn.Open();

            // Passing PostGre SQL Function Name
            NpgsqlCommand command = new NpgsqlCommand("Select colValue from testTable limit 1", conn);

            // Execute the query and obtain a result set
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reading from the database rows
            List<string> listOfManager = new List<string>();
            var res = "";

            while (reader.Read())
            {
                res = reader["colvalue"].ToString(); // Remember Type Casting is required here it has to be according to database column data type
                //listOfManager.Add(WSManager);
            }
            reader.Close();

            command.Dispose();
            conn.Close();

            return res;
        }
    }
}
