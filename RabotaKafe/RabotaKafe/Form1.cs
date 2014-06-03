using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dll_Liza;
using dll_Natasha;
using Excel = Microsoft.Office.Interop.Excel;

namespace RabotaKafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void produkt_Click(object sender, EventArgs e)
        {
            produkt_form pf = new produkt_form();
            pf.ShowDialog();
        }

        private void klient_Click(object sender, EventArgs e)
        {
            klient cf = new klient();
            cf.ShowDialog();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            bludo_form mf = new bludo_form();
            mf.ShowDialog();
        }

        private void zakaz_Click(object sender, EventArgs e)
        {
            zakazy zf = new zakazy();
            zf.ShowDialog();
        }

        private void otchet_Click(object sender, EventArgs e)
        {
            otchet_form f = new otchet_form();
            f.ShowDialog();
        }

        private void pochta_Click(object sender, EventArgs e)
        {
            pochta_form f = new pochta_form();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Klient". При необходимости она может быть перемещена или удалена.
            this.klientTableAdapter.Fill(this.kafeDataSet.Klient);
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                label2.Text = "";
                return;
            }
            string s = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridViewTextBoxColumn3.DisplayIndex].Value.ToString();
            int summaPokupok = 0;
            if (s == "")
            {
                summaPokupok = 0;
            }
            else
            {
                summaPokupok = Convert.ToInt32(s);
            }
            string skidka = "";
            if (summaPokupok > 3000)
            {
                skidka = "7%";
            }
            else if (summaPokupok > 2000)
            {
                skidka = "5%";
            }
            else if (summaPokupok > 1000)
            {
                skidka = "2%";
            }
            else
            {
                skidka = "0";
            }
            label2.Text = skidka;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //создаем объект второй формы
                dobavlenie_zakaza f = new dobavlenie_zakaza();
                f.mode = false; // режим редактирования
                f.klient_fio = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridViewTextBoxColumn4.DisplayIndex].Value.ToString();
                f.dt = DateTime.Now;
                f.dobavlenie_zakaza_Load(sender, e);
                f.mode = true; // режим добавления
                f.button1_Click(sender, e);
                
                // открываем форму работы с заказами
                zakazy zf = new zakazy();
                zf.otkr_bluda = true;
                zf.ShowDialog();
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.Text == "") return;
                if (comboBox2.SelectedIndex == 0)
                {
                    // поиск по номеру телефона
                    klientBindingSource.Filter = "Telefon LIKE '*" + comboBox3.Text + "*'";
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    // поиск по ФИО
                    klientBindingSource.Filter = "FIO LIKE '*" + comboBox3.Text + "*'";
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    // поиск по номеру карты
                    klientBindingSource.Filter = "NomerKarty LIKE '*" + comboBox3.Text + "*'";
                }
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            klientBindingSource.Filter = string.Empty;
        }

        private void comboBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (comboBox3.Text == "")
            {
                button6_Click(sender, e);
                return;
            }
            if (comboBox2.SelectedIndex == 0)
            {
                // поиск по номеру телефона
                klientBindingSource.Filter = "Telefon LIKE '*" + comboBox3.Text + "*'";
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                // поиск по ФИО
                klientBindingSource.Filter = "FIO LIKE '*" + comboBox3.Text + "*'";
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                // поиск по номеру карты
                klientBindingSource.Filter = "NomerKarty LIKE '*" + comboBox3.Text + "*'";
            }
        }
    }
}
