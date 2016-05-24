using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IlanAraKriter
/// </summary>
public class IlanAraKriter
{
    public List<int> Kategoriler { get; set; }
    public string Kelime { get; set; }
    public int SehirId { get; set; }
    public int IlceId { get; set; }
    public double Fiyat1 { get; set; }
    public double Fiyat2 { get; set; }
}