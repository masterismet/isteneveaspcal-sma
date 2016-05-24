using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public static class Extensions
{
    public static string ToTRString(this DateTime tarih)
    {
        return tarih.Day + " " + Ay(tarih.Month) + " " + tarih.Year;
    }

    private static string Ay(int month)
    {
        switch (month)
        {
            case 1:
                return "Ocak";
            case 2:
                return "Şubat";
            case 3:
                return "Mart";
            case 4:
                return "Nisan";
            case 5:
                return "Mayıs";
            case 6:
                return "Haziran";
            case 7:
                return "Temmuz";
            case 8:
                return "Ağustos";
            case 9:
                return "Eylül";
            case 10:
                return "Ekim";
            case 11:
                return "Kasım";
            case 12:
                return "Aralık";
            default:
                return "";
        }
    }

    public static List<Kategori> ToKategoriList(this DataTable kategoriler)
    {
        List<Kategori> listeKategori = new List<Kategori>();
        foreach (DataRow kategori in kategoriler.Rows)
        {
            listeKategori.Add(new Kategori
            {
                KategoriId = Convert.ToInt32(kategori["KategoriId"]),
                KategoriAd = Convert.ToString(kategori["KategoriAd"]),
                Sil = Convert.ToBoolean(kategori["Sil"]),
                UstKategoriId = Convert.ToInt32(kategori["UstKategoriId"])
            });
        }
        return listeKategori;
    }

    public static List<IdAd> ToSehirIdAd(this DataTable sehirler)
    {
        List<IdAd> listeSehir = new List<IdAd>();
        foreach (DataRow sehir in sehirler.Rows)
        {
            listeSehir.Add(new IdAd
            {
                Id = Convert.ToInt32(sehir["SehirId"]),
                Ad = Convert.ToString(sehir["Ad"])
            });
        }
        return listeSehir;

    }
    
}