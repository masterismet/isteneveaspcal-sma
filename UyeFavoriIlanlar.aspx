<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="UyeFavoriIlanlar.aspx.cs" Inherits="UyeFavoriIlanlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        Favori İlanlarım
    </div>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">

        <asp:DataList ID="dtlIlanlar" runat="server" RepeatColumns="1" Width="550px">
            <ItemTemplate>
                <%--IlanId,IlanBaslik,IlanOzet,YayinTarih--%>
                <table style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <div class="makaleustbilgiler">
                                Eklenme Tarihi :
                                <%#Fonksiyon.TarihFormatla(Eval("YayinTarih")) %>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50px; height: 50px" valign="top" rowspan="2">
                            <img src='Content/Images/Site/uyelik.jpg' style="width: 50px; height: 50px; border: none" />
                        </td>
                        <td valign="top">
                            <a class="lgnlink3" href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx">
                                <%#Eval("IlanBaslik") %></a>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="font-family: Trebuchet MS; font-size: 12px; color: #3a3a3a">
                            <p>
                                <%#Eval("IlanOzet") %><a class="lgnlink2" href="<%#Fonksiyon.SiteUrl + "/Ilan-" + Eval("IlanId")+ "-" + Guvenlik.YaziDuzenle(Eval("IlanBaslik").ToString())%>.aspx">Devamını
                                    göster</a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>

