using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dll_Natasha
{
    public partial class produkt_form : Form
    {
        public produkt_form()
        {
            InitializeComponent();
        }

        private void produkt_form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Produkt". При необходимости она может быть перемещена или удалена.
            this.produktTableAdapter.Fill(this.kafeDataSet.Produkt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // пометка на удаление:
            produktBindingSource.RemoveCurrent();

            // сохранение изменений:
            produktBindingSource.EndEdit();

            // выгрузка в DataGridView обновленных данных:
            produktTableAdapter.Update(this.kafeDataSet.Produkt); 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // создаем объект второй формы
            dobavlenie_produkta f = new dobavlenie_produkta();

            // добавляем новую запись в таблицу
            produktBindingSource.AddNew();

            // синхронизируем компоненты bindingSource обоих форм
            f.produktBindingSource.DataSource = produktBindingSource;

            // чтобы они указывали в таблице на одну и ту же запись
            f.produktBindingSource.Position = produktBindingSource.Position;

            //если пользователь в форме добавления нажал на первую кнопку:
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //осуществляем выгрузку в DataGridView обновленных данных:
                produktTableAdapter.Update(this.kafeDataSet.Produkt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // создаем объект второй формы:
            dobavlenie_produkta f = new dobavlenie_produkta();

            // синхронизируем компоненты bindingSource обоих форм:
            f.produktBindingSource.DataSource = produktBindingSource;

            // чтобы они указывали в таблице на одну и ту же запись:
            f.produktBindingSource.Position = produktBindingSource.Position;

            // если пользователь в форме добавления нажал на первую кнопку:
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                // осуществляем выгрузку в DataGridView обновленных данных:
                produktTableAdapter.Update(this.kafeDataSet.Produkt);
        }
    }
}
