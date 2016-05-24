using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteTanim
/// </summary>
public class SiteTanim
{
    public static string SessionKullanici { get { return "IstenEveKullanici"; } }
    public static string SessionDegisken { get { return "IstenEveDegisken"; } }
    public static string RegexKullaniciAdi { get { return "^([a-zA-Z0-9]{3})([a-zA-Z0-9]*)$"; } }
    public static string RegexSifre { get { return "^([a-zA-Z0-9]{3})([a-zA-Z0-9]*)$"; } }

}