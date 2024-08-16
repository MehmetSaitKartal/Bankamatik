using System;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;

int bakiye = 2500;
string sifre = "ab18";
string Kadı = "admin";

Menü:

Console.WriteLine("Bankamatiğe Hoş Geldiniz");

while (true)
{
    Console.WriteLine("Nasıl Bir İşlem İle Devam Etmek İstersiniz?");
    Console.Write("Kartlı İşlem İçin 1'e Tıklayınız");
    Console.Write("        Kartsız İşlem İçin 2'ye Tıklayınız");
    string secim = Console.ReadLine();

    if (secim == "1") 
    { 
        goto Kartlıİşlem;
            
    }
    else if (secim == "2")
    {
        goto Kartsızİşlem;

    }
    else
    {
        Console.WriteLine("Hatalı İşlem,Lütfen Tekrar Deneyiniz");
    }
}
Kartlıİşlem:
int hak = 3;
while (hak > 0)
{
    Console.WriteLine("Lütfen Kullanıcı Adınızı Giriniz:");
    string girilenKadı = Console.ReadLine(); 
    if (girilenKadı == Kadı)
    {
        Console.WriteLine("Lütfen Şifrenizi Giriniz");
        string girilensifre = Console.ReadLine();
        if (girilensifre == sifre)
        {
            goto KartMenü;
        }
        else
        {
            hak--;
            Console.WriteLine($"Yanlış Şifre, {hak} Hakkınız Kaldı");
        }
    }
    else
    {
     hak--;
        Console.WriteLine($"Yanlış Kullanıcı Adı, {hak} Hakkınız Kaldı");
    }
}
Console.WriteLine("Deneme Hakkınız Kalmadı,Sistemden Atıldınız");
return;
KartMenü:
while (true)
{
    Console.WriteLine("İşlem Menüsü:");
    Console.WriteLine("1 - Para Çekme");
    Console.WriteLine("2 - Para Yatırma");
    Console.WriteLine("3 - Para Transferleri");
    Console.WriteLine("4 - Eğitim Ödemeleri");
    Console.WriteLine("5 - Ödemeler");
    Console.WriteLine("6 - Bilgi Güncelleme");
    Console.WriteLine("9 - Menü'ye Dön");
    Console.WriteLine("0 - Çıkış");
    

    string secim = Console.ReadLine();

    switch (secim)
    {
        case "1":
        goto ParaCekme;
            
        case "2":
        goto ParaYatirma;
            
        case "3":
        goto ParaTransferi;
            
        case "4":
        Console.WriteLine("Eğitim Ödemeleri Arızalı");
             break;
        case "5":
        goto KartÖdemeler;
            
        case "6":
        goto BilgiGuncelleme;

        case "9":
        goto Menü;
            
        case "0":
            return;
    }
    if (secim !="1" && secim !="2" && secim !="3" && secim !="4" && secim !="5" && secim !="6" && secim !="0")
    {
        Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
        goto Menü;
    }
}
ParaCekme:
Console.WriteLine("Çekmek İstediğiniz Miktarı Girin:");
int Cmiktar = Convert.ToInt32(Console.ReadLine());

if (Cmiktar <= bakiye)
{
    bakiye-=Cmiktar;
    Console.WriteLine($"Çekilen Tutar:{Cmiktar}TL,    Yeni Bakiye{bakiye} TL");
}
else
{
    Console.WriteLine("Yetersiz Bakiye");
}
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim2 = Convert.ToInt32(Console.ReadLine());
if (secim2 == 9)
{
    goto Menü;
}
else if (secim2 == 0)
{
    return;
}
else
{
    Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
    goto ParaCekme;
}

ParaYatirma:

Console.WriteLine("Yatırmak İstediğiniz Miktarı Girin");

int Ymiktar = Convert.ToInt32(Console.ReadLine());

