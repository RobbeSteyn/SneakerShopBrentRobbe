<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Winkelmandje.aspx.cs" Inherits="WebshopSneakersgip.Winkelmandje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Opmaak.css" rel="stylesheet" />   
    <style type="text/css">
        .auto-style2 {
            width: 470px;
        }
        .auto-style3 {
            width: 467px;
        }
        .auto-style4 {
            width: 466px;
        }
        .auto-style5 {
            width: 465px;
        }
        .auto-style6 {
            width: 464px;
        }
        .auto-style7 {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online Sneakershop -Winkelmandje</h2>
            <h2>
                <asp:Image ID="imgBanner" runat="server" Height="75px" ImageUrl="~/Files/banner.jpg" Width="850px" />
            </h2>
            <table class="DefaultTableStyle">
                <tr>
                    <td class="auto-style7">Klantnummer: </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblKlantID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Naam:</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblNaam" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Adres:</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblAdres" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblPcGe" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Besteldatum:</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblDatum" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvWinkelmand" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvWinkelmand_SelectedIndexChanged" Width="850px" CssClass="DefaultGridView">
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Files/btnDelete.jpg" ShowSelectButton="True" HeaderStyle-CssClass="DefaultGridViewHeader" >
                    <ControlStyle Height="45px" Width="45px" />
                    <ItemStyle Width="50px" />
                    </asp:CommandField>
                    <asp:ImageField DataImageUrlField="Foto" DataImageUrlFormatString="~\Files\{0}" HeaderText="Foto" HeaderStyle-CssClass="DefaultGridViewHeader">
                        <ControlStyle Height="225px" Width="225px" />
                        <ItemStyle Width="250px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="ProductID" HeaderText="ArtNr" HeaderStyle-CssClass="DefaultGridViewHeader">
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Naam" HeaderText="Naam" HeaderStyle-CssClass="DefaultGridViewHeader">
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Aantal" DataField="Aantal" HeaderStyle-CssClass="DefaultGridViewHeader">
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Prijs" HeaderText="Prijs" HeaderStyle-CssClass="DefaultGridViewHeader">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Totaal" DataField="Totaal" HeaderStyle-CssClass="DefaultGridViewHeader"/>
                </Columns>
            </asp:GridView>
            <br />
            <table class="DefaultTableStyle">
                <tr>
                    <td class="auto-style7">Totaal excl. BTW:</td>
                    <td class="auto-style6">
                        <asp:Label ID="lblExclBTW" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">BTW:</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblBTW" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Totaal incl. BTW:</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblInclBTW" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td class="DefaultButtonStyle">
                        <asp:Button ID="btnBestellen" runat="server" Text="Bestellen..." OnClick="btnBestellen_Click" Height="45px" Width="420px" CssClass="DefaultButtonStyle" />
                    </td>
                    <td class="DefaultButtonStyle">
                        <asp:Button ID="btnCatalogus" runat="server" OnClick="btnCatalogus_Click" Text="Terug naar catalogus..." Height="45px" Width="420px" CssClass="DefaultButtonStyle" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
