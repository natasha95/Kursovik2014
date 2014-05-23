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
    public partial class otchet_form : Form
    {
        public otchet_form()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                // за день
                DateTime dt = new DateTime();
                label2.Text = DateTime.Now.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                // за неделю
                DateTime dt1 = new DateTime();
                DateTime dt2 = new DateTime();
                dt1 = DateTime.Now;
                dt2 = dt1;
                string d = dt1.DayOfWeek.ToString().ToLower();
                int delta_day = 0;
                if (d == "monday" || d == "понедельник")
                {
                    delta_day = 0;
                }

                label2.Text = d;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                // за месяц
                DateTime dt = new DateTime();
                label2.Text = DateTime.Now.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                // за квартал
                DateTime dt = new DateTime();
                label2.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
}
