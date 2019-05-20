<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MandjeLeeg.aspx.cs" Inherits="WebshopSneakersgip.MandjeLeeg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Opmaak.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online Sneakershop - Winkelmandje</h2>
            <h2>
                <asp:Image ID="Image1" runat="server" Height="75px" Width="850px" ImageUrl="~/Files/banner.jpg" />
            </h2>
            <table>
                <tr>
                    <td>Het winkelmandje is leeg. Klik op de volgende knop om terug naar de catalogus te gaan.<br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="Terug naar catalogus..." Height="45px" Width="850px" CssClass="DefaultButtonStyle" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
