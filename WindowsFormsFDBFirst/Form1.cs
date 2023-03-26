using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFDBFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ADONetDbEntities tablolar = new ADONetDbEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            // Entityframework ado net deki gibi sql kodları yazmadan veritabanı crud işlemlerini yapabilmemizi sağlayan bir kütüphanedir. Projeye sonradan Nuget package manager aracılığı ile eklenir. 
            // Projeye Entityframework ekleyebilmek için projeye sağ tıklayıp açılan menüden nuget package manager i seçip açılan pencereden browse seçeneğine basıp oradan entity framework paketini seçip yükle butonu ile açılan onay pencerekerine onay vermemiz gerekir.
            dgvUrunler.DataSource = tablolar.urunler.ToList(); // veritabanındaki ürünleri listele
            // ürün yönetimi.edmx i oluşturmak için : projeye sağ tık add new item>sol menuden datayı sectik > gelen ekranda ilk secenegi secip next dedik> asagıda isim verip next dedik >gelen ekranda veritabanı ayarlarını yaptık >ok ile pencereyi kapatıp tabloların ekrana gelmesini bekledik >ustte kaydet butonuna bastık >kayıt tamam
            // veritabanı işlemleri UrunYonetimi.edmx in altındaki AdoNetEntities classı kullanılarak yapılıyor.
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            var urun = new urun() // ekrandan girilen bilgilerle 1 ürün oluştur
            {
                StokMiktari = int.Parse(txtStokMiktari.Text),
                UrunAdi = txtUrunAdi.Text,
                UrunFiyati = decimal.Parse(txtUrunFiyati.Text)
            };
            tablolar.urunler.Add(urun); // üstteki ürünü ef deki tablolardan urunler tablosuna ekle
            int sonuc = tablolar.SaveChanges(); // tablolardaki değişikliği kaydet ve veritabanına işle. SaveChanges metodu bize etkilenen kayıt sayısını getirir.
            if (sonuc > 0)
            {
                dgvUrunler.DataSource = tablolar.urunler.ToList();
                MessageBox.Show("Kayıt Başarılı");
            }
            else MessageBox.Show("Kayıt Başarısız!");
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value.ToString()); // seçili satırdaki id değerini yakala
            var urun = tablolar.urunler.Find(id); // yakalanan id ile ef find metodunu kullanarak db den bu id ye ait ürünü getir
            txtUrunFiyati.Text = urun.UrunFiyati.ToString(); // db den gelen ürün deki bilgileri textbox lara doldur
            txtUrunAdi.Text = urun.UrunAdi;
            txtStokMiktari.Text = urun.StokMiktari.ToString();
            btnekle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnsil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value.ToString());
                var urun = tablolar.urunler.Find(id);
                urun.UrunFiyati = decimal.Parse(txtUrunFiyati.Text);
                urun.StokMiktari = int.Parse(txtStokMiktari.Text);
                urun.UrunAdi = txtUrunAdi.Text;
                int sonuc = tablolar.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = tablolar.urunler.ToList();
                    btnekle.Enabled = true;
                    btnGuncelle.Enabled = false;
                    btnsil.Enabled = false;
                    MessageBox.Show("Kayıt Başarılı");
                }
                else MessageBox.Show("Kayıt Başarısız!");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value.ToString());// seçili satırdan id değerini aldık
            var urun = tablolar.urunler.Find(id);// veritabanından bu idli ürünü bulduk 
            tablolar.urunler.Remove(urun);// bulunan ürünü sildik

            int sonuc = tablolar.SaveChanges();// silme işlemini dbye işledik yoksa silme gerçekleşmez
            if (sonuc > 0)// silindiyse
            {
                dgvUrunler.DataSource = tablolar.urunler.ToList();
                btnekle.Enabled = true;
                btnGuncelle.Enabled = false;
                btnsil.Enabled = false;
                MessageBox.Show("Kayıt Başarılı");
            }
            else MessageBox.Show("Kayıt Başarısız!");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = tablolar.urunler.Where(x=>x.UrunAdi.Contains(txtAra.Text)).ToList();//x=>x. UrUNaDİ ŞEKLİNDEKİ YAZIM TÜRÜNÜ ENTITY FRAMEWORK de lamda expessıon denir .tablolar.Urunler den sonra where metodu  çağırıp içerisinde ürünadi kolonunda txtAra dan gelecel değerle eşleşen kayıt varsa filtrelme yapar.

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = tablolar.urunler.Where(x => x.UrunAdi.Contains(txtAra.Text)).ToList();// textbox daki  içerik değiştikçe sorgula
        }
    }
}
