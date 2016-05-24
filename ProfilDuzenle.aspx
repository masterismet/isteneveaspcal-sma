<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="ProfilDuzenle.aspx.cs" Inherits="ProfilDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <div style="border-style: solid; border-width: thin; border-color: #D3D3D3; background-color: #F9F9F9;
        font-family: Trebuchet MS; font-size: 12px; padding: 3px; padding-left: 10px; font-weight:bold;">
        » YENİ ÜYELİK
    </div>
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #D3D3D3; background-color: #F9F9F9;
        font-family: Trebuchet MS; font-size: 12px; padding: 3px; padding-left: 10px">
        <table>
            <tr>
                <td style="font-family: Arial; font-size: small;">
                    Adınız
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txbAd" runat="server" BorderColor="#D3D3D3" BorderStyle="Solid"
                        BorderWidth="1px" Font-Size="14px" Height="20px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbAd"
                        ErrorMessage="*" Style="font-family: Arial; font-size: x-small; font-weight: 700;
                        color: #000000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="font-family: Arial; font-size: small;">
                    Soyadınız
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txbSoyad" runat="server" BorderColor="#D3D3D3" BorderStyle="Solid"
                        BorderWidth="1px" Font-Size="14px" Height="20px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txbSoyad"
                        ErrorMessage="*" Style="font-weight: 700; font-size: x-small; font-family: Arial;
                        color: #000000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="font-family: Arial; font-size: small;">
                    Telefon</td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlTelefonKod" runat="server">
                    </asp:DropDownList>
&nbsp;<asp:TextBox ID="txbTelefon" runat="server" BorderColor="#D3D3D3" BorderStyle="Solid"
                        BorderWidth="1px" Font-Size="14px" Height="20px" Width="118px"></asp:TextBox>
                    <asp:CheckBox ID="chbTelefonGorunsunMu" runat="server" Text="Görünsün Mü" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txbTelefon"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txbTelefon"
                        ErrorMessage="Geçerli bir telefon numarası giriniz" Style="font-family: Arial; font-size: x-small;
                        font-weight: 700; color: #CCCCCC" 
                        ValidationExpression="^([0-9]){7}$"></asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td style="font-family: Arial; font-size: small;">
                    Meslek
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txbMeslek" runat="server" BorderColor="#D3D3D3" BorderStyle="Solid"
                        BorderWidth="1px" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txbMeslek"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="font-family: Arial; font-size: small;">
                    Sehir
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlSehirler" runat="server" Height="23px" Width="150px" Border="none">
                        <asp:ListItem Selected="True" Value="0">Şehir Seçiniz</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlSehirler"
                        ErrorMessage="*" Style="font-family: Arial; font-size: x-small; font-weight: 700;
                        color: #000000"></asp:RequiredFieldValidator>
                    <span class="style209">&nbsp;</span>
                </td>
            </tr>
            <tr>
                <td style="width: 120px; font-family: Arial; font-size: small;" valign="top">
                    Adres
                </td>
                <td style="width: 8px" valign="top">
                    :
                </td>
                <td valign="top">
                    <asp:TextBox ID="txbAdres" runat="server" BorderColor="#D3D3D3" BorderStyle="Solid"
                        BorderWidth="1px" Height="174px" Style="margin-left: 0px" TextMode="MultiLine"
                        Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txbAdres"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 120px; font-family: Arial; font-size: small;" valign="top">
                    Kısaca Siz
                </td>
                <td style="width: 8px" valign="top">
                    :
                </td>
                <td valign="top">
                    <asp:TextBox ID="txbHakkinda" runat="server" BorderColor="#D3D3D3" BorderStyle="Solid"
                        BorderWidth="1px" Height="174px" Style="margin-left: 0px" TextMode="MultiLine"
                        Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbHakkinda"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="font-family: Arial; font-size: small;">
                    Cinsiyet
                </td>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCinsiyet" runat="server" Height="23px" Width="130px" Border="none">
                        <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                        <asp:ListItem Value="1">Bayan</asp:ListItem>
                        <asp:ListItem Value="2">Erkek</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCinsiyet"
                        ErrorMessage="*" Style="font-family: Arial; font-size: x-small; font-weight: 700;
                        color: #000000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    &nbsp;
                </td>
                <td style="width: 8px">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnUyeOl" runat="server" Height="30px" OnClick="btnUyeOl_Click" Text="Düzenle"
                        Width="250px" />
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    &nbsp;
                </td>
                <td style="width: 8px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <br />

</asp:Content>

