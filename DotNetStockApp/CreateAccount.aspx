<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="DotNetStockApp.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/CreateAccountStyle.css?v=2" type="text/css" />
    </head>
    <div class="content">
        <h1>Create an account here !</h1>
    </div>
    
    <div id="CreateAccountContainer" class="box">
        <div class="content">
        <div id="CreateAccountName">
            
                <asp:TextBox CssClass="field" ID="Name" placeholder="Name" runat="server"></asp:TextBox>
            
        </div>
        <div id="CreateAccountLogin">
           
                <asp:TextBox CssClass="field" ID="Login" placeholder="Login" runat="server"></asp:TextBox>
           
        </div>
        <div id="CreateAccountPassword">
            
                <asp:TextBox CssClass="field" ID="Password" placeholder="password" runat="server"></asp:TextBox>
           
        </div>
        <div id="CreateAccountRights">
            
                
                <asp:DropDownList CssClass="btn" ID="Rights" runat="server">
                    <asp:ListItem>admin</asp:ListItem>
                    <asp:ListItem>user</asp:ListItem>
                </asp:DropDownList>
                
           
        </div>
            <div id="CreateAccountButton">
        <asp:Button class="btn" ID="Button1" runat="server" Text="Create Account !" OnClick="Button1_Click" />
                <asp:ModelErrorMessage ID="Error" runat="server" />
    </div>
    </div> 
        
    </div>
    

</asp:Content>
