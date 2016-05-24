using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SehirVeritabani
/// </summary>
public class SehirVeritabani : BaglantiVeritabani
{
    public SehirVeritabani()
    {
        if (_baglanti == null)
            this._baglanti = new Baglanti();
    }

    private IslemSonuc _islemSonuc;
    protected IslemSonuc SehirListele(int ustSehirId)
    {
        try
        {
            _baglanti.Komut = "SELECT SehirId,Ad FROM Sehir WHERE UstSehirId=@UstSehirId ORDER BY SehirId";
            _baglanti.ParametreEkle("@UstSehirId", SqlDbType.Int, ustSehirId);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "SehirVeritabani",
                Method = "SehirListele",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc TelefonKodListele()
    {
        try
        {
            _baglanti.Komut = "SELECT Kod FROM TelefonKod ORDER BY Kod";
            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "SehirVeritabani",
                Method = "TelefonKodListele",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc ParaBirimListele()
    {
        try
        {
            _baglanti.Komut = "SELECT ParaBirimId,KisaAd FROM ParaBirim ORDER BY ParaBirimId";
            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "SehirVeritabani",
                Method = "ParaBirimListele",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc YayinlanmaSureListele()
    {
        try
        {
            _baglanti.Komut = "SELECT YayinlanmaSureId, CAST(Sure AS NVARCHAR) + ' ' + SureTip AS Sure FROM YayinlanmaSure ORDER BY YayinlanmaSureId";
            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "SehirVeritabani",
                Method = "YayinlanmaSureListele",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }

}