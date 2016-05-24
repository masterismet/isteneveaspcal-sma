using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UyeFavoriIlanlar : System.Web.UI.Page
{
    UyeIslem uyeIslem = new UyeIslem();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("Default.aspx");
        DegiskenKontrol();
        int uyeId = ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId;
        GetirUyeFavoriIlanlar(uyeId);
    }

    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
    }
    protected void GetirUyeFavoriIlanlar(int uyeId)
    {
        dtlIlanlar.DataSource = this.uyeIslem.UyeFavoriIlanlar(uyeId);
        dtlIlanlar.DataBind();
    }
}