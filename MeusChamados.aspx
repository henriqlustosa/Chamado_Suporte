<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MeusChamados.aspx.cs" Inherits="MeusChamados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="container">
      <br />
            <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
           <asp:Label ID="LabelExtratoChamado" runat="server" Text="" Visible="False"></asp:Label>
        <h4 class="text-center">
            <font color="blue"><i>Chamados em Espera do <asp:LoginName ID="LoginName1" runat="server" /> </i> </font></h4>
       <br />
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
                <asp:BoundField DataField="statusDochamado" HeaderText="Status" SortExpression="statusDochamado"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="dt_hora" HeaderText="Data e Hora" SortExpression="dt_hora"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                    <ItemTemplate>
                        <div class="form-inline">
                            <asp:LinkButton ID="lbDadosPaciente" CommandName="atender" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                CssClass="btn alert-info" runat="server"> <!-- Text="Selecionar" -->
                                  Atender
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="sorting_disabled"></HeaderStyle>
                </asp:TemplateField>
                 <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="LinkButton1" CommandName="Visualizar" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="btn alert-info" runat="server"> <!-- Text="Selecionar" -->
                                  Visualizar
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle CssClass="sorting_disabled"></HeaderStyle>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
      
    </div>
</asp:Content>

