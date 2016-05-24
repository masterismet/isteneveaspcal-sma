using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for SiteAyar
/// </summary>
public class SiteAyar : System.Web.UI.Page
{
    private static SiteAyar _siteAyar;
    private static XDocument _xmlUrunler;

	private SiteAyar()
    {
        string xmlPath = Server.MapPath("App_Data") + "/SiteAyar.xml";
        _xmlUrunler = XDocument.Load(xmlPath);
    }
    public static SiteAyar Ayar
    {
        get
        {
            if (_siteAyar == null || _xmlUrunler == null)
                _siteAyar = new SiteAyar();
            return _siteAyar;
        }
    }

    public static string Path { get; set; }
    public string Baslik
    {
        get
        {
            var baslik = (from b in _xmlUrunler.Elements("SiteAyar")
                          select b.Element("SiteBaslik")).FirstOrDefault();
            return baslik.Value;
        }
    }
    public string KullanimSozlesmesi
    {
        get
        {
            var baslik = (from b in _xmlUrunler.Elements("SiteAyar")
                          select b.Element("KullanimSozlesmesi")).FirstOrDefault();
            return baslik.Value;
        }
    }
}