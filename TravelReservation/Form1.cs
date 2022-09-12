using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelReservation
{
    public partial class GirisEkrani : Form
    {        
        public GirisEkrani()
        {
            InitializeComponent();
        }
        public static User user;
        private void linkLabelKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitEkrani ke  = new KayitEkrani();           
            ke.Show();
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxMail.Text != String.Empty && textBoxSifre.Text != String.Empty)
            {
                string mail = textBoxMail.Text;
                user = UserManager.GetUserByMail(mail);
                if (user != null)
                {
                    string sifre = user.Sifre;
                    if (textBoxSifre.Text == sifre)
                    {
                        KullaniciEkrani kullaniciEkrani = new KullaniciEkrani();
                        kullaniciEkrani.Show();
                    }
                    else
                    {
                        MessageBox.Show("Mail adresi ya da şifre yanlış");
                    }

                }
                else
                {
                    MessageBox.Show("Mail adresi ya da şifre yanlış");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun");
            }
            
        }
    }
}
