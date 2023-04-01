using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsKategoriYONETİMİ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = dal.GetAllDataTable("select * from kategoriler");
            dgvKategoriler.Columns[1].HeaderText = "Kategori Adı";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))

            {
                MessageBox.Show("Kategori Adı Boş Geçilmez");
                return;

            }
            
                var kategori = new Kategori();
            kategori.KategoriAdi= txtKategoriAdi.Text;
            model.Kategoriler.Add(kategori);
            model.SaveChanges();
            dgvKategoriler.DataSource = model.Kategoriler.ToList();
            btnEkle.Enabled = true;
            btnGüncelle.Enabled = false;
            btnsil.Enabled = false;
            txtKategoriAdi.Text=string.Empty;



                {
                    KategoriAdi = txtKategoriAdi.Text
                };
                var sonuc = dal.Add(kategori);
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = dal.GetAllDataTable(sql: "select * from kategoriler");
                    txtKategoriAdi.Text = string.Empty;
                    txtKategoriAdi.Focus();
                    MessageBox.Show("kayıt başarılı");

                }
            }
        }

        private void dgvKategoriler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value.ToString());
                var kategori = dal.Get(id);
                if (kategori != null)
                {
                    txtKategoriAdi.Text = kategori.KategoriAdi;
                }
                btnEkle.Enabled = false;
                btnGüncelle.Enabled = true;
                btnSil.Enabled = true;

            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu");
            }


        }
    