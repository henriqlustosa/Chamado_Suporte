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
            LimpaCampos();
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
            carregaGrid();
        }
        Response.AppendHeader("Refresh",
        //Session TimeOut é em minutos e o Refresh e segundos, por isso o Session.Timeout * 60 JUNIOR>> 1 vale 20 segundos 3 vale 1 Minuto
        String.Concat((Session.Timeout * 200),
        //Página para onde o usuário será redirecionado
        ";URL=/chamados/login.aspx"));
    }

    private void LimpaCampos()
    {       
        txtOcorrencia.Text = "";          
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)//cadastrar ocorrencia
    {
        string Nometecnico = pegaNomeLoginUsuario.Text;
        if (txtOcorrencia.Text.Length <= 500 && txtSetor.Text.Length>=2)
        {

            ListaGrid L = new ListaGrid();
            try
            {
                L.cac = txtCac.Text;
                L.setor = txtSetor.Text;
                L.ocorrencia = txtOcorrencia.Text;
                L.nomeTecnico = Nometecnico;
                L.nomeContato = txtNomeContato.Text;
                L.titulo = ddlTitulo.SelectedValue;
                L.ramal = txtRamal.Text;
                ChamadosDAO.GravaChamados(L);
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

}
