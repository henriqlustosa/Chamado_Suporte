using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SolicitacoesRemoverPermissao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            LabelExtratoChamado.Text = "";
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();         
            carregaGrid();
        }     
    }

    private void carregaGrid()
    {
        GridViewSolicitacoes.DataSource = SolicitaAcessoDAO.MostraSolicitacoesNaTelaStatusRemover();
        GridViewSolicitacoes.DataBind();
    }
       
    protected void grdSolicitacoesExibe_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(GridViewSolicitacoes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());        
       // Response.Redirect("~/Suporte/AtenderSolicitacao.aspx?IdChamado=" + id);

        if (e.CommandName == "atender")
        {         
            Response.Redirect("~/Suporte/RetirarPermissaoSolicitacao.aspx?IdChamado=" + id);
        }
        else if (e.CommandName == "visualizarSolicitacao")
        {
            Response.Redirect("~/Suporte/VisualizarSolicitacoes.aspx?idChamado=" + id);
        }
               
    }
}