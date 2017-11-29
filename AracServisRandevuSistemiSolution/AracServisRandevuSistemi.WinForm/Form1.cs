using AracServisRandevuSistemi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracServisRandevuSistemi.WinForm
{
    public partial class frmRandevu : Form
    {
        public frmRandevu()
        {
            InitializeComponent();
        }

        DataManager dataManager = new DataManager();

        private void button1_Click(object sender, EventArgs e)
        {
            //dataManager.ModelYillariniEkle();
            //MessageBox.Show("Yıllar Eklendi..");


        }

        private void frmRandevu_Load(object sender, EventArgs e)
        {
            foreach (var item in dataManager.aracMarkalariGetir())
            {
                cmbAracMarka.ValueMember = item.aracMarkaId.ToString();
                cmbAracMarka.DisplayMember = item.markaAdi;
                //cmbAracMarka.Items.Add(item.markaAdi);
                

            }
        }

        private void cmbAracMarka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
