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
    public partial class dobavlenie_produkta : Form
    {
        public dobavlenie_produkta()
        {
            InitializeComponent();
        }

        private void dobavlenie_produkta_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Produkt". При необходимости она может быть перемещена или удалена.
            this.produktTableAdapter.Fill(this.kafeDataSet.Produkt);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void dobavlenie_produkta_FormClosing(object sender, FormClosingEventArgs e)
        {
            //если пользователь нажал на первую кнопку:
            if (DialogResult == System.Windows.Forms.DialogResult.OK)
                //сохранить изменения:
                produktBindingSource.EndEdit();
            else
                //не сохранять изменения:
                produktBindingSource.CancelEdit();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
