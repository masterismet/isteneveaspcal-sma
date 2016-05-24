using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UyeVeritabani
/// </summary>
public class UyeVeritabani : BaglantiVeritabani
{
    public UyeVeritabani()
    {
        if (_baglanti == null)
            this._baglanti = new Baglanti();
    }


    private IslemSonuc _islemSonuc;

    protected IslemSonuc UyeEkle(Uye uye)
    {
        try
        {
            /*
						
						@ NVARCHAR(5),
						@ NVARCHAR(7),
						@ NVARCHAR(400),
						@Meslek NVARCHAR(200),
						@SehirId INT,
						@Hakkinda NVARCHAR(MAX),
						@UyeTip INT,
						@Cinsiyet INT,
						@WebSite NVARCHAR(250)*/
            _baglanti.SpAdi = "SpUyeEkle";
            _baglanti.ParametreEkle("@Ad", SqlDbType.NVarChar, uye.Ad);
            _baglanti.ParametreEkle("@Soyad", SqlDbType.NVarChar, uye.Soyad);
            _baglanti.ParametreEkle("@EMail", SqlDbType.NVarChar, uye.EMail);
            _baglanti.ParametreEkle("@Sifre", SqlDbType.NVarChar, uye.Sifre);
            _baglanti.ParametreEkle("@TelefonGorunsunMu", SqlDbType.Bit, uye.TelefonGorunsunMu);
            _baglanti.ParametreEkle("@TelefonKod", SqlDbType.NVarChar, uye.TelefonKod);
            _baglanti.ParametreEkle("@TelefonNo", SqlDbType.NVarChar, uye.TelefonNo);
            _baglanti.ParametreEkle("@Adres", SqlDbType.NVarChar, uye.Adres);
            _baglanti.ParametreEkle("@Meslek", SqlDbType.NVarChar, uye.Meslek);
            _baglanti.ParametreEkle("@SehirId", SqlDbType.Int, uye.SehirId);
            _baglanti.ParametreEkle("@Hakkinda", SqlDbType.NVarChar, uye.Hakkinda);
            _baglanti.ParametreEkle("@UyeTip", SqlDbType.Int, uye.UyeTip);
            _baglanti.ParametreEkle("@Cinsiyet", SqlDbType.Int, uye.CinsiyetTip);

            object sonuc = _baglanti.SorguCalistirBirKayit();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "UyeEkle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }

    protected IslemSonuc UyeGiris(string eMail, string sifre)
    {
        try
        {
            _baglanti.SpAdi = "SpUyeGiris";
            _baglanti.ParametreEkle("@EMail", SqlDbType.NVarChar, eMail);
            _baglanti.ParametreEkle("@Sifre", SqlDbType.NVarChar, sifre);

            object sonuc = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "UyeGiris",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc KullaniciProfili(int uyeId)
    {
        try
        {
            _baglanti.Komut = "SELECT TOP 1 UyeId,SehirId,Ad,Soyad,TelefonGorunsunMu,TelefonKod,TelefonNo,Adres,Meslek,Hakkinda,KayitTarih,CinsiyetTip FROM Uye WHERE UyeId = @UyeId";
            _baglanti.ParametreEkle("@UyeId", SqlDbType.Int, uyeId);

            object sonuc = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "KullaniciProfili",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc UyeTemelBilgiler(int uyeId)
    {
        try
        {
            _baglanti.Komut = "SELECT TOP 1 UyeId,Ad + ' ' + Soyad AS AdSoyad FROM Uye WHERE UyeId = @UyeId";
            _baglanti.ParametreEkle("@UyeId", SqlDbType.Int, uyeId);

            object sonuc = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "KullaniciProfili",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }

    protected IslemSonuc UyeFavorilereEkleCikar(int uyeId, int fUyeId)
    {
        try
        {
            _baglanti.SpAdi = "SpFavoriUyeEkleCikar";
            _baglanti.ParametreEkle("@UyeId", System.Data.SqlDbType.Int, uyeId);
            _baglanti.ParametreEkle("@FUyeId", System.Data.SqlDbType.Int, fUyeId);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "UyeFavorilereEkleCikar",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc UyeFavoriMi(int uyeId, int fUyeId)
    {
        try
        {
            _baglanti.SpAdi = "SpFavoriUyeMi";
            _baglanti.ParametreEkle("@UyeId", System.Data.SqlDbType.Int, uyeId);
            _baglanti.ParametreEkle("@FUyeId", System.Data.SqlDbType.Int, fUyeId);

            object sonuc = _baglanti.SorguCalistirBirKayit();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "UyeFavoriMi",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc UyeFavoriUyeler(int uyeId)
    {
        try
        {
            _baglanti.Komut = "SELECT U.UyeId,U.Ad + ' ' + U.Soyad AS AdSoyad FROM FavoriUye F INNER JOIN Uye U ON F.FUyeId = U.UyeId WHERE F.UyeId = @UyeId";
            _baglanti.ParametreEkle("@UyeId", SqlDbType.Int, uyeId);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "UyeFavoriUyeler",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc UyeFavoriIlanlar(int uyeId)
    {
        try
        {
            _baglanti.Komut = "SELECT * FROM FavoriIlan F INNER JOIN Ilan I ON F.IlanId = I.IlanId WHERE F.UyeId = @UyeId";
            _baglanti.ParametreEkle("@UyeId", SqlDbType.Int, uyeId);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "UyeFavoriIlanlar",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc UyeSifreGetir(string ePosta)
    {
        try
        {
            _baglanti.SpAdi = "SpUyeSifreGetir";
            _baglanti.ParametreEkle("@EPosta", SqlDbType.NVarChar, ePosta);

            object sonuc = _baglanti.SorguCalistirBirKayit();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "UyeSifreGetir",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc UyeDuzenle(Uye uye)
    {
        try
        {
            _baglanti.SpAdi = "SpUyeDuzenle";
            _baglanti.ParametreEkle("@UyeId", SqlDbType.Int, uye.UyeId);
            _baglanti.ParametreEkle("@Ad", SqlDbType.NVarChar, uye.Ad);
            _baglanti.ParametreEkle("@Soyad", SqlDbType.NVarChar, uye.Soyad);
            _baglanti.ParametreEkle("@TelefonKod", SqlDbType.NVarChar, uye.TelefonKod);
            _baglanti.ParametreEkle("@TelefonNo", SqlDbType.NVarChar, uye.TelefonNo);
            _baglanti.ParametreEkle("@TelefonGorunsunMu", SqlDbType.Bit, uye.TelefonGorunsunMu);
            _baglanti.ParametreEkle("@Meslek", SqlDbType.NVarChar, uye.Meslek);
            _baglanti.ParametreEkle("@SehirId", SqlDbType.Int, uye.SehirId);
            _baglanti.ParametreEkle("@Adres", SqlDbType.NVarChar, uye.Adres);
            _baglanti.ParametreEkle("@Hakkinda", SqlDbType.NVarChar, uye.Hakkinda);
            _baglanti.ParametreEkle("@CinsiyetTip", SqlDbType.Int, uye.CinsiyetTip);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "UyeVeritabani",
                Method = "UyeDuzenle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }

}