using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MeusFinalizados : System.Web.UI.Page
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
        GridViewChamados.DataSource = ChamadosDAO.MostraChamadosFinalizadosDoTecnicoLogado(pegaNomeLoginUsuario.Text);
        GridViewChamados.DataBind();
    }

    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)//EXCLUIR CHAMADO
    {

        int id = Convert.ToInt32(GridViewChamados.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());


        if (e.CommandName == "Reabrir")
        {
            atualizaStatus(id);
            Response.Redirect("~/Suporte/emAtendimento.aspx?IdChamado=" + id);
        }
        else
        {
            Response.Redirect("~/Suporte/VisualizarChamados.aspx?IdChamado=" + id);
        }
        //carregaGrid();
    }

    private void atualizaStatus(int id)
    {

        ListaGrid L = new ListaGrid();
        L.id = id;
        L.nomeTecnico = pegaNomeLoginUsuario.Text;
        L.statusDochamado = "1";
        L.ChamadoAtendidoPuxadoReaberto = "Reaberto por: ";
        ChamadosDAO.AtualizaStatusChamado(L);

    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
}