bakiye += Ymiktar;
Console.WriteLine($"Yatırılan Miktar:{Ymiktar}TL.    Yeni Bakiye{bakiye}TL ");

Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim3 = Convert.ToInt32(Console.ReadLine());
if (secim3 == 9)
{
    goto Menü;
}
else if (secim3 == 0)
{
    return;
}
else
{
    Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
    goto ParaYatirma;
}

ParaTransferi:
Console.WriteLine("Başka Hesaba EFT İçin 1'e Tıklayınız");
Console.WriteLine("Başka Hesaba Havale İçin 2'ye Tıklayınız");

string secim4 = Console.ReadLine();

switch (secim4)
{
    case "1":
    goto EFT;
        
    case "2":
    goto Havale;
        
    if (secim4 != "1" && secim4 != "2")
        {
            Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
            goto ParaTransferi;
        }
}
EFT:
Console.WriteLine("EFT Numarasını Giriniz(Başta 'TR' Sonrasında 12 Sayı Olmalı)");
string eft = Console.ReadLine();

if (eft.StartsWith("TR") && eft.Length == 14) 
{
    Console.WriteLine("Transfer Etmek İstediğiniz Miktarı Girin:");
    int eftmiktar= Convert.ToInt32(Console.ReadLine());

    if (eftmiktar <= bakiye)
    {
        bakiye-=eftmiktar;
        Console.WriteLine($"İşlem Başarılı    Gönderilen Tutar{eftmiktar}    Yeni Bakiye{bakiye}");
    }
    else 
    {
        Console.WriteLine("Yetersiz Bakiye,Lütfen Tekrar Deneyiniz");
        goto EFT;
    }
}
else
{
    Console.WriteLine("Geçersiz EFT Numarası,Lütfen Tekrar Deneyiniz");
    goto EFT;
}
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim5 = Convert.ToInt32(Console.ReadLine());
if (secim5 == 9)
{
    goto Menü;
}
else if (secim5 == 0)
{
    return;
}
else
{
    Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
    goto ParaTransferi;
}


Havale:
Console.WriteLine("Havale Yapacağınız Hesabın Numarasını Giriniz (11 Haneli Olmalıdır)");
string havale = Console.ReadLine();

if (havale.Length == 11)
{
    Console.WriteLine("Transfer Etmek İstediğiniz Miktarı Girin:");
    int havalemiktar= Convert.ToInt32(Console.ReadLine());

    if (havalemiktar <= bakiye)
    {
        bakiye-=havalemiktar;
        Console.WriteLine($"İşlem Başarılı    Gönderilen Miktar{havalemiktar}TL    Yeni Bakiye{bakiye}TL");
    }
    else
    {
        Console.WriteLine("Yetersiz Bakiye,Lütfen Tekrar Deneyiniz");
        goto Havale;
    }
}
else
{
    Console.WriteLine("Geçersiz Havale Numarası,Lütfen Tekrar Deneyiniz");
    goto Havale;
}
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim6 = Convert.ToInt32(Console.ReadLine());
if (secim6 == 9)
{
    goto Menü;
}
else if (secim6 == 0)
{
    return;
}
else
{
    Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
    goto ParaTransferi;
}

KartÖdemeler:
Console.WriteLine("1 - Elektrik Faturası");
Console.WriteLine("2 - Telefon Faturası");
Console.WriteLine("3 - İnternet Faturası");
Console.WriteLine("4 - Su Faturası");
Console.WriteLine("5 - OGS Ödemeleri");

string secim7 = Console.ReadLine();

Console.WriteLine("Fatura Tutarını Giriniz:");
int faturaturar = Convert.ToInt32(Console.ReadLine());

