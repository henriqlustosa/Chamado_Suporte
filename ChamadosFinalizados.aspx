<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChamadosFinalizados.aspx.cs" Inherits="ChamadosFinalizados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jquery.js"></script>
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <link href="js/jquery-ui.css" rel="stylesheet" type="text/css" />

   
    <script type="text/javascript">

        $(function () {

            $("[id$=txtCac]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("ChamadosFinalizados.aspx/getCac") %>',
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

            $("[id$=txtPesquisaSetor]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("ChamadosFinalizados.aspx/getSetor") %>',
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

            $("[id$=txtOcorrencia]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("ChamadosFinalizados.aspx/getOcorrencia") %>',
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

            $("[id$=txtSolucao]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("ChamadosFinalizados.aspx/getSolucaoExtrato") %>',
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

    <div class="container">
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="LabelExtratoChamado" runat="server" Text="" Visible="False"></asp:Label>

        <h4 class="text-center">
            <font color="gray"><i>Chamados Finalizados</i> </font></h4>
        <br />
       <%-- <div class="row">
            <div class="col-1">
                <asp:Label ID="Label1" runat="server" Text="Pesquisar:"></asp:Label>
            </div>

            <div class="col-2">
                Data Inicio:
                <asp:TextBox ID="txtDtIni" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                Data Fim:
                <asp:TextBox ID="txtDtFim" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>--%>
        <br />
        <div class="row">
            <div class="col-1">
                <asp:RadioButton ID="rbTodos" runat="server" Text="&nbsp;Todos" Checked="True" GroupName="PesquisaFinalizados" AutoPostBack="True" OnCheckedChanged="Page_Load" OnLoad="Page_Load" />
            </div>
            <div class="col-2">
                <asp:RadioButton ID="rbCac" runat="server" Text="&nbsp;CAC" GroupName="PesquisaFinalizados" AutoPostBack="True" OnCheckedChanged="Page_Load" OnLoad="Page_Load" />
                <asp:TextBox ID="txtCac" runat="server" class="form-control"></asp:TextBox>

            </div>
            <div class="col-2">
                <asp:RadioButton ID="rbSetor" runat="server" Text="&nbsp;Setor" GroupName="PesquisaFinalizados" AutoPostBack="True" OnCheckedChanged="Page_Load" OnLoad="Page_Load" />
                <asp:TextBox ID="txtPesquisaSetor" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:RadioButton ID="rbOcorrencia" runat="server" Text="&nbsp;Ocorrência" GroupName="PesquisaFinalizados" AutoPostBack="True" OnCheckedChanged="Page_Load" OnLoad="Page_Load" />
                <asp:TextBox ID="txtOcorrencia" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:RadioButton ID="rbSolucao" runat="server" Text="&nbsp;Solução" GroupName="PesquisaFinalizados" AutoPostBack="True" OnCheckedChanged="Page_Load" OnLoad="Page_Load" />
                <asp:TextBox ID="txtSolucao" runat="server" class="form-control"></asp:TextBox>
            </div>
            <%-- <div class="col-3">
                 <asp:TextBox ID="txtConteudoPesquisa" runat="server" class="form-control" ></asp:TextBox>
            </div>--%>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <div class="button1">
                    <asp:Button ID="BtnPesquisaFinalizados" runat="server" class="btn btn-success" Text="Pesquisar" OnClick="BtnPesquisaFinalizados_Click" />
                </div>
            </div>
        </div>
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
            <asp:BoundField DataField="dt_hora" HeaderText="Data e Hora" SortExpression="dt_hora"
                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                <ItemStyle CssClass="hidden-xs"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                <ItemTemplate>
                    <div class="form-inline">
                        <asp:LinkButton ID="lbDadosPaciente" CommandName="Reabrir" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                            CssClass="btn alert-info" runat="server"> <!-- Text="Selecionar" -->
                                  Reabrir
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
    <!-- dt_alta_medica
                <asp:BoundField DataField="SituacaoStatus" HeaderText="Status" SortExpression="SituacaoStatus"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                -->
    </div>
</asp:Content>

