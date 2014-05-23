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
            // TODO: This line of code loads data into the 'kafeDataSet.Klient' table. You can move, or remove it, as needed.
            this.klientTableAdapter.Fill(this.kafeDataSet.Klient);
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

                // сразу открываем окно редактирования списка блюд
                zakaz1BindingSource.MoveLast();
                button4.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string status = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[Status.DisplayIndex].Value.ToString();
            if (status == "закрыт") return;
            
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
            string status = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[Status.DisplayIndex].Value.ToString();
            if (status == "закрыт") return;

            bluda_zakaza f = new bluda_zakaza();
            f.label2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[iDDataGridViewTextBoxColumn.DisplayIndex].Value.ToString();
            f.label4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[klientfioDataGridViewTextBoxColumn.DisplayIndex].Value.ToString();
            f.formirovaniezakaza1BindingSource.Filter = "ID_zakaza='" + f.label2.Text + "'";
            f.ShowDialog();

            this.zakaz1TableAdapter.Fill(this.kafeDataSet.Zakaz1);
            zakaz1TableAdapter.Update(this.kafeDataSet.Zakaz1);
        }

        // Добавление суммы закрытого заказа на счет клиента
        public void dobavit_zakaz_klientu(int id_klienta, int summa)
        {
            klientBindingSource.MoveFirst();
            kafeDataSet.KlientRow r2 = (kafeDataSet.KlientRow)((DataRowView)klientBindingSource.Current).Row;
            int i = 0;
            while (i < klientBindingSource.List.Count)
            {
                r2 = (kafeDataSet.KlientRow)((DataRowView)klientBindingSource.Current).Row;
                if (r2.ID == id_klienta)
                {
                    r2.SummaPokupok += summa;
                    klientBindingSource.EndEdit();
                    klientTableAdapter.Update(this.kafeDataSet.Klient);
                    this.klientTableAdapter.Fill(this.kafeDataSet.Klient);
                    return;
                }
                klientBindingSource.MoveNext();
                i++;
            }
        }

        // получение скидки на заказ
        public int skidka_na_zakaz(int id_klienta, int summaZakaza)
        {
            int i = 0;
            int summaPokupok = -1;

            // поиск клиента, от него нужна общая сумма покупок
            klientBindingSource.MoveFirst();
            kafeDataSet.KlientRow r2 = (kafeDataSet.KlientRow)((DataRowView)klientBindingSource.Current).Row;
            i = 0;
            while (i < klientBindingSource.List.Count)
            {
                r2 = (kafeDataSet.KlientRow)((DataRowView)klientBindingSource.Current).Row;
                if (r2.ID == id_klienta)
                {
                    summaPokupok = r2.SummaPokupok;
                    break;
                }
                klientBindingSource.MoveNext();
                i++;
            }
            if (summaPokupok == -1) return -1; // клиент не найден

            int skidka = 0;
            if (summaPokupok > 20000)
            {
                skidka = Convert.ToInt32(Math.Ceiling(summaZakaza * 0.07));
            }
            else if (summaPokupok > 10000)
            {
                skidka = Convert.ToInt32(Math.Ceiling(summaZakaza * 0.05));
            }
            else if (summaPokupok > 5000)
            {
                skidka = Convert.ToInt32(Math.Ceiling(summaZakaza * 0.02));
            }

            return skidka;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string status = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[Status.DisplayIndex].Value.ToString();
            if (status == "закрыт") return;

            if (System.Windows.Forms.MessageBox.Show("Рассчитать сумму со скидкой и закрыть заказ?", "Вопрос", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                kafeDataSet.Zakaz1Row r = (kafeDataSet.Zakaz1Row)((DataRowView)zakaz1BindingSource.Current).Row;

                bluda_zakaza f = new bluda_zakaza();
                int id_zakaza = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[iDDataGridViewTextBoxColumn.DisplayIndex].Value.ToString());
                int summa_zakaza = r.Summa_zakaza;
                string fio = r.klient_fio;
                string[] arr = fio.Split('-');
                int id_klienta = Convert.ToInt32(arr[0]);
                int skidka = skidka_na_zakaz(id_klienta, summa_zakaza);

                // закрываем заказ
                r.Summa_zakaza = summa_zakaza - skidka;
                r.Status = "закрыт";
                dobavit_zakaz_klientu(id_klienta, r.Summa_zakaza);

                zakaz1BindingSource.EndEdit();
                zakaz1TableAdapter.Update(this.kafeDataSet.Zakaz1);
                this.zakaz1TableAdapter.Fill(this.kafeDataSet.Zakaz1);
            }
        }
    }
}
