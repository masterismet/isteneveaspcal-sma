using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for KategoriVeritabani
/// </summary>
public class KategoriVeritabani : BaglantiVeritabani
{
    private IslemSonuc _islemSonuc;

	public KategoriVeritabani()
	{
        if (_baglanti == null)
            this._baglanti = new Baglanti();
    }
    protected IslemSonuc KategoriListele(int ustKategoriId)
    {
        try
        {
            _baglanti.Komut = "SELECT * FROM Kategori WHERE UstKategoriId = @UstKategoriId";
            _baglanti.ParametreEkle("@UstKategoriId", System.Data.SqlDbType.Int, ustKategoriId);

            System.Data.DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "KategoriVeritabani",
                Method = "KategoriListele",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc KategoriListele()
    {
        try
        {
            _baglanti.Komut = "SELECT * FROM Kategori";

            System.Data.DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "KategoriVeritabani",
                Method = "KategoriListele (Tamami)",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc KategoriDuzenle(Kategori kategori)
    {
        try
        {
            _baglanti.Komut = "UPDATE Kategori SET KategoriAd=@KategoriAd, UstKategoriId = @UstKategoriId, Sil = @Sil WHERE KategoriId = @KategoriId";
            _baglanti.ParametreEkle("@KategoriAd", SqlDbType.NVarChar, kategori.KategoriAd);
            _baglanti.ParametreEkle("@UstKategoriId", SqlDbType.Int, kategori.UstKategoriId);
            _baglanti.ParametreEkle("@Sil", SqlDbType.Bit, kategori.Sil);
            _baglanti.ParametreEkle("@KategoriId", SqlDbType.Int, kategori.KategoriId);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "KategoriVeritabani",
                Method = "KategoriDuzenle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc KategoriEkle(Kategori kategori)
    {
        try
        {
            _baglanti.Komut = "INSERT INTO Kategori(KategoriAd, UstKategoriId, Sil) VALUES(@KategoriAd,@UstKategoriId,@Sil)";
            _baglanti.ParametreEkle("@KategoriAd", SqlDbType.NVarChar, kategori.KategoriAd);
            _baglanti.ParametreEkle("@UstKategoriId", SqlDbType.Int, kategori.UstKategoriId);
            _baglanti.ParametreEkle("@Sil", SqlDbType.Bit, kategori.Sil);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "KategoriVeritabani",
                Method = "KategoriEkle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
}