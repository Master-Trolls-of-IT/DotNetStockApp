<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommandManagement.aspx.cs" EnableEventValidation="true" Inherits="DotNetStockApp.CommandManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/CommandManagementStyle.css?Version=1" type="text/css" />
    </head>
    <div class="content">
        <h1>Gestionnaire de commandes</h1>
    </div>
    
    <div id="CommandListContainer" class="box">
        <div class="content">
            <h2>
                Pour filtrer, cliquez sur le nom de la colonne, pour avoir le détail de la commande, cliquez sur la ligne. 
            </h2>
        
        <div id="OrderList">

            <asp:GridView class="table" ID="GridView1" AllowSorting="True" OnSorting="GridView1_OnSorting" OnRowDataBound="GridView1_RowDataBound" runat="server">
            </asp:GridView>

        </div>
        
        <div id="AddOrderDiv">
            <asp:Button class="btn" runat="server" ID="AddOrderButton" Text="Add Order !" OnClick="AddOrderButton_Click"/>
        </div>

            </div>
    </div>
</asp:Content>
