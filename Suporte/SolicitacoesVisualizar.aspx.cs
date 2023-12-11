using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Suporte_SolicitacoesVisualizar : System.Web.UI.Page
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
        //DadosSolicitacoesSetores D = new DadosSolicitacoesSetores();
        var lista = new List<DadosSolicitacoesSetores>();
        lista = SolicitaAcessoDAO.MostraSolicitacoesVisualizar();
       
        GridViewMinhasSolicitacoes.DataSource = lista;
        GridViewMinhasSolicitacoes.DataBind();
    }



    protected void grdSolicitacoesExibe_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(GridViewMinhasSolicitacoes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        Response.Redirect("~/Suporte/VisualizarSolicitacoes.aspx?IdChamado=" + id);
    }
}
