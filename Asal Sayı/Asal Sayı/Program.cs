using System;
using System.Collections.Generic; // List için gerekli ad alanı

class AsalSayiToplami
{
    static void Main(string[] args)
    {
        // Kullanıcıdan N sayısını alma
        Console.Write("N sayısını girin: ");
        int n = int.Parse(Console.ReadLine());

        // Asal sayıların toplamını tutacak değişken
        int toplam = 0;

        // Asal sayıları tutacak liste
        List<int> asalSayilar = new List<int>();

        // 2'den N'ye kadar olan sayıları kontrol et
        for (int i = 2; i <= n; i++)
        {
            if (AsalMi(i))
            {
                asalSayilar.Add(i); // Asal sayıyı listeye ekle
                toplam += i; // Asal sayıyı toplamda ekle
            }
        }

        // Asal sayıları ekrana yazdırma
        Console.WriteLine($"\n0'dan {n}'ye kadar olan asal sayılar: {string.Join(", ", asalSayilar)}");

        // Sonucu ekrana yazdırma
        Console.WriteLine($"\n0'dan {n}'ye kadar olan asal sayıların toplamı: {toplam}");

        // Konsolun açık kalması için
        Console.WriteLine("\nÇıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

    // Bir sayının asal olup olmadığını kontrol eden fonksiyon
    static bool AsalMi(int sayi)
    {
        if (sayi < 2) return false; // 2'den küçük sayılar asal değildir
        for (int i = 2; i <= Math.Sqrt(sayi); i++)
        {
            if (sayi % i == 0) return false; // Eğer sayı i'ye tam bölünüyorsa asal değildir
        }
        return true; // Asal
    }
}
