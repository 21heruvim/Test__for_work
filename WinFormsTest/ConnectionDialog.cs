using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
    public partial class ConnectionDialog : Form
    {
        public string ConnectionString { get; private set; }
        public ConnectionDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string connStr = BuildConnectionString();

            try
            {
                using var conn = new NpgsqlConnection(connStr);
                conn.Open();

                ConnectionString = connStr;

                string envContent =
                $"POSTGRES_HOST={textBoxHost.Text.Trim()}\n" +
                $"POSTGRES_PORT={textBoxPort.Text.Trim()}\n" +
                $"POSTGRES_DB={textBoxDatabase.Text.Trim()}\n" +
                $"POSTGRES_USER={textBoxUser.Text.Trim()}\n" +
                $"POSTGRES_PASSWORD={textBoxPassword.Text}";

                File.WriteAllText(".env", envContent);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildConnectionString()
        {
            string host = textBoxHost.Text.Trim();
            string port = textBoxPort.Text.Trim();
            string db = textBoxDatabase.Text.Trim();
            string user = textBoxUser.Text.Trim();
            string pass = textBoxPassword.Text;

            return $"Host={host};Port={port};Database={db};Username={user};Password={pass}";
        }
    }
}
