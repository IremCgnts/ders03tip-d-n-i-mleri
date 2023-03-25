using System.Data ;
using System.Data.SqlClient;


namespace adonet
{
    public class UrunDAL
    {

        // bu class urun ile alakalı veritabanı işlmleri için
        SqlConnection connection=new SqlConnection(@"Server=.;database=AdoNetDb;trusted_connection=true");//veritabanına bağlanmak için gerekli bağlantı nesnesi .ConnectionString veritabanı bağlantı bilgileri
        void BaglantiyiAc()
        {
            if (connection.State==ConnectionState.Closed)//veritabanı bağlantısı kapalıysa
            {
                connection.Open();// bağlantıyı aç

            }
        }
       public List<Urun>UrunleriGetir()
        {
            BaglantiyiAc();
            List<Urun> urunler = new List<Urun>();// boş ürün listesi oluşturduk
            SqlCommand sqlCommand("select* from urunler ",connection);//sql komutu çalistırmak için gerekli nesneyi oluşturup içine selectcümlemizi ve bağlantımı verdik 
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//
            while(sqlDataReader.Read())//
            {
                Urun urun = new Urun()//
                {
                    UrunId = Convert.ToInt32(sqlDataReader["Id"]),
                    StokMiktari = Convert.ToInt32(sqlDataReader["StokMiktari"]),
                    UrunAdi = sqlDataReader["UrunAdi"].ToString(),
                    UrunFiyati = Convert.ToDecimal(sqlDataReader["UrunFiyati"])


                };
                urunler.Add(urun);//


            }
            sqlDataReader.Close();//kapat
            sqlCommand.Dispose();// yoket
            connection.Close();// kapat
            return urunler;//bu metodun kullanıldığı yere ürünleri gönder





        }

    }
}
