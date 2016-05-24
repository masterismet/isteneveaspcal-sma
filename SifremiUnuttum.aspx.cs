using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SifremiUnuttum : System.Web.UI.Page
{
    UyeIslem uyeIslem = new UyeIslem();

    protected void Page_Load(object sender, EventArgs e)
    {
        DegiskenKontrol();
    }
    protected void DegiskenKontrol()
    {
        if (Session[SiteTanim.SessionDegisken] == null)
            Session[SiteTanim.SessionDegisken] = new IslemSession();
        this.uyeIslem = ((IslemSession)Session[SiteTanim.SessionDegisken]).Uye;
    }


    protected void btSifreGonder_Click(object sender, EventArgs e)
    {
        object sifre = uyeIslem.UyeSifreGetir(txbEPosta.Text);
        if (sifre != null)
        {

            bool sifreGonderildiMi = Fonksiyon.PostaGonder(txbEPosta.Text, "IstenEve.Com Şifre Yenileme Talebi", "Şifreniz : " + sifre.ToString());
            if (sifreGonderildiMi)
                Response.Write(Fonksiyon.MesajBox("Şifreniz E-Mail adresinize gönderilmiştir. Teşekkür ederiz !", "Default.aspx"));
            else
                Response.Write(Fonksiyon.MesajBox("Mesaj Gönderilirken bir hata oluştu.", "Default.aspx"));
        }
        else
        {
            Label1.Text = "E-mail adresi kayıtlı değil!";
        }
        txbEPosta.Text = "";
        System.Threading.Thread.Sleep(2000);

    }

}