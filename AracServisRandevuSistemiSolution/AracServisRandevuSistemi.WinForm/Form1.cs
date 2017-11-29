using AracServisRandevuSistemi.Data;
using AracServisRandevuSistemi.Kutuphane;
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
            foreach (var marka in dataManager.aracMarkalariGetir())
            {
                cmbAracMarka.Items.Add(marka);
            }
            //cmbAracMarka.DisplayMember = "MarkaName";
            //cmbAracMarka.ValueMember = "MarkaId";
            //cmbAracMarka.DataSource = dataManager.aracMarkalariGetir();
        }

        private void cmbAracMarka_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AracMarka secilen = (AracMarka)cmbAracMarka.SelectedItem;

            cmbAracModel.ValueMember = "ModelId";
            cmbAracModel.DisplayMember = "ModelName";
            cmbAracModel.DataSource = dataManager.aracModelleriGetir(secilen.aracMarkaId);
        }
    }
}
