using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Kategoriler : System.Web.UI.Page
{    
    #region Değişken

    KategoriIslem kategoriIslem;

    List<Kategori> kategoriler;
    List<IdAd> agacKategoriler;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        if (!IsPostBack)
        {
            KategoriListele();
            KategoriDoldur();
        }
    }
    int katman = 0;
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null || ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeTip != (int)UyeTip.Yonetici)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.kategoriIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Kategori;

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

    protected void KategoriDoldur()
    {
        GetirKategoriler();
        ddlUstKategori.DataSource = this.agacKategoriler;
        ddlUstKategori.DataTextField = "Ad";
        ddlUstKategori.DataValueField = "Id";
        ddlUstKategori.DataBind();
    }
    protected void KategoriListele()
    {
        GetirKategoriler();
        DataList1.DataSource = this.kategoriler;
        DataList1.DataBind();
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            int id = ((Kategori)e.Item.DataItem).KategoriId;
            Label kategoriId = (Label)e.Item.FindControl("lbKategoriId");
            int ustKategoriId = Convert.ToInt32(((Kategori)e.Item.DataItem).UstKategoriId);
            TextBox kategoriAd = (TextBox)e.Item.FindControl("txbKategoriAd");
            CheckBox sil = (CheckBox)e.Item.FindControl("chbSil");

            kategoriAd.Text = ((Kategori)e.Item.DataItem).KategoriAd;
            sil.Checked = ((Kategori)e.Item.DataItem).Sil;

            DropDownList ddlyayinDurumTip = (DropDownList)e.Item.FindControl("ddlUstKategori");
            ddlyayinDurumTip.DataSource = this.agacKategoriler;
            ddlyayinDurumTip.DataValueField = "Id";
            ddlyayinDurumTip.DataTextField = "Ad";
            ddlyayinDurumTip.DataBind();
            for (int i = 0; i < ddlyayinDurumTip.Items.Count; i++)
                if (ddlyayinDurumTip.Items[i].Value == ustKategoriId.ToString())
                {
                    ddlyayinDurumTip.SelectedIndex = i;
                    break;
                }

            kategoriId.Text = id.ToString();
        }
        catch { }
    }
    protected void btOnayla_Click(object sender, EventArgs e)
    {
        bool kaydedildiMi = this.kategoriIslem.KategoriEkle(new Kategori
        {
            KategoriAd = txbKategoriAd.Text,
            Sil = false,
            UstKategoriId = Convert.ToInt32(ddlUstKategori.SelectedItem.Value)
        });
        if (kaydedildiMi)
        {
            Response.Write(Fonksiyon.MesajBox("Kategori Eklendi"));
            KategoriListele();
            Response.Redirect("Kategoriler.aspx");
        }
        else
            Response.Write(Fonksiyon.MesajBox("Özür dileriz, ekleme işlemi sırasında bir sorun ile karşılaşıldı"));

    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.SelectedIndex = e.Item.ItemIndex;

        bool guncellendiMi = this.kategoriIslem.KategoriDuzenle(new Kategori
        {
            KategoriAd = Convert.ToString(((TextBox)DataList1.SelectedItem.FindControl("txbKategoriAd")).Text),
            KategoriId = Convert.ToInt32(((Label)DataList1.SelectedItem.FindControl("lbKategoriId")).Text),
            Sil = Convert.ToBoolean(((CheckBox)DataList1.SelectedItem.FindControl("chbSil")).Checked),
            UstKategoriId = Convert.ToInt32(((DropDownList)DataList1.SelectedItem.FindControl("ddlUstKategori")).SelectedValue)

        });

        if (guncellendiMi)
        {
            Response.Write(Fonksiyon.MesajBox("Kategori Güncellendi"));
            KategoriListele();
        }
        else
            Response.Write(Fonksiyon.MesajBox("Özür dileriz, güncelleme işlemi sırasında bir sorun ile karşılaşıldı"));
        
    }


}