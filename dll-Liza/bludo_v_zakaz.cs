using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace dll_Liza
{
    public partial class bludo_v_zakaz : Form
    {
        public bool mode;
        public int rec_id;
        public string bludo;
        public int id_zakaza;

        // запись с информацией о количестве продуктов
        public struct kolvo_info
        {
            public int produktID;
            public string produkt;
            public float kolvo_na_sklade;
            public float kolvo_treb;
            public int cena;
        }

        public bludo_v_zakaz()
        {
            InitializeComponent();
        }

        private void bludo_v_zakaz_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Zakaz". При необходимости она может быть перемещена или удалена.
            this.zakazTableAdapter.Fill(this.kafeDataSet.Zakaz);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Sostav_bluda". При необходимости она может быть перемещена или удалена.
            this.sostav_bludaTableAdapter.Fill(this.kafeDataSet.Sostav_bluda);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Produkt". При необходимости она может быть перемещена или удалена.
            this.produktTableAdapter.Fill(this.kafeDataSet.Produkt);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Formirovanie_zakaza". При необходимости она может быть перемещена или удалена.
            this.formirovanie_zakazaTableAdapter.Fill(this.kafeDataSet.Formirovanie_zakaza);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Bludo1". При необходимости она может быть перемещена или удалена.
            this.bludo1TableAdapter.Fill(this.kafeDataSet.Bludo1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
                    int ID_bluda = Convert.ToInt32(IDbluda);
                    int kolvo_Bluda = Convert.ToInt32(kolvoBluda);

                    if (mode == true) // добавление
                    {
                        // заносим в список информацию о том, сколько продуктов есть в наличии
                        produktBindingSource.MoveFirst();
                        ArrayList kolvo = new ArrayList();
                        kafeDataSet.ProduktRow r = (kafeDataSet.ProduktRow)((DataRowView)produktBindingSource.Current).Row;
                        int i = 0;
                        while (i < produktBindingSource.List.Count)
                        {
                            r = (kafeDataSet.ProduktRow)((DataRowView)produktBindingSource.Current).Row;
                            kolvo_info k;
                            k.produktID = r.ID;
                            k.produkt = r.Nazvanie;
                            k.kolvo_na_sklade = r.Kolvo;
                            k.kolvo_treb = 0;
                            k.cena = r.Cena;
                            kolvo.Add(k);
                            produktBindingSource.MoveNext();
                            i++;
                        }

                        // получаем список продуктов, нужных для блюда
                        // по каждому продукту смотрим, сколько его в наличии
                        sostavbludaBindingSource.MoveFirst();
                        kafeDataSet.Sostav_bludaRow r1 = (kafeDataSet.Sostav_bludaRow)((DataRowView)sostavbludaBindingSource.Current).Row;
                        i = 0;
                        while (i < sostavbludaBindingSource.List.Count)
                        {
                            r1 = (kafeDataSet.Sostav_bludaRow)((DataRowView)sostavbludaBindingSource.Current).Row;
                            if (r1.ID_bluda == ID_bluda) // в этой строке информация, относящаяся к выбранному блюду
                            {
                                // ищем продукт
                                for (int j = 0; j < kolvo.Count; j++)
                                {
                                    kolvo_info k = (kolvo_info)kolvo[j];
                                    if (r1.ID_produkta == k.produktID)
                                    {
                                        // добавляем информацию, сколько продукта требуется
                                        k.kolvo_treb += (r1.Kolvo_produkta * kolvo_Bluda);
                                        kolvo[j] = k;
                                        break;
                                    }
                                }
                            }
                            sostavbludaBindingSource.MoveNext();
                            i++;
                        }

                        // проверяем, есть ли на складе продукты в необходимом количестве
                        // если продуктов не хватает, выводим сообщение и прерываем добавление в меню
                        string msg = "";
                        for (i = 0; i < kolvo.Count; i++)
                        {
                            kolvo_info k = (kolvo_info)kolvo[i];
                            if (k.kolvo_treb > 0 && k.kolvo_treb > k.kolvo_na_sklade)
                            {
                                msg += k.produkt + ": требуется " + k.kolvo_treb + ", есть в наличии " + k.kolvo_na_sklade + "\n";
                            }
                        }
                        if (msg != "")
                        {
                            msg = "Следующих продуктов не хватает на складе:\n" + msg;
                            System.Windows.Forms.MessageBox.Show(msg);
                            return;
                        }

                        // продуктов хватает, продолжаем, убираем продукты со склада
                        produktBindingSource.MoveFirst();
                        kafeDataSet.ProduktRow r2 = (kafeDataSet.ProduktRow)((DataRowView)produktBindingSource.Current).Row;
                        i = 0;
                        while (i < produktBindingSource.List.Count)
                        {
                            r2 = (kafeDataSet.ProduktRow)((DataRowView)produktBindingSource.Current).Row;
                            kolvo_info k;
                            for (i = 0; i < kolvo.Count; i++)
                            {
                                k = (kolvo_info)kolvo[i];
                                if (r2.ID == k.produktID)
                                {
                                    r2.Kolvo -= k.kolvo_treb;
                                    break;
                                }
                            }
                            produktBindingSource.MoveNext();
                            i++;
                        }
                        produktBindingSource.EndEdit();
                        produktTableAdapter.Update(kafeDataSet.Produkt);

                        // добавляем блюдо в заказ
                        formirovaniezakazaBindingSource.AddNew();
                        formirovaniezakazaBindingSource.MoveLast();
                        kafeDataSet.Formirovanie_zakazaRow r3 = (kafeDataSet.Formirovanie_zakazaRow)((DataRowView)formirovaniezakazaBindingSource.Current).Row;
                        r3.ID_zakaza = id_zakaza;
                        r3.ID_bluda = Convert.ToInt32(IDbluda);
                        r3.Kolvo_bluda = Convert.ToInt32(kolvoBluda);
                        formirovaniezakazaBindingSource.EndEdit();
                        formirovanie_zakazaTableAdapter.Update(kafeDataSet.Formirovanie_zakaza);

                        // считаем коррекцию суммы заказа
                        int delta_summ = 0;
                        bludo1BindingSource.MoveFirst();
                        kafeDataSet.Bludo1Row r4 = (kafeDataSet.Bludo1Row)((DataRowView)bludo1BindingSource.Current).Row;
                        i = 0;
                        while (i < bludo1BindingSource.List.Count)
                        {
                            r4 = (kafeDataSet.Bludo1Row)((DataRowView)bludo1BindingSource.Current).Row;
                            if (r4.ID == ID_bluda)
                            {
                                delta_summ += (r4.Cena * kolvo_Bluda);
                                break;
                            }
                            bludo1BindingSource.MoveNext();
                            i++;
                        }

                        // корректируем сумму заказа
                        zakazBindingSource.MoveFirst();
                        kafeDataSet.ZakazRow r5 = (kafeDataSet.ZakazRow)((DataRowView)zakazBindingSource.Current).Row;
                        i = 0;
                        while (i < zakazBindingSource.List.Count)
                        {
                            r5 = (kafeDataSet.ZakazRow)((DataRowView)zakazBindingSource.Current).Row;
                            if (r5.ID == id_zakaza)
                            {
                                r5.Summa_zakaza += delta_summ;
                                break;
                            }
                            zakazBindingSource.MoveNext();
                            i++;
                        }
                        zakazBindingSource.EndEdit();
                        zakazTableAdapter.Update(kafeDataSet.Zakaz);
                    }
                    else // редактирование
                    {

                    }
                }
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }
    }
}
