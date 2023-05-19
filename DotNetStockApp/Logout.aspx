<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="DotNetStockApp.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/LogoutStyle.css?Version=1" type="text/css" />
    </head>
    <div class="box">
        <div class="content">
            <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Log out !" OnClick="Button1_Click" />
        </div>
    </div>
    
</asp:Content>
