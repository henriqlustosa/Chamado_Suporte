<%@ Page Title="Cadastrar chamado" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Cadastrar.aspx.cs" Inherits="Cadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--  <style type="text/css">
        input
        {
            text-align: left;
        }
    </style>--%>
    <link href="bootstrap5/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap5/dist/js/bootstrap.min.js"></script>
    <link href="../css/content.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <%-- <script type="text/javascript" src="js/jquery.mask.js"></script>--%>
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <%--<script src="js/jquery.mask.js" type="text/javascript"></script>--%>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <link href="js/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(function () {

            $("[id$=txtSetor]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("Cadastrar.aspx/getSetor") %>',
                        data: "{ 'prefixo': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split(';')[0],
                                    val: item.split(';')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });

    </script>
      <script type="text/javascript">

        $(function () {

            $("[id$=txtTituloAberturaChamado]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("Cadastrar.aspx/getTituloAberturaChamado") %>',
                        data: "{ 'prefixo': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split(';')[0],
                                    val: item.split(';')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js2/jquery.mask.js"></script>
    <script type="text/javascript">
        $('#<%=txtCac.ClientID %>').mask("9999");
    </script>
    <div class="container">
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <div class="row">
            <div class="col-12">
                <h3 class="title-content">Cadastrar Chamados</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-1"></div>
            <div class="col-2 fw-bold">
                CAC:
                <asp:TextBox ID="txtCac" runat="server" placeholder="Digite o número do CAC" class="form-control" MaxLength="14"></asp:TextBox>
            </div>
            <div class="col-3 fw-bold">
                Setor:
              <asp:TextBox ID="txtSetor" runat="server" class="form-control" required MaxLength="50" placeholder="Digite e Localize (Clique sobre o Setor)"></asp:TextBox>
            </div>
            <div class="col-3 fw-bold">
                Nome contato:
                <asp:TextBox ID="txtNomeContato" runat="server" class="form-control" required MaxLength="60"></asp:TextBox>
            </div>
            <div class="col-2 fw-bold">
                Ramal:
                <asp:TextBox ID="txtRamal" runat="server" class="form-control" required MaxLength="15"></asp:TextBox>
            </div>
            <div class="col-1"></div>
        </div>
        <br />
        <div class="row">
            <div class="col-1"></div>
              <div class="col-3 fw-bold">
                Título:
              <asp:TextBox ID="txtTituloAberturaChamado" runat="server" class="form-control" required MaxLength="50" placeholder="Digite e Localize (Clique sobre o titulo)"></asp:TextBox>
            </div>
           <%-- <div class="col-2 fw-bold">
                Título:
                        <asp:DropDownList runat="server" class="form-control" ID="ddlTitulo" DataSourceID="SqlDataSource2" DataTextField="NomeTipoChamado" DataValueField="NomeTipoChamado"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:SqlDataSource>
            </div>--%>
            <div class="col-8 fw-bold">
                Ocorrência:
                <asp:TextBox ID="txtOcorrencia" runat="server" class="form-control" required TextMode="MultiLine"
                    MaxLength="500" Rows="4"></asp:TextBox>
            </div>
            <div class="col-1"></div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10 div-btn ">
                <asp:Button CssClass="button" ID="btnCadastrar" runat="server" class="btn btn-success" Text="Cadastrar"
                    OnClick="btnPesquisar_Click" />
            </div>
            <div class="col-1"></div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-1"></div>
        <div class="col-10">
            <asp:GridView ID="GridViewChamados" AutoGenerateColumns="False" DataKeyNames="id"
                runat="server" OnRowCommand="grdDadosPacienteSGH_RowCommand" CssClass="table table-bordered" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"
                HeaderStyle-BackColor="#3b7b92" HeaderStyle-ForeColor="#ffffff" BorderColor="#29336b">
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
                    <asp:BoundField DataField="nomeContato" HeaderText="Nome Contato" SortExpression="nomeContato" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
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
                    <asp:BoundField DataField="dt_hora" HeaderText="Data e Hora" SortExpression="dt_hora" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs">
                        <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                        <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                        <ItemTemplate>
                            <div class="div-btngrid">
                                <asp:LinkButton ID="lbDadosPaciente" CommandName="editarCirurgia" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="button-grid" runat="server">
                                  Visualizar
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle CssClass="sorting_disabled"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-1"></div>
        <!-- dt_alta_medica
                <asp:BoundField DataField="SituacaoStatus" HeaderText="Status" SortExpression="SituacaoStatus"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                -->

       <%-- <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Enviar Imagem" OnClick="Unnamed1_Click" />
        </div>
        <asp:Image ID="imgChamado" runat="server" /> Junior 18/10/2023 --%> 
    </div>
    <%--<script type="text/javascript">

        // função para desabilitar a tecla F5.
        window.onkeydown = function (e) {
            if (e.keyCode === 116) {
                alert("Função não permitida");
                e.keyCode = 0;
                e.returnValue = false;
                return false;
            }
        }
    </script>--%>
</asp:Content>
