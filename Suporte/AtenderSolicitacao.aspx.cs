using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adm_AtenderSolicitacao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string id1 = Request.QueryString["IdChamado"];
            int id = Convert.ToInt32(id1);
            //int id2 = 22;
            carregarDadosSolicitante(id);
            id_Chamado.Text = id1;
            //id_Chamado.Text = "22";
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
            verificaCBK_SituacaoNobanco(Convert.ToInt32(id_Chamado.Text));
            verificaCBK();

        }
    }


    private void carregarDadosSolicitante(int id)
    {
        //carrega os campos textos (Feito pelo Henrique)
        DadosSolicitacao lista = new DadosSolicitacao();
        lista = SolicitaAcessoDAO.GetDadosDaSolitacaoParaAtender(id);
        txtNomeFuncionario.Text = lista.NomeFuncionario;
        txtRF.Text = lista.RF_Funcionario.ToString();
        txtLogin.Text = lista.login;
        txtCargo.Text = lista.cargoFuncionario;
        txtEmail.Text = lista.eMail;
        txtRamal.Text = lista.ramal1;
        txtRamalFuncionario.Text = lista.ramalFuncionario;
        txtLotacao.Text = lista.lotacao;
        txtData.Text = lista.dtSolicitacao.ToShortDateString();
        txtSolicitante.Text = lista.NomeSolicitante_Coordenador;
        LabelEmpresaExibe.Text = lista.NomeEmpresaHSPM_Terceiros;
    }

    private void verificaCBK_SituacaoNobanco(int id)
    {
        CkbExibeRedeCorporativa.Checked = false;
        ckbExibeSGH.Checked = false;
        ckbExibeSimproc.Checked = false;
        ckbExibeGrafica.Checked = false;
        ckbExibeOSmanutencao.Checked = false;
        ckbExibeSEI.Checked = false;
        ckbExibeSigaSaude.Checked = false;
        ckbExibeDadosComp.Checked = false;

        DadosSetoresSolicitados_S lista = new DadosSetoresSolicitados_S();
        lista = SolicitaAcessoDAO.GetSetoresCom_S(id);
        if (lista.RedeCorporativa == "S")
        {
            CkbExibeRedeCorporativa.Checked = true;
        }
        if (lista.SGH == "S")
        {
            ckbExibeSGH.Checked = true;
        }
        if (lista.Simproc == "S")
        {
            ckbExibeSimproc.Checked = true;
        }
        if (lista.Grafica == "S")
        {
            ckbExibeGrafica.Checked = true;
        }
        if (lista.OS_manutencao == "S")
        {
            ckbExibeOSmanutencao.Checked = true;
        }
        if (lista.Sei == "S")
        {
            ckbExibeSEI.Checked = true;
        }
        if (lista.Siga_Saude == "S")
        {
            ckbExibeSigaSaude.Checked = true;
        }
        if (lista.DadosSolicitadosSGH == "S" || lista.DadosSolicitadosSGH == "C")
        {
            ckbExibeDadosComp.Checked = true;
        }
    }

    private void verificaCBK()
    {
        if (CkbExibeRedeCorporativa.Checked == true)
        {
            PanelRedeCorporativa.Visible = true;
            CarregaRedeCorporativa(Convert.ToInt32(id_Chamado.Text));
        }
        if (CkbExibeRedeCorporativa.Checked == false)
        {
            PanelRedeCorporativa.Visible = false;
        }
        if (ckbExibeSGH.Checked == true)
        {
            PanelSGH.Visible = true;
            CarregaSGH(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeSGH.Checked == false)
        {
            PanelSGH.Visible = false;
        }
        if (ckbExibeSimproc.Checked == true)
        {
            PanelSimproc.Visible = true;
            CarregaSimproc(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeSimproc.Checked == false)
        {
            PanelSimproc.Visible = false;
        }
        if (ckbExibeGrafica.Checked == true)
        {
            PanelGrafica.Visible = true;
            CarregaGrafica(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeGrafica.Checked == false)
        {
            PanelGrafica.Visible = false;
        }
        if (ckbExibeOSmanutencao.Checked == true)
        {
            PanelOsManutencao.Visible = true;
            CarregaOSmanutencao(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeOSmanutencao.Checked == false)
        {
            PanelOsManutencao.Visible = false;
        }
        if (ckbExibeSEI.Checked == true)
        {
            PanelSEI.Visible = true;
            CarregaSEI(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeSEI.Checked == false)
        {
            PanelSEI.Visible = false;
        }
        if (ckbExibeSigaSaude.Checked == true)
        {
            PanelSiga_Saude.Visible = true;
            CarregaSigaSaude(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeSigaSaude.Checked == false)
        {
            PanelSiga_Saude.Visible = false;
        }
        if (ckbExibeDadosComp.Checked == true)
        {
            PanelDadosPessoaisTerceiro.Visible = true;
            CarregaDadosSGH_Comp(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeDadosComp.Checked == false)
        {
            PanelDadosPessoaisTerceiro.Visible = false;
        }

        carregaExtratoSocilitaAcesso(Convert.ToInt32(id_Chamado.Text));
    }

    private void carregaExtratoSocilitaAcesso(int idChamado)
    {
        TextAreaExtrato.Text = SolicitaAcessoDAO.GetDadosExtratoAcesso(idChamado);
    }

    private void CarregaSigaSaude(int id)
    {
        DadosSigaSaude lista = new DadosSigaSaude();
        lista = SolicitaAcessoDAO.GetDadosSigaSaude(id);
        labelSigaSaudeDtNasc.Visible = true;
        labelSigaSaudeDtNasc_desc.Text = lista.dtNascSiga + " )";
        labelSigaSaudeNomeMae.Visible = true;
        labelSigaSaudeNomeMae_desc.Text = lista.nomeDaMaeSiga + " )";
        labelSigaSaudeCRM.Visible = true;
        labelSigaSaudeCRM_desc.Text = lista.CRM_siga + " )";
        labelSigaSaudeCPF.Visible = true;
        labelSigaSaudeCPF_desc.Text = lista.cpfSiga + " )";
        labelSigaSaudeRG.Visible = true;
        labelSigaSaudeRG_desc.Text = lista.RG_siga + " )";
        labelSigaSaudeUF.Visible = true;
        labelSigaSaudeUF_desc.Text = lista.UF_Siga + " )";
        labelSigaSaudeDtEmissao.Visible = true;
        labelSigaSaudeDtEmissao_desc.Text = lista.dtEmisaoRG_Siga + " )";
        labelSigaSaudeOrgao.Visible = true;
        labelSigaSaudeOrgao_desc.Text = lista.orgao_RG_Siga + " )";
        labelSigaSaudeNomeRua.Visible = true;
        labelSigaSaudeNomeRua_desc.Text = lista.nomeDaRuaSiga + " )";
        labelSigaSaudeNrua.Visible = true;
        labelSigaSaudeNrua_desc.Text = lista.NumeroDaRuaSiga + " )";
        labelSigaSaudeBairro.Visible = true;
        labelSigaSaudeBairro_desc.Text = lista.bairoSiga + " )";
        labelSigaSaudeCEP.Visible = true;
        labelSigaSaudeCEP_desc.Text = lista.CepSiga + " )";
        labelSigaSaudeModuloAcessar.Visible = true;
        labelSigaSaudeModuloAcessar_desc.Text = lista.ModuloAcessarSiga + " )";
        labelSigaSaudeOBS.Visible = true;
        labelSigaSaudeOBS_desc.Text = lista.ObsSiga + " )";
    }

    private void CarregaSEI(int id)
    {
        DadosSei lista = new DadosSei();
        lista = SolicitaAcessoDAO.GetDadosSEI(id);
        labelSeiSiglaUnidade_1.Visible = true;
        labelSeiSiglaUnidade_1_desc.Text = lista.siglasUnidades1 + " )";
        labelSeiSiglaUnidade_2.Visible = true;
        labelSeiSiglaUnidade_2_desc.Text = lista.siglasUnidades2 + " )";
        labelSeiSiglaUnidade_3.Visible = true;
        labelSeiSiglaUnidade_3_desc.Text = lista.siglasUnidades3 + " )";
        labelSeiSiglaUnidade_4.Visible = true;
        labelSeiSiglaUnidade_4_desc.Text = lista.siglasUnidades4 + " )";
    }

    private void CarregaOSmanutencao(int id)
    {
        DadosOsManutencao lista = new DadosOsManutencao();
        lista = SolicitaAcessoDAO.GetDadosOsManutencao(id);
        labelOsManutencaoNcentroCustoNovo.Visible = true;
        labelOsManutencaoNcentroCustoNovo_desc.Text = lista.N_centro_custos_novo + " )";
        labelOsManutencaoNcentroCustoAntigo.Visible = true;
        labelOsManutencaoNcentroCustoAntigo_desc.Text = lista.N_centro_custos_antigo + " )";
        labelOsManutencaoCPF.Visible = true;
        labelOsManutencaoCPF_desc.Text = lista.cpf_manutencao + " )";
    }

    private void CarregaGrafica(int id)
    {
        DadosGrafica lista = new DadosGrafica();
        lista = SolicitaAcessoDAO.GetDadosGrafica(id);
        labelgraficaSolicitado.Visible = true;
        labelGraficaSolicitada.Text = lista.setor_solicitado_Grafica;
        labelGraficaNcentroCusto.Visible = true;
        labelGraficaNcentroCusto_desc.Text = lista.N_centro_custo_grafica + " )";
        labelGraficaNcentroCusto_Antigo.Visible = true;
        labelGraficaNcentroCusto_Antigo_desc.Text = lista.N_centro_custo_grafica_antigo + " )";
        labelGraficaCPF.Visible = true;
        labelGraficaCPF_desc.Text = lista.cpf_grafica + " )";
    }

    private void CarregaSimproc(int id)
    {
        DadosSimproc lista = new DadosSimproc();
        lista = SolicitaAcessoDAO.GetDadosSimproc(id);
        labelSimprocCod_Uni.Visible = true;
        labelSimprocCod_Uni_Desc.Text = lista.CodigoUnidade_Simproc + " )";
        labelSimprocCpf.Visible = true;
        labelSimprocCpf_Desc.Text = lista.cpf_simproc + " )";
        labelSimprocRG.Visible = true;
        labelSimprocRG_Desc.Text = lista.rg_simproc + " )";
        labelSimprocDtAdmissao.Visible = true;
        labelSimprocDtAdmissao_Desc.Text = lista.dataAdmissao + " )";
    }

    private void CarregaRedeCorporativa(int id)
    {
        DadosRedeCoorporativa lista = new DadosRedeCoorporativa();
        lista = SolicitaAcessoDAO.GetDadosRedeCorporativaSolicitacao(id);
        LabelRedeTipoSolicitacao.Text = lista.redeCorporativa;
        if (lista.emailCorporativo == "True")
        {
            LabelRedeEmail.Visible = true;
        }
        if (lista.caixaDepartamental == "True")
        {
            LabelRedeCaixaDepartamental.Visible = true;
            LabelRedeCaixaDepartNovoOuExistente.Text = lista.redeCorperativaNovoDerp;
            LabelRedeCaixaDepartamental_Descricao.Text = lista.caixaDepartamental_Descricao + " )";

        }
        if (lista.pastaDeRede == "True")
        {
            LabelRedePastaDeRede.Visible = true;
            LabelRedePastaEspecificaNovaOuExistente.Text = lista.redeCorperativaNovoPasta;
            LabelRedePastaEspecifica.Text = lista.PastaEspecifica + " )";
        }
    }

    private void CarregaSGH(int id)
    {
        DadosSGH lista = new DadosSGH();
        lista = SolicitaAcessoDAO.GetDadosSGH(id);

        if (lista.Amb == "True")
        {
            labelAmb.Visible = true;
            labelAmb_descricao.Text = lista.Amb_Desc + " )";
        }
        if (lista.CenCir == "True")
        {
            labelCentroCir.Visible = true;
            labelCentroCir_descricao.Text = lista.CenCir_Desc + " )";
        }
        if (lista.Internacao == "True")
        {
            labelInternacao.Visible = true;
            labelInternacao_descricao.Text = lista.Internacao_Desc + " )";
        }
        if (lista.PS == "True")
        {
            labelProntoSocorro.Visible = true;
            labelProntoSocorro_descricao.Text = lista.PS_Desc + " )";
        }


    }

    private void CarregaDadosSGH_Comp(int id)
    {
        DadosCompSGH lista = new DadosCompSGH();
        lista = SolicitaAcessoDAO.GetDadosSGH_Comp(id);
        LabelDadosCompDtNasc.Visible = true;
        LabelDadosCompDtNasc_desc.Text = lista.dtNasci_dadosComp + " )";
        LabelDadosCompNomeDaMae.Visible = true;
        LabelDadosCompNomeDaMae_desc.Text = lista.nomeMae_dadosComp + " )";
        LabelDadosCompCRM.Visible = true;
        LabelDadosCompCRM_desc.Text = lista.crm_dadosComp + " )";
        LabelDadosCompRG.Visible = true;
        LabelDadosCompRG_desc.Text = lista.rg_dadosComp + " )";
        LabelDadosCompCPF.Visible = true;
        LabelDadosCompCPF_desc.Text = lista.cpf_dadosComp + " )";
    }
    protected void btnRedeCorporativa_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "RedeCorporativa", "C", 1);
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        string dtHr = DateTime.Now.ToString();
        SolicitaAcessoDAO.Atualiza_Extrato(idChamado, ">>>-Rede Corporativa Finalizado por: " + pegaNomeLoginUsuario.Text + " em: " + dtHr + " OBS: " + txtObsFinalizarRedeCorporativa.Text + " \n");
        txtObsFinalizarRedeCorporativa.Text = "";
        int TotalAbreChamado = SolicitaAcessoDAO.VerificaTotalAbrirChamado(idChamado);
        if (TotalAbreChamado == 0)
        {
            AbreChamadoSuporte(idChamado, txtNomeFuncionario.Text);
        }
        Response.Redirect("~/Suporte/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void bntSGH_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "SGH", "C", 1);
        if (LabelEmpresaExibe.Text != "HSPM")
        {
            SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "DadosSolicitadosSGH", "C", 0);
        }
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        string dtHr = DateTime.Now.ToString();
        SolicitaAcessoDAO.Atualiza_Extrato(idChamado, ">>>-SGH Finalizado por: " + pegaNomeLoginUsuario.Text + " em: " + dtHr + " OBS: " + txtObsFinalizarSGH.Text + " \n");
        txtObsFinalizarSGH.Text = "";
        int TotalAbreChamado = SolicitaAcessoDAO.VerificaTotalAbrirChamado(idChamado);
        if (TotalAbreChamado == 0)
        {
            AbreChamadoSuporte(idChamado, txtNomeFuncionario.Text);
        }
        Response.Redirect("~/Suporte/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void btnSimproc_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "Simproc", "C", 1);
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        string dtHr = DateTime.Now.ToString();
        SolicitaAcessoDAO.Atualiza_Extrato(idChamado, ">>>-Simproc Finalizado por: " + pegaNomeLoginUsuario.Text + " em: " + dtHr + " OBS: " + txtObsFinalizarSimproc.Text + " \n");
        txtObsFinalizarSimproc.Text = "";
        int TotalAbreChamado = SolicitaAcessoDAO.VerificaTotalAbrirChamado(idChamado);
        if (TotalAbreChamado == 0)
        {
            AbreChamadoSuporte(idChamado, txtNomeFuncionario.Text);
        }
        Response.Redirect("~/Suporte/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void btnGrafica_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "Grafica", "C", 1);
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        string dtHr = DateTime.Now.ToString();
        SolicitaAcessoDAO.Atualiza_Extrato(idChamado, ">>>-Grafica Finalizado por: " + pegaNomeLoginUsuario.Text + " em: " + dtHr + " OBS: " + txtObsFinalizarGrafica.Text + " \n");
        txtObsFinalizarGrafica.Text = "";
        int TotalAbreChamado = SolicitaAcessoDAO.VerificaTotalAbrirChamado(idChamado);
        if (TotalAbreChamado == 0)
        {
            AbreChamadoSuporte(idChamado, txtNomeFuncionario.Text);
        }
        Response.Redirect("~/Suporte/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void btnOSmanutencao_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "OS_manutencao", "C", 1);
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        string dtHr = DateTime.Now.ToString();
        SolicitaAcessoDAO.Atualiza_Extrato(idChamado, ">>>-Os Manutenção Finalizado por: " + pegaNomeLoginUsuario.Text + " em: " + dtHr + " OBS: " + txtObsFinalizarOSmanutencao.Text + " \n");
        txtObsFinalizarOSmanutencao.Text = "";
        int TotalAbreChamado = SolicitaAcessoDAO.VerificaTotalAbrirChamado(idChamado);
        if (TotalAbreChamado == 0)
        {
            AbreChamadoSuporte(idChamado, txtNomeFuncionario.Text);
        }
        Response.Redirect("~/Suporte/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void btnSei_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "Sei", "C", 1);
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        string dtHr = DateTime.Now.ToString();
        SolicitaAcessoDAO.Atualiza_Extrato(idChamado, ">>>-SEI Finalizado por: " + pegaNomeLoginUsuario.Text + " em: " + dtHr + " OBS: " + txtObsFinalizarSEI.Text + " \n");
        txtObsFinalizarSEI.Text = "";
        int TotalAbreChamado = SolicitaAcessoDAO.VerificaTotalAbrirChamado(idChamado);
        if (TotalAbreChamado == 0)
        {
            AbreChamadoSuporte(idChamado, txtNomeFuncionario.Text);
        }
        Response.Redirect("~/Suporte/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void btnSigaSaude_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "SigaSaude", "C", 1);
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        string dtHr = DateTime.Now.ToString();
        SolicitaAcessoDAO.Atualiza_Extrato(idChamado, ">>>-Siga Saúde Finalizado por: " + pegaNomeLoginUsuario.Text + " em: " + dtHr + " OBS: " + txtObsFinalizarSigaSaude.Text + " \n");
        txtObsFinalizarSigaSaude.Text = "";
        int TotalAbreChamado = SolicitaAcessoDAO.VerificaTotalAbrirChamado(idChamado);
        if (TotalAbreChamado == 0)
        {
            AbreChamadoSuporte(idChamado, txtNomeFuncionario.Text);
        }
        Response.Redirect("~/Suporte/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    //Abre chamado para o ssuporte

    private void AbreChamadoSuporte(int idChamado, string nomeF)
    {
        ListaGrid l = new ListaGrid();

        l.ocorrencia = " Comunicar acesso. Funcionário(a) " + nomeF + " (Solicitação nº:" + idChamado + ") ";
        l.nomeTecnico = pegaNomeLoginUsuario.Text;
        l.nomeContato = nomeF;
        l.ramal = txtRamal.Text;
        SolicitaAcessoDAO.GravaChamadoAutomaticamente(l);
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Suporte/SolicitacoesAbertas.aspx", false);
    }
}