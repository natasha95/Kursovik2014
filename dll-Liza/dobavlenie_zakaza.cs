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

        public void Vybrat_klienta_po_fio(string fio)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                comboBox1.SelectedIndex = i;
                //string[] arr = comboBox1.Text.Split('-');
                if (comboBox1.Text.Contains(fio))
                {
                    break;
                }
            }
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
                Vybrat_klienta_po_fio(klient_fio);
                dateTimePicker1.Value = dt;

                comboBox2.Enabled = false;
                textBox1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                comboBox2.Enabled = true;
                textBox1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                comboBox2.SelectedIndex = 0;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
                        r.Status = "в работе"; // статус - не оформлен
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
            } catch (Exception e1) {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                if (textBox1.Text == "") return;
                if (comboBox2.SelectedIndex == 0)
                {
                    // поиск по номеру телефона
                    klientBindingSource.Filter = "Telefon='" + textBox1.Text + "'";
                    klientBindingSource.MoveFirst();
                    if (klientBindingSource.List.Count > 0)
                    {
                        kafeDataSet.KlientRow r = (kafeDataSet.KlientRow)((DataRowView)klientBindingSource.Current).Row;
                        Vybrat_klienta_po_fio(r.FIO);
                        System.Windows.Forms.MessageBox.Show("Клиент с номером телефона '" + textBox1.Text + "' найден и выбран!");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Клиент с номером телефона '" + textBox1.Text + "' не найден!");
                    }
                    klientBindingSource.Filter = string.Empty;
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    // поиск по ФИО
                    klientBindingSource.Filter = "FIO='" + textBox1.Text + "'";
                    klientBindingSource.MoveFirst();
                    if (klientBindingSource.List.Count > 0)
                    {
                        kafeDataSet.KlientRow r = (kafeDataSet.KlientRow)((DataRowView)klientBindingSource.Current).Row;
                        Vybrat_klienta_po_fio(r.FIO);
                        System.Windows.Forms.MessageBox.Show("Клиент с ФИО '" + textBox1.Text + "' найден и выбран!");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Клиент с ФИО '" + textBox1.Text + "' не найден!");
                    }
                    klientBindingSource.Filter = string.Empty;
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    // поиск по номеру карты
                    klientBindingSource.Filter = "NomerKarty='" + textBox1.Text + "'";
                    klientBindingSource.MoveFirst();
                    if (klientBindingSource.List.Count > 0)
                    {
                        kafeDataSet.KlientRow r = (kafeDataSet.KlientRow)((DataRowView)klientBindingSource.Current).Row;
                        Vybrat_klienta_po_fio(r.FIO);
                        System.Windows.Forms.MessageBox.Show("Клиент с номером карты '" + textBox1.Text + "' найден и выбран!");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Клиент с номером карты '" + textBox1.Text + "' не найден!");
                    }
                    klientBindingSource.Filter = string.Empty;
                }
            } catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // создаем объект второй формы
                dobavlenie_klienta f = new dobavlenie_klienta();

                // добавляем новую запись в таблицу
                klientBindingSource.AddNew();

                // синхронизируем компоненты bindingSource обоих форм
                f.klientBindingSource.DataSource = klientBindingSource;

                // чтобы они указывали в таблице на одну и ту же запись
                f.klientBindingSource.Position = klientBindingSource.Position;

                // если пользователь в форме добавления нажал на первую кнопку:
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    f.klientTableAdapter.Update(this.kafeDataSet.Klient);
                    // осуществляем выгрузку в DataGridView обновленных данных:
                    this.klientTableAdapter.Fill(this.kafeDataSet.Klient);
                    klientTableAdapter.Update(this.kafeDataSet.Klient);

                    this.klient1TableAdapter.Fill(this.kafeDataSet.Klient1);
                    this.zakazTableAdapter.Fill(this.kafeDataSet.Zakaz);

                    comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                }
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }
    }
}
