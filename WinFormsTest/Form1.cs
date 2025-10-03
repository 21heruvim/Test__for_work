using Npgsql;
using System.Windows.Forms;

namespace WinFormsTest
{
    public partial class Form1 : Form
    {
        string connectionString;
        public Form1(string connStr)
        {
            InitializeComponent();
            connectionString = connStr;

            LoadTables();
        }

        private void LoadTables()
        {
            listBoxTables.Items.Clear();

            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();

                string sql = @"SELECT table_name
                           FROM information_schema.tables
                           WHERE table_schema='public' AND table_type='BASE TABLE'
                           ORDER BY table_name;";

                using var cmd = new NpgsqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listBoxTables.Items.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке таблиц: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string NormalizeType(string pgType)
        {
            switch (pgType)
            {
                case "integer": return "integer";
                case "double precision":
                case "real": return "real";
                case "text":
                case "character varying": return "text";
                case "timestamp without time zone":
                case "timestamp with time zone": return "timestamp";
                default: return pgType;
            }
        }
        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem == null) return;

            string tableName = listBoxTables.SelectedItem.ToString();

            dgvFields.Rows.Clear();

            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();

                string sqlColumns = @"
                    SELECT column_name, data_type
                    FROM information_schema.columns
                    WHERE table_name = @table
                    ORDER BY ordinal_position;";

                using var cmd = new NpgsqlCommand(sqlColumns, conn);
                cmd.Parameters.AddWithValue("table", tableName);

                var columns = new List<(string Name, string Type)>();

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string type = reader.GetString(1);
                    columns.Add((name, type));
                }
                reader.Close();

                string sqlPK = @"
                    SELECT a.attname
                    FROM pg_index i
                    JOIN pg_attribute a ON a.attrelid = i.indrelid AND a.attnum = ANY(i.indkey)
                    WHERE i.indrelid = @table::regclass AND i.indisprimary;";
                using var cmdPK = new NpgsqlCommand(sqlPK, conn);
                cmdPK.Parameters.AddWithValue("table", tableName);

                var pkColumns = new HashSet<string>();
                using var readerPK = cmdPK.ExecuteReader();
                while (readerPK.Read())
                {
                    pkColumns.Add(readerPK.GetString(0));
                }

                foreach (var col in columns)
                {
                    bool isPK = pkColumns.Contains(col.Name);
                    dgvFields.Rows.Add(isPK, col.Name, NormalizeType(col.Type));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке структуры таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу для удаления.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tableName = listBoxTables.SelectedItem.ToString();

            var confirm = MessageBox.Show(
                $"Вы действительно хотите удалить таблицу '{tableName}'?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using var conn = new NpgsqlConnection(connectionString);
                    conn.Open();

                    string sql = $"DROP TABLE IF EXISTS \"{tableName}\" CASCADE;";
                    using var cmd = new NpgsqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Таблица '{tableName}' удалена.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadTables();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvFields.DataSource = null;
            dgvFields.Rows.Clear();

            textBoxTableName.Clear();
            listBoxTables.ClearSelected();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string tableName = textBoxTableName.Text.Trim();

            if (string.IsNullOrWhiteSpace(tableName))
            {
                MessageBox.Show("Введите имя таблицы.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvFields.Rows.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одно поле.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> columnDefs = new List<string>();
            List<string> primaryKeys = new List<string>();

            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                if (row.IsNewRow) continue;

                string colName = row.Cells["FieldName"].Value?.ToString()?.Trim();
                string colType = row.Cells["FieldType"].Value?.ToString();
                bool isPK = row.Cells["IsPrimaryKey"].Value is bool b && b;

                if (string.IsNullOrWhiteSpace(colName) || string.IsNullOrWhiteSpace(colType))
                    continue;

                columnDefs.Add($"{colName} {colType}");

                if (isPK)
                    primaryKeys.Add(colName);
            }

            if (columnDefs.Count == 0)
            {
                MessageBox.Show("Нет корректных полей для таблицы.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $"CREATE TABLE {tableName} (\n    {string.Join(",\n    ", columnDefs)}";

            if (primaryKeys.Count > 0)
            {
                sql += $",\n    PRIMARY KEY ({string.Join(", ", primaryKeys)})";
            }

            sql += "\n);";

            try
            {
                using var conn = new Npgsql.NpgsqlConnection(connectionString);
                conn.Open();

                using var cmd = new Npgsql.NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Таблица успешно создана!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу для редактирования.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tableName = listBoxTables.SelectedItem.ToString();

            if (dgvFields.Rows.Count == 0)
            {
                MessageBox.Show("Нет полей для редактирования.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newColumns = new List<(string Name, string Type, bool IsPK)>();
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                if (row.IsNewRow) continue;
                string name = row.Cells["FieldName"].Value?.ToString()?.Trim();
                string type = row.Cells["FieldType"].Value?.ToString();
                bool isPK = row.Cells["IsPrimaryKey"].Value is bool b && b;

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(type))
                    newColumns.Add((name, type, isPK));
            }

            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                using var tran = conn.BeginTransaction();

                string dropPK = $@"
                    DO $$
                    BEGIN
                        IF EXISTS (
                            SELECT 1 FROM pg_constraint
                            WHERE conrelid = '{tableName}'::regclass AND contype = 'p'
                        ) THEN
                            ALTER TABLE {tableName} DROP CONSTRAINT {tableName}_pkey;
                        END IF;
                    END$$;";
                using var cmdDropPK = new NpgsqlCommand(dropPK, conn, tran);
                cmdDropPK.ExecuteNonQuery();

                foreach (var col in newColumns)
                {
                    string sql = $@"
                        DO $$
                        BEGIN
                            IF NOT EXISTS (
                                SELECT 1
                                FROM information_schema.columns
                                WHERE table_name='{tableName}' AND column_name='{col.Name}'
                            ) THEN
                                ALTER TABLE {tableName} ADD COLUMN {col.Name} {col.Type};
                            ELSE
                                ALTER TABLE {tableName} ALTER COLUMN {col.Name} TYPE {col.Type};
                            END IF;
                        END$$;";
                    using var cmd = new NpgsqlCommand(sql, conn, tran);
                    cmd.ExecuteNonQuery();
                }

                var pkCols = newColumns.Where(c => c.IsPK).Select(c => c.Name).ToList();
                if (pkCols.Count > 0)
                {
                    string addPK = $"ALTER TABLE {tableName} ADD PRIMARY KEY ({string.Join(", ", pkCols)});";
                    using var cmdPK = new NpgsqlCommand(addPK, conn, tran);
                    cmdPK.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show("Таблица успешно обновлена!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}