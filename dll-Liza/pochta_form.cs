using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using System.IO;

namespace dll_Liza
{
    public partial class pochta_form : Form
    {
        public pochta_form()
        {
            InitializeComponent();
        }

        private void pochta_form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kafeDataSet.Klient' table. You can move, or remove it, as needed.
            this.klientTableAdapter.Fill(this.kafeDataSet.Klient);
            // TODO: This line of code loads data into the 'kafeDataSet.Bludo' table. You can move, or remove it, as needed.
            this.bludoTableAdapter.Fill(this.kafeDataSet.Bludo);

        }

        public static void SendMail(string smtpServer, string from, string password,
        string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // собираем информацию обо всех блюдах
                string mail = "Перечень блюд\n";
                bludoBindingSource.MoveFirst();
                kafeDataSet.BludoRow r = (kafeDataSet.BludoRow)((DataRowView)bludoBindingSource.Current).Row;
                int i = 0;

                // формируем PDF файл с описанием блюд
                var doc = new Document();
                string docPath = Application.StartupPath + @"\Предложение.pdf";
                PdfWriter.GetInstance(doc, new FileStream(docPath, FileMode.Create));
                doc.Open();
                // заголовок
                string fg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");

                BaseFont baseFont = BaseFont.CreateFont(fg, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Phrase j = new Phrase("Перечень блюд", new iTextSharp.text.Font(baseFont, 14,
                              iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
                Paragraph a1 = new Paragraph(j);
                a1.Add(Environment.NewLine);
                a1.Add(Environment.NewLine);
                a1.Add(Environment.NewLine);
                a1.Alignment = Element.ALIGN_CENTER;
                a1.SpacingAfter = 5;
                doc.Add(a1);
                while (i < bludoBindingSource.List.Count)
                {
                    r = (kafeDataSet.BludoRow)((DataRowView)bludoBindingSource.Current).Row;
                    mail += "Блюдо '" + r.Nazvanie + "': " + r.Opisanie + "\n\n";
                    j = new Phrase("Блюдо '" + r.Nazvanie + "'\n" + r.Opisanie + "\n\n", new iTextSharp.text.Font(baseFont, 12,
                  iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
                    a1 = new Paragraph(j);
                    a1.Add(Environment.NewLine);
                    a1.Add(Environment.NewLine);
                    a1.Alignment = Element.ALIGN_LEFT;
                    a1.SpacingAfter = 5;
                    doc.Add(a1);

                    bludoBindingSource.MoveNext();
                    i++;
                }
                doc.Close();

                // посылаем письмо с информацией о блюдах на почтовые ящики клиентов
                klientBindingSource.MoveFirst();
                kafeDataSet.KlientRow r2 = (kafeDataSet.KlientRow)((DataRowView)klientBindingSource.Current).Row;
                i = 0;
                while (i < klientBindingSource.List.Count)
                {
                    r2 = (kafeDataSet.KlientRow)((DataRowView)klientBindingSource.Current).Row;
                    SendMail("smtp.mail.ru", "nasimna@mail.ru", "yfnfif", r2.Email,
                        "Перечень блюд", "Предлагаем вашему вниманию перечень блюд",
                        Application.StartupPath + @"\Предложение.pdf");
                    klientBindingSource.MoveNext();
                    i++;
                }
                System.Windows.Forms.MessageBox.Show("Почтовая рассылка была успешно выполнена", "Информация", MessageBoxButtons.OK);
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }
        }
    }
}
