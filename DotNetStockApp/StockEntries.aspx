<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockEntries.aspx.cs" Inherits="DotNetStockApp.StockEntries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/StockEntries.css?Version=1" type="text/css" />
    </head>
    <div class="box">
        <div class="content">
            
            <asp:Table class="table" ID="ProductTable" runat="server">
            </asp:Table>
            
        </div>
    </div>
</asp:Content>
