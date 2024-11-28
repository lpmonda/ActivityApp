using MySql.Data.MySqlClient;

namespace AspNetcore1.model
{
    public class ModelContext
    {
        public string ConnectionString { get; set; }

        public ModelContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<MFC> GetAllMFC()
        {
            List<MFC> list = new List<MFC>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM mfc", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MFC()
                        {
                            MFCId = reader.GetInt32("mfc_id"),
                            Name = reader.GetString("title"),
                            Setpoint = reader.GetInt32("setpoint"),
                            Measure = reader.GetInt32("value"),
                            GasId = reader.GetString("gasid")
                        });
                    }
                }
            }

            return list;
        }

    }
}
