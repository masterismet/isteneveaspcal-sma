<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="SayfaDuzenle.aspx.cs" Inherits="SayfaDuzenle" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSerit" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Sayfa Düzenle
    </div>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <span style="width:75px; font-weight:bold; float:left;">Sayfa</span>
                <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
                <asp:DropDownList ID="ddlSayfa" runat="server" Height="23px" Width="300px" 
                    Border="none" AutoPostBack="True" 
                    onselectedindexchanged="ddlSayfa_SelectedIndexChanged"></asp:DropDownList>
                <br /><br />
                <span style="width:75px; font-weight:bold; float:left;">Başlık</span>
                <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
                <span style="padding-left:3px; width:130px; float:left;"><asp:Label ID="lbBaslik" runat="server" Text=""></asp:Label></span>
                <br /> <br />      
                <span style="width:75px; font-weight:bold; float:left;">Açıklama</span>
                <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
                <FCKeditorV2:FCKeditor ID="fckIcerik" BasePath="fckeditor/" runat="server" Height="300px" Width="605" ToolbarSet="Basic"></FCKeditorV2:FCKeditor>
                <br /><br />

            </ContentTemplate>
        </asp:UpdatePanel>
                        <asp:Button ID="btDuzenle" runat="server" Text="Düzenle" onclick="btDuzenle_Click" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 100px;"/>

    </div>
</asp:Content>

