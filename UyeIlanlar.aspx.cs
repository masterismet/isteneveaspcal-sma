using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UyeIlanlar : System.Web.UI.Page
{
    IlanIslem ilanIslem = new IlanIslem();
    UyeIslem uyeIslem;

    protected void Page_Load(object sender, EventArgs e)
    {
        int uyeId = IdAlQueryString();
        if (uyeId == 0)
            Response.Redirect("Default.aspx");

        DegiskenKontrol();
        UyeBilgiGetir(uyeId);
        IlanListele(uyeId);
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
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
    }
    protected void UyeBilgiGetir(int uyeId)
    {
        var uyeBilgileri = this.uyeIslem.UyeTemelBilgiler(uyeId);
        lbAdSoyad.Text = uyeBilgileri.Rows[0]["AdSoyad"].ToString();
    }
    protected void IlanListele(int uyeId)
    {
        var ilanlar = this.ilanIslem.IlanListele(uyeId);
        dtlIlanlar.DataSource = ilanlar;
        dtlIlanlar.DataBind();
    }

}