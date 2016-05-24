using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanOnizle : System.Web.UI.Page
{
    IlanIslem ilanIslem = new IlanIslem();

    protected void Page_Load(object sender, EventArgs e)
    {
        int ilanId = IlanIdAlQueryString();
        if (ilanId == 0)
            Response.Redirect("Default.aspx");
        DegiskenKontrol();
        IlanGetir(ilanId);
    }

    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null || ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeTip != (int)UyeTip.Yonetici)
            Response.Redirect("Default.aspx");

        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
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
        lbIlanTarih.Text = ilan.IlanTarih.ToTRString();
        lbUyeAd.Text = ilan.Ad.ToString();
        lbUyeSoyad.Text = ilan.Soyad.ToString();
        lbTelefon.Text = ilan.TelefonGorunsunMu ? ("+90" + ilan.TelefonKod + "-" + ilan.TelefonNo) : "-";
        lbUyelikBaslangicTarih.Text = ilan.UyeKayitTarih.ToTRString();
        lbAciklama.Text = ilan.Aciklama;
        dtlFotograflar.DataSource = ilan.Fotograflar;
        dtlFotograflar.DataBind();
        lbUyeId.Text = ilan.UyeId.ToString();
        lbFiyat.Text = ilan.FiyatStr.ToString();
        lbIlanTip.Text = ilan.IlanTipStr;
    }

}