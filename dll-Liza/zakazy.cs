using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dll_Liza
{
    public partial class zakazy : Form
    {
        public zakazy()
        {
            InitializeComponent();
        }

        private void zakazy_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Zakaz1". При необходимости она может быть перемещена или удалена.
            this.zakaz1TableAdapter.Fill(this.kafeDataSet.Zakaz1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //создаем объект второй формы
            dobavlenie_zakaza f = new dobavlenie_zakaza();
            f.mode = true; // режим добавления

            // если пользователь в форме добавления нажал на первую кнопку:
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // осуществляем выгрузку в DataGridView обновленных данных:
                this.zakaz1TableAdapter.Fill(this.kafeDataSet.Zakaz1);
                zakaz1TableAdapter.Update(this.kafeDataSet.Zakaz1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //создаем объект второй формы
            dobavlenie_zakaza f = new dobavlenie_zakaza();
            f.mode = false; // режим редактирования
            f.zakaz_id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[iDDataGridViewTextBoxColumn.DisplayIndex].Value.ToString());
            f.klient_fio = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[klientfioDataGridViewTextBoxColumn.DisplayIndex].Value.ToString();
            f.dt = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataDataGridViewTextBoxColumn.DisplayIndex].Value.ToString());

            // если пользователь в форме добавления нажал на первую кнопку:
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // осуществляем выгрузку в DataGridView обновленных данных:
                this.zakaz1TableAdapter.Fill(this.kafeDataSet.Zakaz1);
                zakaz1TableAdapter.Update(this.kafeDataSet.Zakaz1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Заказ будет удален со списком блюд. Продолжить?", "Вопрос", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                // пометка на удаление:
                zakaz1BindingSource.RemoveCurrent();

                // сохранение изменений:
                zakaz1BindingSource.EndEdit();

                // выгрузка в DataGridView обновленных данных:
                zakaz1TableAdapter.Update(this.kafeDataSet.Zakaz1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bluda_zakaza f = new bluda_zakaza();
            f.label2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[iDDataGridViewTextBoxColumn.DisplayIndex].Value.ToString();
            f.label4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[klientfioDataGridViewTextBoxColumn.DisplayIndex].Value.ToString();
            f.formirovaniezakaza1BindingSource.Filter = "ID_zakaza='" + f.label2.Text + "'";
            f.ShowDialog();

            this.zakaz1TableAdapter.Fill(this.kafeDataSet.Zakaz1);
            zakaz1TableAdapter.Update(this.kafeDataSet.Zakaz1);
        }
    }
}
