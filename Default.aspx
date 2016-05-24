<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
    <div class="serit">
        <div class="tanitimbg">
            <div class="duyuru1">
                <div class="ilanduyuru">
                    <a href="IlanVerKategoriSec.aspx">
                        <img style="border-style: none; border-color: inherit; border-width: medium; width: 439px;
                            height: 92px;" alt="İlan bırak" class="style1" src="Content/Images/Site/ilanduyuru.png" /></a>
                </div>
                <div class="login">
                    <asp:Panel ID="pnGiris" runat="server">
                        <table style="width: 200px; float: right; font-family: Trebuchet MS; font-size: 11px;
                            color: #544634; margin-top: 15px">
                            <tr>
                                <td colspan="4">
                                    <div class="lgn2">
                                        <a href="SifremiUnuttum.aspx" class="lgnlink">şifremi gönder</a>
                                    </div>
                                    <div class="lgn1">
                                        <a href="UyeOl.aspx" class="lgnlink">yeni üyelik</a>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    K.Adı
                                </td>
                                <td>
                                    :
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txbKullaniciAd" runat="server" Style="border-style: None; height: 22px;
                                        width: 150px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Şifre
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txbSifre" TextMode="Password" runat="server" Style="border-style: None;
                                        height: 22px; width: 84px;"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btGiris" runat="server" Text="Giriş" OnClick="btGiris_Click" Style="color: White;
                                        background-color: #544634; border-style: None; height: 22px; width: 50px;" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnCikis" runat="server">
                        <table style="width: 300px; float: right; font-family: Trebuchet MS; font-size: 11px;
                            color: #544634; margin-top: 15px">
                            <tr>
                                <td colspan="4">
                                    <div class="lgn1">
                                        <a href="Ilanlarim.aspx" class="lgnlink">ilanlarım</a>
                                    </div>
                                    <div class="lgn1">
                                        <a href="Mesajlar.aspx" class="lgnlink">mesajlarım</a>
                                    </div>
                                    <div class="lgn1">
                                        <a href="ProfilDuzenle.aspx" class="lgnlink">profil düzenle</a>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div class="lgn1">
                                        <a href="UyeFavoriIlanlar.aspx" class="lgnlink">favori ilanlarım</a>
                                    </div>
                                    <div class="lgn1">
                                        <a href="UyeFavoriUyeler.aspx" class="lgnlink">favori üyelerim</a>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <%if (((UyeGirisIcerik)Session[SiteTanim.SessionKullanici]).UyeTip == (int)UyeTip.Yonetici)
                                    { %>
                                    <div class="lgn2">
                                        <a href="IlanOnay.aspx" class="lgnlink">ilan onayları</a>
                                    </div>
                                    <div class="lgn2">
                                        <a href="SayfaDuzenle.aspx" class="lgnlink">sayfa düzenle</a>
                                    </div>
                                    <div class="lgn2">
                                        <a href="Kategoriler.aspx" class="lgnlink">kategoriler</a>
                                    </div>
                                    <%} %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="float:left; width:91px; margin-right:5px;">
                                        <asp:Button ID="btCikis" runat="server" Text="Çıkış" OnClick="btCikis_Click" Style=" margin-left:5px; color: White; background-color: #544634; border-style: None; height: 22px; width: 91px;" />
                                    </div>
                                    
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
            <br />
            <div style="margin-top: 150px; text-align: right; padding-right: 20px">
                <a href="http://facebook.com" target="_blank">
                    <img style="border: none" src="Content/Images/Site/facebook.png" /></a> <a href="http://twitter.com"
                        target="_blank">
                        <img style="border: none" src="Content/Images/Site/twitter.png" /></a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" runat="Server">
    <table style="width: 930px">
        <tr>
            <td style="width: 700px" valign="top">
                <asp:DataList ID="dtlIlanlar" runat="server" RepeatColumns="3" Width="680px">
                    <ItemTemplate>
                        <div style="width:225px; height:260px; font-family:Arial, Helvetica, sans-serif; font-size:12px; background-image:url('Content/Images/Site/bg.png')">
		                    <div style="margin-left:10px; margin-right:10px; padding-top:10px; margin-bottom:10px; width:205px; height:220px; ">
			                    <div style="width:205px; height:150px; background-color:white; background-image:url('Content/Images/Site/IlanArka.png')">
				                    <a href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx"><img alt="" src="<%#FotoPath(Eval("FotoPath")) %>" style="width:195px; height:140px; padding:5px 5px 5px 5px; border-style:none;"/></a>
			                    </div>
			                    <div style="width:195px; height:60px; padding-left:5px; padding-right:5px;">
				                    <a href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx" style="color:#333333; text-decoration:none;">
                                        <%#Eval("IlanOzet") %>
                                    </a>
			                    </div>
			                    <div style="width:205px; height:5px;">
				                    <img alt="" src="Content/Images/Site/IlanAraCizgi.png" style="width:205px; height:5px;"/>
			                    </div>

			                    <div style="width:205px; height:25px;">
				                    <div style="width:100px; height:100%; float:left">
					                    <a href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx">
                                            <img alt="" src="Content/Images/Site/IlanIncele.png" style="width:100px; height:25px; border-style:none;"/>
                                        </a>
				                    </div>
				                    <div style="width:105px; height:100%; float:left; text-align:right; color:#D00000; font-size:16px; font-weight:bold;">
					                    <%#Fonksiyon.ParaAna(Convert.ToDouble(Eval("Fiyat"))) %>,<sup><%#Fonksiyon.ParaKusurat(Convert.ToDouble(Eval("Fiyat"))) %></sup> TL
				                    </div>

			                    </div>

		                    </div>

	                    </div>

                        <%--<div style="width:223px; height:330px; font-family:Arial, Helvetica, sans-serif; font-size:14px;">
		                    <div style="width:223px; background-color:#e5e9ed;">
			                    <div style="height:214px; padding-left:15px; padding-right:15px; padding-top:15px; width:193px;">
				                    <img alt="" src="<%#FotoPath(Eval("FotoPath")) %>" style="width:193px; border-color:black; border-width:1px;height:120px; margin-bottom:15px;" />
				                    <a href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx" style="color:gray; text-decoration:none;">
                                        <%#Eval("IlanOzet") %>
                                    </a>
			                    </div>
		                    </div>	
			                    <div style="height:11px; background-image:url('Content/Images/Site/ara.png')">
			                    </div>
		                    <div style="background-color:#e5e9ed;">
			                    <div style="height:75px; padding-left:15px; padding-right:15px; padding-bottom:15px;">
				                    <div style=" width:193px; height:40px;">
					                    <a href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx" style="color:#8093AD; font-size:12px; font-weight:bold; text-decoration:none;"><%#Eval("IlanBaslik") %></a>
				                    </div>
				                    <div style="color:#D00000; font-size:16px; font-weight:bold; text-align:right; width:197px; height:35px; padding-bottom:15px;">
					                    <%#Fonksiyon.ParaAna(Convert.ToDouble(Eval("Fiyat"))) %>,<sup><%#Fonksiyon.ParaKusurat(Convert.ToDouble(Eval("Fiyat"))) %></sup> TL
				                    </div>
			                    </div>	
		                    </div>
	                    </div>--%>

                    </ItemTemplate>
                </asp:DataList>
                <br />
            </td>
            <td valign="top">
                <div style="width:230px; height:39px;">
		            <img alt="" src="Content/Images/Site/vitrin_ilanlari.png" />
	            </div>
               

                <asp:DataList ID="dtlIlanVitrin" runat="server" RepeatColumns="1">
                    <ItemTemplate>
                        <%--IlanId,IlanBaslik,IlanOzet,YayinTarih--%>
                         <div style="width:230px; height:144px; font-family:Arial, Helvetica, sans-serif; font-size:14px;">
                            <div style="width:230px; height:94px;">
                                <div style="width:203px; height: 84px; padding-top:10px; float:left; background-color:#e5e9ed;">
                                    <div style="width:80px; padding-left:13px; float:left;">
                                        <img title='<%#Eval("IlanBaslik") %>' src='<%#FotoPath(Eval("FotoPath")) %>'
                                                style="width: 80px; height: 80px; border: none" />
                                    </div>
                                    <div style="width:110px; height:80px; float:left;">
                                        <div style="width:100%; height:30px; text-align:center; color:#D00000; font-size:16px; font-weight:bold;">
                                             <%#Fonksiyon.ParaAna(Convert.ToDouble(Eval("Fiyat"))) %>,<sup><%#Fonksiyon.ParaKusurat(Convert.ToDouble(Eval("Fiyat"))) %></sup> <%#Eval("ParaBirimi") %>
                                        </div>
                                        <div style="width:100px; padding-left:10px; height:40px; padding-top:5px; padding-bottom:5px; ">
                                            <a href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx" style="color:#8093AD; font-size:12px; font-weight:bold; text-decoration:none;"><%#Eval("IlanBaslik") %></a>
                                        </div>
                                    </div>
                                </div>
                                <div style="width:27px; height:80px; float:left; ">
                                    
                                </div>
                                <div style="width:27px; height:15px; float:left; background-image:url('Content/Images/Site/vitrinbutonust.png');">
                                    
                                </div>
                            </div>
                            <div style="width:230px; height:50px; background-color:#e5e9ed;">
                                <a href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx" style="color:#8093AD; font-size:12px; font-weight:bold; text-decoration:none; border-style:none;">
                                    <img src="Content/Images/Site/vitrinbuton.png" />
                                </a>
                            </div>
                            

		                    <%--<div style="width:350px; background-color:#CFE4EE;padding-left:5px; padding-right:5px; height:120px; color:#534533;">
			                    <div style="width:100px; height:120px; float:left;">
				                    <a href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx">
                                        
                                    </a>
			                    </div>
			                    <div style="width:220px; height:100px; float:left; text-align:center; color:#534533; padding-left:30px;">
				                    <div style="width:220px; height:50px; font-size:18pt; font-weight:bold;">
					                    <%#Fonksiyon.ParaFormatla(Eval("Fiyat")) %> <%#Eval("ParaBirimi") %>
				                    </div>
				                    <div style="width:220px; height:50px;">
                                        <a href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx">
                                            <img src='Content/Images/Site/ilandetaybuton.png'
                                                style="width: 220px; height: 50px; border: none" />
                                        </a>
				                    </div>
			                    </div>
		                    </div>
		                    <div style="width:350px; background-color:#CFE4EE;padding-left:5px; padding-right:5px; height:30px; color:#534533;">
			                    <%#Eval("IlanBaslik") %>
		                    </div>
                            <div style="width:350px;padding-left:5px; padding-right:5px; height:4px;">
			                    <img alt="" src="Content/Images/Site/vitrinara.png" />
		                    </div>--%>
	                    </div> 
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>
