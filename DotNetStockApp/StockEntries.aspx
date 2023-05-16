<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockEntries.aspx.cs" Inherits="DotNetStockApp.StockEntries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/style.css" type="text/css" />
    </head>
    <div id="MenuAndEditContainer">
        <div id="Menu">
            
            <asp:Table ID="ProductTable" runat="server">
            </asp:Table>
            
        </div>
        <div id="Edit"></div>
    </div>
</asp:Content>
