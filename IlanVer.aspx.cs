using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class IlanVer : System.Web.UI.Page
{
    #region Değişken

    SehirIslem sehirIslem = new SehirIslem();
    IlanIslem ilanIslem = new IlanIslem();
    List<FileUpload> resimUploadlar = new List<FileUpload>();
    private string fileUploadOnAd = "fuResim";

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        ResimUploadlariEkle();
        IlanVerUyeBilgiDoldur();
        if (!IsPostBack)
        {
            SiteAyar.Path = Server.MapPath("App_Data");
            BaglaSehir(0);
            BaglaParaBirim();
            BaglaYayinlanmaSure();
        }
    }
    protected void ResimUploadlariEkle()
    {
        resimUploadlar.Add(fuResim0);
        resimUploadlar.Add(fuResim1);
        resimUploadlar.Add(fuResim2);
        resimUploadlar.Add(fuResim3);
        resimUploadlar.Add(fuResim4);
        resimUploadlar.Add(fuResim5);
        resimUploadlar.Add(fuResim6);
        resimUploadlar.Add(fuResim7);
        resimUploadlar.Add(fuResim8);
        resimUploadlar.Add(fuResim9);

    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null || Request.QueryString["Kategori"] == null)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.sehirIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Sehir;
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
    }
    protected void IlanVerUyeBilgiDoldur()
    {
        var ilanUyeBilgi = this.ilanIslem.IlanVerUyeBilgiGetir(Convert.ToInt32(Request.QueryString["Kategori"]), ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId);
        lbAdSoyad.Text = ilanUyeBilgi.Rows[0]["Ad"].ToString() + " " + ilanUyeBilgi.Rows[0]["Soyad"].ToString();
        lbTelefon.Text = Convert.ToBoolean(ilanUyeBilgi.Rows[0]["TelefonGorunsunMu"]) ? ("+90" + ilanUyeBilgi.Rows[0]["TelefonKod"].ToString() + "-" + ilanUyeBilgi.Rows[0]["TelefonNo"].ToString()) : "-";
        lbKategori.Text = ilanUyeBilgi.Rows[0]["KategoriAd"].ToString();
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


    protected void btResimEkle_Click(object sender, EventArgs e)
    {
        string sonVisibleTrueFileUploadId = resimUploadlar.Where(x => x.Visible).OrderByDescending(x => x.ID).FirstOrDefault().ID;
        sonVisibleTrueFileUploadId = sonVisibleTrueFileUploadId.Substring(fileUploadOnAd.Length);
        try
        {
            resimUploadlar.Where(x => x.ID == fileUploadOnAd + (Convert.ToInt32(sonVisibleTrueFileUploadId) + 1).ToString()).FirstOrDefault().Visible = true;
        }
        catch{}
    }


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
        if (Convert.ToInt32(ddlIlanTip.SelectedItem.Value) > 0)
        {
            Ilan ilan = new Ilan();
            foreach (FileUpload item in this.resimUploadlar)
            {
                string resimPath = item.FileName;
                if (!string.IsNullOrEmpty(resimPath))
                {
                    resimPath = DosyaIslem.Kaydet(item, @"Content\Images\IlanResim\", Fonksiyon.YeniGuid());
                    resimPath = "Content/Images/IlanResim/" + resimPath;
                    ilan.Fotograflar.Add(resimPath);
                }
            }

            ilan.Aciklama = fckAciklama.Value;
            ilan.Fiyat = Convert.ToDouble(txbFiyat.Text);
            ilan.IlanOzet = txbIlanOzet.Text;
            ilan.IlanBaslik = txbBaslik.Text;
            ilan.IlceId = Convert.ToInt32(ddlIlceler.SelectedValue);
            ilan.SehirId = Convert.ToInt32(ddlSehirler.SelectedValue);
            ilan.TelefonNumaramYayinlansinMi = false;// chbTelefonNumaramYayinlansinMi.Checked;
            ilan.YayinlanmaSureId = Convert.ToInt32(ddlYayinlanmaSure.SelectedValue);
            ilan.KategoriId = Convert.ToInt32(Request.QueryString["Kategori"]);
            ilan.YayinTarih = DateTime.Now;
            ilan.UyeId = ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId;
            ilan.YayinDurumTip = (int)YayinDurumTip.Onaylandi;
            ilan.ParaBirimId = Convert.ToInt32(ddlParaBirim.SelectedValue);
            ilan.IlanTip = Convert.ToInt32(ddlIlanTip.SelectedValue);

            bool ilanEklendiMi = this.ilanIslem.IlanEkle(ilan);
            if (ilanEklendiMi)
                Response.Write(Fonksiyon.MesajBox("İlanınız başarıyla eklendi", "Default.aspx"));
            else
                Response.Write(Fonksiyon.MesajBox("Özür dileriz, silme işlemi sırasında bir sorun ile karşılaşıldı"));
        }
        else
            Response.Write(Fonksiyon.MesajBox("Lütfen ilan türünü seçiniz"));
    }

}
