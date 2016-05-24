using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IslemSession
/// </summary>
public class IslemSession
{
	public IslemSession()
	{
        Kategori = new KategoriIslem();
        Sehir = new SehirIslem();
        Uye = new UyeIslem();
        Ilan = new IlanIslem();
        Mesaj = new MesajIslem();
        Sayfa = new SayfaIslem();
	}
    public KategoriIslem Kategori { get; set; }
    public SehirIslem Sehir { get; set; }
    public UyeIslem Uye { get; set; }
    public IlanIslem Ilan { get; set; }
    public MesajIslem Mesaj { get; set; }
    public SayfaIslem Sayfa { get; set; }
}