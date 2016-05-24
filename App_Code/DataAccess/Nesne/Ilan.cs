using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Ilan
/// </summary>
public class Ilan
{
    public Ilan()
    {
        Fotograflar = new List<string>();
    }
    public int IlanId { get; set; }
    public string IlanNo { get; set; }
    public int KategoriId { get; set; }
    public string IlanBaslik { get; set; }
    public string IlanOzet { get; set; }
    public string Aciklama { get; set; }
    public int SehirId { get; set; }
    public int IlceId { get; set; }
    public double Fiyat { get; set; }
    public int YayinlanmaSureId { get; set; }
    public bool TelefonNumaramYayinlansinMi { get; set; }
    public DateTime YayinTarih { get; set; }
    public DateTime SonGuncellemeTarih { get; set; }
    public int YayinDurumTip { get; set; }
    public List<string> Fotograflar { get; set; }
    public int UyeId { get; set; }
    public int ParaBirimId { get; set; }
    public int IlanTip { get; set; }
    public string StrFotograflar
    {
        get
        {
            string strFotograflar = "";
            for (int i = 0; i < Fotograflar.Count; i++)
            {
                if (!string.IsNullOrEmpty(Fotograflar[i]))
                {
                    strFotograflar += Fotograflar[i];
                    if (i != Fotograflar.Count - 1)
                        strFotograflar += ",";
                }
            }
            return strFotograflar;
        }
    }
    public bool ParaliMi { get; set; }
}
