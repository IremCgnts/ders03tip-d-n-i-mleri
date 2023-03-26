using adonet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adonett
{
    public partial class KategoriYönetimi : Form
    {
        public KategoriYönetimi()
        {
            InitializeComponent();
        }
        KategoriDAL dal =new KategoriDAL();

        private void KategoriYönetimi_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = dal.GetAllDataTable("select * from kategoriler");
            dgvKategoriler.Columns[1].HeaderText = "Kategori Adı";// grid viw in kolon başlığını değiştirmek için

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))

            {
                MessageBox.Show("Kategori Adı Boş Geçilmez");
                
            }
            else
            {
                var kategori = new Kategori()
                {
                    KategoriAdi = txtKategoriAdi.Text
                };
                var sonuc =dal.Add (kategori);
                if (sonuc>0)
                {
                    dgvKategoriler.DataSource = dal.GetAllDataTable(sql: "select * from kategoriler");
                    txtKategoriAdi.Text = string.Empty;
                    txtKategoriAdi.Focus();
                    MessageBox.Show("kayıt başarılı");

                }
            }

        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value.ToString());
                var kategori = dal.Get(id);
                if(kategori!=null)
                {
                    txtKategoriAdi.Text=kategori.KategoriAdi;
                }
                btnEkle.Enabled = false;
                btnGüncelle.Enabled = true;
                btnSil.Enabled  = true;

            }
            catch(Exception)
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))

                {
                    MessageBox.Show("Kategori Adı Boş Geçilmez");

                }
                else
                {
                    var kategori = new Kategori()
                    {
                        Id= Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value),
                        KategoriAdi = txtKategoriAdi.Text
                    };
                    var sonuc = dal.Update(kategori);
                    if (sonuc > 0)
                    {
                        dgvKategoriler.DataSource = dal.GetAllDataTable(sql: "select * from kategoriler");
                        txtKategoriAdi.Text = string.Empty;
                        txtKategoriAdi.Focus();
                        btnEkle.Enabled = true;
                        btnGüncelle.Enabled = false;
                        btnSil.Enabled = false;
                        MessageBox.Show("kayıt başarılı");

                    }
                }
                }
            catch(Exception)
            {
                MessageBox.Show("Hata Oluştu");
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Silmek İstediğinize Emin Misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            try
            {
                var urunId = int.Parse(dgvKategoriler.CurrentRow.Cells[0].Value.ToString());
                var sonuc = dal.Delete(urunId);
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = dal.GetAllDataTable("select * from kategoriler");
                    btnGüncelle.Enabled = false;
                        btnSil.Enabled=false;
                        txtKategoriAdi.Text = string.Empty;
                        txtKategoriAdi.Focus();
                        btnEkle.Enabled = true;
                        MessageBox.Show("Kayıt Silme Başarılı");
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

        
    }
}
