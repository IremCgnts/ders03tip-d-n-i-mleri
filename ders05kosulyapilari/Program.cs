// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Kosul Yapilari");
int sayi = 10;
Console.WriteLine("lütfen sayı giriniz");
sayi = Convert.ToInt32(Console.ReadLine());// ekrandan veri alabilmek için Readline metodu kullanılır.Readline metodu ekrandan verikeri string olarak  alır, sayısal işlem yapacaksak bunu dönüştürmemiz gerekir.

if (sayi > 0)// eğeer sayi 0 dan buyukse
{
    Console.WriteLine("sayi pozitif");
}
else if (sayi < 0) 
{
    Console.WriteLine("sayi negatif");
}
else 
{
    Console.WriteLine(" sayi 0");
}
Console.WriteLine();
Console.WriteLine("kulalnici adinizi giriniz");
string kullaniciAdi = Console.ReadLine();
Console.WriteLine("sifrenizi giriniz");
string sifre = Console.ReadLine();
if( kullaniciAdi=="Admin"&&sifre=="123")
{
Console.WriteLine("giris basarili");
}
else
{
    Console.WriteLine("giris basarisiz");
}
int saat = DateTime.Now.Hour;// datetime ile tarih ve saat bilgilerine ulaşırız
if (saat > 19)
    Console.WriteLine("iyi aksamlar");
else
    Console.WriteLine("Saat:"+ saat + "iyi günler");
Console.WriteLine();
Console.WriteLine("ternary operatoru");
Console.WriteLine((saat>19)?"Saat:"+ saat +"iyi akşamlar": "Saat:"+ saat+ "iyi günler");
Console.WriteLine();
Console.WriteLine("switch case kullanınız");
int ay = DateTime.Now.Month;// bulunduğumuz ay değerine ulaşırız
switch (ay)
{
    case 12:
    case 1:
    case 2:
        Console.WriteLine(" mevsim kıs");
        break;
    case 3:
    case 4:
    case 5:
        Console.WriteLine(" mevsim ilkbahar");
        break;
    case 6:
    case 7:
    case 8:
        Console.WriteLine("mevsim yaz");
        break;
    case 9:
    case 10:
    case 11:
        Console.WriteLine("mevsim sonbahar");
        break;
    default:
        Console.WriteLine("hiçbir şart uymadıysa default calışır");
        break;
}
Console.WriteLine();


