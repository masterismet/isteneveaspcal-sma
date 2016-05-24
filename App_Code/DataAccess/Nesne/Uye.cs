using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Uye
/// </summary>
public class Uye
{
    public int UyeId { get; set; }
    public string EMail { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Sifre { get; set; }
    public bool TelefonGorunsunMu { get; set; }
    public string TelefonKod { get; set; }
    public string TelefonNo { get; set; }
    public string Adres { get; set; }
    public string Meslek { get; set; }
    public int SehirId { get; set; }
    public string Hakkinda { get; set; }
    public int CinsiyetTip { get; set; }
    public DateTime KayitTarih { get; set; }
    public bool Sil { get; set; }
    public int UyeTip { get; set; }
}