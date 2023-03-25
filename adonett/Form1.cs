using adonet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adonett
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UrunDAL urunDAL = new UrunDAL();
        private object hata;

        private void Form1_Load(object sender, EventArgs e)
        {
            //dgvUrunler.DataSource= urunDAL.UrunleriGetir();
            dgvUrunler.DataSource = urunDAL.UrunleriDataTablelaGetir();
            dgvUrunler.Columns[1].HeaderText = "Ürün Adı";
            dgvUrunler.Columns[2].HeaderText = "Ürün Fiyati";
            dgvUrunler.Columns[3].HeaderText = "Stok Mikatrı";
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try// çalışmasını istediğimiz kodlar bu bloğa
            {
                var sonuc = urunDAL.Update(new Urun()

                {
                    StokMiktari = int.Parse(txtStokMiktari.Text),
                    UrunAdi = txtUrunAdi.Text,
                    UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text)
                });
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = urunDAL.UrunleriDataTablelaGetir();
                    MessageBox.Show("Kayıt Başarılı");
                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız");
                }
            }
            catch(Exception hata)
            {
                // hata oluştuğunda çalıştıracagımız kodlar buraya yazılır
                MessageBox.Show("Hata Oluştu!\n"+ hata.Message);
                
            }
            
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtUrunAdi.Text = dgvUrunler.CurrentRow.Cells[1].Value.ToString();
            txtUrunFiyati.Text = dgvUrunler.CurrentRow.Cells[2].Value.ToString();
            txtStokMiktari.Text = dgvUrunler.CurrentRow.Cells[3].Value.ToString();
            

            try
            {
                var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value.ToString());
                var urun = urunDAL.Get(id);
                if (urun != null)
                {
                    txtUrunAdi.Text = urun.UrunAdi;
                    txtUrunFiyati.Text = urun.UrunFiyati.ToString();
                    txtUrunFiyati.Text = urun.UrunFiyati.ToString();
                }
                btnGuncelle.Enabled = true;
                btnsil.Enabled = true;

            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata oluştu!" +hata.Message);
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try// çalışmasını istediğimiz kodlar bu bloğa
            {
                var sonuc = urunDAL.Update(new Urun()

                {
                    StokMiktari=int.Parse(txtStokMiktari.Text),
                    Id= int.Parse(dgvUrunler.CurrentRow.Cells[1].Value.ToString()) ,   
                    UrunAdi = txtUrunAdi.Text,
                    UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text)
                });
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = urunDAL.UrunleriDataTablelaGetir();
                    btnGuncelle.Enabled = false;
                    btnsil.Enabled = false;
                    MessageBox.Show("Kayıt Silme Başarılı");
                }
                else
                {
                    MessageBox.Show("Kayıt Silme Başarısız");
                }
            }
            catch (Exception hata)
            {
                // hata oluştuğunda çalıştıracagımız kodlar buraya yazılır
                MessageBox.Show("Hata Oluştu!\n" + hata.Message);

            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                var urunId = int.Parse(dgvUrunler.CurrentRow.Cells[0].Value.ToString());
                var sonuc = urunDAL.Delete(urunId);
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = urunDAL.UrunleriDataTablelaGetir();
                    btnGuncelle.Enabled = false;
                    MessageBox.Show("Kayıt Başarılı");
                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata Oluştu!\n" + hata.Message);

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dgvUrunler.DataSource=urunDAL.UrunleriDataTablelaGetir(txtAra.Text.Trim());
        }
    }
}
