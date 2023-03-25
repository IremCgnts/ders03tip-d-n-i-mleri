using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonett
{
    internal class OrtakDAL
    {
        // bu class urun ile alakalı veritabanı işlmleri için
        public SqlConnection connection = new SqlConnection(@"Server=.;database=AdoNetDb;trusted_connection=true");//veritabanına bağlanmak için gerekli bağlantı nesnesi .ConnectionString veritabanı bağlantı bilgileri
        public void  BaglantiyiAc()
        {
            if(connection.State== ConnectionState.Closed)
            {
                connection.Open();
            }       
        }
        public DataTable GetAllDataTable(string sql)
        {
            DataTable table = new DataTable();
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            table.Load(sqlDataReader);// veritabanına çekilen verileri table a yukle
            sqlDataReader.Close(); // kapat
            sqlCommand.Dispose(); // yoket
            connection.Close();
            return table;

        }
    }
}
