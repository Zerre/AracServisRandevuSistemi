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

        private void frmRandevu_Load(object sender, EventArgs e)
        {
            cmbAracMarka.DataSource = dataManager.aracMarkalariGetir();
            cmbAracMarka.SelectedItem = 0;
            cmbModelYili.DataSource = dataManager.modelYiliGetir();
            cmbModelYili.SelectedIndex = 3;
        }

        private void cmbAracMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            AracMarka secilenAracMarka = (AracMarka)cmbAracMarka.SelectedItem;
            cmbAracModel.DataSource = dataManager.aracModelleriGetir(secilenAracMarka.aracMarkaId);
        }

        private void cmbAracModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            AracModel secilenAracModel = (AracModel)cmbAracModel.SelectedItem;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
        }
    }
}
