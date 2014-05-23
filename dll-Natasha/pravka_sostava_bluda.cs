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
    public partial class pravka_sostava_bluda : Form
    {

        public bool mode; // режим запуска формы - добавление true, редактирование false
        public string sostav_ID; // ID редактируемой строки из таблицы sostav_bluda
        public string nazvanie_produkta;

        public pravka_sostava_bluda()
        {
            InitializeComponent();
        }

        private void pravka_sostava_bluda_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Sostav_bluda". При необходимости она может быть перемещена или удалена.
            this.sostav_bludaTableAdapter.Fill(this.kafeDataSet.Sostav_bluda);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Produkt1". При необходимости она может быть перемещена или удалена.
            this.produkt1TableAdapter.Fill(this.kafeDataSet.Produkt1);

            if (mode == false)
            {
                // выбираем нужный продукт в режиме редактирования
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    comboBox1.SelectedIndex = i;
                    if (comboBox1.Text.IndexOf(nazvanie_produkta) > 0)
                    {
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // вставка строки в таблицу sostav_bluda
                if (comboBox1.SelectedIndex != -1)
                {

                    string IDprodukta, kolvoProdukta;
                    string produkt;
                    string[] arr = comboBox1.Text.Split(' ');
                    IDprodukta = arr[0];
                    produkt = arr[1];
                    kolvoProdukta = textBox3.Text;

                    if (mode == true) // добавление
                    {
                        sostavbludaBindingSource.AddNew();
                        sostavbludaBindingSource.MoveLast();
                        kafeDataSet.Sostav_bludaRow r = (kafeDataSet.Sostav_bludaRow)((DataRowView)sostavbludaBindingSource.Current).Row;
                        r.ID_bluda = Convert.ToInt32(label6.Text);
                        r.ID_produkta = Convert.ToInt32(IDprodukta);
                        r.Kolvo_produkta = (float)Convert.ToDouble(kolvoProdukta);
                        sostavbludaBindingSource.EndEdit();
                        sostav_bludaTableAdapter.Update(kafeDataSet.Sostav_bluda);
                    }
                    else // редактирование
                    {
                        int ID = Convert.ToInt32(sostav_ID);
                        sostavbludaBindingSource.MoveFirst();
                        kafeDataSet.Sostav_bludaRow r = (kafeDataSet.Sostav_bludaRow)((DataRowView)sostavbludaBindingSource.Current).Row; ;
                        int i = 0;
                        // ищем строку
                        while (i < sostavbludaBindingSource.List.Count)
                        {
                            r = (kafeDataSet.Sostav_bludaRow)((DataRowView)sostavbludaBindingSource.Current).Row;
                            if (r.ID == ID)
                            {
                                break;
                            }
                            sostavbludaBindingSource.MoveNext();
                            i++;
                        }

                        // вносим изменения
                        r.ID_bluda = Convert.ToInt32(label6.Text);
                        r.ID_produkta = Convert.ToInt32(IDprodukta);
                        r.Kolvo_produkta = (float)Convert.ToDouble(kolvoProdukta);
                        sostavbludaBindingSource.EndEdit();
                        sostav_bludaTableAdapter.Update(kafeDataSet.Sostav_bluda);
                    }
                }
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
