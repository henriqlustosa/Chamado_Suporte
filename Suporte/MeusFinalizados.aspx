<%@ Page Title="Meus chamados finalizados" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MeusFinalizados.aspx.cs" Inherits="MeusFinalizados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/content.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
         <link href="../js/jquery.dataTable.css" rel="stylesheet" />

         <script src="../js/jquery.js"></script>
    <script src="../js/jquery.dataTables.js"></script>
    
    <div class="container">       

        <asp:Label ID="LabelExtratoChamado" runat="server" Text="" Visible="False"></asp:Label>

        <h3 class="title-content">Chamados Finalizados do técnico - 
            <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="true"></asp:Label>
        </h3>

        <asp:GridView ID="GridViewChamados" AutoGenerateColumns="False" DataKeyNames="id"
            runat="server" OnRowCommand="grdDadosPacienteSGH_RowCommand" CssClass="table table-bordered"
            HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#3b7b92"
            HeaderStyle-ForeColor="#ffffff" BorderColor="#29336b">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Nº ID" SortExpression="id" ItemStyle-CssClass="hidden-xs"
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
                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                    <ItemTemplate>
                        <div class="form-inline">
                            <div class="div-btn">
                                <asp:LinkButton ID="lbDadosPaciente" CommandName="Reabrir" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="button-grid" runat="server"> <!-- Text="Selecionar" -->
                                  Reabrir
                                </asp:LinkButton>
                            </div>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="sorting_disabled"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                    <ItemTemplate>
                        <div class="form-inline">
                            <div class="div-btn">
                                <asp:LinkButton ID="LinkButton1" CommandName="Visualizar" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="button-grid" runat="server"> <!-- Text="Selecionar" -->
                                  Visualizar
                                </asp:LinkButton>
                            </div>
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
     <script type="text/javascript">
         $(document).ready(function() {

             $('#<%= GridViewChamados.ClientID %>').prepend($("<thead></thead>").append($('#<%= GridViewChamados.ClientID %>').find("tbody tr:first"))).DataTable({
                 language: {
                     search: "<i class='fa fa-search' aria-hidden='true'>Pesquisar</i>",
                     processing: "Processando...",
                     lengthMenu: "Mostrando _MENU_ registros por páginas",
                     info: "Mostrando página _PAGE_ de _PAGES_",
                     infoEmpty: "Nenhum registro encontrado",
                     infoFiltered: "(filtrado de _MAX_ registros no total)"
                 }
             });

         });
         </script>
</asp:Content>

