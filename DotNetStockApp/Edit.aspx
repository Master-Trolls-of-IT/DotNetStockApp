<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="DotNetStockApp.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/style.css" type="text/css" />
    </head>
    <div id="EditParamsContainer">
        <div id="Name">
            <h2>Name</h2>
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>

        </div>
        <div id="Quantity">
            <h2>Quantity</h2>
            <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>

        </div>
        <div id="Cost">
            <h2>Cost</h2>
            <asp:TextBox ID="Cost" runat="server"></asp:TextBox>

        </div>
        <div id="SellingPrice">
            <h2>SellingPrice</h2>
            <asp:TextBox ID="SellingPrice" runat="server"></asp:TextBox>

        </div>
        <div id="SeriesNumber">
            <h2>SeriesNumber</h2>
            <asp:TextBox ID="SeriesNumber" runat="server"></asp:TextBox>

        </div>
        <div id="ExpirationDate">
            <h2>ExpirationDate</h2>
            <asp:TextBox ID="ExpirationDate" runat="server" TextMode="Date"></asp:TextBox>

        </div>
        <div id="Photo">
            <h2>Photo</h2>
            <asp:TextBox ID="Photo" runat="server"></asp:TextBox>

        </div>
        <div id="Edit">
            <h2>Edit</h2>
<asp:Button ID="EditButton" runat="server" Text="Edit" OnClick="EditButton_Click" />
        </div>
    </div>
</asp:Content>
