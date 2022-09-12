using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelReservation
{
    public partial class SeyahatRaporu : Form
    {
        public static DataTable ulasimBilgileri;
        public static DataTable konaklamaBilgileri;
        public SeyahatRaporu()
        {
            InitializeComponent();
        }

        private void SeyahatRaporu_Load(object sender, EventArgs e)
        {
            if(KullaniciEkrani.Seyahat != null)
            {
                dataGridViewUlasim.DataSource = ulasimBilgileri;
                dataGridViewKonaklama.DataSource = konaklamaBilgileri;
            }
            else
            {
                panelSeyahatYok.Visible = true;
            }

        }
        public string ExportDataTableToHtml(DataTable dt)
        {            
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html >");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; font-size:smaller'>");
            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");
            }
            strHTMLBuilder.Append("</tr>");
            foreach (DataRow myRow in dt.Rows)
            {
                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");
                }
                strHTMLBuilder.Append("</tr>");
            }
            //Close tags.
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");
            string Htmltext = strHTMLBuilder.ToString();
            return Htmltext;
            
        }
        WebBrowser webBrowser = new WebBrowser();
        private void buttonHtml_Click(object sender, EventArgs e)
        {
            string htmlUlasim = ExportDataTableToHtml(ulasimBilgileri);
            string htmlKonaklama = ExportDataTableToHtml(konaklamaBilgileri);
            string document = htmlUlasim + "\n" + htmlKonaklama;

            webBrowser.DocumentText = document;
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            webBrowser.Print();
        }
        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser.Print();
        }
    }
}
