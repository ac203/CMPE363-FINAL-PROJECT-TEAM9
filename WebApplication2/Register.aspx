<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication2.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
</head>
<body>
    <strong>
        <asp:Label ID="Label1" runat="server" Text="Register" CssClass="auto-style1" Style="font-size: x-large"></asp:Label>
    </strong>
    <form id="form1" runat="server">
        <div>
            <p>Username</p>
            <input id="Text1" type="text" name="Username" />
            <p>Password</p>
            <input id="Password1" type="password" name="Password" />
            <p>Preferred Language</p>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="de">German</asp:ListItem>
                <asp:ListItem Value="en">English</asp:ListItem>
                <asp:ListItem Value="tr">Turkish</asp:ListItem>
                <asp:ListItem Value="sq">Albanian</asp:ListItem>
                <asp:ListItem Value="ar">Arabic</asp:ListItem>
                <asp:ListItem Value="el">Greek</asp:ListItem>
                <asp:ListItem Value="id">Indonesian</asp:ListItem>
                <asp:ListItem Value="it">Italian</asp:ListItem>
                <asp:ListItem Value="ko">Korean</asp:ListItem>
                <asp:ListItem Value="mk">Macedonian</asp:ListItem>
                <asp:ListItem Value="nb">Norwegian</asp:ListItem>
                <asp:ListItem Value="pl">Polish</asp:ListItem>
                <asp:ListItem Value="pt">Portuguese</asp:ListItem>
                <asp:ListItem Value="es">Spanish</asp:ListItem>
                <asp:ListItem Value="th">Thai</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
