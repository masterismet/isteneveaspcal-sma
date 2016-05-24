using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class MesajIslem : MesajVeritabani
{
    HataIslem _hata = new HataIslem();

    public bool MesajGonder(int gonderenUyeId, int alanUyeId, string mesaj, string baslik, int ilanId = 0)
    {
        var islemSonuc = base.MesajGonder(gonderenUyeId,alanUyeId,mesaj,baslik, ilanId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public DataTable MesajGonderilecekUyeGetirIlanId(int ilanId)
    {
        var islemSonuc = base.MesajGonderilecekUyeGetirIlanId(ilanId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable MesajGonderilecekUyeGetirUyeId(int ilanId)
    {
        var islemSonuc = base.MesajGonderilecekUyeGetirUyeId(ilanId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable Mesajlar(int uyeId)
    {
        var islemSonuc = base.Mesajlar(uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }



}