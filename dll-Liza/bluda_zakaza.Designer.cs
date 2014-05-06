namespace dll_Liza
{
    partial class bluda_zakaza
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDzakazaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bludoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolvobludaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formirovaniezakaza1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kafeDataSet = new dll_Liza.kafeDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.formirovanie_zakaza1TableAdapter = new dll_Liza.kafeDataSetTableAdapters.Formirovanie_zakaza1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formirovaniezakaza1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID заказа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "(ID)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Клиент:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "(клиент)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.iDzakazaDataGridViewTextBoxColumn,
            this.bludoDataGridViewTextBoxColumn,
            this.kolvobludaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.formirovaniezakaza1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(558, 264);
            this.dataGridView1.TabIndex = 4;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 70;
            // 
            // iDzakazaDataGridViewTextBoxColumn
            // 
            this.iDzakazaDataGridViewTextBoxColumn.DataPropertyName = "ID_zakaza";
            this.iDzakazaDataGridViewTextBoxColumn.HeaderText = "ID заказа";
            this.iDzakazaDataGridViewTextBoxColumn.Name = "iDzakazaDataGridViewTextBoxColumn";
            this.iDzakazaDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDzakazaDataGridViewTextBoxColumn.Width = 80;
            // 
            // bludoDataGridViewTextBoxColumn
            // 
            this.bludoDataGridViewTextBoxColumn.DataPropertyName = "bludo";
            this.bludoDataGridViewTextBoxColumn.HeaderText = "Блюдо";
            this.bludoDataGridViewTextBoxColumn.Name = "bludoDataGridViewTextBoxColumn";
            this.bludoDataGridViewTextBoxColumn.ReadOnly = true;
            this.bludoDataGridViewTextBoxColumn.Width = 250;
            // 
            // kolvobludaDataGridViewTextBoxColumn
            // 
            this.kolvobludaDataGridViewTextBoxColumn.DataPropertyName = "Kolvo_bluda";
            this.kolvobludaDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.kolvobludaDataGridViewTextBoxColumn.Name = "kolvobludaDataGridViewTextBoxColumn";
            this.kolvobludaDataGridViewTextBoxColumn.ReadOnly = true;
            this.kolvobludaDataGridViewTextBoxColumn.Width = 80;
            // 
            // formirovaniezakaza1BindingSource
            // 
            this.formirovaniezakaza1BindingSource.DataMember = "Formirovanie_zakaza1";
            this.formirovaniezakaza1BindingSource.DataSource = this.kafeDataSet;
            // 
            // kafeDataSet
            // 
            this.kafeDataSet.DataSetName = "kafeDataSet";
            this.kafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Редактировать";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(271, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // formirovanie_zakaza1TableAdapter
            // 
            this.formirovanie_zakaza1TableAdapter.ClearBeforeFill = true;
            // 
            // bluda_zakaza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 330);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "bluda_zakaza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Блюда в заказе";
            this.Load += new System.EventHandler(this.bluda_zakaza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formirovaniezakaza1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private kafeDataSet kafeDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDzakazaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bludoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolvobludaDataGridViewTextBoxColumn;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.BindingSource formirovaniezakaza1BindingSource;
        public kafeDataSetTableAdapters.Formirovanie_zakaza1TableAdapter formirovanie_zakaza1TableAdapter;
    }
}