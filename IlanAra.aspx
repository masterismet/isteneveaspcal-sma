<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="IlanAra.aspx.cs" Inherits="IlanAra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSerit" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />     
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        İlan Ara
    </div>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:13px; padding:10px">
        <span style="width:100px; float:left;">Arama Kriteri</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <asp:TextBox ID="txbKriter" runat="server" Style=" height: 15px; width: 600px;"></asp:TextBox>
        <br />
        <span style="width:100px; float:left;">Kategori</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <asp:DropDownList ID="ddlKategori" runat="server" Width="600"></asp:DropDownList>
        <br />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <span style="width:100px; float:left;">Şehir</span>
                <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
                <asp:DropDownList ID="ddlSehir" runat="server" Width="600" AutoPostBack="true" 
                    onselectedindexchanged="ddlSehir_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <span style="width:100px; float:left;">İlçe</span>
                <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
                <asp:DropDownList ID="ddlIlce" runat="server" Width="600"></asp:DropDownList>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <span style="width:100px; float:left;">Fiyat Aralığı</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="float:left;"><asp:TextBox ID="txbFiyat1" runat="server" Style=" height: 15px; width: 100px;"></asp:TextBox> TL</span>
        <span style="width:10px; font-weight:bold; float:left; text-align:center;">-</span>
        <span style="float:left;"><asp:TextBox ID="txbFiyat2" runat="server" Style=" height: 15px; width: 100px;"></asp:TextBox> TL</span>
        <br /><br />
        <asp:Button ID="btAra" runat="server" Text="ARA" onclick="btAra_Click" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 730px;"/>
    </div>
    <br/>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Arama Sonuçları
    </div>
    <br/>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:13px; padding:10px">
        <asp:DataList ID="dtlIlanlar" runat="server" RepeatColumns="4" Width="550px">
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
					            <%#Fonksiyon.ParaAna(Convert.ToDouble(Eval("Fiyat"))) %>,<sup><%#Fonksiyon.ParaKusurat(Convert.ToDouble(Eval("Fiyat"))) %></sup>TL
				            </div>

			            </div>

		            </div>

	            </div>
                <%--IlanId,IlanBaslik,IlanOzet,YayinTarih--%>
               <%-- <table style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <div class="makaleustbilgiler">
                                Eklenme Tarihi :
                                <%#Fonksiyon.TarihFormatla(Eval("YayinTarih")) %>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50px; height: 50px" valign="top" rowspan="2">
                            <img src='Content/Images/Site/uyelik.jpg' style="width: 50px; height: 50px; border: none" />
                        </td>
                        <td valign="top">
                            <a class="lgnlink3" href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx">
                                <%#Eval("IlanBaslik") %></a>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="font-family: Trebuchet MS; font-size: 12px; color: #3a3a3a">
                            <p>
                                <%#Eval("IlanOzet") %><a class="lgnlink2" href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx">Devamını
                                    göster</a>
                        </td>
                    </tr>
                </table>--%>
            </ItemTemplate>
        </asp:DataList>

    </div>

</asp:Content>

