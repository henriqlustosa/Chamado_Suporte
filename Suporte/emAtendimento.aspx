<%@ Page Title="Em atendimento" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="emAtendimento.aspx.cs" Inherits="emAtendimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/alinharbtn.css" rel="stylesheet" />
    <link href="../css/content.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/jquery.mask.js"></script>

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
                        url: '<%=ResolveUrl("emAtendimento.aspx/getSetor") %>',
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

            $("[id$=txtTutuloAlterarSePrecisar]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("emAtendimento.aspx/getTituloAberturaChamado") %>',
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
  <%--  txtReclassificarChamado--%>
    <script type="text/javascript">

        $(function () {

            $("[id$=txtReclassificarChamado]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("emAtendimento.aspx/getTituloAberturaChamado") %>',
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
    <div class="container-fluid">
        <asp:Label ID="labelOcorrenciaIdSolicitacao" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>

        <h3 class="title-content">Em Atendimento</h3>
        <asp:Label ID="LabelID" runat="server" Text="Label" Visible="False"></asp:Label>
        <div class="row">
            <div class="col-1"></div>
            <div class="col-2 fw-bold">
                CAC:
                <asp:TextBox ID="txtCac" runat="server" class="form-control" required Text="HSPMCAC"></asp:TextBox>
            </div>
            <div class="col-2 fw-bold">
                Setor:
                <asp:TextBox ID="txtSetor" runat="server" class="form-control" required ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2 fw-bold">
                Nome contato:
                <asp:TextBox ID="txtNomeContato" runat="server" class="form-control" required ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2 fw-bold">
                Ramal:
                <asp:TextBox ID="txtRamal" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-2 fw-bold">
                Chamado aberto em:
                <asp:TextBox ID="txtHoraDtChamado" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>

            </div>
            <div class="col-1"></div>
        </div>
        <br />
        <div class="row">
            <div class="col-1"></div>
            <div class="col-3 fw-bold">
                Título:
              <asp:TextBox ID="txtTituloAberturaChamado" runat="server" class="form-control" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <%--<div class="col-2 fw-bold">
                Título:
                <asp:TextBox ID="txtTitulo" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>--%>
            <div class="col-7 fw-bold">
                Ocorrência:
                <asp:TextBox ID="txtOcorrencia" runat="server" class="form-control" required TextMode="MultiLine"
                    MaxLength="500" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-1"></div>
        </div>
        <div class="text-center">
            <asp:LinkButton ID="btnLinkSolicitacao" runat="server" OnClick="btnLinkSolicitacao_Click">Visualizar Solicitação</asp:LinkButton></div>
        <br />
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10 fw-bold">
                Solução:
                <asp:TextBox ID="txtSolucao" runat="server" class="form-control" required
                    TextMode="MultiLine" MaxLength="500" Height="174px"></asp:TextBox>
            </div>
            <div class="col-1">
            </div>
        </div>
        <div class="row">
            <div class="col-1"></div>
            <div class="col-4">
                Selecionar Imagem
                <asp:FileUpload ID="FileUpload1" runat="server" accept="image/jpg, image/png, image/jpeg" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10">
                <div class="space-buttons nav nav-pills mb-3" id="pills-tab" role="tablist">
                    <div class="col-3">
                        <input class="buttonverde" id="btnFinalizarC" data-bs-toggle="pill" value="Opções Finalizar"
                            data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home"
                            aria-selected="true" onclick="finaliza_chamado()" />
                    </div>
                    <div class="col-3">
                        <input class="buttonverde" id="btnEmEspera1" data-bs-toggle="pill" value="Em espera"
                            data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile"
                            aria-selected="false" />
                    </div>
                    <div class="col-3">
                        <input class="buttonverde" id="pills-contact-tab" data-bs-toggle="pill" value="Reclassificar"
                            data-bs-target="#pills-contact" type="button" role="tab" aria-controls="pills-contact"
                            aria-selected="false" />
                    </div>
                    <div class="col-3 div-encaminhar">
                        <asp:Button ID="btnEncaminhar" runat="server" class="buttonverde" Text="Encaminhar" OnClick="btnEncaminhar_Click" />
                        &nbsp;
                                <asp:DropDownList ID="DdlEncaminharParaTecnico" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserName"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [UserName] FROM [vw_aspnet_Users] ORDER BY [UserName]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
            <div class="col-1"></div>
        </div>
        <div id="divId" class="hidden">
            <div class="row">
                <div class="col-1"></div>
                <div class="col-10">
                    <div class="tab-content nav nav-pills mb-3" id="pills-tabContent" role="tablist">
                        <div class="col-3">
                            <div class="tab-pane fade" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                                <div class="row">
                                    <div>
                                        <span class="fw-bold">Solução:</span>
                                        <asp:DropDownList ID="ddlTipoSolucao" runat="server" class="form-control" DataSourceID="SqlDataSource3" DataTextField="nomeSolucao" DataValueField="nomeSolucao"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [nomeSolucao] FROM [padraoSolucao] ORDER BY [nomeSolucao]"></asp:SqlDataSource>
                                    </div>
                                    <div class="div-btntab">
                                        <asp:Button ID="btnFinalizar" runat="server" class="buttonazul div-input "
                                            Text="Finalizar" OnClick="btnFinalizar_Click" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div>
                                        <span class="fw-bold">Título (se precisar alterar): </span>
                                        <div class="col-auto fw-bold">                                        
              <asp:TextBox ID="txtTutuloAlterarSePrecisar" runat="server" class="form-control" required></asp:TextBox>
                                        </div>
                                        <%--<asp:DropDownList runat="server" class="form-control" ID="ddlTituloAlterar" DataSourceID="SqlDataSource2" DataTextField="NomeTipoChamado" DataValueField="NomeTipoChamado"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:SqlDataSource>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                                <div class="row " id="RbStatus">
                                    <div class="fw-bold">
                                        <asp:RadioButton ID="RbtAtendimentoLocal" runat="server" GroupName="Status" Text="&ensp;Atendimento Local" Checked="True" />
                                    </div>
                                    <div class="fw-bold">
                                        <asp:RadioButton ID="RbtInterManutencao" runat="server" GroupName="Status" Text="&ensp;Interno Manutenção" />
                                    </div>
                                    <div class="fw-bold">
                                        <asp:RadioButton ID="RbtDell" runat="server" GroupName="Status" Text="&ensp;Externo DELL" />
                                    </div>
                                    <div class="fw-bold">
                                        <asp:RadioButton ID="RbtImpressora" runat="server" GroupName="Status" Text="&ensp;Externo Impressora" />
                                    </div>
                                    <div class="fw-bold">
                                        <asp:RadioButton ID="RbtDiurno" runat="server" GroupName="Status" Text="&ensp;Encaminhar Diurno" />
                                    </div>
                                    <div class="fw-bold">
                                        <asp:RadioButton ID="RbtNoturno" runat="server" GroupName="Status" Text="&ensp;Encaminhar Noturno" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="fw-bold">
                                        <asp:Label ID="Label1" runat="server" Text="Infome a TAG / Nº de série:"></asp:Label>
                                        <asp:TextBox ID="txtTagNserie" runat="server" class="form-control" MaxLength="20"></asp:TextBox>
                                    </div>
                                    <div class="div-btntab">
                                        <asp:Button ID="btnEmEspera" runat="server" class="buttonazul div-input" Text="Cadastrar" OnClick="btnEmEspera_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="tab-pane fade" id="pills-contact" role="tabpanel" aria-labelledby="pills-contact-tab">
                                <div class="col-auto fw-bold">                                        
              <asp:TextBox ID="txtReclassificarChamado" runat="server" class="form-control" placeholder="Digite e Localize (Clique sobre o titulo)"></asp:TextBox>
                                    </div>
                               <%-- <div class=" fw-bold">
                                    Título:
                                    <asp:DropDownList runat="server" class="form-control" ID="ddlTitulo" DataSourceID="SqlDataSource2" DataTextField="NomeTipoChamado" DataValueField="NomeTipoChamado"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:SqlDataSource>
                                </div>--%>
                                <div class="div-btntab">
                                    <asp:Button ID="btnAtualizar" runat="server" class="buttonazul div-input" Text="Atualizar" OnClick="btnAtualizar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-1"></div>
            </div>
        </div>
        <%--   <br /> --%>
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10">
                <span class="fw-bold">Movimentação do chamado até o momento:</span>
                <asp:TextBox ID="txtExtratoChamado" runat="server" class="form-control" Rows="4" TextMode="MultiLine" MaxLength="2000" ReadOnly="True" BackColor="#F2F2F2" Visible="true"></asp:TextBox>
            </div>
            <div class="col-1"></div>
        </div>
        <br />

        <div id="imgAbertura">
            <div class="container figure-img">
                <asp:Label ID="LabelImagemTituloAbertura" runat="server" Text=" Enviada pelo Usuário" Visible="false" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <asp:Image ID="imgChamado" runat="server" ImageAlign="NotSet" AlternateText="Sem imagem do Usuário" Width="100%" Height="100%" BorderStyle="Inset" BorderWidth="4" />
            </div>
        </div>
        <br />
        <div id="imgFechamentodiv">
            <%-- <div id="imgFechamentodiv" style='display: none;'>--%>
            <div class="container figure-img">
                <asp:Label ID="LabelImagemTituloFechamanto" runat="server" Text=" Enviada pelo Técnico" Visible="false" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <asp:Image ID="imgFechamento" runat="server" ImageAlign="NotSet" AlternateText="Sem imagem enviada pelo Técnico" Width="100%" Height="100%" BorderStyle="Inset" BorderWidth="4" />
            </div>
        </div>

        <script type="text/javascript">
            function MostraImgAbertura() {

                var div = document.getElementById('imgAbertura');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>
        <script type="text/javascript">
            function MostraImgFechamento() {

                var div = document.getElementById('imgFechamentodiv');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>

        <script type="text/javascript">
            $('input').on('click', function () {
                $('#divId').show(); // aparece o div
            });
        </script>

        <script type="text/javascript">
            function reclassificar() {

                var div = document.getElementById('Re-classificar');
                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>

        <script type="text/javascript">
            function mostra3() {

                var div = document.getElementById('EncaminharExterno');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>

        <script type="text/javascript">
            function finaliza_chamado() {

                var div = document.getElementById('FinalizarChamado');
                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>
    </div>

</asp:Content>
