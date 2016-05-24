using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IlanAnasayfa
/// </summary>
public class IlanAnasayfa
{
    public IlanAnasayfa()
    {
        Fotograflar = new List<Fotograf>();
    }
    public string KategoriAd { get; set; }
    public string SehirAd { get; set; }
    public string IlceAd { get; set; }
    public string Sure { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string TelefonKod { get; set; }
    public string TelefonNo { get; set; }
    public bool TelefonGorunsunMu { get; set; }
    public double Fiyat { get; set; }
    public string FiyatStr { get; set; }
    public string IlanBaslik { get; set; }
    public string IlanNo { get; set; }
    public string Aciklama { get; set; }
    public List<Fotograf> Fotograflar { get; set; }
    public DateTime IlanTarih { get; set; }
    public DateTime UyeKayitTarih { get; set; }
    public int UyeId { get; set; }
    public int IlanTipInt { get; set; }
    public string IlanTipStr
    {
        get
        {
            if (IlanTipInt == (int)IlanTip.Isveren)
                return "İşveren";
            else if (IlanTipInt == (int)IlanTip.IsArayan)
                return "İş Arayan";
            return "";
        }
    }
}
public class Fotograf
{
    public string Path { get; set; }
}