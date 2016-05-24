using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for IlanIslem
/// </summary>
public class IlanIslem : IlanVeritabani
{
    HataIslem _hata = new HataIslem();

    public bool IlanEkle(Ilan ilan)
    {
        var islemSonuc = base.IlanEkle(ilan);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public IlanAnasayfa IlanGetir(int ilanId)
    {
        IlanAnasayfa ilan = new IlanAnasayfa();
        var ilanIslemSonuc = base.IlanGetir(ilanId);
        if (!ilanIslemSonuc.BasariliMi)
            _hata.HataEkle(ilanIslemSonuc.HataBilgi);
        else
        {
            DataTable ilanTablo = (DataTable)ilanIslemSonuc.Veri;
            if (ilanTablo.Rows.Count > 0)
            {
                ilan = new IlanAnasayfa
                {
                    Aciklama = ilanTablo.Rows[0]["Aciklama"].ToString(),
                    FiyatStr = ilanTablo.Rows[0]["Fiyat"].ToString(),
                    IlanBaslik = ilanTablo.Rows[0]["IlanBaslik"].ToString(),
                    IlanNo = ilanTablo.Rows[0]["IlanNo"].ToString(),
                    IlceAd = ilanTablo.Rows[0]["IlceAd"].ToString(),
                    KategoriAd = ilanTablo.Rows[0]["KategoriAd"].ToString(),
                    SehirAd = ilanTablo.Rows[0]["SehirAd"].ToString(),
                    Sure = ilanTablo.Rows[0]["Sure"].ToString(),
                    TelefonGorunsunMu = Convert.ToBoolean(ilanTablo.Rows[0]["TelefonGorunsunMu"]),
                    TelefonKod = ilanTablo.Rows[0]["TelefonKod"].ToString(),
                    TelefonNo = ilanTablo.Rows[0]["TelefonNo"].ToString(),
                    Ad = ilanTablo.Rows[0]["Ad"].ToString(),
                    Soyad = ilanTablo.Rows[0]["Soyad"].ToString(),
                    IlanTarih = Convert.ToDateTime(ilanTablo.Rows[0]["SonGuncellemeTarih"]),
                    UyeKayitTarih = Convert.ToDateTime(ilanTablo.Rows[0]["KayitTarih"]),
                    UyeId = Convert.ToInt32(ilanTablo.Rows[0]["UyeId"]),
                    IlanTipInt = Convert.ToInt32(ilanTablo.Rows[0]["IlanTip"])

                };

                var ilanFotoIslemSonuc = base.IlanFotoGetir(ilanId);
                if (!ilanFotoIslemSonuc.BasariliMi)
                    _hata.HataEkle(ilanFotoIslemSonuc.HataBilgi);
                else
                {

                    DataTable ilanFotoTablo = (DataTable)ilanFotoIslemSonuc.Veri;
                    for (int i = 0; i < ilanFotoTablo.Rows.Count; i++)
                    {
                        ilan.Fotograflar.Add(new Fotograf { Path = ilanFotoTablo.Rows[i]["FotoPath"].ToString() });
                    }
                }
            }
        }

        return ilan;
    }
    public DataTable IlanListeleAnasayfa()
    {
        var islemSonuc = base.IlanListeleAnasayfa();
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable IlanVerUyeBilgiGetir(int kategoriId, int uyeId)
    {
        var islemSonuc = base.IlanVerUyeBilgiGetir(kategoriId,uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable IlanListele(int uyeId)
    {
        var islemSonuc = base.IlanListele(uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public bool IlanFavorilereEkleCikar(int ilanId, int uyeId)
    {
        var islemSonuc = base.IlanFavorilereEkleCikar(ilanId, uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public bool IlanFavoriMi(int ilanId, int uyeId)
    {
        var islemSonuc = base.IlanFavoriMi(ilanId, uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return Convert.ToBoolean(islemSonuc.Veri); ;
    }
    public DataTable IlanListeleIlanlarim(int uyeId)
    {
        var islemSonuc = base.IlanListeleIlanlarim(uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable IlanGetirDuzenle(int ilanId)
    {
        var islemSonuc = base.IlanGetirDuzenle(ilanId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public bool IlanDuzenle(Ilan ilan)
    {
        var islemSonuc = base.IlanDuzenle(ilan);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public DataTable IlanFotoListele(int uyeId)
    {
        var islemSonuc = base.IlanFotoGetir(uyeId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public bool IlanFotoSil(int ilanFotoId)
    {
        var islemSonuc = base.IlanFotoSil(ilanFotoId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public bool IlanFotoEkle(int ilanId, string fotoPath)
    {
        var islemSonuc = base.IlanFotoEkle(ilanId, fotoPath);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public bool IlanSil(int ilanId)
    {
        var islemSonuc = base.IlanSil(ilanId);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public DataTable IlanListeleOnay()
    {
        var islemSonuc = base.IlanListeleOnay();
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public bool IlanDurumGuncelle(int ilanId, int yayinDurumTip)
    {
        var islemSonuc = base.IlanDurumGuncelle(ilanId,yayinDurumTip);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return islemSonuc.BasariliMi;
    }
    public DataTable IlanAra(IlanAraKriter kriter)
    {
        var islemSonuc = base.IlanAra(kriter);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable IlanListele()
    {
        var islemSonuc = base.IlanListele();
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable IlanListeleVitrin()
    {
        var islemSonuc = base.IlanListeleVitrin();
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }
    public DataTable IlanListele_Ilanlar(int ilanTip)
    {
        var islemSonuc = base.IlanListele_Ilanlar(ilanTip);
        if (!islemSonuc.BasariliMi)
            _hata.HataEkle(islemSonuc.HataBilgi);
        return (DataTable)islemSonuc.Veri;
    }

}