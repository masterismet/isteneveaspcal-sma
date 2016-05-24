<%@ Page Title="" Language="C#" MasterPageFile="~/IstenEveMaster.master" AutoEventWireup="true" CodeFile="IlanVerKategoriSec.aspx.cs" Inherits="IlanVerKategoriSec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSerit" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMeydan" runat="Server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:ListBox ID="lsbKategori1" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="True" AutoPostBack="True" Height="150px"></asp:ListBox>
                        <asp:ListBox ID="lsbKategori2" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="150px"></asp:ListBox>
                        <asp:ListBox ID="lsbKategori3" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="150px"></asp:ListBox>
                        <asp:ListBox ID="lsbKategori4" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="150px"></asp:ListBox>
                        <asp:ListBox ID="lsbKategori5" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="150px"></asp:ListBox>
                        <asp:ListBox ID="lsbKategori6" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="150px"></asp:ListBox>
                        <asp:ListBox ID="lsbKategori7" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="150px"></asp:ListBox>
                        <asp:ListBox ID="lsbKategori8" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="150px"></asp:ListBox>
                        <asp:ListBox ID="lsbKategori9" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="150px"></asp:ListBox>
                        <asp:ListBox ID="lsbKategori10" runat="server" Width="130px" onselectedindexchanged="lsbKategori_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="150px"></asp:ListBox>
                    </asp:Panel>
                </div>
                <br />
                <div>
                    <asp:Button ID="btKategoriTamam" runat="server" Text="Devam" Width="300" Style="color: White;
                                        background-color: #544634; border-style: None; height: 22px;"
                        onclick="btKategoriTamam_Click" Enabled="False" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

