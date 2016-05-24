using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UyeGiris : System.Web.UI.Page
{
    UyeIslem uyeIslem;


    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        if (Session[SiteTanim.SessionKullanici] != null)
        {
            Response.Redirect("Default.aspx");
        }

    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
    }




    protected void btGiris_Click(object sender, EventArgs e)
    {
        string kullaniciAdi = txbKullaniciAd.Text,
                       sifre = txbSifre.Text;

        UyeGirisIcerik uyeBilgi = uyeIslem.UyeGiris(kullaniciAdi, sifre);
        if (uyeBilgi.BasariliMi)
        {
            Session[SiteTanim.SessionKullanici] = uyeBilgi;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        else
        {

        }
    }
}