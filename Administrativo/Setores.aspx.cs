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
            IniciarGridSetores();
        }
    }

    protected void CadastrarSetor_Click(object sender, EventArgs e)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {

            if (verificaSetor(txtAddSetor.Text) == false)
            {
                try
                {
                    string strQuery = "";
                    string nomeSetor = txtAddSetor.Text.TrimStart();
                    SqlCommand commd = new SqlCommand(strQuery, com);
                    strQuery = @"INSERT INTO [dbo].[LocalSetor] ([setor],[ativo])"
                        + " VALUES (@setor,@ativo)";

                    commd.Parameters.Add("@setor", SqlDbType.VarChar).Value = nomeSetor;
                    commd.Parameters.Add("@ativo", SqlDbType.Int).Value = 0;
                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Setor Gravado com suecesso!');", true);
                }


                catch (Exception ex)
                {

                    string erro = ex.Message;

                }
            } 
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Já existe um setor com esse nome!');", true);

            }




        }
        txtAddSetor.Text = "";
        IniciarGridSetores();
    }

    private static bool verificaSetor(string nomesetor)
    {
        {
            bool valido;
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
            {
                string strquerySelect;
                strquerySelect = @"SELECT [setor] FROM [chamado_suporte].[dbo].[LocalSetor]" +
                 " where setor='" + nomesetor + "'";
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

    private void IniciarGridSetores()
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);

                strQuery = @"SELECT * FROM [chamado_suporte].[dbo].[LocalSetor] order by setor";
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("ID do setor", System.Type.GetType("System.String"));
                dt.Columns.Add("Nome do setor", System.Type.GetType("System.String"));

                while (dr.Read())
                {
                    string ID = dr.GetInt32(0).ToString();
                    string nomeSetor = dr.GetString(1);
                    dt.Rows.Add(new String[] { ID, nomeSetor });
                }
                com.Close();
                GridViewSetores.DataSource = dt;
                GridViewSetores.DataBind();
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
                strQuery = @" DELETE FROM [chamado_suporte].[dbo].[LocalSetor]  where id=" + id +" ";
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
                IniciarGridSetores();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                IniciarGridSetores();
            }
        }
    }
}