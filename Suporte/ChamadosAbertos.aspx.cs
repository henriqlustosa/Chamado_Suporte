using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class ChamadosAbertos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            LabelExtratoChamado.Text = "";
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
            CarregaMeusChamadosEmEspera(pegaNomeLoginUsuario.Text);
            CarregaTotalSolicitacoes();
            CarregaTotalSolicitacoesRetirarPermissao();
            carregaGrid();
        }
    }

    private void CarregaTotalSolicitacoesRetirarPermissao()
    {
        labelTotalDeSolicitacoesRemover.Text = SolicitaAcessoDAO.CarregaQtoDeSolicitacoesRemoverPermissao();

    }

    private void CarregaTotalSolicitacoes()
    {
        labelTotalDeSolicitacoesEmAberto.Text = SolicitaAcessoDAO.CarregaQtoDeSolicitacoesEmAberto();

    }

    private void CarregaMeusChamadosEmEspera(string NomeDoTecnico)
    {
        labelTotalChamadosEmAberto.Text = ChamadosDAO.CarregaQtoChamadosEuTenho(NomeDoTecnico);
    }

    private void carregaGrid()
    {
        GridViewChamados.DataSource = ChamadosDAO.MostraChamadosNaTelaStatus0();
        GridViewChamados.DataBind();
    }

    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int id = Convert.ToInt32(GridViewChamados.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());       
        atualizaStatus(id);
        Response.Redirect("~/Suporte/emAtendimento.aspx?IdChamado=" + id);
       
    }

    private void atualizaStatus(int id)
    {
      
        try
        {
            string Nometecnico = pegaNomeLoginUsuario.Text;
            ListaGrid L = new ListaGrid();
            L.id = id;
            L.statusDochamado =Convert.ToString(1);
            L.nomeTecnico = Nometecnico;
            L.ChamadoAtendidoPuxadoReaberto = "Atendido Por:";
            ChamadosDAO.AtualizaStatusChamado(L);
        }
        catch (Exception ex)
        {
            string erro = ex.Message;

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Suporte/MeusChamados.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Suporte/SolicitacoesAbertas.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Suporte/SolicitacoesRemoverPermissao.aspx");
    }


}
