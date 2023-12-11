using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using System.Configuration;

public partial class Cadastrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
            carregaGrid();

        }
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)//cadastrar ocorrencia
    {
        string Nometecnico = pegaNomeLoginUsuario.Text;
        if (txtOcorrencia.Text.Length <= 500 && txtSetor.Text.Length>=2)
        {

            DateTime dtatual = DateTime.Now;
            string dtCadastroChamado = dtatual.ToString().Substring(0,16);
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
            {
                try
                {
                    string strQuery = @"INSERT INTO [dbo].[aberturaChamado]
           ([cac]
           ,[nomeContato]
           ,[setor]
           ,[ramal]           
           ,[titulo]
           ,[ocorrencia]          
           ,[statusChamado]
           ,[dataHoraAbertura]
           ,[extratoDoChamado])
     VALUES
           (@cac,@nomeContato,@setor,@ramal,@titulo,@ocorrencia,@statusChamado,@dataHoraAbertura,@extratoDoChamado)";
                    SqlCommand commd = new SqlCommand(strQuery, com);
                    commd.Parameters.Add("@cac", SqlDbType.VarChar).Value = txtCac.Text;
                    commd.Parameters.Add("@nomeContato", SqlDbType.VarChar).Value = txtNomeContato.Text;
                    // commd.Parameters.Add("@setor", SqlDbType.VarChar).Value = txtSetor.Text;
                    commd.Parameters.Add("@setor", SqlDbType.VarChar).Value = txtSetor.Text;
                    commd.Parameters.Add("@ramal", SqlDbType.VarChar).Value = txtRamal.Text;
                    // commd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = txtTitulo.Text;
                    commd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = ddlTitulo.SelectedValue;
                    commd.Parameters.Add("@ocorrencia", SqlDbType.VarChar).Value = txtOcorrencia.Text;
                    commd.Parameters.Add("@statusChamado", SqlDbType.VarChar).Value = "0";
                    commd.Parameters.Add("@dataHoraAbertura", SqlDbType.DateTime).Value = dtatual;
                    commd.Parameters.Add("@extratoDoChamado", SqlDbType.VarChar).Value = "-> Criado por " + Nometecnico + " em: " + dtCadastroChamado + " Ocorrência: " + txtOcorrencia.Text + "\n";

                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();
                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                    throw;
                }

            }

            txtCac.Text = "HSPMCAC";
            txtNomeContato.Text = "";
            //txtSetor.Text = "";

            txtRamal.Text = "";
            //txtTitulo.Text = "";
            txtOcorrencia.Text = "";
            txtSetor.Text = "";

            carregaGrid();
            
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Limite 500 caracteres! ou Setor com no minimo 2 caracteres!');", true);

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
      ,[titulo],[dataHoraAbertura]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where statusChamado='0'order by id ASC";
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


    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)//Visualizar
    {
        int id = Convert.ToInt32(GridViewChamados.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        //atualizaStatus(id);
        Response.Redirect("~/VisualizarChamados.aspx?IdChamado=" + id);
    
    }

    [WebMethod]

    public static string[] getSetor(string prefixo)
    {
        List<string> clientes = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = "SELECT TOP 20 setor FROM[chamado_suporte].[dbo].[LocalSetor] where setor LIKE '%' + @Texto +'%' group by setor";
                cmd.Parameters.AddWithValue("@Texto", prefixo);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        clientes.Add(string.Format("{0}", sdr["setor"]));
                    }
                }
                conn.Close();
            }
        }
        return clientes.ToArray();
    }


}
