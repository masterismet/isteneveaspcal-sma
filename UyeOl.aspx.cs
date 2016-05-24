using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UyeOl : System.Web.UI.Page
{
    UyeIslem uyeIslem = new UyeIslem();
    SehirIslem sehirIslem = new SehirIslem();

    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] != null)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
        this.sehirIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Sehir;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        BaglaBaslik();

        if (!IsPostBack)
        {
            SiteAyar.Path = Server.MapPath("App_Data");
            BaglaSehir();
            BaglaTelefonKod();
            BaglaKullanimSozlesmesi();
        }
    }

    protected void BaglaKullanimSozlesmesi()
    {
        lblSozlesme.Text = SiteAyar.Ayar.KullanimSozlesmesi;
    }
    protected void BaglaBaslik()
    {
        this.Title = "Yeni Üyelik | " + SiteAyar.Ayar.Baslik;
    }
    protected void BaglaSehir()
    {
        var sehirler = sehirIslem.SehirListele(0);
        ddlSehirler.DataSource = sehirler;
        ddlSehirler.DataTextField = "Ad";
        ddlSehirler.DataValueField = "SehirId";
        ddlSehirler.DataBind();
    }
    protected void BaglaTelefonKod()
    {
        var telefonKodlar = sehirIslem.TelefonKodListele();
        ddlTelefonKod.DataSource = telefonKodlar;
        ddlTelefonKod.DataTextField = "Kod";
        ddlTelefonKod.DataValueField = "Kod";
        ddlTelefonKod.DataBind();
    }

    protected void btnUyeOl_Click(object sender, EventArgs e)
    {
        Uye yeniUye = new Uye()
        {
            EMail = txbEmail.Text,
            Ad = txbAd.Text,
            Soyad = txbSoyad.Text,
            Sifre = txbSifre.Text,
            TelefonGorunsunMu = false,//chbTelefonGorunsunMu.Checked,
            TelefonKod = ddlTelefonKod.SelectedItem.Text,
            TelefonNo = txbTelefon.Text,
            Adres = txbAd.Text,
            Meslek = txbMeslek.Text,
            SehirId = Convert.ToInt32(ddlSehirler.SelectedItem.Value),
            Hakkinda = txbHakkinda.Text,
            CinsiyetTip = Convert.ToInt32(ddlCinsiyet.SelectedItem.Value),
            KayitTarih = DateTime.Now,
            Sil = false
        };
        var uyeEkleSonuc = uyeIslem.UyeEkle(yeniUye);
        if (uyeEkleSonuc.ToString() == "Kullanıcı Adı Sistemde Kayıtlı")
        {
            Response.Write(Fonksiyon.MesajBox("Kullanıcı Adı Sistemde Kayıtlı"));
        }
        else
        {
            UyeGirisIcerik uyeBilgi = uyeIslem.UyeGiris(txbEmail.Text, txbSifre.Text);
            Session[SiteTanim.SessionKullanici] = uyeBilgi;
            Response.Redirect("Default.aspx");
        }
    }
}