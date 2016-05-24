using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IletisimPopup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btGonder_Click(object sender, EventArgs e)
    {
        Fonksiyon.PostaGonder("info@isteneve.com", "İletişim Mesajı",
            "Adı-Soyadı : " + tbAdSoyad.Text + "<br/>Telefon : " + tbTelefon.Text +
            "<br/>E-Posta : " + tbEMail.Text + "<br/> Mesaj : " + tbMesaj.Text);
    }
}