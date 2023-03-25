using adonet;
using System;
using System.Collections.Generic;
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
        public List<Urun> UrunleriGetir()
        {
            BaglantiyiAc();
            List<Urun> urunler = new List<Urun>(); // boş ürün listesi oluşturduk
            SqlCommand sqlCommand = new SqlCommand("select * from urunler", connection); // sql komutu çalıştırmak için gerekli nesneyi oluşturup içine select cümlemizi ve bağlantımızı verdik
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(); // sqlCommand çalıştırıldığında dönecek kayıtları okumak için sqlDataReader oluşturduk
            while (sqlDataReader.Read()) // sqlDataReader dan kayıt okunduğu sürece
            {
                Urun urun = new Urun() // veritabanından gelecek ürün bilgileri için nesnemiz
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    StokMiktari = Convert.ToInt32(sqlDataReader["StokMiktari"]),
                    UrunAdi = sqlDataReader["UrunAdi"].ToString(),
                    UrunFiyati = Convert.ToDecimal(sqlDataReader["UrunFiyati"])
                };
                urunler.Add(urun); // db den gelen ürünü yukardaki boş listeye ekliyoruz
            }
            sqlDataReader.Close(); // kapat
            sqlCommand.Dispose(); // yoket
            connection.Close();  // kapat
            return urunler; // bu metodun kullanılacağı yere ürünleri gönder
        }
        public DataTable UrunleriDataTablelaGetir()
        {
            DataTable table = new DataTable();
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand("select * from urunler", connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            table.Load(sqlDataReader);// veritabanına çekilen verileri table a yukle
            sqlDataReader.Close(); // kapat
            sqlCommand.Dispose(); // yoket
            connection.Close();  
            return table;

        }
        public DataTable UrunleriDataTablelaGetir(string kelime)
        {
            DataTable table = new DataTable();
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand("select * from urunler where urunadi Like @kelime", connection);
            sqlCommand.Parameters.AddWithValue("@kelime", "%" + kelime + "%");
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            table.Load(sqlDataReader);// veritabanına çekilen verileri table a yukle
            sqlDataReader.Close(); // kapat
            sqlCommand.Dispose(); // yoket
            connection.Close();
            return table;

        }
        public int Add(Urun urun)
        {
            BaglantiyiAc();
            int IslemSonucu = 0;
            SqlCommand sqlCommand = new SqlCommand("insert into urunler(StokMiktari,UrunAdi,UrunFiyati)values(@StokMiktari,@UrunAdi,@UrunFiyati", connection);
            sqlCommand.Parameters.AddWithValue("@StokMiktari", urun.StokMiktari);
            sqlCommand.Parameters.AddWithValue("@UrunFiyati", urun.UrunFiyati);
            sqlCommand.Parameters.AddWithValue("@UrunAdi", urun.UrunAdi);
            IslemSonucu = sqlCommand.ExecuteNonQuery();// sql çalıştiğinda aql den bize etkilene kayıt sayısı döner işlem basarılıysa 0 dan buyuk (genelde 1 )değer gelir
            sqlCommand.Dispose();// yoket
            connection.Close();//bağlantıyı kapat
            return IslemSonucu;// eklemeden sonra geriye işlem sonucu döndür
        }
        public int Update(Urun urun)
        {
            BaglantiyiAc();
            int IslemSonucu = 0;
            SqlCommand sqlCommand = new SqlCommand("update urunler setStokMiktari=StokMiktari,UrunAdi=@UrunAdi, UrunFiyati=@UrunFiyati where Id=@UrunId", connection);
                sqlCommand.Parameters.AddWithValue("@UrunId", urun.Id);
            sqlCommand.Parameters.AddWithValue("@StokMiktari", urun.StokMiktari);
            sqlCommand.Parameters.AddWithValue("@UrunFiyati", urun.UrunFiyati);
            sqlCommand.Parameters.AddWithValue("@UrunAdi", urun.UrunAdi);
            IslemSonucu= sqlCommand.ExecuteNonQuery();// sql çalıştiğinda aql den bize etkilene kayıt sayısı döner işlem basarılıysa 0 dan buyuk (genelde 1 )değer gelir
            sqlCommand.Dispose();// yoket
            connection.Close();//bağlantıyı kapat
            return IslemSonucu;// eklemeden sonra geriye işlem sonucu döndür
        }

        public int Delete(int id)
        {
            BaglantiyiAc();
            int islemSonucu = 0;
            SqlCommand sqlCommand = new SqlCommand("delete from urunler where Id=@UrunId", connection);
            sqlCommand.Parameters.AddWithValue("@UrunId", id);
            islemSonucu = sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose(); // yoket
            connection.Close(); // bağlantıyı kapat
            return islemSonucu;
        }
        public Urun Get(int id)
        {
            Urun urun = new Urun();
            return urun;
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand("delete from urunler where Id=@UrunId", connection);
            sqlCommand.Parameters.AddWithValue("@UrunId", id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();   
            if(sqlDataReader.Read())
            {
                urun.Id = Convert.ToInt32(sqlDataReader["Id"]);
                urun.UrunFiyati =Convert.ToDecimal(sqlDataReader["UrunFiyati"]);
                urun.UrunAdi = sqlDataReader["UrunAdi"].ToString();
                urun.StokMiktari = Convert.ToInt32(sqlDataReader["StokMiktari"]);
            }
            sqlDataReader.Close();
            sqlCommand.Dispose();
            connection.Close();
            return urun;

        }

    }
}
