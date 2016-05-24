using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteSayfa : System.Web.UI.Page
{
    SayfaIslem sayfaIslem;

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        SayfaBagla();
    }

    protected void DegiskenKontrol()
    {
        if (Request.QueryString["id"] == null)
            Response.Redirect("Default.aspx");

        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();

        this.sayfaIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Sayfa;
    }
    protected void SayfaBagla()
    {
        Sayfa sayfa = sayfaIslem.SayfaGetir(Convert.ToInt32(Request.QueryString["id"]));
        lbBaslik.Text = sayfa.Baslik;
        lbIcerik.Text = sayfa.Icerik;
    }
}