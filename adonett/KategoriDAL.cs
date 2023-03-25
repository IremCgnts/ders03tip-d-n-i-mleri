
using adonet;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonett
{
    internal class KategoriDAL: OrtakDAL// ortakdaldan miras alarak onun içindekileri burada kullanılabilir hale getirdik
    {
        public int Add(Kategori kategori)
        {
            BaglantiyiAc();
            int IslemSonucu = 0;
            SqlCommand sqlCommand = new SqlCommand("insert into kategoriler(KategoriAdi)values(@KategoriAdi)", connection);
            
            
            sqlCommand.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            IslemSonucu = sqlCommand.ExecuteNonQuery();// sql çalıştiğinda aql den bize etkilene kayıt sayısı döner işlem basarılıysa 0 dan buyuk (genelde 1 )değer gelir
            sqlCommand.Dispose();// yoket
            connection.Close();//bağlantıyı kapat
            return IslemSonucu;// eklemeden sonra geriye işlem sonucu döndür
        }
        public Kategori Get(int id)
        {
            Kategori kategori = new Kategori();
            
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand("select * from kategoriler where Id=@Id", connection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                kategori.Id = Convert.ToInt32(sqlDataReader["Id"]);
                kategori.KategoriAdi = sqlDataReader["KategoriAdi"].ToString();
                
                
            }
            sqlDataReader.Close();
            sqlCommand.Dispose();
            connection.Close();
            return kategori;

        }
        public int Delete(int id)
        {
            BaglantiyiAc();
            int islemSonucu = 0;
            SqlCommand sqlCommand = new SqlCommand("delete from kategoriler where Id=@id", connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            islemSonucu = sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose(); // yoket
            connection.Close(); // bağlantıyı kapat
            return islemSonucu;
        }
        public int Update (Kategori kategori)
        {
            BaglantiyiAc();
            int IslemSonucu = 0;
            SqlCommand sqlCommand = new SqlCommand("update kategoriler set KategoriAdi=@KategoriAdi  where Id=@id", connection);


            sqlCommand.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            sqlCommand.Parameters.AddWithValue("@id", kategori.Id);
            IslemSonucu = sqlCommand.ExecuteNonQuery();// sql çalıştiğinda aql den bize etkilene kayıt sayısı döner işlem basarılıysa 0 dan buyuk (genelde 1 )değer gelir
            sqlCommand.Dispose();// yoket
            connection.Close();//bağlantıyı kapat
            return IslemSonucu;// eklemeden sonra geriye işlem sonucu döndür
        }

    }
}
