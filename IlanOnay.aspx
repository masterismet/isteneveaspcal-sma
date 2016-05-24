<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="IlanOnay.aspx.cs" Inherits="IlanOnay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        İlan Onayla
    </div>
    <div style=" border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <asp:DataList ID="DataList1" runat="server" 
        onitemdatabound="DataList1_ItemDataBound" 
        onitemcommand="DataList1_ItemCommand">
        <ItemTemplate>
            <span style="padding-left:3px;font-size:11px; width:550px; font-weight:bold; float:left;"><a href="javascript:openPopup('IlanOnizle.aspx?IlanId=<%# Eval("IlanId") %>')"><%#Eval("IlanBaslik") %></a> </span>
            <span style="padding-left:3px;font-size:11px; width:5px; padding-right:5px; font-weight:bold; float:left;">:</span>
            <span style="padding-left:3px;font-size:11px; width:150px; float:left;">
                <asp:DropDownList ID="ddlYayinDurumTip" runat="server" Width="150">
                    <asp:ListItem Value="1">Onay Bekliyor</asp:ListItem>
                    <asp:ListItem Value="2">Onaylandı</asp:ListItem>
                    <asp:ListItem Value="3">Reddedildi</asp:ListItem>
                </asp:DropDownList>
            </span>
            <span style="padding-left:3px;font-size:11px; width:150px; float:left;">
                <asp:Button ID="btOnayla" runat="server" Text="İlan Durumunu Güncelle" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 150px;" onclick="btOnayla_Click" />
            </span>
            <br /> 
            <asp:Label ID="lbIlanId" runat="server" Text="" Visible="false"></asp:Label>
            
            
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:DataList>
    </div>
    

</asp:Content>

