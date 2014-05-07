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
    public partial class bluda_zakaza : Form
    {
        public bluda_zakaza()
        {
            InitializeComponent();
        }

        private void bluda_zakaza_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Formirovanie_zakaza1". При необходимости она может быть перемещена или удалена.
            this.formirovanie_zakaza1TableAdapter.Fill(this.kafeDataSet.Formirovanie_zakaza1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //создаем объект второй формы
            bludo_v_zakaz f = new bludo_v_zakaz();
            f.mode = true;
            f.id_zakaza = Convert.ToInt32(label2.Text);

            // если пользователь в форме добавления нажал на первую кнопку:
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // осуществляем выгрузку в DataGridView обновленных данных:
                this.formirovanie_zakaza1TableAdapter.Fill(this.kafeDataSet.Formirovanie_zakaza1);
                formirovanie_zakaza1TableAdapter.Update(this.kafeDataSet.Formirovanie_zakaza1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // пометка на удаление:
            formirovaniezakaza1BindingSource.RemoveCurrent();

            // сохранение изменений:
            formirovaniezakaza1BindingSource.EndEdit();

            // выгрузка в DataGridView обновленных данных:
            formirovanie_zakaza1TableAdapter.Update(this.kafeDataSet.Formirovanie_zakaza1); 
        }
    }
}
