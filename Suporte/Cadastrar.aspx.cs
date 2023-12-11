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
using System.Drawing;

public partial class Cadastrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!this.IsPostBack)
        {
            LimpaCampos();
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
            carregaGrid();
            //ddlTitulo.SelectedValue = "**Selecione**";
        }
        
    }

    private void LimpaCampos()
    {       
        txtOcorrencia.Text = "";
        txtNomeContato.Text="";
        txtSetor.Text="";
        txtRamal.Text = "";
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)//cadastrar ocorrencia
    {
        string Nometecnico = pegaNomeLoginUsuario.Text;

     bool RestSetorExiste=VerificaSetorExiste(txtSetor.Text);
        bool tituloExiste = ChamadosDAO.verificaTituloExiste(txtTituloAberturaChamado.Text);

        //if (ddlTitulo.Text != "**Selecione**")
            if (tituloExiste == true)
            {

            if (RestSetorExiste == true)
            {
                if (txtOcorrencia.Text.Length <= 500 && txtSetor.Text.Length >= 2)
                {

                    ListaGrid L = new ListaGrid();
                    try
                    {
                        L.cac = txtCac.Text;
                        L.setor = txtSetor.Text;
                        L.ocorrencia = txtOcorrencia.Text;
                        L.nomeTecnico = Nometecnico;
                        L.nomeContato = txtNomeContato.Text;
                        //L.titulo = ddlTitulo.SelectedValue;
                        L.titulo = txtTituloAberturaChamado.Text;
                        L.ramal = txtRamal.Text;
                        ChamadosDAO.GravaChamados(L);
                        this.Dispose();
                        Response.Redirect("Cadastrar.aspx");

                    }
                    catch (Exception ex)
                    {
                        string erro = ex.Message;
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
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('O Setor que está colocando não existe na Base de Dados >>>>> Verifique se selecionou o setor correto  >>>>>>>Se ele não existe na lista coloque setor OUTROS  >>>>> Para cadastrar um novo setor é só ir em Administrativo --> Cadastrar Setor e lá incluir o setor >>>> Duvidas procure o Junior / Kelly / Eduardo  >>>>> na hora de finalizar o chamado da pra trocar o setor OUTROS para o setor verdadeiro então deixe na abertura de chamado o nome do setor correto!');", true);

            }
        }else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Informe Titulo');", true);

        }

    }

    private bool VerificaSetorExiste(string txtSetorExiste)
    {
        bool valido;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))

        {
            string strquerySelect;
            strquerySelect = @"SELECT [setor] FROM [chamado_suporte].[dbo].[LocalSetor] where setor='"+ txtSetorExiste + "'";
            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();
            valido = dr.Read();
            com.Close();
        }
        return valido;
    }

    private void carregaGrid()
    {        
        GridViewChamados.DataSource = ChamadosDAO.MostraChamadosNaTelaStatus0();
        GridViewChamados.DataBind();
    }
    
    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)//Visualizar
    {
        int id = Convert.ToInt32(GridViewChamados.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        //atualizaStatus(id);
        Response.Redirect("~/Suporte/VisualizarChamados.aspx?IdChamado=" + id);    
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

    //protected void Unnamed1_Click(object sender, EventArgs e)
    //{
    //    //var imagem =  FileUpload1;
    //    byte[] imagemBytes = null;

    //    if (FileUpload1.HasFile)
    //    {


    //        using (var memoryStream = new MemoryStream())
    //        {
    //            using (Stream inputStream = FileUpload1.PostedFile.InputStream)
    //            {
    //                int bytesRead;
    //                byte[] buffer = new byte[8192];

    //                while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
    //                {
    //                    memoryStream.Write(buffer, 0, bytesRead);
    //                }
    //            }

    //            imagemBytes = memoryStream.ToArray();



    //        }


    //    }

    //    DateTime dtatual = DateTime.Now;
    //    string dtCadastroChamado = dtatual.ToString().Substring(0, 16);
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
    //    {
    //        try
    //        {
    //            string strQuery = @"INSERT INTO [dbo].[ImgChamado]
    //              ([id_chamado]
    //              ,[img_chamado]
    //              ,[descricao])
    //        VALUES
    //              (@id_chamado,@img_chamado,@descricao); SELECT SCOPE_IDENTITY();";
    //            SqlCommand commd = new SqlCommand(strQuery, com);
    //            commd.Parameters.Add("@id_chamado", SqlDbType.Int).Value = 44; // Substitua pelo ID do chamado apropriado
    //            commd.Parameters.Add("@img_chamado", SqlDbType.Image).Value = imagemBytes;
    //            commd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = "Teste";

    //            commd.CommandText = strQuery;
    //            com.Open();
    //            // O select na strQuery (SELECT SCOPE_IDENTITY())
    //            // sendo executado com o ExecuteScalar retorna o id da inserção
    //            int idImagem = Convert.ToInt32(commd.ExecuteScalar());
    //            com.Close();

    //            // Chama o método que ira fazer o select e irá passar para a tela na tag asp:Image
    //            MostraImagem(idImagem);
    //        }
    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //            throw;
    //        }

    //    }
    //    //GravaChamados(imagem);

    //}
    //public void MostraImagem(int idImagem)
    //{
    //    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chamado_suporteConnectionString"].ToString()))
    //    {
    //        try
    //        {
    //            con.Open();
    //            string query = "SELECT [img_chamado] FROM[chamado_suporte].[dbo].[ImgChamado] where id_img = " + idImagem + "";
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.Parameters.AddWithValue("@id", idImagem);

    //            byte[] imagemBytes = (byte[])cmd.ExecuteScalar();

    //            if (imagemBytes != null && imagemBytes.Length > 0)
    //            {
    //                // Converta os bytes da imagem em uma URL de dados para exibição na imagem
    //                string base64String = Convert.ToBase64String(imagemBytes);
    //                imgChamado.ImageUrl = "data:image/jpeg;base64," + base64String;
    //            }
    //            else
    //            {
    //                // Caso não haja imagem no banco de dados, você pode definir uma imagem padrão ou fazer algo apropriado aqui
    //                imgChamado.ImageUrl = "imagem_padrao.jpg"; // Substitua pelo caminho da imagem padrão desejada
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //            // Trate os erros adequadamente
    //        }

    //    }
    //}




}
