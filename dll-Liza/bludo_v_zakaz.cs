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
    public partial class bludo_v_zakaz : Form
    {
        public bool mode;
        public int rec_id;
        public string bludo;
        public int id_zakaza;

        public bludo_v_zakaz()
        {
            InitializeComponent();
        }

        private void bludo_v_zakaz_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Formirovanie_zakaza". При необходимости она может быть перемещена или удалена.
            this.formirovanie_zakazaTableAdapter.Fill(this.kafeDataSet.Formirovanie_zakaza);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Bludo1". При необходимости она может быть перемещена или удалена.
            this.bludo1TableAdapter.Fill(this.kafeDataSet.Bludo1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // вставка строки в таблицу sostav_bluda
            if (comboBox1.SelectedIndex != -1)
            {

                string IDbluda, kolvoBluda;
                string bludo;
                string[] arr = comboBox1.Text.Split('-');
                IDbluda = arr[0];
                bludo = arr[1];
                kolvoBluda = textBox1.Text;

                if (mode == true) // добавление
                {
                    formirovaniezakazaBindingSource.AddNew();
                    formirovaniezakazaBindingSource.MoveLast();
                    kafeDataSet.Formirovanie_zakazaRow r = (kafeDataSet.Formirovanie_zakazaRow)((DataRowView)formirovaniezakazaBindingSource.Current).Row;
                    r.ID_zakaza = id_zakaza;
                    r.ID_bluda = Convert.ToInt32(IDbluda);
                    r.Kolvo_bluda = Convert.ToInt32(kolvoBluda);
                    formirovaniezakazaBindingSource.EndEdit();
                    formirovanie_zakazaTableAdapter.Update(kafeDataSet.Formirovanie_zakaza);
                }
                else // редактирование
                {
                    //formirovaniezakazaBindingSource.MoveFirst();
                    //kafeDataSet.Formirovanie_zakazaRow r = (kafeDataSet.Formirovanie_zakazaRow)((DataRowView)formirovaniezakazaBindingSource.Current).Row; ;
                    //int i = 0;
                    //// ищем строку
                    //while (i < formirovaniezakazaBindingSource.List.Count)
                    //{
                    //    r = (kafeDataSet.Formirovanie_zakazaRow)((DataRowView)formirovaniezakazaBindingSource.Current).Row;
                    //    if (r.ID == ID)
                    //    {
                    //        break;
                    //    }
                    //    sostavbludaBindingSource.MoveNext();
                    //    i++;
                    //}

                    //// вносим изменения
                    //r.ID_bluda = Convert.ToInt32(label6.Text);
                    //r.ID_produkta = Convert.ToInt32(IDprodukta);
                    //r.Kolvo_produkta = (float)Convert.ToDouble(kolvoProdukta);
                    //sostavbludaBindingSource.EndEdit();
                    //sostav_bludaTableAdapter.Update(kafeDataSet.Sostav_bluda);
                }
            }
        }
    }
}
