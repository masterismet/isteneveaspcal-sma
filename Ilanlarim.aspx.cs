using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ilanlarim : System.Web.UI.Page
{
    IlanIslem ilanIslem = new IlanIslem();

    protected void Page_Load(object sender, EventArgs e)
    {
        SessionKontrol();
        UyeGirisIcerik uyeBilgi = (UyeGirisIcerik)Session[SiteTanim.SessionKullanici];
        int uyeId = uyeBilgi.UyeId;
        BaglaIlanlarim(uyeId);
    }
    private void SessionKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
    }

    private void BaglaIlanlarim(int uyeId)
    {
        DataList1.DataSource = ilanIslem.IlanListeleIlanlarim(uyeId);
        DataList1.DataBind();
    }
}