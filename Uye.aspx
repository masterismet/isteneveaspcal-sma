<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="Uye.aspx.cs" Inherits="Kullanici" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Kullanıcı Bilgileri
    </div>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS;font-size: 13px; padding: 10px">
        <span style="width:180px; font-weight:bold; float:left;">Adı </span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbUyeAd" runat="server" Text=""></asp:Label></span>
        <br />
        <span style="width:180px; font-weight:bold; float:left;">Soyadı </span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbUyeSoyad" runat="server" Text=""></asp:Label></span>
        <br />
        <%--<span style="width:180px; font-weight:bold; float:left;">Telefon </span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbTelefon" runat="server" Text=""></asp:Label></span>
        <br />--%>
        <span style="width:180px; font-weight:bold; float:left;">Üyelik Başlangıç Tarihi </span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbUyelikBaslangicTarih" runat="server" Text=""></asp:Label></span>
        <br />
        <span style="width:180px; font-weight:bold; float:left;">Adres </span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbAdres" runat="server" Text=""></asp:Label></span>
        <br />
        <span style="width:180px; font-weight:bold; float:left;">Meslek </span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbMeslek" runat="server" Text=""></asp:Label></span>
        <br />
        <span style="width:180px; font-weight:bold; float:left;">Hakkında </span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbHakkinda" runat="server" Text=""></asp:Label></span>
        <br />
        <span style="width:180px; font-weight:bold; float:left;">Cinsiyet </span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbCinsiyet" runat="server" Text=""></asp:Label></span>
        <br />
    </div>

    <asp:Button ID="btKullaniciIlanlari" runat="server" 
        Text="Kullanıcının İlanları" onclick="btKullaniciIlanlari_Click" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 130px;"/>
    <hr />
</asp:Content>

