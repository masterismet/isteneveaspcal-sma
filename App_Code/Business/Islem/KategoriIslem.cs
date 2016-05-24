using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for KategoriIslem
/// </summary>
public class KategoriIslem : KategoriVeritabani
{
    HataIslem _hata = new HataIslem();
    public DataTable KategoriListele(int ustKategoriId)
    {
        var islemSonuc = base.KategoriListele(ustKategoriId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable KategoriListele()
    {
        var islemSonuc = base.KategoriListele();
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public bool KategoriDuzenle(Kategori kategori)
    {
        var islemSonuc = base.KategoriDuzenle(kategori);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public bool KategoriEkle(Kategori kategori)
    {
        var islemSonuc = base.KategoriEkle(kategori);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
}