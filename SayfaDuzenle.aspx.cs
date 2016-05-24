using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SayfaDuzenle : System.Web.UI.Page
{
    SayfaIslem sayfaIslem;

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        if(!IsPostBack)
            GetirSayfalar();
    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null || ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeTip != (int)UyeTip.Yonetici)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.sayfaIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Sayfa;
    }
    protected void GetirSayfalar()
    {
        var sayfalar = this.sayfaIslem.TumSayfalariGetir();
        ddlSayfa.DataSource = sayfalar;
        ddlSayfa.DataTextField = "Baslik";
        ddlSayfa.DataValueField = "SayfaId";
        ddlSayfa.DataBind();
        ddlSayfa_SelectedIndexChanged(null, null);
    }

    protected void ddlSayfa_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SayfaId >= 0)
            GetirSayfa();
    }
    protected void GetirSayfa()
    {
        var sayfa = this.sayfaIslem.SayfaGetir(SayfaId);
        lbBaslik.Text = sayfa.Baslik;
        fckIcerik.Value = sayfa.Icerik;
    }
    protected int SayfaId
    {
        get
        {
            if (ddlSayfa.SelectedIndex >= 0)
                return Convert.ToInt32(ddlSayfa.SelectedItem.Value);
            else return -1;
        }
    }
    protected void btDuzenle_Click(object sender, EventArgs e)
    {
        var sonuc = this.sayfaIslem.SayfaDuzenle(new Sayfa
        {
            Icerik = fckIcerik.Value,
            SayfaId = this.SayfaId
        });
        if(sonuc)
            Response.Write(Fonksiyon.MesajBox("Sayfa başarıyla düzenlendi","IstenEveSayfa-" + SayfaId + "-" + Guvenlik.YaziDuzenle(lbBaslik.Text) + ".aspx"));
        else
            Response.Write(Fonksiyon.MesajBox("Özür dileriz, düzenleme işlemi sırasında bir sorun ile karşılaşıldı","Default.aspx"));
    }
}