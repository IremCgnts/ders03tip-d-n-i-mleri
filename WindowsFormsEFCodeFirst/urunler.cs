namespace WindowsFormsEFCodeFirst
{
   

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("urunler")]
    public partial class Urun
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UrunAdi { get; set; }

        public decimal UrunFiyati { get; set; }

        public int? StokMiktari { get; set; }
    }
}
