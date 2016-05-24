using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanAra : System.Web.UI.Page
{    
    #region Değişken

    IlanIslem ilanIslem;
    SehirIslem sehirIslem;
    KategoriIslem kategoriIslem;

    List<Kategori> kategoriler;
    List<IdAd> agacKategoriler;

    int katman = 0;


    #endregion

    #region Kategoriler

    protected void KategoriListele()
    {
        
        ddlKategori.DataSource = this.agacKategoriler;
        ddlKategori.DataTextField = "Ad";
        ddlKategori.DataValueField = "Id";
        ddlKategori.DataBind();
    }
    protected void GetirKategoriler()
    {
        katman = 0;
        this.kategoriler = kategoriIslem.KategoriListele().ToKategoriList();
        agacKategoriler = new List<IdAd>();
        agacKategoriler.Add(new IdAd
        {
            Id = 0,
            Ad = "-"
        });
        agacKategoriler.AddRange(GetirAltKategoriler(0));
    }

    protected List<IdAd> GetirAltKategoriler(int ustKategoriId)
    {
        katman++;
        List<IdAd> altKategoriler = new List<IdAd>();
        int katmanx = katman;
        var altlar = this.kategoriler.Where(x => x.UstKategoriId == ustKategoriId).ToList();
        foreach (var alt in altlar)
        {
            if (ustKategoriId == 0)
                altKategoriler.Add(new IdAd { Ad = alt.KategoriAd, Id = alt.KategoriId });
            else
                altKategoriler.Add(new IdAd { Ad = new String('-', katmanx * 2) + alt.KategoriAd, Id = alt.KategoriId });
            if (kategoriler.Where(x => x.UstKategoriId == alt.KategoriId).Count() > 0)
            {
                var altaltKategoriler = GetirAltKategoriler(alt.KategoriId);
                altKategoriler.AddRange(altaltKategoriler);
            }
        }


        return altKategoriler;
    }


    #endregion



    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        GetirKategoriler();
        if (!IsPostBack)
        {
            KategoriListele();
            SehirListele();
            ddlSehir_SelectedIndexChanged(null, null);
        }
    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
        this.sehirIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Sehir;
        this.kategoriIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Kategori;
    }
    protected void btAra_Click(object sender, EventArgs e)
    {
        Ara();
    }
    protected void Ara()
    {
        try
        {
            List<int> kategoriler = new List<int>();
            if (ddlKategori.SelectedIndex > 0)
            {
                kategoriler.Add(Convert.ToInt32(ddlKategori.SelectedItem.Value));
                kategoriler.AddRange(Ara_TumAltKategoriler(Convert.ToInt32(ddlKategori.SelectedItem.Value)));
            }
               
            var ilanlar = this.ilanIslem.IlanAra(new IlanAraKriter
            {
                Kelime = txbKriter.Text,
                SehirId = ddlSehir.SelectedIndex >= 0 ? Convert.ToInt32(ddlSehir.SelectedItem.Value) : 0,
                IlceId = ddlIlce.SelectedIndex >= 0 ? (ddlIlce.SelectedItem.Text == "Tümü" ? 0 : Convert.ToInt32(ddlIlce.SelectedItem.Value)) : 0,
                Fiyat1 = !string.IsNullOrEmpty(txbFiyat1.Text) ? Convert.ToDouble(txbFiyat1.Text) : 0,
                Fiyat2 = !string.IsNullOrEmpty(txbFiyat2.Text) ? Convert.ToDouble(txbFiyat2.Text) : 0,
                Kategoriler = kategoriler
            });
            dtlIlanlar.DataSource = ilanlar;
            dtlIlanlar.DataBind();
        }
        catch (Exception hata)
        { }
        
    }
    private List<int> Ara_TumAltKategoriler(int ustKategoriId)
    {
        List<int> altKategoriler = new List<int>();

        var altlar = this.kategoriler.Where(x => x.UstKategoriId == ustKategoriId).ToList();
        foreach (var alt in altlar)
        {
            altKategoriler.Add(alt.KategoriId);
            if (kategoriler.Where(x => x.UstKategoriId == alt.KategoriId).Count() > 0)
            {
                var altaltKategoriler = Ara_TumAltKategoriler(alt.KategoriId);
                altKategoriler.AddRange(altaltKategoriler);
            }
        }


        return altKategoriler;
    }

    public static string FotoPath(object path)
    {
        if (string.IsNullOrEmpty(Convert.ToString(path)))
            return "Content/Images/Site/ResimYok.png";
        return path.ToString();
    }
    protected void ddlSehir_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSehir.SelectedIndex > 0)
            IlceListele(Convert.ToInt32(ddlSehir.SelectedItem.Value));
    }
    protected void SehirListele()
    {
        var sehirler = this.sehirIslem.SehirListele(0).ToSehirIdAd();
        ddlSehir.DataSource = sehirler;
        ddlSehir.DataTextField = "Ad";
        ddlSehir.DataValueField = "Id";
        ddlSehir.DataBind();
        if(ddlSehir.Items.Count > 0)
            ddlSehir.SelectedIndex = 0;
    }
    protected void IlceListele(int sehirId)
    {
        var ilceler = this.sehirIslem.SehirListele(sehirId).ToSehirIdAd();
        ddlIlce.DataSource = ilceler;
        ddlIlce.DataTextField = "Ad";
        ddlIlce.DataValueField = "Id";
        ddlIlce.DataBind();
        ddlIlce.SelectedIndex = -1;
    }
}