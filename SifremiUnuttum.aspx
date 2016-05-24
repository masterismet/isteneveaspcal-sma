<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="SifremiUnuttum.aspx.cs" Inherits="SifremiUnuttum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; background-color: #f4f9fd; font-family:Trebuchet MS; font-size:12px; padding:3px; padding-left:10px">
    » ŞİFREMİ GÖNDER
    </div>
    <br />

    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; background-color: #f4f9fd; font-family:Trebuchet MS; font-size:12px; padding:3px; padding-left:10px">

        <table>
        <tr>
            <td>E-Mail Adresiniz</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txbEPosta" runat="server" BorderStyle="Solid" 
                    BorderWidth="1px" Width="300px" BorderColor="#CCCCFF"></asp:TextBox>
                <asp:RegularExpressionValidator ID="vlEPosta" runat="server" 
                    ErrorMessage="*" ControlToValidate="txbEPosta" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>
                <asp:Button ID="btSifreGonder" runat="server" BorderColor="#CCCCFF" 
                    BorderStyle="Solid" BorderWidth="1px" OnClick="btSifreGonder_Click" Text="Gönder" 
                    Width="305px" BackColor="#374e6d" ForeColor="White" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    </div>


</asp:Content>

