using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ilanlar : System.Web.UI.Page
{
    #region Değişken

    IlanIslem ilanIslem;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        if (IlanTipi > 0)
        {
            if (IlanTipi == (int)IlanTip.IsArayan)
            {
                lbIlanTip.Text = "İş Arayan ";
            }
            else if (IlanTipi == (int)IlanTip.Isveren)
            {
                lbIlanTip.Text = "İşveren";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        else
            Response.Redirect("Default.aspx");
        IlanListele();
    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
    }
    private int IlanTipi
    {
        get
        {
            try
            {
                return Convert.ToInt32(Request.QueryString["ilantip"]);
            }
            catch { return 0; }
        }
    }

    private void IlanListele()
    {
        dtlIlanlar.DataSource = ilanIslem.IlanListele_Ilanlar(IlanTipi);
        dtlIlanlar.DataBind();
    }


    public static string FotoPath(object path)
    {
        if (string.IsNullOrEmpty(Convert.ToString(path)))
            return "Content/Images/Site/ResimYok.png";
        return path.ToString();
    }

}