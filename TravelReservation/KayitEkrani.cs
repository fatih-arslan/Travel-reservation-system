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
    public partial class KayitEkrani : Form
    {
        public KayitEkrani()
        {
            InitializeComponent();
        }

        private void KayitEkrani_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonKayıt_Click(object sender, EventArgs e)
        {
            if(textBoxAd.Text == String.Empty || textBoxSoyad.Text == String.Empty || textBoxMail.Text == String.Empty ||
                textBoxSifre.Text == String.Empty || textBoxTC.Text == String.Empty)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun");                
            }
            else
            {
                User userTemp = UserManager.GetUserByMail(textBoxMail.Text);
                if(userTemp != null)
                {
                    MessageBox.Show("Bu mail adresi kullanılıyor, lütfen başka bir mail adresi girin");
                }
                else
                {
                    User user = new User { Ad = textBoxAd.Text, Soyad = textBoxSoyad.Text, Mail = textBoxMail.Text, Sifre = textBoxSifre.Text, TC = textBoxTC.Text };
                    UserManager.AddUser(user);
                    MessageBox.Show("Kayıt tamamlandı");
                    this.Close();
                }                
            }
        }
    }
}
