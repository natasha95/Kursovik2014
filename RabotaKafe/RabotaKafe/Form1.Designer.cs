namespace RabotaKafe
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.klient = new System.Windows.Forms.Button();
            this.produkt = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Button();
            this.zakaz = new System.Windows.Forms.Button();
            this.otchet = new System.Windows.Forms.Button();
            this.pochta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // klient
            // 
            this.klient.BackColor = System.Drawing.Color.PowderBlue;
            this.klient.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.klient.ForeColor = System.Drawing.Color.Black;
            this.klient.Location = new System.Drawing.Point(346, 12);
            this.klient.Name = "klient";
            this.klient.Size = new System.Drawing.Size(144, 69);
            this.klient.TabIndex = 0;
            this.klient.Text = "Клиенты";
            this.klient.UseVisualStyleBackColor = false;
            this.klient.Click += new System.EventHandler(this.klient_Click);
            // 
            // produkt
            // 
            this.produkt.BackColor = System.Drawing.Color.PowderBlue;
            this.produkt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.produkt.ForeColor = System.Drawing.Color.Black;
            this.produkt.Location = new System.Drawing.Point(12, 12);
            this.produkt.Name = "produkt";
            this.produkt.Size = new System.Drawing.Size(144, 69);
            this.produkt.TabIndex = 1;
            this.produkt.Text = "Продукты";
            this.produkt.UseVisualStyleBackColor = false;
            this.produkt.Click += new System.EventHandler(this.produkt_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.PowderBlue;
            this.menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menu.ForeColor = System.Drawing.Color.Black;
            this.menu.Location = new System.Drawing.Point(177, 12);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(144, 69);
            this.menu.TabIndex = 2;
            this.menu.Text = "Меню";
            this.menu.UseVisualStyleBackColor = false;
            this.menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // zakaz
            // 
            this.zakaz.BackColor = System.Drawing.Color.PowderBlue;
            this.zakaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zakaz.ForeColor = System.Drawing.Color.Black;
            this.zakaz.Location = new System.Drawing.Point(87, 131);
            this.zakaz.Name = "zakaz";
            this.zakaz.Size = new System.Drawing.Size(309, 69);
            this.zakaz.TabIndex = 3;
            this.zakaz.Text = "Работа с заказами";
            this.zakaz.UseVisualStyleBackColor = false;
            this.zakaz.Click += new System.EventHandler(this.zakaz_Click);
            // 
            // otchet
            // 
            this.otchet.BackColor = System.Drawing.Color.PowderBlue;
            this.otchet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otchet.Location = new System.Drawing.Point(135, 248);
            this.otchet.Name = "otchet";
            this.otchet.Size = new System.Drawing.Size(94, 69);
            this.otchet.TabIndex = 4;
            this.otchet.Text = "Отчет";
            this.otchet.UseVisualStyleBackColor = false;
            this.otchet.Click += new System.EventHandler(this.otchet_Click);
            // 
            // pochta
            // 
            this.pochta.BackColor = System.Drawing.Color.PowderBlue;
            this.pochta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pochta.Location = new System.Drawing.Point(257, 248);
            this.pochta.Name = "pochta";
            this.pochta.Size = new System.Drawing.Size(94, 69);
            this.pochta.TabIndex = 5;
            this.pochta.Text = "Почта";
            this.pochta.UseVisualStyleBackColor = false;
            this.pochta.Click += new System.EventHandler(this.pochta_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(502, 350);
            this.Controls.Add(this.pochta);
            this.Controls.Add(this.otchet);
            this.Controls.Add(this.zakaz);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.produkt);
            this.Controls.Add(this.klient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автоматизация работы кафе";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button klient;
        private System.Windows.Forms.Button produkt;
        private System.Windows.Forms.Button menu;
        private System.Windows.Forms.Button zakaz;
        private System.Windows.Forms.Button otchet;
        private System.Windows.Forms.Button pochta;
    }
}

