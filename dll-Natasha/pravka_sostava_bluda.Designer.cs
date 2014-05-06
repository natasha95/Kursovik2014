namespace dll_Natasha
{
    partial class pravka_sostava_bluda
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.produkt1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kafeDataSet = new dll_Natasha.kafeDataSet();
            this.produkt1TableAdapter = new dll_Natasha.kafeDataSetTableAdapters.Produkt1TableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sostavbludaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sostav_bludaTableAdapter = new dll_Natasha.kafeDataSetTableAdapters.Sostav_bludaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.produkt1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sostavbludaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название продукта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Кол-во продукта";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 92);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(149, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(230, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produkt1BindingSource, "Nazvanie_produkta", true));
            this.comboBox1.DataSource = this.produkt1BindingSource;
            this.comboBox1.DisplayMember = "Nazvanie_produkta";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(124, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // produkt1BindingSource
            // 
            this.produkt1BindingSource.DataMember = "Produkt1";
            this.produkt1BindingSource.DataSource = this.kafeDataSet;
            // 
            // kafeDataSet
            // 
            this.kafeDataSet.DataSetName = "kafeDataSet";
            this.kafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produkt1TableAdapter
            // 
            this.produkt1TableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Блюдо:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "(название блюда)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "(ID блюда)";
            // 
            // sostavbludaBindingSource
            // 
            this.sostavbludaBindingSource.DataMember = "Sostav_bluda";
            this.sostavbludaBindingSource.DataSource = this.kafeDataSet;
            // 
            // sostav_bludaTableAdapter
            // 
            this.sostav_bludaTableAdapter.ClearBeforeFill = true;
            // 
            // pravka_sostava_bluda
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(315, 166);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pravka_sostava_bluda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Доб/ред состава блюда";
            this.Load += new System.EventHandler(this.pravka_sostava_bluda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.produkt1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kafeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sostavbludaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private kafeDataSet kafeDataSet;
        public System.Windows.Forms.BindingSource produkt1BindingSource;
        public kafeDataSetTableAdapters.Produkt1TableAdapter produkt1TableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.BindingSource sostavbludaBindingSource;
        public kafeDataSetTableAdapters.Sostav_bludaTableAdapter sostav_bludaTableAdapter;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}