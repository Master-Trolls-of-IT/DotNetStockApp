﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommandManagement.aspx.cs" EnableEventValidation="true" Inherits="DotNetStockApp.CommandManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/style.css?v=2" type="text/css" />
    </head>
    <h1>Gestionnaire de commandes</h1>
    <div id="CommandListContainer">
        <div id="OrderList">

           

            

           


           

            <asp:GridView ID="GridView1" AllowSorting="True" OnSorting="GridView1_OnSorting" OnRowDataBound="GridView1_RowDataBound" runat="server">
                

            </asp:GridView>

           

            

           


           

        </div>
        
        <div id="OrderSummaryContainer">

            <asp:GridView ID="OrderDetailContainer" runat="server">
            </asp:GridView>
            <asp:TextBox ID="test" runat="server">test</asp:TextBox>
        </div>


    </div>
</asp:Content>