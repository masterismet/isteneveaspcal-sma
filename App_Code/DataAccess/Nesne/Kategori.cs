using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Kategori
/// </summary>
public class Kategori
{
    public int KategoriId { get; set; }
    public string KategoriAd { get; set; }
    public bool Sil { get; set; }
    public int UstKategoriId { get; set; }
}