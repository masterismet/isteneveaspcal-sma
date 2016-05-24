<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="IlanOnizle.aspx.cs" Inherits="IlanOnizle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        <asp:Label ID="lbIlanBaslik" runat="server" Text=""></asp:Label>
    </div>
    <div style="height:250px; border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <div style="width:400px; height:100%; float:left;">
            <asp:DataList ID="dtlFotograflar" runat="server" 
                RepeatColumns="3" Width="400px">
                <ItemTemplate>
                    <img src='<%# Eval("Path") %>' alt='Resim' style="width:100px; height:100px;"/>
                </ItemTemplate>
            </asp:DataList>
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
            <span style="padding-left:3px;font-size:11px; width:50px; font-weight:bold; float:left;">Telefon</span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:130px; float:left;"><asp:Label ID="lbTelefon" runat="server" Text=""></asp:Label></span>
            <asp:Label ID="lbUyeId" runat="server" Visible="false" Text=""></asp:Label>
            <br />
            <span style="padding-left:3px;font-size:11px; width:90px; font-weight:bold; float:left;">Üyelik Başlangıcı</span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:90px; float:left;"><asp:Label ID="lbUyelikBaslangicTarih" runat="server" Text=""></asp:Label></span>
            <br /><br />
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

