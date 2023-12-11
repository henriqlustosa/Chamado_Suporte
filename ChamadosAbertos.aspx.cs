using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ChamadosAbertos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
        CarregaMeusChamadosEmEspera(pegaNomeLoginUsuario.Text);
        carregaGrid();

    }

    private void CarregaMeusChamadosEmEspera(string NomeDoTecnico)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT count(*)
  FROM [chamado_suporte].[dbo].[aberturaChamado] 
  where nomeTecnico='" + NomeDoTecnico + "' and (statusChamado!=0 and statusChamado!=2)";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    labelTotalChamadosEmAberto.Text = dr.GetInt32(0).ToString();
                }
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }

        }

    }

    private void carregaGrid()
    {
        var lista = new List<listaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[extratoDoChamado],[ip]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where statusChamado = 0 order by id ASC";
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
                    l.extratoChamado = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.IpDeQuemCadastrou = dr.IsDBNull(8) ? null : dr.GetString(8);
                    lista.Add(l);
                    LabelExtratoChamado.Text = l.extratoChamado;

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

    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int id = Convert.ToInt32(GridViewChamados.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        //bool atendido = verificaSeJaFoiAtendido(id);
        //if (atendido == false)
        //{
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Esse já foi atendido sua pagina será atualizada, atenda o Proximo chamado!');", true);

        //}
        //else
        //{
            atualizaStatus(id);
            Response.Redirect("~/emAtendimento.aspx?IdChamado=" + id);
        //}

        //carregaGrid();
    }

  //  private bool verificaSeJaFoiAtendido(int id)
  //  {
  //      bool valido;
  //      using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
  //      {

  //          string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
  //    ,[titulo],[dataHoraAbertura],[extratoDoChamado]
  //FROM [chamado_suporte].[dbo].[aberturaChamado] where id="+id+" and statusChamado = 0";
  //          com.Open();
  //          SqlCommand commd = new SqlCommand(strQuery, com);
  //          SqlDataReader dr = commd.ExecuteReader();
  //          valido = dr.Read();
  //          com.Close();
  //      }
  //      return valido;
  //  }

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
                commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = LabelExtratoChamado.Text += "-> Chamado atendido por: " + Nometecnico + " em: " + dtCadastroChamado + "\n";
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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MeusChamados.aspx");
    }
}