if (faturaturar <= bakiye)
{
    bakiye-=faturaturar;
    Console.WriteLine($"Faturanız Başarıyla Ödenmiştir    Ödenen Tutar{faturaturar}TL    Yeni Bakiye{bakiye}TL");
}
else
{
    Console.WriteLine("Yetersiz Bakiye,Lütfen Tekrar Deneyiniz");
}
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim8 = Convert.ToInt32(Console.ReadLine());
if (secim8 == 9)
{
    goto Menü;
}
else if (secim8 == 0)
{
    return;
}
else
{
    Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
    goto ParaYatirma;
}
BilgiGuncelleme:
Console.WriteLine("1 - Kullanıcı Adı Güncelleme");
Console.WriteLine("2 - Şifre Güncelleme");

int secim9 = Convert.ToInt32(Console.ReadLine());
if (secim9 == 1)
{
    Console.WriteLine("Lütfen Onaylamak İçin Eski Kullanıcı Adınızı Giriniz");
    string YKadı =Console.ReadLine();
    if (YKadı == Kadı)
    {
        Console.WriteLine("İşlem Onaylandı,Yeni Kullanıcı Adınızı Giriniz");
        Kadı = Console.ReadLine();
        Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
        int secim22 = Convert.ToInt32(Console.ReadLine());
        if (secim22 == 9)
        {
            goto Menü;
        }
        else if (secim22 == 0)
        {
            return;
        }
        else
        {
            Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
            goto BilgiGuncelleme;
        }
    }
    else
    {
        Console.WriteLine("Hatalı Bilgi Girdiniz,Lütfen Tekrar Deneyin");
        goto BilgiGuncelleme;
    }
}
else if ( secim9 == 2)
{
    Console.WriteLine("Lütfen Onaylamak İçin Eski Şifrenizi Giriniz");
    string Ysifre = Console.ReadLine();
    if (Ysifre == sifre)
    {
        Console.WriteLine("İşlem Onaylandı,Yeni Şifrenizi Giriniz");
        sifre = Console.ReadLine();
        Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
        int secim10 = Convert.ToInt32(Console.ReadLine());
        if (secim10 == 9)
        {
            goto Menü;
        }
        else if (secim10 == 0)
        {
            return;
        }
        else
        {
            Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
            goto BilgiGuncelleme;
        }
    }
    else
    {
        Console.WriteLine("Hatalı Bilgi Girdiniz,Lütfen Tekrar Deneyin");
        goto BilgiGuncelleme;
    }
}

Kartsızİşlem:;
Console.WriteLine("1 - CepBank Para Çekimi için");
Console.WriteLine("2 - Para Yatırmak İçin");
Console.WriteLine("3 - Kredi Kartı Ödemesi İçin");
Console.WriteLine("4 - Eğitim Ödemeleri İçin");
Console.WriteLine("5 - Ödemeler İçin");

string secim11 = Console.ReadLine();

switch (secim11)
{
    case "1":
        goto CepBank;
    case "2":
        goto KartsızParaYatırma;
    case "3":
        goto KrediKartıÖdemesi;
    case "4":
        goto EğitimÖdemeleri;
    case "5":
        goto NakitÖdemeler;
}
CepBank:
int hak2 = 3;
while (hak2 > 0)
{
    Console.WriteLine("Lütfen TC Kimlik Numaranızı Giriniz(11 Hane)");
    string TCno = Console.ReadLine();

    if (TCno.Length == 11)
    {
    Telno:
        Console.WriteLine("Lütfen Telefon Numaranızı Giriniz(10 Hane)");
        string Telno = Console.ReadLine();

        if (Telno.Length == 10)
        {
            bakiye += 1000;
            Console.WriteLine($"İşlem Onaylandı Bakiyenize 1000 TL Eklenmiştir Yeni Bakiye {bakiye}TL");
            goto Secim;
        }
        else
        {
            hak2--;
            Console.WriteLine($"Telefon Numaranızı Hatalı Girdiniz {hak2} Hakkınız Kalmıştır,Lütfen Tekrar Deneyiniz");
            goto Telno;
        }
    }
    else
    {
        hak2--;
        Console.WriteLine($"TC Kimlik Numaranızı Hatalı Girdiniz {hak2} Hakkınız Kalmıştır,Lütfen Tekrar Deneyiniz");
    }
}
if (hak2 == 0)
{
    Console.WriteLine("Hakkınız Kalmadı Sistem 1 Saat Kendini Kilitleyecek");
    Thread.Sleep(360000);
    Console.WriteLine("Program Kilidi Açıldı,Tekrar Deneyin");
    goto CepBank;
}
Secim:
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim12 = Convert.ToInt32(Console.ReadLine());
if (secim12 == 9)
{
goto Menü;
}
else if (secim12 == 0)
{
return;
}
else
{
Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
goto CepBank;
}
KartsızParaYatırma:
Console.WriteLine("1 - Nakit Ödeme");
Console.WriteLine("2 - Hesaptan Ödeme");
Console.WriteLine("9 - Ana Menü");
Console.WriteLine("0 - Çıkış");

