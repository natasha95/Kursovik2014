using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace dll_Natasha
{
    public partial class otchet_form : Form
    {
        public DateTime dt1, dt2;

        public otchet_form()
        {
            InitializeComponent();
            dt1 = new DateTime();
            dt2 = new DateTime();
        }

        private void otchet_form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kafeDataSet.Bludo1' table. You can move, or remove it, as needed.
            this.bludo1TableAdapter.Fill(this.kafeDataSet.Bludo1);
            // TODO: This line of code loads data into the 'kafeDataSet.Zakaz1' table. You can move, or remove it, as needed.
            this.zakaz1TableAdapter.Fill(this.kafeDataSet.Zakaz1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dt1 = dateTimePicker1.Value;
                dt2 = dateTimePicker2.Value;
                zakaz1BindingSource.Filter = "Data >= '" + dt1.ToShortDateString() + "' AND Data <= '" + dt2.ToShortDateString() + "'";

                dataGridView2.Visible = false;
                dataGridView1.Visible = true;

                // выгрузка отчета в excel
                Excel.Application excelapp = new Excel.Application();
                excelapp.SheetsInNewWorkbook = 1;
                excelapp.Workbooks.Add(Type.Missing);
                excelapp.DisplayAlerts = true;
                Excel.Workbooks excelappworkbooks = excelapp.Workbooks;
                Excel.Workbook excelappworkbook = excelappworkbooks[1];
                excelappworkbook.Saved = false;
                Excel.Sheets excelsheets = excelappworkbook.Worksheets;
                Excel.Worksheet excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Name = "Данные";
                excelworksheet.Activate();

                // заголовок таблицы
                Excel.Range excelcells = (Excel.Range)excelworksheet.Cells[3, 1];
                excelcells.Font.Size = 14;
                excelcells.Font.Italic = false;
                excelcells.Font.Bold = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.ColumnWidth = 10;
                excelcells.Value2 = "ID";

                excelcells = (Excel.Range)excelworksheet.Cells[3, 2];
                excelcells.Font.Size = 14;
                excelcells.Font.Italic = false;
                excelcells.Font.Bold = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.ColumnWidth = 25;
                excelcells.Value2 = "Дата";

                excelcells = (Excel.Range)excelworksheet.Cells[3, 3];
                excelcells.Font.Size = 14;
                excelcells.Font.Italic = false;
                excelcells.Font.Bold = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.ColumnWidth = 20;
                excelcells.Value2 = "Сумма заказа";

                excelcells = (Excel.Range)excelworksheet.Cells[3, 4];
                excelcells.Font.Size = 14;
                excelcells.Font.Italic = false;
                excelcells.Font.Bold = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.ColumnWidth = 60;
                excelcells.Value2 = "Клиент";

                excelcells = excelworksheet.get_Range("A1", "D1");
                excelcells.Select();
                ((Excel.Range)(excelapp.Selection)).Merge(Type.Missing);
                excelcells = excelworksheet.get_Range("A1", Type.Missing);
                excelcells.Font.Size = 14;
                excelcells.Font.Italic = false;
                excelcells.Font.Bold = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.Value2 = "Отчет о заказах с " + dateTimePicker1.Value.ToShortDateString() + " по " + dateTimePicker2.Value.ToShortDateString();

                // информация о заказах
                int m, n = 0;
                for (m = 0; m < dataGridView1.Rows.Count; m++)
                {
                    for (n = 0; n < dataGridView1.Columns.Count; n++)
                    {
                        excelcells = (Excel.Range)excelworksheet.Cells[m + 4, n + 1];
                        excelcells.Font.Size = 12;
                        excelcells.Font.Italic = false;
                        excelcells.Font.Bold = false;
                        excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                        excelcells.Value2 = dataGridView1.Rows[m].Cells[n].Value.ToString();
                    }
                }
                excelcells = excelworksheet.get_Range("A3", "D" + Convert.ToString(m + 3));
                excelcells.Borders.ColorIndex = 1;
                excelcells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                excelcells.Borders.Weight = Excel.XlBorderWeight.xlMedium;

                excelapp.Visible = true;
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
                dt1 = dateTimePicker1.Value;
                dt2 = dateTimePicker2.Value;
                zakaz1BindingSource.Filter = "Data >= '" + dt1.ToShortDateString() + "' AND Data <= '" + dt2.ToShortDateString() + "'";

                dataGridView2.Visible = true;
                dataGridView1.Visible = false;

                // выгрузка отчета в excel
                Excel.Application excelapp = new Excel.Application();
                excelapp.SheetsInNewWorkbook = 1;
                excelapp.Workbooks.Add(Type.Missing);
                excelapp.DisplayAlerts = true;
                Excel.Workbooks excelappworkbooks = excelapp.Workbooks;
                Excel.Workbook excelappworkbook = excelappworkbooks[1];
                excelappworkbook.Saved = false;
                Excel.Sheets excelsheets = excelappworkbook.Worksheets;
                Excel.Worksheet excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Name = "Данные";
                excelworksheet.Activate();

                // заголовок таблицы
                Excel.Range excelcells = (Excel.Range)excelworksheet.Cells[3, 1];
                excelcells.Font.Size = 14;
                excelcells.Font.Italic = false;
                excelcells.Font.Bold = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.ColumnWidth = 10;
                excelcells.Value2 = "ID";

                excelcells = (Excel.Range)excelworksheet.Cells[3, 2];
                excelcells.Font.Size = 14;
                excelcells.Font.Italic = false;
                excelcells.Font.Bold = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.ColumnWidth = 40;
                excelcells.Value2 = "Блюдо";

                excelcells = (Excel.Range)excelworksheet.Cells[3, 3];
                excelcells.Font.Size = 14;
                excelcells.Font.Italic = false;
                excelcells.Font.Bold = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.ColumnWidth = 38;
                excelcells.Value2 = "Количество заказанных блюд";

                excelcells = excelworksheet.get_Range("A1", "C1");
                excelcells.Select();
                ((Excel.Range)(excelapp.Selection)).Merge(Type.Missing);
                excelcells = excelworksheet.get_Range("A1", Type.Missing);
                excelcells.Font.Size = 14;
                excelcells.Font.Italic = false;
                excelcells.Font.Bold = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.Value2 = "Статистика заказа блюд";

                // информация о блюдах
                int m, n = 0;
                for (m = 0; m < dataGridView2.Rows.Count; m++)
                {
                    for (n = 0; n < dataGridView2.Columns.Count; n++)
                    {
                        excelcells = (Excel.Range)excelworksheet.Cells[m + 4, n + 1];
                        excelcells.Font.Size = 12;
                        excelcells.Font.Italic = false;
                        excelcells.Font.Bold = false;
                        excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                        excelcells.Value2 = dataGridView2.Rows[m].Cells[n].Value.ToString();
                    }
                }
                excelcells = excelworksheet.get_Range("A3", "C" + Convert.ToString(m + 3));
                excelcells.Borders.ColorIndex = 1;
                excelcells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                excelcells.Borders.Weight = Excel.XlBorderWeight.xlMedium;

                // строим диаграмму
                Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                excelapp.ActiveChart.ChartType = Excel.XlChartType.xlColumnClustered;
                excelapp.ActiveChart.HasTitle = true;
                excelapp.ActiveChart.ChartTitle.Text = "Статистика заказа блюд";
                excelapp.ActiveChart.ChartTitle.Font.Size = 14;
                excelapp.ActiveChart.ChartTitle.Font.Color = 254;
                excelapp.ActiveChart.ChartTitle.Shadow = true;
                excelapp.ActiveChart.ChartTitle.Border.LineStyle = Excel.Constants.xlSolid;

                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                    Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                 Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Блюда";

                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                 Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Число заказов";

                excelapp.ActiveChart.HasLegend = true;
                excelapp.ActiveChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionLeft;
                ((Excel.LegendEntry)excelapp.ActiveChart.Legend.LegendEntries(1)).Font.Size = 14;
                Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)excelapp.ActiveChart.SeriesCollection(Type.Missing);
                seriesCollection.Item(1).Delete();


                // добавляем данные на диаграмму
                string names = "";
                string values = "";
                string cats = "";
                for (m = 0; m < dataGridView2.Rows.Count; m++)
                {
                    Excel.Range c_value = (Excel.Range)excelworksheet.get_Range("C" + Convert.ToString(m + 4), "C" + Convert.ToString(m + 4));
                    Excel.Range c_series = (Excel.Range)excelworksheet.get_Range("B" + Convert.ToString(m + 4), "B" + Convert.ToString(m + 4));

                    names = dataGridView2.Rows[m].Cells[1].Value.ToString();
                    values = dataGridView2.Rows[m].Cells[2].Value.ToString();
                    cats += names;
                    seriesCollection.Add(c_value, Excel.XlRowCol.xlRows, c_series, c_series, Type.Missing);

                    seriesCollection.Item(m + 1).Name = names;
                    //seriesCollection.Item(m + 1).XValues = "qwe";
                    seriesCollection.Item(m + 1).HasDataLabels = true;
                }
                excelapp.Visible = true;
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }

    }
}
