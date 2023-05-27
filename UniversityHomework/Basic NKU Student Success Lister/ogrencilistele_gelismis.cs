using System;
using System.Collections.Generic;
using System.Linq;

class Ogrenci
{
    public string Numara { get; set; }
    public string Ad { get; set; }
    public int AraSinav { get; set; }
    public int Final { get; set; }
    public int Devamsizlik { get; set; }
    public int Ortalama { get; set; }
    public string Durum { get; set; }
}

class Program
{
    static List<Ogrenci> ogrenciler = new List<Ogrenci>();

    static void Main()
    {
        while (true)
        {
            MenuGoster();
            int secim = int.Parse(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    KayitGirisi();
                    break;
                case 2:
                    try
                    {
                        Listele(); // hata fırlatması engellendi ama listele fonksiyonu içine bir şeyler yazmak try catych den iyi olabilir

                    }
                    catch
                    {
                        Console.WriteLine("GÖSTERİLECEK ÖĞRENCİ EKLEMEDEN LİSTELEME YAPAMAZSINIZ!");
                    }
                    break;
                case 3:
                    Console.WriteLine("Programdan çıkılıyor.");
                    return;
                default:
                    Console.WriteLine("Lütfen geçerli bir seçim yapınız.");
                    break;
            }
        }
    }

    static void MenuGoster()
    {
        Console.WriteLine("1- Kayıt Girişi");
        Console.WriteLine("2- Kayıtları Listele");
        Console.WriteLine("3- Çıkış");
        Console.Write("Seçiminizi yapınız: ");
    }

    static void KayitGirisi()
    {
        Console.Write("Öğrenci numarasını giriniz: ");
        string numara = Console.ReadLine();
        Console.Write("Öğrenci adını giriniz: ");
        string ad = Console.ReadLine();
        Console.Write("Ara sınav notunu giriniz: ");
        int araSinav = int.Parse(Console.ReadLine());
        Console.Write("Final notunu giriniz: ");
        int final = int.Parse(Console.ReadLine());
        Console.Write("Devamsızlık sayısını giriniz: ");
        int devamsizlik = int.Parse(Console.ReadLine());

        int ortalama = (int)Math.Round(araSinav * 0.4 + final * 0.6);
        string durum = ortalama >= 50 && devamsizlik < 5 && final >= 50 ? "BAŞARILI" : "BAŞARISIZ";

        ogrenciler.Add(new Ogrenci
        {
            Numara = numara,
            Ad = ad,
            AraSinav = araSinav,
            Final = final,
            Devamsizlik = devamsizlik,
            Ortalama = ortalama,
            Durum = durum
        });
    }

    static void Listele()
    {
        int basariliSayisi = ogrenciler.Count(o => o.Durum == "BAŞARILI");
        int basarisizSayisi = ogrenciler.Count(o => o.Durum == "BAŞARISIZ");
        int sinifOrtalamasi = (int)Math.Round(ogrenciler.Average(o => o.Ortalama));
        Ogrenci enBasariliOgrenci = ogrenciler.OrderByDescending(o => o.Ortalama).First();

        Console.WriteLine($"Sınıf Ortalaması: {sinifOrtalamasi}");
        Console.WriteLine($"Başarılı Öğrenci Sayısı: {basariliSayisi}");
        Console.WriteLine($"Başarısız Öğrenci Sayısı: {basarisizSayisi}");
        Console.WriteLine($"En Başarılı Öğrenci - Numara: {enBasariliOgrenci.Numara}, Ad: {enBasariliOgrenci.Ad}");

        Console.WriteLine("\nÖğrenci Listesi:");
        foreach (var ogrenci in ogrenciler)
        {
            Console.WriteLine($"Numara: {ogrenci.Numara}, Ad: {ogrenci.Ad}, Ara Sınav: {ogrenci.AraSinav}," +
                $" Final: {ogrenci.Final}, Devamsızlık: {ogrenci.Devamsizlik}, Ortalama: {ogrenci.Ortalama}, Durum: {ogrenci.Durum}");



        }
        Console.WriteLine(EnBasariliIkiOgrenci()); // baya çirkin duruyor bunları formatlamalıyım
        Console.WriteLine(SinifOrtalamasi());
        Console.WriteLine(BasarisizOgrenciSayisi());
        Console.WriteLine(BasariliOgrenciSayisi());

    }
    static string EnBasariliIkiOgrenci()
    {
        var enBasariliIkiOgrenci = ogrenciler.OrderByDescending(o => o.Ortalama).Take(2).Select(o => o.Ad).ToList();
        return $"En Başarılı İki Öğrenci: {enBasariliIkiOgrenci[0]} ve {enBasariliIkiOgrenci[1]}"; // daha fazlası da yazılabilir sıralama gibi for ile
    }

    static string SinifOrtalamasi()
    {
        int sinifOrtalamasi = (int)Math.Round(ogrenciler.Average(o => o.Ortalama));
        return $"Sınıf Ortalaması: {sinifOrtalamasi}";
    }

    static string BasariliOgrenciSayisi()
    {
        int basariliSayisi = ogrenciler.Count(o => o.Durum == "BAŞARILI");
        return $"Başarılı Öğrenci Sayısı: {basariliSayisi}";
    }

    static string BasarisizOgrenciSayisi()
    {
        int basarisizSayisi = ogrenciler.Count(o => o.Durum == "BAŞARISIZ");
        return $"Başarısız Öğrenci Sayısı: {basarisizSayisi}";
    }

}


