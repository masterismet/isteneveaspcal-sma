using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kullanici : System.Web.UI.Page
{
    UyeIslem uyeIslem = new UyeIslem();

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = IdAlQueryString();
        if (id == 0)
            Response.Redirect("Default.aspx");
        DegiskenKontrol();
        UyeGetir(id);
    }

    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
    }
    protected int IdAlQueryString()
    {
        int id = 0;
        try
        {
            id = Convert.ToInt32(Request.QueryString["Uye"]);
        }
        catch { }
        return id;
    }
    protected void UyeGetir(int uyeId)
    {
        var uyeBilgi = this.uyeIslem.KullaniciProfili(uyeId);
        lbUyeAd.Text = uyeBilgi.Rows[0]["Ad"].ToString();
        lbUyeSoyad.Text = uyeBilgi.Rows[0]["Soyad"].ToString();
        //lbTelefon.Text = Convert.ToBoolean(uyeBilgi.Rows[0]["TelefonGorunsunMu"]) ? ("+90 " + uyeBilgi.Rows[0]["TelefonKod"].ToString() + "-" + uyeBilgi.Rows[0]["TelefonNo"].ToString()) : "-";
        lbUyelikBaslangicTarih.Text = uyeBilgi.Rows[0]["KayitTarih"].ToString();
        lbAdres.Text = uyeBilgi.Rows[0]["Adres"].ToString();
        lbMeslek.Text = uyeBilgi.Rows[0]["Meslek"].ToString();
        lbHakkinda.Text = uyeBilgi.Rows[0]["Hakkinda"].ToString();
        lbCinsiyet.Text = Fonksiyon.Cinsiyet(Convert.ToInt32(uyeBilgi.Rows[0]["CinsiyetTip"]));
    }
    protected void KullanicininDigerIlanlari()
    {
        Response.Redirect("UyeIlanlar.aspx?Uye=" + IdAlQueryString().ToString());
    }

    protected void btKullaniciIlanlari_Click(object sender, EventArgs e)
    {
        KullanicininDigerIlanlari();
    }
}
