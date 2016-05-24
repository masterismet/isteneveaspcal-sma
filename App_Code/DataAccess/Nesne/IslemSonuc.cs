using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IslemSonuc
/// </summary>
public class IslemSonuc
{
    public IslemSonuc(bool basariliMi, Hata hataBilgi = null, object veri = null)
    {
        BasariliMi = basariliMi;
        HataBilgi = hataBilgi;
        Veri = veri;
        if (!basariliMi)
        {
            HataIslem hataIslem = new HataIslem();
            hataIslem.HataEkle(hataBilgi);
        }
    }
    public bool BasariliMi { get; set; }
    public object Veri { get; set; }
    public Hata HataBilgi { get; set; }

}