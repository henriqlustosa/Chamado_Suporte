<%@ Page Title="Chamados finalizados" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChamadosFinalizados.aspx.cs" Inherits="ChamadosFinalizados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <script type="text/javascript" src="js/jquery.js"></script>
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <link href="js/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../css/content.css" rel="stylesheet" />

<%--    <script type="text/javascript">

        $(function () {

            $("[id$=txtCac]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("ChamadosFinalizados.aspx/getCac") %>',
                        data: "{ 'prefixo': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data)
                        {
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
                        success: function (data)
                        {
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

            $("[id$=txtPesquisaTitulo]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("ChamadosFinalizados.aspx/getTitulo") %>',
                        data: "{ 'prefixo': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data)
                        {
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
                        success: function (data)
                        {
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
                        success: function (data)
                        {
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

            $("[id$=txtNomeContato]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("ChamadosFinalizados.aspx/getNomeContato") %>',
                        data: "{ 'prefixo': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data)
                        {
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
         </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <link href="../js/jquery.dataTable.css" rel="stylesheet" />

       <%--  <script src="../js/jquery.js"></script>--%>
    <script src="../js/jquery.dataTables.js"></script>
    
    <script src="js2/jquery.mask.js"></script>

    <script type="text/javascript">
        $('#<%=txtdtIni.ClientID %>').mask("99/99/9999");
        $('#<%=txtdtFim.ClientID %>').mask("99/99/9999");

    </script>
    <div class="container">
        <asp:label id="pegaNomeLoginUsuario" runat="server" text="" visible="False"></asp:label>
        <asp:label id="LabelExtratoChamado" runat="server" text="" visible="False"></asp:label>

        <h3 class="title-content">Chamados Finalizados</h3>

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

        <div class="row">

            <div class="col-1 fw-bold">
                <asp:radiobutton id="rbTodos" runat="server" text="&nbsp;Geral" checked="True" groupname="PesquisaFinalizados" autopostback="True" oncheckedchanged="Page_Load" onload="Page_Load" />

            </div>
            <div class="col-2">
                Data Inicio<asp:textbox id="txtdtIni" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-2">
                Data Fim<asp:textbox id="txtdtFim" runat="server" class="form-control"></asp:textbox>
            </div>
            OBS: o campo data é somente para a pesquisa Geral
        </div>
        <div class="row">
            <div class="col-1 fw-bold">
                <asp:radiobutton id="rbCac" runat="server" text="&nbsp;CAC" groupname="PesquisaFinalizados" autopostback="True" oncheckedchanged="Page_Load" onload="Page_Load" />
                <asp:textbox id="txtCac" runat="server" class="form-control"></asp:textbox>

            </div>
            <div class="col-2 fw-bold">
                <asp:radiobutton id="rbSetor" runat="server" text="&nbsp;Setor" groupname="PesquisaFinalizados" autopostback="True" oncheckedchanged="Page_Load" onload="Page_Load" />
                <asp:textbox id="txtPesquisaSetor" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-2 fw-bold">
                <asp:radiobutton id="rbTitulo" runat="server" text="&nbsp;Titulo" groupname="PesquisaFinalizados" autopostback="True" oncheckedchanged="Page_Load" onload="Page_Load" />
                <asp:textbox id="txtPesquisaTitulo" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-3 fw-bold">
                <asp:radiobutton id="rbOcorrencia" runat="server" text="&nbsp;Ocorrência" groupname="PesquisaFinalizados" autopostback="True" oncheckedchanged="Page_Load" onload="Page_Load" />
                <asp:textbox id="txtOcorrencia" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-2 fw-bold">
                <asp:radiobutton id="rbSolucao" runat="server" text="&nbsp;Solução" groupname="PesquisaFinalizados" autopostback="True" oncheckedchanged="Page_Load" onload="Page_Load" />
                <asp:textbox id="txtSolucao" runat="server" class="form-control"></asp:textbox>
            </div>
              <div class="col-2 fw-bold">
                <asp:radiobutton id="rbNomeContato" runat="server" text="&nbsp;Nome Contato" groupname="PesquisaFinalizados" autopostback="True" oncheckedchanged="Page_Load" onload="Page_Load" />
                <asp:textbox id="txtNomeContato" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-1"></div>
            <%-- <div class="col-3">
                 <asp:TextBox ID="txtConteudoPesquisa" runat="server" class="form-control" ></asp:TextBox>
            </div>--%>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <div class="div-btn">
                    <asp:button id="BtnPesquisaFinalizados" runat="server" class="button" text="Pesquisar" onclick="BtnPesquisaFinalizados_Click" />
                </div>
            </div>
        </div>
        <br />
        <asp:gridview id="GridViewChamados" autogeneratecolumns="False" datakeynames="id"
            runat="server" onrowcommand="grdDadosPacienteSGH_RowCommand" cssclass="table table-bordered"
            headerstyle-horizontalalign="Center" headerstyle-verticalalign="Middle"
            headerstyle-backcolor="#3b7b92" headerstyle-forecolor="#ffffff" bordercolor="#29336b">
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
                <asp:BoundField DataField="ocorrencia" HeaderText="Ocorrencia" SortExpression="ocorrencia"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                  <asp:BoundField DataField="nomeTecnico" HeaderText="Tecnico" SortExpression="nomeTecnico"
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
        </asp:gridview>
        <!-- dt_alta_medica
                <asp:BoundField DataField="SituacaoStatus" HeaderText="Status" SortExpression="SituacaoStatus"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                -->
    </div>
       <%--<script type="text/javascript">
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
         </script>--%>
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
                        success: function (data)
                        {
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
                        success: function (data)
                        {
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

            $("[id$=txtPesquisaTitulo]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("ChamadosFinalizados.aspx/getTitulo") %>',
                        data: "{ 'prefixo': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data)
                        {
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
                        success: function (data)
                        {
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
                        success: function (data)
                        {
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

            $("[id$=txtNomeContato]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("ChamadosFinalizados.aspx/getNomeContato") %>',
                        data: "{ 'prefixo': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data)
                        {
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

