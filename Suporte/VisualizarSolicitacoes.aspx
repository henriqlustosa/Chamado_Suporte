﻿<%@ Page Title="Visualizar Solicitações" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VisualizarSolicitacoes.aspx.cs" Inherits="Suporte_VisualizarSolicitacoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap5/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../bootstrap5/dist/js/bootstrap.min.js"></script>
    <link href="../css/print.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
    <asp:Label ID="id_ChamadoRetorno" runat="server" Text="" Visible="False"></asp:Label>
    <asp:Label ID="id_Chamado" runat="server" Text="Label" Visible="False"></asp:Label>
    <div class="row">
        <asp:CheckBox ID="CkbExibeRedeCorporativa" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeSGH" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeSimproc" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeGrafica" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeOSmanutencao" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeSEI" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeSigaSaude" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeDadosComp" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
    </div>
    <div class="container" id="printable">
        <h3 class="text-center fw-bold m-2">Visualizar Solicitação </h3>
        <div class="row m-2">
            <div class="col-auto">
                <%--<div class="col-auto me-auto">--%>
                <asp:Label runat="server" class="fw-bold" Text="Nome do funcionario"></asp:Label>
                <asp:Label ID="txtNomeFuncionario" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
            <div class="col-auto">
                <b>RF/RG</b>
                <asp:Label ID="txtRF" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
            <div class="col-auto">
                <b>Login</b>
                <asp:Label ID="txtLogin" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
            <div class="col-auto">
                <b>Cargo do funcionario</b>
                <asp:Label ID="txtCargo" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
            <div class="col-auto">
                <b>Lotação</b>
                <asp:Label ID="txtLotacao" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
            <div class="col-auto">
                <b>Data do Pedido</b>
                <asp:Label ID="txtData" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
        </div>
        <div class="row m-2">
            <div class="col-auto">
                <b>Coordenador/Chefia)</b>
                <asp:Label ID="txtSolicitante" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
            <div class="col-auto">
                <b>E-mail do Coordenador</b>
                <asp:Label ID="txtEmail" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
            <div class="col-auto">
                <b>Ramal Chefia</b>
                <asp:Label ID="txtRamal" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
            <div class="col-auto">
                <b>Ramal Funcionario</b>
                <asp:Label ID="txtRamalFuncionario" runat="server" class="form-control" BackColor="#EFEFEF"></asp:Label>
            </div>
        </div>
      <h5 class="text-center fw-bold"> Funcionário - <asp:Label ID="LabelEmpresaExibe" runat="server" Text=""></asp:Label></h5>
        <%--<br />--%>
     
        <asp:Panel runat="server" ID="PanelDadosPessoaisTerceiro" BorderStyle="Double" GroupingText="Dados Complementares" Visible="False" align="Center">
            <div id="DivDadosPessoais">
                <div class="row m-0">
                    <%--  <div class="col-auto">
                        Solicitação:
                        <asp:Label runat="server" ID="Label1" Text="Não Preenchido" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>--%>
                    <div class="col-auto">
                        <asp:Label runat="server" ID="LabelDadosCompDtNasc" Text="Data de Nascimento: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompDtNasc_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompNomeDaMae" Text="Nome da Mãe: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompNomeDaMae_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompCRM" Text="CRM:" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompCRM_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompRG" Text="RG:" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompRG_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompCPF" Text="CPF:" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompCPF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelRedeCorporativa" BorderStyle="Double" GroupingText="Rede Corporativa" Visible="False" align="Center">
            <div id="DivRedeCorporativa">
                <div class="row m-0">
                    <div class="col-auto">
                        Solicitação:
                        <asp:Label runat="server" ID="LabelRedeTipoSolicitacao" Text="Não Preenchido" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                    <div class="col-auto">
                        <asp:Label runat="server" ID="LabelRedeEmail" Text="( E-mail Corporativo )" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelRedeCaixaDepartamental" Text="( Caixa Departamental: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelRedeCaixaDepartamental_Descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelRedePastaDeRede" Text="&nbsp;&nbsp;&nbsp;&nbsp; ( Pasta de Rede Solicitada:" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelRedePastaEspecifica" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoRedeCorporativa" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>

            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelSGH" BorderStyle="Double" GroupingText="SGH" Visible="False" align="Center">
            <div id="DivSGH">
                <div class="row m-0">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelAmb" Text="( Ambulatorio: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelAmb_descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelInternacao" Text="( Internação: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelInternacao_descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelCentroCir" Text="( Centro Cirurgico: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelCentroCir_descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelProntoSocorro" Text="( Pronto socorro: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelProntoSocorro_descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoSGH" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelSimproc" BorderStyle="Double" GroupingText="Simproc" Visible="False" HorizontalAlign="Center">
            <div id="DivSimproc">
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSimprocCod_Uni" Text="( Codigo da Unidade: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocCod_Uni_Desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocCpf" Text="( CPF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocCpf_Desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocRG" Text="( RG: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocRG_Desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocDtAdmissao" Text="( Data Admissão: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocDtAdmissao_Desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoSimproc" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelGrafica" BorderStyle="Double" GroupingText="Central/Gráfica" Visible="False" HorizontalAlign="Center">
            <div id="DivGrafica">
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelgraficaSolicitado" Text="Solicitado: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaSolicitada" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaNcentroCusto" Text="( Nº Centro de Custo " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaNcentroCusto_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaNcentroCusto_Antigo" Text="( Nº Centro de Custo-antigo " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaNcentroCusto_Antigo_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaCPF" Text="( CPF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaCPF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoGrafica" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>
            </div>

        </asp:Panel>
        <asp:Panel runat="server" ID="PanelOsManutencao" BorderStyle="Double" GroupingText="OS-Manutencao" Visible="False" HorizontalAlign="Center">
            <div id="OsManutencao">
                <div class="row m-0">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelOsManutencaoNcentroCustoNovo" Text="( Nº centro de custos Novo: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoNcentroCustoNovo_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoNcentroCustoAntigo" Text="( Nº centro de custos Antigo: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoNcentroCustoAntigo_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoCPF" Text="( CPF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoCPF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoOsManutencao" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelSEI" BorderStyle="Double" GroupingText="SEI" Visible="False" HorizontalAlign="Center">
            <div id="DivSei">
                <div class="row m-0">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_1" Text="( Sigla Unidade 1: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_1_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_2" Text="( Sigla Unidade 2: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_2_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_3" Text="( Sigla Unidade 3: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_3_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_4" Text="( Sigla Unidade 4: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_4_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoSEI" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelSiga_Saude" BorderStyle="Double" GroupingText="Siga-Saúde" Visible="False" HorizontalAlign="Center">
            <div id="DivSigaSaude">
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSigaSaudeDtNasc" Text="( Data Nascimento: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeDtNasc_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNomeMae" Text="( Mome da Mãe: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNomeMae_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSigaSaudeCRM" Text="( CRM: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCRM_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCPF" Text="( CPF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCPF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeRG" Text="( RG: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeRG_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeUF" Text="( UF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeUF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeDtEmissao" Text="( Data de Emissão: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeDtEmissao_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeOrgao" Text="( Orgão: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeOrgao_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>

                    </div>
                </div>
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSigaSaudeNomeRua" Text="( Rua: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNomeRua_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNrua" Text="( Nº: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNrua_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeBairro" Text="( Bairro: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeBairro_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCEP" Text="( CEP: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCEP_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSigaSaudeModuloAcessar" Text="( Modulo que irá acessar: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeModuloAcessar_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeOBS" Text="( Obs: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeOBS_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>

                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoSigaSaude" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>

            </div>
        </asp:Panel>

           <div class="row">
            <div class="d-flex flex-row-reverse nav justify-content-center">
                <div class="p-3" id="btnVoltar1">
                    <asp:Button ID="btnVoltar" runat="server" class="button" Text="Voltar para pagina anterior" OnClick="btnVoltar_Click" />
                </div>
            </div>
        </div>

        <div class="row m-2">
            <h6 class="nav justify-content-center"><b>Extrato movimentação</b> </h6>
            <asp:TextBox ID="TextAreaExtrato" runat="server" TextMode="MultiLine" Width="100%" BackColor="#F2F2F2" ReadOnly="True" Height="160px"></asp:TextBox>
        </div>
        <%--       <div class="row">
               <div class="d-flex flex-row-reverse">
  <div class="p-2"> 
                <asp:button id="btnVoltar" runat="server" class="button"
                    text="Voltar" onclick="btnVoltar_Click" />
                </div>
            </div>
    </div>--%>
    </div>


</asp:Content>


