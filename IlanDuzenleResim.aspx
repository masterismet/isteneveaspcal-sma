<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true"
    CodeFile="IlanDuzenleResim.aspx.cs" Inherits="IlanDuzenleResim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        İlan Resimlerini Düzenle
    </div>
    <div style=" border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <br />
        <asp:Button ID="btIlanaDon" runat="server" Text="İlana Dön" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 100px;" onclick="btIlanaDon_Click" /> <br />
        <br />

    </div>
        

    <asp:GridView ID="grvResimler" runat="server" AutoGenerateColumns="False" CellPadding="4"
        Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="#333333" GridLines="None"
        OnSelectedIndexChanged="grvResimler_SelectedIndexChanged" Width="664px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="IlanFotografId" HeaderText="ResimId" Visible="False">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Resim">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("FotoPath") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("FotoPath") %>' />
                </ItemTemplate>
                <ControlStyle Height="100px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" CancelText="İptal" DeleteText="Sil" EditText="Düzenle" 
                InsertText="Ekle" SelectText="Sil" ShowSelectButton="True" UpdateText="Düzenle" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
        <div id="Resimler">
        <asp:Panel ID="Panel1" runat="server" >
            <asp:FileUpload ID="fuResim" runat="server" />  &nbsp;<asp:Button ID="btResimEkle" 
                runat="server" onclick="btResimEkle_Click" 
                Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 100px;" 
                Text="Ekle" />
            <br/>
        </asp:Panel>


    </div>

</asp:Content>
