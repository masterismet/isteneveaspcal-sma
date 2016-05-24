<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="MesajGonder.aspx.cs" Inherits="MesajGonder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Mesaj Gönder
    </div>
    <div style=" border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <span style="padding-left:3px;font-size:11px; width:100px; font-weight:bold; float:left;">Üye Adı</span>
        <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
        <span style="padding-left:3px;font-size:11px; width:130px; float:left;"><asp:Label ID="lbUyeAd" runat="server" Text=""></asp:Label></span>
        <br /><br />   
        <span style="padding-left:3px;font-size:11px; width:100px; font-weight:bold; float:left;">Üye Soyadı</span>
        <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
        <span style="padding-left:3px;font-size:11px; width:130px; float:left;"><asp:Label ID="lbUyeSoyad" runat="server" Text=""></asp:Label></span>
        <asp:Label ID="lbUyeId" Visible="false" runat="server" Text=""></asp:Label>
        <br /><br />   
        <span style="padding-left:3px;width:100px; font-weight:bold; font-size:11px; font-weight:bold; float:left;">Başlık</span>
        <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
        <asp:TextBox ID="txbBaslik" runat="server" Style=" height: 15px; width: 605px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rqvBaslik" runat="server" ErrorMessage="*" ControlToValidate="txbBaslik" ForeColor="Red" ></asp:RequiredFieldValidator>
        <br /><br />
        <span style="padding-left:3px;width:100px; font-weight:bold; font-size:11px; font-weight:bold; float:left;">İlan Özeti</span>
        <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
        <asp:TextBox ID="txbMesaj" runat="server" TextMode="MultiLine" Style=" height: 80px; width: 600px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txbMesaj" ForeColor="Red" ></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="btMesajGonder" runat="server" Text="Gönder" onclick="btMesajGonder_Click" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 100px;"/>
    </div>

</asp:Content>

