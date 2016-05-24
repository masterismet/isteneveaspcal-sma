using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TumIlanlar : System.Web.UI.Page
{
    IlanIslem ilanIslem = new IlanIslem();

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        var ilanlar = ilanIslem.IlanListele();
        dtlIlanlar.DataSource = ilanlar;
        dtlIlanlar.DataBind();
    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
    }

}