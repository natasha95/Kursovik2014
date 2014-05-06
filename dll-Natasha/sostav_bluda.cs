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
    public partial class sostav_bluda : Form
    {
        public sostav_bluda()
        {
            InitializeComponent();
        }

        private void sostav_bluda_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Sostav_bluda1". При необходимости она может быть перемещена или удалена.
            this.sostav_bluda1TableAdapter.Fill(this.kafeDataSet.Sostav_bluda1);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //создаем объект второй формы
            pravka_sostava_bluda f = new pravka_sostava_bluda();
            f.mode = true;
            f.label5.Text = label2.Text;
            f.label6.Text = label4.Text;

            // если пользователь в форме добавления нажал на первую кнопку:
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // осуществляем выгрузку в DataGridView обновленных данных:
                this.sostav_bluda1TableAdapter.Fill(this.kafeDataSet.Sostav_bluda1);
                sostav_bluda1TableAdapter.Update(this.kafeDataSet.Sostav_bluda1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //создаем объект второй формы
            pravka_sostava_bluda f = new pravka_sostava_bluda();
            f.mode = false;
            f.label5.Text = label2.Text;
            f.label6.Text = label4.Text;
            string nazvanie_produkta = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridViewTextBoxColumn4.DisplayIndex].Value.ToString();
            string kolvo_produkta = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridViewTextBoxColumn2.DisplayIndex].Value.ToString();
            string ID_sostava = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridViewTextBoxColumn1.DisplayIndex].Value.ToString();

            // установка значений
            f.sostav_ID = ID_sostava;
            f.textBox3.Text = kolvo_produkta;
            f.nazvanie_produkta = nazvanie_produkta;

            // если пользователь в форме добавления нажал на первую кнопку:
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // осуществляем выгрузку в DataGridView обновленных данных:
                this.sostav_bluda1TableAdapter.Fill(this.kafeDataSet.Sostav_bluda1);
                sostav_bluda1TableAdapter.Update(this.kafeDataSet.Sostav_bluda1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // пометка на удаление:
            sostavbluda1BindingSource.RemoveCurrent();

            // сохранение изменений:
            sostavbluda1BindingSource.EndEdit();

            // выгрузка в DataGridView обновленных данных:
            sostav_bluda1TableAdapter.Update(this.kafeDataSet.Sostav_bluda1); 
        }
    }
}
