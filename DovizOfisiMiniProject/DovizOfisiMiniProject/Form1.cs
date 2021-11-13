using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizOfisiMiniProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugün = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(bugün);

            string dolarAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            string dolarSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string euroAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            string euroSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;

            lblDolarAlis.Text = dolarAlis;
            lblDolarSatis.Text = dolarSatis;
            lblEuroAlis.Text = euroAlis;
            lblEuroSatis.Text = euroSatis;

        }

        private void btnDolarAl_Click(object sender, EventArgs e)
        {
            tbxKur.Text = lblDolarAlis.Text;   
        }

        private void btnDolarSat_Click(object sender, EventArgs e)
        {
            tbxKur.Text = lblDolarSatis.Text;
        }

        private void btnEuroAl_Click(object sender, EventArgs e)
        {
            tbxKur.Text = lblEuroAlis.Text;
        }

        private void btnEuroSat_Click(object sender, EventArgs e)
        {
            tbxKur.Text = lblEuroSatis.Text;
        }

        private void btnSat_Click(object sender, EventArgs e)
        {
            double kur, toplam, miktar;
            kur = Convert.ToDouble(tbxKur.Text);
            miktar = Convert.ToDouble(tbxMiktar.Text);
            toplam = kur * miktar;
            tbxTutar.Text = toplam.ToString();
        }

        private void tbxKur_TextChanged(object sender, EventArgs e)
        {
            tbxKur.Text = tbxKur.Text.Replace(".", ",");
        }

        private void btnAlisYap_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(tbxKur.Text);
            int tutar = Convert.ToInt32(tbxTutar.Text);
            int miktar = Convert.ToInt32(tutar/kur);
            tbxMiktar.Text = miktar.ToString();
            double kalan;
            kalan = miktar % kur;
            tbxKalan.Text = kalan.ToString();
        }
    }
}
