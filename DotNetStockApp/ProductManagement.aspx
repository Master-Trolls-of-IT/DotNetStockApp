<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="DotNetStockApp.ProductManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/style.css" type="text/css" />
    </head>
    <h1>Ajouter ou supprimer des produits.</h1>
        <div id="AddDeleteContainer">
            <div id ="Add">
                <h2>Ajoutez les informations de vos produits ici:</h2>
                <div id="Name">
                    <h3>Name:<asp:TextBox ID="NameInput" runat="server"></asp:TextBox>
                    </h3>
                </div>
                <div id="Quantity">
                    <h3>Quantity:<asp:TextBox ID="QuantityInput" runat="server"></asp:TextBox>
                    </h3>
                </div>
                <div id="Cost">
                    <h3>Cost:<asp:TextBox ID="CostInput" runat="server"></asp:TextBox>
                    </h3>
                </div>
                <div id="SellingPrice">
                    <h3>SellingPrice:<asp:TextBox ID="SellingPriceInput" runat="server"></asp:TextBox>
                    </h3>
                </div>
                <div id="SeriesNumber">
                    <h3>SeriesNumber:<asp:TextBox ID="SeriesNumberInput" runat="server"></asp:TextBox>
                    </h3>
                </div>
                <div id="ExpirationDate">
                    <h3>ExpirationDate:<asp:TextBox ID="ExpirationDateInput" runat="server" TextMode="Date"></asp:TextBox>
                    </h3>
                </div>
                <div id="Photo">
                    <h3>Photo:<asp:FileUpload ID="PhotoInput" runat="server" />
                    
                    </h3><asp:Button ID="uploadButton" runat="server" Text="Upload" OnClick="uploadButton_Click" />
                </div>
                <asp:ModelErrorMessage ID="ErrorLabel" runat="server" />

            </div>
            <div id="Delete">
                <h2>Supprimez des elements ici</h2>
                <div id="DropDownId">

                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    
                    <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
                    
                </div>
           
            </div>
        </div>

     
</asp:Content>
