<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="IlanDetay.aspx.cs" Inherits="IlanDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function resimGoster(path) {
            var img = new Image();
            var x = 400;
            var y = 200;
            var ihtml = "";

            img.onload = function () {
                if (this.width > this.height * 2) {
                    y = (x / this.width) * this.height;
                }
                else if (this.width < this.height * 2) {
                    x = (y / this.height) * this.width;
                }
                
            }
            img.src = path;

            ihtml = "<img id=\"resim\" width=\"" + x  + "\" height=\"" + y + "\" src=\"" + path+ "\" />";

            document.getElementById("resimdiv").innerHTML = ihtml;
        }
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        <asp:Label ID="lbIlanBaslik" runat="server" Text=""></asp:Label>
    </div>
    <div style="height:340px; border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <div style="width:400px; height:100%; float:left;">
            <div id="resimdiv" style="width:400px; background-image: url('images/loading.gif');background-repeat: no-repeat; background-position: center;">
                <asp:Image ID="imgResim" runat="server" Width="400px" Height="200px" />
		    </div>
            <div style="margin-top: 15px;">
                <asp:DataList ID="dtlFotograflar" runat="server" 
                    RepeatColumns="6" Width="400px">
                    <ItemTemplate>
                        <a href="javascript:;" onclick="resimGoster('<%# Eval("Path") %>');"><img alt="" src="<%# Eval("Path") %>" width="60" height="60" /></a>
                    </ItemTemplate>
                </asp:DataList>
		    </div>



            
        </div>
        <div style="width:280px; height:100%; float:left; border-style: solid; border-width: thin; border-color: #bff0ff;">
            <div style="border-style: solid; text-align:center; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; padding:3px; color:#544634; font-weight:bold">
                <asp:Label ID="lbFiyat" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <span style="padding-left:3px;font-size:11px; width:250px; font-weight:bold; float:left;"><asp:Label ID="lbIlIlce" runat="server" Text=""></asp:Label></span>
            <br />
            <span style="padding-left:3px;font-size:11px; width:70px; font-weight:bold; float:left;">İlan Tarihi</span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:150px; float:left;"><asp:Label ID="lbIlanTarih" runat="server" Text=""></asp:Label></span>
             <br />
            <span style="padding-left:3px;font-size:11px; width:70px; font-weight:bold; float:left;">İlan Türü</span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:150px; float:left;"><asp:Label ID="lbIlanTip" runat="server" Text=""></asp:Label></span>
            
        </div>
        <div style="width:200px; height:100%; float:left; border-style: solid; border-width: thin; border-color: #bff0ff;">
            <div style="border-style: solid; text-align:center; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; padding:3px; color:#544634; font-weight:bold">
                Kullanıcı Bilgileri
            </div>
            <span style="padding-left:3px;font-size:11px; width:50px; font-weight:bold; float:left;">Adı</span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:130px; float:left;"><asp:Label ID="lbUyeAd" runat="server" Text=""></asp:Label></span>
            <br />                        
            <span style="padding-left:3px;font-size:11px; width:50px; font-weight:bold; float:left;">Soyadı</span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:130px; float:left;"><asp:Label ID="lbUyeSoyad" runat="server" Text=""></asp:Label></span>
            <br />                        
            <%--<span style="padding-left:3px;font-size:11px; width:50px; font-weight:bold; float:left;">Telefon</span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:130px; float:left;"><asp:Label ID="lbTelefon" runat="server" Text=""></asp:Label></span>
            <br />--%>
            <asp:Label ID="lbUyeId" runat="server" Visible="false" Text=""></asp:Label>
            
            <span style="padding-left:3px;font-size:11px; width:90px; font-weight:bold; float:left;">Üyelik Başlangıcı</span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:90px; float:left;"><asp:Label ID="lbUyelikBaslangicTarih" runat="server" Text=""></asp:Label></span>
            <br /><br />
            <span style="padding-left:50px;">
                <asp:Button ID="btMesajGonder" runat="server" Text="Mesaj Gönder" onclick="btMesajGonder_Click" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 100px;"/>
            </span>
            <br /><br />
            <span style="padding-left:3px; width:16px; float:left;">
                <img src="Content/Images/Site/Kullanici_Profili.png" width="16" height="16" /></span>
            <span style="padding-left:3px;font-size:11px; width:90px; float:left; text-decoration:none;">
            <asp:LinkButton ID="lnbKullaniciProfili" runat="server" 
                onclick="lnbKullaniciProfili_Click">Kullanıcı Profili</asp:LinkButton></span>
            <br />
            <span style="padding-left:3px; width:16px; float:left;">
                <img src="Content/Images/Site/DigerIlanlar.png" width="16" height="16" /></span>
            <span style="padding-left:3px;font-size:11px; width:140px; float:left; text-decoration:none;">
            <asp:LinkButton ID="lnbKullanicininDigerIlanlari" runat="server" 
                onclick="lnbKullanicininDigerIlanlari_Click">Kullanıcının Diğer İlanları</asp:LinkButton></span>
            <br />
            <%--Favori Satıcılarına ve Favori İlanlarına Ekleme İşlemi--%>

                <% 
        if (Request.QueryString["IlanId"] != null && Session[SiteTanim.SessionKullanici] != null)
        {
            if (Session[SiteTanim.SessionDegisken] == null)
                Session[SiteTanim.SessionDegisken] = new IslemSession();
            if (((IslemSession)Session[SiteTanim.SessionDegisken]).Ilan.IlanFavoriMi(Convert.ToInt32(Request.QueryString["IlanId"]), ((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId))
            {//Favorim ise
                %>
                <span style="padding-left:3px; width:16px; float:left;">
                    <img src="Content/Images/Site/Ilan_Favori_Cikar.png" width="16" height="16" /></span>
                <span style="padding-left:3px;font-size:11px; width:150px; float:left; text-decoration:none;">
                <asp:LinkButton ID="lbtFavorileriIlanlarimdanCikar1" runat="server" 
                    onclick="btFavorileriIlanlarimaEkle_Click">Favori İlanlarımdan Çıkar</asp:LinkButton></span>

                <%
        }
            else
            {//Favorim Değilse
                 %>
                 <span style="padding-left:3px; width:16px; float:left;">
                    <img src="Content/Images/Site/Ilan_Favori_Ekle.png" width="16" height="16" /></span>
                <span style="padding-left:3px;font-size:11px; width:150px; float:left; text-decoration:none;">
                <asp:LinkButton ID="lbtFavorileriIlanlarimaEkle2" runat="server" 
                    onclick="btFavorileriIlanlarimaEkle_Click">Favori İlanlarıma Ekle</asp:LinkButton></span>

                <%
        }
        }
        else
        {//Üye giriş yapmadıysa
         %>
                 <span style="padding-left:3px; width:16px; float:left;">
                    <img src="Content/Images/Site/Ilan_Favori_Ekle.png" width="16" height="16" /></span>
                <span style="padding-left:3px;font-size:11px; width:150px; float:left; text-decoration:none;">
                <asp:LinkButton ID="lbtFavorileriIlanlarimaEkle3" runat="server" 
                    onclick="btFavorileriIlanlarimaEkle_Click">Favori İlanlarıma Ekle</asp:LinkButton></span>
                <%
                }
                %>
                <br />
                <% 
                    if (Session[SiteTanim.SessionKullanici] != null)
                    {
                        if (Session[SiteTanim.SessionDegisken] == null)
                            Session[SiteTanim.SessionDegisken] = new IslemSession();
                        if (((IslemSession)Session[SiteTanim.SessionDegisken]).Uye.UyeFavoriMi((((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeId),Convert.ToInt32(lbUyeId.Text)))
                        {//Favorim ise
                %>
                <span style="padding-left:3px; width:16px; float:left;">
                    <img src="Content/Images/Site/Kullanici_Favori_Cikar.png" width="16" height="16" /></span>
                <span style="padding-left:3px;font-size:11px; width:150px; float:left; text-decoration:none;">
                <asp:LinkButton ID="lbtFavoriKullanicilarimdanCikar1" runat="server" 
                    onclick="btFavoriKullanicilarimaEkle_Click">Favori Kullanıcılarıma Çıkar</asp:LinkButton></span>
                <%
                    }
                        else
                        {//Favorim Değilse
                                %>
                                <span style="padding-left:3px; width:16px; float:left;">
                                <img src="Content/Images/Site/Kullanici_Favori_Ekle.png" width="16" height="16" /></span>
                            <span style="padding-left:3px;font-size:11px; width:150px; float:left; text-decoration:none;">
                            <asp:LinkButton ID="lbtFavoriKullanicilarimaEkle1" runat="server" 
                                onclick="btFavoriKullanicilarimaEkle_Click">Favori Kullanıcılarıma Ekle</asp:LinkButton></span>
                <%
                    }
                }
                else
                {//Üye giriş yapmadıysa
                 %>
                <span style="padding-left:3px; width:16px; float:left;">
                    <img src="Content/Images/Site/Kullanici_Favori_Ekle.png" width="16" height="16" /></span>
                <span style="padding-left:3px;font-size:11px; width:150px; float:left; text-decoration:none;">
                <asp:LinkButton ID="lbtFavoriKullanicilarimaEkle2" runat="server" 
                    onclick="btFavoriKullanicilarimaEkle_Click">Favori Kullanıcılarıma Ekle</asp:LinkButton></span>
                <%
                }
                %>

            <%--Favori Satıcılarına ve Favori İlanlarına Ekleme İşlemi--%>
        </div>
    </div>
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Açıklama
    </div>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <asp:Label ID="lbAciklama" runat="server" Text=""></asp:Label>
    </div>
    <br />
    
    <br />
    <hr />

</asp:Content>

