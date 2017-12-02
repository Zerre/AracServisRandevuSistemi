
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AracServisRandevuSistemi.Data;

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
                cmbAracMarka.Items.Add(item.markaAdi);
                cmbAracMarka.SelectedValue = Convert.ToInt32( item.aracMarkaId);
                foreach (var model in dataManager.aracModelleriGetir())
                {
                    if (model.markaId ==Convert.ToInt32( cmbAracMarka.SelectedValue))
                    {
                        cmbAracModel.Items.Add(model.modelAdi);
                    }
                }

            }
        }

        private void cmbAracMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbAracModel_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
