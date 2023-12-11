using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class emAtendimento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string id1 = Request.QueryString["IdChamado"];
            int id = Convert.ToInt32(id1);
            carregarAtendimento(id);
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
        }
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
                    // txtSolucao.Text = dr.IsDBNull(8) ? null : dr.GetString(8);
                    txtExtratoChamado.Text = dr.IsDBNull(9) ? null : dr.GetString(9);
                    txtTagNserie.Text = dr.IsDBNull(10) ? null : dr.GetString(10);
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

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {

        string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();
        DateTime dtatual = DateTime.Now;
        string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
        int idChamado = Convert.ToInt32(LabelID.Text);

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

        {
            string strQuery = @"UPDATE [dbo].[aberturaChamado]
   SET [solucao]=@sulucao,
       [dataHoraSolucao]=@dthrSolucao,
[statusChamado]=@statusChamado,
[nomeTecnico]=@nomeTecnico,
[extratoDoChamado]=@extratoDoChamado,
[solucaoPfuncionarioVer]=@solucaoPfuncionarioVer
    where   id=" + idChamado + "";

            SqlCommand commd = new SqlCommand(strQuery, com);
            commd.Parameters.Add("@sulucao", SqlDbType.NVarChar).Value = (object)txtSolucao.Text ?? DBNull.Value; //Caso a variavel seja nula   
            commd.Parameters.Add("@dthrSolucao", SqlDbType.DateTime).Value = dtatual;
            commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = 2;
            commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = (object)Nometecnico ?? DBNull.Value; //Caso a variavel seja nula   
            commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = txtExtratoChamado.Text += "-> Chamado finalizado por: " + Nometecnico + " em: " + dtCadastroChamado + " Solução: " + txtSolucao.Text + "\n";
            commd.Parameters.Add("@solucaoPfuncionarioVer", SqlDbType.NVarChar).Value = (object)ddlTipoSolucao.SelectedValue ?? DBNull.Value; //Caso a variavel seja nula   

            commd.CommandText = strQuery;
            com.Open();
            commd.ExecuteNonQuery();
            com.Close();           


            string url;
            url = "~/ChamadosAbertos.aspx";
            Response.Redirect(url);

        }


    }
      
    protected void btnEmEspera_Click(object sender, EventArgs e)
    {

        string statusChamado = "10";
        if (RbtAtendimentoLocal.Checked == true)
        {
            statusChamado = "5";
            txtTagNserie.Text = "";
            ChamarUPdate(statusChamado);
        }
        else if (RbtDell.Checked == true)
        {
            statusChamado = "6";
            if (txtTagNserie.Text == null || txtTagNserie.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Informe o Numero da TAG!');", true);
            }
            else
            {
                ChamarUPdate(statusChamado);
            }
        }
        else if (RbtImpressora.Checked == true)
        {
            statusChamado = "7";
            if (txtTagNserie.Text == null || txtTagNserie.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Informe o Numero de Serie!');", true);

            }
            else
            {
                ChamarUPdate(statusChamado);
            }
        }

    }

    private void ChamarUPdate(string statusChamado)
    {
        int idChamado = Convert.ToInt32(LabelID.Text);
        string nomeLoginCadastrou = pegaNomeLoginUsuario.Text.ToUpper();
        string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();
        DateTime dtatual = DateTime.Now;
        string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
        try
        {
            int StatusIntChamado = Convert.ToInt32(statusChamado);
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

            {
                string strQuery = @"UPDATE [dbo].[aberturaChamado]
   SET 
[statusChamado]=@statusChamado,
[solucao]=@solucao,
[nomeTecnico]=@nomeTecnico,
[extratoDoChamado]=@extratoDoChamado,
[numeroSerieOuTag]=@numeroSerieOuTag
    where   id=" + idChamado + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                //commd.Parameters.Add("@sulucao", SqlDbType.NVarChar).Value = (object)txtSolucao.Text ?? DBNull.Value; //Caso a variavel seja nula   
                //commd.Parameters.Add("@dthrSolucao", SqlDbType.DateTime).Value = dataAtual;
                commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = StatusIntChamado; // status em espera
                commd.Parameters.Add("@solucao", SqlDbType.NVarChar).Value = (object)txtSolucao.Text ?? DBNull.Value; //Caso a variavel seja nula 
                commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = (object)nomeLoginCadastrou ?? DBNull.Value; //Caso a variavel seja nula  
                if (txtTagNserie.Text.Length >2)
                {
                    commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = txtExtratoChamado.Text += "-> Chamado Colocado em espera por: " + Nometecnico + " em: " + dtCadastroChamado + "Tag ou N-serie (" + txtTagNserie.Text + ") Solução: " + txtSolucao.Text + "\n";
                }
                else
                {
                    commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = txtExtratoChamado.Text += "-> Chamado Colocado em espera por: " + Nometecnico + " em: " + dtCadastroChamado + " Solução: " + txtSolucao.Text + "\n";
                }
                commd.Parameters.Add("@numeroSerieOuTag", SqlDbType.NVarChar).Value = (object)txtTagNserie.Text ?? DBNull.Value; //Caso a variavel seja nula 

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
                string url;
                url = "~/ChamadosAbertos.aspx";
                Response.Redirect(url);
            }

        }
        catch (Exception ex)
        {
            string erro = ex.Message;

        }
    }

    protected void btnEncaminhar_Click(object sender, EventArgs e)
    {
        if (DdlEncaminharParaTecnico.SelectedValue == "admin")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Não pode encaminhar chamado para o admin! Escolha algum tecnico!');", true);
        }
        else
        {
            string nomeDoTecnicoQueRecebeChamado = DdlEncaminharParaTecnico.SelectedValue;
            int idChamado = Convert.ToInt32(LabelID.Text);
            string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();
            DateTime dtatual = DateTime.Now;
            string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
            try
            {
                using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

                {
                    string strQuery = @"UPDATE [dbo].[aberturaChamado]
                                           SET 
                                        [statusChamado]=@statusChamado,
                                        [solucao]=@solucao,
                                        [nomeTecnico]=@nomeTecnico,
                                        [extratoDoChamado]=@extratoDoChamado
                                            where   id=" + idChamado + "";

                    SqlCommand commd = new SqlCommand(strQuery, com);
                    //commd.Parameters.Add("@sulucao", SqlDbType.NVarChar).Value = (object)txtSolucao.Text ?? DBNull.Value; //Caso a variavel seja nula   
                    //commd.Parameters.Add("@dthrSolucao", SqlDbType.DateTime).Value = dataAtual;
                    commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = 1; // status em espera
                    commd.Parameters.Add("@solucao", SqlDbType.NVarChar).Value = (object)txtSolucao.Text ?? DBNull.Value; //Caso a variavel seja nula 
                    commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = (object)nomeDoTecnicoQueRecebeChamado ?? DBNull.Value; //Caso a variavel seja nula   
                    commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = txtExtratoChamado.Text += "-> Chamado encaminhado por: " + Nometecnico + " em: " + dtCadastroChamado + " Solução: " + txtSolucao.Text + "\n";

                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();
                    string url;
                    url = "~/ChamadosAbertos.aspx";
                    Response.Redirect(url);
                }

            }
            catch (Exception ex)
            {
                string erro = ex.Message;

            }
        }

    }

    protected void btnReclassificar_Click(object sender, EventArgs e)
    {
       
    }

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();
        DateTime dtatual = DateTime.Now;
        string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
        int idChamado = Convert.ToInt32(LabelID.Text);
        try
        {
            string nomeLoginCadastrou = pegaNomeLoginUsuario.Text.ToUpper();
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

            {
                string strQuery = @"UPDATE [dbo].[aberturaChamado]
                                   SET 
                                [statusChamado]=@statusChamado,
                                [nomeTecnico]=@nomeTecnico,
                                [extratoDoChamado]=@extratoDoChamado,
                                [titulo]=@titulo

                                 where   id=" + idChamado + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                //commd.Parameters.Add("@sulucao", SqlDbType.NVarChar).Value = (object)txtSolucao.Text ?? DBNull.Value; //Caso a variavel seja nula   
                //commd.Parameters.Add("@dthrSolucao", SqlDbType.DateTime).Value = dataAtual;
                commd.Parameters.Add("@statusChamado", SqlDbType.Int).Value = 0;
                commd.Parameters.Add("@nomeTecnico", SqlDbType.NVarChar).Value = (object)nomeLoginCadastrou ?? DBNull.Value; //Caso a variavel seja nula   
                commd.Parameters.Add("@extratoDoChamado", SqlDbType.NVarChar).Value = txtExtratoChamado.Text += "-> Chamado Reclassificado por: " + Nometecnico + " em: " + dtCadastroChamado + " Solução: " + txtSolucao.Text + "\n";
                commd.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = (object)ddlTitulo.SelectedValue ?? DBNull.Value; //Caso a variavel seja nula   


                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
                string url;
                url = "~/ChamadosAbertos.aspx";
                Response.Redirect(url);
            }

        }
        catch (Exception ex)
        {
            string erro = ex.Message;

        }
    }
}
