using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanDetay : System.Web.UI.Page
{
    #region Değişken

    IlanIslem ilanIslem = new IlanIslem();
    UyeIslem uyeIslem = new UyeIslem();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        int ilanId = IlanIdAlQueryString();
        if (ilanId == 0)
            Response.Redirect("Default.aspx");
        DegiskenKontrol();
        if(!IsPostBack)
            IlanGetir(ilanId);
    }

    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
    }

    protected int IlanIdAlQueryString()
    {
        int ilanId = 0;
        try
        {
            ilanId = Convert.ToInt32(Request.QueryString["IlanId"]);
        }
        catch{ }
        return ilanId;
    }
    protected void IlanGetir(int ilanId)
    {
        IlanAnasayfa ilan = this.ilanIslem.IlanGetir(ilanId);
        lbIlanBaslik.Text = ilan.IlanBaslik;
        lbIlIlce.Text = ilan.SehirAd + " / " + ilan.IlceAd;
        lbIlanTarih.Text = ilan.IlanTarih.ToTRString() ;
        lbUyeAd.Text = ilan.Ad.ToString();
        lbUyeSoyad.Text = ilan.Soyad.ToString();
        //lbTelefon.Text = ilan.TelefonGorunsunMu ? ("+90" + ilan.TelefonKod + "-" + ilan.TelefonNo) : "-";
        lbUyelikBaslangicTarih.Text = ilan.UyeKayitTarih.ToTRString();
        lbAciklama.Text = ilan.Aciklama;
        dtlFotograflar.DataSource = ilan.Fotograflar;
        dtlFotograflar.DataBind();
        lbUyeId.Text = ilan.UyeId.ToString();
        lbFiyat.Text = ilan.FiyatStr.ToString();
        lbIlanTip.Text = ilan.IlanTipStr;
        imgResim.ImageUrl = ilan.Fotograflar.Count > 0 ? ilan.Fotograflar[0].Path : "Content/Images/Site/ResimYok.png";
    }
    protected void btMesajGonder_Click(object sender, EventArgs e)
    {
        MesajGonder();
    }
    protected void lnbKullaniciProfili_Click(object sender, EventArgs e)
    {
        KullaniciProfili();
    }
    protected void lnbKullanicininDigerIlanlari_Click(object sender, EventArgs e)
    {
        KullanicininDigerIlanlari();
    }
    protected void btFavorileriIlanlarimaEkle_Click(object sender, EventArgs e)
    {
        IlanFavorilereEkle();
    }
    protected void btFavoriKullanicilarimaEkle_Click(object sender, EventArgs e)
    {
        UyeFavorilereEkle();
    }

    #region Buton İşlemleri

    protected void MesajGonder()
    {
        Response.Redirect("MesajGonder.aspx?IlanId=" + IlanIdAlQueryString());
    }
    protected void KullaniciProfili()
    {
        Response.Redirect("UyeDetay-" + lbUyeId.Text + "-uye.aspx");
    }
    protected void KullanicininDigerIlanlari()
    {
        Response.Redirect("UyeIlanlar.aspx?Uye=" + lbUyeId.Text);
    }
    protected void IlanFavorilereEkle()
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("UyeOl.aspx");
        else
            this.ilanIslem.IlanFavorilereEkleCikar(IlanIdAlQueryString(), ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId);
    }
    protected void UyeFavorilereEkle()
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("UyeOl.aspx");
        else
            this.uyeIslem.UyeFavorilereEkleCikar(((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId,Convert.ToInt32(lbUyeId.Text));
    }


    #endregion
}