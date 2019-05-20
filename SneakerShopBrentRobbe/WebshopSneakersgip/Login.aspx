<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebshopSneakersgip.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Opmaak.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online sneakershop - Login</h2>
            <p>
                <asp:Image ID="imgBanner" runat="server" Height="75px" ImageUrl="~/Files/banner.jpg" Width="850px" />
            </p>
            <p>
                <table class="DefaultTableStyle">
                    <tr>
                        <td>Gebruikersnaam:</td>
                        <td>
                            <asp:TextBox ID="txtGebnaam" runat="server" Width="160px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvGebrNaam" runat="server" ControlToValidate="txtGebnaam" ErrorMessage="Gebruikersnaam is verplicht!" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Wachtwoord:</td>
                        <td>
                            <asp:TextBox ID="txtWachtwoord" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="rfvWw" runat="server" ControlToValidate="txtWachtwoord" ErrorMessage="Wachtwoord is verplicht!" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" />
                            <br />
                            <asp:Button ID="btnAanmelden" runat="server" OnCLick="btnAanmelden_Click" Text="Aanmelden" CssClass="DefaultButtonStyle" Height="45px" Width="850px" />
                            <br />
                            <br />
                            <asp:Label ID="lblFout" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </p>
        </div>
    </form>
</body>
</html>
