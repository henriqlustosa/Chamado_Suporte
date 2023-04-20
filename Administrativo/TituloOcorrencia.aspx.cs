using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrativo_Setores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            IniciarGridTituloOcorrencia();
        }
    }
       

    private static bool verificaTituloOcorrencia(string nomeTituloOcorrencia)
    {
        {
            bool valido;
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
            {
                string strquerySelect;
                strquerySelect = @"SELECT NomeTipoChamado FROM [chamado_suporte].[dbo].[TipoChamado]" +
                 " where NomeTipoChamado='" + nomeTituloOcorrencia + "'";
                SqlCommand commd = new SqlCommand(strquerySelect, com);
                com.Open();
                SqlDataReader dr = commd.ExecuteReader();

                //int rhInternacao = Convert.ToInt32(internacao.cd_prontuario);

                valido = dr.Read();
                com.Close();
            }
            return valido;
        }
    }

    private void IniciarGridTituloOcorrencia()
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);

                strQuery = @"SELECT * FROM [chamado_suporte].[dbo].[TipoChamado] order by NomeTipoChamado";
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("ID do Título", System.Type.GetType("System.String"));
                dt.Columns.Add("Nome da ocorrência", System.Type.GetType("System.String"));

                while (dr.Read())
                {
                    string ID = dr.GetInt32(0).ToString();
                    string nomeSetor = dr.GetString(1);
                    dt.Rows.Add(new String[] { ID, nomeSetor });
                }
                com.Close();
                GridViewTituloOcorrencia.DataSource = dt;
                GridViewTituloOcorrencia.DataBind();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }

        }
    }

    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(txtID.Text);
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @" DELETE FROM [chamado_suporte].[dbo].[TipoChamado]  where id=" + id +" ";
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
                IniciarGridTituloOcorrencia();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                IniciarGridTituloOcorrencia();
            }
        }
    }

    protected void CadastrarItuloOcorrencia_Click(object sender, EventArgs e)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {

            if (verificaTituloOcorrencia(txtAddTituloOcorrencia.Text) == false)
            {
                try
                {
                    string strQuery = "";
                    string nomeTituloocorrencia = txtAddTituloOcorrencia.Text;
                    SqlCommand commd = new SqlCommand(strQuery, com);
                    strQuery = @"INSERT INTO [dbo].[TipoChamado] ([NomeTipoChamado])"
                        + " VALUES (@NomeTipoChamado)";

                    commd.Parameters.Add("@NomeTipoChamado", SqlDbType.VarChar).Value = nomeTituloocorrencia;                    
                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Titulo da ocorrência Gravado com suecesso!');", true);
                }


                catch (Exception ex)
                {

                    string erro = ex.Message;

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Já existe um Titulo da ocorrência com esse nome!');", true);

            }




        }
        txtAddTituloOcorrencia.Text = "";
        IniciarGridTituloOcorrencia();
    }
}