using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

public class Fonksiyon
{
    public Fonksiyon()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// İlk olarak sayfa url ini sonra sayfada gözükecek kayıt sayısını sonrada toplam kaydı girin
    /// </summary>
    public static string sayfalama(string url, int SayfadaKiMaxAdeti, int toplamKayit, object suankiSayfa)
    {
        int kacSayfa = 1;
        string icerik = "";
        int hangiSayfada = 1;

        try
        {
            kacSayfa = toplamKayit / SayfadaKiMaxAdeti;

            if (toplamKayit % SayfadaKiMaxAdeti > 0)
            {
                kacSayfa++;
            }
        }
        catch
        {
            kacSayfa = 1;
        }

        try
        {
            hangiSayfada = Guvenlik.SadeceSayi(suankiSayfa);
            if (hangiSayfada == 0)
                hangiSayfada = 1;
        }
        catch
        {
            hangiSayfada = 1;
        }
        string yol;
        for (int i = 1; i <= kacSayfa; i++)
        {
            if (i == hangiSayfada)
                yol = "<b>" + i + "</b>";
            else
                yol = i.ToString();
            icerik += " [ <a href='" + url + "s=" + i + "'>" + yol + "</a> ] ";
        }

        return icerik;
    }

    /// <summary>
    /// Sınırsız alt kategori ekleyebilmek için menu adını gönderin
    /// </summary>
    //public static void menuEkle(Menu SolMenu)
    //{
    //    //bool durum = false;

    //    try
    //    {
    //        SqlConnection baglanti = new SqlConnection(baglan.baglantiMars.ConnectionString);
    //        SqlCommand sorgu = new SqlCommand("select KategoriAd,KategoriId from Kategoriler where Root = 0", baglanti);

    //        if (ConnectionState.Closed == baglanti.State)
    //            baglanti.Open();

    //        SqlDataReader dr = sorgu.ExecuteReader();

    //        while (dr.Read())
    //        {
    //            MenuItem menu1 = new MenuItem();
    //            int KategoriId = Convert.ToInt32(dr["KategoriId"]);
    //            menu1.Text = dr["KategoriAd"].ToString();
    //            menu1.NavigateUrl = fonksiyonlar.SiteUrl + "/" + dr["KategoriId"].ToString() + "-" + Guvenlik.YaziDuzenle(dr["KategoriAd"].ToString()) + ".html";
    //            SolMenu.Items.Add(menu1);
    //            altUrunEkle(KategoriId, menu1);
    //        }
    //        baglanti.Close();
    //    }
    //    catch
    //    { }
    //}

    /// <summary>
    /// Sınırsız alt kategori ekleyebilmek için ana kat id be ana menuitem ı gönderin
    /// </summary>
    //public static void altUrunEkle(int anaKat, MenuItem menuItem)
    //{
    //    try
    //    {
    //        // İç içe döngüler yüzünden bağlantı yineliyoruz.
    //        SqlConnection baglanti = new SqlConnection(baglan.baglantiMars.ConnectionString);
    //        SqlCommand sorgu = new SqlCommand("select KategoriAd,KategoriId from Kategoriler where Root=" + anaKat, baglanti);
    //        if (ConnectionState.Closed == baglanti.State)
    //            baglanti.Open();
    //        SqlDataReader sorguyuOku = sorgu.ExecuteReader();
    //        while (sorguyuOku.Read())
    //        {
    //            MenuItem altMenu = new MenuItem(sorguyuOku["KategoriAd"].ToString());
    //            altMenu.NavigateUrl = fonksiyonlar.SiteUrl + "/" + "Kategoriler/" + sorguyuOku["KategoriId"].ToString() + "-" + Guvenlik.YaziDuzenle(sorguyuOku["KategoriAd"].ToString()) + ".html";
    //            menuItem.ChildItems.Add(altMenu);
    //            altUrunEkle(Convert.ToInt32(sorguyuOku["KategoriId"]), altMenu);
    //        }

    //        baglanti.Close();
    //    }
    //    catch
    //    { }
    //}

    /// <summary>
    /// Session alarak dil kontrolü yapar ve boşsa atar
    /// </summary>
    public static void DilKontrol()
    {
        if (HttpContext.Current.Request.QueryString["dil"] == "tr" || HttpContext.Current.Request.QueryString["dil"] == "ing")
            HttpContext.Current.Session["dil"] = HttpContext.Current.Request.QueryString["dil"];
        else if (HttpContext.Current.Session["dil"] == null && HttpContext.Current.Request.QueryString["dil"] == null)
            HttpContext.Current.Session["dil"] = "tr";
        else if (HttpContext.Current.Session["dil"] != null)
            HttpContext.Current.Session["dil"] = HttpContext.Current.Session["dil"];
    }

