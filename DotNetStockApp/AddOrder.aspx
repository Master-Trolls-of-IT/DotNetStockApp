<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="DotNetStockApp.AddOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/style.css?v=2" type="text/css" />
    </head>
    <h1>Add another Order here !</h1>
    <div id="AddItemsToOrderId">
        <div id="OrderCustomer">
            <h2>What Is the Name of the Customer of this Order ?</h2>
            <asp:TextBox ID="Customer" runat="server"></asp:TextBox>
        </div>
        <div id="OrderDeliveryDate">
            <h2>What is the delivery Date of this order ?</h2>
            <asp:TextBox ID="DeliveryDate" TextMode="Date" runat="server"></asp:TextBox>
        </div>
        <div id="OrderProducts">
            <h2>Please choose what Products are in your order</h2>
            
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false">
            </asp:DropDownList>
            <div id="divQuantity">
                <asp:TextBox type="number" ID="ProductQuantity" min="1" value="1" runat="server" AutoPostBack="false"></asp:TextBox>
                <asp:Button ID="ValidateProductButton" Text="Validate Product adding to Order !" runat="server" OnClick="ValidateProductButton_Click"/>
            </div>
            <div id="ProductListInOrderId">
                
                <asp:GridView ID="productsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="productsGridView_RowCommand">
    <Columns>
        <asp:TemplateField HeaderText="Product Name">
            <ItemTemplate>
                <asp:Label ID="Name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
                <asp:Label ID="Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Series Number">
            <ItemTemplate>
                <asp:Label ID="SeriesNumber" runat="server" Text='<%# Eval("SeriesNumber") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:Button ID="DeleteProductButton" Text="Delete Product !" runat="server" CommandName="DeleteProduct" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="grid-header" />
</asp:GridView>


               

            </div>
            <asp:Button ID="Button1" runat="server" Text="validate Order !" OnClick="Button1_Click" />
        </div>


    </div>
</asp:Content>
