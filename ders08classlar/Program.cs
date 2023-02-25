// See https://aka.ms/new-console-template for more information

using System;

namespace ders08classlar // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sınıflar-Class!");
            Ev ilkEv = new Ev();
            ilkEv.sokakAdi = "okul sokak";
            ilkEv.kapiNo = 10;
            Console.WriteLine("ilk ev sokak adi:" + ilkEv.sokakAdi);
            Console.WriteLine("İlk ev kapi no:" + ilkEv.kapiNo);
            Ev yazlikEv = new Ev();
            yazlikEv.sokakAdi = "enşz sokak";
            yazlikEv.kapiNo = 18;
            Console.WriteLine("yazlik ev sokak adi:" + yazlikEv.sokakAdi);
            Console.WriteLine("yazlik ev kapi no:" + yazlikEv.kapiNo);

            Ev koyEvi = new()
            {
                sokakAdi = "kavak sokak",// bu kullanimda ; yerine öğeler arasına , koymamız gerekli
                kapiNo = 27
            };
            Console.WriteLine("koy evi sokak adi:" + koyEvi.sokakAdi);
            Console.WriteLine("koy evi kapı no:" + koyEvi.kapiNo);
            Console.WriteLine();

            kullanici kullanici = new()
            {
                Adi = "Deniz",
                Soyadi = "Çoban",
                Email = "denizcoban.com",
                Id = 1,
                KullaniciAdi = "deniz",
                sifre = "1234"
            };


            Console.WriteLine("kullanici adınız");
            var kullaniciAdi = Console.ReadLine();
            Console.WriteLine("sifreniz:");
            var sifre = Console.ReadLine();
            if (kullaniciAdi == kullanici.KullaniciAdi && sifre == kullanici.sifre)
            {

                Console.WriteLine("hosgekdin:" + kullanici.Adi + "" + kullanici.Soyadi);
            }
            else Console.WriteLine("giris basarisiz");

        }
        class Ev // sınıf tanimlama
        {
            internal string sokakAdi;
            internal int kapiNo;
        }
    }
}
{
class kullanici
 }

internal string KullaniciAdi;
internal int Id;
internal string sifre;
internal string Soyadi;
internal string Adi;
internal string Email;


Araba araba = new()
{
    Id:""
Marka: ""
    Model: ""
    Renk: ""
};
{
    class Araba
}
internal string Marka;
internal int Id;
internal string Model;
internal string Renk;

{

}