﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockLevels.aspx.cs" Inherits="DotNetStockApp.StockLevels" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1>Les Niveaux de Stock.</h1>
    </header>
    <asp:Chart ID="Chart1" runat="server">
        <Series>
            <asp:Series Name="Series1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>