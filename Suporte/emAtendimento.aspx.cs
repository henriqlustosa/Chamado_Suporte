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
using System.IO;

public partial class emAtendimento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            LimpaCampos();
            string id1 = Request.QueryString["IdChamado"];
            int id = Convert.ToInt32(id1);
            carregarAtendimento(id);
            MostraImagem(id);
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
        }

    }

    private void MostraImagem(int id)
    {
        imgChamado.ImageUrl = ChamadosDAO.MostraImagem(id, "Abertura");
        imgFechamento.ImageUrl = ChamadosDAO.MostraImagem(id, "Fechamento");
        if (imgChamado.ImageUrl != "")
        {
            LabelImagemTituloAbertura.Visible = true;
        }
        if (imgFechamento.ImageUrl != "")
        {
            LabelImagemTituloFechamanto.Visible = true;
        }
    }

    private void LimpaCampos()
    {
        LabelID.Text = "";
        txtOcorrencia.Text = "";
        txtExtratoChamado.Text = "";
        txtSolucao.Text = "";
    }

    private void carregarAtendimento(int id)
    {
        var l = ChamadosDAO.CarregaChamadoParaSerAtendido(id);
        LabelID.Text = Convert.ToString(l.id);
        txtCac.Text = l.cac;
        txtNomeContato.Text = l.nomeContato;
        txtSetor.Text = l.setor;
        txtRamal.Text = l.ramal;
        //txtTitulo.Text = l.titulo;
        txtTituloAberturaChamado.Text = l.titulo;
        btnLinkSolicitacao.Visible = false;
        if (l.titulo == "Retornar ao Funcionário" && l.cac == "HSPM00000 ")
        {
            btnLinkSolicitacao.Visible = true;
        }

        txtOcorrencia.Text = l.ocorrencia;
        txtHoraDtChamado.Text = l.HoraDtChamado;
        txtExtratoChamado.Text = l.extratoChamado;
        txtTagNserie.Text = l.tagNserie;
        //ddlTituloAlterar.SelectedValue = l.titulo;
        txtTutuloAlterarSePrecisar.Text = l.titulo;
        string statusExterno = l.statusDochamado;
        if (statusExterno == "6")
        {
            RbtDell.Checked = true;
        }
        if (statusExterno == "7")
        {
            RbtImpressora.Checked = true;
        }
        if (statusExterno == "8")
        {
            RbtInterManutencao.Checked = true;
        }
        if (statusExterno == "5")
        {
            RbtAtendimentoLocal.Checked = true;
        }
        labelOcorrenciaIdSolicitacao.Text = l.ocorrencia;
    }

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {

        string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();
        int idChamado = Convert.ToInt32(LabelID.Text);
        ListaGrid L = new ListaGrid();
        //if (ddlTituloAlterar.SelectedValue == "Outros")

        string palavra = "Outros"; 
        //if (txtTutuloAlterarSePrecisar.Text == "Outros")
        //{
        if (txtTutuloAlterarSePrecisar.Text.Contains(palavra))
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Não é possivel fechar um chamado com o Titulo ( Outros ) escolha um outro titulo que se encaixe no chamado!');", true);
        }
        else
        {
            L.id = idChamado;
            L.cac = txtCac.Text;
            L.solucao = txtSolucao.Text;
            L.nomeTecnico = Nometecnico;
            //L.extratoChamado = txtExtratoChamado.Text;
            L.SolucaoPFuncionarioVer = ddlTipoSolucao.SelectedValue;
            //L.tituloAlterar = ddlTituloAlterar.SelectedValue;
            L.tituloAlterar = txtTutuloAlterarSePrecisar.Text;
            L.setor = txtSetor.Text;
            L.nomeContato = txtNomeContato.Text;
            L.ramal = txtRamal.Text;
            ChamadosDAO.FinalizarChamados(L);
            if (FileUpload1.HasFile)
            {
                CadastrarImagem(L.id);
            }
            string url;
            url = "~/Suporte/ChamadosAbertos.aspx";
            Response.Redirect(url, false);
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
        else if (RbtInterManutencao.Checked == true)
        {
            statusChamado = "8";
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
        else if (RbtNoturno.Checked == true)
        {
            statusChamado = "11";
            ChamarUPdate(statusChamado);
        }
        else if (RbtDiurno.Checked == true)
        {
            statusChamado = "12";
            ChamarUPdate(statusChamado);
        }
        if (FileUpload1.HasFile)
        {
            int id = Convert.ToInt32(LabelID.Text);
            CadastrarImagem(id);
        }
    }

    private void ChamarUPdate(string statusChamado)
    {

        //  string nomeLoginCadastrou = pegaNomeLoginUsuario.Text.ToUpper();
        string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();

        ListaGrid L = new ListaGrid();
        L.id = Convert.ToInt32(LabelID.Text);
        L.cac = txtCac.Text;
        L.statusDochamado = statusChamado;
        L.solucao = txtSolucao.Text;
        L.nomeTecnico = Nometecnico;
        // L.extratoChamado = txtExtratoChamado.Text;
        L.tagNserie = txtTagNserie.Text;
        ChamadosDAO.ChamarUpdateEmAtendimentoChamado(L);
        string url;
        url = "~/Suporte/ChamadosAbertos.aspx";
        Response.Redirect(url, false);
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

            ListaGrid L = new ListaGrid();
            L.id = idChamado;
            L.cac = txtCac.Text;
            L.solucao = txtSolucao.Text;
            L.nomeTecnico = Nometecnico;
            L.nomeTecnicoRecebeChamado = nomeDoTecnicoQueRecebeChamado;
            // L.extratoChamado = txtExtratoChamado.Text;
            ChamadosDAO.EncaminharChamadoTelaAtendimento(L);
            if (FileUpload1.HasFile)
            {
                int id = Convert.ToInt32(LabelID.Text);
                CadastrarImagem(id);
            }
            string url;
            url = "~/Suporte/ChamadosAbertos.aspx";
            Response.Redirect(url, false);
        }

    }

    //protected void btnReclassificar_Click(object sender, EventArgs e)
    //{

    //}

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        string Nometecnico = pegaNomeLoginUsuario.Text.ToUpper();
        int idChamado = Convert.ToInt32(LabelID.Text);

        ListaGrid L = new ListaGrid();
        L.id = idChamado;
        L.cac = txtCac.Text;
        L.nomeTecnico = Nometecnico;
        L.solucao = txtSolucao.Text;
        //  L.extratoChamado = txtExtratoChamado.Text;
        //L.tituloAlterar = ddlTitulo.SelectedValue;
        L.tituloAlterar = txtReclassificarChamado.Text;
        ChamadosDAO.AtualizarTituloDoChamado(L);

        string url;
        url = "~/Suporte/ChamadosAbertos.aspx";
        Response.Redirect(url, false);
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

    [WebMethod]
    public static string[] getTituloAberturaChamado(string prefixo)
    {
        List<string> clientes = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT TOP 20 NomeTipoChamado  FROM [chamado_suporte].[dbo].[TipoChamado] where NomeTipoChamado LIKE '%' + @Texto +'%' group by NomeTipoChamado";
                cmd.Parameters.AddWithValue("@Texto", prefixo);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        clientes.Add(string.Format("{0}", sdr["NomeTipoChamado"]));
                    }
                }
                conn.Close();
            }
        }
        return clientes.ToArray();
    }


    //private string MostraImagem(int idImagem, string tipo)
    //{
    //    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
    //    {
    //        string img = "";
    //        try
    //        {
    //            con.Open();
    //            string query = "SELECT [img_chamado] FROM[chamado_suporte].[dbo].[ImgChamado] where id_chamado = " + idImagem + " and descricao='" + tipo + "' ";
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.Parameters.AddWithValue("@id", idImagem);

    //            byte[] imagemBytes = (byte[])cmd.ExecuteScalar();

    //            if (imagemBytes != null && imagemBytes.Length > 0)
    //            {
    //                // Converta os bytes da imagem em uma URL de dados para exibição na imagem
    //                string base64String = Convert.ToBase64String(imagemBytes);
    //                img = "data:image/jpeg;base64," + base64String; //imgChamado.ImageUrl
    //            }
    //            //else
    //            //{
    //            //    // Caso não haja imagem no banco de dados, você pode definir uma imagem padrão ou fazer algo apropriado aqui
    //            //    imgChamado.ImageUrl = "imagem_padrao.jpg"; // Substitua pelo caminho da imagem padrão desejada
    //            //}
    //        }
    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //            // Trate os erros adequadamente
    //        }
    //        if (tipo == "Abertura" && img != "")
    //        {
    //            LabelImagemTituloAbertura.Visible = true;
    //        }
    //        else if (tipo == "Fechamento" && img != "")
    //        {
    //            LabelImagemTituloFechamanto.Visible = true;
    //        }
    //        return img;
    //    }
    //}




    //Grava imagem gerada pelo tecnico
    public void CadastrarImagem(int id)
    {

        byte[] imagemBytes = null;

        if (FileUpload1.HasFile)
        {


            using (var memoryStream = new MemoryStream())
            {
                using (Stream inputStream = FileUpload1.PostedFile.InputStream)
                {
                    int bytesRead;
                    byte[] buffer = new byte[8192];

                    while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memoryStream.Write(buffer, 0, bytesRead);
                    }
                }

                imagemBytes = memoryStream.ToArray();

            }


        }

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[ImgChamado]
                  ([id_chamado]
                  ,[img_chamado]
                  ,[descricao])
            VALUES
                  (@id_chamado,@img_chamado,@descricao); SELECT SCOPE_IDENTITY();";
                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado", SqlDbType.Int).Value = id; // Substitua pelo ID do chamado apropriado
                commd.Parameters.Add("@img_chamado", SqlDbType.Image).Value = imagemBytes; //= imagemBytes no lugar de label
                commd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = "Fechamento";

                commd.CommandText = strQuery;
                com.Open();
                // O select na strQuery (SELECT SCOPE_IDENTITY())
                // sendo executado com o ExecuteScalar retorna o id da inserção
                int idImagem = Convert.ToInt32(commd.ExecuteScalar());
                com.Close();

                // Chama o método que ira fazer o select e irá passar para a tela na tag asp:Image
                //MostraImagem(idImagem);
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }

        }
    }


    protected void btnLinkSolicitacao_Click(object sender, EventArgs e)
    {
        string numero = labelOcorrenciaIdSolicitacao.Text.Replace(')', ' ');
        var i = numero.Split(':');
        int id = Convert.ToInt32(i[1]);
        Response.Redirect("~/Suporte/VisualizarSolicitacoes.aspx?IdChamado=" + id + "&IdChamado2=" + LabelID.Text);
    }
}
