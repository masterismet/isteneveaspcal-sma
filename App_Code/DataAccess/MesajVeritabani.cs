using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for MesajVeritabani
/// </summary>
public class MesajVeritabani : BaglantiVeritabani
{
    private IslemSonuc _islemSonuc;

	public MesajVeritabani()
	{
        if (_baglanti == null)
            this._baglanti = new Baglanti();
	}

    protected IslemSonuc MesajGonder(int gonderenUyeId, int alanUyeId, string mesaj, string baslik, int ilanId)
    {
        try
        {
            _baglanti.Komut = "INSERT INTO Mesaj(GonderenUyeId,AlanUyeId,Mesaj,IlanId,Baslik,Tarih) VALUES(@GonderenUyeId,@AlanUyeId,@Mesaj,@IlanId,@Baslik,@Tarih)";
            _baglanti.ParametreEkle("@GonderenUyeId", SqlDbType.Int, gonderenUyeId);
            _baglanti.ParametreEkle("@AlanUyeId", SqlDbType.Int, alanUyeId);
            _baglanti.ParametreEkle("@Mesaj", SqlDbType.NVarChar, mesaj);
            _baglanti.ParametreEkle("@IlanId", SqlDbType.Int, ilanId);
            _baglanti.ParametreEkle("@Baslik", SqlDbType.NVarChar, baslik);
            _baglanti.ParametreEkle("@Tarih", SqlDbType.DateTime, DateTime.Now);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "MesajVeritabani",
                Method = "MesajGonder",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc MesajGonderilecekUyeGetirIlanId(int ilanId)
    {
        try
        {
            _baglanti.Komut = "SELECT U.UyeId,U.Ad,U.Soyad FROM Ilan I INNER JOIN Uye U ON I.UyeId = U.UyeId WHERE I.IlanId = @IlanId";
            _baglanti.ParametreEkle("@IlanId", System.Data.SqlDbType.Int, ilanId);

            System.Data.DataTable tabloIlan = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tabloIlan);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "MesajVeritabani",
                Method = "MesajGonderilecekUyeGetir",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc MesajGonderilecekUyeGetirUyeId(int uyeId)
    {
        try
        {
            _baglanti.Komut = "SELECT U.UyeId,U.Ad,U.Soyad FROM Uye U WHERE U.UyeId = @UyeId";
            _baglanti.ParametreEkle("@UyeId", System.Data.SqlDbType.Int, uyeId);

            System.Data.DataTable tabloIlan = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tabloIlan);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "MesajVeritabani",
                Method = "MesajGonderilecekUyeGetir",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc Mesajlar(int uyeId)
    {
        try
        {
            _baglanti.Komut = "SELECT M.Baslik,M.Mesaj,U.UyeId,U.Ad + ' ' + U.Soyad AS AdSoyad, M.Tarih FROM Mesaj M INNER JOIN Uye U ON M.GonderenUyeId = U.UyeId WHERE M.AlanUyeId = @UyeId";
            _baglanti.ParametreEkle("@UyeId", SqlDbType.Int, uyeId);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "MesajVeritabani",
                Method = "Mesajlar",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }



    
}