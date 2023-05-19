<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="DotNetStockApp.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/OrderDetailsStyle.css?Version=1" type="text/css" />
    </head>
    <div class="content">
        <h1>Détail de la commande</h1>
    </div>
    
    <asp:Button class="btn" ID="GoBack" Text="< Retour aux commandes" runat="server" OnClick="GoBack_Click"/>
<div class="box">
    <div class="content">
        <h2>Commande n°<asp:Label ID="lblOrderID" runat="server"></asp:Label></h2>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    </div>
</div>

</asp:Content>
