using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChamadosEmEspera : System.Web.UI.Page
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

        GridViewChamados.DataSource = ChamadosDAO.MostraChamadosEmEsperaGeral();
        GridViewChamados.DataBind();
        //  LabelExtratoChamado.Text = l.extratoChamado;

    }

    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)//EXCLUIR CHAMADO
    {

        int id = Convert.ToInt32(GridViewChamados.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());


        if (e.CommandName == "atender")
        {
            atualizaStatus(id);
            Response.Redirect("~/Suporte/emAtendimento.aspx?IdChamado=" + id);
        }
        else
        {
            Response.Redirect("~/Suporte/VisualizarChamados.aspx?idChamado=" + id);
        }

        //carregaGrid();
    }

    private void atualizaStatus(int id)
    {
        string Nometecnico = pegaNomeLoginUsuario.Text;
        ListaGrid L = new ListaGrid();
        L.id = id;
        L.statusDochamado = Convert.ToString(1);
        L.nomeTecnico = Nometecnico;
        L.ChamadoAtendidoPuxadoReaberto = "Atendido/puxado por:";
        ChamadosDAO.AtualizaStatusChamado(L);

    }
}
