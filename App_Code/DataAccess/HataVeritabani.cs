using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HataVeritabani
/// </summary>
public class HataVeritabani : BaglantiVeritabani
{
    public HataVeritabani()
    {
        if (_baglanti == null)
            this._baglanti = new Baglanti();
    }

    protected void HataEkle(Hata hata)
    {
        try
        {
            _baglanti.SpAdi = "SpHataEkle";
            _baglanti.ParametreEkle("@KullaniciId", SqlDbType.NChar, hata.KullaniciId);
            _baglanti.ParametreEkle("@Tarih", SqlDbType.DateTime, hata.Tarih);
            _baglanti.ParametreEkle("@Sinif", SqlDbType.NVarChar, hata.Sinif);
            _baglanti.ParametreEkle("@Method", SqlDbType.NVarChar, hata.Method);
            _baglanti.ParametreEkle("@HataMesaj", SqlDbType.NVarChar, hata.HataMesaj);

            int sonuc = _baglanti.SorguCalistir();
        }
        catch { }
    }
    protected DataTable HataListele()
    {
        try
        {
            using (Baglanti baglanti = new Baglanti())
            {
                baglanti.SpAdi = "SpHataListele";
                return baglanti.SorguCalistirTablo();
            }
        }
        catch { return null; }
    }
}