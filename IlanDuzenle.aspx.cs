using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanDuzenle : System.Web.UI.Page
{   
    #region Değişken

    SehirIslem sehirIslem = new SehirIslem();
    IlanIslem ilanIslem = new IlanIslem();

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        int ilanId = IdAlQueryString();
        if (ilanId == 0)
            Response.Redirect("Default.aspx");
        if (Request.QueryString["islem"] == null || (Request.QueryString["islem"] != "guncel" && Request.QueryString["islem"] != "sil"))
            Response.Redirect("Ilanlarim.aspx");
        if (Request.QueryString["islem"] == "sil")
        {
            IlanSil(ilanId);
        }

        DegiskenKontrol();
        if (!IsPostBack)
        {
            SiteAyar.Path = Server.MapPath("App_Data");
            BaglaSehir(0);
            BaglaParaBirim();
            BaglaYayinlanmaSure();
            IlanBilgiDoldur(ilanId);

        }
    }
    protected void IlanSil(int ilanId)
    {
        bool silindiMi = ilanIslem.IlanSil(ilanId);
        if (!silindiMi)
            Response.Write(Fonksiyon.MesajBox("Özür dileriz, silme işlemi sırasında bir sorun ile karşılaşıldı"));
        else
            Response.Redirect("Ilanlarim.aspx");
    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.sehirIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Sehir;
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
    protected void IlanBilgiDoldur(int ilanId)
    {
        var ilanlar = this.ilanIslem.IlanGetirDuzenle(ilanId);
        var ilanBilgi = ilanlar.Rows[0];
        txbBaslik.Text = ilanBilgi["IlanBaslik"].ToString();
        txbIlanOzet.Text = ilanBilgi["IlanOzet"].ToString();
        fckAciklama.Value = ilanBilgi["Aciklama"].ToString();
        for (int i = 0; i < ddlSehirler.Items.Count; i++)
            if (ddlSehirler.Items[i].Value == ilanBilgi["SehirId"].ToString())
            {
                ddlSehirler.Items[i].Selected = true;
                break;
            }
        ddlSehirler_SelectedIndexChanged(null, null);
        for (int i = 0; i < ddlIlceler.Items.Count; i++)
            if (ddlIlceler.Items[i].Value == ilanBilgi["IlceId"].ToString())
            {
                ddlIlceler.Items[i].Selected = true;
                break;
            }
        txbFiyat.Text = ilanBilgi["Fiyat"].ToString();
        for (int i = 0; i < ddlParaBirim.Items.Count; i++)
            if (ddlParaBirim.Items[i].Value == ilanBilgi["ParaBirimId"].ToString())
            {
                ddlParaBirim.Items[i].Selected = true;
                break;
            }
        ddlYayinlanmaSure.SelectedIndex = -1;
        for (int i = 0; i < ddlYayinlanmaSure.Items.Count; i++)
            if (ddlYayinlanmaSure.Items[i].Value == ilanBilgi["YayinlanmaSureId"].ToString())
            {
                ddlYayinlanmaSure.Items[i].Selected = true;
                break;
            }
        ddlIlanTip.SelectedIndex = -1;
        for (int i = 0; i < ddlIlanTip.Items.Count; i++)
            if (ddlIlanTip.Items[i].Value == ilanBilgi["IlanTip"].ToString())
            {
                ddlIlanTip.Items[i].Selected = true;
                break;
            }
        chbTelefonNumaramYayinlansinMi.Checked = Convert.ToBoolean(ilanBilgi["TelefonNumaramYayinlansinMi"]);
    }

    protected void BaglaSehir(int ustSehirId)
    {
        var sehirler = sehirIslem.SehirListele(ustSehirId);
        ddlSehirler.DataSource = sehirler;
        ddlSehirler.DataTextField = "Ad";
        ddlSehirler.DataValueField = "SehirId";
        ddlSehirler.DataBind();
    }
    protected void BaglaParaBirim()
    {
        var paraBirimler = sehirIslem.ParaBirimListele();
        ddlParaBirim.DataSource = paraBirimler;
        ddlParaBirim.DataTextField = "KisaAd";
        ddlParaBirim.DataValueField = "ParaBirimId";
        ddlParaBirim.DataBind();
    }
    protected void BaglaYayinlanmaSure()
    {
        var yayinlanmaSureler = sehirIslem.YayinlanmaSureListele();
        ddlYayinlanmaSure.DataSource = yayinlanmaSureler;
        ddlYayinlanmaSure.DataTextField = "Sure";
        ddlYayinlanmaSure.DataValueField = "YayinlanmaSureId";
        ddlYayinlanmaSure.DataBind();

        if (ddlYayinlanmaSure.Items.Count > 0)
            ddlYayinlanmaSure.SelectedIndex = 0;
    }

    #endregion

    protected void ddlSehirler_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ilceler = sehirIslem.SehirListele(Convert.ToInt32(ddlSehirler.SelectedItem.Value));
        ddlIlceler.DataSource = ilceler;
        ddlIlceler.DataTextField = "Ad";
        ddlIlceler.DataValueField = "SehirId";
        ddlIlceler.DataBind();
    }
    protected void btDevam_Click(object sender, EventArgs e)
    {
        Ilan ilan = new Ilan();


        ilan.Aciklama = fckAciklama.Value;
        ilan.Fiyat = Convert.ToDouble(txbFiyat.Text);
        ilan.IlanBaslik = txbBaslik.Text;
        ilan.IlceId = Convert.ToInt32(ddlIlceler.SelectedValue);
        ilan.SehirId = Convert.ToInt32(ddlSehirler.SelectedValue);
        ilan.TelefonNumaramYayinlansinMi = chbTelefonNumaramYayinlansinMi.Checked;
        ilan.YayinlanmaSureId = Convert.ToInt32(ddlYayinlanmaSure.SelectedValue);
        ilan.KategoriId = Convert.ToInt32(Request.QueryString["Kategori"]);
        ilan.YayinTarih = DateTime.Now;
        ilan.UyeId = ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId;
        ilan.YayinDurumTip = (int)YayinDurumTip.Onaylandi;
        ilan.IlanId = IdAlQueryString();
        ilan.ParaBirimId = Convert.ToInt32(ddlParaBirim.SelectedValue);
        ilan.IlanOzet = txbIlanOzet.Text;
        ilan.IlanTip = Convert.ToInt32(ddlIlanTip.SelectedValue);

        bool ilanEklendiMi = this.ilanIslem.IlanDuzenle(ilan);
        if(ilanEklendiMi)
            Response.Write(Fonksiyon.MesajBox("İlan Başarıyla Düzenlendi", "Ilanlarim.aspx"));
        else
            Response.Write(Fonksiyon.MesajBox("Özür dileriz, ilan düzenleme sırasında bir hata oluştu."));

    }
    protected void btResimleriDuzenle_Click(object sender, EventArgs e)
    {
        ResimleriDuzenle();
    }

    protected void ResimleriDuzenle()
    {
        Response.Redirect("IlanDuzenleResim.aspx?IlanId=" + IdAlQueryString());
    }

}