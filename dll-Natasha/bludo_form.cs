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
    public partial class bludo_form : Form
    {
        public bludo_form()
        {
            InitializeComponent();
        }

        private void menu_form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Bludo". При необходимости она может быть перемещена или удалена.
            this.bludoTableAdapter.Fill(this.kafeDataSet.Bludo);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //создаем объект второй формы
                dobavlenie_bluda f = new dobavlenie_bluda();

                // добавляем новую запись в таблицу
                bludoBindingSource.AddNew();

                // синхронизируем компоненты bindingSource обоих форм
                f.bludoBindingSource.DataSource = bludoBindingSource;

                // чтобы они указывали в таблице на одну и ту же запись
                f.bludoBindingSource.Position = bludoBindingSource.Position;

                // если пользователь в форме добавления нажал на первую кнопку:
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    // осуществляем выгрузку в DataGridView обновленных данных:
                    bludoTableAdapter.Update(this.kafeDataSet.Bludo);
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
                dobavlenie_bluda f = new dobavlenie_bluda();

                // синхронизируем компоненты bindingSource обоих форм
                f.bludoBindingSource.DataSource = bludoBindingSource;

                // чтобы они указывали в таблице на одну и ту же запись
                f.bludoBindingSource.Position = bludoBindingSource.Position;

                // если пользователь в форме добавления нажал на первую кнопку:
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    // осуществляем выгрузку в DataGridView обновленных данных:
                    bludoTableAdapter.Update(this.kafeDataSet.Bludo);
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show("Удалить блюдо со списком ингредиентов?", "Вопрос", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // пометка на удаление:
                    bludoBindingSource.RemoveCurrent();

                    // сохранение изменений:
                    bludoBindingSource.EndEdit();

                    // выгрузка в DataGridView обновленных данных:
                    bludoTableAdapter.Update(this.kafeDataSet.Bludo);
                }
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sostav_bluda f = new sostav_bluda();
            f.label2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            f.label4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            f.sostavbluda1BindingSource.Filter = "Nazvanie_bluda='" + f.label2.Text + "'";
            f.ShowDialog();
        }
    }
}
