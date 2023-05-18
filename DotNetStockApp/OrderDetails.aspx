<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="DotNetStockApp.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Détail de la commande</h1>
    <asp:Button ID="GoBack" Text="Retour aux commandes" runat="server" OnClick="GoBack_Click"/>
<h2>Commande n°<asp:Label ID="lblOrderID" runat="server"></asp:Label></h2>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>
