using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfilDuzenle : System.Web.UI.Page
{
    UyeIslem uyeIslem = new UyeIslem();
    SehirIslem sehirIslem = new SehirIslem();

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        if (!IsPostBack)
        {
            SiteAyar.Path = Server.MapPath("App_Data");
            BaglaSehir();
            BaglaTelefonKod();
            GetirUyeBilgi();
        }

    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
        this.sehirIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Sehir;
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
    protected void GetirUyeBilgi()
    {
        var uyeBilgiler = this.uyeIslem.KullaniciProfili(((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId);
        var uyeBilgi = uyeBilgiler.Rows[0];
        txbAd.Text = uyeBilgi["Ad"].ToString();
        txbSoyad.Text = uyeBilgi["Soyad"].ToString();
        for (int i = 0; i < ddlTelefonKod.Items.Count; i++)
            if (ddlTelefonKod.Items[i].Text == uyeBilgi["TelefonKod"].ToString())
            {
                ddlTelefonKod.Items[i].Selected = true;
                break;
            }
        txbTelefon.Text = uyeBilgi["TelefonNo"].ToString();
        for (int i = 0; i < ddlSehirler.Items.Count; i++)
            if (ddlSehirler.Items[i].Value == uyeBilgi["SehirId"].ToString())
            {
                ddlSehirler.Items[i].Selected = true;
                break;
            }
        txbAdres.Text = uyeBilgi["Adres"].ToString();
        txbHakkinda.Text = uyeBilgi["Hakkinda"].ToString();
        for (int i = 0; i < ddlCinsiyet.Items.Count; i++)
            if (ddlCinsiyet.Items[i].Value == uyeBilgi["CinsiyetTip"].ToString())
            {
                ddlCinsiyet.Items[i].Selected = true;
                break;
            }
        chbTelefonGorunsunMu.Checked = Convert.ToBoolean(uyeBilgi["TelefonGorunsunMu"]);
        txbMeslek.Text = uyeBilgi["Meslek"].ToString();
    }




    protected void btnUyeOl_Click(object sender, EventArgs e)
    {
        Uye uye = new Uye
        {
            UyeId = ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId,
            Ad = txbAd.Text,
            Soyad = txbSoyad.Text,
            TelefonKod = ddlTelefonKod.SelectedItem.Text,
            TelefonNo = txbTelefon.Text,
            TelefonGorunsunMu = chbTelefonGorunsunMu.Checked,
            Meslek = txbMeslek.Text,
            SehirId = Convert.ToInt32(ddlSehirler.SelectedItem.Value),
            Adres = txbAdres.Text,
            Hakkinda = txbHakkinda.Text,
            CinsiyetTip = Convert.ToInt32(ddlCinsiyet.SelectedItem.Value)
        };
        bool uyeDuzeldiMi = uyeIslem.UyeDuzenle(uye);
        if (!uyeDuzeldiMi)
            Response.Write(Fonksiyon.MesajBox("Özür dileriz, düzeltme işlemi sırasında bir sorun ile karşılaşıldı"));
        else
            Response.Redirect("Default.aspx");

    }

}