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
      ,[titulo],[dataHoraAbertura],[solucao]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where nomeTecnico = '"+pegaNomeLoginUsuario.Text+"' order by id DESC";
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

                    lista.Add(l);
                    // LabelExtratoChamado.Text = l.extratoChamado;
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


        if (e.CommandName == "Reabrir")
        {
            atualizaStatus(id);
            Response.Redirect("~/emAtendimento.aspx?IdChamado=" + id);
        }
        else
        {
            Response.Redirect("~/VisualizarChamados.aspx?IdChamado=" + id);
        }
        //carregaGrid();
    }

    private void atualizaStatus(int id)
    {
        try
        {
            string Nometecnico = pegaNomeLoginUsuario.Text;
            DateTime dtatual = DateTime.Now;
            string dtCadastroChamado = dtatual.ToString().Substring(0,16);

            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

            {
                string strQuery1 = @"SELECT [extratoDoChamado] 
  FROM [chamado_suporte].[dbo].[aberturaChamado] where id= " + id + "";
                com.Open();
                SqlCommand commd1 = new SqlCommand(strQuery1, com);
                SqlDataReader dr1 = commd1.ExecuteReader();
                while (dr1.Read())
                {
                    LabelExtratoChamado.Text = dr1.GetString(0);

                }
                com.Close();

                string strQuery = @"UPDATE [dbo].[aberturaChamado]
   SET 
[statusChamado]=@statusChamado,
[extratoDoChamado]=@extratoDoChamado
    where   id=" + id + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                //commd.Parameters.Add("@sulucao", SqlDbType.NVarChar).Value = (object)txtSolucao.Text ?? DBNull.Value; //Caso a variavel seja nula   
                //commd.Parameters.Add("@dthrSolucao", SqlDbType.DateTime).Value = dataAtual;
                commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = 1;
                commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = LabelExtratoChamado.Text += "-> Chamado Reaberto por: " + Nometecnico + " em: " + dtCadastroChamado + "\n";


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

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
}