string secim13 = Console.ReadLine();

switch (secim13)
{
    case "1":
        goto NakitÖdeme;
    case "2":
        goto HesaptanÖdeme;
    case "9":
        goto Menü;
    case "0":
        return;
}
NakitÖdeme:
Console.WriteLine("Lütfen Kredi Kartı Numaranızı Giriniz(12 Hane)");
string kredino = Console.ReadLine();

if (kredino.Length == 12)
{
TCno:
    Console.WriteLine("Lütfen TC Kimlik Numaranızı Giriniz(11 Hane)");
    string TCno = Console.ReadLine();
    if (TCno.Length == 11)
    {
        Console.WriteLine("Kaç TL Yatırmak İstersiniz?");
        int YNmiktar = Convert.ToInt32(Console.ReadLine());
        bakiye += YNmiktar;
        Console.WriteLine($"İşlem Başarılı    Yatırılan Miktar{YNmiktar}TL    Yeni Bakiye{bakiye}TL");
    }
    else
    {
        Console.WriteLine("Hatalı İşlem,Lütfen Tekrar Deneyiniz");
        goto TCno;
    }
}
else
{
    Console.WriteLine("Hatalı İşlem,Lütfen Tekrar Deneyiniz");
    goto NakitÖdeme;
}
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim14 = Convert.ToInt32(Console.ReadLine());
if (secim14 == 9)
{
    goto Menü;
}
else if (secim14 == 0)
{
    return;
}
else
{
    Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
    goto NakitÖdeme;
}
HesaptanÖdeme:
Console.WriteLine("Lütfen TC Kimlik Numaranızı Giriniz(11 Hane)");
string TCno2 = Console.ReadLine();
if (TCno2.Length == 11)
{
    Console.WriteLine("Kaç TL Yatırmak İstersiniz?");
    int YNmiktar = Convert.ToInt32(Console.ReadLine());
    bakiye += YNmiktar;
    Console.WriteLine($"İşlem Başarılı    Yatırılan Miktar{YNmiktar}TL    Yeni Bakiye{bakiye}TL");
}
else
{
    Console.WriteLine("Hatalı İşlem,Lütfen Tekrar Deneyiniz");
    goto HesaptanÖdeme;
}
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim15 = Convert.ToInt32(Console.ReadLine());
if (secim15 == 9)
{
    goto Menü;
}
else if (secim15 == 0)
{
    return;
}
else
{
    Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
    goto HesaptanÖdeme;
}
KrediKartıÖdemesi:
Console.WriteLine("1 - Başka Hesaba EFT");
Console.WriteLine("2 - Başka Hesaba Havale");

string secim16 = Console.ReadLine();

switch (secim16)
{
case "1":
goto EFT2;

case "2":
goto Havale2;

if (secim16 != "1" && secim16 != "2")
{
Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
goto ParaTransferi;
}
}
EFT2:
Console.WriteLine("EFT Numarasını Giriniz(Başta 'TR' Sonrasında 12 Sayı Olmalı)");
string eft2 = Console.ReadLine();

