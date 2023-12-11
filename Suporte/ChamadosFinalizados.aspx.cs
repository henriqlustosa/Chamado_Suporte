using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChamadosFinalizados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!this.IsPostBack)
        //{
        LabelExtratoChamado.Text = "";
        txtPesquisaSetor.Enabled = false;
        txtPesquisaTitulo.Enabled = false;
        txtCac.Enabled = false;
        txtOcorrencia.Enabled = false;
        txtSolucao.Enabled = false;
        txtNomeContato.Enabled = false;
        pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
        // carregaGrid();
        if (rbSetor.Checked == true)
        {
            txtPesquisaSetor.Enabled = true;
            txtCac.Text = "";
            txtSolucao.Text = "";
            txtOcorrencia.Text = "";
            txtPesquisaTitulo.Text = "";
            txtNomeContato.Text = "";
        }
        else if (rbTitulo.Checked == true)
        {
            txtPesquisaTitulo.Enabled = true;
            txtPesquisaSetor.Text = "";
            txtSolucao.Text = "";
            txtOcorrencia.Text = "";
            txtNomeContato.Text = "";
        }
        else if (rbCac.Checked == true)
        {
            txtCac.Enabled = true;
            txtPesquisaSetor.Text = "";
            txtSolucao.Text = "";
            txtOcorrencia.Text = "";
            txtPesquisaTitulo.Text = "";
            txtNomeContato.Text = "";
        }
        else if (rbSolucao.Checked == true)
        {
            txtSolucao.Enabled = true;
            txtCac.Text = "";
            txtPesquisaSetor.Text = "";
            txtOcorrencia.Text = "";
            txtPesquisaTitulo.Text = "";
            txtNomeContato.Text = "";
        }
        else if (rbOcorrencia.Checked == true)
        {
            txtOcorrencia.Enabled = true;
            txtSolucao.Text = "";
            txtCac.Text = "";
            txtPesquisaSetor.Text = "";
            txtPesquisaTitulo.Text = "";
            txtNomeContato.Text = "";
        }
        else if (rbNomeContato.Checked == true)
        {
            txtNomeContato.Enabled = true;
            txtSolucao.Text = "";
            txtCac.Text = "";
            txtPesquisaSetor.Text = "";
            txtPesquisaTitulo.Text = "";
            txtOcorrencia.Text = "";
        }

        else
        {
            txtCac.Text = "";
            txtSolucao.Text = "";
            txtPesquisaSetor.Text = "";
            txtOcorrencia.Text = "";
            txtPesquisaTitulo.Text = "";
            txtNomeContato.Text = "";
        }
        //}
        if (!this.IsPostBack)
        {
            string dt = DateTime.Now.ToShortDateString();
            txtdtIni.Text = dt;
            txtdtFim.Text = dt;
        }
    }



    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)
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
        try
        {
            string Nometecnico = pegaNomeLoginUsuario.Text;
            DateTime dtatual = DateTime.Now;
            string dtCadastroChamado = dtatual.ToString().Substring(0, 16);

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

    protected void BtnPesquisaFinalizados_Click(object sender, EventArgs e)
    {


        //private void carregaGrid()
        //{
        var lista = new List<ListaGrid>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {            
            string DataInicial = "";
            string DataFinal = "";
            if (txtdtIni.Text.Length<10 || txtdtFim.Text.Length < 10)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Data No formato ERRADO Fotmato correto dd/mm/aaaa - Lembrando que o campo data só serve para pesquisar os chamados em Geral, as opções  CAC - SETOR - TITULO - OCORRÊNCIA e SOLUÇÂO não usam a data como paramentro sendo assim deixe a data como está.');", true);

            }
            else
            {
                string[] dt1 = new string[3];
                dt1[0] = txtdtIni.Text.Substring(6, 4);
                dt1[1] = txtdtIni.Text.Substring(0, 2);
                dt1[2] = txtdtIni.Text.Substring(3, 2);
                DataInicial = dt1[0] + '-' + dt1[1] + '-' + dt1[2] + " 00:00:00";
                string[] dt2 = new string[3];
                dt2[0] = txtdtFim.Text.Substring(6, 4);
                dt2[1] = txtdtFim.Text.Substring(0, 2);
                dt2[2] = txtdtFim.Text.Substring(3, 2);
                DataFinal = dt2[0] + '-' + dt2[1] + '-' + dt2[2] + " 23:59:59";
            }
          
            try
            {
                string strQuery = "";
                if (rbTodos.Checked == true)
                {
                    strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[ocorrencia],[nomeTecnico]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where (dataHoraSolucao BETWEEN '" + DataInicial + "' and  '" + DataFinal + "') and statusChamado = 2 order by id ASC";

                }
                else if (rbCac.Checked == true)
                {
                    strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[ocorrencia],[nomeTecnico]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where cac='" + txtCac.Text + "' and statusChamado = 2 order by id ASC";

                }
                else if (rbSetor.Checked == true)
                {
                    strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[ocorrencia],[nomeTecnico]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where setor='" + txtPesquisaSetor.Text + "' and statusChamado = 2 order by id ASC";

                }
                else if (rbTitulo.Checked == true)
                {
                    strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[ocorrencia],[nomeTecnico]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where titulo='" + txtPesquisaTitulo.Text + "' and statusChamado = 2 order by id ASC";

                }
                else if (rbOcorrencia.Checked == true)
                {
                    strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[ocorrencia],[nomeTecnico]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where ocorrencia like'%" + txtOcorrencia.Text + "%' and statusChamado = 2 order by id ASC";

                }
                else if (rbSolucao.Checked == true)
                {
                    strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[ocorrencia],[nomeTecnico]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where solucao like'%" + txtSolucao.Text + "%' and statusChamado = 2 order by id ASC";

                }
                else if (rbNomeContato.Checked == true)
                {
                    strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[dataHoraAbertura],[solucao],[ocorrencia],[nomeTecnico]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where nomeContato like'%" + txtNomeContato.Text + "%' and statusChamado = 2 order by id ASC";

                }

                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    ListaGrid l = new ListaGrid();
                    l.id = dr.GetInt32(0);
                    l.cac = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.nomeContato = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.setor = dr.IsDBNull(3) ? null : dr.GetString(3);
                    l.ramal = dr.IsDBNull(4) ? null : dr.GetString(4);
                    l.titulo = dr.IsDBNull(5) ? null : dr.GetString(5);
                    l.ocorrencia = dr.IsDBNull(8) ? null : dr.GetString(8);
                    DateTime dtHora = dr.GetDateTime(6);
                    l.dt_hora = Convert.ToString(dtHora).Substring(0, 16);
                    l.solucao = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.nomeTecnico= dr.IsDBNull(9) ? null : dr.GetString(9);

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
        //}
    }

    //autoComplete
    [WebMethod]
    public static string[] getSetor(string prefixo)
    {
        List<string> clientes = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = "SELECT TOP 20 setor FROM[chamado_suporte].[dbo].[aberturaChamado] where setor LIKE '%' + @Texto +'%' group by setor";
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
    
    [WebMethod]
    public static string[] getTitulo(string prefixo)
    {
        List<string> clientes = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = "SELECT TOP 20 titulo FROM[chamado_suporte].[dbo].[aberturaChamado] where titulo LIKE '%' + @Texto +'%' group by titulo";
                cmd.Parameters.AddWithValue("@Texto", prefixo);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        clientes.Add(string.Format("{0}", sdr["titulo"]));
                    }
                }
                conn.Close();
            }
        }
        return clientes.ToArray();
    }
    
    [WebMethod]
    public static string[] getCac(string prefixo)
    {
        List<string> clientes = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = "SELECT TOP 10 cac FROM[chamado_suporte].[dbo].[aberturaChamado] where cac LIKE '%' + @Texto +'%' group by cac";
                cmd.Parameters.AddWithValue("@Texto", prefixo);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        clientes.Add(string.Format("{0}", sdr["cac"]));
                    }
                }
                conn.Close();
            }
        }
        return clientes.ToArray();
    }
    
    [WebMethod]
    public static string[] getOcorrencia(string prefixo)
    {
        List<string> clientes = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = "SELECT TOP 20 ocorrencia FROM[chamado_suporte].[dbo].[aberturaChamado] where ocorrencia LIKE '%' + @Texto +'%' group by ocorrencia";
                cmd.Parameters.AddWithValue("@Texto", prefixo);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        clientes.Add(string.Format("{0}", sdr["ocorrencia"]));
                    }
                }
                conn.Close();
            }
        }
        return clientes.ToArray();
    }

    [WebMethod]
    public static string[] getSolucaoExtrato(string prefixo)
    {
        List<string> clientes = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = "SELECT TOP 20 solucao FROM[chamado_suporte].[dbo].[aberturaChamado] where solucao LIKE '%' + @Texto +'%' group by solucao";
                cmd.Parameters.AddWithValue("@Texto", prefixo);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        clientes.Add(string.Format("{0}", sdr["solucao"]));
                    }
                }
                conn.Close();
            }
        }
        return clientes.ToArray();
    }

    [WebMethod]
    public static string[] getNomeContato(string prefixo)
    {
        List<string> clientes = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = "SELECT TOP 20 nomeContato FROM[chamado_suporte].[dbo].[aberturaChamado] where nomeContato LIKE '%' + @Texto +'%' group by nomeContato";
                cmd.Parameters.AddWithValue("@Texto", prefixo);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        clientes.Add(string.Format("{0}", sdr["nomeContato"]));
                    }
                }
                conn.Close();
            }
        }
        return clientes.ToArray();
    }

}
