using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mesajlar : System.Web.UI.Page
{
    MesajIslem mesajIslem = new MesajIslem();

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
        this.mesajIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Mesaj;
    }
    protected void GetirUyeFavoriUyeler(int uyeId)
    {
        dtlMesajlar.DataSource = this.mesajIslem.Mesajlar(uyeId);
        dtlMesajlar.DataBind();
    }
}