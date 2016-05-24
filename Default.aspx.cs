using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    IlanIslem ilanIslem;
    UyeIslem uyeIslem;

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        IlanListele();
        IlanVitrinListele();
    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
        if (Session[SiteTanim.SessionKullanici] != null)
        { pnGiris.Visible = false; pnCikis.Visible = true; }
        else
        { pnGiris.Visible = true; pnCikis.Visible = false; }
    }
    protected void IlanListele()
    {
        var ilanlar = this.ilanIslem.IlanListeleAnasayfa();
        dtlIlanlar.DataSource = ilanlar;
        dtlIlanlar.DataBind();
    }
    protected void IlanVitrinListele()
    {
        var ilanlar = this.ilanIslem.IlanListeleVitrin();
        dtlIlanVitrin.DataSource = ilanlar;
        dtlIlanVitrin.DataBind();
    }
    protected void btGiris_Click(object sender, EventArgs e)
    {
        string kullaniciAdi = txbKullaniciAd.Text,
                       sifre = txbSifre.Text;

        UyeGirisIcerik uyeBilgi = uyeIslem.UyeGiris(kullaniciAdi, sifre);
        if (uyeBilgi.BasariliMi)
        {
            Session[SiteTanim.SessionKullanici] = uyeBilgi;
            pnGiris.Visible = false; 
            pnCikis.Visible = true;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        else
        {

        }
    }
    protected void btCikis_Click(object sender, EventArgs e)
    {
        if (Session[SiteTanim.SessionKullanici] != null)
            Session[SiteTanim.SessionKullanici] = null;
        pnGiris.Visible = true;
        pnCikis.Visible = false;

    }
    public static string FotoPath(object path)
    {
        if (string.IsNullOrEmpty(Convert.ToString(path)))
            return "Content/Images/Site/ResimYok.png";
        return path.ToString();
    }

}