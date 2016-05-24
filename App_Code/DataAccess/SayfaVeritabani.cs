using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SayfaVeritabani
/// </summary>
public class SayfaVeritabani : BaglantiVeritabani
{
    private IslemSonuc _islemSonuc;

	public SayfaVeritabani()
	{
        if (_baglanti == null)
            this._baglanti = new Baglanti();

	}
    protected IslemSonuc SayfaDuzenle(Sayfa sayfa)
    {
        try
        {
            _baglanti.Komut = "UPDATE Sayfa SET Icerik=@Icerik WHERE SayfaId = @SayfaId";
            _baglanti.ParametreEkle("@Icerik", SqlDbType.NVarChar, sayfa.Icerik);
            _baglanti.ParametreEkle("@SayfaId", SqlDbType.Int, sayfa.SayfaId);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "SayfaVeritabani",
                Method = "SayfaDuzenle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc SayfaGetir(int sayfaId)
    {
        try
        {
            _baglanti.Komut = "SELECT * FROM Sayfa WHERE SayfaId = @SayfaId";
            _baglanti.ParametreEkle("@SayfaId", System.Data.SqlDbType.Int, sayfaId);

            System.Data.DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "SayfaVeritabani",
                Method = "SayfaGetir",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc TumSayfalariGetir()
    {
        try
        {
            _baglanti.Komut = "SELECT SayfaId,Baslik FROM Sayfa";

            System.Data.DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "SayfaVeritabani",
                Method = "TumSayfalariGetir",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
}