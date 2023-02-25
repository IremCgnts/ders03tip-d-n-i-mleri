// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("donguler");
Console.WriteLine("For Dongusu");
int veritabanindangelenurunsayisi = 5;
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("i nin değeri:" + i);

}

Console.WriteLine("While Döngüsü");
int j = 0;
while(j < 5)
{
    Console.WriteLine("j nin değeri :"+j);
    j++;// değişkenin edğerini  bir arttırıyoruz ki sonsuz donguye girmesin.

}

Console.WriteLine(" Do While Döngüsü");
int toplam = 10;
    do
    {
    Console.WriteLine("toplamin değeri :"+ toplam);
toplam++;
} while (toplam < 10) ;
Console.WriteLine("Foreach Döngüsü");
string[] kategoriler = { "Elektronik", "Bilgisayar", "Telefon" };
foreach ( var kategori in kategoriler)// diziler için en kulllanısilı döngü
{
    Console.WriteLine("Kategori adi:"+ kategori);
}
string[] ürünler = { "ürün 1", "ürün 2", "ürün 3" };
Console.WriteLine("Kategori adi:" + kategori);
foreach (var urun in ürünler) 
{
    Console.WriteLine("\tÜrün adi:" + urun);
}