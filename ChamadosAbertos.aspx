<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChamadosAbertos.aspx.cs" Inherits="ChamadosAbertos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <asp:Label ID="LabelExtratoChamado" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <br />
        <h4 class="text-center">
            <font color="grenn"><i>Chamados Abertos</i> </font></h4>
        <div class="row">
            <div class="col-10">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Larger" OnClick="LinkButton1_Click">Meus Chamados em  aberto: </asp:LinkButton>
                <%--<asp:Label runat="server" Text="Meus Chamados em aberto: " ForeColor="Black" Font-Bold="True" Font-Italic="False" Font-Size="Larger"></asp:Label>--%>
                <asp:Label runat="server" ID="labelTotalChamadosEmAberto" Font-Bold="True" Font-Size="Larger" ForeColor="black" Visible="true"></asp:Label>
            </div>
            <div class="col-2">
                <button type="button" onclick="recarregarAPagina()" class="btn btn alert-dismissible">Atualizar lista</button>
            </div>
        </div>
        <asp:GridView ID="GridViewChamados" AutoGenerateColumns="False" DataKeyNames="id"
            runat="server" OnRowCommand="grdDadosPacienteSGH_RowCommand" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Nº" SortExpression="id" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="cac" HeaderText="Cac" SortExpression="cac" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="setor" HeaderText="Setor" SortExpression="setor" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="nomeContato" HeaderText="Nome Contato" SortExpression="nomeContato"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ramal" HeaderText="Ramal" SortExpression="ramal" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="titulo" HeaderText="Titulo" SortExpression="titulo" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="dt_hora" HeaderText="Data e Hora" SortExpression="dt_hora"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="IpDeQuemCadastrou" HeaderText="Ip Cadastrou" SortExpression="IpDeQuemCadastrou"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                    <ItemTemplate>
                        <div class="form-inline">
                            <asp:LinkButton ID="lbDadosPaciente" CommandName="editarCirurgia" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                CssClass="btn alert-info" runat="server"> <!-- Text="Selecionar" -->
                                  Atender
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="sorting_disabled"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <!-- dt_alta_medica
                <asp:BoundField DataField="SituacaoStatus" HeaderText="Status" SortExpression="SituacaoStatus"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                -->
    </div>

    <%-- Funções em Java script--%>

    <script>
        function recarregarAPagina() {
            window.location.reload();
        }
    </script>
    <script type="text/javascript">
        setTimeout(function () {
            window.location.reload(1);
        }, 240000); //60000 1 minutos // 120000 2 min  Junior 03/01/2022

    </script>

</asp:Content>
