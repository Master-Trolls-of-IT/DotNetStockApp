<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DotNetStockApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <head>
    <link rel="stylesheet" href="Content/LoginStyle.css?v=2" type="text/css" />
</head>
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
        <LayoutTemplate>
            <div class="box">
            <div class="content">
                              <h1>
                    Authentication Required</h1>
                                
                                    <asp:TextBox class="field" ID="UserName"  placeholder="User Name" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                              
                                   
                               
                                    <asp:TextBox class="field" ID="Password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                             
                               
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                              
                                   <asp:Button class="btn" ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" /></div>
               </div>            
        </LayoutTemplate>
        
</asp:Login>
</asp:Content>
