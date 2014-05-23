using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
            // TODO: This line of code loads data into the 'kafeDataSet.Bludo1' table. You can move, or remove it, as needed.
            this.bludo1TableAdapter.Fill(this.kafeDataSet.Bludo1);
            // TODO: This line of code loads data into the 'kafeDataSet.Formirovanie_zakaza1' table. You can move, or remove it, as needed.
            this.formirovanie_zakaza1TableAdapter.Fill(this.kafeDataSet.Formirovanie_zakaza1);
            // TODO: This line of code loads data into the 'kafeDataSet.Klient' table. You can move, or remove it, as needed.
            this.klientTableAdapter.Fill(this.kafeDataSet.Klient);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Zakaz1". При необходимости она может быть перемещена или удалена.
            this.zakaz1TableAdapter.Fill(this.kafeDataSet.Zakaz1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
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
            } catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        // Добавление суммы закрытого заказа на счет клиента
        public void dobavit_zakaz_klientu(int id_klienta, int summa)
        {
            try
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
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

        // получение скидки на заказ
        public int skidka_na_zakaz(int id_klienta, int summaZakaza)
        {
            try
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
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
                return 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string status = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[Status.DisplayIndex].Value.ToString();
                if (status == "закрыт") return;

                if (System.Windows.Forms.MessageBox.Show("Рассчитать сумму со скидкой и закрыть заказ?", "Вопрос", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    kafeDataSet.Zakaz1Row r = (kafeDataSet.Zakaz1Row)((DataRowView)zakaz1BindingSource.Current).Row;

                    bluda_zakaza f = new bluda_zakaza();
                    int id_zakaza = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[iDDataGridViewTextBoxColumn.DisplayIndex].Value.ToString());
                    string data_zakaza = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataDataGridViewTextBoxColumn.DisplayIndex].Value.ToString();
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

                    // сформировать отчет в XLS
                    Excel.Application excelapp = new Excel.Application();
                    excelapp.SheetsInNewWorkbook = 1;
                    excelapp.Workbooks.Add(Type.Missing);
                    excelapp.DisplayAlerts = true;
                    Excel.Workbooks excelappworkbooks = excelapp.Workbooks;
                    Excel.Workbook excelappworkbook = excelappworkbooks[1];
                    excelappworkbook.Saved = false;
                    Excel.Sheets excelsheets = excelappworkbook.Worksheets;
                    Excel.Worksheet excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                    excelworksheet.Name = "Заказ";
                    excelworksheet.Activate();

                    Excel.Range excelcells = (Excel.Range)excelworksheet.get_Range("A1", "D1");
                    excelcells.Select();
                    ((Excel.Range)(excelapp.Selection)).Merge(Type.Missing);
                    excelcells = excelworksheet.get_Range("A1", Type.Missing);
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.Value2 = "Заказ #" + id_zakaza + " от " + data_zakaza;

                    excelcells = (Excel.Range)excelworksheet.Cells[3, 1];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlRight;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.ColumnWidth = 30;
                    excelcells.Value2 = "Клиент:";

                    excelcells = (Excel.Range)excelworksheet.Cells[3, 2];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = false;
                    excelcells.HorizontalAlignment = Excel.Constants.xlLeft;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.ColumnWidth = 40;
                    excelcells.Value2 = fio;

                    excelcells = (Excel.Range)excelworksheet.Cells[5, 1];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.Value2 = "Блюдо";

                    excelcells = (Excel.Range)excelworksheet.Cells[5, 2];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.Value2 = "Количество";

                    excelcells = (Excel.Range)excelworksheet.Cells[5, 3];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.ColumnWidth = 25;
                    excelcells.Value2 = "Стоимость";

                    // информация о блюдах заказа
                    formirovaniezakaza1BindingSource.MoveFirst();
                    formirovaniezakaza1BindingSource.Filter = "ID_zakaza='" + id_zakaza + "'";
                    formirovaniezakaza1BindingSource.MoveFirst();
                    kafeDataSet.Formirovanie_zakaza1Row r2 = (kafeDataSet.Formirovanie_zakaza1Row)((DataRowView)formirovaniezakaza1BindingSource.Current).Row;
                    int i = 0;
                    while (i < formirovaniezakaza1BindingSource.List.Count)
                    {
                        r2 = (kafeDataSet.Formirovanie_zakaza1Row)((DataRowView)formirovaniezakaza1BindingSource.Current).Row;
                        excelcells = (Excel.Range)excelworksheet.Cells[i + 6, 1];
                        excelcells.Font.Size = 12;
                        excelcells.Font.Italic = false;
                        excelcells.Font.Bold = false;
                        excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                        excelcells.Value2 = r2.bludo;
                        string[] arr1 = r2.bludo.Split('-');
                        string ID_bluda = arr1[0];

                        excelcells = (Excel.Range)excelworksheet.Cells[i + 6, 2];
                        excelcells.Font.Size = 12;
                        excelcells.Font.Italic = false;
                        excelcells.Font.Bold = false;
                        excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                        excelcells.Value2 = r2.Kolvo_bluda;

                        // считаем цену блюда
                        int summ = 0;
                        bludo1BindingSource.MoveFirst();
                        kafeDataSet.Bludo1Row r4 = (kafeDataSet.Bludo1Row)((DataRowView)bludo1BindingSource.Current).Row;
                        int j = 0;
                        while (j < bludo1BindingSource.List.Count)
                        {
                            r4 = (kafeDataSet.Bludo1Row)((DataRowView)bludo1BindingSource.Current).Row;
                            if (r4.ID == Convert.ToInt32(ID_bluda))
                            {
                                summ += (r4.Cena * r2.Kolvo_bluda);
                                break;
                            }
                            bludo1BindingSource.MoveNext();
                            j++;
                        }
                        excelcells = (Excel.Range)excelworksheet.Cells[i + 6, 3];
                        excelcells.Font.Size = 12;
                        excelcells.Font.Italic = false;
                        excelcells.Font.Bold = false;
                        excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                        excelcells.Value2 = summ;

                        formirovaniezakaza1BindingSource.MoveNext();
                        i++;
                    }
                    excelcells = excelworksheet.get_Range("A5", "C" + Convert.ToString(i + 5));
                    excelcells.Borders.ColorIndex = 1;
                    excelcells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    excelcells.Borders.Weight = Excel.XlBorderWeight.xlMedium;

                    i += 2;
                    excelcells = (Excel.Range)excelworksheet.Cells[i + 5, 1];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.Value2 = "Сумма заказа:";

                    excelcells = (Excel.Range)excelworksheet.Cells[i + 5, 2];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.Value2 = summa_zakaza;

                    i++;
                    excelcells = (Excel.Range)excelworksheet.Cells[i + 5, 1];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.Value2 = "Скидка:";

                    excelcells = (Excel.Range)excelworksheet.Cells[i + 5, 2];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.Value2 = skidka;

                    i++;
                    excelcells = (Excel.Range)excelworksheet.Cells[i + 5, 1];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.Value2 = "Итого:";

                    excelcells = (Excel.Range)excelworksheet.Cells[i + 5, 2];
                    excelcells.Font.Size = 14;
                    excelcells.Font.Italic = false;
                    excelcells.Font.Bold = true;
                    excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                    excelcells.Value2 = summa_zakaza - skidka;

                    excelapp.Visible = true;
                }
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }
    }
}
