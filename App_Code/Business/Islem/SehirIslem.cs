using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SehirIslem
/// </summary>
public class SehirIslem : SehirVeritabani
{
    HataIslem _hata = new HataIslem();
    public DataTable SehirListele(int ustSehirId)
    {
        var islemSonuc = base.SehirListele(ustSehirId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable TelefonKodListele()
    {
        var islemSonuc = base.TelefonKodListele();
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable ParaBirimListele()
    {
        var islemSonuc = base.ParaBirimListele();
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable YayinlanmaSureListele()
    {
        var islemSonuc = base.YayinlanmaSureListele();
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
}
