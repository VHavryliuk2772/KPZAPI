namespace WITProject.Options.DatabaseConnectionOptions
{
    public class DatabaseConnection
    {
        public static string GetConnectionStringFromEnvironment()
        {
            string dbname = "ApplicationContextDB";

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = Environment.GetEnvironmentVariable("RDS_USERNAME");

            string password = Environment.GetEnvironmentVariable("RDS_PASSWORD");

            string hostname = Environment.GetEnvironmentVariable("RDS_HOSTNAME");

            string port = Environment.GetEnvironmentVariable("RDS_PORT");

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";

        }
    }
}
