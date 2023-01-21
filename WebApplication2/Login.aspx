<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <strong>
        <asp:Label ID="Label1" runat="server" Text="Login" CssClass="auto-style1"></asp:Label>
    </strong>
    <form id="form1" runat="server">
        <div>
            <p>Username</p>
            <input id="Text1" type="text" name="Username" />
            <p>Password</p>
            <input id="Password1" type="password" name="Password" />

        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Text="login" OnClick="Button1_Click" />

        </p>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
    </form>
</body>
</html>
