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
        private static string connectionString = "Data Source=SamininMAkinesi;Initial Catalog=AracServisRandevuSistemi;Integrated Security=True";

        private static SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        //public void ModelYillariniEkle()
        //{
        //    using (SqlConnection connection = CreateConnection())
        //    {
        //        SqlCommand command = new SqlCommand("insert into AracModelYili (Yillar) values(@yil)", connection);

        //        for (int i = 1880; i < 2019; i++)
        //        {                    
        //            command.Parameters.AddWithValue("@yil", i.ToString());
        //            command.ExecuteNonQuery();
        //            command.Parameters.Clear();
        //        }
        //    }
        //}

        public void RandevuOlustur(Musteri musteri, Musteri_Arac musteri_Arac, RandevuZamani randevuZamani, Lift lift, Randevu randevu)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("MusteriEkleVeRandevuOlustur", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MusteriAdi", musteri.musteriAdi);
                command.Parameters.AddWithValue("@MusteriSoyadi", musteri.musteriSoyadi);
                command.Parameters.AddWithValue("@FirmaAdi", musteri.firmaAdi);
                command.Parameters.AddWithValue("@MusteriIletisimNo", musteri.iletisimNumarasi);

                command.Parameters.AddWithValue("@PlakaNo", musteri_Arac.plakaNo);
                command.Parameters.AddWithValue("@ModelId", musteri_Arac.musteriAracId);
                command.Parameters.AddWithValue("@YilId", musteri_Arac.modelYili);

                command.Parameters.AddWithValue("@RandevuGunu", randevuZamani.randevuGunu);
                command.Parameters.AddWithValue("@RandevuSaatId", randevuZamani.randevuSaati);

                command.Parameters.AddWithValue("@LiftId", lift.liftId);

                command.Parameters.AddWithValue("@YapilacakIslemler", randevu.yapilacakIslem);
                command.Parameters.AddWithValue("@SaatiGectiMi", randevu.saatGectiMi);
                command.Parameters.AddWithValue("@BakimYapildiMi", randevu.bakimYapildiMi);
                command.Parameters.AddWithValue("@CalisanId", randevu.calisan);

                command.ExecuteNonQuery();
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
    }
}
