using AracServisRandevuSistemi.Kutuphane;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracServisRandevuSistemi.Data
{
    public class DataManager
    {
        private static string connectionString = "Data Source=SamininMakinesi;Initial Catalog=AracServisRandevuSistemi;Integrated Security=True";
        private static SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public int RandevuOlustur(Musteri musteri, Musteri_Arac musteri_Arac, RandevuZamani randevuZamani, Lift lift, Randevu randevu)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("RandevuEkle", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MusteriAdi", musteri.musteriAdi);
                command.Parameters.AddWithValue("@MusteriSoyadi", musteri.musteriSoyadi);
                command.Parameters.AddWithValue("@FirmaAdi", musteri.firmaAdi);
                command.Parameters.AddWithValue("@MusteriIletisimNo", musteri.iletisimNumarasi);

                command.Parameters.AddWithValue("@PlakaNo", musteri_Arac.plakaNo);
                command.Parameters.AddWithValue("@ModelId", musteri_Arac.aracModel.modelId);
                command.Parameters.AddWithValue("@YilId", musteri_Arac.modelYili.yilId);

                command.Parameters.AddWithValue("@RandevuGunu", randevuZamani.randevuGunu);
                command.Parameters.AddWithValue("@RandevuSaatId", randevuZamani.randevuSaati.randevuSaatId);

                command.Parameters.AddWithValue("@LiftId", lift.liftId);

                command.Parameters.AddWithValue("@YapilacakIslemler", randevu.yapilacakIslem);
                command.Parameters.AddWithValue("@SaatiGectiMi", randevu.saatGectiMi);
                command.Parameters.AddWithValue("@BakimYapildiMi", randevu.bakimYapildiMi);
                command.Parameters.AddWithValue("@CalisanId", randevu.calisan.calisanId);

                int sonuc = command.ExecuteNonQuery();
                return sonuc;
            }
        }

        public List<AracMarka> aracMarkalariGetir()
        {
            var aracListesi = new List<AracMarka>();
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM AracMarka ", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AracMarka marka = new AracMarka();
                        marka.aracMarkaId = (int)reader["MarkaId"];
                        marka.markaAdi = reader["MarkaName"].ToString();
                        aracListesi.Add(marka);
                    }
                }
            }
            return aracListesi;
        }

        public List<AracModel> aracModelleriGetir(int MarkaId)
        {
            var modelListesi = new List<AracModel>();
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM AracModel where MarkaID = @id", connection);
                command.Parameters.AddWithValue("@id", MarkaId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new AracModel((int)reader["ModelId"], reader["ModelName"].ToString());
                        modelListesi.Add(model);
                    }
                }
            }
            return modelListesi;
        }

        public List<AracModelYili> modelYiliGetir()
        {
            List<AracModelYili> modelYiliListesi = new List<AracModelYili>();
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM AracModelYili order by YilId desc", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AracModelYili aracModelYili = new AracModelYili();
                        aracModelYili.yilId = (int)reader["YilId"];
                        aracModelYili.aracinModelYili = (string)reader["Yillar"];
                        modelYiliListesi.Add(aracModelYili);
                    }
                }
            }
            return modelYiliListesi;
        }

        public List<Lift> LiftleriGetir()
        {
            List<Lift> liftler = new List<Lift>();

            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("Select * from Liftler", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lift lift = new Lift();
                        lift.liftId = (int)reader["LiftId"];
                        lift.liftAdi = reader["LiftAdi"].ToString();
                        liftler.Add(lift);
                    }
                }
            }
            return liftler;
        }

        public List<RandevuSaati> saatleriGetir()
        {
            List<RandevuSaati> randevuSaatleri = new List<RandevuSaati>();

            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("Select * from RandevuSaatleri", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RandevuSaati saat = new RandevuSaati();
                        saat.randevuSaatId = (int)reader["RandevuSaatId"];
                        saat.randevuSaat = reader["RandevuSaati"].ToString();
                        randevuSaatleri.Add(saat);
                    }
                }
            }
            return randevuSaatleri;
        }

        public int CalisanEkle(string adi, string soyadi, string cepNo, int gorevId, string kullaniciAdi, string sifre, bool yetki)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("CalisanEkle", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Adi", adi);
                command.Parameters.AddWithValue("@Soyadi", soyadi);
                command.Parameters.AddWithValue("@CepNo", cepNo);
                command.Parameters.AddWithValue("@GorevId", gorevId);
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                command.Parameters.AddWithValue("@Sifre", sifre);
                command.Parameters.AddWithValue("@Yetki", yetki);

                int sonuc = command.ExecuteNonQuery();
                return sonuc;
            }
        }
    }
}