<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="UyeFavoriUyeler.aspx.cs" Inherits="UyeFavoriUyeler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Favori Üyeleirm
    </div>
    <br />
    <asp:DataList ID="dtlUyeler" runat="server"  Width="550px">
        <ItemTemplate>
            <div style=" border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
                <a href='Uye.aspx?Uye=<%# Eval("UyeId") %>' style="text-decoration:none;"><img src="Content/Images/Site/Kullanici_Profili.png" width="16" height="16" style="padding-right:5px;"/><b><%# Eval("AdSoyad") %></a></b>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
