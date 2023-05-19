<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="DotNetStockApp.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/EditStyle.css?Version=1" type="text/css" />
    </head>
    <div class="box">
    <div id="EditParamsContainer" class="content">
        <div id="Name">
            <h2>Name</h2>
            <asp:TextBox class="field" ID="Name" runat="server"></asp:TextBox>

        </div>
        <div id="Quantity">
            <h2>Quantity</h2>
            <asp:TextBox class="field" ID="Quantity" runat="server"></asp:TextBox>

        </div>
        <div id="Cost">
            <h2>Cost</h2>
            <asp:TextBox class="field" ID="Cost" runat="server"></asp:TextBox>

        </div>
        <div id="SellingPrice">
            <h2>SellingPrice</h2>
            <asp:TextBox class="field" ID="SellingPrice" runat="server"></asp:TextBox>

        </div>
        <div id="SeriesNumber">
            <h2>SeriesNumber</h2>
            <asp:TextBox class="field" ID="SeriesNumber" runat="server"></asp:TextBox>

        </div>
        <div id="ExpirationDate">
            <h2>ExpirationDate</h2>
            <asp:TextBox class="field" ID="ExpirationDate" runat="server" TextMode="Date"></asp:TextBox>

        </div>
        <div id="Photo">
            <h2>Photo</h2>
            <asp:TextBox class="field" ID="Photo" runat="server"></asp:TextBox>

        </div>
        <div id="Edit">
            <h1>Confirm Edit ?</h1>
<asp:Button class="btn" ID="EditButton" runat="server" Text="Confirm" OnClick="EditButton_Click" />
        </div>
    </div>
        </div>
</asp:Content>
