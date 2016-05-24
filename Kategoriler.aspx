<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="Kategoriler.aspx.cs" Inherits="Kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSerit" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Kategori İşlemleri
    </div>

    <div style=" border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <div style="font-weight:bold; font-size:16px;">
            <span style="padding-left:3px;width:300px; font-weight:bold; float:left;">
                Kategori Adı<hr />
            </span>
            <span style="padding-left:16px; width:370px; float:left;">
                Üst Kategori<hr />
            </span>
            <span style="padding-left:3px;width:40px; float:left;">
                Sil<hr />
            </span>
            <span style="padding-left:3px;width:150px; float:left;">
                İşlem<hr />
            </span>
        </div>
        <br />
        

        <asp:DataList ID="DataList1" runat="server" 
        onitemdatabound="DataList1_ItemDataBound" 
        onitemcommand="DataList1_ItemCommand">
        <ItemTemplate>
            <span style="padding-left:3px;font-size:11px; width:300px; font-weight:bold; float:left;">
                <asp:TextBox ID="txbKategoriAd" runat="server" Width="295"></asp:TextBox>
            </span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:370px; float:left;">
                <asp:DropDownList ID="ddlUstKategori" runat="server" Width="360">
                </asp:DropDownList>
            </span>
            <span style="padding-left:3px;font-size:11px; width:40px; float:left;">
                <asp:CheckBox ID="chbSil" runat="server" Text="Sil" />
            </span>
            <span style="padding-left:3px;font-size:11px; width:150px; float:left;">
                <asp:Button ID="btOnayla" runat="server" Text="Kategoriyi Güncelle" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 150px;"  />
            </span>
            <br /> 
            <asp:Label ID="lbKategoriId" runat="server" Text="" Visible="false"></asp:Label>
            
            
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:DataList>
    </div>
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Kategori Ekle
    </div>

    <div style=" border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <span style="padding-left:3px;font-size:11px; width:300px; font-weight:bold; float:left;">
            <asp:TextBox ID="txbKategoriAd" runat="server" Width="295"></asp:TextBox>
        </span>
        <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
        <span style="padding-left:3px;font-size:11px; width:370px; float:left;">
            <asp:DropDownList ID="ddlUstKategori" runat="server" Width="360">
            </asp:DropDownList>
        </span>
        <span style="padding-left:46px;font-size:11px; width:150px; float:left;">
            <asp:Button ID="btOnayla" runat="server" Text="Kategori Ekle" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 150px;" onclick="btOnayla_Click" />
        </span>
        <br /> 
    </div>
    
</asp:Content>

