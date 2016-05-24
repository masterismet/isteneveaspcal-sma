using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanDuzenleResim : System.Web.UI.Page
{
    #region Değişken

    IlanIslem ilanIslem = new IlanIslem();

    #endregion

    #region Load

    protected void Page_Load(object sender, EventArgs e)
    {
        int ilanId = IdAlQueryString();
        if (ilanId == 0)
            Response.Redirect("Default.aspx");
        DegiskenKontrol();
        IlanFotoListele();

    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
    }
    protected int IdAlQueryString()
    {
        int id = 0;
        try
        {
            id = Convert.ToInt32(Request.QueryString["IlanId"]);
        }
        catch { }
        return id;
    }
    protected void IlanFotoListele()
    {
        grvResimler.DataSource = this.ilanIslem.IlanFotoListele(IdAlQueryString());
        grvResimler.DataBind();
    }

    #endregion



    protected void grvResimler_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ilanFotoId = Convert.ToInt32(grvResimler.Rows[grvResimler.SelectedIndex].Cells[0].Text);
        this.ilanIslem.IlanFotoSil(ilanFotoId);
        IlanFotoListele();
    }
    protected void btIlanaDon_Click(object sender, EventArgs e)
    {
        Response.Redirect("IlanDuzenle.aspx?IlanId=" + IdAlQueryString().ToString() + "&Islem=guncel");
    }
    protected void btResimEkle_Click(object sender, EventArgs e)
    {
        string resimPath = fuResim.FileName;
        if (!string.IsNullOrEmpty(resimPath))
        {
            resimPath = DosyaIslem.Kaydet(fuResim, @"Content\Images\IlanResim\", Fonksiyon.YeniGuid());
            resimPath = "Content/Images/IlanResim/" + resimPath;
            bool resimEklendiMi = ilanIslem.IlanFotoEkle(IdAlQueryString(), resimPath);
            if(resimEklendiMi)
                Response.Write(Fonksiyon.MesajBox("Resim Başarıyla Eklendi", "IlanDuzenleResim.aspx?IlanId=" + IdAlQueryString().ToString()));
            else
                Response.Write(Fonksiyon.MesajBox("Özür dileriz, resim ekleme sırasında bir hata oluştu"));
        }
    }
}