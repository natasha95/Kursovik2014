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
    public partial class dobavlenie_bluda : Form
    {
        public dobavlenie_bluda()
        {
            InitializeComponent();
        }

        private void dobavlenie_bluda_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kafeDataSet.Bludo". При необходимости она может быть перемещена или удалена.
            this.bludoTableAdapter.Fill(this.kafeDataSet.Bludo);
        }

        private void dobavlenie_bluda_FormClosing(object sender, FormClosingEventArgs e)
        {
            // если пользователь нажал на первую кнопку:
            if (DialogResult == System.Windows.Forms.DialogResult.OK)
                // сохранить изменения:
                bludoBindingSource.EndEdit();
            else
                // не сохранять изменения:
                bludoBindingSource.CancelEdit();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
