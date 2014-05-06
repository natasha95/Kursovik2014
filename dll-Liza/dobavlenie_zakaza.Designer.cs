namespace dll_Liza
{
    partial class dobavlenie_zakaza
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.klientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kafeDataSet = new dll_Liza.kafeDataSet();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.klientTableAdapter = new dll_Liza.kafeDataSetTableAdapters.KlientTableAdapter();
            this.zakazBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zakazTableAdapter = new dll_Liza.kafeDataSetTableAdapters.ZakazTableAdapter();
            this.klient1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.klient1TableAdapter = new dll_Liza.kafeDataSetTableAdapters.Klient1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.klientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zakazBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.klient1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Клиент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.klientBindingSource, "FIO", true));
            this.comboBox1.DataSource = this.klient1BindingSource;
            this.comboBox1.DisplayMember = "fio1";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(66, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(272, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // klientBindingSource
            // 
            this.klientBindingSource.DataMember = "Klient";
            this.klientBindingSource.DataSource = this.kafeDataSet;
            // 
            // kafeDataSet
            // 
            this.kafeDataSet.DataSetName = "kafeDataSet";
            this.kafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(66, 41);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(152, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(179, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(260, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // klientTableAdapter
            // 
            this.klientTableAdapter.ClearBeforeFill = true;
            // 
            // zakazBindingSource
            // 
            this.zakazBindingSource.DataMember = "Zakaz";
            this.zakazBindingSource.DataSource = this.kafeDataSet;
            // 
            // zakazTableAdapter
            // 
            this.zakazTableAdapter.ClearBeforeFill = true;
            // 
            // klient1BindingSource
            // 
            this.klient1BindingSource.DataMember = "Klient1";
            this.klient1BindingSource.DataSource = this.kafeDataSet;
            // 
            // klient1TableAdapter
            // 
            this.klient1TableAdapter.ClearBeforeFill = true;
            // 
            // dobavlenie_zakaza
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(347, 112);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dobavlenie_zakaza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление/редактирование заказа";
            this.Load += new System.EventHandler(this.dobavlenie_zakaza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.klientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zakazBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.klient1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private kafeDataSet kafeDataSet;
        private System.Windows.Forms.BindingSource klientBindingSource;
        private kafeDataSetTableAdapters.KlientTableAdapter klientTableAdapter;
        private System.Windows.Forms.BindingSource zakazBindingSource;
        private kafeDataSetTableAdapters.ZakazTableAdapter zakazTableAdapter;
        private System.Windows.Forms.BindingSource klient1BindingSource;
        private kafeDataSetTableAdapters.Klient1TableAdapter klient1TableAdapter;
    }
}