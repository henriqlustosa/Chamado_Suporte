<%@ Page Title="Chamados abertos" Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="ChamadosAbertos.aspx.cs" Inherits="ChamadosAbertos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/chamadosAbertos.css" rel="stylesheet" />
    <link href="../css/content.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <asp:Label ID="LabelExtratoChamado" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <h3 class="title-content">Chamados Abertos</h3>
        <div class="row">
            <div class="div-teste">
                <%-- <div class="col-12">--%>
                <div>
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Larger" OnClick="LinkButton1_Click">Meus Chamados em  aberto: </asp:LinkButton>
                    <%--<asp:Label runat="server" Text="Meus Chamados em aberto: " ForeColor="Black" Font-Bold="True" Font-Italic="False" Font-Size="Larger"></asp:Label>--%>
                    <asp:Label runat="server" ID="labelTotalChamadosEmAberto" Font-Bold="True" Font-Size="Larger" ForeColor="black" Visible="true"></asp:Label>
                </div>
                    <div>
                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="Larger" OnClick="LinkButton2_Click">Solicitações de acesso em  aberto: </asp:LinkButton>
                    <%--<asp:Label runat="server" Text="Meus Chamados em aberto: " ForeColor="Black" Font-Bold="True" Font-Italic="False" Font-Size="Larger"></asp:Label>--%>
                    <asp:Label runat="server" ID="labelTotalDeSolicitacoesEmAberto" Font-Bold="True" Font-Size="Larger" ForeColor="black" Visible="true"></asp:Label>
                </div>
                  <div>
                    <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" Font-Size="Larger" OnClick="LinkButton3_Click">Remover Permissões: </asp:LinkButton>
                    <%--<asp:Label runat="server" Text="Meus Chamados em aberto: " ForeColor="Black" Font-Bold="True" Font-Italic="False" Font-Size="Larger"></asp:Label>--%>
                    <asp:Label runat="server" ID="labelTotalDeSolicitacoesRemover" Font-Bold="True" Font-Size="Larger" ForeColor="black" Visible="true"></asp:Label>
                </div>
                <div>
                    <button type="button" onclick="recarregarAPagina()" class="button">Atualizar lista</button>
                </div>
                <%--</div>--%>
            </div>

        </div>
        <br />
        <asp:GridView ID="GridViewChamados" AutoGenerateColumns="False" DataKeyNames="id"
            runat="server" OnRowCommand="grdDadosPacienteSGH_RowCommand" CssClass="table table-bordered"
            HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#3b7b92"
            HeaderStyle-ForeColor="#ffffff" BorderColor="#29336b">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Nº" SortExpression="id" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                   <asp:BoundField DataField="statusDochamado" HeaderText="Status" SortExpression="statusDochamado" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="cac" HeaderText="CAC" SortExpression="cac" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="setor" HeaderText="Setor" SortExpression="setor" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="nomeContato" HeaderText="Nome Contato" SortExpression="nomeContato"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ramal" HeaderText="Ramal" SortExpression="ramal" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="titulo" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="dt_hora" HeaderText="Data e Hora" SortExpression="dt_hora"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="IpDeQuemCadastrou" HeaderText="IP Cadastrou" SortExpression="IpDeQuemCadastrou"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                    <ItemTemplate>
                        <div class="form-inline">
                            <div class="div-btngrid">
                                <asp:LinkButton ID="lbDadosPaciente" CommandName="editarCirurgia" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="button-grid" runat="server" HorizontalAlign="Center"> <!-- Text="Selecionar" -->
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
        }, 60000); //60000 1 minutos // 120000 2 min  Junior 03/01/2022

    </script>

</asp:Content>
