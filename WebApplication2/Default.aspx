<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Translate</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 622px;
        }

        .auto-style3 {
            width: 622px;
            height: 30px;
            text-align: center;
        }

        .auto-style4 {
            height: 30px;
            text-align: center;
        }

        .auto-style5 {
            text-align: center;
        }

        .auto-style6 {
            width: 622px;
            height: 23px;
        }

        .auto-style7 {
            height: 23px;
        }

        .auto-style8 {
            width: 622px;
            text-align: center;
        }

        .auto-style9 {
            height: 23px;
            text-align: center;
        }

        .auto-style10 {
            width: 622px;
            height: 23px;
            text-align: center;
        }

        .auto-style11 {
            width: 622px;
            height: 39px;
        }

        .auto-style12 {
            height: 39px;
        }

        .auto-style13 {
            height: 31px;
            text-align: left;
        }

        .auto-style14 {
            width: 622px;
            height: 31px;
            text-align: right;
        }

        .auto-style15 {
            width: 622px;
            text-align: right;
        }

        .auto-style16 {
            text-align: left;
        }

        .auto-style17 {
            font-size: x-large;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="Form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5" colspan="2">
                        <strong>
                            <asp:Label ID="Label1" runat="server" Text="CMPE-363-PROJECT-TEAM9" CssClass="auto-style17"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td style="text-align: center">
                        <asp:Button ID="Button5" runat="server" Text="Logout" OnClick="Button5_Click" Visible="False" />
                        <asp:Button ID="Button3" runat="server" Text="Login" OnClick="Button3_Click" Style="text-align: justify" />
                        <asp:Button ID="Button4" runat="server" Text="Register" OnClick="Button4_Click" Style="text-align: right" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style2">From</td>
                    <td>To</td>
                </tr>
                <tr>
                    <td class="auto-style2">
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
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Value="en">English</asp:ListItem>
                            <asp:ListItem Value="de">German</asp:ListItem>
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
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Input Text" OnTextChanged="TextBox1_TextChanged" Height="248px" Width="405px" TextMode="multiline" Style="overflow: auto"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Height="248px" Width="405px" TextMode="multiline" Style="overflow: auto"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Translate" />
                    </td>
                    <td class="auto-style4">
                        <asp:ImageButton ID="Button2" ImageUrl="~/sound-icon.png" AlternateText="No Image available" runat="server" OnClick="Button2_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>


                <tr>
                    <td class="auto-style10">Translate Text form a image</td>
                    <td class="auto-style9">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <fieldset>
                            <legend>Upload Image </legend>
                            <label for="Image">Image</label>
                            <input id="oFile" name="oFile" type="file" runat="server" />
                            <br />
                            <asp:Button ID="BtnUpload" type="submit" Text="Upload" runat="server" OnClick="BtnUpload_Click"></asp:Button>
                        </fieldset>

                        <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="lblLoggedIn1" runat="server" Text="Currently logged in: " Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <strong>
                            <asp:Label ID="lblLoggedIn2" runat="server" Text="Username" Visible="False"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="lblTranslate1" runat="server" Text="Translate count: " Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <strong>
                            <asp:Label ID="lblTranslate2" runat="server" Text="Translate count" Visible="False"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="lblSpeech1" runat="server" Text="Speech count: " Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <strong>
                            <asp:Label ID="lblSpeech2" runat="server" Text="Speech count" Visible="False"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="lblPrefLang1" runat="server" Text="Preferred Language: " Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <strong>
                            <asp:Label ID="lblPrefLang2" runat="server" Text="PreferredLang" Visible="False"></asp:Label>
                        </strong>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style7"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
