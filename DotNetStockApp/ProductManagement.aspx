<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="DotNetStockApp.ProductManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/ProductManagementSyle.css?Version=1" type="text/css" />
    </head>
    <div class="box">
        <div class="content">

        
    <h1>Ajouter ou supprimer des produits.</h1>
        
            <div class="box" id="addbox">
                <div class="content">

                <h2>Ajoutez les informations de vos produits ici:</h2>
                
                   <asp:TextBox class="field" ID="NameInput" placeholder="Name" runat="server"></asp:TextBox>
                
                <div id="Quantity">
                    <asp:TextBox class="field" ID="QuantityInput" placeholder="Quantity" runat="server"></asp:TextBox>
                </div>
                <div id="Cost">
                    <asp:TextBox class="field" ID="CostInput" placeholder="Cost" runat="server"></asp:TextBox>
                </div>
                <div id="SellingPrice">
                    <asp:TextBox class="field" ID="SellingPriceInput" placeholder="Selling Price" runat="server"></asp:TextBox>
                </div>
                <div id="SeriesNumber">
                    <asp:TextBox class="field" ID="SeriesNumberInput" placeholder="Series Number" runat="server"></asp:TextBox>
                </div>
                <div id="ExpirationDate">
                   <asp:TextBox class="field" ID="ExpirationDateInput" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div id="Photo">
                    <asp:FileUpload ID="PhotoInput" style="display:none" runat="server" />
                        
                    <div class="btn" id="uploadTrigger">click here to add picture</div>
                        <script>
                            $("#uploadTrigger").click(function () {
                                $("#<%= PhotoInput.ClientID %>").click();
                            });
                        </script>
                    
                </div>
                <asp:Button class="btn" ID="uploadButton" runat="server" Text="Upload Product" OnClick="uploadButton_Click" />
                <asp:ModelErrorMessage ID="ErrorLabel" runat="server" />
            </div>
                </div>
            <div class="box" id="deletebox">
                <div class="content">
                <h1>Supprimez des elements ici</h1>
                <div id="DropDownId">

                    <asp:DropDownList CssClass="btn" ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    
                    <asp:Button ID="DeleteButton" CssClass="btn" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
                    
                </div>
           
            </div>

            </div>
       
            </div>
    </div>

     
</asp:Content>
