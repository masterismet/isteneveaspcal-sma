using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for IlanVeritabani
/// </summary>
public class IlanVeritabani : BaglantiVeritabani
{
    private IslemSonuc _islemSonuc;

	public IlanVeritabani()
	{
        if (_baglanti == null)
            this._baglanti = new Baglanti();
    }
    protected IslemSonuc IlanEkle(Ilan ilan)
    {
        try
        {
            _baglanti.SpAdi = "SPIlanEkle";
            _baglanti.ParametreEkle("@KategoriId", SqlDbType.Int, ilan.KategoriId);
            _baglanti.ParametreEkle("@IlanBaslik", SqlDbType.NVarChar, ilan.IlanBaslik);
            _baglanti.ParametreEkle("@Aciklama", SqlDbType.NVarChar, ilan.Aciklama);
            _baglanti.ParametreEkle("@IlanOzet", SqlDbType.NVarChar, ilan.IlanOzet);
            _baglanti.ParametreEkle("@SehirId", SqlDbType.Int, ilan.SehirId);
            _baglanti.ParametreEkle("@IlceId", SqlDbType.Int, ilan.IlceId);
            _baglanti.ParametreEkle("@Fiyat", SqlDbType.Money, ilan.Fiyat);
            _baglanti.ParametreEkle("@YayinlanmaSureId", SqlDbType.Int, ilan.YayinlanmaSureId);
            _baglanti.ParametreEkle("@TelefonNumaramYayinlansinMi", SqlDbType.Bit, ilan.TelefonNumaramYayinlansinMi);
            _baglanti.ParametreEkle("@YayinTarih", SqlDbType.DateTime, ilan.YayinTarih);
            _baglanti.ParametreEkle("@YayinDurumTip", SqlDbType.Int, ilan.YayinDurumTip);
            _baglanti.ParametreEkle("@UyeId", SqlDbType.Int, ilan.UyeId);
            _baglanti.ParametreEkle("@ParaBirimId", SqlDbType.Int, ilan.ParaBirimId);
            _baglanti.ParametreEkle("@Fotograflar", SqlDbType.NVarChar, ilan.StrFotograflar);
            _baglanti.ParametreEkle("@IlanGuid", SqlDbType.NChar, Fonksiyon.YeniGuid());
            _baglanti.ParametreEkle("@IlanTip", SqlDbType.Int, ilan.IlanTip);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch(Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanEkle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanGetir(int ilanId)
    {
        try
        {
            _baglanti.SpAdi = "SpIlanGetir";
            _baglanti.ParametreEkle("@IlanId", System.Data.SqlDbType.Int, ilanId);

            System.Data.DataTable tabloIlan = _baglanti.SorguCalistirTablo();



            _islemSonuc = new IslemSonuc(true, veri: tabloIlan);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanGetir",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanFotoGetir(int ilanId)
    {
        try
        {
            _baglanti.Komut = "SELECT * FROM IlanFotograf WHERE IlanId = @IlanId";
            _baglanti.ParametreEkle("@IlanId", System.Data.SqlDbType.Int, ilanId);

            System.Data.DataTable tabloIlanFoto = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tabloIlanFoto);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanFotoGetir",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanListeleAnasayfa()
    {
        try
        {
            _baglanti.Komut = "SELECT TOP 9 I.IlanId,I.IlanBaslik,I.IlanOzet,I.YayinTarih,I.Fiyat, (SELECT TOP 1 F.FotoPath FROM IlanFotograf F WHERE F.IlanId = I.IlanId) FotoPath FROM Ilan I WHERE I.Sil = 0 AND I.YayinDurumTip = @YayinDurumTip AND I.ParaliMi = 0 ORDER BY I.YayinTarih DESC";
            _baglanti.ParametreEkle("@YayinDurumTip", System.Data.SqlDbType.Int, (int)YayinDurumTip.Onaylandi);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanListele",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanVerUyeBilgiGetir(int kategoriId, int uyeId)
    {
        try
        {
            _baglanti.Komut = "SELECT U.UyeId,U.Ad,U.Soyad,U.TelefonGorunsunMu,U.TelefonKod,U.TelefonNo,K.KategoriId,K.KategoriAd FROM Uye U, Kategori K WHERE U.UyeId = @UyeId AND K.KategoriId = @KategoriId";
            _baglanti.ParametreEkle("@UyeId", System.Data.SqlDbType.Int, uyeId);
            _baglanti.ParametreEkle("@KategoriId", System.Data.SqlDbType.Int, kategoriId);

            System.Data.DataTable tabloIlan = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tabloIlan);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanVerUyeBilgiGetir",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanListele(int uyeId)
    {
        try
        {
            _baglanti.Komut = "SELECT IlanId,IlanBaslik,IlanOzet,YayinTarih,IlanTip FROM Ilan WHERE UyeId = @UyeId AND YayinDurumTip = @YayinDurumTip AND Sil = 0 AND ParaliMi = 0";
            _baglanti.ParametreEkle("@UyeId", System.Data.SqlDbType.Int, uyeId);
            _baglanti.ParametreEkle("@YayinDurumTip", System.Data.SqlDbType.Int, (int)YayinDurumTip.Onaylandi);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanListele",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanFavorilereEkleCikar(int ilanId, int uyeId)
    {
        try
        {
            _baglanti.SpAdi = "SpFavoriIlanEkleCikar";
            _baglanti.ParametreEkle("@IlanId", System.Data.SqlDbType.Int, ilanId);
            _baglanti.ParametreEkle("@UyeId", System.Data.SqlDbType.Int, uyeId);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanFavorilereEkle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanFavoriMi(int ilanId, int uyeId)
    {
        try
        {
            _baglanti.SpAdi = "SpFavoriIlanMi";
            _baglanti.ParametreEkle("@IlanId", System.Data.SqlDbType.Int, ilanId);
            _baglanti.ParametreEkle("@UyeId", System.Data.SqlDbType.Int, uyeId);

            object sonuc = _baglanti.SorguCalistirBirKayit();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanFavoriMi",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanListeleIlanlarim(int uyeId)
    {
        try
        {
            _baglanti.Komut = "SELECT (SELECT TOP 1 KategoriAd FROM Kategori K WHERE K.KategoriId = I.KategoriId) KategoriAd, I.IlanBaslik, I.IlanNo, I.IlanId, CASE WHEN I.YayinDurumTip = 1 THEN 'Onay Bekliyor' WHEN I.YayinDurumTip = 2 THEN 'Onaylandı' WHEN I.YayinDurumTip = 3 THEN 'Reddedildi' ELSE 'Bilinmiyor' END AS Durum, I.IlanTip FROM Ilan I WHERE I.UyeId = @UyeId AND I.Sil = 0";
            _baglanti.ParametreEkle("@UyeId", System.Data.SqlDbType.Int, uyeId);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanListeleIlanlarim",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanGetirDuzenle(int ilanId)
    {
        try
        {
            _baglanti.Komut = "SELECT * FROM Ilan WHERE IlanId = @IlanId";
            _baglanti.ParametreEkle("@IlanId", System.Data.SqlDbType.Int, ilanId);

            System.Data.DataTable tabloIlan = _baglanti.SorguCalistirTablo();

            _islemSonuc = new IslemSonuc(true, veri: tabloIlan);
        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanGetirDuzenle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanDuzenle(Ilan ilan)
    {
        try
        {
            _baglanti.Komut = "UPDATE Ilan SET IlanBaslik = @IlanBaslik ,IlanOzet = @IlanOzet,Aciklama = @Aciklama ,SehirId = @SehirId ,IlceId = @IlceId ,Fiyat = @Fiyat ,YayinlanmaSureId = @YayinlanmaSureId ,TelefonNumaramYayinlansinMi = @TelefonNumaramYayinlansinMi ,SonGuncellemeTarih = @SonGuncellemeTarih ,YayinDurumTip = @YayinDurumTip ,ParaBirimId = @ParaBirimId, IlanTip = @IlanTip  WHERE IlanId = @IlanId";
            _baglanti.ParametreEkle("@IlanBaslik", SqlDbType.NVarChar, ilan.IlanBaslik);
            _baglanti.ParametreEkle("@IlanOzet", SqlDbType.NVarChar, ilan.IlanOzet);
            _baglanti.ParametreEkle("@Aciklama", SqlDbType.NVarChar, ilan.Aciklama);
            _baglanti.ParametreEkle("@SehirId", SqlDbType.Int, ilan.SehirId);
            _baglanti.ParametreEkle("@IlceId", SqlDbType.Int, ilan.IlceId);
            _baglanti.ParametreEkle("@Fiyat", SqlDbType.Money, ilan.Fiyat);
            _baglanti.ParametreEkle("@YayinlanmaSureId", SqlDbType.Int, ilan.YayinlanmaSureId);
            _baglanti.ParametreEkle("@TelefonNumaramYayinlansinMi", SqlDbType.Bit, ilan.TelefonNumaramYayinlansinMi);
            _baglanti.ParametreEkle("@YayinDurumTip", SqlDbType.Int, (int)YayinDurumTip.OnayBekliyor);
            _baglanti.ParametreEkle("@ParaBirimId", SqlDbType.Int, ilan.ParaBirimId);
            _baglanti.ParametreEkle("@SonGuncellemeTarih", SqlDbType.DateTime, DateTime.Now);
            _baglanti.ParametreEkle("@IlanId", SqlDbType.Int, ilan.IlanId);
            _baglanti.ParametreEkle("@IlanTip", SqlDbType.Int, ilan.IlanTip);


            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanDuzenle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanFotoSil(int ilanFotoId)
    {
        try
        {
            _baglanti.Komut = "DELETE FROM IlanFotograf WHERE IlanFotografId = @IlanFotografId";
            _baglanti.ParametreEkle("@IlanFotografId", SqlDbType.Int, ilanFotoId);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanFotoSil",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanFotoEkle(int ilanId, string fotoPath)
    {
        try
        {
            _baglanti.Komut = "INSERT INTO IlanFotograf(IlanId, FotoPath) VALUES(@IlanId,@FotoPath)";
            _baglanti.ParametreEkle("@IlanId", SqlDbType.Int, ilanId);
            _baglanti.ParametreEkle("@FotoPath", SqlDbType.NVarChar, fotoPath);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanFotoEkle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanSil(int ilanId)
    {
        try
        {
            _baglanti.Komut = "UPDATE Ilan SET Sil = 1 WHERE IlanId = @IlanId";
            _baglanti.ParametreEkle("@IlanId", SqlDbType.Int, ilanId);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanSil",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanListeleOnay()
    {
        try
        {
            _baglanti.Komut = "SELECT IlanId,IlanBaslik,YayinDurumTip,ParaliMi FROM Ilan WHERE Sil = 0";

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanListeleOnay",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanDurumGuncelle(int ilanId, int yayinDurumTip)
    {
        try
        {
            _baglanti.Komut = "UPDATE Ilan SET YayinDurumTip = @YayinDurumTip WHERE IlanId = @IlanId";
            _baglanti.ParametreEkle("@IlanId", SqlDbType.Int, ilanId);
            _baglanti.ParametreEkle("@YayinDurumTip", SqlDbType.Int, yayinDurumTip);

            int sonuc = _baglanti.SorguCalistir();
            _islemSonuc = new IslemSonuc(true, veri: sonuc);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanDurumGuncelle",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanAra(IlanAraKriter kriter)
    {
        try
        {
            int sorguDurum = 0;
            string sorgu = "SELECT I.IlanId,I.IlanBaslik,I.IlanOzet,I.YayinTarih,I.Fiyat, (SELECT TOP 1 F.FotoPath FROM IlanFotograf F WHERE F.IlanId = I.IlanId) AS FotoPath FROM Ilan I WHERE ";
            if (!string.IsNullOrEmpty(kriter.Kelime))
            {
                sorgu += "(I.IlanBaslik LIKE '%" + kriter.Kelime + "%' OR I.IlanOzet LIKE '%" + kriter.Kelime + "%' OR I.Aciklama LIKE '%" + kriter.Kelime + "%') ";
                sorguDurum++;
            }
            if (kriter.SehirId != 0)
            {
                if (sorguDurum == 1) 
                    sorgu += " AND ";
                sorgu += "SehirId = " + kriter.SehirId + " ";
                sorguDurum++;
            }
            if (kriter.IlceId != 0)
            {
                if (sorguDurum > 0)
                    sorgu += " AND ";
                sorgu += "IlceId = " + kriter.IlceId + " ";
                sorguDurum++;
            }
            if (kriter.Fiyat1 >= 0 & kriter.Fiyat2 > 0)
            {
                if (sorguDurum > 0)
                    sorgu += " AND ";
                sorgu += "(Fiyat > " + kriter.Fiyat1 + " AND Fiyat < " + kriter.Fiyat2 + ") ";
                sorguDurum++;
            }
            if (kriter.Kategoriler.Count > 0)
            {
                if (sorguDurum > 0)
                    sorgu += " AND ";
                sorgu += "KategoriId IN(";
                for (int i = 0; i < kriter.Kategoriler.Count; i++)
                {
                    sorgu += kriter.Kategoriler[i] + (i != kriter.Kategoriler.Count - 1 ? "," : "");
                }
                sorgu += ") ";
            }
            if(sorguDurum > 0)
                sorgu += " AND ";
            sorgu += "I.YayinDurumTip = @YayinDurumTip AND I.Sil = 0";

            _baglanti.Komut = sorgu;

            _baglanti.ParametreEkle("@YayinDurumTip", System.Data.SqlDbType.Int, (int)YayinDurumTip.Onaylandi);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanAra",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanListele()
    {
        try
        {
            _baglanti.Komut = "SELECT IlanId,IlanBaslik,IlanOzet,YayinTarih FROM Ilan WHERE YayinDurumTip = @YayinDurumTip AND Sil = 0";
            _baglanti.ParametreEkle("@YayinDurumTip", System.Data.SqlDbType.Int, (int)YayinDurumTip.Onaylandi);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanListele",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanListeleVitrin()
    {
        try
        {
            _baglanti.Komut = "SELECT TOP 10 I.IlanId, I.IlanBaslik,I.Fiyat, (SELECT TOP 1 F.FotoPath FROM IlanFotograf F WHERE F.IlanId = I.IlanId) FotoPath, (SELECT TOP 1 KisaAd FROM ParaBirim P WHERE P.ParaBirimId = I.ParaBirimId) ParaBirimi, I.IlanTip  FROM Ilan I WHERE I.ParaliMi = 1 AND YayinDurumTip = @YayinDurumTip AND Sil = 0 AND IlanTip = 1";
            _baglanti.ParametreEkle("@YayinDurumTip", System.Data.SqlDbType.Int, (int)YayinDurumTip.Onaylandi);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanListeleVitrin",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }
    protected IslemSonuc IlanListele_Ilanlar(int ilanTip)
    {
        try
        {
            _baglanti.Komut = "SELECT I.IlanId,I.IlanBaslik,I.IlanOzet,I.YayinTarih,I.Fiyat, (SELECT TOP 1 F.FotoPath FROM IlanFotograf F WHERE F.IlanId = I.IlanId) FotoPath FROM Ilan I WHERE I.Sil = 0 AND I.YayinDurumTip = @YayinDurumTip AND IlanTip = @IlanTip ORDER BY I.YayinTarih DESC";
            _baglanti.ParametreEkle("@YayinDurumTip", System.Data.SqlDbType.Int, (int)YayinDurumTip.Onaylandi);
            _baglanti.ParametreEkle("@IlanTip", System.Data.SqlDbType.Int, ilanTip);

            DataTable tablo = _baglanti.SorguCalistirTablo();
            _islemSonuc = new IslemSonuc(true, veri: tablo);

        }
        catch (Exception hata)
        {
            _islemSonuc = new IslemSonuc(false, new Hata
            {
                Sinif = "IlanVeritabani",
                Method = "IlanListele_Ilanlar",
                KullaniciId = 0,
                HataMesaj = hata.Message,
                Tarih = DateTime.Now
            });
        }
        return _islemSonuc;
    }




    /* */
}