<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="Ilanlarim.aspx.cs" Inherits="Ilanlarim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" Runat="Server">
    <br />
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family:Trebuchet MS; font-size:17px; padding:3px; padding-left:10px; color:#544634; font-weight:bold">
        İLANLARIM
    </div>
    <div style="border-style: solid; border-width: thin; border-color: #bff0ff; font-family: Trebuchet MS; font-size: 13px; padding: 10px;">
        <table style="width: 95%">
            <tr>
                <td style="border-bottom-width:1px; border-bottom-color:Black; font-weight:bold;">
                    İLAN BAŞLIK
                </td>
                <td style="text-align: center;border-bottom-width:1px; border-bottom-color:Black; font-weight:bold;">
                    İŞLEM
                </td>
            </tr>
            <asp:Repeater ID="DataList1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="font-family: Tahoma; font-size: 12px">
                            İlan No : <%#Eval("IlanNo")%> | Başlık : <%#Eval("IlanBaslik")%>
                        </td>
                        <td style="text-align: center; width: 200px"> 
                            <div class="lgn1" style="margin-right:5px;">
                                <a href="IlanDuzenle.aspx?IlanId=<%#Eval("IlanId") %>&islem=guncel" class="lgnlink">
                                GÜNCELLE</a>
                            </div>
                            
                            <div class="lgn2">
                                <a onclick="return onay()" href="IlanDuzenle.aspx?IlanId=<%#Eval("IlanId") %>&islem=sil"
                                    class="lgnlink">SİL</a>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <br />
</asp:Content>

