<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Cadastrar.aspx.cs" Inherits="Cadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <%--  <style type="text/css">
        input
        {
            text-align: left;
        }
    </style>--%>

    
    <script type="text/javascript" src="js/jquery.js"></script>

   <%-- <script type="text/javascript" src="js/jquery.mask.js"></script>--%>

    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <script src="js/jquery.js" type="text/javascript"></script>

    <%--<script src="js/jquery.mask.js" type="text/javascript"></script>--%>

    <script src="js/jquery-ui.js" type="text/javascript"></script>

    <link href="js/jquery-ui.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        $(function() {

            $("[id$=txtSetor]").autocomplete({
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("Cadastrar.aspx/getSetor") %>',
                        data: "{ 'prefixo': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {
                            response($.map(data.d, function(item) {
                                return {
                                    label: item.split(';')[0],
                                    val: item.split(';')[1]
                                }
                            }))
                        },
                        error: function(response) {
                            alert(response.responseText);
                        },
                        failure: function(response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function(e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript">
        $('#<%=txtDtCir.ClientID %>').mask("99/99/9999");                 
    </script>--%>
   

    <div class="container">        
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <br />
        <h4 class="text-center">
            <font color="blue"><i>Chamados Informatica</i> </font></h4>        
        <br />
        <br />
        <div class="font-weight-bold">
        <div class="row">
            <div class="col-2">
                Cac:
                <asp:TextBox ID="txtCac" runat="server" class="form-control" required Text="HSPMCAC"></asp:TextBox>
            </div>
            <div class="col-3">
                Setor:
              <asp:TextBox ID="txtSetor" runat="server" class="form-control" required></asp:TextBox>
               <%-- <asp:dropdownlist runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="setor" DataValueField="setor" ID="ddlSetor"></asp:dropdownlist>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [setor] FROM [LocalSetor] ORDER BY [setor]"></asp:SqlDataSource>--%>
            </div>
            <div class="col-3">
                Nome contato:
                <asp:TextBox ID="txtNomeContato" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-2">
                Ramal:
                <asp:TextBox ID="txtRamal" runat="server" class="form-control" required></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                Titulo:
                <%--<asp:TextBox ID="txtTitulo" runat="server" class="form-control" required></asp:TextBox>--%>
                <asp:dropdownlist runat="server" class="form-control" ID="ddlTitulo" DataSourceID="SqlDataSource2" DataTextField="NomeTipoChamado" DataValueField="NomeTipoChamado"></asp:dropdownlist>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:SqlDataSource>
            </div>
            <div class="col-8">
                Ocorrência:
                <asp:TextBox ID="txtOcorrencia" runat="server" class="form-control" required TextMode="MultiLine"
                    MaxLength="500" Rows="4"></asp:TextBox>
            </div>
            <div class="col-1">
            </div>
        </div>
            </div>
        <br />
        <div class="row">
            <div class="col-4">
            </div>
            <asp:Button ID="btnCadastrar" runat="server" class="btn btn-success" Text="Cadastrar"
                OnClick="btnPesquisar_Click" />
            <div class="col-5">
                
            </div>
            <%--<input id="btnPesquisar" type="button" onclick="gerarTabela()" class="btn btn-success"
                    value="Pesquisar" />--%>
        </div>
        <%-- </div>--%>
        <br />
        <div>
            <asp:GridView ID="GridViewChamados" AutoGenerateColumns="False" DataKeyNames="id"
                runat="server" OnRowCommand="grdDadosPacienteSGH_RowCommand" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Chamado" SortExpression="id" ItemStyle-CssClass="hidden-xs"
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
                      <asp:BoundField DataField="nomeContato" HeaderText="Nome Contato" SortExpression="nomeContato" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
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
                    <asp:BoundField DataField="dt_hora" HeaderText="Data e Hora" SortExpression="dt_hora" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
                        <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                        <ItemStyle CssClass="hidden-xs"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="lbDadosPaciente" CommandName="editarCirurgia" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="btn alert-info" runat="server"> <!-- Text="Selecionar" -->
                                  Visualizar
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
    </div>
</asp:Content>