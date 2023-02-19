// See https://aka.ms/new-console-template for more information
using Microsoft.Win32.SafeHandles;

Console.WriteLine("Tip Dönüşümleri");
//float<long<int<byte
int sayi = 9;
double kesirliSayi = sayi;
Console.WriteLine("Sayi:" +sayi);
Console.WriteLine("kesirli Sayi:" + kesirliSayi);
Console.WriteLine("Explicit Casting");
double kesirliSayi2 = 258;
int TamSayi = (int)kesirliSayi2;
//kesirlisayiyi int e cast etme- dönüştürme
byte plaka = (byte)kesirliSayi2;
Console.WriteLine("tamSayi :" + plaka);
int tamSayi2 = 18;
double kesirliSayi3 = 5.25;
decimal ürünFiyati = 9999;
Console.WriteLine("Diğer Tip Dönüştürme Metodlari");
Console.WriteLine(Convert.ToByte(tamSayi2));
Console.WriteLine(Convert.ToInt32(kesirliSayi3));





