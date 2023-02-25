// See https://aka.ms/new-console-template for more information
Console.WriteLine("Metodlar");
void ToplamaYap()// voit metodlar geriye depğer dondurmez, sadece gorevini yapar.
{
    Console.WriteLine(10+8);
}
ToplamaYap();
void ToplamaYapParametreli(int sayi1, int sayi2);
{
    Console.WriteLine(" Toplama Sonucu:");
    Console.WriteLine(sayi1+sayi2);

}
ToplamaYapParametreli(18, 34);

ToplamaYapParametreli(sayi2: 18, sayi1: 25);// metodlar dışadan parametre gonderelirse de kullanılabilir
int ToplamaParametreli(int sayi1, int sayi2);// metod isminin önünne void yerine herhangi bir veri tipi belirterek geriye bu tipte değer döndürecek metod oluşturabilirz
{
    // eğer bir metod geriye dödürüyorsa metod içerisinde return ifadesiyle bir değer döndürmeliyiz
    return sayi1 + sayi2;//
}
    Console.WriteLine(" Değer Döndüren Toplama Sonucu: ");
int islemSonucu = ToplamaParametreli(18, 9);// toplama işleminin sonucunu bize getiren metodun getirdiği toplam değeri islemsonucu adlı değişkene aktardık
    Console.WriteLine("islemSonucu:");

bool MailGonder(string email)
{
    // burası örnek mail gönderim 
    // kod alanı
    if (email!="")// eğer email değişkeni boş değilse
    {
        // mail göderim kodlarını çalıştır
        // ve maili gönder
        return true;// geriye de mail göderildiğini anlayabilmemiz içinbize true değeri döndür
    }
    return false; // if bloğu çalışmamışsa metod burya kadar gelecek ve geriye false değeri dödürecek böylecebiz de mail göderim işlemiinin başarılı olduğunu anlayabileceğiz
}
Console.WriteLine("mail adresinizi giriniz:");
var mail = Console.ReadLine();
var sonuc = MailGonder(mail);
if (sonuc == true)
{

    Console.WriteLine(" mailiniz başarıyla gönderildi");
}
else
    Console.WriteLine("mailiniz gonderilemedi");
// ekrandan kullanıcı adi ve şifre bilgisi girilsin--k. adi: admin , şifre: 123456
//bu verileri bir metod içerisinde kontrol edelim 
// eğeer bu girilen veriler istediğimiz değerlerse geriye true dösün ve ekrana hoşgeldin kullanıcı adı yazsın
Console.WriteLine("kullanıcı adını giriniz:");
var kullaniciAdi = Console.ReadLine();
Console.WriteLine("sifrenizi giriniz:");
var sifre= Console.ReadLine();
bool LoginKontrol(string kullanici,string sifre)
{
    if (kullanici=="admin"&&sifre=="123456")
    {
        return true;
    }
    return false;
}
var girisSonuc = LoginKontrol(kullaniciAdi,sifre);
// if(girisSonuc==true)// if kontrolunu bu sekide acık olarak kullanabilirz

//if(LoginKontrol(kullaniciAdi,sifre))// if in içinde direkt metodu çagirabiriz
if (girisSonuc)// girisSonuc dğişkeni zaten true veya false olacagi icin bu sekilde kontrol edebiriz
    Console.WriteLine("hosgeldin:" + kullaniciAdi);
else
    Console.WriteLine("giris basarisiz");





