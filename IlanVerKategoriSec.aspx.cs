using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanVerKategoriSec : System.Web.UI.Page
{
    #region Değişkenler

    private int sonListBoxId = 10;
    private string listboxOnAd = "lsbKategori";
    KategoriIslem kategoriIslem = new KategoriIslem();

    #endregion

    #region Events

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[SiteTanim.SessionKullanici] == null)
            Response.Redirect("Default.aspx");

        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.kategoriIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Kategori;

        if (!IsPostBack)
            KategoriListele(0, lsbKategori1);
    }

    #endregion

    #region Kategori Listleme

    protected void lsbKategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBox secilenListBox = (ListBox)sender;
        ListBox olusacakListBox = new ListBox();

        foreach (Control item in Panel1.Controls)
        {
            if (item is ListBox)
            {
                if (item.ID == listboxOnAd + (Convert.ToInt32(secilenListBox.ID.Substring(listboxOnAd.Length)) + 1).ToString())
                {
                    olusacakListBox = (ListBox)item;
                    break;
                }
            }
        }


        KategoriListele(Convert.ToInt32(secilenListBox.SelectedItem.Value), olusacakListBox);
    }
    protected void KategoriListele(int ustKategoriId, ListBox listBox)
    {
        if (listBox.ID.Substring(listboxOnAd.Length) != sonListBoxId.ToString())
        {
            foreach (Control item in Panel1.Controls)
            {
                if (item is ListBox)
                {
                    if (Convert.ToInt32(item.ID.Substring(listboxOnAd.Length)) > Convert.ToInt32(listBox.ID.Substring(listboxOnAd.Length)))
                    {
                        ((ListBox)item).Visible = false;
                        ((ListBox)item).SelectedIndex = -1;
                    }
                }
            }
        }

        var dataSource = this.kategoriIslem.KategoriListele(ustKategoriId);
        if (dataSource == null || dataSource.Rows.Count == 0)
        {
            btKategoriTamam.Enabled = true;
            listBox.Visible = false;
        }
        else
        {
            listBox.DataSource = this.kategoriIslem.KategoriListele(ustKategoriId);
            listBox.DataTextField = "KategoriAd";
            listBox.DataValueField = "KategoriId";
            listBox.DataBind();
            listBox.Visible = true;
            btKategoriTamam.Enabled = false;
        }
    }

    #endregion


    protected void btKategoriTamam_Click(object sender, EventArgs e)
    {
        string kategoriId = GetirKategoriId();
        if (kategoriId != "")
            Response.Redirect("IlanVer.aspx?Kategori=" + kategoriId);
    }
    protected string GetirKategoriId()
    {
        string kategoriId = "";
        foreach (Control item in Panel1.Controls)
        {
            if (item is ListBox && !item.Visible)
                break;
            if (item is ListBox && item.Visible)
                kategoriId = ((ListBox)item).SelectedItem.Value.ToString();
        }
        return kategoriId;
    }

    #endregion

}