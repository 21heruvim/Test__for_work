namespace WinFormsTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxTables = new ListBox();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnCreate = new Button();
            dgvFields = new DataGridView();
            IsPrimaryKey = new DataGridViewCheckBoxColumn();
            FieldName = new DataGridViewTextBoxColumn();
            FieldType = new DataGridViewComboBoxColumn();
            textBoxTableName = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFields).BeginInit();
            SuspendLayout();
            // 
            // listBoxTables
            // 
            listBoxTables.FormattingEnabled = true;
            listBoxTables.ItemHeight = 15;
            listBoxTables.Location = new Point(12, 12);
            listBoxTables.Name = "listBoxTables";
            listBoxTables.Size = new Size(213, 424);
            listBoxTables.TabIndex = 0;
            listBoxTables.SelectedIndexChanged += listBoxTables_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(dgvFields);
            groupBox1.Controls.Add(textBoxTableName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(231, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(392, 424);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(311, 372);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(87, 372);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(168, 372);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(6, 372);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // dgvFields
            // 
            dgvFields.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFields.Columns.AddRange(new DataGridViewColumn[] { IsPrimaryKey, FieldName, FieldType });
            dgvFields.Location = new Point(6, 85);
            dgvFields.Name = "dgvFields";
            dgvFields.RowTemplate.Height = 25;
            dgvFields.Size = new Size(380, 268);
            dgvFields.TabIndex = 2;
            // 
            // IsPrimaryKey
            // 
            IsPrimaryKey.HeaderText = "PK";
            IsPrimaryKey.Name = "IsPrimaryKey";
            IsPrimaryKey.Width = 40;
            // 
            // FieldName
            // 
            FieldName.HeaderText = "Field Name";
            FieldName.Name = "FieldName";
            FieldName.Width = 170;
            // 
            // FieldType
            // 
            FieldType.HeaderText = "Field Type";
            FieldType.Items.AddRange(new object[] { "integer", "real", "text", "timestamp" });
            FieldType.Name = "FieldType";
            FieldType.Width = 127;
            // 
            // textBoxTableName
            // 
            textBoxTableName.Location = new Point(6, 37);
            textBoxTableName.Name = "textBoxTableName";
            textBoxTableName.Size = new Size(120, 23);
            textBoxTableName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "Table Name";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 450);
            Controls.Add(groupBox1);
            Controls.Add(listBoxTables);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFields).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxTables;
        private GroupBox groupBox1;
        private TextBox textBoxTableName;
        private Label label1;
        private DataGridView dgvFields;
        private Button btnDelete;
        private Button btnCreate;
        private Button btnEdit;
        private DataGridViewCheckBoxColumn IsPrimaryKey;
        private DataGridViewTextBoxColumn FieldName;
        private DataGridViewComboBoxColumn FieldType;
        private Button btnClear;
    }
}