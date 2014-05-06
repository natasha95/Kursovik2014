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
    public partial class dobavlenie_zakaza : Form
    {
        public bool mode;
        public int zakaz_id;
        public string klient_fio;
        public DateTime dt;

        public dobavlenie_zakaza()
        {
            InitializeComponent();
        }

        private void dobavlenie_zakaza_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Klient1". При необходимости она может быть перемещена или удалена.
            this.klient1TableAdapter.Fill(this.kafeDataSet.Klient1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Zakaz". При необходимости она может быть перемещена или удалена.
            this.zakazTableAdapter.Fill(this.kafeDataSet.Zakaz);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Klient". При необходимости она может быть перемещена или удалена.
            this.klientTableAdapter.Fill(this.kafeDataSet.Klient);

            if (mode == false) // режим редактирования
            {
                // выбираем нужные данные в режиме редактирования
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    comboBox1.SelectedIndex = i;
                    //string[] arr = comboBox1.Text.Split('-');
                    if (comboBox1.Text == klient_fio)
                    {
                        break;
                    }
                }
                dateTimePicker1.Value = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // вставка строки в таблицу sostav_bluda
            if (comboBox1.SelectedIndex != -1)
            {

                string fio;
                //string sdate;
                string[] arr = comboBox1.Text.Split('-');
                string id = arr[0];
                fio = arr[1];

                if (mode == true) // добавление
                {
                    zakazBindingSource.AddNew();
                    zakazBindingSource.MoveLast();
                    kafeDataSet.ZakazRow r = (kafeDataSet.ZakazRow)((DataRowView)zakazBindingSource.Current).Row;
                    r.ID_klienta = Convert.ToInt32(id);
                    r.Data = dateTimePicker1.Value;
                    r.Summa_zakaza = 0;
                    zakazBindingSource.EndEdit();
                    zakazTableAdapter.Update(kafeDataSet.Zakaz);
                }
                else // редактирование
                {
                    //int sID = Convert.ToInt32(sostav_ID);
                    zakazBindingSource.MoveFirst();
                    kafeDataSet.ZakazRow r = (kafeDataSet.ZakazRow)((DataRowView)zakazBindingSource.Current).Row;
                    int i = 0;
                    // ищем строку
                    while (i < zakazBindingSource.List.Count)
                    {
                        r = (kafeDataSet.ZakazRow)((DataRowView)zakazBindingSource.Current).Row;
                        if (r.ID == zakaz_id)
                        {
                            break;
                        }
                        zakazBindingSource.MoveNext();
                        i++;
                    }

                    // вносим изменения
                    r.ID_klienta = Convert.ToInt32(id);
                    r.Data = dateTimePicker1.Value;
                    zakazBindingSource.EndEdit();
                    zakazTableAdapter.Update(kafeDataSet.Zakaz);
                }
            }
        }
    }
}
