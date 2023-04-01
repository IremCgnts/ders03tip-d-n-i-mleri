using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEFCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EFCodeFirstModel model= new EFCodeFirstModel(); 
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = model.urunler.ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            var urun = new Urun()
            {
                StokMiktari=int.Parse(txtStokMiktari.Text),
                UrunAdi=txtUrunAdi.Text,
                UrunFiyati=Convert.ToDecimal(txtUrunFiyati .Text),
            };
            model.urunler.Add(urun);
            var islemSonucu = model.SaveChanges();
            if(islemSonucu>0)
            {
                dgvUrunler.DataSource = model.urunler.ToList();
                MessageBox.Show("Kayıt Başarılı");
            }

           


        }

        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value.ToString());
            var urun=model.urunler.Find(id);
            txtStokMiktari.Text = urun.StokMiktari.ToString();
            urun.UrunAdi= txtUrunAdi.Text;
            txtUrunFiyati.Text=urun.UrunFiyati.ToString();
            btnekle.Enabled=false;
            btnGuncelle.Enabled=true;
            btnsil.Enabled=true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value.ToString());
            var urun = model.urunler.Find(id);
            urun.StokMiktari = int.Parse(txtStokMiktari.Text);
            urun.UrunAdi = txtUrunAdi.Text;
            urun.UrunFiyati=Convert.ToDecimal(txtUrunFiyati.Text);
            var islemSonucu = model.SaveChanges();
            if (islemSonucu > 0)
            {
                dgvUrunler.DataSource = model.urunler.ToList();
                btnekle.Enabled = true;
                btnGuncelle.Enabled = false;
                btnsil.Enabled = false;
                MessageBox.Show("Kayıt Başarılı");
            }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {

            var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value.ToString());
            var urun = model.urunler.Find(id);
            model.urunler.Remove(urun);
            var islemSonucu = model.SaveChanges();
            if (islemSonucu > 0)
            {
                dgvUrunler.DataSource = model.urunler.ToList();
                btnekle.Enabled = true;
                btnGuncelle.Enabled = false;
                btnsil.Enabled = false;
                MessageBox.Show("Kayıt Silme Başarılı");
            }

        }
    }
}
