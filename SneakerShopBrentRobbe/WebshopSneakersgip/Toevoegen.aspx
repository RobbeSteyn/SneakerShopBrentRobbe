<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Toevoegen.aspx.cs" Inherits="WebshopSneakersgip.Toevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Opmaak.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online Sneakershop - Item toevoegen aan het winkelmandje</h2>
            <h2>
                <asp:Image ID="imgBanner" runat="server" Height="75px" ImageUrl="~/Files/banner.jpg" Width="850px" />
            </h2>
            <table>
                <tr>
                    <td class="auto-style1">
                        <asp:Image ID="imgProduct" runat="server" Height="300px" Width="300px" />
                    </td>
                    <td>
                        <table>                           
                            <tr>
                                <td>ArtNr:</td>
                                <td>
                                    <asp:Label ID="lblProductID" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Naam:</td>
                                <td>
                                    <asp:Label ID="lblNaam" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Verkoopprijs:</td>
                                <td>
                                    <asp:Label ID="lblVerkoopprijs" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Voorraad:</td>
                                <td>
                                    <asp:Label ID="lblVoorraad" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="DefaultTableStyle"> &nbsp;
                        <asp:Label ID="lblText" runat="server" Text="Aantal te bestellen exemplaren van dit item:" Width="410px"></asp:Label>
                        <asp:TextBox ID="txtAantal" runat="server" Width="410px"></asp:TextBox>
&nbsp;
                        <br />
                        <br />
                        <asp:Button ID="btnOk" runat="server" Text="Toevoegen..." OnClick="Button1_Click" Height="45px" Width="850px" CssClass="DefaultButtonStyle" />
                        <br />
                        <asp:Label ID="lblFouttext" runat="server" ForeColor="Maroon" Text="Dit product zit al in het winkelmandje. Als u het aantal wil wijzigen, verwijder het dan uit het winkelmandje en voeg het correcte aantal toe." Visible="False" Width="850px"></asp:Label>
                        <asp:Button ID="btnCatalogus" runat="server" OnClick="btnCatalogus_Click" Text="Terug naar catalogus..." Visible="False" Height="45px" Width="850px" CssClass="DefaultButtonStyle" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
