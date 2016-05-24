using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UyeIslem
/// </summary>
public class UyeIslem : UyeVeritabani
{
    HataIslem _hata = new HataIslem();

    public object UyeEkle(Uye uye)
    {
        var islemSonuc = base.UyeEkle(uye);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.Veri;
    }
    public UyeGirisIcerik UyeGiris(string eMail, string sifre)
    {
        var islemSonuc = base.UyeGiris(eMail, sifre);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        var sonuc = (DataTable)islemSonuc.Veri;
        if (sonuc.Rows[0][0].ToString() == "Hata")
            return new UyeGirisIcerik() { BasariliMi = false };
        else
            return new UyeGirisIcerik()
            {
                BasariliMi = true,
                AdSoyad = sonuc.Rows[0]["AdSoyad"].ToString(),
                UyeId = Convert.ToInt32(sonuc.Rows[0]["UyeId"]),
                UyeTip = Convert.ToInt32(sonuc.Rows[0]["UyeTip"])
            };
    }
    public DataTable KullaniciProfili(int uyeId)
    {
        var islemSonuc = base.KullaniciProfili(uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable UyeTemelBilgiler(int uyeId)
    {
        var islemSonuc = base.UyeTemelBilgiler(uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }

    public bool UyeFavorilereEkleCikar(int uyeId, int fUyeId)
    {
        var islemSonuc = base.UyeFavorilereEkleCikar(uyeId, fUyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public bool UyeFavoriMi(int uyeId, int fUyeId)
    {
        var islemSonuc = base.UyeFavoriMi(uyeId, fUyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return Convert.ToBoolean(islemSonuc.Veri); ;
    }
    public DataTable UyeFavoriUyeler(int uyeId)
    {
        var islemSonuc = base.UyeFavoriUyeler(uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable UyeFavoriIlanlar(int uyeId)
    {
        var islemSonuc = base.UyeFavoriIlanlar(uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public object UyeSifreGetir(string ePosta)
    {
        var islemSonuc = base.UyeSifreGetir(ePosta);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.Veri;
    }
    public bool UyeDuzenle(Uye uye)
    {
        var islemSonuc = base.UyeDuzenle(uye);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }

}