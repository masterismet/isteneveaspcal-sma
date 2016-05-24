using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MesajGonder : System.Web.UI.Page
{
    MesajIslem mesajIslem = new MesajIslem();

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        MesajGonderilecekUyeBilgiGetir();
    }

    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.mesajIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Mesaj;
    }
    protected void MesajGonderilecekUyeBilgiGetir()
    {
        System.Data.DataTable uyeBilgi;
        if(IlanIdAlQueryString() != 0)
            uyeBilgi = this.mesajIslem.MesajGonderilecekUyeGetirIlanId(IlanIdAlQueryString());
        else
            uyeBilgi = this.mesajIslem.MesajGonderilecekUyeGetirUyeId(UyeIdAlQueryString());

        lbUyeAd.Text = uyeBilgi.Rows[0]["Ad"].ToString();
        lbUyeSoyad.Text = uyeBilgi.Rows[0]["Soyad"].ToString();
        lbUyeId.Text = uyeBilgi.Rows[0]["UyeId"].ToString();
    }
    protected int IlanIdAlQueryString()
    {
        int ilanId = 0;
        try
        {
            ilanId = Convert.ToInt32(Request.QueryString["IlanId"]);
        }
        catch { }
        return ilanId;
    }
    protected int UyeIdAlQueryString()
    {
        int uyeId = 0;
        try
        {
            uyeId = Convert.ToInt32(Request.QueryString["UyeId"]);
        }
        catch { }
        return uyeId;
    }

    protected void btMesajGonder_Click(object sender, EventArgs e)
    {
        bool gonderildiMi = this.mesajIslem.MesajGonder(((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId, Convert.ToInt32(lbUyeId.Text), txbMesaj.Text, txbBaslik.Text, IlanIdAlQueryString());
        if(gonderildiMi)
            Response.Write(Fonksiyon.MesajBox("Mesajınız başarıyla gönderildi.", "IlanDetay.aspx?IlanId=" + IlanIdAlQueryString()));
        else
            Response.Write(Fonksiyon.MesajBox("Özür dileriz, mesaj gönderme sırasında bir hata oluştu.", "Default.aspx"));
    }
}