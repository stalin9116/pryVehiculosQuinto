<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProdudctoLista.aspx.cs" Inherits="Pry_Vehiculos.WebForms.Administracion.Productos.wfmProdudctoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div width="95%">

        <h3>Lista Productos</h3>
        <br />

        <table style="width: 136px">
            <tr>
                <td style="width: 41px">
                    <asp:ImageButton ID="ImageButton1" runat="server" Width="32px" Height="32px" ImageUrl="~/images/icon_nuevo.png" OnClick="ImageButton1_Click" />
                </td>
                <td>
                    <asp:LinkButton ID="lnkNuevo" runat="server" OnClick="lnkNuevo_Click">Nuevo</asp:LinkButton>
                </td>
            </tr>
        </table>

        <table width="95%">
            <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <table width="30%">
                        <tr>
                            <td>Buscar</td>
                            <td>
                                <asp:TextBox ID="txtProductos" runat="server" Width="287px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/images/icon_buscar.png" Width="32px" Height="32px" />

                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:GridView ID="gdvProductos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="740px" OnRowCommand="gdvProductos_RowCommand">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />

                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgModificar" runat="server" ImageUrl="~/images/modificar.png" Width="32px" Height="32px" CommandName="Modificar" CommandArgument='<%#Eval("ID") %>' />

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEliminar" runat="server" ImageUrl="~/images/icon_delete.png" Width="32px" Height="32px" CommandName="Eliminar" CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('Oye bro vas a eliminar este registro jaja ?');" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>



                    </asp:GridView>

                </td>
            </tr>

        </table>

    </div>


</asp:Content>