    /// <summary>
    /// Sitenin Local dede sorunsuz çalışabilmesi için default value belirledik
    /// </summary>
    //public static string SiteUrl = "http://localhost:1044/IstenEve";
    public static string SiteUrl = "http://www.isteneve.com";
    //public static string SiteUrl = "http://www.denizmert.org";

    /// <summary>
    /// Videonun bulunduğu klasörü, videonun uzantısı dahil ismini, genişlik ve yüksekliğini gönder kodları ile birlikte al...
    /// </summary>
    public static string VideoCagir(string VideoKlasor, string VideoAdi, string genislik, string yukseklik)
    {
        string videoIcerik = "";
        videoIcerik = "<object id='mediaPlayer' width='" + genislik + "' height='" + yukseklik + "' classid='CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95'";
        videoIcerik += "codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701'";
        videoIcerik += "standby='Microsoft Windows Media Player bilesenleri yukleniyor..'  type='application/x-oleobject'> ";
        videoIcerik += "<param name='FileName' VALUE='" + VideoKlasor + "/" + VideoAdi + "'><param name='ShowControls' value='1'><param name='AutoStart' value='0'><param name='ShowDisplay' value='False'><param name='AutoRewind' value='0'><param name='PlayCount' value='3'><param name='ShowStatusBar' value='1'><param name='ShowGotoBar' value='0'><param name='AutoSize' value='0'>  <param name='EnableContextMenu' value='false'><param name='BorderStyle' VALUE='1'><param name='DisplayForeColor' VALUE='0'><param name='DisplayBackColor' VALUE='0'><embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/Downloads/Contents/Products/MediaPlayer/' filename='" + VideoKlasor + "/" + VideoAdi + "' src='" + VideoKlasor + "/" + VideoAdi + "' name='mediaPlayer' autostart=0  showcontrols=1  showdisplay=False showgotobar=0  enablecontextmenu=false showstatusbar=1  autosize='0' width='" + genislik + "' height='" + yukseklik + "'></embed></object>";
        return videoIcerik;
    }


    public static string TarihFormatla(object tarih)
    {
        return String.Format("{0:dd.MM.yyyy}", Convert.ToDateTime(tarih));
    }
    public static string ParaFormatla(object para)
    {
        return String.Format("{0:00.00}", para);
    }

    public static bool PostaGonder(string kime, string baslik, string mesaj)
    {
        MailMessage newMessage = new MailMessage("info@isteneve.com", kime, baslik, mesaj);
        newMessage.IsBodyHtml = true;
        SmtpClient newSmtp = new SmtpClient("mail.isteneve.com");
        newSmtp.Credentials = new System.Net.NetworkCredential("info@isteneve.com", "sifre");
        try
        {
            newSmtp.Send(newMessage);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public static string MesajBox(string kelime)
    {
        kelime = "<script language='JavaScript'>alert('" + kelime + "');</script>";
        return kelime;
    }

    /// <summary>
    /// Js Alert methodunun yanında virgülden sonra link verebilir ya da geri yazabiliriz
    /// </summary>
    public static string MesajBox(string kelime, string link)
    {
        if (link == "geri")
        {
            kelime = "<script language='JavaScript'>alert('" + kelime + "');history.back(-1);</script>";
        }
        else
        {
            kelime = "<script language='JavaScript'>alert('" + kelime + "');window.location = '" + link + "';</script>";
        }
        return kelime;
    }

    public static string YeniGuid()
    {
        return Guid.NewGuid().ToString().Replace("-", "");
    }
    public static string Cinsiyet(int cinsiyetTip)
    {
        switch (cinsiyetTip)
        {
            case (int)CinsiyetTip.Bayan:
                return "Bayan";
            case (int)CinsiyetTip.Erkek:
                return "Erkek";
            default:
                return "";
        }
    }
    public static string ParaAna(double para)
    {
        try
        {
            if (para.ToString().IndexOf('.') > 0)
                return para.ToString().Substring(0, para.ToString().IndexOf('.'));
            else
                return para.ToString();
        }
        catch
        {
            if (para.ToString().IndexOf(',') > 0)
                return para.ToString().Substring(0, para.ToString().IndexOf(','));
            else
                return para.ToString();
        }
    }
    public static string ParaKusurat(double para)
    {
        try
        {
            if (para.ToString().IndexOf(',') > 0)
                return para.ToString().Substring(para.ToString().IndexOf('.') + 1);
            else
                return "00";
        }
        catch
        {
            if (para.ToString().IndexOf(',') > 0)
                return para.ToString().Substring(para.ToString().IndexOf(',') + 1);
            else
                return "00";
        }
    }
    
}
