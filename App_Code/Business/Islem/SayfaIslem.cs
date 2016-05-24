using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SayfaIslem
/// </summary>
public class SayfaIslem : SayfaVeritabani
{
    HataIslem _hata = new HataIslem();

    public bool SayfaDuzenle(Sayfa sayfa)
    {
        var islemSonuc = base.SayfaDuzenle(sayfa);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public Sayfa SayfaGetir(int sayfaId)
    {
        Sayfa sayfa = new Sayfa();
        var islemSonuc = base.SayfaGetir(sayfaId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        else
        {
            DataTable sayfaTablo = (DataTable)islemSonuc.Veri;
            if (sayfaTablo.Rows.Count > 0)
            {
                sayfa = new Sayfa
                {
                    SayfaId = Convert.ToInt32(sayfaTablo.Rows[0]["SayfaId"]),
                    Baslik = sayfaTablo.Rows[0]["Baslik"].ToString(),
                    Icerik = sayfaTablo.Rows[0]["Icerik"].ToString()
                };
            }
        }

        return sayfa;
    }
    public DataTable TumSayfalariGetir()
    {
        Sayfa sayfa = new Sayfa();
        var islemSonuc = base.TumSayfalariGetir();
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);

        return (DataTable)islemSonuc.Veri;
    }

}