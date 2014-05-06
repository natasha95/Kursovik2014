namespace dll_Liza
{
    partial class bludo_v_zakaz
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
            this.kafeDataSet = new dll_Liza.kafeDataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bludo1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bludo1TableAdapter = new dll_Liza.kafeDataSetTableAdapters.Bludo1TableAdapter();
            this.formirovaniezakazaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formirovanie_zakazaTableAdapter = new dll_Liza.kafeDataSetTableAdapters.Formirovanie_zakazaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bludo1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formirovaniezakazaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Блюдо";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Кол-во";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.kafeDataSet, "Bludo1.nazvanie_bluda", true));
            this.comboBox1.DataSource = this.bludo1BindingSource;
            this.comboBox1.DisplayMember = "nazvanie_bluda";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(68, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(308, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // kafeDataSet
            // 
            this.kafeDataSet.DataSetName = "kafeDataSet";
            this.kafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(219, 71);
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
            this.button2.Location = new System.Drawing.Point(300, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
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
            // formirovaniezakazaBindingSource
            // 
            this.formirovaniezakazaBindingSource.DataMember = "Formirovanie_zakaza";
            this.formirovaniezakazaBindingSource.DataSource = this.kafeDataSet;
            // 
            // formirovanie_zakazaTableAdapter
            // 
            this.formirovanie_zakazaTableAdapter.ClearBeforeFill = true;
            // 
            // bludo_v_zakaz
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(387, 108);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "bludo_v_zakaz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление блюда в заказ";
            this.Load += new System.EventHandler(this.bludo_v_zakaz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bludo1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formirovaniezakazaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private kafeDataSet kafeDataSet;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.BindingSource bludo1BindingSource;
        public kafeDataSetTableAdapters.Bludo1TableAdapter bludo1TableAdapter;
        public System.Windows.Forms.BindingSource formirovaniezakazaBindingSource;
        public kafeDataSetTableAdapters.Formirovanie_zakazaTableAdapter formirovanie_zakazaTableAdapter;
    }
}