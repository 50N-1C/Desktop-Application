using MySql.Data.MySqlClient;

public class DatabaseHelper
{
    private string connectionString;

    public DatabaseHelper(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public bool RegisterUser(string username, string password, string email)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO users (username, password, email) VALUES (@username, @password, @.email)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@.email", email);
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public bool ValidateUser(string username, string password)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM users WHERE username=@username AND password=@password";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}
