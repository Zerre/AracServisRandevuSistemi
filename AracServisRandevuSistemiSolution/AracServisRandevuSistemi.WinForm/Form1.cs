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
        RandevuSaati secilenSaat;
        Lift secilenLift;

        private void frmRandevu_Load(object sender, EventArgs e)
        {
            cmbAracMarka.DataSource = dataManager.aracMarkalariGetir();
            cmbAracMarka.SelectedItem = 0;
            cmbModelYili.DataSource = dataManager.modelYiliGetir();
            cmbModelYili.SelectedIndex = 3;

            int grpLocationX = 10, grpLocationY = 27;
            int btnLocationX = 95, btnLocationY = 1;
            bool Renk = true;
            foreach (var lift in dataManager.LiftleriGetir())
            {
                GroupBox grpLift = new GroupBox();
                grpLift.Name = lift.liftAdi;
                grpLift.Text = lift.liftAdi.ToUpper();
                grpLift.Tag = lift;
                grpLift.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);                
                grpLift.Size = new Size(818, 77);
                grpLift.Location = new Point(grpLocationX, grpLocationY);
                grpLocationY += grpLift.Height + 5;
                foreach (var saat in dataManager.saatleriGetir())
                {
                    Button btnSaat = new Button();
                    btnSaat.Name = "btn_" + saat.randevuSaat;
                    btnSaat.Text = saat.randevuSaat;
                    btnSaat.Tag = saat;
                    btnSaat.Font = new Font("Microsoft Sans Serif", 8);
                    if (Renk)
                    {
                        btnSaat.ForeColor = Color.OrangeRed;
                        Renk = false;
                    }
                    else
                    {
                        btnSaat.ForeColor = Color.DarkBlue;
                        Renk = true;
                    }
                    btnSaat.Size = new Size((grpLift.Width-95-(dataManager.saatleriGetir().Count*5))/dataManager.saatleriGetir().Count, 75);
                    btnSaat.Location = new Point(btnLocationX, btnLocationY);
                    btnLocationX += btnSaat.Width + 5;
                    btnSaat.Click += btnRandevuSaati_Click;
                    grpLift.Controls.Add(btnSaat);
                }
                btnLocationX = 95;
                pnlZaman.Controls.Add(grpLift);
            }

            for (int i = 0; i < grpLift1.Controls.Count; i++)
            {
                grpLift1.Controls[i].Tag = dataManager.saatleriGetir()[i];
                grpLift1.Controls[i].Text = dataManager.saatleriGetir()[i].randevuSaat;
                grpLift2.Controls[i].Tag = dataManager.saatleriGetir()[i];
                grpLift2.Controls[i].Text = dataManager.saatleriGetir()[i].randevuSaat;
                grpLift3.Controls[i].Tag = dataManager.saatleriGetir()[i];
                grpLift3.Controls[i].Text = dataManager.saatleriGetir()[i].randevuSaat;
            }

            grpLift1.Tag = dataManager.LiftleriGetir()[0];
            grpLift2.Tag = dataManager.LiftleriGetir()[1];
            grpLift3.Tag = dataManager.LiftleriGetir()[2];
        }

        private void cmbAracMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            AracMarka secilenAracMarka = (AracMarka)cmbAracMarka.SelectedItem;
            cmbAracModel.DataSource = dataManager.aracModelleriGetir(secilenAracMarka.aracMarkaId);
        }

        private void btnRandevuSaati_Click(object sender, EventArgs e)
        {
            Button tiklananButon = sender as Button;
            secilenSaat = (RandevuSaati)tiklananButon.Tag;
            secilenLift = (Lift)tiklananButon.Parent.Tag;
            MessageBox.Show(tiklananButon.Text);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri() { musteriAdi = txtMusteriAdi.Text, musteriSoyadi = txtMusteriSoyadi.Text, firmaAdi = txtFirmaAdi.Text, iletisimNumarasi = txtIletisimNo.Text };

            Musteri_Arac musteri_Arac = new Musteri_Arac() { plakaNo = txtPlakaNo.Text, aracModel = (AracModel)cmbAracModel.SelectedItem, modelYili = (AracModelYili)cmbModelYili.SelectedItem };

            RandevuZamani randevuZamani = new RandevuZamani() { randevuGunu = dtpRandevuGunu.Value.ToString("yyyy.MM.dd"), randevuSaati = secilenSaat };

            Lift lift = new Lift() { liftId = secilenLift.liftId, liftAdi = secilenLift.liftAdi };

            CalisanGorev calisanGorev = new CalisanGorev() { gorevId = 1, gorevAdi = "Usta" };
            Calisan aktifCalisan = new Calisan() { calisanId = 1, calisanAdi = "Burak", soyadi = "K.", cepNo = "5553331122", gorev = calisanGorev };
            Randevu randevu = new Randevu() { yapilacakIslem = txtYapilacakIslemler.Text, saatGectiMi = false, bakimYapildiMi = false, calisan = aktifCalisan };

            if (dataManager.RandevuOlustur(musteri, musteri_Arac, randevuZamani, lift, randevu) > 0)
            {
                MessageBox.Show("Randevu Oluşturuldu");
            }
        }
    }
}
