<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true"
    CodeFile="IlanVer.aspx.cs" Inherits="IlanVer" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />    
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        İletişim Bilgileri
    </div>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS;
        font-size: 13px; padding: 10px">
        <span style="width:75px; font-weight:bold; float:left;">Adı Soyadı</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbAdSoyad" runat="server" Text=""></asp:Label></span>
        <br />
        <span style="width:75px; font-weight:bold; float:left;">Telefon</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:200px; float:left;"><asp:Label ID="lbTelefon" runat="server" Text=""></asp:Label></span>
        <br />
    </div>
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        İlan Detayları
    </div>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px">
        <span style="width:75px; font-weight:bold; float:left;">Kategori</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <span style="width:300px; float:left;"><asp:Label ID="lbKategori" runat="server" Text=""></asp:Label></span>
        <br /><br />
        <span style="width:75px; font-weight:bold; float:left;">İlan Başlığı</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <asp:TextBox ID="txbBaslik" runat="server" Style=" height: 15px; width: 600px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rqvBaslik" runat="server" ErrorMessage="*" ControlToValidate="txbBaslik" ForeColor="Red" ></asp:RequiredFieldValidator>
        <br /><br />
        <span style="width:75px; font-weight:bold; float:left;">İlan Özeti</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <asp:TextBox ID="txbIlanOzet" runat="server" TextMode="MultiLine" Style=" height: 80px; width: 600px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txbIlanOzet" ForeColor="Red" ></asp:RequiredFieldValidator>
        <br /><br />
        <span style="width:75px; font-weight:bold; float:left;">Açıklama</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <FCKeditorV2:FCKeditor ID="fckAciklama" BasePath="fckeditor/" runat="server" Height="300px" Width="605" ToolbarSet="Basic"></FCKeditorV2:FCKeditor>
        <br /><br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <span style="width:75px; font-weight:bold; float:left;">Şehir</span>
                <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
                <asp:DropDownList ID="ddlSehirler" runat="server" Height="23px" Width="150px" Border="none"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlSehirler_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Şehir Seçiniz</asp:ListItem>
                </asp:DropDownList>
                <br /><br />
                <span style="width:75px; font-weight:bold; float:left;">İlçe</span>
                <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
                <asp:DropDownList ID="ddlIlceler" runat="server" Height="23px" Width="150px" Border="none">
                    <asp:ListItem Selected="True" Value="0">İlçe Seçiniz</asp:ListItem>
                </asp:DropDownList>
                <br /><br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <span style="width:75px; font-weight:bold; float:left;">Fiyat</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <asp:TextBox ID="txbFiyat" runat="server" Style=" height: 15px; width: 150px;"></asp:TextBox>
        <asp:DropDownList ID="ddlParaBirim" runat="server" Height="20px" Width="70px" Border="none">
        </asp:DropDownList><asp:RequiredFieldValidator ID="rqvFiyat" runat="server" ErrorMessage="*" ControlToValidate="txbFiyat" ForeColor="Red" ></asp:RequiredFieldValidator>
        <br /><br />
        <span style="width:75px; font-weight:bold; float:left;">İlan Türü</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <asp:DropDownList ID="ddlIlanTip" runat="server" Height="23px" Width="150px" Border="none">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Selected="False" Value="1">İş Sahibi</asp:ListItem>
            <asp:ListItem Selected="False" Value="2">İş Arayan</asp:ListItem>
        </asp:DropDownList>        
        <br />
        </div>
        <br />
        <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
            Fotoğraf
        </div>
        <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px">
            <div id="Resimler">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:FileUpload ID="fuResim0" Visible="true" runat="server" />
                            <asp:FileUpload ID="fuResim1" Visible="false" runat="server" />
                            <asp:FileUpload ID="fuResim2" Visible="false" runat="server" />
                            <asp:FileUpload ID="fuResim3" Visible="false" runat="server" />
                            <asp:FileUpload ID="fuResim4" Visible="false" runat="server" />
                            <asp:FileUpload ID="fuResim5" Visible="false" runat="server" />
                            <asp:FileUpload ID="fuResim6" Visible="false" runat="server" />
                            <asp:FileUpload ID="fuResim7" Visible="false" runat="server" />
                            <asp:FileUpload ID="fuResim8" Visible="false" runat="server" />
                            <asp:FileUpload ID="fuResim9" Visible="false" runat="server" />
                        </asp:Panel>
                        <br />
                        <asp:Button ID="btResimEkle" runat="server" Text="Resim Ekle" OnClick="btResimEkle_Click" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 100px;"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
            İlan Seçenekleri
        </div>
        <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px">
        <span style="width:75px; font-weight:bold; float:left;">Yayınlanma Süresi</span>
        <span style="width:5px; padding-right:10px; font-weight:bold; float:left;">:</span>
        <asp:DropDownList ID="ddlYayinlanmaSure" runat="server" Height="23px" Width="100px" Border="none"></asp:DropDownList>
       <%-- <br /><br />
        <asp:CheckBox ID="chbTelefonNumaramYayinlansinMi" Text="Telefon numaram ilanımda yayınlansın"
            runat="server" />--%>
        <br />
        <hr />
        <asp:CheckBox ID="chbIlanVermeKurallariniOkudum" runat="server" /><a href="javascript:openPopup('IlanKurallari.aspx')">İlan
            Verme Kuralları</a>nı okudum<br />
        <hr />
    </div>
    <asp:Button ID="btDevam" runat="server" Text="Devam" OnClick="btDevam_Click" Style="color: White; background-color: #544634; border-style: None; height: 22px; width: 50px;"/>
</asp:Content>
