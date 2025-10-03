using dotenv.net;
using Npgsql;

namespace WinFormsTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            DotEnv.Load();
            string host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
            string port = Environment.GetEnvironmentVariable("POSTGRES_PORT");
            string db = Environment.GetEnvironmentVariable("POSTGRES_DB");
            string user = Environment.GetEnvironmentVariable("POSTGRES_USER");
            string pass = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

            string connStr;

            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(db) || string.IsNullOrWhiteSpace(user))
            {
                using var dlg = new ConnectionDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    connStr = dlg.ConnectionString;
                }
                else
                {
                    return;
                }
            }
            else
            {
                connStr = $"Host={host};Port={port};Database={db};Username={user};Password={pass}";
            }

            try
            {
                using var conn = new NpgsqlConnection(connStr);
                conn.Open();

                Application.Run(new Form1(connStr));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}