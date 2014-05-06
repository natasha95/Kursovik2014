using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dll_Liza;
using dll_Natasha;

namespace RabotaKafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void produkt_Click(object sender, EventArgs e)
        {
            produkt_form pf = new produkt_form();
            pf.ShowDialog();
        }

        private void klient_Click(object sender, EventArgs e)
        {
            klient cf = new klient();
            cf.ShowDialog();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            bludo_form mf = new bludo_form();
            mf.ShowDialog();
        }

        private void zakaz_Click(object sender, EventArgs e)
        {
            zakazy zf = new zakazy();
            zf.ShowDialog();
        }
    }
}
