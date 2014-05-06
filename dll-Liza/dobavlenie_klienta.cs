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
    public partial class dobavlenie_klienta : Form
    {
        public dobavlenie_klienta()
        {
            InitializeComponent();
        }

        private void dobavlenie_klienta_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Klient". При необходимости она может быть перемещена или удалена.
            this.klientTableAdapter.Fill(this.kafeDataSet.Klient);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Klient". При необходимости она может быть перемещена или удалена.

        }

        private void dobavlenie_klienta_FormClosing(object sender, FormClosingEventArgs e)
        {
            //если пользователь нажал на первую кнопку:
            if (DialogResult == System.Windows.Forms.DialogResult.OK)
                //сохранить изменения:
                klientBindingSource.EndEdit();
            else
                //не сохранять изменения:
                klientBindingSource.CancelEdit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