if (eft2.StartsWith("TR") && eft2.Length == 14)
{
Console.WriteLine("Transfer Etmek İstediğiniz Miktarı Girin:");
int eftmiktar = Convert.ToInt32(Console.ReadLine());

if (eftmiktar <= bakiye)
{
bakiye -= eftmiktar;
Console.WriteLine($"İşlem Başarılı    Gönderilen Tutar{eftmiktar}    Yeni Bakiye{bakiye}");
}
else
{
Console.WriteLine("Yetersiz Bakiye,Lütfen Tekrar Deneyiniz");
goto EFT;
}
}
else
{
Console.WriteLine("Geçersiz EFT Numarası,Lütfen Tekrar Deneyiniz");
goto EFT;
}
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim17 = Convert.ToInt32(Console.ReadLine());
if (secim17 == 9)
{
goto Menü;
}
else if (secim17 == 0)
{
return;
}
else
{
Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
goto KrediKartıÖdemesi;
}


Havale2:
Console.WriteLine("Havale Yapacağınız Hesabın Numarasını Giriniz (11 Haneli Olmalıdır)");
string havale2 = Console.ReadLine();

if (havale2.Length == 11)
{
Console.WriteLine("Transfer Etmek İstediğiniz Miktarı Girin:");
int havalemiktar = Convert.ToInt32(Console.ReadLine());

if (havalemiktar <= bakiye)
{
bakiye -= havalemiktar;
Console.WriteLine($"İşlem Başarılı    Gönderilen Miktar{havalemiktar}TL    Yeni Bakiye{bakiye}TL");
}
else
{
Console.WriteLine("Yetersiz Bakiye,Lütfen Tekrar Deneyiniz");
goto Havale;
}
}
else
{
Console.WriteLine("Geçersiz Havale Numarası,Lütfen Tekrar Deneyiniz");
goto Havale;
}
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim18 = Convert.ToInt32(Console.ReadLine());
if (secim18 == 9)
{
goto Menü;
}
else if (secim18 == 0)
{
return;
}
else
{
Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
goto KrediKartıÖdemesi;
}

EğitimÖdemeleri:
Console.WriteLine("Eğitim Ödemeleri Sayfası Arızalı");
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim19 = Convert.ToInt32(Console.ReadLine());
if (secim19 == 9)
{
goto Menü;
}
else if (secim19 == 0)
{
return;
}
else
{
Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
goto Kartsızİşlem;
}

NakitÖdemeler:
Console.WriteLine("1 - Elektrik Faturası");
Console.WriteLine("2 - Telefon Faturası");
Console.WriteLine("3 - İnternet Faturası");
Console.WriteLine("4 - Su Faturası");
Console.WriteLine("5 - OGS Ödemeleri");

string secim20 = Console.ReadLine();

Console.WriteLine("Fatura Tutarını Giriniz:");
int faturaturar2 = Convert.ToInt32(Console.ReadLine());

if (faturaturar2 <= bakiye)
{
    bakiye -= faturaturar2;
    Console.WriteLine($"Faturanız Başarıyla Ödenmiştir    Ödenen Tutar{faturaturar2}TL    Yeni Bakiye{bakiye}TL");
}
else
{
    Console.WriteLine("Yetersiz Bakiye,Lütfen Tekrar Deneyiniz");
}
Console.WriteLine("Menüye Dönmek İçin 9'a Sistemtden Çıkmak İçin 0'a Tıklayınız ");
int secim21 = Convert.ToInt32(Console.ReadLine());
if (secim21 == 9)
{
    goto Menü;
}
else if (secim21 == 0)
{
    return;
}
else
{
    Console.WriteLine("Geçersiz İşlem,Lütfen Tekrar Deneyiniz");
    goto NakitÖdemeler;
}
