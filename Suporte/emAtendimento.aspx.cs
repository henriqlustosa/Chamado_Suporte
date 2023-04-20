using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class emAtendimento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            LimpaCampos();
            string id1 = Request.QueryString["IdChamado"];
            int id = Convert.ToInt32(id1);
            carregarAtendimento(id);
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
        }

    }

    private void LimpaCampos()
    {
        LabelID.Text = "";
        txtOcorrencia.Text = "";
        txtExtratoChamado.Text = "";
        txtSolucao.Text = "";
    }

    private void carregarAtendimento(int id)
    {
        var l = ChamadosDAO.CarregaChamadoParaSerAtendido(id);
        LabelID.Text = Convert.ToString(l.id);
        txtCac.Text = l.cac;
        txtNomeContato.Text = l.nomeContato;
        txtSetor.Text = l.setor;
        txtRamal.Text = l.ramal;
        txtTitulo.Text = l.titulo;
        txtOcorrencia.Text = l.ocorrencia;
        txtHoraDtChamado.Text = l.HoraDtChamado;
        txtExtratoChamado.Text = l.extratoChamado;
        txtTagNserie.Text = l.tagNserie;
        ddlTituloAlterar.SelectedValue = l.titulo;
        string statusExterno = l.statusDochamado;
        if (statusExterno == "6")
        {
            RbtDell.Checked = true;
        }
        if (statusExterno == "7")
        {
            RbtImpressora.Checked = true;
        }
        if (statusExterno == "5")
        {
            RbtAtendimentoLocal.Checked = true;
        }
    }

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {

        string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();
        int idChamado = Convert.ToInt32(LabelID.Text);

        ListaGrid L = new ListaGrid();
        L.id = idChamado;
        L.cac = txtCac.Text;
        L.solucao = txtSolucao.Text;
        L.nomeTecnico = Nometecnico;
        //L.extratoChamado = txtExtratoChamado.Text;
        L.SolucaoPFuncionarioVer = ddlTipoSolucao.SelectedValue;
        L.tituloAlterar = ddlTituloAlterar.SelectedValue;
        ChamadosDAO.FinalizarChamados(L);

        string url;
        url = "~/Suporte/ChamadosAbertos.aspx";
        Response.Redirect(url, false);
    }

    protected void btnEmEspera_Click(object sender, EventArgs e)
    {

        string statusChamado = "10";
        if (RbtAtendimentoLocal.Checked == true)
        {
            statusChamado = "5";
            txtTagNserie.Text = "";
            ChamarUPdate(statusChamado);
        }
        else if (RbtDell.Checked == true)
        {
            statusChamado = "6";
            if (txtTagNserie.Text == null || txtTagNserie.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Informe o Numero da TAG!');", true);
            }
            else
            {
                ChamarUPdate(statusChamado);
            }
        }
        else if (RbtImpressora.Checked == true)
        {
            statusChamado = "7";
            if (txtTagNserie.Text == null || txtTagNserie.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Informe o Numero de Serie!');", true);
            }
            else
            {
                ChamarUPdate(statusChamado);
            }
        }
        else if (RbtNoturno.Checked == true)
        {
            statusChamado = "11";
            ChamarUPdate(statusChamado);
        }
        else if (RbtDiurno.Checked == true)
        {
            statusChamado = "12";
            ChamarUPdate(statusChamado);
        }

    }

    private void ChamarUPdate(string statusChamado)
    {

        //  string nomeLoginCadastrou = pegaNomeLoginUsuario.Text.ToUpper();
        string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();

        ListaGrid L = new ListaGrid();
        L.id = Convert.ToInt32(LabelID.Text);
        L.cac = txtCac.Text;
        L.statusDochamado = statusChamado;
        L.solucao = txtSolucao.Text;
        L.nomeTecnico = Nometecnico;
        // L.extratoChamado = txtExtratoChamado.Text;
        L.tagNserie = txtTagNserie.Text;

        ChamadosDAO.ChamarUpdateEmAtendimentoChamado(L);

        string url;
        url = "~/Suporte/ChamadosAbertos.aspx";
        Response.Redirect(url, false);
    }

    protected void btnEncaminhar_Click(object sender, EventArgs e)
    {
        if (DdlEncaminharParaTecnico.SelectedValue == "admin")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Não pode encaminhar chamado para o admin! Escolha algum tecnico!');", true);
        }
        else
        {
            string nomeDoTecnicoQueRecebeChamado = DdlEncaminharParaTecnico.SelectedValue;
            int idChamado = Convert.ToInt32(LabelID.Text);
            string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();

            ListaGrid L = new ListaGrid();
            L.id = idChamado;
            L.cac = txtCac.Text;
            L.solucao = txtSolucao.Text;
            L.nomeTecnico = Nometecnico;
            L.nomeTecnicoRecebeChamado = nomeDoTecnicoQueRecebeChamado;
            // L.extratoChamado = txtExtratoChamado.Text;
            ChamadosDAO.EncaminharChamadoTelaAtendimento(L);

            string url;
            url = "~/Suporte/ChamadosAbertos.aspx";
            Response.Redirect(url, false);
        }

    }

    //protected void btnReclassificar_Click(object sender, EventArgs e)
    //{

    //}

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();
        int idChamado = Convert.ToInt32(LabelID.Text);

        ListaGrid L = new ListaGrid();
        L.id = idChamado;
        L.cac = txtCac.Text;
        L.nomeTecnico = Nometecnico;
        L.solucao = txtSolucao.Text;
        //  L.extratoChamado = txtExtratoChamado.Text;
        L.tituloAlterar = ddlTitulo.SelectedValue;
        ChamadosDAO.AtualizarTituloDoChamado(L);

        string url;
        url = "~/Suporte/ChamadosAbertos.aspx";
        Response.Redirect(url, false);
    }
}
