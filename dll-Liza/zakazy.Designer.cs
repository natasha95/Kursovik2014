namespace dll_Liza
{
    partial class zakazy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zakaz1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kafeDataSet = new dll_Liza.kafeDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.zakaz1TableAdapter = new dll_Liza.kafeDataSetTableAdapters.Zakaz1TableAdapter();
            this.button5 = new System.Windows.Forms.Button();
            this.klientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.klientTableAdapter = new dll_Liza.kafeDataSetTableAdapters.KlientTableAdapter();
            this.formirovaniezakaza1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formirovanie_zakaza1TableAdapter = new dll_Liza.kafeDataSetTableAdapters.Formirovanie_zakaza1TableAdapter();
            this.bludo1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bludo1TableAdapter = new dll_Liza.kafeDataSetTableAdapters.Bludo1TableAdapter();
            this.summazakazaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klientfioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zakaz1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.klientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formirovaniezakaza1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bludo1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.klientfioDataGridViewTextBoxColumn,
            this.summazakazaDataGridViewTextBoxColumn,
            this.Status});
            this.dataGridView1.DataSource = this.zakaz1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(674, 309);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 70;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Статус";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 80;
            // 
            // zakaz1BindingSource
            // 
            this.zakaz1BindingSource.DataMember = "Zakaz1";
            this.zakaz1BindingSource.DataSource = this.kafeDataSet;
            // 
            // kafeDataSet
            // 
            this.kafeDataSet.DataSetName = "kafeDataSet";
            this.kafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить заказ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 328);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Изменить описание заказа";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(594, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(304, 328);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Редактировать список блюд";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // zakaz1TableAdapter
            // 
            this.zakaz1TableAdapter.ClearBeforeFill = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(480, 327);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Закрыть заказ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // klientBindingSource
            // 
            this.klientBindingSource.DataMember = "Klient";
            this.klientBindingSource.DataSource = this.kafeDataSet;
            // 
            // klientTableAdapter
            // 
            this.klientTableAdapter.ClearBeforeFill = true;
            // 
            // formirovaniezakaza1BindingSource
            // 
            this.formirovaniezakaza1BindingSource.DataMember = "Formirovanie_zakaza1";
            this.formirovaniezakaza1BindingSource.DataSource = this.kafeDataSet;
            // 
            // formirovanie_zakaza1TableAdapter
            // 
            this.formirovanie_zakaza1TableAdapter.ClearBeforeFill = true;
            // 
            // bludo1BindingSource
            // 
            this.bludo1BindingSource.DataMember = "Bludo1";
            this.bludo1BindingSource.DataSource = this.kafeDataSet;
            // 
            // bludo1TableAdapter
            // 
            this.bludo1TableAdapter.ClearBeforeFill = true;
            // 
            // summazakazaDataGridViewTextBoxColumn
            // 
            this.summazakazaDataGridViewTextBoxColumn.DataPropertyName = "Summa_zakaza";
            this.summazakazaDataGridViewTextBoxColumn.HeaderText = "Сумма заказа";
            this.summazakazaDataGridViewTextBoxColumn.Name = "summazakazaDataGridViewTextBoxColumn";
            this.summazakazaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // klientfioDataGridViewTextBoxColumn
            // 
            this.klientfioDataGridViewTextBoxColumn.DataPropertyName = "klient_fio";
            this.klientfioDataGridViewTextBoxColumn.HeaderText = "Клиент";
            this.klientfioDataGridViewTextBoxColumn.Name = "klientfioDataGridViewTextBoxColumn";
            this.klientfioDataGridViewTextBoxColumn.ReadOnly = true;
            this.klientfioDataGridViewTextBoxColumn.Width = 250;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zakazy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 361);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "zakazy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Работа с заказами";
            this.Load += new System.EventHandler(this.zakazy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zakaz1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.klientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formirovaniezakaza1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bludo1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private kafeDataSet kafeDataSet;
        public System.Windows.Forms.BindingSource zakaz1BindingSource;
        public kafeDataSetTableAdapters.Zakaz1TableAdapter zakaz1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.BindingSource klientBindingSource;
        public kafeDataSetTableAdapters.KlientTableAdapter klientTableAdapter;
        public System.Windows.Forms.BindingSource formirovaniezakaza1BindingSource;
        public kafeDataSetTableAdapters.Formirovanie_zakaza1TableAdapter formirovanie_zakaza1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn klientfioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summazakazaDataGridViewTextBoxColumn;
        public System.Windows.Forms.BindingSource bludo1BindingSource;
        public kafeDataSetTableAdapters.Bludo1TableAdapter bludo1TableAdapter;
    }
}