<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlayTranslation.aspx.cs" Inherits="WebApplication2.PlayTranslation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Play Translation</title>
</head>
<body>
    <div>
        <strong>
            <asp:Label ID="Label1" runat="server" Text="Play your translation" CssClass="auto-style1" Style="font-size: x-large"></asp:Label>
        </strong>
    </div>

    <div>
        <audio src="translated.wav" controls="controls" />
    </div>
</body>
</html>
