<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RelatorioGeralExcel.aspx.cs" Inherits="Administrativo_Relatorios" %>

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
        <h3 class="title-content">Relatório de Geral em Excel</h3>

     <%--   <div class="row">
            <div class="col-3"></div>
            <div class="col-1 centralizar ">

                <asp:RadioButton ID="rdbTodos" runat="server" Checked="True" Text="Todos " GroupName="RelExcel"></asp:RadioButton>
            </div>
            <div class="col-1 centralizar ">
                <asp:RadioButton ID="rdbFechados" runat="server" Text="Fechados " GroupName="RelExcel"></asp:RadioButton>
            </div>
            <div class="col-1 centralizar ">
                <asp:RadioButton ID="rdbAbertos" runat="server" Text="Abertos " GroupName="RelExcel"></asp:RadioButton>
            </div>
            <div class="col-4"></div>
        </div>--%>
        <br />
        <div class="row">
            <div class="col-3"></div>
            <div class="col-2">
                <span class="fw-bold">Data Inicial:</span>
                <asp:TextBox ID="txtDtInicio" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-2">
                <span class="fw-bold">Data Final:</span>
                <asp:TextBox ID="txtDtFim" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-2 m-3">
                <div class="nav m-2">
                    <asp:Button ID="btnPesquisar" runat="server" class="btn btn-success" Text="Exportar Excel" OnClick="btnPesquisar_Click" />
                </div>
            </div>

           <%-- <div class="col-2">
                <asp:Button runat="server" ID="btnExcel" class="btn btn-success" Text="Exportar Excel" OnClick="btnExcel_Click" />

            </div>--%>


        </div>
        <br />
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4">
                <div class="nav justify-content-center m-2">
                    <asp:GridView ID="GridViewRelGeralExcel" runat="server"
                        HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" EnableModelValidation="True">
                        <AlternatingRowStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />

                        <RowStyle HorizontalAlign="Center"></RowStyle>

                    </asp:GridView>
                </div>
            </div>

            <div class="col-4"></div>
        </div>
    </div>

</asp:Content>

