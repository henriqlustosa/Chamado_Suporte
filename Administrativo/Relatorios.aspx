<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Relatorios.aspx.cs" Inherits="Administrativo_Relatorios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery.mask.js" type="text/javascript"></script>
    <link href="../css/content.css" rel="stylesheet" />
    <link href="../css/relatorio.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('#<%=txtDtInicio.ClientID %>').mask("99/99/9999");
        $('#<%= txtDtFim.ClientID %>').mask("99/99/9999");
    </script>

    <div class="container">
        <h3 class="title-content">Relatório de Produtividade</h3>

        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 centralizar ">
                <span class="fw-bold">Total de Chamados:</span>
                <asp:label class="fw-bold" id="LabelTotalCodificados" runat="server" forecolor="#3b7b92" text=""></asp:label>
            </div>
            <div class="col-4"></div>
        </div>
        <br />
        <div class="row">
            <div class="col-3"></div>
            <div class="col-2">
                <span class="fw-bold">Data Inicial:</span>
                <asp:textbox id="txtDtInicio"  runat="server" class="form-control" required></asp:textbox>
            </div>
            <div class="col-2">
                <span class="fw-bold">Data Final:</span>
                <asp:textbox id="txtDtFim" runat="server" class="form-control" required></asp:textbox>
            </div>
            <div class="col-2 m-3">
                <div class="nav m-2">
                    <asp:button id="btnPesquisar" runat="server" class=" button"
                        text="Pesquisar" onclick="btnPesquisar_Click" />
                </div>
            </div>
            <div class="col-3"></div>
        </div>
        <br />
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4">
                <div class="nav justify-content-center m-2">
                    <asp:gridview id="GridViewRelUsuario" runat="server" backcolor="White" bordercolor="#999999"
                        borderstyle="Solid" borderwidth="1px" cellpadding="3" forecolor="Black" gridlines="Vertical"
                        horizontalalign="Center" rowstyle-horizontalalign="Center">
                        <AlternatingRowStyle BackColor="#3b7b92" ForeColor="#ffffff" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="#29336b" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#3b7b92" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    </asp:gridview>
                </div>
            </div>

            <div class="col-4"></div>
        </div>
    </div>

</asp:Content>

