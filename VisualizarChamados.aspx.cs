using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VisualizarChamados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string id1 = Request.QueryString["IdChamado"];
             Global.localOrigem = Request.UrlReferrer.AbsolutePath;
            int id = Convert.ToInt32(id1);
            carregarAtendimento(id);
        }
    }
    public static class Global
    {
        public static string localOrigem;
    }
    
    private void carregarAtendimento(int id)
        {
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
            {
                try
                {
                    string strQuery = @"SELECT [id],[cac],[nomeContato],[setor],[ramal]
      ,[titulo],[ocorrencia],[dataHoraAbertura],[solucao],[extratoDoChamado],[numeroSerieOuTag]
  FROM [chamado_suporte].[dbo].[aberturaChamado] where id = " + id + "";
                    com.Open();
                    SqlCommand commd = new SqlCommand(strQuery, com);
                    SqlDataReader dr = commd.ExecuteReader();
                    while (dr.Read())
                    {

                        LabelID.Text = Convert.ToString(dr.GetInt32(0));
                        txtCac.Text = dr.IsDBNull(1) ? null : dr.GetString(1);
                        txtNomeContato.Text = dr.IsDBNull(2) ? null : dr.GetString(2);
                        txtSetor.Text = dr.IsDBNull(3) ? null : dr.GetString(3);
                        txtRamal.Text = dr.IsDBNull(4) ? null : dr.GetString(4);
                        txtTitulo.Text = dr.IsDBNull(5) ? null : dr.GetString(5);
                        txtOcorrencia.Text = dr.IsDBNull(6) ? null : dr.GetString(6);
                        // l.ocorrencia = dr.IsDBNull(6) ? null : dr.GetString(6);
                        DateTime dtHora = dr.GetDateTime(7);
                        string dtSub = Convert.ToString(dtHora);
                        txtHoraDtChamado.Text = dtSub.Substring(0, 16);
                        txtSolucao.Text = dr.IsDBNull(8) ? null : dr.GetString(8);
                        txtExtratoChamado.Text = dr.IsDBNull(9) ? null : dr.GetString(9);
                        LabelTagNserie.Text= dr.IsDBNull(10) ? null : dr.GetString(10);
                    if (LabelTagNserie.Text.Length >4)
                    {
                        string lbTag = "Numero da TAG ou Nº de Serie é: " + LabelTagNserie.Text;
                        LabelTagNserie.Text = lbTag;

                    }

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

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        
        string url;
        url = ""+ Global.localOrigem + "";
        Response.Redirect(url);
    }

}

    
