<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="DotNetStockApp.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" href="Content/style.css?v=2" type="text/css" />
    </head>
    <h1>Create an account here !</h1>
    <div id="CreateAccountContainer">
        <div id="CreateAccountName">
            <h2>Name : 
                <asp:TextBox ID="Name" runat="server"></asp:TextBox>
            </h2>
        </div>
        <div id="CreateAccountLogin">
            <h2>Login : 
                <asp:TextBox ID="Login" runat="server"></asp:TextBox>
            </h2>
        </div>
        <div id="CreateAccountPassword">
            <h2>Password : 
                <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            </h2>
        </div>
        <div id="CreateAccountRights">
            <h2>Rights : 
                
                <asp:DropDownList ID="Rights" runat="server">
                    <asp:ListItem>admin</asp:ListItem>
                    <asp:ListItem>user</asp:ListItem>
                </asp:DropDownList>
                
            </h2>
        </div>
    </div>
    <div id="CreateAccountButton">
        <asp:Button ID="Button1" runat="server" Text="Create Account !" OnClick="Button1_Click" />
    </div>

</asp:Content>
