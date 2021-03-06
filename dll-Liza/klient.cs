﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dll_Liza
{
    public partial class klient : Form
    {
        public klient()
        {
            InitializeComponent();
        }

        private void klient_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Klient". При необходимости она может быть перемещена или удалена.
            this.klientTableAdapter.Fill(this.kafeDataSet.Klient);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //пометка на удаление:
            klientBindingSource.RemoveCurrent();

            // сохранение изменений:
            klientBindingSource.EndEdit();

            // выгрузка в DataGridView обновленных данных:
            klientTableAdapter.Update(this.kafeDataSet.Klient); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // создаем объект второй формы
                dobavlenie_klienta f = new dobavlenie_klienta();

                // добавляем новую запись в таблицу
                klientBindingSource.AddNew();

                // синхронизируем компоненты bindingSource обоих форм
                f.klientBindingSource.DataSource = klientBindingSource;

                // чтобы они указывали в таблице на одну и ту же запись
                f.klientBindingSource.Position = klientBindingSource.Position;

                // если пользователь в форме добавления нажал на первую кнопку:
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // осуществляем выгрузку в DataGridView обновленных данных:
                    klientTableAdapter.Update(this.kafeDataSet.Klient);
                }
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // создаем объект второй формы
                dobavlenie_klienta f = new dobavlenie_klienta();

                // синхронизируем компоненты bindingSource обоих форм
                f.klientBindingSource.DataSource = klientBindingSource;

                // чтобы они указывали в таблице на одну и ту же запись
                f.klientBindingSource.Position = klientBindingSource.Position;

                // если пользователь в форме добавления нажал на первую кнопку:
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // осуществляем выгрузку в DataGridView обновленных данных:
                    klientTableAdapter.Update(this.kafeDataSet.Klient);
                }
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
