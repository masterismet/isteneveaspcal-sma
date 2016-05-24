<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IletisimPopup.aspx.cs" Inherits="IletisimPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 640px; height: 480px; font-family:Segoe UI; font-size:12px;">
        <div style="padding-left:160px; padding-right:160px; width:300px; height:40px;font-size:14px; font-weight:bold; text-align:center;">
            İletişim Formu
        </div>
        <div style="padding-left:160px; padding-right:160px; width:300px;">
            <div style="width:100px; float:left; font-weight:bold;">
                Adı - Soyadı
            </div>
            <div style="width:200px; float:left;">
                <asp:TextBox ID="tbAdSoyad" runat="server" Width="200"></asp:TextBox>
            </div>
        </div>    
        <div style="padding-left:160px; padding-right:160px; width:300px;">
            <div style="width:100px; float:left; font-weight:bold;">
                E-Mail
            </div>
            <div style="width:200px; float:left;">
                <asp:TextBox ID="tbEMail" runat="server" Width="200"></asp:TextBox>
            </div>
        </div>  
        <div style="padding-left:160px; padding-right:160px; width:300px;">
            <div style="width:100px; float:left; font-weight:bold;">
                Telefon
            </div>
            <div style="width:200px; float:left;">
                <asp:TextBox ID="tbTelefon" runat="server" Width="200"></asp:TextBox>
            </div>
        </div>  
        <div style="padding-left:160px; padding-right:160px; width:300px;">
            <div style="width:100px; float:left; font-weight:bold;">
                Mesaj
            </div>
            <div style="width:200px; float:left;">
                <asp:TextBox ID="tbMesaj" TextMode="MultiLine" runat="server" Width="200" Height="100"></asp:TextBox>
            </div>
        </div>  
        <div style="padding-left:160px; padding-right:160px; width:300px;">
            <asp:Button ID="btGonder" runat="server" Text="Gönder" 
                style="color: White; background-color: #544634; border-style: None; height: 22px; width: 300px;" 
                onclick="btGonder_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
