// See https://aka.ms/new-console-template for more information
Console.WriteLine("Operetstorler");
Console.WriteLine("1-Aritmatik Operetstorler");
int a = 50;
int b = 30;
int c = 20;

int toplama = a + b;
Console.WriteLine("a+b :" + toplama);
int cikarma = a - b;
Console.WriteLine("a-b :" + cikarma);
int carpma = b * c;
Console.WriteLine("b*c :" + carpma);
int bolme = b / c;
Console.WriteLine("b/c :" + bolme);
int kalan =b%c;
Console.WriteLine("b%c:" + kalan);
b++;// b nin değerini 1 arttır
Console.WriteLine("b++:"+b);
Console.WriteLine();// boş satır ekle

Console.WriteLine("2-Atama Operatorleri:");
Console.WriteLine(" a nin değeri:"+ a);
Console.WriteLine("b nin değeri:" + b);
Console.WriteLine("c nin değeri:" + c);
Console.WriteLine("a+=b:" + (a += b));// a nın edğerini b kadar arttır
Console.WriteLine("a=a+b:" +(a=a+b));// bu işlem ile a+= b işlemi aynı işlevi görür
Console.WriteLine("a-=b: " + (a -= b));
Console.WriteLine("a*=b:" + (a *= b));
Console.WriteLine("a/=b:" + (a /= b));
Console.WriteLine($"a({a})==b({b}):" + (a == b));// a b ye eşit mmi
Console.WriteLine($"a({a})!=b({b}):" + (a != b));// a b ye eşit değil mi
Console.WriteLine($"a({a})<b({b}):" + (a < b));// a b den küçük mü
Console.WriteLine($"a({a})<=b({b}):" + (a <= b)); //a b den küçük mü veya eşit mi
Console.WriteLine("ternary operatoru a==b:" +((a==b)?"a b ye eşit":" a b ye eşit değil"));// 2 olasılıklı durumlareda klulananbileceğimiz ternary operatoru
Console.WriteLine("4- Mantiksal Operatorleri :");
Console.WriteLine($"a-{a}, b-{b},c-{c} ((a>b)|| (b>c)):" + ((a > b) || (b > c)));// || - veya operatoru iki şartın birini doğru olmasını bekler
Console.WriteLine($"a-{a}, b-{b} (a>b):" + (a>b));
Console.WriteLine($"a-{a}, b-{b} (a>b):" + !(a > b));// ! işareti ile bir işlem sonucunun tam tersini ifade ederiz



