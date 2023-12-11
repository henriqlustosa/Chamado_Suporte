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
        pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
        carregaGrid();
    }

    private void carregaGrid()
    {
        var lista = new List<listaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[nomeTecnico],[statusChamado],[extratoDoChamado]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where (statusChamado != 0 and statusChamado != 2) order by nomeTecnico ASC";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    listaGrid l = new listaGrid();
                    l.id = dr.GetInt32(0);
                    l.cac = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.nomeContato = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.setor = dr.IsDBNull(3) ? null : dr.GetString(3);
                    l.ramal = dr.IsDBNull(4) ? null : dr.GetString(4);
                    l.titulo = dr.IsDBNull(5) ? null : dr.GetString(5);
                    // l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                    DateTime dtHora = dr.GetDateTime(6);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0,16);
                    l.solucao = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.nomeTecnico = dr.IsDBNull(8) ? null : dr.GetString(8);
                    int nStatus = dr.GetInt32(9);

                    if (nStatus==5)
                    {
                        l.statusDochamado = "No Local";
                    }
                    else if (nStatus == 6)
                    {
                        l.statusDochamado = "Chamado DELL";
                    }
                    else if (nStatus == 7)
                    {
                        l.statusDochamado = "Chamado IMPR";
                    }
                    else
                    {
                        l.statusDochamado = "Outros";

                    }
                    l.extratoChamado = dr.IsDBNull(10) ? null : dr.GetString(10);
                    LabelExtratoChamado.Text = l.extratoChamado;

                    lista.Add(l);
                }
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            GridViewChamados.DataSource = lista;
            GridViewChamados.DataBind();

        }
    }

    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)//EXCLUIR CHAMADO
    {

        int id = Convert.ToInt32(GridViewChamados.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
       

        if (e.CommandName=="atender")
        {
            atualizaStatus(id);
            Response.Redirect("~/emAtendimento.aspx?IdChamado=" + id);
        }
        else
        {
            Response.Redirect("~/VisualizarChamados.aspx?idChamado=" + id);
        }

        //carregaGrid();
    }

    private void atualizaStatus(int id)
    {
        try
        {
            string Nometecnico = pegaNomeLoginUsuario.Text;
            DateTime dtatual = DateTime.Now;
            string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

            {
                string strQuery = @"UPDATE [dbo].[aberturaChamado]
   SET 
[statusChamado]=@statusChamado,
[extratoDoChamado]=@extratoDoChamado,
[nomeTecnico]=@nomeTecnico

    where   id=" + id + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                //commd.Parameters.Add("@sulucao", SqlDbType.NVarChar).Value = (object)txtSolucao.Text ?? DBNull.Value; //Caso a variavel seja nula   
                //commd.Parameters.Add("@dthrSolucao", SqlDbType.DateTime).Value = dataAtual;
                commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = 1;
                commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = LabelExtratoChamado.Text += "-> Chamado atendido/puxado por: " + Nometecnico + " em: " + dtCadastroChamado + "\n";
                commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = Nometecnico;

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();

            }

        }
        catch (Exception ex)
        {
            string erro = ex.Message;

        }
    }
}
