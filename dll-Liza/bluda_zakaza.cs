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
            // TODO: This line of code loads data into the 'kafeDataSet.Klient' table. You can move, or remove it, as needed.
            this.klientTableAdapter.Fill(this.kafeDataSet.Klient);
            // TODO: This line of code loads data into the 'kafeDataSet.Zakaz' table. You can move, or remove it, as needed.
            this.zakazTableAdapter.Fill(this.kafeDataSet.Zakaz);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Formirovanie_zakaza1". При необходимости она может быть перемещена или удалена.
            this.formirovanie_zakaza1TableAdapter.Fill(this.kafeDataSet.Formirovanie_zakaza1);

            label6.Text = Convert.ToString(summa_zakaza(Convert.ToInt32(label2.Text)));
            label8.Text = Convert.ToString(skidka_na_zakaz(Convert.ToInt32(label2.Text)));
        }

        // получение суммы заказа с заданным id
        public int summa_zakaza(int id_zakaza)
        {
            try
            {
                zakazBindingSource.MoveFirst();
                kafeDataSet.ZakazRow r = (kafeDataSet.ZakazRow)((DataRowView)zakazBindingSource.Current).Row;
                int i = 0;
                while (i < zakazBindingSource.List.Count)
                {
                    r = (kafeDataSet.ZakazRow)((DataRowView)zakazBindingSource.Current).Row;
                    if (r.ID == id_zakaza)
                    {
                        return r.Summa_zakaza;
                    }
                    zakazBindingSource.MoveNext();
                    i++;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return -1; // заказ не найден
            }
            return -1; // заказ не найден
        }

        // получение скидки на заказ с заданным id
        public int skidka_na_zakaz(int id_zakaza)
        {
            try
            {
                int i = 0;
                int summaZakaza = 0;
                int summaPokupok = -1;
                int id_klienta = -1;

                // поиск заказа
                zakazBindingSource.MoveFirst();
                kafeDataSet.ZakazRow r = (kafeDataSet.ZakazRow)((DataRowView)zakazBindingSource.Current).Row;
                while (i < zakazBindingSource.List.Count)
                {
                    r = (kafeDataSet.ZakazRow)((DataRowView)zakazBindingSource.Current).Row;
                    if (r.ID == id_zakaza)
                    {
                        summaZakaza = r.Summa_zakaza;
                        id_klienta = r.ID_klienta;
                        break;
                    }
                    zakazBindingSource.MoveNext();
                    i++;
                }
                if (id_klienta == -1) return -1; // заказ не найден

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
                if (summaPokupok > 3000)
                {
                    skidka = Convert.ToInt32(Math.Ceiling(summaZakaza * 0.07));
                }
                else if (summaPokupok > 2000)
                {
                    skidka = Convert.ToInt32(Math.Ceiling(summaZakaza * 0.05));
                }
                else if (summaPokupok > 1000)
                {
                    skidka = Convert.ToInt32(Math.Ceiling(summaZakaza * 0.02));
                }

                return skidka;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return 0;
            }
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

                // обновление суммы заказа
                this.zakazTableAdapter.Fill(this.kafeDataSet.Zakaz);
                zakazTableAdapter.Update(this.kafeDataSet.Zakaz);
                label6.Text = Convert.ToString(summa_zakaza(Convert.ToInt32(label2.Text)));
                label8.Text = Convert.ToString(skidka_na_zakaz(Convert.ToInt32(label2.Text)));
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
