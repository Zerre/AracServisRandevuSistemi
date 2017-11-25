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

        public void RandevuOlustur()
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("MusteriEkleVeRandevuOlustur", connection);
            }
        }
    }
}
