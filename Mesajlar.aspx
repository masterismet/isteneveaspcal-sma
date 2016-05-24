<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="Mesajlar.aspx.cs" Inherits="Mesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Mesajlar
    </div>
    <br />
    <asp:DataList ID="dtlMesajlar" runat="server"  Width="550px">
        <ItemTemplate>
            <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
                <%# Eval("Baslik") %>
            </div>
            <div style=" border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
                <%# Eval("Mesaj") %>
                <hr />
                <span style="padding-left:3px;font-size:11px; width:60px; font-weight:bold; float:left;">Gönderen</span>
                <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
                <span style="padding-left:3px;font-size:11px; width:100px; float:left;"><a href='Uye.aspx?Uye=<%# Eval("UyeId") %>'><%# Eval("AdSoyad") %></a></span>
                <br />                                   
                <span style="padding-left:3px;font-size:11px; width:60px; font-weight:bold; float:left;">Tarih</span>
                <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
                <span style="padding-left:3px;font-size:11px; width:100px; float:left;"><%# Fonksiyon.TarihFormatla(Eval("Tarih")) %></span>
                <br />
                <div class="lgn1">
                    <a href="MesajGonder.aspx?UyeId=<%# Eval("UyeId") %>" class="lgnlink">Cevap Gönder</a>
                </div>
                
            </div>
            <br />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

