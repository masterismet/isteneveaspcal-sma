<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="UyeGiris.aspx.cs" Inherits="UyeGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    Kullanıcı Adı : 
    <asp:TextBox ID="txbKullaniciAd" runat="server"></asp:TextBox>
    <br />
    Şifre : 
    <asp:TextBox ID="txbSifre" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btGiris" runat="server" Text="Giriş" onclick="btGiris_Click" />
</asp:Content>

