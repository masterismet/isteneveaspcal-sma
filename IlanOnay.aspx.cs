using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class IlanOnay : System.Web.UI.Page
{    
    #region Değişken

    IlanIslem ilanIslem = new IlanIslem();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
        if (!IsPostBack)
        {
            IlanListele();
        }
    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionKullanici] == null || ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeTip != (int)UyeTip.Yonetici)
            Response.Redirect("Default.aspx");
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.ilanIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan;
    }

    protected void IlanListele()
    {
        var liste = ilanIslem.IlanListeleOnay();
        DataList1.DataSource = liste;
        DataList1.DataBind();
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString());
            int yayinDurumTip = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString());
            Label ilanId = (Label)e.Item.FindControl("lbIlanId");
            DropDownList ddlyayinDurumTip = (DropDownList)e.Item.FindControl("ddlYayinDurumTip");
            for (int i = 0; i < ddlyayinDurumTip.Items.Count; i++)
                if(ddlyayinDurumTip.Items[i].Value == yayinDurumTip.ToString())
                {
                    ddlyayinDurumTip.SelectedIndex = i;
                    break;
            }

            ilanId.Text = id.ToString();
        }
        catch { }
    }
    protected void btOnayla_Click(object sender, EventArgs e)
    {

    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.SelectedIndex = e.Item.ItemIndex;
        int yayinDurumTip = Convert.ToInt32(((DropDownList)DataList1.SelectedItem.FindControl("ddlYayinDurumTip")).SelectedValue);
        int ilanId = Convert.ToInt32(((Label)DataList1.SelectedItem.FindControl("lbIlanId")).Text);
        bool guncellendiMi = ilanIslem.IlanDurumGuncelle(ilanId, yayinDurumTip);
        if (guncellendiMi)
        {
            Response.Write(Fonksiyon.MesajBox("İlan Güncellendi"));
            IlanListele();
        }
        else
            Response.Write(Fonksiyon.MesajBox("Özür dileriz, silme işlemi sırasında bir sorun ile karşılaşıldı"));

    }
}