<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebshopSneakersgip.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalogus</title>
    <link href="Opmaak.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>
                Online Sneakershop - Catalogus</h2>
            <h2>
                <asp:Image ID="imgBanner" runat="server" Height="75px" ImageUrl="~/Files/banner.jpg" Width="850px" />
            </h2>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvCatalogus" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCatalogus_SelectedIndexChanged" Width="850px" CssClass="DefaultGridView" DataKeyNames="Foto">
                            <Columns>
                                <asp:BoundField DataField="ProductID" HeaderText="ProductID" HeaderStyle-CssClass="DefaultGridViewHeader">
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Naam" HeaderText="Naam" HeaderStyle-CssClass="DefaultGridViewHeader">
                                <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:ImageField DataImageUrlField="Foto" DataImageUrlFormatString="~\Files\{0}" HeaderText="Foto" HeaderStyle-CssClass="DefaultGridViewHeader">
                                    <ControlStyle Height="225px" Width="225px" />
                                    <ItemStyle Width="250px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="Prijs" HeaderText="Verkoopprijs" HeaderStyle-CssClass="DefaultGridViewHeader" DataFormatString="{0:c}">
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Voorraad" HeaderText="Voorraad" HeaderStyle-CssClass="DefaultGridViewHeader">
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:CommandField SelectText="Voeg toe aan winkelmandje..." HeaderStyle-CssClass="DefaultGridViewHeader" ShowSelectButton="True" >
                                <ItemStyle Width="150px" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Button class="DefaultButtonStyle" ID="btnOk" runat="server" Text="Bekijk de inhoud van het winkelmandje..." Width="850px" OnClick="btnOk_Click" CssClass="DefaultButtonStyle" Height="45px"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server">Afmelden</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
