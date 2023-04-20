<%@ Page Title="Em atendimento" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="emAtendimento.aspx.cs" Inherits="emAtendimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/alinharbtn.css" rel="stylesheet" />
    <link href="../css/content.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/jquery.mask.js"></script>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        
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
                <asp:TextBox ID="txtSetor" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2 fw-bold">
                Nome contato:
                <asp:TextBox ID="txtNomeContato" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-2 fw-bold">
                Ramal:
                <asp:TextBox ID="txtRamal" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
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
            <div class="col-2 fw-bold">
                Título:
                <asp:TextBox ID="txtTitulo" runat="server" class="form-control" required ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-8 fw-bold">
                Ocorrência:
                <asp:TextBox ID="txtOcorrencia" runat="server" class="form-control" required TextMode="MultiLine"
                    MaxLength="500" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-1"></div>
        </div>
        <br />
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10 fw-bold">
                Solução:
                <asp:TextBox ID="txtSolucao" runat="server" class="form-control" required
                    TextMode="MultiLine" MaxLength="500" Height="174px"></asp:TextBox>
            </div>
            <div class="col-1"></div>
        </div>
        <br />
        <%--<div class="space-buttons justify-content-evenly" id="pills-tab">
            <div>
                <input id="btnFinalizarC" type="button" value="Finalizar" onclick="finaliza_chamado()" 
                    class="btn-encaminhar" data-bs-target="#btnFinalizar" data-bs-toggle="pill"
                    aria-selected="false" aria-controls="btnFinalizar"/>
            </div>
            <div>
                <input id="btnEmEspera1" type="button" value="Em espera" onclick="mostra3()" 
                    class="btn-encaminhar" data-bs-target="#btnEncamihar" data-bs-toggle="pill"
                    aria-selected="false"/>
            </div>
            <div>
                <input id="btnRetornar" type="button" value="Reclassificar" onclick="reclassificar()" 
                    class="btn-encaminhar" data-bs-target="#btnReclassificar" data-bs-toggle="pill"
                    aria-selected="false"/>
            </div>
            <div class="div-encaminhar">
                <asp:button id="btnEncaminhar" runat="server" class="btn-encaminhar" text="Encaminhar" onclick="btnEncaminhar_Click" />
                &nbsp;
                <asp:dropdownlist id="DdlEncaminharParaTecnico" runat="server" class="form-control" datasourceid="SqlDataSource1" datatextfield="UserName" datavaluefield="UserName"></asp:dropdownlist>
                <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:chamado_suporteConnectionString %>" selectcommand="SELECT [UserName] FROM [vw_aspnet_Users] ORDER BY [UserName]"></asp:sqldatasource>
            </div>
        </div>
        <br />
         <div id="FinalizarChamado" style='display: none;'>
            <div class="row">
                <div class="col-2"></div>
                <div class="col-4">
                    <span class="fw-bold">Solução:</span>
                    <asp:dropdownlist id="ddlTipoSolucao" runat="server" class="form-control" datasourceid="SqlDataSource3" datatextfield="nomeSolucao" datavaluefield="nomeSolucao"></asp:dropdownlist>
                    <asp:sqldatasource id="SqlDataSource3" runat="server" connectionstring="<%$ ConnectionStrings:chamado_suporteConnectionString %>" selectcommand="SELECT [nomeSolucao] FROM [padraoSolucao] ORDER BY [nomeSolucao]"></asp:sqldatasource>
                </div>
                <div class="col-2 div-btnbloquear">
                    <asp:button id="btnFinalizar" runat="server" class="btn-guia div-input"
                        text="Finalizar" onclick="btnFinalizar_Click" />
                </div>
                <div class="col-4"></div>
            </div>
             <br />
            <div class="row">
                <div class="col-2"></div>
                <div class="col-2">
                    <span class="fw-bold">Título(se precisar alterar): </span>
                    
                <asp:dropdownlist runat="server" class="form-control" id="ddlTituloAlterar" datasourceid="SqlDataSource2" datatextfield="NomeTipoChamado" datavaluefield="NomeTipoChamado"></asp:dropdownlist>
                    <asp:sqldatasource id="SqlDataSource4" runat="server" connectionstring="<%$ ConnectionStrings:chamado_suporteConnectionString %>" selectcommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:sqldatasource>
                </div>
                <div class="col-8"></div>
            </div>
    </div>

         <div id="EncaminharExterno" style='display: none;'>
            <div class="row" id="RbStatus">
                <div class="col-3"></div>
                <div class="col-2">
                    <asp:radiobutton id="RbtAtendimentoLocal" runat="server" groupname="Status" text="&ensp;Atendimento Local" checked="True" />
                </div>
                <div class="col-2">
                    <asp:radiobutton id="RbtDell" runat="server" groupname="Status" text="&ensp;Externo DELL" />
                </div>
                <div class="col-2">
                    <asp:radiobutton id="RbtImpressora" runat="server" groupname="Status" text="&ensp;Externo Impressora" />
                </div>
                <div class="col-3"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-4"></div>
                <div class="col-3">
                    <asp:label id="Label1" runat="server" text="Infome a TAG / Nº de serie:"></asp:label>
                    <asp:textbox id="txtTagNserie" runat="server" class="form-control"></asp:textbox>
                </div>
                <div class="col-1">
                    <asp:label id="Label2" runat="server" text="&ensp;&ensp;"></asp:label>
                    <asp:button id="btnEmEspera" runat="server" class="btn btn-info" text="Cadastar" onclick="btnEmEspera_Click" />
                </div>
                <div class="col-4"></div>
            </div>
        </div>

         <div id="Re-classificar" style='display: none;'>
        <div class="row">
            <div class="col-3"></div>
            <div class="col-4">
                Título:
                <asp:dropdownlist runat="server" class="form-control" id="ddlTitulo" datasourceid="SqlDataSource2" datatextfield="NomeTipoChamado" datavaluefield="NomeTipoChamado"></asp:dropdownlist>
                <asp:sqldatasource id="SqlDataSource2" runat="server" connectionstring="<%$ ConnectionStrings:chamado_suporteConnectionString %>" selectcommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:sqldatasource>
            </div>
            <div class="col-2">
                <asp:label id="Label3" runat="server" text="&ensp;&ensp;"></asp:label>
                <asp:button id="btnAtualizar" runat="server" class="btn btn-success" text="Atualizar" onclick="btnAtualizar_Click" />
            </div>
            <div class="col-3"></div>
        </div>
    </div>--%>
        <br />
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10">
                <div class="space-buttons nav nav-pills mb-3" id="pills-tab" role="tablist">
                    <div class="col-3">
                        <input class="buttonverde" id="btnFinalizarC" data-bs-toggle="pill" value="Finalizar"
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
                                        <asp:DropDownList runat="server" class="form-control" ID="ddlTituloAlterar" DataSourceID="SqlDataSource2" DataTextField="NomeTipoChamado" DataValueField="NomeTipoChamado"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:SqlDataSource>
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
                                <div class=" fw-bold">
                                    Título:
                                    <asp:DropDownList runat="server" class="form-control" ID="ddlTitulo" DataSourceID="SqlDataSource2" DataTextField="NomeTipoChamado" DataValueField="NomeTipoChamado"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:SqlDataSource>
                                </div>
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
        <br />
        
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10">
                <span class="fw-bold">Movimentação do chamado até o momento:</span>
                <asp:TextBox ID="txtExtratoChamado" runat="server" class="form-control" required Rows="5" TextMode="MultiLine" ReadOnly="True" BackColor="#F2F2F2"></asp:TextBox>
            </div>
            <div class="col-1"></div>
        </div>

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
