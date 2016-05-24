using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UyeFavoriUyeler : System.Web.UI.Page
{
    UyeIslem uyeIslem = new UyeIslem();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("Default.aspx");
        DegiskenKontrol();
        int uyeId = ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId;
        GetirUyeFavoriUyeler(uyeId);
    }

    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
    }
    protected void GetirUyeFavoriUyeler(int uyeId)
    {
        dtlUyeler.DataSource = this.uyeIslem.UyeFavoriUyeler(uyeId);
        dtlUyeler.DataBind();
    }

}